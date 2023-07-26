using CrudOperationInNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

namespace CrudOperationInNetCore.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandContext _dbContext ;

        public BrandController(BrandContext dbContext)
        {
            _dbContext = dbContext;
        }

    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {

            if(_dbContext.Brands  == null) 
            { 
                return NotFound();
            }
            return await _dbContext.Brands.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {

            if (_dbContext.Brands == null)
            {
                return NotFound();
            }
            var brand = await _dbContext.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {
            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrand),new {id = brand.Id} , brand);


        }

        [HttpPut]

        public async Task<ActionResult<Brand>> PutBrand(int id, Brand brand)
        {
          

            _dbContext.Entry(brand).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException) {

                if (!BrandAvailable(id))
                {
                    return NotFound();
                }
                else
                    throw;
            }

            return Ok();


        }

        private bool BrandAvailable(int id)
        {
            return (_dbContext.Brands?.Any(x => x.Id == id)).GetValueOrDefault();
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBrand(int id)
        {
            if(_dbContext.Brands == null)
                return NotFound();

            var brand = _dbContext.Brands.FindAsync(id);
            if (brand == null)
                return NotFound();

            _dbContext.Brands.Remove(await brand);

            await _dbContext.SaveChangesAsync();
            return Ok();




        }
    }
}
