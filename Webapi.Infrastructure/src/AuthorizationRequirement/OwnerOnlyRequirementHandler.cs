using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Webapi.Business.src.Dtos;


namespace Webapi.Infrastructure.src.AuthorizationRequirement
{
    public class OwnerOnlyRequirement : IAuthorizationRequirement
    {

    }

    public class OwnerOnlyRequirementHandler : AuthorizationHandler<OwnerOnlyRequirement, OrderReadDto>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerOnlyRequirement requirement, OrderReadDto resource)
        {
            var authenticatedUser = context.User;
            var userIds = authenticatedUser.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            if (resource.UserId.ToString() == userIds)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }

    }
}