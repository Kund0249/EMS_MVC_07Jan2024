using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace EMS_MVC_07Jan2024.Models.ExtensionMethod
{
    public static class ConvertListString
    {
        public static String ListToString(this List<string> s,string Delemenator)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in s)
            {
                builder.Append(item + Delemenator);
            }
            string convertedValue = builder.ToString();
            convertedValue = convertedValue.Remove(convertedValue.LastIndexOf(Delemenator));
            return convertedValue;
        }
    }
}