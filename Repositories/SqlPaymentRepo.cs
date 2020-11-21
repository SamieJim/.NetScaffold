using System;
using System.Collections.Generic;
using System.Linq;
using Payment.Models;

namespace Payment.Repositories
{
    public class SqlPaymentRepo : IPaymentRepo
    {
        private readonly PaymentContext _context;

        public SqlPaymentRepo(PaymentContext context)
        {
            _context = context;
        }

        public void CreateTransaction(Transaction obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            _context.Transaction.Add(obj);
        }

        public void DeleteTransaction(Transaction obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Transaction.Remove(obj);
        }

        public IEnumerable<Transaction> GetAllTransaction()
        {
            return _context.Transaction.ToList();
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public Transaction GetTransactionById(int id)
        {
            return _context.Transaction.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}