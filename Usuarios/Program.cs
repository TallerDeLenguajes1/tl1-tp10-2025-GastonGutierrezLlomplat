using System.Text.Json;
using espacioUsuarios;

string url = "https://jsonplaceholder.typicode.com/users";

// 1
HttpClient client = new HttpClient();

// 2
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();

// 3
string responseBody = await response.Content.ReadAsStringAsync();
List<Usuario> listUsuarios = JsonSerializer.Deserialize<List<Usuario>>(responseBody);

// 4. Mostrar nombre, correo electronico y domicilio de los 5 primeros

for (int i = 0; i < 5; i++)
{
    var usuario = listUsuarios[i];

    Console.WriteLine("Nombre: " + usuario.name);
    Console.WriteLine("Correo electrónico : " + usuario.email);
    Console.WriteLine("Domicilio: ");
    Console.WriteLine(" Calle: " + usuario.address.street);
    Console.WriteLine(" Departamento: " + usuario.address.suite);
    Console.WriteLine(" Ciudad: " + usuario.address.city);
    Console.WriteLine(" Código postal: " + usuario.address.zipcode);
    Console.WriteLine(" Geolocalización: ");
    Console.WriteLine("     Latitud: " + usuario.address.geo.lat);
    Console.WriteLine("     Longitud: " + usuario.address.geo.lng);
    Console.WriteLine();
}

// 5. Guardar JSON

string jsonUsuarios = JsonSerializer.Serialize(listUsuarios);
File.WriteAllText("usuarios.json", jsonUsuarios);

