using APM.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace APM.WebApi.Utility
{
    public class UnitTestPathProvider : IPathProvider
    {
        public string MapPath(string path)
        {
            var assmblyPath = Assembly.GetCallingAssembly().Location;
            assmblyPath = Path.GetDirectoryName(assmblyPath);
            assmblyPath = Path.Combine(assmblyPath, @"..\..\..\APM.WebApi");
            path = path.Remove(0, 2);
            path = path.Replace("/", @"\");
            assmblyPath = Path.Combine(assmblyPath, path);

            if (File.Exists(assmblyPath) == true)
            {
                Console.WriteLine("True");
            }
            return assmblyPath;
        }
    }
}