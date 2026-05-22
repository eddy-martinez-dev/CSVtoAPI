using CSV_Cliente;
using System.Net.Http.Json;


string apiUrl = args.Length > 0 ? args[0] : "http://localhost:5164/api/Personas";
using HttpClient client = new HttpClient();

var personas = Procesador.LeerParsear(@"C:\Users\Eddy Martinez\Desktop\Prueba Tecnica 2026-05\CSVtoAPI\samples\sample_personas_v2.csv");


    try
    {
        var response = await client.PostAsJsonAsync(apiUrl, personas);

        if (response.IsSuccessStatusCode)
            Console.WriteLine("Personas enviadas exitosamente.");
        else
        {
            Console.WriteLine("Error al enviar la persona: " + response.StatusCode);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fallo de conexion: {ex.Message}");
    }
