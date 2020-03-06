using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class MovimientoDAO : DaoBase
    {
        public static Movimiento NuevoMovimiento(Movimiento movimiento)
        {
            try
            {
                int movimientoId = GetNextId(movimiento);

                if (movimientoId != 0)
                {
                    movimiento.Id = movimientoId;
                    if (CreateEntity(movimiento))
                        return movimiento;

                    throw new Exception("No se pudo crear el Movimiento");
                }
                else
                    throw new Exception("No se pudo obtener el siguiente id de la entidad: Movimiento");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static List<Movimiento> LlenarMovimientos(object dto, DataTable dt)
        {
            List<Movimiento> dtos = new List<Movimiento>();

            foreach (DataRow dr in dt.Rows)
            {
                Movimiento aux = new Movimiento();
                PoblarObjetoDesdeDataRow(aux, dr);

                dtos.Add(aux);
            }

            return dtos;
        }
        internal static List<Movimiento> RetrieveEntitiesWhere(object dto, string where)
        {
            List<Movimiento> dtos = new List<Movimiento>();

            DataTable dt = GetDataTableWhere(dto, where);

            if (dt.Rows.Count > 0)
                dtos = LlenarMovimientos(dto, dt);

            return dtos;
        }

        internal static List<string> GetNombresPacientes()
        {
            try
            {
                List<string> pacientes = new List<string>();

                DataTable dt = GetDataTableDistinct("Cliente");

                foreach (DataRow dr in dt.Rows)
                {
                    pacientes.Add(Convert.ToString(dr[0]));
                }

                return pacientes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static int GetLatestIdMov()
        {
            try
            {
                int id = GetLatestId();
                return id;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static List<string> GetNombresInstituciones()
        {
            try
            {
                List<string> instituciones = new List<string>();

                DataTable dt = GetDataTableDistinct("Institucion");

                foreach (DataRow dr in dt.Rows)
                {
                    instituciones.Add(Convert.ToString(dr[0]));
                }

                return instituciones;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

