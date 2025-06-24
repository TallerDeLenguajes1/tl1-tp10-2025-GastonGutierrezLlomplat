using espacioTarea;
using System.Text.Json;

string url = "https://jsonplaceholder.typicode.com/todos/";

// 1. Crear una Instancia de HttpClient:
HttpClient client = new HttpClient();

// 2. Enviar Solicitud GET: Se envía una solicitud GET a la URL especificada y se verifica que la respuesta sea exitosa
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();

// 3. Leer y Deserializar la Respuesta:
string responseBody = await response.Content.ReadAsStringAsync();
List<Tarea> listTarea = JsonSerializer.Deserialize<List<Tarea>>(responseBody);

// 4. Mostrar informacion

foreach (var respuesta in listTarea)
{
    string estado;
    if (respuesta.completed == true)
    {
        estado = "completada";
    }
    else
    {
        estado = "pendiente";
    }

    Console.WriteLine("Titulo: " + respuesta.title + " | Estado: " + estado);
    Console.WriteLine("");
}

// 5. Ordenar informacion

var tareasOrdenadas = listTarea
    .OrderBy(t => t.completed) // false primero, luego true
    .ToList();

foreach (var tarea in tareasOrdenadas)
{
    string estado = tarea.completed ? "completada" : "pendiente";
    Console.WriteLine($"Titulo: {tarea.title} || Estado: {estado}");
}

// 6. Serializar y guardar JSON

string jsonString = JsonSerializer.Serialize(listTarea);
File.WriteAllText("tareas.json", jsonString);
