using DripChipProject.Models;

namespace DripChipProject.Models.ResponseModels
{
    public class AccountRegistrationDTO
    {

        public string firstName { get; set; }
        public string lastName { get; set; }

        public string email { get; set; }
        public string password { get; set; }

    }
}
