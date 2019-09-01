using System;
using System.Threading.Tasks;
using Zip.Domain.Models;
using Zip.Domain.Models.Account;
using Zip.Domain.Models.User;

namespace Zip.Domain.Contracts
{
    public interface IUserService
    {
        Task<UserSummaryModel> Create(CreateUserRequest request);
        Task<UserDetailsModel> Get(Guid id);
        Task<Paged<UserSummaryModel>> GetAll(int pageSize, int pageNumber);
        Task<UserDetailsModel> CreateAccount(Guid userId, CreateAccountRequest request);
    }
}
