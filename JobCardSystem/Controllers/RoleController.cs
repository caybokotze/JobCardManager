using System.Collections.Generic;
using System.Data.Entity;
using JobCardSystem.BusinessLogic;
using JobCardSystem.Core.Domain;
using JobCardSystem.Models;
using JobCardSystem.Persistence;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobCardSystem.Controllers
{
    public class RoleController : ApplicationBaseController
    {
        private readonly ApplicationDbContext _context;

        private ApplicationRoleManager _roleManager;

        public RoleController()
        { 
            //Can't Implement Repository Pattern for Identity Related Classes.
            _context = new ApplicationDbContext();
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>(); }
            private set { _roleManager = value; }
        }

        // GET: Role

        public ActionResult AssignRole(string id)
        {
            if (id != null)
            {
                var user = _context.Users.SingleOrDefault(s => s.Id == id);
                EditUserViewModel evm = new EditUserViewModel();
                evm.Name = user.Name;
                evm.Surname = user.Surname;
                evm.Email = user.Email;
                evm.AreaId = user.AreaId;
                evm.Areas = _context.Areas.ToList();
                evm.Roles = _context.Roles.ToList();
                //Role here:
                return View(evm);
            }
            return View();
        }

        [HttpPost]
        public ActionResult AssignRole(EditUserViewModel user)
        {
            var appUser = new ApplicationUser();
            appUser.AreaId = user.AreaId;
            var role = _context.Roles.SingleOrDefault(s => s.Id == user.RoleId);
            List<ApplicationUser> users = _context.Users.Include(i => i.Roles).ToList();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            UserManager.AddToRole(user.Id, role.Name);
            return RedirectToAction("Index");

        }

        public ActionResult StaffList()
        {
            var list = _context.Users.ToList();
            return View(list);
        }

        public ActionResult Index()
        {

            var list = _context.Roles.ToList();
            var roleVmList = ListMapper.RoleMapper(list);
            return View(roleVmList);
        }

        public bool IsAdminUser()
        {
            if (!User.Identity.IsAuthenticated) return false;
            try
            {
                var user = User.Identity;
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].Equals("Admin"))
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch
            {
                return false;
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!IsAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!IsAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            _context.Roles.Add(role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }

    
}