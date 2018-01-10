using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Login.Extensions
{
    public static class EnumExtension
    {       
        public static string DescriptionAttr<T>(this T source)
        {
            var fi = source.GetType().GetField(source.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }              

        public static T GetEnumWithDescription<T>(this IEnumerable<T> source, string description)
        {
            foreach (var element in source)
            {
                var fi = element.GetType().GetField(element.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var desc = (attributes != null && attributes.Length > 0) ? attributes[0].Description : element.ToString();
                if (desc == description) return element;
            }
            throw new Exception("Enum with specific description not found");
        }
                
    }
}