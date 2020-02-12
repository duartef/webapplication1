using System;
using System.Collections.Generic;
using System.Web;

namespace WebApplication1
{
    [Serializable]
    public class Imagen
    {
        public int Id { get; set; }
        public int IdMovimiento { get; set; }
        public byte[] Foto { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public bool Descargado { get; set; }
    }
}