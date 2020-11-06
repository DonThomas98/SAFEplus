using Oracle.ManagedDataAccess.Client;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace SAFE.Negocios
{
    public class Manejadora
    {
        public OracleConnection ConexionDB()
        {
            string host = "127.0.0.1";
            int port = 1521;
            string sid = "xe";
            //string user = "C##SAFEPLUS"; //DB Antigua
            //string password = "1234"; //DB Antigua
            string user = "DJANGO21";  //DB Django
            string password = "django21";  //DB Django

            OracleConnection conn = new OracleConnection
            {
                ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user
            };

            return conn;
        }

        //Django qlo asquerosoooooo
        private string decryptPassword(string password, string salt)
        {
            byte[] convertedsalt = Convert.FromBase64String(salt);
            int iterations = 216000;
            var deriveBytes = new Rfc2898DeriveBytes(password, convertedsalt, iterations, HashAlgorithmName.SHA256);
            byte[] hash = deriveBytes.GetBytes(32);

            var passwordValue = $"pbkdf2_sha256$216000${salt}${Convert.ToBase64String(hash)}";
            return passwordValue;

        }

        public bool Login(String email, String pass)
        {
            bool result = false;
            OracleConnection conn = ConexionDB();
            conn.Open();

            try
            {
                //string query = "SELECT CORREO, CONTRASENA FROM TRABAJADOR WHERE CORREO = '" + user + "'";  //DB Antigua
                string query = "select email, password from auth_user where email = '" + email + "'";
                OracleCommand comm = new OracleCommand(query, conn);
                OracleDataReader ocdr = comm.ExecuteReader();
                if (ocdr.Read())
                {
                    if (email == ocdr.GetString(0))
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
                //string query = "SELECT P_NOMBRE, P_APELLIDO FROM TRABAJADOR WHERE CORREO = '" + user + "'"; //DB Antigua
                string query = "select first_name, last_name from auth_user where email = '" + user + "'";
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
