using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    Users user = (Users)Session["user"];

                    CargarFavoritosUsuario(user.Id.ToString());
                }

            }
        }

        public void CargarFavoritosUsuario(string userId)
        {


            FavNegocio negocioFav = new FavNegocio();

            if (!string.IsNullOrEmpty(userId) && !IsPostBack)
            {
                dgvArticulosFavoritos.DataSource = negocioFav.listar(userId);
                dgvArticulosFavoritos.DataBind();
            }
        }

        protected void dgvArticulosFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {

            string id = dgvArticulosFavoritos.SelectedDataKey.Value.ToString();
            FavNegocio negocio = new FavNegocio();
            Users user = (Users)Session["user"];

            try
            {

                negocio.eliminarFav2(id.ToString());
                dgvArticulosFavoritos.DataSource = negocio.listar(user.Id.ToString());
                dgvArticulosFavoritos.DataBind();
              

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}