using Xunit;
using RestCustomerServiceSample1.Model;
using RestCustomerServiceSample1.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestProject1
{

    public class UnitTest1
    {
       
       
        
        [Fact]
        public void GetAllProducts_ShouldReturnAllElephants()
        {
            // Act
            var testProducts = GetTestElephants();
            var controller = new ElephantController();

            var result = controller.Get() as List<Elephants>;
            Assert.NotNull(result);
            // Assert
            Assert.Equal(testProducts.Count, result.Count);
        }
        private List<Elephants> GetTestElephants()
        {
            List<Elephants> elephants = new List<Elephants>()
            {
                new Elephants(1,"POMMY" , 1000 , "ASIAN"),
                new Elephants(2,"Tony" , 4009 , "African"),
                new Elephants(3,"Jony" , 5000 , "South-ASIAN"),
                new Elephants(4,"Lilly" , 6000 , "South-african"),
                new Elephants(5,"Danny" , 7000 , "North-america")
            };
            return elephants;
        }

        [Fact]
        public void GetProduct_ShouldReturnCorrectElephant()
        {
            // Act
            var testProducts = GetTestElephants();
            var controller = new ElephantController();
            //Assert            
            var result = controller.Get(4) as OkObjectResult;
            var data = result.Value as Elephants;
            Assert.NotNull(result);
            Assert.Equal(testProducts[3].Name, data.Name);
        }
    }
}
