using BankingControlPanelTool.Services;
using Contracts;
using Contracts.ViewModel;
using Entities;
using Entities.Models;
using Entities.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BankingControlPanelTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IBankUsersRepository _bankUsersRepository;
        public static BankUsers user = new BankUsers();
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IUserRolesRepository _userRolesRepository;


        public AuthenticationController(IBankUsersRepository bankUsersRepository,IAuthenticationManager authenticationService,
            IUserRolesRepository userRolesRepository)
        {
            _bankUsersRepository = bankUsersRepository;
            _authenticationManager = authenticationService;
            _userRolesRepository = userRolesRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<BankUsers>> Register(CreateUserVM request)
        {
            try
            {
                _authenticationManager.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var user = _bankUsersRepository.CreateBankUser(request, passwordHash, passwordSalt);

                return Ok(user);
            }            
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpGet("GetRoles"), Authorize]
        public ActionResult GetUserRoles()
        {
            try
            {
                return Ok(_userRolesRepository.GetUserRoles());
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }



        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            try
            {
                var user = _bankUsersRepository.GetUsers(request.Username);
                if (user == null || user.UserName != request.Username)
                {
                    return BadRequest("User not found.");
                }

                if (!_authenticationManager.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return BadRequest("Wrong password.");
                }

                string token = _authenticationManager.CreateToken(user);

                //var refreshToken = GenerateRefreshToken();
                //SetRefreshToken(refreshToken);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        
    }
}
