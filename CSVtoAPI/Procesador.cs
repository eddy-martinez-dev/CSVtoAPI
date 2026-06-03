using CSV_Cliente.Models;

namespace CSV_Cliente
{
    public class Procesador
    {
        public static List<PersonaCreateDTo> LeerParsear(string rutaArchivo)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
                throw new ArgumentException("rutaArchivo no puede ser vacío", nameof(rutaArchivo));

            var listaPersonas = new List<PersonaCreateDTo>();

            try
            {
                var todasLasLineas = File.ReadAllLines(rutaArchivo);

                if (todasLasLineas.Length == 0)
                {
                    Console.WriteLine("El archivo CSV está vacío.");
                    return listaPersonas;
                }

                // Validar encabezados solo en la primera línea
                var encabezados = todasLasLineas[0].Split('|');
                var encabezadosEsperados = new[] { "Nombre", "Apellido", "FechaNacimiento", "Edad" };

                if (!encabezadosEsperados.All(e => encabezados.Contains(e)))
                {
                    Console.WriteLine("El archivo no tiene encabezados válidos.");
                    return listaPersonas;
                }

                // Iterar desde la segunda línea
                var lineas = todasLasLineas.Skip(1);

                foreach (var line in lineas)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var campos = line.Split('|');

                    if (campos.Length == 4)
                    {
                        var persona = new PersonaCreateDTo
                        {
                            Name = campos[0],
                            LastName = campos[1],
                            Birthate = DateTime.TryParse(campos[2], out DateTime birthDate) ? birthDate : DateTime.MinValue,
                            Age = int.TryParse(campos[3], out int e) ? e : 0
                        };

                        if (string.IsNullOrWhiteSpace(persona.Name) ||
                            string.IsNullOrWhiteSpace(persona.LastName) ||
                            persona.Age <= 0 ||
                            persona.Birthate == DateTime.MinValue)
                        {
                            Console.WriteLine($"Registro inválido omitido: {line}");
                            continue;
                        }

                        listaPersonas.Add(persona);
                    }
                    else
                    {
                        Console.WriteLine($"Línea con formato incorrecto: {line}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            }

            return listaPersonas;
        }
    }
}
