using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using SignalRTest.Hubs;

namespace SignalRTest.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IHubContext<TestCaseHub> _hubContext;

        public IndexModel(IHubContext<TestCaseHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public void OnGet()
        {

        }
    }
}
