namespace DripChipProject.Models
{
    public class AccountDTO
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string email { get; set; }
        public AccountDTO(Account account)
        {
            id = account.Id;
            lastName = account.LastName;
            firstName = account.FirstName;
            email = account.Email;
        }
    }
}
