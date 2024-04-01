using System;
using System.Collections.Generic;

namespace Backend.Models.DB
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? IdEstado { get; set; }
        public int? IdTipoElab { get; set; }
        public bool? Defectuso { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public bool? Activo { get; set; }

        public virtual Estado? IdEstadoNavigation { get; set; }
        public virtual TipoElaboracion? IdTipoElabNavigation { get; set; }
    }
}
