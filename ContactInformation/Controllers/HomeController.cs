using ContactInformation.Helper;
using ContactInformation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContactInformation.Controllers
{
    public class HomeController : Controller
    {
        ContactAPI contanctAPI = new ContactAPI();

        public async Task<IActionResult> Index()
        {
            List<ContactViewModel> contacts = new List<ContactViewModel>();
            HttpClient client = contanctAPI.Initial();
            HttpResponseMessage res = await client.GetAsync("api/contacts");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                contacts = JsonConvert.DeserializeObject<List<ContactViewModel>>(results);
            }

            return View(contacts);
        }


        public async Task<IActionResult> Details(int id)
        {
            var contact = new ContactViewModel();
            HttpClient client = contanctAPI.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/contacts/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                contact = JsonConvert.DeserializeObject<ContactViewModel>(results);
            }

            return View(contact);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactViewModel contact)
        {

            HttpClient client = contanctAPI.Initial();

            var postTask = client.PostAsJsonAsync<ContactViewModel>($"api/contacts", contact);
            postTask.Wait();

            var res = postTask.Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(contact);
        }


        //[HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = new ContactViewModel();
            HttpClient client = contanctAPI.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/contacts/{id}");

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id)
        {

            var contact = new ContactViewModel();
            HttpClient client = contanctAPI.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/contacts/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                contact = JsonConvert.DeserializeObject<ContactViewModel>(results);
            }

            return View(contact);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContactViewModel contact)
        {
            ContactViewModel contactViewModel = new ContactViewModel();
            if (ModelState.IsValid)
            {

                HttpClient client = contanctAPI.Initial();
                var json = JsonConvert.SerializeObject(contact);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"api/contacts/{id}", content);

                string apiResponse = response.Content.ReadAsStringAsync().Result;
                contactViewModel = JsonConvert.DeserializeObject<ContactViewModel>(apiResponse);
            }
            return View(contactViewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
