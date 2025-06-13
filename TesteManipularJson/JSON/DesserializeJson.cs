using Newtonsoft.Json;
using TesteManipularJson.Models;

namespace TesteManipularJson.JSON;

public class DesserializeJson
{
    public List<User> Lista()
    {
        StreamReader file = System.IO.File.OpenText(@"JSON\RandomData.json");
        JsonSerializer serializer = new JsonSerializer();
        List<User> users = (List<User>)serializer.Deserialize(file, typeof(List<User>));

        return users;
    }
}
