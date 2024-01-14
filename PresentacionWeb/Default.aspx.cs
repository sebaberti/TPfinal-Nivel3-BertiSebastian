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

        public List<Articulo> ListaArticulos { get; set; }

        private List<Articulo> listaArticulos;

        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articulo = new Articulo();

            try
            {

                Session.Add("listaArticulos", negocio.listar());

                repRepetidor.DataSource = Session["listaArticulos"];
                repRepetidor.DataBind();


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void btnBuscador_Click(object sender, EventArgs e)
        {
            
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada;
            string filtro = txtFiltro.Text;
           
            if (!chkAvanzadoDefault.Checked)
            {
                listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                repRepetidor.DataSource = listaFiltrada;
                repRepetidor.DataBind();
            }

            if (ddlAvanzado.SelectedItem.ToString() == "Precio mayor a" && chkAvanzadoDefault.Checked)
            {
                if (filtro == "")
                    listaFiltrada = listaArticulos;
                else
                {
                    listaFiltrada = lista.FindAll(y => y.Precio > decimal.Parse(filtro));

                    repRepetidor.DataSource = listaFiltrada;
                    repRepetidor.DataBind();

                }

            }

            if (ddlAvanzado.SelectedItem.ToString() == "Precio menor a" && chkAvanzadoDefault.Checked)
            {
                if (filtro == "")
                {
                    listaFiltrada = listaArticulos;
                }
                else
                {

                    listaFiltrada = lista.FindAll(y => y.Precio < decimal.Parse(filtro));

                    repRepetidor.DataSource = listaFiltrada;
                    repRepetidor.DataBind();

                }

            }
            
        }

        
        protected void chkAzanzadoDefault_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            regexValidator.Visible = chkAvanzadoDefault.Checked;
            ddlAvanzado.Visible = chkAvanzadoDefault.Checked;
        }


    }
}