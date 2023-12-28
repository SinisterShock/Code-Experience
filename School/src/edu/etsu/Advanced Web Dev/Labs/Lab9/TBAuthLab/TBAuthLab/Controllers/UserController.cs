using Humanizer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using TBAuthLab.Models.Entities;
using TBAuthLab.Models.ViewModels;
using TBAuthLab.Services;

namespace TBAuthLab.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IRoleRepository _roleRepo;
        public UserController(IUserRepository userRepo, IRoleRepository roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userRepo.ReadAllAsync();
            var userList = users
            .Select(u => new UserListVM
            {
                Email = u.Email,
                Username = u.UserName,
                NumberOfRoles = u.Roles.Count,
                RoleNames = string.Join(",", u.Roles.ToArray())
            });
            return View(userList);
        }

        public async Task<IActionResult> AssignRole([Bind(Prefix = "Id")] string username)
        {
            var user = await _userRepo.ReadByUsernameAsync(username);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var allRoles = _roleRepo.ReadAll().ToList();
            var allRoleNames = allRoles.Select(r => r.Name);
            var rolesNotThere = allRoleNames.Except(user.Roles);
            ViewData["User"] = user;
            return View(rolesNotThere);
        }

        public async Task<IActionResult> ShowRoles(string userName)
        {
            ApplicationUser? user = await _userRepo.ReadByUsernameAsync(userName);
            StringBuilder builder = new();
            foreach (var roleName in user.Roles)
            {
                builder.Append(roleName + " ");
            }
            return Content($"UserName: {user.UserName} Roles: {user.Roles}");
        }

        public async Task<IActionResult> AssignTheRole(string userName, string roleName)
        {
            var user = await _userRepo.AssignRoleAsync(userName, roleName);
            return RedirectToAction("Index");
        }
    }
}
