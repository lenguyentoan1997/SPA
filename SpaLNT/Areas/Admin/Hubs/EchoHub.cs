using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SpaLNT.Areas.Admin.Hubs
{
    public class EchoHub : Hub
    {
        [HubMethodName("broadcastData")]
        public async static void BroadcastData()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<EchoHub>();
            await context.Clients.All.updatedData();
        }
    }
}