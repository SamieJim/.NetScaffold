using System.Collections.Generic;
using AutoMapper;
using Scaffolder.Repositories;
using Scaffolder.Models;
using Microsoft.AspNetCore.Mvc;
using Scaffolder.DTOs;

namespace Scaffolder.Controllers
{

    [Route("api/scaffold")]
    [ApiController]
    public class ScaffoldController : ControllerBase
    {
        private readonly IScaffolderRepo _repository;
        private readonly IMapper _mapper;

        public ScaffoldController(IScaffolderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
       
        [HttpGet]
        public ActionResult <IEnumerable<ScaffoldReadDTO>> GetAllScaffolds()
        {
            var scaffoldItems = _repository.GetAllScaffold();

            return Ok(_mapper.Map<IEnumerable<ScaffoldReadDTO>>(scaffoldItems));
        }

        [HttpGet("{id}", Name="GetScaffoldById")]
        public ActionResult <ScaffoldReadDTO> GetScaffoldById(int id)
        {
            var scaffoldItem = _repository.GetScaffoldById(id);
            if(scaffoldItem != null)
            {
                return Ok(_mapper.Map<ScaffoldReadDTO>(scaffoldItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateScaffold(ScaffoldCreateDTO obj)
        {
            var scaffoldModel = _mapper.Map<Scaffold>(obj);
            _repository.CreateScaffold(scaffoldModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<ScaffoldReadDTO>(scaffoldModel);
            return CreatedAtRoute(nameof(GetScaffoldById), new {Id = commandReadDto.Id}, commandReadDto);      
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