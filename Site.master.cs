using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;
    private bool activeSesion = false;

    protected void Page_Init(object sender, EventArgs e)
    {
        
        //Session["inicioSesion"] = null;

        // The code below helps to protect against XSRF attacks
         var requestCookie = Request.Cookies[AntiXsrfTokenKey];
         Guid requestCookieGuidValue;
         if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
         {
             // Use the Anti-XSRF token from the cookie
             _antiXsrfTokenValue = requestCookie.Value;
             Page.ViewStateUserKey = _antiXsrfTokenValue;
         }
         else
         {
             // Generate a new Anti-XSRF token and save to the cookie
             _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
             Page.ViewStateUserKey = _antiXsrfTokenValue;

             var responseCookie = new HttpCookie(AntiXsrfTokenKey)
             {
                 HttpOnly = true,
                 Value = _antiXsrfTokenValue
             };
             if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
             {
                 responseCookie.Secure = true;
             }
             Response.Cookies.Set(responseCookie);
         }

         Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            // Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "e-Cash Bank";
        if (Session["inicioSesion"] != null)
        {
            activeSesion = true;
            string usuario = Session["inicioSesion"].ToString();
            link.HRef = "/Perfil.aspx";
            link.InnerText = usuario;
            link2.Text = "Cerrar Sesion";
        }
    }

    protected void CerrarSesion()
    {
        Session["inicioSesion"] = null;
        Session["usuario"] = null;
        Response.Redirect("/Default.aspx");
    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }

    protected void Button_Click(object sender, EventArgs e)
    {
        //< asp:Button style = "background-color:none" runat = "server" ID = "link2" Text = "Register" OnClick = "Button_Click" />
        //< a id = "link2" runat = "server" href = "~/Account/Register" > Register </ a ></ li >
        if (activeSesion)
        {
            CerrarSesion();
        }
        else
        {
            activeSesion = false;
            Response.Redirect("~/Account/Register.aspx");
        }
    }
}