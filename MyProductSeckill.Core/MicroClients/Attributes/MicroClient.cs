using System;
using System.Collections.Generic;
using System.Text;

namespace MyProductSeckill.Core.MicroClients.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class MicroClient : Attribute
    {
        public string UrlShcme { get; }
        public string ServiceName { get; }
        public MicroClient(string urlShcme, string serviceName)
        {
            this.UrlShcme = urlShcme;
            this.ServiceName = serviceName;
        }
    }
}
