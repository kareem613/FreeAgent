using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeAgent.Models
{
    //https://api.freeagent.com/v2/bank_transactions/statement

    public class Statement
    {
        public IEnumerable<BankTransaction> BankTransactions { get; private set; }
        
        public Statement()
        {
            BankTransactions = new List<BankTransaction>();
        }

        public void AddBankTransaction(BankTransaction transaction)
        {
            ((List<BankTransaction>)BankTransactions).Add(transaction);
        }

        public class StatementWrapper
        {
            public StatementWrapper()
            {

                statement = null;
            }
            public Statement statement { get; set; }

        }

        public class StatementsWrapper
        {
            public StatementsWrapper()
            {
                users = new List<User>();
            }

            public List<User> users { get; set; }
        }
    }
}
