using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using RepositoryPattern_ServiceClasses;
using RepositoryPattern_ServiceInterfaces;
using Repository_Database;
using RepositoryPattern.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace MockingDemo
{
    [TestClass]
    public class CustomerControllerUnitTest
    {
        public ICustomerService MockCustomerService;
        IList<Customer> customers = null;


        public CustomerControllerUnitTest()
        {
            customers = TestData.GetCustomersListWithFakerTestData();

            //IList<Customer> customers = new List<Customer>
            //{
            //    new Customer{ CustomerID = "1",
            //    CompanyName = "Logica Corp",
            //    ContactName = "Santosh",
            //    ContactTitle = "Sir",
            //    Address = "Malviya Nager",
            //    City = "Bhopal",
            //    Region = "BPL",
            //    PostalCode = "786699",
            //    Country = "India",
            //    Phone = "9876546780",
            //    Fax = "677847549894"
            //    },
            //    new Customer{ CustomerID="2",
            //    CompanyName = "Logica Corp",
            //    ContactName = "Mahesh",
            //    ContactTitle = "Sir",
            //    Address = "Malviya Nager",
            //    City = "Bhopal",
            //    Region = "BPL",
            //    PostalCode = "786699",
            //    Country = "India",
            //    Phone = "9876546780",
            //    Fax = "677847549894"
            //    },
            //    new Customer{CustomerID="3",
            //    CompanyName = "Logica Corp",
            //    ContactName = "Santosh",
            //    ContactTitle = "Sir",
            //    Address = "Malviya Nager",
            //    City = "Bhopal",
            //    Region = "BPL",
            //    PostalCode = "786699",
            //    Country = "India",
            //    Phone = "9876546780",
            //    Fax = "677847549894"
            //} };
            var mockCustomerService = new Moq.Mock<ICustomerService>();
            //select all customers
            mockCustomerService.Setup(cust => cust.SelectAll()).Returns(customers);

            // return a customer by Id
            mockCustomerService.Setup(cust => cust.SelectByID(
                It.IsAny<string>())).Returns((string str) => customers.Where(
                x => x.CustomerID == str).Single());

            // saving a customer
            mockCustomerService.Setup(cust => cust.Insert(It.IsAny<Customer>())).Returns((Customer target) =>
            {
                customers.Add(target);

                return true;
            });

                // Complete the setup of our Mock Customer Service
                this.MockCustomerService = mockCustomerService.Object;

        }

        /// <summary>
        /// return a customer By Id
        /// </summary>
        [TestMethod]
        public void CanReturnCustomerById()
        {
            //Arrange
            var mockService = new Mock<ICustomerService>();
            mockService.Setup(x => x.SelectByID("1"))
                .Returns(new Customer { CustomerID = "1" });

            var controller = new CustomerController(mockService.Object);

            // Act
            var result = controller.CustomerById("1") as JsonResult;

            // Assert
            Assert.IsNotNull(result);          
            Assert.IsInstanceOfType(result.Data, typeof(Customer)); // Test type
        }

        /// <summary>
        /// return all customers
        /// </summary>
        [TestMethod]
        public void CanReturnAllCustomers()
        {
            //Arrange
            var mockService = new Mock<ICustomerService>();
            mockService.Setup(cust => cust.SelectAll()).Returns(customers);

            var controller = new CustomerController(mockService.Object);

            // Act
            var result = controller.Index() as JsonResult;

            // Assert
            Assert.IsNotNull(result.Data);         
        }

        /// <summary>
        /// return no customers
        /// </summary>
        [TestMethod]
        public void CustomerByNegativeIdTest()
        {
            // Arrange
            var mockService = new Mock<ICustomerService>();
            mockService.Setup(x => x.SelectByID("1"))
                .Returns(new Customer { CustomerID = "1" });

            var controller = new CustomerController(mockService.Object);

            // Act
            var result = controller.CustomerById("-1") as HttpNotFoundResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult)); // Verify the correct Number
        }

        [TestMethod]
        public void CustomerInsertInvalidModel()
        {
            // Arrange
            var mockService = new Mock<ICustomerService>();
            var controller = new CustomerController(mockService.Object);
            controller.ModelState.AddModelError("Error", "Error");

            //Act
            var result = (JsonResult)controller.Insert(TestData.GetCustomerTestData());


            // Assert
            Assert.AreEqual(result.Data, "400"); 
        }
        /// <summary>
        /// insert a new customerr
        /// </summary>
        [TestMethod]
        public void CanInsertCustomerWithCityNotEqualBangalore()
        {
            //Arrange
            var mockService = new Mock<ICustomerService>();
            var controller = new CustomerController(mockService.Object);
            IList<Customer> customer = TestData.GetCustomersListTestData();
            IList<Customer> customerFake = TestData.GetCustomersListWithFakerTestData();

            // Act

            var result = controller.Insert(TestData.GetCustomerTestData()) as JsonResult;

            //Assert
            Assert.AreEqual(result.Data, true);
        }      

    } 
}
