using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.ComponentModel.Design;

namespace PresentacionWeb
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
       
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            btnEliminar.Enabled = false;

            ArticuloNegocio negocio = new ArticuloNegocio();
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            MarcaNegocio negocioMarca = new MarcaNegocio();
            try
            {
                if (!IsPostBack)
                {
                    List<Articulo> listaArticulos = negocio.listar();
                   
                    ddlCategoria.DataSource = negocioCategoria.listar();
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();


                    ddlMarca.DataSource = negocioMarca.listar();
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    btnEliminar.Enabled = true;
                    Articulo seleccionado = (negocio.listar(id))[0];
                    
                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    TxtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.Imagen;
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    cargarImagen(txtImagenUrl.Text);
                }



            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo nuevo = new Articulo();
            try
            {
   
               nuevo.Codigo = txtCodigo.Text;
               nuevo.Nombre = TxtNombre.Text;
               nuevo.Descripcion = txtDescripcion.Text;
               nuevo.Precio = decimal.Parse(txtPrecio.Text);
               nuevo.Imagen = txtImagenUrl.Text;


               nuevo.Categoria = new Categoria();
               nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                

               nuevo.Marca = new Marca();
               nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.Modificar(nuevo);
       
                }

                else
                
                    negocio.agregar(nuevo);

                    Response.Redirect("ListaArticulos.aspx", false);

            } 
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int id = int.Parse(ddlCategoria.SelectedItem.Value);
            //ddlMarca.DataSource = ((List<Articulo>)Session["listaArticulos"]).FindAll(x => x.Categoria.Id == id);
            //ddlMarca.DataTextField = "Nombre";
            //ddlMarca.DataBind();
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            cargarImagen(txtImagenUrl.Text);
           
        }

        public void cargarImagen(string img)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkconfirmaEliminacion.Checked)
                {
                ArticuloNegocio negocio =  new ArticuloNegocio();
                negocio.eliminar(int.Parse(txtId.Text));
                Response.Redirect("ListaArticulos.aspx", false);

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");

            }
        }
    }
}