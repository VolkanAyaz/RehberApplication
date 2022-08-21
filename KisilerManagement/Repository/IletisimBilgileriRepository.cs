using KisilerManagement.Model;
using KisilerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KisilerManagement.Repository
{
    public class IletisimBilgileriRepository : IIletisimBilgileriRepository
    {
        private readonly KisilerDbContext _context;
        public IletisimBilgileriRepository(KisilerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IletisimBilgileri>> GetIletisimBilgileri()
        {
            var list = await _context.IletisimBilgileri.Include(x=>x.Kisi).Include(x=>x.BilgiTipi).ToListAsync();
            return list;
        }
        public async Task<IletisimBilgileri> GetIletisimBilgileriById(int Id)
        {
            var dto = await _context.IletisimBilgileri.Include(x => x.Kisi).Where(x => x.Id == Id).FirstOrDefaultAsync();
            return dto;
        }
        public string AddIletisimBilgileri(IletisimBilgileri iletisim)
        {
            var xx = _context.IletisimBilgileri.Add(iletisim);
            var xx11 = _context.SaveChanges();
            return "kayit eklendi";
        }
        public string DeleteIletisim(int id)
        {
            var dto = _context.IletisimBilgileri.FirstOrDefault(x => x.Id == id);
            _context.IletisimBilgileri.Remove(dto);
            _context.SaveChanges();
            return "Kayıt Silindi";
        }
        public async Task<IEnumerable<IletisimBilgileri>> KisiBazliIletisimBilgileri(int kisiId)
        {
            var list = await _context.IletisimBilgileri.Include(x => x.Kisi).Include(x => x.BilgiTipi).Where(x => x.KisiID == kisiId).ToListAsync();
            return list;
        }
    }
}
