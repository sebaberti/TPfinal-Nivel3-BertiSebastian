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
    public partial class Detalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           ArticuloNegocio negocio = new ArticuloNegocio();
           CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            MarcaNegocio negocioMarca = new MarcaNegocio();

            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if ( id != "" && !IsPostBack)
                {

                    Articulo seleccionado = (negocio.listar(id)[0]);

                    imgDetalle.ImageUrl = seleccionado.Imagen;


                    lblNombreTitulo.Text = seleccionado.Nombre;
                    lblCategoria.Text = seleccionado.Categoria.ToString();
                    lblMarca.Text = seleccionado.Marca.ToString();
                    lblDescripciom.Text = seleccionado.Descripcion;
                    lblPrecio.Text = seleccionado.Precio.ToString();

                   
                }

            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}