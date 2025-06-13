using Microsoft.AspNetCore.Mvc;
using TesteManipularJson.JSON;
using TesteManipularJson.Models;

namespace TesteManipularJson.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ManipularController : ControllerBase
{
    private readonly List<User> _users;
    
    public ManipularController(DesserializeJson desserializeJson)
    {
        _users = desserializeJson.Lista();
    }


    [HttpGet("/get")]
    public async Task<String> Get()
    {
        var paises = _users.Select(p => p.Country).Distinct();
        var numPaises = paises.Count();

        string listaString = string.Join("", _users.Select(p => $"Nome: {p.Name}, País: {p.Country}, Carro: {p.Car}\n")); 
        string final = $"{listaString} {numPaises}";
        return final;
    }

    [HttpGet("/get/ford")]
    public async Task<string> GetSpecific()
    {
        List<User> ford = new List<User>();
        int contador = 0;
        foreach(var item in _users) 
        {
            if (item.Car == "Ford")
            {
                ford.Add(item);
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
