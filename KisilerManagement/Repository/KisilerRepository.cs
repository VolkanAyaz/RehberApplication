using KisilerManagement.Model;
using KisilerManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisilerManagement.Repository
{
    public class KisilerRepository : IKisilerRepository
    {
        private readonly KisilerDbContext _context;

        public KisilerRepository(KisilerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Kisiler>> GetKisiler()
        {
            var list = await _context.Kisiler.ToListAsync();
            return list;
        }
        public async Task<Kisiler> GetKisi(int Id)
        {
            var dto= await _context.Kisiler.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return dto;
        }
        public string AddKisi(Kisiler kisi)
        {
            var xx = _context.Kisiler.Add(kisi);
            var xx11 = _context.SaveChanges();
            return "kayit eklendi";
        }
        public string DeleteKisi(int id)
        {
            var dto = _context.Kisiler.FirstOrDefault(x => x.Id == id);
            _context.Kisiler.Remove(dto);
            _context.SaveChanges();
            return "Kayıt Silindi";
        }
    }
}
