using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using static System.Net.WebRequestMethods;

namespace PresentacionWeb
{
    public partial class Detalles : System.Web.UI.Page
    {
        public List<Articulo> Favoritos
        {
            get
            {
                if (Session["Favoritos"] == null)
                {
                    Session["Favoritos"] = new List<Articulo>();
                }
                return (List<Articulo>)Session["Favoritos"];
            }
            set
            {
                Session["Favorios"] = value;
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            MarcaNegocio negocioMarca = new MarcaNegocio();

            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {

                    Articulo seleccionado = (negocio.listar(id)[0]);


                  
                    imgDetalle.ImageUrl = seleccionado.Imagen;
                    


                    lblNombreTitulo.Text = seleccionado.Nombre;
                    lblCategoria.Text = seleccionado.Categoria.ToString();
                    lblMarca.Text = seleccionado.Marca.ToString();
                    lblDescripciom.Text = seleccionado.Descripcion;
                    lblPrecio.Text = seleccionado.Precio.ToString("0.00");


                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }



        }

        protected void btnFav_Click(object sender, EventArgs e)
        {

            if (Seguridad.sesionActiva(Session["user"]))
            {
                Users user = (Users)Session["user"];
                string id = Request.QueryString["id"];
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> listaFav = negocio.listar(id);
                Favoritos.Add(listaFav[0]);
                Response.Redirect("Favoritos.aspx");

            }
            else
            {
                Response.Redirect("Login.aspx",false);
            }


        }
    }
}