using ContactInformationService.Models;
using ContactInformationService.Models.EFCore;

namespace ContactInformationService.Data.EFCore
{
    public class EfCoreContactRepository : EfCoreRepository<Contact, MyMDBContext>
    {
        public EfCoreContactRepository(MyMDBContext context) : base(context)
        {

        }
        // We can add new methods specific to the movie repository here in the future
    }
}
