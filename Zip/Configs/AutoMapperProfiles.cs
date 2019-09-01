using AutoMapper;
using Zip.Data.Entities;
using Zip.Domain.Models.Account;
using Zip.Domain.Models.User;

namespace Zip.Configs
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserSummaryModel>();
            CreateMap<User, UserDetailsModel>();
            CreateMap<Account, AccountModel>()
                .ForMember(
                    x => x.AvailableCredit, 
                    opt => opt.MapFrom(src => src.CreditLimit - src.CreditBalance));

            CreateMap<Account, UserAccountModel>()
                .ForMember(
                    x => x.AvailableCredit,
                    opt => opt.MapFrom(src => src.CreditLimit - src.CreditBalance));
        }
    }
}
