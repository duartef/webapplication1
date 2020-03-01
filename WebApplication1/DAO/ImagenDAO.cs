using System;
using System.Collections.Generic;
using System.Data;
using WebApplication1;

namespace WebApplication1
{
    public class ImagenDAO : DaoBase
    {
        public static Imagen NuevaImagen(Imagen ima)
        {
            try
            {
                int imaid = GetNextId(ima);

                if (imaid != 0)
                {
                    ima.Id = imaid;
                    CreateEntity(ima);

                    return ima;
                }
                else
                {
                    throw new Exception("No se pudo obtener el siguiente Id de la entidad: Imagen");
                }
            }
            catch (Exception)
            {

                throw new Exception("Error en AgregarImagen.");
            }
        }

        internal static bool BorrarImagen(object dto)
        {
            Imagen ima = (Imagen)dto;

            if (ima.Id != 0)
            {
                return DeleteEntity(dto);
            }

            return false;
        }



    }
}