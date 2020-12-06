using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
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
            string user = "DJANGO21";
            string password = "django21";

            OracleConnection conn = new OracleConnection
            {
                ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user
            };

            return conn;
        }

        public bool Login(String email, String pass)
        {
            bool result = false;
            OracleConnection conn = ConexionDB();

            try
            {
                conn.Open();
                string query = "select is_active, is_staff, email, password from auth_user where email = '" + email + "'";
                OracleCommand comm = new OracleCommand(query, conn);
                OracleDataReader ocdr = comm.ExecuteReader();
                if (ocdr.Read() && (ocdr.GetInt16(0) == 1) && (ocdr.GetInt16(1) == 1) && email == ocdr.GetString(2) && pass == ocdr.GetString(3))
                {
                    result = true;
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

        private void Commit()
        {
            OracleConnection conn = ConexionDB();
            conn.Open();
            string query = "commit";
            OracleCommand cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private int GetIdUsuario(string rut)
        {
            int id = 0;
            OracleConnection conn = ConexionDB();
            try
            {
                conn.Open();
                string query = "SELECT A.ID FROM AUTH_USER A JOIN ACCOUNT_USERPROFILE P ON A.ID = P.USER_ID WHERE P.RUT = '" + rut + "'";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    id = dr.GetInt32(0);
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
            return id;
        }

        public string GetNombre(string user)
        {
            string usuario = "Admin";
            OracleConnection conn = ConexionDB();
            try
            {
                conn.Open();
                string query = "SELECT FIRST_NAME, LAST_NAME FROM AUTH_USER WHERE EMAIL = '" + user + "'";
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

        public bool SetCliente(string correo, string password, string nombre, string apellido, int rut, int sueldo, int edad)
        {
            bool result = false;
            int id = 0;

            //Username a partir del correo
            string[] usuario = correo.Split('@');
            string username = usuario[0];

            OracleConnection conn = ConexionDB();
            conn.Open();

            string querty = "INSERT INTO AUTH_USER(USERNAME, PASSWORD, FIRST_NAME, LAST_NAME, EMAIL, IS_STAFF, IS_SUPERUSER, IS_ACTIVE, DATE_JOINED) " +
                            "VALUES('" + username + "', '" + password + "', '" + nombre + "', '" + apellido + "', '" + correo + "', 0, 0, 1, CURRENT_DATE)";
            OracleCommand cmd = new OracleCommand(querty, conn);
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            cmd.ExecuteNonQuery();

            //Sacar último user id
            string query = "select max(id) from auth_user";
            OracleCommand sql = new OracleCommand(query, conn);
            OracleDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {
                id = dr.GetInt32(0);
            }
            else
            {
                return result = false;
            }

            //conn.Open();
            string asdfgh = "INSERT INTO ACCOUNT_USERPROFILE(RUT, SUELDO, EDAD, USER_ID) " +
                            "VALUES(" + rut + ", " + sueldo + ", " + edad + ", " + id + ")";
            OracleCommand cmd2 = new OracleCommand(asdfgh, conn);
            //OracleDataAdapter da2 = new OracleDataAdapter(cmd);
            cmd2.ExecuteNonQuery();
            result = true;
            conn.Close();
            Commit();
            return result;
        }

        public DataTable GetClientes()
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConexionDB();
            string query = "SELECT B.RUT, A.FIRST_NAME NOMBRE, A.LAST_NAME APELLIDO, A.EMAIL, B.EDAD " +
                           "FROM AUTH_USER A JOIN ACCOUNT_USERPROFILE B ON A.ID = B.USER_ID " +
                           "WHERE A.IS_STAFF = 0 AND A.IS_ACTIVE = 1";
            OracleCommand cmd = new OracleCommand(query, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (OracleException zz)
            {
                throw zz;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<string> GetRutCliente()
        {
            List<string> pagos = new List<string>();
            OracleConnection conn = ConexionDB();
            string query = "SELECT P.RUT FROM ACCOUNT_USERPROFILE P JOIN AUTH_USER A ON P.USER_ID = A.ID WHERE A.IS_STAFF=0";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pagos.Add(dr[0].ToString());
            }
            conn.Close();
            return pagos;
        }

        public DataTable GetPagos()
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConexionDB();
            string query = "SELECT P.RUT, U.EMAIL, R.MONTO_PAGO \"MONTO PAGADO\",R.FECHA_PAGO \"FECHA PAGO\", C.DESCRIPCION \"DESCRIPCION CONTRATO\", C.FECHA_CONTRATACION \"FECHA CONTRATACION\" " +
                           "FROM REGISTRO_PAGOS R " +
                           "JOIN CONTRATO C ON C.ID = R.ID_CONTRATO_ID " +
                           "JOIN AUTH_USER U ON C.RUT_CLIENTE_ID = U.ID " +
                           "JOIN ACCOUNT_USERPROFILE P ON U.ID = P.USER_ID";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable GetPagosCliente(string rut)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConexionDB();
            string query = "SELECT P.RUT, U.EMAIL, R.MONTO_PAGO \"MONTO PAGADO\",R.FECHA_PAGO \"FECHA PAGO\", C.DESCRIPCION \"DESCRIPCION CONTRATO\", C.FECHA_CONTRATACION \"FECHA CONTRATACION\" " +
                           "FROM REGISTRO_PAGOS R " +
                           "JOIN CONTRATO C ON C.ID = R.ID_CONTRATO_ID " +
                           "JOIN AUTH_USER U ON C.RUT_CLIENTE_ID = U.ID " +
                           "JOIN ACCOUNT_USERPROFILE P ON U.ID = P.USER_ID " +
                           "WHERE P.RUT = '" + rut + "'";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public bool SetTrabajador(string correo, string password, string nombre, string apellido, int? admin, int rut, int sueldo, int edad)
        {
            bool result = false;
            int id = 0;

            //Username a partir del correo
            string[] usuario = correo.Split('@');
            string username = usuario[0];

            OracleConnection conn = ConexionDB();
            conn.Open();

            string querty = "insert into auth_user(username,password,first_name,last_name,email,is_staff,is_superuser,is_active,date_joined) " +
                            "values('" + username + "', '" + password + "', '" + nombre + "', '" + apellido + "', '" + correo + "',1," + admin + ",1,current_date)";
            OracleCommand cmd = new OracleCommand(querty, conn);
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            cmd.ExecuteNonQuery();

            //Sacar último user id
            string query = "select max(id) from auth_user";
            OracleCommand sql = new OracleCommand(query, conn);
            OracleDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {
                id = dr.GetInt32(0);
            }
            else
            {
                return result = false;
            }

            //conn.Open();
            string asdfgh = "insert into account_userprofile(rut,sueldo,edad,user_id) " +
                            "values(" + rut + ", " + sueldo + ", " + edad + ", " + id + ")";
            OracleCommand cmd2 = new OracleCommand(asdfgh, conn);
            //OracleDataAdapter da2 = new OracleDataAdapter(cmd);
            cmd2.ExecuteNonQuery();
            result = true;
            conn.Close();
            Commit();
            return result;
        }
        public DataTable GetTrabajadores()
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConexionDB();
            string query = "SELECT B.RUT, A.FIRST_NAME NOMBRE, A.LAST_NAME APELLIDO, A.EMAIL, B.EDAD " +
                           "FROM AUTH_USER A JOIN ACCOUNT_USERPROFILE B ON A.ID = B.USER_ID " +
                           "WHERE A.IS_STAFF = 1 AND A.IS_ACTIVE = 1";
            OracleCommand cmd = new OracleCommand(query, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (OracleException zz)
            {
                throw zz;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<string> GetRutTrabajador()
        {
            List<string> carga = new List<string>();
            OracleConnection conn = ConexionDB();
            string query = "SELECT P.RUT FROM ACCOUNT_USERPROFILE P JOIN AUTH_USER A ON P.USER_ID = A.ID WHERE A.IS_STAFF=1";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                carga.Add(dr[0].ToString());
            }
            conn.Close();
            return carga;
        }

        public DataTable GetCargaLabTrabajador(string mes, string año, string rut)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConexionDB();
            string query = "SELECT FIRST_NAME || ' ' || LAST_NAME TRABAJADOR, MOTIVO_VISITA \"MOTIVO VISITA\", FECHA_VISITA \"FECHA VISITA\", " +
                           "(SELECT RUT FROM AUTH_USER AU JOIN ACCOUNT_USERPROFILE AP ON AU.ID = AP.USER_ID WHERE AU.ID = V.RUT_CLIENTE_ID) \"RUT CLIENTE\" " +
                           "FROM AUTH_USER A " +
                           "JOIN VISITA_TERRENO V ON A.ID = V.RUT_TRABAJADOR_ID " +
                           "JOIN ACCOUNT_USERPROFILE P ON P.USER_ID = A.ID " +
                           "WHERE TO_CHAR(FECHA_VISITA,'mm/yyyy')= '" + mes + "/" + año + "' AND P.RUT = '" + rut + "'" +
                           "ORDER BY FECHA_VISITA ASC";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable GetContratos()
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConexionDB();
            string query = "SELECT A.FIRST_NAME || ' ' || A.LAST_NAME CLIENTE, C.DESCRIPCION, C.COSTO, C.FECHA_CONTRATACION \"FECHA CONTRATACION\" " +
                           "FROM CONTRATO C JOIN ACCOUNT_USERPROFILE P ON C.RUT_CLIENTE_ID = P.USER_ID JOIN AUTH_USER A ON A.ID = P.USER_ID";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable GetContratosCliente(string rut)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConexionDB();
            string query = "SELECT A.FIRST_NAME || ' ' || A.LAST_NAME CLIENTE, C.DESCRIPCION, C.COSTO, C.FECHA_CONTRATACION \"FECHA CONTRATACION\" " +
                           "FROM CONTRATO C JOIN ACCOUNT_USERPROFILE P ON C.RUT_CLIENTE_ID = P.USER_ID JOIN AUTH_USER A ON a.ID = p.USER_ID " +
                           "WHERE P.RUT = '" + rut + "'";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public bool SetAsesoriaAccidente()
        {
            bool resultado = false;
            /*
            OracleConnection conn = ConexionDB();
            conn.Open();

            //INSERT Asesoria Accidente
            string query = "INSERT INTO VISITA_TERRENO (MOTIVO_VISITA, FECHA_VISITA, RUT_CLIENTE_ID, RUT_TRABAJADOR_ID) " +
                           "VALUES ('" + motivo + "', '" + fecha + "', '" + id_cliente + "', '" + id_trabajador + "')";
            OracleCommand cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            resultado = true;
            Commit();
            */
            return resultado;
        }

        public bool SetAsesoriaFiscalizacion()
        {
            bool resultado = false;
            /*
            OracleConnection conn = ConexionDB();
            conn.Open();

            //INSERT Asesoria Fiscalizacion
            string query = "INSERT INTO VISITA_TERRENO (MOTIVO_VISITA, FECHA_VISITA, RUT_CLIENTE_ID, RUT_TRABAJADOR_ID) " +
                           "VALUES ('" + motivo + "', '" + fecha + "', '" + id_cliente + "', '" + id_trabajador + "')";
            OracleCommand cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            resultado = true;
            Commit();
            */
            return resultado;
        }

        public DataTable GetAsesoriasAccidente()
        {
            DataTable aseacci = new DataTable();
            OracleConnection conn = ConexionDB();
            string query = "SELECT A.ID, U.FIRST_NAME || ' ' || U.LAST_NAME CLIENTE, P.RUT, A.EVENTO, A.PROPUESTA, A.ASESORIA_ESPECIAL \"¿ASESORIA ESPECIAL?\", " +
                           "AC.NATURALEZA, AC.PARTES_ACCIDENTADAS \"PARTES ACCIDENTADAS\", AC.FUENTE_ACCIDENTE \"FUENTE ACCIDENTE\", AC.FECHA_ACCIDENTE \"FECHA ACCIDENTE\" " +
                           "FROM ASESORIA A " +
                           "JOIN ACCIDENTE AC ON A.ID_ACCIDENTE_ID = AC.ID " +
                           "JOIN AUTH_USER U ON U.ID = AC.RUT_CLIENTE_ID " +
                           "JOIN ACCOUNT_USERPROFILE P ON P.USER_ID = U.ID";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(aseacci);
            conn.Close();
            return aseacci;
        }

        public DataTable GetAsesoriasFiscalizacion()
        {
            DataTable asefisca = new DataTable();
            OracleConnection conn = ConexionDB();
            string query = "SELECT A.ID, U.FIRST_NAME || ' ' || U.LAST_NAME CLIENTE, P.RUT, A.EVENTO, F.DOC_REVISADOS \"DOCUMENTOS REVISADOS\", " +
                           "F.DESCRIPCION_DOCUMENTO \"DESCRPCION DEL DOCUMENTO\", F.DOCUMENTO, " +
                           "A.PROPUESTA, A.ASESORIA_ESPECIAL \"¿ASESORIA ESPECIAL?\", F.DOCUMENTO " +
                           "FROM ASESORIA A " +
                           "JOIN FISCALIZACION F ON A.ID_FISCALIZACION_ID = F.ID " +
                           "JOIN AUTH_USER U ON U.ID = F.RUT_CLIENTE_ID " +
                           "JOIN ACCOUNT_USERPROFILE P ON P.USER_ID = U.ID";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(asefisca);
            conn.Close();
            return asefisca;
        }

        public DataTable GetAsesoriasAccidenteFecha(string mesaño)
        {
            DataTable aseacci = new DataTable();
            OracleConnection conn = ConexionDB();
            string query = "SELECT A.ID, U.FIRST_NAME || ' ' || U.LAST_NAME CLIENTE, P.RUT, A.EVENTO, AC.NATURALEZA, A.PROPUESTA, A.ASESORIA_ESPECIAL \"¿ASESORIA ESPECIAL?\", " +
                           "AC.PARTES_ACCIDENTADAS \"PARTES ACCIDENTADAS\", AC.FUENTE_ACCIDENTE \"FUENTE ACCIDENTE\", AC.FECHA_ACCIDENTE \"FECHA ACCIDENTE\" " +
                           "FROM ASESORIA A " +
                           "JOIN ACCIDENTE AC ON A.ID_ACCIDENTE_ID = AC.ID " +
                           "JOIN AUTH_USER U ON U.ID = AC.RUT_CLIENTE_ID " +
                           "JOIN ACCOUNT_USERPROFILE P ON P.USER_ID = U.ID " +
                           "WHERE TO_CHAR(AC.FECHA_ACCIDENTE,'mm/yyyy') = '" + mesaño + "'";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(aseacci);
            conn.Close();
            return aseacci;
        }

        public string GetAccidentabilidad(string mesaño)
        {
            string accidentabilidad;
            OracleConnection conn = ConexionDB();
            conn.Open();
            string query = "SELECT " +
                           "TRUNC(((SELECT COUNT(DISTINCT ID) FROM ACCIDENTE WHERE TO_CHAR(FECHA_ACCIDENTE,'mm/yyyy') = '" + mesaño + "')/" +
                           "(SELECT COUNT(DISTINCT ID) FROM AUTH_USER WHERE IS_STAFF=0 AND IS_ACTIVE=1)*100), 2) || '%' ACCIDENTABILIDAD " +
                           "FROM DUAL";
            OracleCommand sql = new OracleCommand(query, conn);
            OracleDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {
                accidentabilidad = dr.GetString(0);
            }
            else
            {
                accidentabilidad = "Error";
            }
            conn.Close();
            return accidentabilidad;
        }

        public bool SetVisita(string motivo, string fecha, string rutcli, string ruttra)
        {
            bool resultado = false;
            int id_cliente = GetIdUsuario(rutcli);
            int id_trabajador = GetIdUsuario(ruttra);
            OracleConnection conn = ConexionDB();
            conn.Open();

            //Insert Visita
            string query = "INSERT INTO VISITA_TERRENO (MOTIVO_VISITA, FECHA_VISITA, RUT_CLIENTE_ID, RUT_TRABAJADOR_ID) " +
                            "VALUES ('" + motivo + "', '" + fecha + "', '" + id_cliente + "', '" + id_trabajador + "')";
            OracleCommand cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            resultado = true;
            Commit();
            return resultado;
        }

        public DataTable GetVisitas(int opcion, string rut)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConexionDB();
            string modificador;

            if(opcion == 1)
            {
                modificador = "TRABAJADOR";
            }
            else
            {
                modificador = "CLIENTE";
            }

            string query = "SELECT VT.FECHA_VISITA \"FECHA VISITA\", VT.MOTIVO_VISITA \"MOTIVO VISITA\", " +
                "(SELECT P.RUT FROM AUTH_USER A JOIN ACCOUNT_USERPROFILE P ON A.ID = P.USER_ID WHERE A.ID = VT.RUT_CLIENTE_ID) \"RUT CLIENTE\", " +
                "(SELECT P.RUT FROM AUTH_USER A JOIN ACCOUNT_USERPROFILE P ON A.ID = P.USER_ID WHERE A.ID = VT.RUT_TRABAJADOR_ID) \"RUT TRABAJADOR\" " +
                "FROM VISITA_TERRENO VT LEFT JOIN INFORME_VISITA IV ON VT.ID=IV.ID_VISITA_ID JOIN ACCOUNT_USERPROFILE P ON P.USER_ID = VT.RUT_" + modificador + "_ID " +
                "WHERE IV.ID_VISITA_ID IS NULL AND P.RUT = '" + rut + "'";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable GetCapacitaciones()
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConexionDB();
            string query = "SELECT C.ID, C.FECHA_CAPACITACION \"FECHA CAPACITACION\", C.FECHA_SOLICITUD \"FECHA SOLICITUD\", C.HORA_CAPACITACION \"HORA CAPACITACION\", " +
                "(SELECT P.RUT FROM AUTH_USER A JOIN ACCOUNT_USERPROFILE P ON A.ID = P.USER_ID WHERE A.ID = C.RUT_CLIENTE_ID) \"RUT CLIENTE\", " +
                "(SELECT P.RUT FROM AUTH_USER A JOIN ACCOUNT_USERPROFILE P ON A.ID = P.USER_ID WHERE A.ID = C.RUT_TRABAJADOR_ID) \"RUT TRABAJADOR\" " +
                "FROM CAPACITACION C";
            OracleCommand cmd = new OracleCommand(query, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (OracleException zz)
            {
                throw zz;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable GetCapacitacionesTrabajador(string rut)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConexionDB();
            int id = GetIdUsuario(rut);
            conn.Open();

            string query = "SELECT C.ID, C.FECHA_CAPACITACION \"FECHA CAPACITACION\", C.FECHA_SOLICITUD \"FECHA SOLICITUD\", C.HORA_CAPACITACION \"HORA CAPACITACION\", " +
                "(SELECT P.RUT FROM AUTH_USER A JOIN ACCOUNT_USERPROFILE P ON A.ID = P.USER_ID WHERE A.ID = C.RUT_CLIENTE_ID) \"RUT CLIENTE\", " +
                "(SELECT P.RUT FROM AUTH_USER A JOIN ACCOUNT_USERPROFILE P ON A.ID = P.USER_ID WHERE A.ID = C.RUT_TRABAJADOR_ID) \"RUT TRABAJADOR\" " +
                "FROM CAPACITACION C " +
                "WHERE C.RUT_TRABAJADOR_ID = '" + id + "'";

            OracleCommand cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public List<string> GetIdCapacitaciones()
        {
            List<string> id = new List<string>();
            OracleConnection conn = ConexionDB();
            string query = "SELECT ID FROM CAPACITACION";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id.Add(dr[0].ToString());
            }
            conn.Close();
            return id;
        }

        public bool SetCapacitacion(string fecha, string hora, string rutcli, string ruttra)
        {
            bool resultado;
            int id_cliente = GetIdUsuario(rutcli);
            int id_trabajador = GetIdUsuario(ruttra);
            OracleConnection conn = ConexionDB();
            conn.Open();

            string query = "INSERT INTO CAPACITACION (FECHA_SOLICITUD, FECHA_CAPACITACION, HORA_CAPACITACION, RUT_CLIENTE_ID, RUT_TRABAJADOR_ID) " +
                            "VALUES(CURRENT_DATE, '" + fecha + "', '" + hora + "', '" + id_cliente + "', '" + id_trabajador + "')";
            
            OracleCommand cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            resultado = true;
            Commit();
            return resultado;
        }

        public DataTable GetMateriales()
        {
            DataTable materiales = new DataTable();
            OracleConnection conn = ConexionDB();
            string query = "SELECT MATERIAL \"Lista de Materiales\" FROM MATERIAL_CAPACITACIONES";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(materiales);
            conn.Close();
            return materiales;
        }

        public List<string> GetMateriales2()
        {
            List<string> id = new List<string>();
            OracleConnection conn = ConexionDB();
            string query = "SELECT MATERIAL FROM MATERIAL_CAPACITACIONES";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id.Add(dr[0].ToString());
            }
            conn.Close();
            return id;
        }

        public bool SetMaterial(string material)
        {
            bool resultado;
            OracleConnection conn = ConexionDB();
            conn.Open();

            string query = "INSERT INTO MATERIAL_CAPACITACIONES (MATERIAL) " +
                           "VALUES('" + material + "')";

            OracleCommand cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            resultado = true;
            Commit();
            return resultado;
        }

        public bool SetMaterialCapacitacion(string material, int cantidad, int capacitacion)
        {
            bool resultado;
            int id;
            OracleConnection conn = ConexionDB();
            conn.Open();

            //ID Material
            string query = "SELECT ID FROM MATERIAL_CAPACITACIONES WHERE MATERIAL = '" + material + "'";
            OracleCommand sql = new OracleCommand(query, conn);
            OracleDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {
                id = dr.GetInt32(0);
            }
            else
            {
                resultado = false;
                return resultado;
            }

            //INSERT Material_Solicitado
            string query2 = "INSERT INTO MATERIAL_SOLICITADO VALUES (\"DJANGO21\".\"ISEQ$$_80333\".nextval, " + cantidad + ", " + id + ", " + capacitacion + ")";

            OracleCommand cmd = new OracleCommand(query2, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            resultado = true;
            Commit();
            return resultado;
        }
    }
}