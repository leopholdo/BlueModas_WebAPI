using System.Linq;
using BlueModas_WebAPI.Data;
using BlueModas_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlueModas_WebAPI.Services
{
    public interface IClientService
    {
        TabClient GetClient(string tclEmail);
        TabClient InsertClient(TabClient client);
        TabClient UpdateClient(TabClient client);
    }

    public class ClientService : IClientService
    {
        readonly APIContext _apiContext;

        public ClientService(APIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public TabClient GetClient(string tclEmail)
        {
            TabClient client =
                _apiContext.TabClient
                .Where(s => s.tclEmail == tclEmail)
                .AsNoTracking()
                .DefaultIfEmpty()
                .ToList()[0];

            return client;
        }

        public TabClient InsertClient(TabClient client)
        {
            _apiContext.TabClient.Add(client);
            _apiContext.SaveChanges();

            return client;
        }

        public TabClient UpdateClient(TabClient client)
        {
            _apiContext.TabClient.Update(client);
            _apiContext.SaveChanges();

            return client;
        }
    }
}