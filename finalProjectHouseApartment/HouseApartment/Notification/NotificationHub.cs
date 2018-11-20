using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseApartment.Notification
{

    public class NotificationHub : Hub
    {

        private static Dictionary<string, dynamic> connectedClients = new Dictionary<string, dynamic>();


        public void RegisterClient(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                lock (connectedClients)
                {
                    if (connectedClients.ContainsKey(userName))
                    {
                        connectedClients[userName] = Clients.Caller;
                    }
                    else
                    {
                        connectedClients.Add(userName, Clients.Caller);
                    }
                }
            }
        }


        public void message(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {


                foreach (var item in connectedClients)
                {
                    if (!string.IsNullOrEmpty(item.Key))
                    {
                        if (HttpContext.Current.User.Identity.Name != item.Key)
                        {
                            string user = item.Key;
                            {
                                Clients.All.sendMessage(message);
                            }
                        }

                    }

                }
            }
        }
    }
}