namespace Zip.Domain.Models.User
{
    public class UserDetailsModel : UserSummaryModel
    {
        public UserAccountModel Account { get; set; }
    }
}
