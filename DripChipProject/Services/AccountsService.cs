using DripChipProject.Models;
using DripChipProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DripChipProject.Models.ResponseModels;

namespace DripChipProject.Services
{
    public class AccountsService : IAccountService
    {
        IDbContextFactory<APIDbContext> contextFactory;
        public AccountsService(IDbContextFactory<APIDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public AccountDTO AddAccount(AccountRegistrationDTO account)
        {
            using var dbContext = contextFactory.CreateDbContext();
            Account dbAccont = new Account();
            dbAccont.firstName = account.firstName;
            dbAccont.lastName = account.lastName;
            dbAccont.email = account.email;
            dbAccont.password = account.password;
            dbContext.Accounts.Add(dbAccont);
            dbContext.SaveChanges();
            AccountDTO acc = new AccountDTO(dbAccont);
            return acc;
        }

        public void DeleteAccount(int id) // Доработать
        {
            using var dbContext = contextFactory.CreateDbContext();
            var accountToDeleting = dbContext.Accounts.First(x =>x.id == id);
            dbContext.Accounts.Remove(accountToDeleting);
            dbContext.SaveChanges();
        }

        public AccountDTO? GetAccount(int id)
        {
            using var dbContext = contextFactory.CreateDbContext();
            if (!dbContext.Accounts.Any(x => x.id == id))
            {
                return null;
            }
            AccountDTO account = new AccountDTO(dbContext.Accounts.First(x => x.id == id));
            return account;
        }

        public Account? GetAccountByEmail(string email)
        {
            using var dbContext = contextFactory.CreateDbContext();
            return dbContext.Accounts.FirstOrDefault(x => x.email == email);
        }

        public AccountDTO[]? SearchAccounts(string? firstName, string? lastName, string? email, int from = 0, int size = 10)
        {
            using var dbContext = contextFactory.CreateDbContext() ;
            var filteredResult = dbContext.Accounts.AsQueryable();
            if (firstName != null)
            {
                filteredResult = filteredResult.Where(x =>x.firstName == firstName);
            }
            if (lastName != null)
            {
                filteredResult = filteredResult.Where(x => x.lastName == lastName);
            }
            if (email != null)
            {
                filteredResult = filteredResult.Where(x => x.email == email);
            }
            if (filteredResult.Count() == 0)
            {
                return null;
            }
            filteredResult = filteredResult.OrderBy(x=> x.id).Skip(from).Take(size);
            List<AccountDTO> accList = new List<AccountDTO>();
            foreach(var account in filteredResult) 
            {
                AccountDTO ac = new AccountDTO(account);
                accList.Add(ac);
            }
            return accList.ToArray();
        }
    }
}
