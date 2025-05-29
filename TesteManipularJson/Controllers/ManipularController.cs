using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TesteManipularJson.JSON;
using TesteManipularJson.Models;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TesteManipularJson.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ManipularController : ControllerBase
{
    private readonly DesserializeJson _desserializeJson;
    public ManipularController(DesserializeJson desserializeJson)
    {
        _desserializeJson = desserializeJson;
    }

    [HttpGet("/get")]
    public async Task<String> Get()
    {
        var result = _desserializeJson.Lista();
        var paises = result.Select(p => p.Country).Distinct();
        var numPaises = paises.Count();

        string listaString = string.Join("", result.Select(p => $"Nome: {p.Name}, País: {p.Country}, Carro: {p.Car}\n")); 
        string final = $"{listaString} {numPaises}";
        return final;
    }

    [HttpGet("/get/ford")]
    public async Task<string> GetSpecific()
    {
        var array = _desserializeJson.Lista().ToArray();
        List<User> ford = new List<User>();
        int contador = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Car == "Ford")
            {
                ford.Add(array[i]);
                contador++;
            }
        }

        var paises = ford.Select(p => p.Country).Distinct();
        var paisesNum = paises.Count();
        var bbb = ford.OrderBy(p => p.Country);
        string stringFord = string.Join("", bbb.Select(p => $"Nome: {p.Name}, País:{p.Country}\n"));

        string final = $"O numero de pessoas que usam Ford é de {contador} e estão separadas em {paisesNum} países, segue a baixa a lista\n{stringFord}";

        return final;
    }

}
