using AutoMapper;
using BrewApp.DTOs;
using BrewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace BrewApp.Controllers.API
{
    public class RecipeAPIController : ApiController
    {
        private ApplicationDbContext _context;
        public RecipeAPIController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<RecipeMasterDTO> GetRecipes()
        {
            return _context.RecipeMaster.ToList().Select(Mapper.Map<RecipeMaster, RecipeMasterDTO>);
            //return Ok(_context.RecipeMaster.ToList().Select(Mapper.Map<RecipeMaster, RecipeMasterDTO>));
        }

        [HttpPost]
        public int AddRecipe(RecipeMasterDTO RecipeDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var Recipe = Mapper.Map<RecipeMasterDTO, RecipeMaster>(RecipeDTO);

            _context.RecipeMaster.Add(Recipe);
            _context.SaveChanges();

            RecipeDTO.id = Recipe.id;

            return RecipeDTO.id;
        }

        [AcceptVerbs("PUT", "DELETE")]
        [HttpPut]
        public void UpdateRecipe(RecipeMasterDTO RecipeDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var RecipeinDB = _context.RecipeMaster.SingleOrDefault(c => c.id == RecipeDTO.id);

            if (RecipeinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(RecipeDTO, RecipeinDB);

            _context.SaveChanges();
        }
    }
}
