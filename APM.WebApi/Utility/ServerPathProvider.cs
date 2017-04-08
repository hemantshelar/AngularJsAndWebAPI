using APM.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace APM.WebApi.Utility
{
    public class ServerPathProvider : IPathProvider
    {
        public string MapPath(string path)
        {
            var fullPath = HostingEnvironment.MapPath(path);
            //fullPath = Path.GetDirectoryName(fullPath);
            //path = path.Remove(0, 2);
            //path = path.Replace("/", @"\");
            //fullPath = Path.Combine(fullPath,path);
            return fullPath;
        }
    }
}