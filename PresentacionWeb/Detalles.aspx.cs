using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;
using System.Web.ModelBinding;
using System.Web.Script.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Dominio;
using Microsoft.Win32;
using Negocio;
using static System.Net.WebRequestMethods;
using Dominio = Dominio.Favoritoss;
using PresentacionWeb = PresentacionWeb.Favoritos;

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
                if (id != "" && !IsPostBack)
                {

                    Articulo seleccionado = (negocio.listar(id)[0]);

                    imgDetalle.ImageUrl = seleccionado.Imagen;

                    lblNombreTitulo.Text = seleccionado.Nombre;
                    lblCategoria.Text = seleccionado.Categoria.ToString();
                    lblMarca.Text = seleccionado.Marca.ToString();
                    lblDescripciom.Text = seleccionado.Descripcion;
                    lblPrecio.Text = seleccionado.Precio.ToString("0.00");


                    FavNegocio negocioFav = new FavNegocio();

                    Users user = (Users)Session["user"];
                    if (user != null)
                    {
                        List<Favoritoss> listaFavoritos = negocioFav.listar(user.Id.ToString());

                        if (listaFavoritos.Any(art => art.IdArticulo.Id == seleccionado.Id))
                        {
                            btnFav.Visible = false;
                            btnQuitarFAV.Visible = true;
                        }
                        else
                        {
                            btnFav.Visible = true;
                            btnQuitarFAV.Visible = false;
                        }

                    }
                    else
                    {
                        btnQuitarFAV.Visible = false;
                    }


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


            try
            {
                string IdArt = Request.QueryString["id"];
                Users user = (Users)Session["user"];


                if (Seguridad.sesionActiva(Session["user"]))
                {
                    string IdUser = user.Id.ToString();
                    FavNegocio negocio = new FavNegocio();
                    negocio.agregarFav(IdUser, IdArt);
                    btnFav.Visible = false;
                    btnQuitarFAV.Visible = true;
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        protected void btnQuitarFAV_Click(object sender, EventArgs e)
        {


            string IdArt = Request.QueryString["id"];
            FavNegocio negocio = new FavNegocio();

            try
            {
                negocio.eliminarFav(IdArt);
                btnFav.Visible = true;
                btnQuitarFAV.Visible = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}