// using System.Text.Json;
// using Deserializer.Models;

// string fileName = "person.json";
// string jsonString = File.ReadAllText(fileName);

// // Console.WriteLine(jsonString);

// var options = new JsonSerializerOptions
// {
//     PropertyNameCaseInsensitive = true,    
// };

// Person? person = JsonSerializer.Deserialize<Person>(jsonString, options);

// Console.WriteLine($"The first name is {person!.FirstName}");

using System.Net.Http.Json;
using System.Text.Json;
using Deserializer.Models;



using HttpClient client = new() {
    BaseAddress = new Uri("http://localhost:5118/")
};

// OPCION 3 --------------------------------------------------------------------------------------------
// SIN DECLARAR MODELO
var response = await client.GetAsync("weatherforecast");

if (response.IsSuccessStatusCode)
{
    var jsonString = await response.Content.ReadAsStringAsync();

    using (JsonDocument jsonDocument = JsonDocument.Parse(jsonString))
    {
        JsonElement root = jsonDocument.RootElement;

        Console.WriteLine(root.ValueKind);

        foreach (var temp in root.EnumerateArray())
        {
            Console.WriteLine(temp.GetProperty("summary").ToString());
        }
    }
}
else
{
    Console.WriteLine($"Failed to get data. Status code: {response.StatusCode}");
}
    
// OPCION 2 --------------------------------------------------------------------------------------------
// ESTA ES LA OPTIMA
// var opt = new JsonSerializerOptions
// {
//     PropertyNameCaseInsensitive = true,
// };

// var temperatures = await client.GetFromJsonAsync<Temperature[]>("weatherforecast", opt);

// if (temperatures != null)
// {
//     foreach (var temp in temperatures)
//     {
//         Console.WriteLine($"Date: {temp.Date}, Temp: {temp.TemperatureC}, Summary: {temp.Summary}");
//     }
// }
// else
// {
//     Console.WriteLine("Failed to deserialize data.");
// }

// OPCION 1 --------------------------------------------------------------------------------------------
// var response = await client.GetAsync("weatherforecast");

// if (response.IsSuccessStatusCode)
// {
//     var temperatures = await JsonSerializer.DeserializeAsync<Temperature[]>(await response.Content.ReadAsStreamAsync(), opt);

//     if (temperatures != null)
//     {
//         foreach (var temp in temperatures)
//         {
//             Console.WriteLine($"Date: {temp.Date}, Temp: {temp.TemperatureC}, Summary: {temp.Summary}");
//         }
//     }
//     else
//     {
//         Console.WriteLine("Failed to deserialize data.");
//     }
// }
// else
// {
//     Console.WriteLine($"Failed to get data. Status code: {response.StatusCode}");
// }