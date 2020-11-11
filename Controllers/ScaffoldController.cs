using System.Collections.Generic;
using AutoMapper;
using Scaffolder.Repositories;
using Scaffolder.Models;
using Microsoft.AspNetCore.Mvc;

namespace Scaffolder.Controllers
{

    [Route("api/scaffold")]
    [ApiController]
    public class ScaffoldController : ControllerBase
    {
        private readonly IScaffolderRepo _repository;

        public ScaffoldController(IScaffolderRepo repository, IMapper mapper)
        {
            _repository = repository;
        }
       
        [HttpGet]
        public ActionResult <IEnumerable<Scaffold>> GetAllCommmands()
        {
            var scaffoldItems = _repository.GetAllScaffold();

            return Ok(scaffoldItems);
        }

        [HttpGet("{id}", Name="GetScaffoldById")]
        public ActionResult <Scaffold> GetScaffoldById(int id)
        {
            var scaffoldItem = _repository.GetScaffoldById(id);
            if(scaffoldItem != null)
            {
                return Ok(scaffoldItem);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateScaffold(Scaffold obj)
        {
            _repository.CreateScaffold(obj);
            _repository.SaveChanges();
            
            return CreatedAtRoute(nameof(GetScaffoldById), new {Id = obj.Id}, obj);      
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteScaffold(int id)
        {
            var scaffoldModelFromRepo = _repository.GetScaffoldById(id);
            if(scaffoldModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteScaffold(scaffoldModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }


        [HttpPut("{id}")]
        public ActionResult UpdateScaffold(int id, Scaffold scaffold)
        {
            throw new System.NotImplementedException();
        }
        
    }
}