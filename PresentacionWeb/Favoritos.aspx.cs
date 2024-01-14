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

                dgvArticulosFavoritos.DataSource = Session["Favoritos"];
                dgvArticulosFavoritos.DataBind();
            }
        }

        protected void dgvArticulosFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Articulo fav = new Articulo();
            string id = dgvArticulosFavoritos.SelectedDataKey.Value.ToString();
            List<Articulo> lista = (List<Articulo>)Session["Favoritos"];

            lista.RemoveAll(x => x.Id == int.Parse(id));

            dgvArticulosFavoritos.DataSource = Session["Favoritos"];
            dgvArticulosFavoritos.DataBind();
        }
    }
}