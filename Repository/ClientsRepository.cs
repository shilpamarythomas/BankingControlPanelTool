using Contracts;
using Contracts.ViewModel;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClientsRepository : RepositoryBase<Clients>, IClientsRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public ClientsRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public List<Clients> GetFilteredClients(string searchTerm, ClientListParamters clientListParamters) {

            
            var filteredClientList = searchTerm != null ? _repositoryContext.Clients.Where(x => x.Email.Contains(searchTerm) || x.FirstName.Contains(searchTerm) ||
                                        x.LastName.Contains(searchTerm)).ToList() : _repositoryContext.Clients.ToList();           

            return filteredClientList.OrderBy(ow => ow.FirstName).Skip((clientListParamters.PageNumber - 1) * clientListParamters.PageSize)
                                   .Take(clientListParamters.PageSize).ToList();
        }

        public int AddClient(CreateClientVM clientVM)
        {
            var input = new Clients()
            {
                Email = clientVM.Email,
                Accounts = clientVM.Accounts.Select(x => new Accounts
                {
                    AccountName = x.AccountName,
                    AccountNumber = x.AccountNumber,
                    IBANNumber = x.IBANNumber,
                    CreatedBy = clientVM.CreatedBy
                }).ToList(),
                Address = clientVM.Address.Select(x => new UserAddress
                {
                    CityId= x.CityId,
                    CountryId= x.CountryId,
                    Street = x.Street,
                    ZipCode= x.ZipCode
                }).ToList(),
                FirstName = clientVM.FirstName,
                LastName = clientVM.LastName,
                MobileNo = clientVM.MobileNo,
                PersonalId = clientVM.PersonalId,
                ProfilePhoto = clientVM.ProfilePhoto,
                Sex = clientVM.Sex,
                CountryCode = clientVM.CountryCode,
                CreatedBy= clientVM.CreatedBy
            };
            Create(input);
            SaveChange();

            return input.Id;

        }
    }
}
