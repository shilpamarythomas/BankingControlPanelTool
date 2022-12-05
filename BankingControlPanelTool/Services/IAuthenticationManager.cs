using Entities.Models;

namespace BankingControlPanelTool.Services
{
    public interface IAuthenticationManager
    {
         void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
         bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateToken(BankUsers user);
    }
}
