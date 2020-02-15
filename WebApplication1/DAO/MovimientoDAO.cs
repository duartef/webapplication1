using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1;

public class MovimientoDAO : DaoBase
    {

      public static Movimiento AgregarMovimiento(Movimiento mov)
    {
		try
		{
			int movId = GetNextId(mov);

			if (movId != 0)
			{
				mov.Id = movId;
				CreateEntity(mov);
				return mov;
			}
			else
			{
				throw new Exception("No se pudo obtener el siguiente Id de la entidad: Movimiento");
			}

		}
		catch (Exception e)
		{

			throw new Exception("Error en Agregar Movimiento");
		}
    }

    }