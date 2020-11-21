using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CuentaCliente
/// </summary>
public class CuentaCliente
{
    public CuentaCliente()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string cuentaCreacion { get; set; }
    public int nro_cuenta { get; set; }
    public string nombreCuenta { get; set; }
    public string fecha_movimiento { get; set; }
    public string nro_movimiento { get; set; }
    public decimal monto { get; set; }
    public string tipo { get; set; }
    public string concepto { get; set; }

}