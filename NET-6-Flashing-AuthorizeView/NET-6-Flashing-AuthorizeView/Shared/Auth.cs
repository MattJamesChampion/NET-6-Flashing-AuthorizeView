using Microsoft.AspNetCore.Authorization;
using System.Threading;
using System.Threading.Tasks;

namespace NET_6_Flashing_AuthorizeView.Shared
{
    public static class Requirements
    {
        public class InstantRequirement : IAuthorizationRequirement
        {
        }

        public class ThreadSleepRequirement : IAuthorizationRequirement
        {
        }

        public class TaskDelayRequirement : IAuthorizationRequirement
        {
        }
    }

    public static class Handlers
    {
        public class InstantHandler : AuthorizationHandler<Requirements.InstantRequirement>
        {
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, Requirements.InstantRequirement requirement)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
        }

        public class ThreadSleepHandler : AuthorizationHandler<Requirements.ThreadSleepRequirement>
        {
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, Requirements.ThreadSleepRequirement requirement)
            {
                Thread.Sleep(1);
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
        }

        public class TaskDelayHandler : AuthorizationHandler<Requirements.TaskDelayRequirement>
        {
            protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, Requirements.TaskDelayRequirement requirement)
            {
                await Task.Delay(1);
                context.Succeed(requirement);
            }
        }
    }
}
