using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for consultarSolicitudA
/// </summary>
public class consultarSolicitudA
{
    public consultarSolicitudA()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int id { get; set; }
    public string nro_soli { get; set; }
    public string fecha { get; set; }
    public string nombre_cliente { get; set; }
    public string apellido { get; set; }
    public string correo { get; set; }
    public string tlfno { get; set; }
    public string tipo_operacion { get; set; }
    public decimal monto { get; set; }    
    public string estado { get; set; }

}