using Hangfire.Dashboard;

namespace devboost.dronedelivery.sb.consumer.api.Filter
{
    public class AuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}