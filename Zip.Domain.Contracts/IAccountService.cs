using System.Threading.Tasks;
using Zip.Domain.Models;
using Zip.Domain.Models.Account;

namespace Zip.Domain.Contracts
{
    public interface IAccountService
    {
        Task<Paged<AccountModel>> Get(int pageSize, int pageNumber);
    }
}
