using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialTips.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string BlogsEndpoint = $"{Prefix}/blogs";
        public static readonly string ChartsEndpoint = $"{Prefix}/charts";
        public static readonly string CommunitysEndpoint = $"{Prefix}/communitys";
        public static readonly string FinancialPlanningsEndpoint = $"{Prefix}/financialplannings";
        public static readonly string TipsEndpoint = $"{Prefix}/tips";
        public static readonly string InsightsEndpoint = $"{Prefix}/insights";
        public static readonly string CustomersEndpoint = $"{Prefix}/customers";
        public static readonly string AccountsEndpoint = $"{Prefix}/accounts";


    }
}
