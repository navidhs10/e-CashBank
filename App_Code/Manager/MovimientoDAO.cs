using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for MovimientoDAO
/// </summary>
public class MovimientoDAO
{
    public MovimientoDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<Movimiento> consultarMovimiento(string id)
    {
        List<Movimiento> lmovimientos = new List<Movimiento>();
        Movimiento movimientos = new Movimiento();

        MySqlConnection connection = ConnectionManager.Connect();
        MySqlCommand command;
        connection.Open();

        string query = id ;
        command = ConnectionManager.BuildQuery("pa_consultarMovimiento", query, connection);
        MySqlDataReader dr = command.ExecuteReader();

        if (dr.HasRows)
        {
            while(dr.Read())
            {
                movimientos.nro_movimiento = dr["nro_movimiento"].ToString();
                movimientos.fecha = dr["fecha"].ToString();
                movimientos.monto = decimal.Parse(dr["monto"].ToString());
                movimientos.tipo = dr["tipo"].ToString();
                movimientos.concepto = dr["concepto"].ToString();
                lmovimientos.Add(movimientos);
                movimientos = new Movimiento();
            }
        }

        connection.Close();
        return lmovimientos;
    }

    //method
    public static List<consultarMovimientoA> consultarMovimientoAC(string tipo_consulta, string id_cliente)
    {
        List<consultarMovimientoA> lconsltaMovi = new List<consultarMovimientoA>();
        consultarMovimientoA consultaMovi = new consultarMovimientoA();

        MySqlConnection connection = ConnectionManager.Connect();
        MySqlCommand command;
        connection.Open();

        if (tipo_consulta.Equals("admin"))
        {
            command = ConnectionManager.BuildQuery("pa_consultarMovimientoAdmin", "", connection);
            MySqlDataReader dr = command.ExecuteReader();
            
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    consultaMovi.id = int.Parse(dr["id"].ToString());
                    consultaMovi.nro_movimiento = dr["nro_movimiento"].ToString();
                    consultaMovi.fecha = dr["fecha"].ToString();
                    consultaMovi.nombre_cliente = dr["nombre"].ToString();
                    consultaMovi.apellido = dr["apellido"].ToString();
                    consultaMovi.correo = dr["cedula"].ToString();
                    consultaMovi.tlfno = dr["tlfno"].ToString();
                    consultaMovi.nro_cuenta = dr["cuenta"].ToString();
                    consultaMovi.monto = decimal.Parse(dr["monto"].ToString());
                    consultaMovi.tipo = dr["tipo"].ToString();
                    lconsltaMovi.Add(consultaMovi);
                    consultaMovi = new consultarMovimientoA();
                }
            }
        }
        else if (tipo_consulta.Equals("cliente"))
        {
            string query = id_cliente;
            command = ConnectionManager.BuildQuery("pa_consultarMovimiento", query, connection);            
            MySqlDataReader dr = command.ExecuteReader();

            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    consultaMovi.nro_movimiento = dr["nro_movimiento"].ToString();
                    consultaMovi.fecha = dr["fecha"].ToString();
                    consultaMovi.monto = decimal.Parse(dr["monto"].ToString());
                    consultaMovi.tipo = dr["tipo"].ToString();
                    //concepto... -> (se evaluara) -> dr["concepto"].ToString();
                    lconsltaMovi.Add(consultaMovi);
                    consultaMovi = new consultarMovimientoA();
                }
            }
        }

        connection.Close();
        return lconsltaMovi;
    }   
    //
    //method
    //Evaluar el metodo "pa_eliminarMovimiento" <- (No recomendado)
}