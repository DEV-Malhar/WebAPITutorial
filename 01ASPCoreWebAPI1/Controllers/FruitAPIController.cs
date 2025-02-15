using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01ASPCoreWebAPI1.Controllers;

[Route("api/fruitapi")]
[ApiController]
public class FruitAPIController : ControllerBase
{
    public List<string> fruits = new List<string>()
    {
        "Apple",
        "Banana",
        "Cherry",
        "Date",
        "Elderberry",
        "Fig",
        "Grape"
    };

    [HttpGet]
    public List<string> GetFruit()
    {
        return fruits;
    }

    [HttpGet("{id}")]                   //this is used for passing parameters through id
    public string GetFruitbyIndex(int id)
    {
        return fruits.ElementAt(id);    //this is used for passing parameters
    }
}
