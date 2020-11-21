using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using e_CashBank;

public partial class Account_Register : Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {

        if (UserName.Text.Contains(" ") && Password.Text.Contains(" "))
        {
            LabelError.Visible = true;
        }
        else
        {
            LabelError.Visible = false;
            UsuarioDAO.AgregarUsuario(UserName.Text.Trim(), Password.Text.Trim(), "123c", Name.Text, LastName.Text, cedula.Text.Trim(), correo.Text.Trim(), tlfno.Text.Trim());
            Usuario user = new Usuario();
            user = UsuarioDAO.buscarUsuario(UserName.Text.Trim(), Password.Text.Trim());
            if (user.usuario != null)
            {
                //Session["usuario"] = user.id + ";" + user.usuario;
                Response.Redirect("/Default.aspx");
            }
            else
            {
                LabelError.Visible = true;
                LabelError.InnerText = "Ha habido un error guardando los datos.";
            }
        }        


        /*var manager = new UserManager();
        //var user = new ApplicationUser() { UserName = UserName.Text };
        var user = new ApplicationUser();
        
        IdentityResult result = manager.Create(user, Password.Text);
        if (result.Succeeded)
        {
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
        else
        {
            ErrorMessage.Text = result.Errors.FirstOrDefault();
        }

        

        Server.Transfer("Login.aspx", true); */
    }
}