using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace XUnitTestProject1
{
    public static class ServerFactory
    {
        
            public static TestServer GetServerInstance()
            {
                return new TestServer(new WebHostBuilder()
                     .UseContentRoot(Directory.GetCurrentDirectory())
                   .UseStartup<TestStartup>());
            }

            
    }
}
