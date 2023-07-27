using CrudOperationInNetCore.Interfaces;
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
    

        private readonly IBrandRepository _brandRepository ;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository ;
        }

       
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {

            Array array = (Array)_brandRepository.GetBrands();

            if(array.Length == 0) 
            { 
                return NotFound();
            }
            return Ok(array); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {

            Brand brand = _brandRepository.GetBrandById(id);



            if ( brand == null)
            {
                return NotFound();
            }
            

            return brand;
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {

            return (Brand)_brandRepository.PostBrand(brand);


        }

        [HttpPut]

        public async Task<ActionResult<Brand>> PutBrand(int id, Brand brand)
        {
          
           var brandCreated = _brandRepository.PutBrand(id, brand);

           if (brandCreated == null)
            {
                return NotFound();
            }

          

            return brandCreated;


        }

       

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBrand(int id)
        {
            

            var brand = _brandRepository.DeleteBrand(id);
            if (brand == null)
                return NotFound();

            return Ok();




        }


    }
}
