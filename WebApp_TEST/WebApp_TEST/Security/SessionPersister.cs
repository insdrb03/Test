using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_TEST.Security
{
    public static class SessionPersister
    {
        static string usernameSession = "username";

        public static string Username
        {

            get
            {

                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionvar = HttpContext.Current.Session[usernameSession];
                if (sessionvar != null)
                {
                    return sessionvar as string;
                }
                return null;

            }
            set
            {
                HttpContext.Current.Session[usernameSession] = value;


            }
        }
    }

    
}