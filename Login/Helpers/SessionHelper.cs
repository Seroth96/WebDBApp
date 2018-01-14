using WebDBApp.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDBApp.Helpers
{
    public static class SessionHelper
    {
        public static T GetElement<T>(SessionElement sessionElement)
        {
            var element = HttpContext.Current.Session[sessionElement.ToString()];
            return element == null ? default(T) : (T)element;
        }

        public static void SetElement(SessionElement sessionElement, object value)
        {
            HttpContext.Current.Session[sessionElement.ToString()] = value;
        }

        public static void SetLogin(string login, string role)
        {
            HttpContext.Current.Session[SessionElement.Login.ToString()] = login;
            HttpContext.Current.Session[SessionElement.Role.ToString()] = role;
            HttpContext.Current.Session[SessionElement.IsAdmin.ToString()] = true;
        }

       

       
    }
}