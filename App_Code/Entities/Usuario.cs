using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Usuario
/// </summary>
public class Usuario
{
    public Usuario()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string id { get; set; }
    public string usuario { get; set; }
    public string clave { get; set; }
    public string codi_usuario { get; set; }
    public string enabled { get; set; }
}