public class Paciente
{
    // Atributos de tipo primitivo
    public string Nombre { get; set; }
    public string Cedula { get; set; }
    public string Telefono { get; set; }

    // Constructor explícito (POO)
    public Paciente(string nombre, string cedula, string telefono)
    {
        Nombre = nombre;
        Cedula = cedula;
        Telefono = telefono;
    }
}