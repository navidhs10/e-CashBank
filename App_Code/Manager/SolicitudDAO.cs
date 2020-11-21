using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for SolicitudDAO
/// </summary>
public class SolicitudDAO
{
    public SolicitudDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //method ----- el parametro "tipo_consulta" se ultilizará para elegir entre la consulta a la cuenta administrador o la consulta a la cuenta de cliente    
    public List<consultarSolicitudA> consultarSolicitud(string tipo_consulta, string id_cliente)
    {
        List<consultarSolicitudA> lconsultaSoli = new List<consultarSolicitudA>();
        consultarSolicitudA consultaSoli = new consultarSolicitudA();

        MySqlConnection connection = ConnectionManager.Connect();
        MySqlCommand command;
        connection.Open();


        if (tipo_consulta.Equals("admin"))
        {
            command = ConnectionManager.BuildQuery("pa_consultarSolicitudAdmin", "", connection);

            MySqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    consultaSoli.id = int.Parse(dr["id"].ToString());
                    consultaSoli.nro_soli = dr["nro_soli"].ToString();
                    consultaSoli.fecha = dr["fecha"].ToString();
                    consultaSoli.nombre_cliente = dr["nombre"].ToString();
                    consultaSoli.apellido = dr["apellido"].ToString();
                    consultaSoli.correo = dr["correo"].ToString();
                    consultaSoli.tlfno = dr["tlfno"].ToString();
                    consultaSoli.monto = decimal.Parse(dr["monto"].ToString());
                    consultaSoli.tipo_operacion = dr["tipo_operacion"].ToString();
                    consultaSoli.estado = dr["estado"].ToString();
                    lconsultaSoli.Add(consultaSoli);
                    consultaSoli = new consultarSolicitudA();
                }
            }

        }
        else if (tipo_consulta.Equals("cliente"))
        {
            command = ConnectionManager.BuildQuery("pa_consultarSolicitudes",id_cliente, connection);

            MySqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    consultaSoli.nro_soli = dr["nro_soli"].ToString();
                    consultaSoli.fecha = dr["fecha"].ToString();
                    consultaSoli.monto = decimal.Parse(dr["monto"].ToString());
                    consultaSoli.tipo_operacion = dr["tipo_operacion"].ToString();
                    consultaSoli.estado = dr["estado"].ToString();
                    lconsultaSoli.Add(consultaSoli);
                    consultaSoli = new consultarSolicitudA();
                }
            }
        }
        else if (tipo_consulta.Equals("clienteTodo"))
        {
            command = ConnectionManager.BuildQuery("pa_consultarSolicitudesClien", id_cliente, connection);

            MySqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    consultaSoli.nro_soli = dr["nro_soli"].ToString();
                    consultaSoli.fecha = dr["fecha"].ToString();
                    consultaSoli.monto = decimal.Parse(dr["monto"].ToString());
                    consultaSoli.tipo_operacion = dr["tipo_operacion"].ToString();
                    consultaSoli.estado = dr["estado"].ToString();
                    lconsultaSoli.Add(consultaSoli);
                    consultaSoli = new consultarSolicitudA();
                }
            }
        }

        connection.Close();
        return lconsultaSoli;
    }

    //method
    public void eliminarSolicitud(string nro_solicitud)
    {
        MySqlConnection connection = ConnectionManager.Connect();
        MySqlCommand command;
        connection.Open();

        string query = nro_solicitud;
        command = ConnectionManager.BuildQuery("pa_eliminarSolicitud", query, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    //method
    public void crearSolicitud(DateTime fecha, string id_cliente, decimal monto, string tipo_operacion)
    {
        MySqlConnection connection = ConnectionManager.Connect();
        MySqlCommand command;
        connection.Open();

        string query = fecha + "','" + id_cliente + "','" + monto + "','" + tipo_operacion;
        command = ConnectionManager.BuildQuery("pa_crearSolicitud", query, connection);

        command.ExecuteNonQuery();
        connection.Close();
    }
}