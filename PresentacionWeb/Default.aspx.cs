using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace PresentacionWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set;}
        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articulo = new Articulo();
           
            try
            {
               
                ListaArticulos = negocio.listar();

                repRepetidor.DataSource = ListaArticulos;
                repRepetidor.DataBind();
                
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}