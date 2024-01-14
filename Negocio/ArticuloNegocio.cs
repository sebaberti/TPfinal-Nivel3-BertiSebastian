using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select A.Id, A.Codigo Codigo,A.Nombre,A.Descripcion, A.ImagenUrl, A.Precio,C.Descripcion Categoria, M.Descripcion Marca, A.IdMarca, A.IdCategoria from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria = C.Id AND A.IdMarca = M.Id ");
                if (id != "")
                {
                    datos.setearConsulta("select A.Id, A.Codigo Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, C.Descripcion Categoria, M.Descripcion Marca, A.IdMarca, A.IdCategoria from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria = C.Id AND A.IdMarca = M.Id and A.Id = " + id);
                }

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = decimal.Parse(string.Format("{0:F2}", datos.Lector["Precio"]));


                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];


                    lista.Add(aux);


                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

       

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS values(@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @img, @precio)");
                datos.setearParametro("codigo", nuevo.Codigo);
                datos.setearParametro("nombre", nuevo.Nombre);
                datos.setearParametro("descripcion", nuevo.Descripcion);
                datos.setearParametro("idMarca", nuevo.Marca.Id);
                datos.setearParametro("idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("img", nuevo.Imagen);
                datos.setearParametro("precio", nuevo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca , IdCategoria = @idCategoria , ImagenUrl = @img, Precio = @precio WHERE id = @id");
                datos.setearParametro("id", art.Id);
                datos.setearParametro("codigo", art.Codigo);
                datos.setearParametro("nombre", art.Nombre);
                datos.setearParametro("descripcion", art.Descripcion);
                datos.setearParametro("idMarca", art.Marca.Id);
                datos.setearParametro("idCategoria", art.Categoria.Id);
                datos.setearParametro("img", art.Imagen);
                datos.setearParametro("precio", art.Precio);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}