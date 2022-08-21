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
    public class KisilerController : ControllerBase
    {
        private readonly IKisilerRepository _kisilerRepository;

        public KisilerController(IKisilerRepository kisilerRepository)
        {
            _kisilerRepository = kisilerRepository;
        }

        // GET: api/Kisiler
        [HttpGet]
        public async Task<IEnumerable<Kisiler>> Get()
        {
            var kisiler = await _kisilerRepository.GetKisiler();
            return kisiler;
        }


        // GET: api/Kisiler/5
        [HttpGet("{id}", Name = "GetKisiler")]
        public async Task<Kisiler> Get(int id)
        {
            var kisi = await _kisilerRepository.GetKisi(id);
            return kisi;
        }

        // POST: api/Kisiler
        [HttpPost]
        public string Post(Kisiler kisi)
        {
            string sonuc = "Kayıt eklenemedi";
            if (kisi != null)
            {
                Kisiler dto = new Kisiler();
                dto.Ad = kisi.Ad;
                dto.Firma = kisi.Firma;
                dto.Soyad = kisi.Soyad;
                dto.UUID = kisi.UUID;
                sonuc = _kisilerRepository.AddKisi(kisi);
            }
            return sonuc;
        }

        // PUT: api/Kisiler/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var sonuc = _kisilerRepository.DeleteKisi(id);
            return sonuc;
        }
    }
}
