# Prueba Técnica — CSV to API REST con .NET y SQLite

Solución compuesta por dos proyectos independientes: una API REST en ASP.NET Core con Clean Architecture y un cliente de consola en .NET que lee un archivo CSV y envía los datos a la API.

---

## Requisitos previos

- .NET SDK 10 (API REST)
- .NET SDK 8 o superior (cliente consola)
- Entity Framework Core CLI

---

## Tecnologías utilizadas

| Proyecto | Tecnologías |
|---|---|
| API REST | ASP.NET Core, Entity Framework Core, SQLite, Swashbuckle (Swagger) |
| Cliente consola | .NET, HttpClient, System.Text.Json |

---

## Arquitectura

La API REST está implementada siguiendo **Clean Architecture** con 4 capas:

| Capa | Proyecto | Responsabilidad |
|---|---|---|
| Dominio | API_REST.Domain | Entidades del negocio |
| Aplicación | API_REST.Application | Interfaces y contratos |
| Infraestructura | API_REST.Infrastructure | EF Core, SQLite, repositorios |
| Presentación | API_REST | Controladores, Swagger, DI |

---

## Configuración y ejecución

### 1. Clonar el repositorio

```bash
git clone <url-del-repositorio>
cd CSVtoAPI
```

### 2. Levantar la API REST

```bash
cd API_REST
dotnet ef database update
dotnet run
```

La API quedará disponible en:
- `http://localhost:5164`
- Swagger UI: `http://localhost:5164/swagger`

### 3. Ejecutar el cliente consola

Con la API corriendo, abrir otra terminal:

```bash
cd CSVtoAPI
dotnet run
```

El cliente buscará automáticamente el archivo CSV en `samples/sample_personas_v2.csv` relativo a la raíz de la solución.

---

## Endpoints de la API

### POST /api/Personas

Recibe una lista de personas en formato JSON y las guarda en SQLite.

**Request body:**
```json
[
  {
    "name": "Juan",
    "lastName": "Pérez",
    "age": 30,
    "birthate": "1994-05-15T00:00:00"
  }
]
```

**Response exitosa (200):**
```json
{
  "message": "Records saved successfully"
}
```

### GET /api/Personas

Retorna todos los registros almacenados en la base de datos.

**Response exitosa (200):**
```json
[
  {
    "id": 1,
    "name": "Juan",
    "lastName": "Pérez",
    "age": 30,
    "birthate": "1994-05-15T00:00:00"
  }
]
```

### GET /api/Personas/{id}

Retorna un registro específico por su Id.

---

## Formato del archivo CSV

El archivo CSV debe usar `|` como separador y contener los siguientes encabezados:

```
Nombre|Apellido|FechaNacimiento|Edad
Juan|Pérez|1994-05-15|30
María|Gómez|1999-03-20|25
```

Un archivo de ejemplo se encuentra en `samples/sample_personas_v2.csv`.

---

## Validaciones implementadas

### Cliente consola
- El archivo CSV no puede estar vacío
- Debe contener los encabezados: `Nombre`, `Apellido`, `FechaNacimiento`, `Edad`
- Registros con datos inválidos son omitidos e informados en consola

### API REST
- Nombre requerido
- Apellido requerido
- Edad mayor que 0
- FechaNacimiento válida (no puede ser `DateTime.MinValue`)

---

## Pasos realizados

| Paso | Descripción |
|---|---|
| 1 | Instalar .NET SDKs y dotnet-ef |
| 2 | Crear solución y proyectos independientes |
| 3 | Crear archivo CSV de muestra |
| 4 | Instalar EF Core SQLite en la API |
| 5 | Crear entidad Persona |
| 6 | Configurar AppDbContext con Dependency Injection |
| 7 | Crear migraciones y base de datos SQLite |
| 8 | Implementar PersonasController con POST y GET |
| 9 | Confirmar System.Text.Json en el cliente consola |
| 10 | Implementar lectura y parseo del CSV |
| 11 | Serializar y enviar datos a la API via HttpClient |
| 12 | Manejo de respuesta HTTP en consola |
| 13 | Probar API con Swagger y Postman |
| 14 | Prueba de integración completa |
| 15 | Probar casos de error y validaciones |
| 16 | Migrar API REST a Clean Architecture |
| 17 | Corregir ruta del CSV a ruta relativa |

---

## Notas

- La base de datos SQLite (`*.db`) está excluida del repositorio vía `.gitignore`. Se genera automáticamente al ejecutar `dotnet ef database update`.
- La ruta del CSV es relativa a la raíz de la solución, no depende de la máquina donde se ejecute.