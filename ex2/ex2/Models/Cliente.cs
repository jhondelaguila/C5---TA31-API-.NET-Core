namespace ex2.Models
{

    public class Cliente
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Direccion { get; set; }

        public string? Dni { get; set; }

        public DateOnly? Fecha { get; set; }
    }
}