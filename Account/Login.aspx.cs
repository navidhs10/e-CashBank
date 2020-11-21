using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using e_CashBank;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            if (!UserName.Text.Equals("") && !Password.Text.Equals(""))
            {
                UserName.Text = UserName.Text.Trim();
                Password.Text = Password.Text.Trim();
                usuario = UsuarioDAO.buscarUsuario(UserName.Text, Password.Text);
                if (usuario != null && !usuario.id.Equals("No existe"))
                {
                    Session["usuario"] = usuario;
                    Response.Redirect("/Perfil.aspx");
                }
                else if (usuario.id.Equals("No existe"))
                {
                    unregistered.Visible = true;
                    unregistered.Text = "Contraseña incorrecta o usuario no registrado";
                }
                else if (usuario == null)
                {
                    unregistered.Visible = true;
                    unregistered.Text = "Su usuario no ha sido confirmado";
                }
                else if (usuario.id.Equals("Inhabilitado"))
                {
                    unregistered.Visible = true;
                    unregistered.Text = "Este usuario ha sido suspendido";
                }
            }
            else
            {
                unregistered.Visible = true;
                unregistered.Text = "Usuario o contraseña invalida";
            }


       /* if (IsValid)
        {
           // Validate the user password
           var manager = new UserManager();
           ApplicationUser user = manager.Find(UserName.Text, Password.Text);
           if (user != null)
           {
               IdentityHelper.SignIn(manager, user, RememberMe.Checked);
               IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
           }
           else
           {
               FailureText.Text = "Invalid username or password.";
               ErrorMessage.Visible = true;
           }
        }*/

    }
}