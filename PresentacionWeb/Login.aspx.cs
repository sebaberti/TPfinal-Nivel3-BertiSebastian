using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace PresentacionWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            UsersNegocio negocio = new UsersNegocio();

            try
            {
                if (Validacion.validaTextoVacio(txtEmail) || Validacion.validaTextoVacio(txtPassword))
                {
                    base.Session.Add("error", "Ambos campos deben estar completos");
                    Response.Redirect("Error.aspx");

                }
                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;
               if(negocio.Login(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }



            }
            catch (System.Threading.ThreadAbortException ex)
            {

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}