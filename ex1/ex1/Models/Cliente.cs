﻿namespace ex1.Models
{

    public class Cliente
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Dni { get; set; } = null!;

        public DateOnly Fecha { get; set; }
    }
}

