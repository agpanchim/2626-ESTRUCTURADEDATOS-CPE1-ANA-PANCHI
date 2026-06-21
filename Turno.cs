public class Turno
{
    // Atributos primitivos y compuestos (POO)
    public int NumeroTurno { get; set; }
    public string Fecha { get; set; }
    public string Hora { get; set; }
    public string Especialidad { get; set; }
    public Paciente Paciente { get; set; } // Asociación orientada a objetos

    // Constructor explícito (POO)
    public Turno(int numeroTurno, string fecha, string hora, string especialidad, Paciente paciente)
    {
        NumeroTurno = numeroTurno;
        Fecha = fecha;
        Hora = hora;
        Especialidad = especialidad;
        Paciente = paciente;
    }
}