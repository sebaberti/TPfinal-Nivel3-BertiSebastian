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
        public static bool sesionActiva(object usuario)
        {
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
