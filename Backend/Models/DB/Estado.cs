using System;
using System.Collections.Generic;

namespace Backend.Models.DB
{
    public partial class Estado
    {
        public Estado()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdEstado { get; set; }
        public string? Nombre { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
