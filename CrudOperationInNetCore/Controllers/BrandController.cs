using CrudOperationInNetCore.Interfaces;
using CrudOperationInNetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

namespace CrudOperationInNetCore.Controllers
{
   
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandController : ControllerBase
    {
    

        private readonly IBrandRepository _brandRepository ;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository ;
        }


        
        [HttpGet]
        public ActionResult<IEnumerable<Brand>> GetBrands()
        {

            Array array = _brandRepository.GetBrands().ToArray();

            if (array.Length == 0)
            {
                return NotFound();
            }
            return Ok(array);
        }

        [HttpGet("{id}")]
        public ActionResult<Brand> GetBrand(int id)
        {

            Brand? brand = _brandRepository.GetBrandById(id);



            if (brand == null)
            {
                return NotFound();
            }


            return brand;
        }

        [HttpPost]
        public ActionResult<Brand> PostBrand(Brand brand)
        {

            return (Brand)_brandRepository.PostBrand(brand);


        }

        [HttpPut]

        public ActionResult<Brand> PutBrand(int id, Brand brand)
        {

            var brandCreated = _brandRepository.PutBrand(id, brand);

            if (brandCreated == null)
            {
                return NotFound();
            }



            return brandCreated;


        }



        [HttpDelete("{id}")]

        public ActionResult<Brand> DeleteBrand(int id)
        {


            var brand = _brandRepository.DeleteBrand(id);
            if (brand == null)
                return NotFound();

            return Ok(brand);




        }


    }
}
