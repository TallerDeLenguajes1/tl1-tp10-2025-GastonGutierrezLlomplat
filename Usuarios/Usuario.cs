namespace espacioUsuarios;

class Usuario
{
    public int id { get; set; }
    public string name { get; set; }
    public string username { get; set; }
    public string email { get; set; }

    public Address address { get; set; }
}

class Address
{
    public string street { get; set; }
    public string suite { get; set; }
    public string city { get; set; }
    public string zipcode { get; set; }
    public Geo geo { get; set; }
}

class Geo
{
    public string lat { get; set; }
    public string lng { get; set; }
}