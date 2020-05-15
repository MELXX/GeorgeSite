using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgeSite.Models.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext AppDbContext;
        private IdentityDbContext IdentityDbContext;
        private IItemRepository itemRepository;
        private ITransactionRepository transactionRepository;
        private IEmailRepository emailRepository;
        private IUserRepository userRepository;



        public IItemRepository ItemRepository 
        {
            get
            {
                if (itemRepository == null)
                {
                    itemRepository = new ItemRepository(AppDbContext);
                }
                return itemRepository;
            }
        }
        public IUserRepository UserRepository 
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(IdentityDbContext);
                }
                return userRepository;
            }
        }
        public ITransactionRepository TransactionRepository
        {
            get
            {
                if (transactionRepository == null)
                {
                    transactionRepository = new TransactionRepository(AppDbContext);
                }
                return transactionRepository;
            }
        }
        public IEmailRepository EmailRepository
        {
            get
            {
                if (emailRepository == null)
                {
                    emailRepository = new EmailRepository(AppDbContext);
                }
                return emailRepository;
            }
        }
        public RepositoryWrapper(AppDbContext appDbContext, IdentityDbContext identityDbContext)
        {
            AppDbContext = appDbContext;
            IdentityDbContext = identityDbContext;
        }
    }
}
