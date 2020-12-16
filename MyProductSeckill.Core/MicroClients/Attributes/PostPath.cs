using System;
using System.Collections.Generic;
using System.Text;

namespace MyProductSeckill.Core.MicroClients.Attributes
{
    /// <summary>
    /// post请求特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class PostPath : Attribute
    {
        public string Path { get; set; }
        public PostPath(string Path)
        {
            this.Path = Path;
        }
    }
}
