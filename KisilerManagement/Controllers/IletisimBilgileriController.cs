using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KisilerManagement.Models;
using KisilerManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KisilerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IletisimBilgileriController : ControllerBase
    {
        private readonly IIletisimBilgileriRepository _iletisimBilgileriRepository;

        public IletisimBilgileriController(IIletisimBilgileriRepository iletisimBilgileriRepository)
        {
            _iletisimBilgileriRepository = iletisimBilgileriRepository;
        }

        // GET: api/IletisimBilgileri
        [HttpGet]
        public async Task<IEnumerable<IletisimBilgileri>> Get()
        {
            var iletisim = await _iletisimBilgileriRepository.GetIletisimBilgileri();
            return iletisim;
        }

        // GET: api/IletisimBilgileri/5
        [HttpGet("{id}", Name = "GetIletisim")]
        public async Task<IletisimBilgileri> Get(int id)
        {
            var iletisim = await _iletisimBilgileriRepository.GetIletisimBilgileriById(id);
            return iletisim;
        }

        // POST: api/IletisimBilgileri
        [HttpPost]
        public string Post(IletisimBilgileri iletisim)
        {
            string sonuc = "Kayıt eklenemedi";
            if (iletisim != null)
            {
                IletisimBilgileri dto = new IletisimBilgileri();
                dto.KisiID = iletisim.KisiID;
                dto.BilgiTipiID = iletisim.BilgiTipiID;
                dto.BilgiIcerigi = iletisim.BilgiIcerigi;
                sonuc = _iletisimBilgileriRepository.AddIletisimBilgileri(iletisim);
            }
            return sonuc;
        }

        // PUT: api/IletisimBilgileri/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var sonuc = _iletisimBilgileriRepository.DeleteIletisim(id);
            return sonuc;
        }

        [HttpGet("kisiId/{id}", Name = "GetKisiIletisimBilgileri")]
        public async Task<IEnumerable<IletisimBilgileri>> GetKisiIletisimBilgileri(int id)
        {
            var iletisim = await _iletisimBilgileriRepository.KisiBazliIletisimBilgileri(id);
            return iletisim;
        }
    }
}
