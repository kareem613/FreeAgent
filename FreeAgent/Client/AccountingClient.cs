using System;
using System.Collections.Generic;
using RestSharp;

namespace FreeAgent
{
	public class AccountingClient : BaseClient
	{
		public AccountingClient(FreeAgentClient client) : base(client) {}

		public override string ResouceName
		{
			get
			{
				return "accounting";
			}
		}


		public List<TrialBalanceSummary> TrialBalanceSummary(DateTime date)
		{
            var request = CreateBasicRequest(Method.GET, "/trial_balance/summary?per_page=50&to_date=" + date.ToString("yyyy-MM-dd"));
			var response = Client.Execute<TrialBalanceSummaryWrapper>(request);

			if (response != null) return response.trial_balance_summary;

			return null;

		}

        public List<TrialBalanceSummary> TrialBalanceSummary()
		{
            return TrialBalanceSummary(DateTime.Now);
        }
       

	}
}

