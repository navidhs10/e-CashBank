using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UsuarioDAO
/// </summary>
public class UsuarioDAO
{
    public UsuarioDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static Usuario buscarUsuario(string usuario, string clave)
    {
        Usuario user = new Usuario();

        // Esta clase conecta la base de datos desde el string de conexion
        MySqlConnection connection = ConnectionManager.Connect();
        MySqlCommand command;
        //se abre la conexion establecida desde la funcion anterior.
        connection.Open();


        string query = usuario + "','" + clave;
        command = ConnectionManager.BuildQuery("pa_consultarUsuario", query, connection);

        /*DataSet ds = new DataSet();
        MySqlDataAdapter da = new MySqlDataAdapter(command);
        da.Fill(ds);*/

        MySqlDataReader dr = command.ExecuteReader();

        if (dr.HasRows)
        {
            if (dr.Read())
            {
                if (dr["enabled"].ToString().Equals("True"))
                {
                    user.id = dr["id"].ToString();
                    user.usuario = dr["usuario"].ToString();
                    user.clave = dr["clave"].ToString();
                    user.codi_usuario = dr["codi_usuario"].ToString();
                }
                else if(dr["enabled"].ToString().Equals("Disabled"))
                {
                    user.id = "Inhabilitado";
                }
                else if(dr["enabled"].ToString().Equals("False"))
                {
                    user = null;
                }
            }
        }
        else
            user.id = "No existe";

        connection.Close();
        return user;
    }

    public static void AgregarUsuario(string usuario, string pass, string codi_usuario, string nombre, string apel, string cedul, string correo, string tlfno)
    {
        MySqlConnection connection = ConnectionManager.Connect();
        MySqlCommand command;
        connection.Open();

        string query = usuario + "','" + pass + "','" + codi_usuario + "','" + nombre + "','" + apel + "','" + cedul + "','" + correo + "','" + tlfno;
        command = ConnectionManager.BuildQuery("pa_agregarUsuario", query, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    public static Persona consultarPersona(string id_usuario)
    {
        Persona persona = new Persona();
        MySqlConnection connection = ConnectionManager.Connect();
        MySqlCommand command;
        connection.Open();
        command = ConnectionManager.BuildQuery("pa_consultarPersona", id_usuario, connection);

        MySqlDataReader dr = command.ExecuteReader();

        if(dr.HasRows)
        {
            while(dr.Read())
            {
                //persona.id = dr["id"].ToString();
                persona.nombre = dr["nombre"].ToString();
                persona.apellido = dr["apellido"].ToString();
                persona.cedula = dr["cedula"].ToString();
                persona.correo = dr["correo"].ToString();
                persona.tlfno = dr["tlfno"].ToString();
            }            
        }

        connection.Close();
        return persona;
    }
    
    
}