using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace NET_6_Flashing_AuthorizeView.Shared
{
    public static class Requirements
    {
        public class TaskDelayRequirement : IAuthorizationRequirement
        {
        }

        public class InstantRequirement : IAuthorizationRequirement
        {
        }
    }

    public static class Handlers
    {
        public class TaskDelayHandler : AuthorizationHandler<Requirements.TaskDelayRequirement>
        {
            protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, Requirements.TaskDelayRequirement requirement)
            {
                await Task.Delay(1);
                context.Succeed(requirement);
            }
        }

        public class InstantHandler : AuthorizationHandler<Requirements.InstantRequirement>
        {
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, Requirements.InstantRequirement requirement)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
        }
    }
}
