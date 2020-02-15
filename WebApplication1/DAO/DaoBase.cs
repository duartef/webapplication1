using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Reflection;

namespace WebApplication1
{
    public class DaoBase
    {
        internal const string connStr = @"Data Source=SQL5045.site4now.net;Initial Catalog=DB_9BA2A5_palmed;User Id=DB_9BA2A5_palmed_admin;Password=q1w2e3r4_;";

        public static bool DeleteEntity(object dto)
        {
            try
            {
                string query = string.Format("DELETE FROM {0} WHERE Id = {1}", dto.GetType().Name, dto.GetType().GetProperty("Id").GetValue(dto, null));

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();

                        int result = (int)cmd.ExecuteNonQuery();

                        if (result > 0)
                            return true;

                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool GetEntity(object dto)
        {
            if (dto == null)
                return false;

            try
            {
                using(SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;

                        con.Open();

                        var props = dto.GetType().GetProperties();
                        foreach (PropertyInfo prop in props)
                        {
                            if (prop.Name != "CantFotos")
                            {
                                SqlParameter p = cmd.CreateParameter();

                                if
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        public static bool CreateEntity(object dto)
        {
            if (dto == null)
                return false;

            try
            {

                //string query = string.Format("INSERT INTO {0})", dto.GetType().Name);

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;

                        con.Open();

                        var props = dto.GetType().GetProperties();
                        foreach (PropertyInfo prop in props)
                        {
                            if (prop.Name != "CantFotos")
                            {
                                SqlParameter p = cmd.CreateParameter();

                                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                {
                                    p.SqlDbType = ConvertToDBType(prop.PropertyType.GetGenericArguments()[0]);
                                    if (prop.GetValue(dto, null) == null)
                                        p.SqlValue = Convert.DBNull;
                                    else
                                        p.SqlValue = prop.GetValue(dto, null);
                                }
                                else
                                {
                                    p.SqlDbType = ConvertToDBType(prop);
                                    p.SqlValue = prop.GetValue(dto, null);
                                }

                                p.ParameterName = "@" + prop.Name;

                                cmd.Parameters.Add(p);
                            }
                        }
                        //cmd.Parameters.A

                        CrearInsertQuery(cmd, dto.GetType().Name);


                        int result = (int)cmd.ExecuteNonQuery();

                        if (result > 0)
                            return true;

                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static SqlDbType ConvertToDBType(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(bool))
                return SqlDbType.Bit;
            if (prop.PropertyType == typeof(string))
                return SqlDbType.NVarChar;
            if (prop.PropertyType == typeof(int))
                return SqlDbType.Int;
            if (prop.PropertyType == typeof(long))
                return SqlDbType.BigInt;
            if (prop.PropertyType == typeof(DateTime))
                return SqlDbType.DateTime;
            if (prop.PropertyType == typeof(DateTime?))
                return SqlDbType.DateTime;
            if (prop.PropertyType == typeof(TimeSpan))
                return SqlDbType.Time;
            if (prop.PropertyType == typeof(float))
                return SqlDbType.Float;
            if (prop.PropertyType == typeof(decimal))
                return SqlDbType.Decimal;
            if (prop.PropertyType == typeof(double))
                return SqlDbType.Real;
            if (prop.PropertyType == typeof(byte[]))
                return SqlDbType.VarBinary;
            if (prop.PropertyType == null)
                return SqlDbType.VarBinary;
            if (prop.PropertyType == typeof(Nullable<>))
                return SqlDbType.Int;

            throw new Exception("Err: Tipo de Valor Desconocido!");
        }

        internal static SqlDbType ConvertToDBType(Type type)
        {
            if (type == typeof(bool))
                return SqlDbType.Bit;
            if (type == typeof(string))
                return SqlDbType.NVarChar;
            if (type == typeof(int))
                return SqlDbType.Int;
            if (type == typeof(long))
                return SqlDbType.BigInt;
            if (type == typeof(DateTime))
                return SqlDbType.DateTime;
            if (type == typeof(DateTime?))
                return SqlDbType.DateTime;
            if (type == typeof(TimeSpan))
                return SqlDbType.Time;
            if (type == typeof(float))
                return SqlDbType.Float;
            if (type == typeof(decimal))
                return SqlDbType.Decimal;
            if (type == typeof(double))
                return SqlDbType.Real;
            if (type == typeof(byte[]))
                return SqlDbType.VarBinary;
            if (type == null)
                return SqlDbType.VarBinary;
            if (type == typeof(Nullable<>))
                return SqlDbType.Int;

            throw new Exception("Err: Tipo de Valor Desconocido!");
        }
        public static void CrearInsertQuery(SqlCommand Comando, string Tabla)
        {

            string sQuery = "INSERT INTO [" + Tabla + "]" + "\r\n" + "(";

            foreach (SqlParameter unParametro in Comando.Parameters)
            {
                if (unParametro.Direction == ParameterDirection.Input)
                {
                    sQuery = sQuery + unParametro.ParameterName.Substring(1) + ",";
                }
            }

            sQuery = sQuery.Remove(sQuery.Length - 1, 1);
            sQuery = sQuery + " )" + "\r\n" + "VALUES ( ";

            foreach (SqlParameter unParametro in Comando.Parameters)
            {
                if (unParametro.Direction == ParameterDirection.Input)
                {
                    sQuery = sQuery + unParametro.ParameterName + ",";
                }
            }

            sQuery = sQuery.Remove(sQuery.Length - 1, 1);
            sQuery = sQuery + " )";

            Comando.CommandType = CommandType.Text;
            Comando.CommandText = sQuery;
        }

        public static int GetNextId(object dto)
        {
            if (dto == null)
                return 0;

            try
            {
                string query = string.Format("SELECT MAX(Id) FROM {0}", dto.GetType().Name);

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();

                        object aux = cmd.ExecuteScalar();

                        //Si el resultado es un numero, le sumo 1 y lo devuelvo.
                        //Sino, devuelvo 1.
                        int nextId;
                        if ((bool)int.TryParse(aux.ToString(), out nextId))
                            return (nextId + 1);
                        else
                            return 1;
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}