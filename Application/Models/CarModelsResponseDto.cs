using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models;

public class CarModelsResponseDto
{
    public int Count { get; set; }
    public string Message { get; set; }
    public string SearchCriteria { get; set; }
    public List<CarResults> Results { get; set; } = [];
}

public class CarResults
{
    public int Make_ID { get; set; }
    public string Make_Name { get; set; }
    public int Model_ID { get; set; }
    public string Model_Name { get; set; }
}
