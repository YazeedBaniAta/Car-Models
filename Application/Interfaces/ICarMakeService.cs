using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;
public interface ICarMakeService
{
    Task<List<string>> GetCarModelsAsync(string carMakeName, int modelYear);
}
