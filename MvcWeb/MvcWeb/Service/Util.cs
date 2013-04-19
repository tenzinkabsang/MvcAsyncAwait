using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MvcWeb.Service
{
    public class Util
    {
        private static string GetRootUri()
        {
            return Configuration.WidgetServiceURI;
        }

        public static string GetServiceUri(string service)
        {
            return GetRootUri() + "api/" + service;
        }
    }

    public static class Configuration
    {
        private static string Uri;

        public static string WidgetServiceURI
        {
            get
            {
                if (!string.IsNullOrEmpty(Uri))
                    return Uri;

                Uri = GetKeyValue("WidgetServiceURI");
                return string.IsNullOrEmpty(Uri) ? "http://localhost:41929/" : Uri;
            }
        }

        public static string GetKeyValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}