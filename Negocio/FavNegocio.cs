using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FavNegocio
    {

        public List<Favoritoss> listar(string id = "")
        {
            AccesoDatos datos = new AccesoDatos();
            List<Favoritoss> listaFav = new List<Favoritoss>();
            try
            {
                datos.setearConsulta("SELECT U.Id, A.Nombre AS NombreArticulo, A.Precio AS PrecioArticulo,A.Id as ArtId, F.Id AS FavId, M.Descripcion AS MarcaArticulo FROM FAVORITOS F INNER JOIN  USERS U ON F.idUser = U.id INNER JOIN ARTICULOS A ON F.IdArticulo = A.Id INNER JOIN   MARCAS M ON A.IdMarca = M.Id WHERE U.id =" + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Favoritoss fav = new Favoritoss();
                    fav.Nombre = (string)datos.Lector["NombreArticulo"];

                    fav.Precio = decimal.Parse(string.Format("{0:F2}", datos.Lector["PrecioArticulo"]));
                    decimal.Parse(string.Format("{0:F2}", datos.Lector["PrecioArticulo"]));

                    fav.MarcaFav = new Marca();
                    fav.MarcaFav.Descripcion = (string)datos.Lector["MarcaArticulo"];

                    fav.IdArticulo = new Articulo();
                    fav.IdArticulo.Id = (int)datos.Lector["ArtId"];

                    fav.Id = (int)datos.Lector["FavId"];

                    listaFav.Add(fav);
                }
                return listaFav;

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

        public void agregarFav(string IdUser, string IdArt)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.setearConsulta("SELECT COUNT(*) FROM FAVORITOS WHERE idUser = @IdUser AND IdArticulo = @IdArt");
                //datos.setearParametro("IdUser", IdUser);
                //datos.setearParametro("IdArt", IdArt);
                //datos.ejecutarLectura();


                //int cantidad = 0;
                //if (datos.Lector.Read())
                //{
                //    cantidad = (int)datos.Lector[0];

                //}
                //datos.cerrarConexion();


                //if (cantidad == 0)
                {
                    datos.setearConsulta("INSERT INTO FAVORITOS(IdUser,IdArticulo) values (@IdUser,@IdArt)");
                    datos.setearParametro("IdUser", IdUser);
                    datos.setearParametro("IdArt", IdArt);
                    datos.ejecutarAccion();
                }


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

        public void eliminarFav(string IdArt)
        {
            AccesoDatos datos = new AccesoDatos();

            datos.setearConsulta("delete from favoritos where IdArticulo = @IdArt");
            datos.setearParametro("@IdArt", IdArt);
            datos.ejecutarAccion();
        }

        public void eliminarFav2(string Id)
        {
            AccesoDatos datos = new AccesoDatos();

            datos.setearConsulta("delete from favoritos where Id = @Id");
            datos.setearParametro("@Id", Id);
            datos.ejecutarAccion();
        }
    }
}
