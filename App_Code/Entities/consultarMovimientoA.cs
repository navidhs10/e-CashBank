using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for consultarMovimientoA
/// </summary>
public class consultarMovimientoA
{
    public consultarMovimientoA()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int id { get; set; }
    public string nro_movimiento { get; set; }
    public string fecha { get; set; }
    public string nombre_cliente { get; set; }
    public string apellido { get; set; }
    public string correo { get; set; }
    public string tlfno { get; set; }
    public string nro_cuenta { get; set; }
    public decimal monto { get; set; }
    public string tipo { get; set; }

}