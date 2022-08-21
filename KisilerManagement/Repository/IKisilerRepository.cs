using KisilerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisilerManagement.Repository
{
    public interface IKisilerRepository
    {
        Task<IEnumerable<Kisiler>> GetKisiler();
        string AddKisi(Kisiler kisi);
        Task<Kisiler> GetKisi(int Id);
        string DeleteKisi(int id);
    }
}
