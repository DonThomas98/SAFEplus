using Oracle.ManagedDataAccess.Client;
using System;

namespace SAFE.Negocios
{
    public class Manejadora
    {
        public OracleConnection ConexionDB()
        {
            string host = "127.0.0.1";
            int port = 1521;
            string sid = "xe";
            string user = "C##SAFEPLUS";
            string password = "1234";

            OracleConnection conn = new OracleConnection
            {
                ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user
            };

            return conn;
        }

        public bool Login(String user, String pass)
        {
            bool result = false;
            OracleConnection conn = ConexionDB();
            conn.Open();
            try
            {
                string query = "SELECT CORREO, CONTRASENA FROM TRABAJADOR WHERE CORREO = '" + user + "'";
                OracleCommand comm = new OracleCommand(query, conn);
                OracleDataReader ocdr = comm.ExecuteReader();
                if (ocdr.Read())
                {
                    if (user == ocdr.GetString(0))
                    {
                        if (pass == ocdr.GetString(1))
                        {
                            result = true;
                            return result;
                        }
                        else
                        {
                            return result;
                        }
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            catch (OracleException zz)
            {
                throw zz;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public string GetNombre(string user)
        {
            string usuario = "Admin";
            OracleConnection conn = ConexionDB();
            conn.Open();
            try
            {
                string query = "SELECT P_NOMBRE, P_APELLIDO FROM TRABAJADOR WHERE CORREO = '" + user + "'";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuario = dr.GetString(0) + ' ' + dr.GetString(1);
                }
            }
            catch (OracleException zz)
            {
                throw zz;
            }
            finally
            {
                conn.Close();
            }

            return usuario;
        }
    }
}
