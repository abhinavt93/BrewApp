using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrewApp.Models;
using BrewApp.DTOs;
using AutoMapper;

namespace BrewApp.Controllers.API
{
    public class KegsAPIController : ApiController
    {
        private ApplicationDbContext _context;


        public KegsAPIController()
        {
            _context = new ApplicationDbContext();
        }

        //[HttpGet]
        //public IEnumerable<KegDTO> GetKeg()
        //{
        //    return _context.Keg.ToList().Select(Mapper.Map<Keg, KegDTO>);
        //}

        [HttpGet]
        public IHttpActionResult GetKeg()
        {
            var Temp = _context.Kegs
                .Join(
                _context.Customers,
                keg => keg.CurrentLocation,
                customer => customer.CustomerID.ToString(),
                (keg, customer) => new
                {
                    KegID = keg.KegID,
                    KegNumber = keg.KegNumber,
                    CurrentLocation = customer.CustomerName + " (" + customer.CustomerID + ")",
                    LastUpdatedAt = keg.LastUpdatedAt,
                    CreatedAt = keg.CreatedAt,
                    PreviousLocation = keg.PreviousLocation
                })
                .Join(
                _context.Customers,
                keg => keg.PreviousLocation,
                customer => customer.CustomerID.ToString(),
                (keg, customer) => new
                {
                    KegID = keg.KegID,
                    KegNumber = keg.KegNumber,
                    CurrentLocation = keg.CurrentLocation,
                    LastUpdatedAt = keg.LastUpdatedAt,
                    CreatedAt = keg.CreatedAt,
                    PreviousLocation = customer.CustomerName + " (" + customer.CustomerID + ")"
                })
                .ToList();

            return Ok(Temp);

        }

        //[HttpGet]
        //public IHttpActionResult GetKeg(int KegID)
        //{
        //    var keg = _context.Keg.SingleOrDefault(e => e.KegID == KegID);

        //    if (keg == null)
        //        NotFound();

        //    return Ok(Mapper.Map<Keg, KegDTO>(keg));
        //}

        

        [HttpGet]
        public KegDTO GetKeg(int KegID)
        {
            var keg = _context.Kegs.SingleOrDefault(e => e.KegID == KegID);

            if (keg == null)
                NotFound();

            return Mapper.Map<Keg, KegDTO>(keg);
        }

        [HttpPost]
        public int CreateKeg(KegDTO kegDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var keg = Mapper.Map<KegDTO, Keg>(kegDTO);

            _context.Kegs.Add(keg);
            _context.SaveChanges();

            kegDTO.KegID = keg.KegID;

            return keg.KegID;
        }

        //[HttpPost]
        //public IHttpActionResult CreateKeg(KegDTO kegDTO)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    var keg = Mapper.Map<KegDTO, Keg>(kegDTO);

        //    _context.Keg.Add(keg);
        //    _context.SaveChanges();

        //    kegDTO.KegID = keg.KegID;

        //    return Created(new Uri(Request.RequestUri + "/" + keg.KegID), kegDTO);
        //}

        [AcceptVerbs("PUT","DELETE")]
        [HttpPut]
        public void UpdateKeg(int id,KegDTO kegDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var KeginDB = _context.Kegs.SingleOrDefault(c => c.KegID == id);

            if (KeginDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            kegDTO.KegID = id;
            kegDTO.PreviousLocation = KeginDB.CurrentLocation;
            kegDTO.CreatedAt = KeginDB.CreatedAt;

            Mapper.Map(kegDTO, KeginDB);

            _context.SaveChanges();
        }

        [HttpDelete, Route("{id}")]
        public void DeleteKeg(int id)
        {
            var KeginDB = _context.Kegs.SingleOrDefault(c => c.KegID == id);

            if (KeginDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Kegs.Remove(KeginDB);

            _context.SaveChanges();

        }
    }
}
