using Application.Models;
using Application.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace Infrastructure.Repositories;

public class CarMakeRepository : ICarMakeRepository
{

    public List<CarMakeDto> GetAllCarMakeFromCSVFile()
    {
        string csvPath = "CarMake.csv";
        if (File.Exists(csvPath))
        {
            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<CarMakeDto>().ToList();
        }
        else
        {
            Console.WriteLine(new FileNotFoundException("the file dose not exist"));
            return new List<CarMakeDto> { };
        }
    }

}
