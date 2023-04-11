using AutoMapper;
using FunBooksAndVideosForShawBrook.BusinessRules;
using FunBooksAndVideosForShawBrook.Dto;
using FunBooksAndVideosForShawBrook.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideosForShawBrook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IEnumerable<IBusinessRule> _rules;
        private readonly IMapper _mapper;

        public OrdersController(IEnumerable<IBusinessRule> rules, IMapper mapper)
        {
            _rules = rules;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PlaceOrder(OrderDto orderDto)
        {
            PurchaseOrder purchaseOrder;
            try
            {
                //Initialize the AutoMapper
                purchaseOrder = _mapper.Map<PurchaseOrder>(orderDto);

                //check if rule is applicable and execute it one by one
                var ruleResult = new RuleEvaluator(_rules).Execute(purchaseOrder);
                return Ok(ruleResult);
            }
            catch (AutoMapper.AutoMapperMappingException ex)
            {
                return BadRequest("Invalid Order details");
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}