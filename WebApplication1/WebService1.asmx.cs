using System;
using System.Collections.Generic;
using System.Net.Mail;
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

        //Este método lo hago para exponer todos los dtos que creemos
        [WebMethod]
        public string Test(Imagen imagen, Movimiento movimiento)
        {
            return "";
        }

        [WebMethod]
        public Movimiento GuardarMovimiento(Movimiento movimiento)
        {
            try
            {
                return MovimientoDAO.NuevoMovimiento(movimiento);
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        [WebMethod]
        public Imagen GuardarImagen(Imagen imagen)
        {
            try
            {
                return ImagenDAO.NuevaImagen(imagen);
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
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

        [WebMethod]
        public object[] RetrieveEntitiesWhere(object dto, string where)
        {
            try
            {
                switch (dto.GetType().Name)
                {
                    case "Movimiento":
                        return MovimientoDAO.RetrieveEntitiesWhere(dto, where).ToArray();
                    //case "Imagen":
                    //    return ImagenDAO.RetrieveEntitiesWhere(dto, where).ToArray();
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        [WebMethod]
        public string[] GetNombresPacientes()
        {
            try
            {
                return MovimientoDAO.GetNombresPacientes().ToArray();
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        [WebMethod]
        public string[] GetNombresInstituciones()
        {
            try
            {
                return MovimientoDAO.GetNombresInstituciones().ToArray();
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }


        [WebMethod]
        public int GetIdMovimiento()
        {
            try
            {
                return MovimientoDAO.GetLatestId();
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        private void Log(Exception ex)
        {
            EnviarNotificacion(ex);

            //string mydocpath = "C:\\Log";
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();

            //sb.AppendLine("\r\nLog Entry : ");
            //sb.AppendLine(string.Format("Error ocurrido a las: {0}", DateTime.Now));
            //sb.AppendLine(string.Format("Mensaje del error: {0}", ex.Message));
            ////sb.AppendLine(string.Format("Mensaje Inner del error: {0}", ex.InnerException.Message));
            //sb.AppendLine(string.Format("StackTrace del error: {0}", ex.StackTrace));
            //sb.AppendLine("------------------------------------------------");
            //sb.AppendLine();
            //sb.AppendLine();

            //using (StreamWriter outfile = new StreamWriter(mydocpath + @"\Goc System Log.txt", true))
            //{
            //    outfile.Write(sb.ToString());
            //}
        }

        internal static void EnviarNotificacion(Exception ex)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add("duarte.fabricio.90@gmail.com");
                message.Subject = "Error en la aplicacion de PalMed";
                message.From = new System.Net.Mail.MailAddress("system_as@outlook.com", "SystemAs");
                message.Priority = MailPriority.High;

                string text = string.Format("Error ocurrido en PaceMakers: {0}", ex.Message);
                message.Body = text;

                SmtpClient smtpClient = new SmtpClient("smtp.live.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("system_as@outlook.com", "q1w2e3r4t5");

                smtpClient.Send(message);
            }
            catch (Exception)
            {
            }
        }
    }
}
