using System;
using System.Collections.Generic;

namespace Backend.Models.DB
{
    public partial class TipoElaboracion
    {
        public TipoElaboracion()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdTipo { get; set; }
        public string? Nombre { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
