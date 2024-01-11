using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Diagnostics.Eventing.Reader;

namespace PresentacionWeb
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        private List<Articulo> listaArticulos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["user"]))
            {
                Session.Add("error", "se requiere permiso admin");
                Response.Redirect("Error.aspx");
            }

            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                Session.Add("listaArticulos", negocio.listar());
                dgvArticulos.DataSource = Session["listaArticulos"];

                dgvArticulos.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }



        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {

            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada; 
            string filtro = txtFiltro.Text;
            if (!chkAzanzado.Checked)
            {
                listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.DataBind();
            }

            if (ddlAvanzado.SelectedItem.ToString() == "Mayor a" && chkAzanzado.Checked)
            {
                if (filtro == "")
                    listaFiltrada = listaArticulos;
                else
                {
                listaFiltrada = lista.FindAll(y => y.Precio > decimal.Parse(filtro));

                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.DataBind();

                }

            }

            if (ddlAvanzado.SelectedItem.ToString() == "Menor a" && chkAzanzado.Checked)
            { 
                if(filtro == "")
                {
                    listaFiltrada = listaArticulos;
                }
                else
                {
    
                    listaFiltrada = lista.FindAll(y => y.Precio < decimal.Parse(filtro));

                    dgvArticulos.DataSource = listaFiltrada;
                    dgvArticulos.DataBind();

                }
               
            }

           

        }

        protected void chkAzanzado_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
        }
    }
}