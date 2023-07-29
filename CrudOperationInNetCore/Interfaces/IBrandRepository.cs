using CrudOperationInNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationInNetCore.Interfaces
{
    public interface IBrandRepository 
    {
        IEnumerable<Brand> GetBrands();

        Brand? GetBrandById(int id);

        Brand PostBrand(Brand brand);

        Brand? PutBrand(int id, Brand brand);

        bool BrandAvailable(int id);

        Brand? DeleteBrand(int id);

    }
}
