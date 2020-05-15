using GeorgeSite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgeSite.Models.Data
{

    public interface IItemRepository:IRepositoryBase<Item>
    {

    }

    public interface IEmailRepository : IRepositoryBase<Email>
    {

    }

    public interface ITransactionRepository : IRepositoryBase<Transaction>
    {

    }

    public interface IUserRepository : IRepositoryBase<User>
    {

    }
}
