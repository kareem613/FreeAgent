using FreeAgent.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeAgent
{
    public class StatementClient : BaseClient
    {
        private FreeAgentClient freeAgentClient;

        public StatementClient(FreeAgentClient freeAgentClient): base(freeAgentClient)
        {
            this.freeAgentClient = freeAgentClient;
        }

        public void Put(Statement statement)
        {
            var request = CreateBasicRequest(RestSharp.Method.POST, "/statement", "bank_transactions");
            request.AddParameter("bank_account", statement.BankAccountURI,  RestSharp.ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json;
            dynamic data = new ExpandoObject();
            var bts = new List<dynamic>();
            foreach(var bt in statement.BankTransactions)
            {
                dynamic t = new ExpandoObject();
                t.amount = bt.amount;
                t.dated_on = bt.dated_on;
                t.description = bt.description;
                bts.Add(t);
            }
            data.statement = bts;
            request.AddBody(data);
            var response = Client.Execute(request);

        }
    }
}
