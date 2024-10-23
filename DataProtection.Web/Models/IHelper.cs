using Microsoft.AspNetCore.DataProtection;

namespace DataProtection.Web.Models
{
    public interface IHelper : IDataProtectionProvider
    {
       new IDataProtector CreateProtector(string purpose);
    }
}
