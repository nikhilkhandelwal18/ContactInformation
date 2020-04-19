using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactInformationService.Data.EFCore;
using ContactInformationService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactInformationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : MyMDBController<Contact, EfCoreContactRepository>
    {
        public ContactsController(EfCoreContactRepository repository) : base(repository)
        {

        }
    }
}