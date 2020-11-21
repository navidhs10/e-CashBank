using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for CuentaDAO
/// </summary>
public class CuentaDAO
{
    public CuentaDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //method
    public static List<Cuenta> pa_consultarCuentaCliente(int idUSuario)
    {
        List<Cuenta> lDatosCuenta = new List<Cuenta>();
        Cuenta Bcuenta = new Cuenta();

        MySqlConnection connection = ConnectionManager.Connect();
        MySqlCommand command;
        connection.Open();

        string query = idUSuario.ToString();
        command = ConnectionManager.BuildQuery("pa_consultarCuentaCliente", query, connection);

        MySqlDataReader dr = command.ExecuteReader();

        if(dr.HasRows)
        {
            while(dr.Read())
            {
                /*Bcuenta.cuentaCreacion = dr["cuenta_creacion"].ToString();
                Bcuenta.nro_cuenta = int.Parse(dr["cuenta"].ToString());
                Bcuenta.nombreCuenta = dr["nombre"].ToString();
                Bcuenta.fecha_movimiento = dr["fecha_movimiento"].ToString();
                Bcuenta.nro_movimiento = dr["nro_movimiento"].ToString();
                Bcuenta.monto = Decimal.Parse(dr["monto"].ToString());
                Bcuenta.tipo = dr["tipo"].ToString();
                Bcuenta.concepto = dr["concepto"].ToString();*/
                Bcuenta.nro_Cuenta = dr["nro"].ToString();
                Bcuenta.nombre_Cuenta = dr["nombre"].ToString();
                Bcuenta.fecha_Creacion = dr["fecha"].ToString();                
                lDatosCuenta.Add(Bcuenta);
                Bcuenta = new Cuenta();
            }
        }

        connection.Close();
        return lDatosCuenta;
    }
    //method
    public static void pa_crearCuenta(string nombreCuenta, string fechaCreacion, string idCliente)
    {
        MySqlConnection connect = ConnectionManager.Connect();        
        MySqlCommand command;
        connect.Open();

        string query = nombreCuenta + "','" + fechaCreacion + "','" + idCliente;
        command = ConnectionManager.BuildQuery("pa_crearCuenta", query, connect);
        command.ExecuteNonQuery();
        connect.Close();
    }
    //method
    public static void pa_eliminarCuenta(string nro_cuenta)
    {
        MySqlConnection connection = ConnectionManager.Connect();
        MySqlCommand command;
        connection.Open();

        string query = nro_cuenta+"'";
        command = ConnectionManager.BuildQuery("pa_eliminarCuenta", query, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }


}