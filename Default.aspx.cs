using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            Usuario user = (Usuario)Session["usuario"];
            Persona persona = new Persona();
            persona = UsuarioDAO.consultarPersona(user.id);
            if (persona.id != null)
                titulo.InnerText = "Bienvenido " + persona.nombre + " " + persona.apellido;

            //Session["usuario"] = null;
            Session["inicioSesion"] = user.usuario;
            
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        //Usuario user = new Usuario();

        /*user = data.buscarUsuario("navidhs10", "navidpwns10");

        if (user != null || user.usuario != string.Empty)
        {
            prueba.Text = user.usuario + " " + user.clave + " " + user.id + " " + user.codi_usuario;
        }
        else
        {
            prueba.Text = "No se ha encontrado dato o no se ha conectado a bd";
        }*/
        

        //GridView1.DataSource = ds.Tables[0];
        //GridView1.DataBind();
        
    }
}