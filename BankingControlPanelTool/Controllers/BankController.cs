using Contracts;
using Contracts.ViewModel;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using PhoneNumbers;


namespace BankingControlPanelTool.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankUsersRepository _bankUsersRepository;
        private readonly IClientsRepository _clientsRepository;
        private readonly ISearchHistoryRepository _searchHistoryRepository;
        private readonly ICountryRepository _countryRepository;
        public BankController(IBankUsersRepository bankUsersRepository, 
                            IClientsRepository clientsRepository,
                            ISearchHistoryRepository searchHistoryRepository,
                            ICountryRepository countryRepository)
        {
            _bankUsersRepository = bankUsersRepository;
            _clientsRepository = clientsRepository;
            _searchHistoryRepository = searchHistoryRepository;
            _countryRepository = countryRepository;
        }

        [HttpGet, Authorize]
        public IActionResult GetClient(string? searchTerm,[FromQuery] ClientListParamters getClientParamters)
        {
            try
            {
                var filteredClientList = _clientsRepository.GetFilteredClients(searchTerm, getClientParamters);
                if (filteredClientList.Count > 0 && !String.IsNullOrEmpty(searchTerm))
                {
                    _searchHistoryRepository.AddSearchHistory(searchTerm);
                }
                return Ok(filteredClientList.Count > 0 ? filteredClientList : "No records found.");
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        [HttpGet, Authorize]
        public IActionResult GetLastSearchedParamters()
        {
            try
            {
                return Ok(_searchHistoryRepository.GetSearchHistory());
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost, Authorize]
        public ActionResult AddClients(CreateClientVM clientVM)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                if (clientVM == null)
                {
                    throw new ArgumentNullException(nameof(clientVM));
                }

                string mobilenumber = clientVM.MobileNo;
                string countryCode = clientVM.CountryCode;
                //PhoneNumbers.PhoneNumber phoneNumber = phoneUtil.Parse(mobilenumber, countryCode);
                //bool isValidNumber = phoneUtil.IsValidNumber(phoneNumber);
                //string countrycode = _countryRepository.GetCountries(clientVM.Address.FirstOrDefault().CountryId);
                //bool IsValidRegion = phoneUtil.IsValidNumberForRegion(phoneNumber, countrycode);

                //if (!isValidNumber || !IsValidRegion)
                //{
                //    return BadRequest("Invalid Mobilenumber format!");
                //}

                var userDetails = _bankUsersRepository.GetUsersById(clientVM.CreatedBy);
                if(userDetails == null || userDetails.RoleId != 1)
                {
                    return BadRequest("You are not permitted to create a new client!");
                }

                if (ModelState.IsValid)
                {
                    _clientsRepository.AddClient(clientVM);
                    return Ok("Inserted successfully!");
                }
                else
                {
                    return BadRequest("Failed to insert!");
                }                
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
