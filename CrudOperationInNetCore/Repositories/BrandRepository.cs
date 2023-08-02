using CrudOperationInNetCore.Context;
using CrudOperationInNetCore.Interfaces;
using CrudOperationInNetCore.Models;
using Microsoft.EntityFrameworkCore;


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

        public  Brand? DeleteBrand(int id)
        {
            var b = _dbContext.Brands.Where(c => c.Id == id).FirstOrDefault();

            _dbContext.Brands.Remove(b);

            _dbContext.SaveChanges();


            return b;

        }

        public Brand? GetBrandById(int id)
        {
            var b = _dbContext.Brands.Where(c => c.Id == id).FirstOrDefault();

            return b;
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

        public Brand? PutBrand(int id,Brand brand)
        {

             var b = _dbContext.Brands.Where(c => c.Id ==id).FirstOrDefault();

             if (b!=null)
            {


                b.Name = brand.Name;

                b.Category = brand.Category;

                b.IsActive = brand.IsActive;

                _dbContext.SaveChanges();

                return b;


            }

            return null;

        }
    }
}
