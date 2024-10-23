using Microsoft.AspNetCore.DataProtection;

namespace DataProtection.Web.Models
{
    public class Helper : IHelper
    {
        private readonly IDataProtector _dataProtector;
        public Helper(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("ProductsController");
        }

        public IDataProtector CreateProtector(string purpose)
        {
            return _dataProtector;
        }
    }
}
