
using CrudOperationInNetCore.Controllers;
using CrudOperationInNetCore.Interfaces;
using CrudOperationInNetCore.Models;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroudOperationInNetCore.Tests.ControllerTests
{
    public class BrandControllerTests
    {
        private readonly IBrandRepository _brandRepository;

        public BrandControllerTests()
        {
            _brandRepository = A.Fake<IBrandRepository>();

        }


        [Fact]

        public void BrandController_GetBrand_ReturnBrand()
        {
            //Arrange - What do i need to bring in ?
            var id = 1;
            var brand = A.Fake<Brand>();
            A.CallTo(() => _brandRepository.GetBrandById(id)).Returns(brand);
            var controller = new BrandController(_brandRepository);

            //Access 

            var result = controller.GetBrand(id);

            //Act

            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<Brand>>();

        }


        [Fact]

        public void BrandController_DeleteBrand_ReturnBrand()
        {
            var id = 1;
            var brand = A.Fake<Brand>();
            A.CallTo(() => _brandRepository.DeleteBrand(id)).Returns(brand);
            var controller = new BrandController(_brandRepository);


            var result = controller.DeleteBrand(id);

            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<Brand>>();
        }

        [Fact]

        public void BrandController_PostBrand_ReturnBrand()
        {
            
            var brand = A.Fake<Brand>();
            A.CallTo(() => _brandRepository.PostBrand(brand)).Returns(brand);
            var controller = new BrandController(_brandRepository);


            var result = controller.PostBrand(brand);

            result.Should().NotBeNull();
            result.Should().BeOfType <ActionResult<Brand>>();


        }

        [Fact]

        public void BrandController_GetBrands_ReturnBrands()
        {

            var brand = A.Fake<IEnumerable<Brand>>().ToArray();
            A.CallTo(() => _brandRepository.GetBrands()).Returns(brand);
            var controller = new BrandController(_brandRepository);


            var result = controller.GetBrands();

            result.Should().NotBeNull();
            //result.Should().BeOfType<ActionResult<Brand>>();


        }

        [Fact]
        public void BrandController_PutBrand_ReturnBrand()
        {
            int id = 1;

            var brand = A.Fake<Brand>();
            A.CallTo(() => _brandRepository.PutBrand(id , brand)).Returns(brand);
            var controller = new BrandController(_brandRepository);


            var result = controller.PutBrand(id,brand);

            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<Brand>>();


        }











    }
}
