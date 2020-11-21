using System.Collections.Generic;
using Payment.Models;

namespace Payment.Repositories
{
    public interface IPaymentRepo
    {
        bool SaveChanges();

        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int id);
        void CreateTransaction(Transaction obj);
        void DeleteTransaction(Transaction obj);
    }
}