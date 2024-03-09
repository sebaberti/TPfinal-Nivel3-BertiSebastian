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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            imgPerfilAvatar.ImageUrl = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
           
            // chequeamos si la pag que estoy por cargar no es ninguna de estas 3
            // si no es quiero que me verifique la seguridad 
            if (!(Page is Login || Page is Register || Page is Error ))
                //{
                //    if (!Seguridad.sesionActiva(Session["user"]))
                //        Response.Redirect("Default.aspx", false);
                
                if (Seguridad.sesionActiva(Session["user"]))
                {
                    Users user = (Users)Session["user"];
                    lblUser.Text = user.Nombre;
                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        imgPerfilAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                }
                
        }
    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
    }

}
    