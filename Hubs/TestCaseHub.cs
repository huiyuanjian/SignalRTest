using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.FileProviders;

namespace SignalRTest.Hubs
{
    public class TestCaseHub : Hub
    {
        public async Task SendTestCase()
        {
            var provider = new PhysicalFileProvider(Directory.GetCurrentDirectory());

            var fileInfos = provider.GetDirectoryContents(string.Empty);

            foreach(var fileInfo in fileInfos)
            {
                using (var stream = fileInfo.CreateReadStream())
                { 
                    await Clients.All.SendAsync("ReceiveTestCase", fileInfo.Name, stream);
                }
            }
        }
    }
}
