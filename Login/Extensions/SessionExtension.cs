using Login.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Login.Extensions
{
    public static class SessionExtension
    {
        public static string GetLogin(this HttpSessionStateBase session)
        {
            return session[SessionElement.Login.DescriptionAttr()].ToString();
        }

        public static void SetLogin(this HttpSessionStateBase session, string value)
        {
            session[SessionElement.Login.DescriptionAttr()] = value;
        }

        public static string GetLogin(this HttpSessionState session)
        {
            return session[SessionElement.Login.DescriptionAttr()].ToString();
        }

        public static void SetLogin(this HttpSessionState session, string value)
        {
            session[SessionElement.Login.DescriptionAttr()] = value;
        }
    }
}