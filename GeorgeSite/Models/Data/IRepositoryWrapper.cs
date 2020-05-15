using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgeSite.Models.Data
{
    public interface IRepositoryWrapper
    {
        IItemRepository ItemRepository { get;}
        IUserRepository UserRepository { get;}
        ITransactionRepository TransactionRepository { get;}
        IEmailRepository EmailRepository { get;}

    }
}
