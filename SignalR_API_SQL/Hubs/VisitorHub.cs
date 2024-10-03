using Microsoft.AspNetCore.SignalR;
using SignalR_API_SQL.Model;

namespace SignalR_API_SQL.Hubs
{
    public class VisitorHub:Hub
    {
        private readonly VisitorService _visitorService;

        public VisitorHub(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("ReceiveVisitorList", "_visitorService.GetVisitorChartList()");
        }
    }
}
