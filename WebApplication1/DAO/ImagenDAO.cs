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

        internal static List<Imagen> RetrieveEntitiesWhere(object dto, string where)
        {
            List<Imagen> dtos = new List<Imagen>();

            DataTable dt = GetDataTableWhere(dto, where);

            if (dt.Rows.Count > 0)
                dtos = LlenarImagenes(dto, dt);

            return dtos;
        }

        private static List<Imagen> LlenarImagenes(object dto, DataTable dt)
        {
            List<Imagen> dtos = new List<Imagen>();

            foreach (DataRow dr in dt.Rows)
            {
                Imagen aux = new Imagen();
                PoblarObjetoDesdeDataRow(aux, dr);

                dtos.Add(aux);
            }

            return dtos;
        }

        internal static List<Imagen> GetEntitiesPaginated(int num, string filtro)
        {
            try
            {
                List<Imagen> dtos = new List<Imagen>();

                DataTable dt = GetDataTablePaginado(new Imagen(), num, filtro);

                if (dt.Rows.Count > 0)
                    dtos = LlenarImagenes(new Imagen(), dt);

                return dtos;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        internal static List<int> GetFotosId()
        {
            try
            {
                List<int> ids = new List<int>();
                DataTable dt = DaoBase.GetFotosId();

                foreach (DataRow dr in dt.Rows)
                {
                    ids.Add((int)dr["Id"]);
                }

                return ids;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static List<Imagen> GetFotosPaginado(List<int> ids)
        {
            try
            {
                List<Imagen> imagenes = new List<Imagen>();

                DataTable dt = DaoBase.GetFotosPaginado(ids);
                Imagen aux = new Imagen();
                if (dt.Rows.Count > 0)
                    imagenes = LlenarImagenes(aux, dt);

                return imagenes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static void UpdateImagenes(List<int> imagenesIds)
        {
            try
            {
                DaoBase.UpdateImagenes(imagenesIds);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}