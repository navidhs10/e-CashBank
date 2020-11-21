using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Perfil : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            Usuario user = (Usuario)Session["usuario"];
            Persona persona = new Persona();
            persona = UsuarioDAO.consultarPersona(user.id);
            if (persona != null || !persona.id.Equals(""))
            {               
                Session["inicioSesion"] = user.usuario;
                //verificarCuentas(persona);
            }
        }
        else
        {
            //Response.Redirect("/Default.aspx");
        }
    }

    protected void verificarCuentas(Persona personal)
    {
       /* List<Cuenta> lCuenta = new List<Cuenta>();
        lCuenta = CuentaDAO.pa_consultarCuentaCliente(int.Parse(personal.id));
        if (lCuenta.Count > 0)
        {
            New.Attributes.Add("style", "display:none;");
            Old.Visible = true;
            cargaGrid.Visible = true;
            cargarGrid(lCuenta);
            /*GridView1.HeaderRow.Cells[0].Text = "Creacion";
            GridView1.HeaderRow.Cells[1].Text = "Cuenta";
            GridView1.HeaderRow.Cells[2].Text = "Nombre Cuenta";
            GridView1.HeaderRow.Cells[3].Text = "Fecha Movimiento";
            GridView1.HeaderRow.Cells[4].Text = "Movimiento";
            GridView1.HeaderRow.Cells[5].Text = "Monto";
            GridView1.HeaderRow.Cells[6].Text = "Tipo";
            GridView1.HeaderRow.Cells[7].Text = "Concepto"; 
        }*/
        
    }
    
    protected void cargarGrid( List<Movimiento> Movimiento = null)
    {
        
       /* GridMovimiento.Visible = true;
        GridView1.DataSource = Movimiento;
        GridView1.DataBind();
        GridView1.HeaderRow.Cells[0].Text = "Nro.";
        GridView1.HeaderRow.Cells[1].Text = "Fecha";
        GridView1.HeaderRow.Cells[2].Text = "Monto";
        GridView1.HeaderRow.Cells[3].Text = "Tipo";
        GridView1.HeaderRow.Cells[4].Text = "Concepto";*/
        
    }

    /*protected void CambioDataGrid(string numero)
    {
        if (Session["usuario"] != null)
        {
            string[] user = Session["usuario"].ToString().Split(';');
            if (numero.Equals("1"))
            {
                List<Cuenta> lCuenta = new List<Cuenta>();
                lCuenta = CuentaDAO.pa_consultarCuentaCliente(int.Parse(user[0]));
                cargarGrid(lCuenta);
            }
            else if (numero.Equals("2"))
            {
                if (cuenta.ToString() != String.Empty)
                {
                    List<Movimiento> lmovimiento = new List<Movimiento>();
                    lmovimiento = MovimientoDAO.pa_consultarMovimiento(user[0], cuenta.Value);
                    if (lmovimiento.Count > 0)
                    {
                        cargarGrid(null, lmovimiento);
                        prueba.Text = "";
                    }
                    else
                        prueba.Text = "No tienes movimientos para esta cuenta";
                }
            }
        }
    }*/

    /*protected void cargarCuentaInfo(string[] datos)
    {
        if (datos.Length == 3)
        {
            tituloInfo.InnerText = "Informacion de tu cuenta";
            infoC.Visible = true;
            P1.InnerText = datos[0];
            P2.InnerText = datos[1];
            P3.InnerText = datos[2];

        }
        else
        {
            prueba.Text = "Ha ocurrido un error";
        }

    }*/

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /*if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "this.style.cursor='pointer'; this.style.backgroundColor='#cccccc'; this.style.color = 'Black';");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor='White'; this.style.color='Black';");
            e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackClientHyperlink(GridView1, "select$" + e.Row.RowIndex.ToString()));
            e.Row.BackColor = Color.FromName("White");
            e.Row.ForeColor = Color.FromName("black");
            e.Row.Font.Bold = false;
        }*/
    }    

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
       /* if (GridView1.SelectedRow != null)
        {
            GridView1.SelectedRow.BackColor = Color.FromName("rgb(112, 182, 243)");
            GridView1.SelectedRow.ForeColor = Color.FromName("White");
            GridView1.SelectedRow.Font.Bold = false;

            GridMovimiento.Visible = false;
            cuenta.Value = GridView1.SelectedRow.Cells[0].Text;*/
            /*if (cuenta.Value != String.Empty)
            {
                string[] datos = new string[3];
                datos[0] = GridView1.SelectedRow.Cells[0].Text;
                datos[1] = GridView1.SelectedRow.Cells[1].Text;
                datos[2] = GridView1.SelectedRow.Cells[2].Text;
                CambioDataGrid("2");
                cargarCuentaInfo(datos);
            }
        }*/
        /*else
        {            
            GridView2.SelectedRow.BackColor = Color.FromName("rgb(112, 182, 243)");
            GridView2.SelectedRow.ForeColor = Color.FromName("White");
            GridView2.SelectedRow.Font.Bold = false;
        }*/

        
    }
    
}