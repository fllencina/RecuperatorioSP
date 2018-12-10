using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Entidades
{
    public class UsuarioDAO
    {
        //string str = @"Data source=.\sqlexpress; initial catalog=final-20180802;integrated security=true";
        string str = @"Data source=fernanda\ALPHA2000; initial catalog=final-20180802;integrated security=true";

        SqlCommand comando;
        SqlConnection conexion;

        public UsuarioDAO()
        {
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            conexion = new SqlConnection(str);
        }
        public void Guardar(string tabla, Usuario unUsuario)
        {
            comando.CommandText = "INSERT INTO " + tabla + "(nombre,clave) values('" + unUsuario.Nombre + "','" + unUsuario.Clave + "')";
            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }
        public Usuario Leer(string tabla)
        {
            //string str = @"Data source=.\sqlexpress; initial catalog=patentes-sp-2018;integrated security=true";
            //string str = @"Data source=\alpha2000; initial catalog=final-20180802;integrated security=true";

            conexion = new SqlConnection(str);
            Usuario usuarioLeido = default(Usuario);
            comando.CommandText = "select nombre,clave from " + tabla;

            try
            {
                conexion.Open();
                comando.Connection = conexion;
                SqlDataReader reader = comando.ExecuteReader();

                string nombre = reader["nombre"].ToString();
                string clave = reader["clave"].ToString();

                usuarioLeido = new Usuario(nombre, clave);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return usuarioLeido;
        }

    }
}

