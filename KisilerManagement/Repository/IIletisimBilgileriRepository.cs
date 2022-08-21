using KisilerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisilerManagement.Repository
{
    public interface IIletisimBilgileriRepository
    {
        Task<IEnumerable<IletisimBilgileri>> GetIletisimBilgileri();
        string AddIletisimBilgileri(IletisimBilgileri iletisim);
        Task<IletisimBilgileri> GetIletisimBilgileriById(int Id);
        string DeleteIletisim(int id);
    }
}
