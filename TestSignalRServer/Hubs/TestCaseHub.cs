using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.FileProviders;

namespace TestSignalRServer
{
    public class TestCaseHub : Hub
    {
        public async Task SendTestCase(string fileName)
        {
            var provider = new PhysicalFileProvider(Directory.GetCurrentDirectory());

            var fileInfos = provider.GetDirectoryContents("TestCases");
            var fileInfo = fileInfos.FirstOrDefault(f => f.Name.Contains(fileName));

            using (var reader = new StreamReader(fileInfo.PhysicalPath))
            {
                await Clients.All.SendAsync("TestReceive");
                var content = reader.ReadToEnd();
                await Clients.All.SendAsync("ReceiveString", fileInfo.Name, content);
            }

        }
    }
}
