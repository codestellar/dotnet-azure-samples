using BlazingPizza.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Controllers{

    [Route("specials")]
    [ApiController]
    public class SpecialsController: Controller{
        
        private readonly PizzaStoreContext _context;
        public SpecialsController(PizzaStoreContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials(){
            return (await _context.Specials.ToListAsync()).OrderByDescending(x => x.BasePrice).ToList();
        }
    }
}
