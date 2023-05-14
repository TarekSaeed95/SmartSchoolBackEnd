using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartSchool.Bl.Helpers;
using SmartSchool.BL.Models;
using SmartSchool.BL.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using JWT.Helpers;
//using JWT.Models;

namespace SmartSchool.BL.Services
{
    #region IAuth
    //public class AuthService : IAuthService
    //{
    //    private readonly UserManager<ApplicationUser> userManager;
    //    private readonly RoleManager<IdentityRole> roleManager;
    //    private readonly JWTC _jwt;
    //    public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager , IOptions<JWTC> jwt)
    //    {
    //        this.userManager = userManager;
    //        this.roleManager = roleManager;
    //        _jwt = jwt.Value;
    //    }
    //    public async Task<AuthModel> RegisterAsync(RegisterModel model)
    //    {
    //        //checked befor registeration if this email is already exists
    //        if (await userManager.FindByEmailAsync(model.Email) is not null)
    //            return new AuthModel { Message = "Email is already exists" };


    //        //checked befor registeration if username is already exists
    //        if (await userManager.FindByNameAsync(model.Username) is not null)
    //            return new AuthModel { Message = "Username is already exists " };

    //        var user = new ApplicationUser
    //        {
    //            UserName = model.Username,
    //            Email = model.Email,
    //            //FirstName = model.FirstName,
    //            //LastName = model.LastName
    //        };

    //        var Result = await userManager.CreateAsync(user, model.Password);

    //        if(!Result.Succeeded)// if registeration failed
    //        {
    //            var errors = string.Empty;
    //            foreach (var error in Result.Errors)
    //            {
    //                errors += $"{error.Description},";
    //            }

    //            return new AuthModel { Message = errors };
    //        }


    //        //if registeration Successded --> assign user to Role ==> make select List and select role from it
    //        //await userManager.AddToRoleAsync(user, "User");

    //        await userManager.AddToRoleAsync(user, model.myRole);

    //        var jwtSecurityToken = await CreateJwtToken(user);

    //        return new AuthModel
    //        {
    //            Email = user.Email,
    //            ExpireOn = jwtSecurityToken.ValidTo,
    //            IsAuthenticated = true,
    //            //Roles = new List<string> { "User" },
    //            Roles = new List<string> { model.myRole },
    //            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
    //            UserName = user.UserName
    //        };

    //    }


    //    public async Task<AuthModel> LoginAsync(LoginModel model)
    //    {
    //        var authModel = new AuthModel();

    //        //check if this email is registered or not
    //        var user = await userManager.FindByEmailAsync(model.Email);

    //        if (user is null || !await userManager.CheckPasswordAsync(user, model.Password))
    //        {
    //            authModel.Message = "Invalid Email or password";
    //            return authModel;
    //        }


    //        var jwtSecurityToken = await CreateJwtToken(user);
    //        var rolesList = await userManager.GetRolesAsync(user);

    //        authModel.IsAuthenticated = true;
    //        authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    //        authModel.Email = user.Email;
    //        authModel.UserName = user.UserName;
    //        authModel.ExpireOn = jwtSecurityToken.ValidTo;
    //        authModel.Roles = rolesList.ToList();

    //        return authModel;
    //    }

    //    public async Task<string> AddRoleAsync(AddRoleModel model)
    //    {
    //        var user = await userManager.FindByIdAsync(model.UserId);

    //        if (user is null || !await roleManager.RoleExistsAsync(model.Role))
    //            return "Invalid Email or password";


    //        if (await userManager.IsInRoleAsync(user, model.Role))
    //            return "User already assigned to this role";

    //        var result = await userManager.AddToRoleAsync(user, model.Role);


    //        return result.Succeeded ? string.Empty : "something wrong";

    //    }


    //    //generate token function
    //    private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
    //    {
    //        var userClaims = await userManager.GetClaimsAsync(user);
    //        var roles = await userManager.GetRolesAsync(user);
    //        var roleClaims = new List<Claim>();

    //        foreach (var role in roles)
    //            roleClaims.Add(new Claim("roles", role));


    //        var claims = new[]
    //        {
    //            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
    //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //            new Claim(JwtRegisteredClaimNames.Email, user.Email),
    //            new Claim("uid", user.Id)
    //        }
    //        .Union(userClaims)
    //        .Union(roleClaims);

    //        var symetricSecuirtyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
    //        var signingCredentials = new SigningCredentials(symetricSecuirtyKey, SecurityAlgorithms.HmacSha256);

    //        var jwtSecurityToken = new JwtSecurityToken(
    //            issuer: _jwt.Issuer,
    //            audience: _jwt.Audience,
    //            claims: claims,
    //            expires: DateTime.Now.AddDays(_jwt.DurationInDays),
    //            signingCredentials: signingCredentials
    //            );

    //        return jwtSecurityToken;

    //    }


    //}
    #endregion

    #region IAUth Identity
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly JWTC _jwt;
        public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWTC> jwt)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _jwt = jwt.Value;
        }
        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            //checked befor registeration if this email is already exists
            if (await userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Message = "Email is already exists" };


            //checked befor registeration if username is already exists
            if (await userManager.FindByNameAsync(model.Username) is not null)
                return new AuthModel { Message = "Username is already exists " };

            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email,
                
                //FirstName = model.FirstName,
                //LastName = model.LastName
            };

            var Result = await userManager.CreateAsync(user, model.Password);

            if (!Result.Succeeded)// if registeration failed
            {
                var errors = string.Empty;
                foreach (var error in Result.Errors)
                {
                    errors += $"{error.Description},";
                }

                return new AuthModel { Message = errors };
            }


            //if registeration Successded --> assign user to Role ==> make select List and select role from it
            //await userManager.AddToRoleAsync(user, "User");

            await userManager.AddToRoleAsync(user, model.myRole);

            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthModel
            {
                Email = user.Email,
                ExpireOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                //Roles = new List<string> { "User" },
                Roles = new List<string> { model.myRole },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName
            };

        }


        public async Task<AuthModel> LoginAsync(LoginModel model)
        {
            var authModel = new AuthModel();

            //check if this email is registered or not
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user is null || !await userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Invalid Email or password";
                return authModel;
            }


            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.UserName = user.UserName;
            authModel.ExpireOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            return authModel;
        }

        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);

            if (user is null || !await roleManager.RoleExistsAsync(model.Role))
                return "Invalid Email or password";


            if (await userManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            var result = await userManager.AddToRoleAsync(user, model.Role);


            return result.Succeeded ? string.Empty : "something wrong";

        }


        //generate token function
        private async Task<JwtSecurityToken> CreateJwtToken(IdentityUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symetricSecuirtyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symetricSecuirtyKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;

        }


    }
    #endregion


}
