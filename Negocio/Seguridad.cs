using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public static class Seguridad
    {
    //static para que no haga falta instanciar cuando la quiero usar
        public static bool sesionActiva(object usuario)
        {
            //validamos si hay una persona logueada
            // 
            Users user = usuario != null ? (Users)usuario : null;
            if (user != null && user.Id != 0)
                return true;
            else
                return false;
        }
    public static bool esAdmin(object usuario)
    {
        Users user = usuario != null ? (Users)usuario : null;
            return user != null ? user.Admin : false;
    }

  


    }


}
