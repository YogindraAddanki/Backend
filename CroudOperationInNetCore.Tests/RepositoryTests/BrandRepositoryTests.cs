using CrudOperationInNetCore.Models;
using CrudOperationInNetCore.Repositories;
using FluentAssertions;
using FluentAssertions.Equivalency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroudOperationInNetCore.Tests.RepositoryTests
{
    public class BrandRepositoryTests
    {
       

        private async Task<BrandContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<BrandContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var DataBaseContext = new BrandContext(options);
            DataBaseContext.Database.EnsureCreated();

           



            if(await DataBaseContext.Brands.CountAsync() <= 0)
            {

                for (var i = 0; i < 10; i++)
                {
                    DataBaseContext.Brands.Add(

                         new Brand()
                         {

                             Name = "Hello",

                             Category = "TYpe",

                             IsActive = 1,

                             Orders = new List<Order>()

                             {
                                new Order() { Name = "Electric" , BrandId = 1}
                             }
                         }



                            );

                    await DataBaseContext.SaveChangesAsync();

                }

            }

            return DataBaseContext;


        }

        [Fact]

        public async void BrandRepository_GetBrand_ReturnsBrand()
        {
            //Arrange
            var id = 1;
            var dbContext = await GetDbContext();
            var BrandRepository = new BrandRepository(dbContext);

            //Act
            var result = BrandRepository.GetBrandById(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Brand>();
        }

        [Fact]
        public async void BrandRepository_GetBrands_ReturnsBrands()
        {
            //Arrange
            
            var dbContext = await GetDbContext();
            var BrandRepository = new BrandRepository(dbContext);

            //Act
            var result = BrandRepository.GetBrands().ToArray();

            //Assert
            result.Should().NotBeNull();
            //result.Should().BeOfType<Brand>();
        }




    }
}
