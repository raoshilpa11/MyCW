using CompanyMVC.Models;
using CompanyMVC.ViewModel;
using System.Web.Mvc;

namespace CompanyMVC.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company  
        public ActionResult Index()
        {
            CompanyAPIRequest CC = new CompanyAPIRequest();
            ViewBag.listCompanies = CC.findAll();

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(CompanyViewModel cvm)
        {
            CompanyAPIRequest CC = new CompanyAPIRequest();
            CC.Create(cvm.company);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            CompanyAPIRequest CC = new CompanyAPIRequest();
            CC.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CompanyAPIRequest CC = new CompanyAPIRequest();
            CompanyViewModel CVM = new CompanyViewModel();
            CVM.company = CC.find(id);
            return View("Edit", CVM);
        }

        [HttpPost]
        public ActionResult Edit(CompanyViewModel CVM)
        {
            CompanyAPIRequest CC = new CompanyAPIRequest();
            CC.Edit(CVM.company);
            return RedirectToAction("Index");
        }
    }
}