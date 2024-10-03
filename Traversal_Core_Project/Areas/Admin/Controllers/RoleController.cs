using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal_Core_Project.Areas.Admin.Models;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(Create_Role_VM model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new()
                {
                    Name = model.RoleName
                };

                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return Redirect("/Admin/Role/Index/");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {

            var role = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(role);
            return Redirect("/Admin/Role/Index/");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var values = await _roleManager.FindByIdAsync(id.ToString());
            Update_Role_VM vm = new()
            {
               Id = values.Id,
               RoleName = values.Name,
               NormalizedName = values.NormalizedName,
               ConcurrencyStamp = values.ConcurrencyStamp
            };
           
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(Update_Role_VM model)
        {
            AppRole appRole = new()
            {
                Id = model.Id,
                Name = model.RoleName,
                ConcurrencyStamp = model.ConcurrencyStamp,
                NormalizedName = model.NormalizedName
            };
            var result = await _roleManager.UpdateAsync(appRole);
            if (result.Succeeded)
            {
                return Redirect("/Admin/Role/Index/");

            }
            return View(model);
        }

        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            TempData["UserId"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            List<Role_Assign_VM> role_Assign_VMs = new();

            foreach (var item in roles)
            {
                Role_Assign_VM vm = new()
                {
                    RoleId = item.Id,
                    RoleName = item.Name,
                    RoleExists = userRoles.Contains(item.Name)
                };

                role_Assign_VMs.Add(vm);
            }


            return View(role_Assign_VMs);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<Role_Assign_VM> model)
        {
            var userId = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

            foreach (var item in model)
            {
                if (item.RoleExists)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return Redirect("/Admin/Role/UserList/");

        }

    }
}
