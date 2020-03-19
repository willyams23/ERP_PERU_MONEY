using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WebERP.PeruMoney.Models
{
    public static class DapperMysql
    {

        private static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionMysql"].ConnectionString;

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    con.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
                }
                catch (MySqlException ex)
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
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    return (T)Convert.ChangeType(con.ExecuteScalar(procedureName, param,
                        commandType: CommandType.StoredProcedure), typeof(T));
                }
                catch (MySqlException ex)
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
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                IEnumerable<T> olista = null;
                try
                {
                    con.Open();
                    olista = con.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
                }
                catch (MySqlException ex)
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

        #region Ocultar

        //string ConnectionMysql = ConfigurationManager.ConnectionStrings["ConnectionMysql"].ConnectionString;

        //MySqlConnection myConnection = new MySqlConnection(ConnectionMysql);
        //MySqlCommand comm = new MySqlCommand("select * from agencia");
        //{
        //    MySqlDataAdapter da = new MySqlDataAdapter();
        //    comm.Connection = myConnection;
        //    da.SelectCommand = comm;
        //    DataTable dt = new DataTable();
        //    {
        //        da.Fill(dt);
        //    }
        //}

        //String cad = null;
        //cad = "";

        #endregion
    }
}