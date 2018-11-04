using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using System;
using System.Net;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    // ClientModule 
    //  CL-Client list
    //  CC-Client create
    //  CE-Client edit
    //  CD-Client details 
    //  CR-Client remove

    //      On table dbo.AspNetUserClaims (AspNet Identity):
    //          Add row: UserId: f08cd71d-acd3-42cd-8c32-6bd437e5c232
    //                   ClaimType: ClientModule
    //                   ClaimValue: CL,CA,CE,CD,CR (for a person with full access)

    // [Authorize]
    public class RegistryController : Controller
    {
        private readonly IRegistryApplicationService _service;

        public RegistryController(IRegistryApplicationService service)
        {
            _service = service;
        }

        // [ClaimsAuthorize("ClientModule", "CL")]
        public ActionResult Index()
        {
            return View(_service.GetAllActives());
        }

        // [ClaimsAuthorize("ClientModule", "CD")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = _service.GetById(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // [ClaimsAuthorize("ClientModule", "CC")]
        public ActionResult Create()
        {
            return View();
        }

        // [ClaimsAuthorize("ClientModule", "CC")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientDto clientDto)
        {
            if (ModelState.IsValid)
            {
                _service.Add(clientDto);
                return RedirectToAction("Index");
            }

            return View(clientDto);
        }

        // [ClaimsAuthorize("ClientModule", "CE")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clientAddressDto = _service.GetById(id.Value);
            if (clientAddressDto == null)
            {
                return HttpNotFound();
            }
            return View(clientAddressDto);
        }

        // [ClaimsAuthorize("ClientModule", "CE")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientDto clientDto)
        {
            if (ModelState.IsValid)
            {
                _service.Update(clientDto);
                return RedirectToAction("Index");
            }
            return View(clientDto);
        }

        // [ClaimsAuthorize("ClientModule", "CR")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clientDto = _service.GetById(id.Value);
            if (clientDto == null)
            {
                return HttpNotFound();
            }
            return View(clientDto);
        }

        // [ClaimsAuthorize("ClientModule", "CR")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _service.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
