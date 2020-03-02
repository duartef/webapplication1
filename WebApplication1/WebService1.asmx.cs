using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public Movimiento GuardarMovimiento(Movimiento movimiento)
        {
            try
            {
                return movimiento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public Imagen GuardarImagen(Imagen imagen)
        {
            try
            {
                return imagen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public Imagen[] RetrieveImages()
        {
            try
            {
                List<Imagen> imagenes = new List<Imagen>();

                string path1 = "Images//128.png";
                //byte[] imgdata1 = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath(path1));
                byte[] imgdata1 = System.IO.File.ReadAllBytes(path1);
                Imagen imagen1 = new Imagen();
                imagen1.Foto = imgdata1;
                imagen1.Id = 1;
                imagenes.Add(imagen1);

                string path2 = "anadir.png";
                byte[] imgdata2 = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath(path2));
                Imagen imagen2 = new Imagen();
                imagen1.Foto = imgdata2;
                imagen1.Id = 2;
                imagenes.Add(imagen2);

                return imagenes.ToArray();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
