using CSV_Cliente;
using System.Net.Http.Json;


string apiUrl = args.Length > 0 ? args[0] : "http://localhost:5164/api/Personas";
string csvPath = Path.Combine("..", "..", "..", "..", "samples", "sample_personas_v2.csv");

Console.WriteLine(Path.GetFullPath(csvPath));
using HttpClient client = new HttpClient();

var personas = Procesador.LeerParsear(csvPath);

try
{
    var response = await client.PostAsJsonAsync(apiUrl, personas);

    if (response.IsSuccessStatusCode) { 
        Console.WriteLine("Personas enviadas exitosamente.");
    }
    else
    {
        Console.WriteLine("Error al enviar la persona: " + response.StatusCode);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Fallo de conexion: {ex.Message}");
}
