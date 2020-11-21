using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Movimiento
/// </summary>
public class Movimiento
{
    public Movimiento()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public string nro_movimiento { get; set; }
    public string fecha { get; set; }    
    public decimal monto { get; set; }
    public string tipo { get; set; }
    public string concepto { get; set; }
}