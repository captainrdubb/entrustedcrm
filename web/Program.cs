using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace Entrusted.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConventionRegistry.Register("camelCase", new ConventionPack { new CamelCaseElementNameConvention(), new EnumRepresentationConvention(BsonType.String) }, t => true);

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
