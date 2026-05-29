using CSV_Cliente;
using System.Net.Http.Json;

// Url de la API: se puede pasar como argumento o usar un valor por defecto
string apiUrl = args.Length > 0 ? args[0] : "http://localhost:5164/api/Personas";
// Ruita relativa al CSV
string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sample_personas_v2.csv");

Console.WriteLine(Path.GetFullPath(csvPath));
using HttpClient client = new HttpClient();

// Leer y parsear el CSV para obtener la lista de personas
var personas = Procesador.LeerParsear(csvPath);

try
{
    // Envia la lista de personas a la API usando POST
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
