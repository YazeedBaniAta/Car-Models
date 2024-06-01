using Application.Interfaces;
using Application.Models;
using Application.RepositoryInterfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;
using Polly.Wrap;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace Application.Services;

public class CarMakeService : ICarMakeService
{
    private readonly ICarMakeRepository _carMakeRepository;
    private readonly HttpClient _client;

    public CarMakeService(ICarMakeRepository carMakeRepository, HttpClient client)
    {
        _carMakeRepository = carMakeRepository;
        _client = client;
    }

    public async Task<List<string>> GetCarModelsAsync(string carMakeName, int modelYear)
    {
        List<CarMakeDto> carsMake = _carMakeRepository.GetAllCarMakeFromCSVFile();
        List<string> carModels = [];
        if (carsMake.Count > 0)
        {
            int? carMakeId = carsMake.Find(m => m.make_name.Equals(carMakeName, StringComparison.OrdinalIgnoreCase))?.make_id;

            return await GetPolicyWrap("GetModelsForMakeIdYear").ExecuteAsync(async () =>
            {
                var httpResponse = await _client.GetAsync($"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{carMakeId}/modelyear/{modelYear}?format=json");
                if (!httpResponse.IsSuccessStatusCode)
                {
                    return [];
                }

                var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CarModelsResponseDto>(jsonResponse);

                carModels = result?.Results.Select(a=>a.Model_Name).ToList()!;

                return carModels;
            });

        }
        return carModels;
    }

    private static AsyncPolicyWrap GetPolicyWrap(string callName)
    {
        var retryPolicy = Policy.Handle<HttpRequestException>(exception => exception.StatusCode != HttpStatusCode.InternalServerError).RetryAsync(
           Convert.ToInt32(3), (ext, attempt) =>
           {
               Console.WriteLine("faild to call  API " + callName + "exception:" + ext.Message + "number of attempt" + attempt.ToString());
           });
        var timeOutPolicy = Policy.TimeoutAsync(Convert.ToInt32(190), onTimeoutAsync: (context, timeSpan, task) =>
        {
            Console.WriteLine("Timeout calling " + callName + " delegate fired after " + timeSpan.TotalMilliseconds);
            return Task.CompletedTask;
        });
        return Policy.WrapAsync(retryPolicy, timeOutPolicy);
    }

}
