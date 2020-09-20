using PierreLidholm.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace PierreLidholm.Core.Controllers
{
    public class ContactController : SurfaceController
    {
        public ActionResult RenderContactForm() 
        {
            var vm = new ContactFormViewModel();
            return PartialView("~/Views/Partials/Contactform.cshtml", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HandleContactForm(ContactFormViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("Fel", "Kolla så att allt i formen är korrekt.");
                return CurrentUmbracoPage();
            }
            var contactForms = Umbraco.ContentAtRoot().DescendantsOrSelfOfType("contactForms").FirstOrDefault();

            if(contactForms != null)
            {
                var newContact = Services.ContentService.Create("Contact", contactForms.Id, "contactForm");
                newContact.SetValue("contactName", vm.Name);
                newContact.SetValue("contactEmail", vm.Email);
                newContact.SetValue("contactSubject", vm.Subject);
                newContact.SetValue("contactComments", vm.Comnment);
                Services.ContentService.SaveAndPublish(newContact);
            }

            TempData["status"] = "OK";

            return RedirectToCurrentUmbracoPage();
        }
    }

   
}
