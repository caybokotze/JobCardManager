
using System.Web.Mvc;
using JobCardSystem.Core;

namespace JobCardSystem.Controllers
{
    [Authorize]
    public class SignatureController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SignatureController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Create(int? id)
        {
            return View("~/Views/Signature/View.cshtml");
        }

        public ActionResult Index()
        {
            var list = _unitOfWork.ApplicationUserSignatures.GetSignaturesWithApplicationUsers();
            return View(list);
        }

        public ActionResult Delete(int? id)
        {
            var signature = _unitOfWork.CustomerSignatures.Get((int)id);
            _unitOfWork.CustomerSignatures.Remove(signature);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }


    }


    
}