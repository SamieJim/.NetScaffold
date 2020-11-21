using System.Collections.Generic;
using AutoMapper;
using Payment.Repositories;
using Payment.Models;
using Microsoft.AspNetCore.Mvc;
using Payment.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace Payment.Controllers
{

    [Route("api/transaction")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepo _repository;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
       
        [HttpGet]
        public ActionResult <IEnumerable<TransactionReadDTO>> GetAllTransactions()
        {
            var transactionItems = _repository.GetAllTransactions();

            return Ok(_mapper.Map<IEnumerable<TransactionReadDTO>>(transactionItems));
        }

        [HttpGet("{id}", Name="GetTransactionById")]
        public ActionResult <TransactionReadDTO> GetTransactionById(int id)
        {
            var transactionItem = _repository.GetTransactionById(id);
            if(transactionItem != null)
            {
                return Ok(_mapper.Map<TransactionReadDTO>(transactionItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateTransaction(TransactionCreateDTO obj)
        {
            var transactionModel = _mapper.Map<Transaction>(obj);
            _repository.CreateTransaction(transactionModel);
            _repository.SaveChanges();

            var transactionReadDto = _mapper.Map<TransactionReadDTO>(transactionModel);
            return CreatedAtRoute(nameof(GetTransactionById), new {Id = transactionReadDto.Id}, transactionReadDto);      
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTransaction(int id)
        {
            var transactionModelFromRepo = _repository.GetTransactionById(id);
            if(transactionModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteTransaction(transactionModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
        
    }
}