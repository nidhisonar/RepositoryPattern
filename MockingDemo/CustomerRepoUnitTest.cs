using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepositoryPattern_RepoClasses;
using RepositoryPattern_RepoInterfaces;
using Repository_Database;
using RepositoryPattern;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Autofac;

namespace MockingDemo
{
    [TestClass]
    public class CustomerRepoUnitTest
    {
        public INorthwind_DBEntities MockDbContext;

        public CustomerRepoUnitTest()
        {
            //Customer customer = TestData.GetCustomerTestData();
            //IList<Customer> customers = new List<Customer>
            //{
            //    new Customer{ CustomerID="1",
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

         
            //var mockCustomersSet = new Mock<DbSet<Customer>>();
            //mockCustomersSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customers.Provider);
            ////customersSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customers.Expression);
            ////customersSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customers.ElementType);
            ////customersSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customers.GetEnumerator());

            //var mockedContext = new Mock<INorthwind_DBEntities>();

            //mockedContext.Setup(c => c.Customers).Returns(mockCustomersSet.Object);
            
            //// Complete the setup of our Mock Db Context
            //this.MockDbContext = mockedContext.Object;
        }

        /// <summary>
        /// return a customer By Id
        /// </summary>
        [TestMethod]
        public void CanReturnCustomerById()
        {
            //Arrange            
            var mockDbContext = new Mock<INorthwind_DBEntities>();
            var mockCustomersSet = new Mock<DbSet<Customer>>();
            mockCustomersSet.Setup(x => x.Find(It.IsAny<string>())).Returns(TestData.GetCustomerTestData());
            mockDbContext.Setup(x => x.Customers).Returns(mockCustomersSet.Object);
            var mockRepo = new CustomerRepository(mockDbContext.Object);

            //Act
            var result = mockRepo.SelectByID("1207272115");

            //Assert                     
            Assert.IsNotNull(result); // Test if null
            Assert.IsInstanceOfType(result, typeof(Customer)); // Test type
            Assert.AreEqual("ContactName1", result.ContactName); // Verify it is the right customer
        }

        /// <summary>
        /// return all customers
        /// </summary>
        [TestMethod]
        public void CanReturnAllCustomers()
        {
            //Arrange
            var customers = TestData.GetCustomersListWithFakerTestData().AsQueryable();        
            var mockCustomersSet = new Mock<DbSet<Customer>>();
            mockCustomersSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customers.Provider);
            mockCustomersSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customers.Expression);
            mockCustomersSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customers.ElementType);
            mockCustomersSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customers.GetEnumerator());
            var mockDbContext = new Mock<INorthwind_DBEntities>();
            mockDbContext.Setup(x => x.Customers).Returns(mockCustomersSet.Object);
            var mockRepo = new CustomerRepository(mockDbContext.Object);

            //Act
            var result = mockRepo.SelectAll();


            //Assert                     
            Assert.IsNotNull(result); // Test if null
            Assert.AreEqual(10, result.Count()); // Verify the count
        }

        /// <summary>
        /// insert a new customerr
        /// </summary>
        [TestMethod]
        public void CanInsertCustomer()
        {
            //Arrange            
            var mockDbContext = new Mock<INorthwind_DBEntities>();
            var mockCustomersSet = new Mock<DbSet<Customer>>();
            mockDbContext.Setup(x => x.Customers.Add(It.IsAny<Customer>())).Returns(TestData.GetCustomerTestData());
            var mockRepo = new CustomerRepository(mockDbContext.Object);

            //Act
            var result = mockRepo.Insert(TestData.GetCustomerTestData());

            //Assert     
            Assert.AreEqual(result, true);
            //mockCustomersSet.Verify(x => x.Add(It.IsAny<Customer>()), Times.Once);
            //mockDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }      

    }
}
