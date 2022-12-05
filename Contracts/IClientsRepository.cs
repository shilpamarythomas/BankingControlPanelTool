using Contracts.ViewModel;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IClientsRepository : IRepositoryBase<Clients>
    {
        int AddClient(CreateClientVM clientVM);
        List<Clients> GetFilteredClients(string searchTerm, ClientListParamters clientListParamters);
    }
}
