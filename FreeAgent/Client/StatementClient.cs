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

        //public override string ResouceName => "bank_transactions";

        public void Put(Statement statement)
        {
            var request = CreateBasicRequest(RestSharp.Method.POST, "/statement", "bank_transactions");
            //request.AddParameter("resource", "bank_transactions/statement", RestSharp.ParameterType.UrlSegment);
            request.AddParameter("bank_account", "https://api.freeagent.com/v2/bank_accounts/425295",  RestSharp.ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json;
            dynamic data = new ExpandoObject();
            var bts = new List<BankTransaction>();
            foreach(var bt in statement.BankTransactions)
            {
                dynamic t = new ExpandoObject();
                t.amount = bt.amount;
                t.dated_on = bt.dated_on;
                t.description = bt.description;
                bts.Add(t);
            }
            request.AddBody(data);
            //request.AddParameter("Content-Type", "application/octet-stream", ParameterType.HttpHeader);
            //string test = "2020-01-16,TESTEST,30.99";
            //var bytes = Encoding.ASCII.GetBytes(test);
            //request.AddFile("filenamet.csv", bytes,"filename.csv", "application/octet-stream");
            var response = Client.Execute(request);

        }
    }
}
