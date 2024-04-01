using System;
using System.Collections.Generic;

namespace Backend.Models.DB
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? Activo { get; set; }
    }
}
