using CrudOperationInNetCore.Interfaces;
using CrudOperationInNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace CrudOperationInNetCore.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly BrandContext _dbContext;

        public BrandRepository( BrandContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool BrandAvailable(int id)
        {

            return (_dbContext.Brands?.Any(x => x.Id == id)).GetValueOrDefault();

        }

        public  Brand DeleteBrand(int id)
        {
            var b = _dbContext.Brands.Where(c => c.Id == id);

            _dbContext.Brands.Remove((Brand)b);

            _dbContext.SaveChanges();


            return (Brand)b;

        }

        public Brand GetBrandById(int id)
        {
            var b = _dbContext.Brands.Where(c => c.Id == id);

            return (Brand)b;
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _dbContext.Brands.ToArray();

        }

        public Brand PostBrand(Brand brand)
        {
            _dbContext.Brands.Add(brand);

            _dbContext.SaveChanges();

            return brand;

        }

        public Brand PutBrand(int id,Brand brand)
        {
             _dbContext.Entry(brand).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }

            catch (DbUpdateConcurrencyException)
            {

                if (!BrandAvailable(id))
                {
                    return null;
                }
                else
                    throw;
            }

            return brand;
        }
    }
}
