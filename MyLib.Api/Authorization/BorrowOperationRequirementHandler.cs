using Microsoft.AspNetCore.Authorization;
using MyLib.Api.Entities;
using System.Security.Claims;

namespace MyLib.Api.Authorization
{
    public class BorrowOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Borrow>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Borrow resource)
        {
            var userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            if(resource.BorrowerId == userId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
