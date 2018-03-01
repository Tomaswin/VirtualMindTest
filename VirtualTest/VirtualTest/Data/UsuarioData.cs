using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using VirtualTest.Models;

namespace VirtualTest.Data
{
    public class UsuariosData
    {
        public static void InsertarUsuario(Users oUsuario)
        {
            string sInsert =
            string.Format(
                "Insert into users (nombre,apellido,email,password)" +
                "values ('{0}','{1}','{2}','{3}')",
                oUsuario.nombre,
                oUsuario.apellido,
                oUsuario.email,
                oUsuario.contraseña);

            DBHelper.EjecutarIUD(sInsert);
        }

        public static void Update(Users oUsuario)
        {
            string sUpdate = "update users set Nombre='" + oUsuario.nombre + "',Apellido = '" + 
                oUsuario.apellido + "',email = '" + oUsuario.email + "',password = '" + 
                oUsuario.contraseña + "' where id = " + oUsuario.id.ToString();

            DBHelper.EjecutarIUD(sUpdate);
        }

        public static void Delete(int IdUsuario)
        {
            string sUpdate = "delete from users where id = " + IdUsuario.ToString();
            DBHelper.EjecutarIUD(sUpdate);
        }

        public static Users ObtenerPorId(int IdUsuario)
        {
            string select = "select * from users where id = " + IdUsuario.ToString();
            DataTable dt = DBHelper.EjecutarSelect(select);
            Users oUsuario;
            if (dt.Rows.Count > 0)
            {
                oUsuario = ObtenerPorRow(dt.Rows[0]);
                return oUsuario;
            }
            return null;
        }

        public static List<Users> ObtenerUsuarios()
        {
            string select = "select * from users";
            DataTable dt = DBHelper.EjecutarSelect(select);
            List<Users> lista = new List<Users>();
            Users oUsuario;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    oUsuario = ObtenerPorRow(row);
                    lista.Add(oUsuario);
                }
                oUsuario = ObtenerPorRow(dt.Rows[0]);
            }
            return lista;
        }

        public static Users ObtenerPorRow(DataRow Row)
        {
            Users oUsuario = new Users();
            oUsuario.id = Row.Field<int>("id");
            oUsuario.nombre = Row.Field<string>("nombre");
            oUsuario.apellido = Row.Field<string>("apellido");
            oUsuario.email = Row.Field<string>("email");
            oUsuario.contraseña = Row.Field<string>("password");
            return oUsuario;
        }
    }
}