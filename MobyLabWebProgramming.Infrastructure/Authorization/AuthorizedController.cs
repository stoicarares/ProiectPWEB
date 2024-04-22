﻿using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Enums;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Infrastructure.Authorization;

/// <summary>
/// This abstract class is used as a base class for controllers that need to get current information about the user from the database.
/// </summary>
public abstract class AuthorizedController : ControllerBase
{
    private UserClaims? _userClaims;
    protected readonly IUserService UserService;

    protected AuthorizedController(IUserService userService) => UserService = userService;

    /// <summary>
    /// This method extracts the claims from the JWT into an object.
    /// It also caches the object if used a second time.
    /// </summary>
    protected UserClaims ExtractClaims()
    {
        if (_userClaims != null)
        {
            return _userClaims;
        }

        var enumerable = User.Claims.ToList();
        var userId = enumerable.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => Guid.Parse(x.Value)).FirstOrDefault();
        var email = enumerable.Where(x => x.Type == ClaimTypes.Email).Select(x => x.Value).FirstOrDefault();
        var name = enumerable.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault();
        var roleClaim = enumerable.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        UserRoleEnum? role;

        if (string.IsNullOrEmpty(roleClaim))
        {
            role = null;
        }
        else
        {
            role = UserRoleEnum.ParseOrNull(roleClaim); // Assuming FromValueOrDefault is a method in your smart enum to convert string value to enum
            if (role == null)
            {
                // Handle invalid role claim value
                throw new InvalidOperationException($"Invalid role claim value: {roleClaim}");
            }
        }
        _userClaims = new(userId, name, email, role);

        return _userClaims;
    }

    /// <summary>
    /// This method also gets the currently logged user information from the database to provide more information to authorization verifications.
    /// </summary>
    protected Task<ServiceResponse<UserDTO>> GetCurrentUser() => UserService.GetUser(ExtractClaims().Id);
}
