using Microsoft.AspNetCore.Authorization;

namespace NET_6_Flashing_AuthorizeView.Shared
{
    public static class Requirements
    {
        public class TestRequirement : IAuthorizationRequirement
        {
        }
    }

    public static class Handlers
    {
        public class TestHandler : AuthorizationHandler<Requirements.TestRequirement>
        {
            protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, Requirements.TestRequirement requirement)
            {
                await Task.Delay(1);
                context.Succeed(requirement);
            }
        }
    }
}
