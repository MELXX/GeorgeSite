using GeorgeSite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgeSite.Models.Data
{

    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(AppDbContext DbContext) : base(DbContext)
        {
        }
    }

    public class EmailRepository : RepositoryBase<Email>, IEmailRepository
    {
        public EmailRepository(AppDbContext DbContext) : base(DbContext)
        {
        }
    }

    public class UserRepository : IdentityRepositoryBase<User>, IUserRepository
    {
        public UserRepository(IdentityDbContext DbContext) : base(DbContext)
        {
        }
    }

    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext DbContext) : base(DbContext)
        {
        }
    }


}
