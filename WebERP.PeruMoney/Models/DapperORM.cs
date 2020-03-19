using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace WebERP.PeruMoney.Models
{
    public static class DapperORM
    {
        private static string ConnectionString = @"Data source=DESKTOP-VT996K0;initial catalog=BD_PERUMONEY;Integrated Security=True;user id=sa;password=Password@SQL123456;";

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    con.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    param = null;
                }
            }
        }
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    return (T)Convert.ChangeType(con.ExecuteScalar(procedureName, param,
                        commandType: CommandType.StoredProcedure), typeof(T));
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    param = null;
                }
            }
        }
        //DapperORM.ReturnList<AgenciaModel> <= IEnumerable<AgenciaModel>
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                IEnumerable<T> olista = null;

                try
                {
                    con.Open();
                    olista = con.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    param = null;
                }
                return olista;
            }
        }


    }
}