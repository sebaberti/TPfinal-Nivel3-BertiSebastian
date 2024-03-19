using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class UsersNegocio
    {
        public bool Login(Users user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select id, email, pass, admin, urlImagenPerfil, nombre, apellido from USERS where email = @email And pass = @pass");
                datos.setearParametro("@email" , user.Email);
                datos.setearParametro("@pass", user.Pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["id"];
                    user.Admin = (bool)(datos.Lector["admin"]);
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        user.ImagenPerfil = (string)(datos.Lector["urlImagenPerfil"]);
                    if (!(datos.Lector["nombre"] is DBNull))
                        user.Nombre = (string)(datos.Lector["nombre"]);
                    if (!(datos.Lector["apellido"] is DBNull))
                        user.Apellido = (string)(datos.Lector["apellido"]);
                    
                    return true;
                }
                return false;
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
        public int insertarNuevo(Users nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into USERS (email, pass, admin) output inserted.id values (@email, @pass, 0)");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("pass", nuevo.Pass);
                // va a obtener el id del registro que acabamos de insertar
                return datos.ejecutarAccionScalar();


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


        public void actualizar(Users user)
        {
                AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USERS set Nombre = @nombre, Apellido = @apellido,urlImagenPerfil = @imagen, Email =@email Where Id = @id");
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@email", user.Email);
                //datos.setearParametro("@imagen", (object)user.ImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : "");
                datos.setearParametro("@id", user.Id);
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


        public bool correoExistente(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM USERS WHERE email = @email");
                datos.setearParametro("@email", email);

                int count = datos.ejecutarAccionScalar();

                return count > 0;

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

    }
}
