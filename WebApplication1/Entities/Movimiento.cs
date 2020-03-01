using System;
using System.Collections.Generic;
using System.Web;

namespace WebApplication1
{
    [Serializable]
    public class Movimiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string Institucion { get; set; }
    }
}