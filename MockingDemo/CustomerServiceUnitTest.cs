using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepositoryPattern_RepoClasses;
using RepositoryPattern_RepoInterfaces;
using Repository_Database;
using RepositoryPattern;
using System.Collections.Generic;
using System.Linq;

namespace MockingDemo
{
    [TestClass]
    public class CustomerServiceUnitTest
    {
        public ICustomerRepository MockCustomerRepository;

       
        public CustomerServiceUnitTest()
        {
            IList<Customer> customers = TestData.GetCustomersListTestData();
            var mockCustomerRepo = new Moq.Mock<ICustomerRepository>();
            //select all customers
            mockCustomerRepo.Setup(cust => cust.SelectAll()).Returns(customers);
            // return a customer by Id
            mockCustomerRepo.Setup(cust => cust.SelectByID(
                It.IsAny<string>())).Returns((string str) => customers.Where(
                x => x.CustomerID == str).Single());

            // saving a customer
            mockCustomerRepo.Setup(cust => cust.Insert(It.IsAny<Customer>())).Returns((Customer target) =>
            {
                customers.Add(target);

                return true;
            });

            // Complete the setup of our Mock Customer Repository
            this.MockCustomerRepository = mockCustomerRepo.Object;

        }

        /// <summary>
        /// return a customer By Id
        /// </summary>
        [TestMethod]
        public void CanReturnCustomerById()
        {
            //Act
            Customer testCustomer = this.MockCustomerRepository.SelectByID("CustomerID2");
            
            //Assert
            Assert.IsNotNull(testCustomer); // Test if null
            Assert.IsInstanceOfType(testCustomer, typeof(Customer)); // Test type
            Assert.AreEqual("ContactName2", testCustomer.ContactName); // Verify it is the right product
        }

        /// <summary>
        /// return all customers
        /// </summary>
        [TestMethod]
        public void CanReturnAllCustomers()
        {
            // Try finding all customers
            IList<Customer> testCustomers = this.MockCustomerRepository.SelectAll().ToList();

            Assert.IsNotNull(testCustomers); // Test if null
            Assert.AreEqual(10, testCustomers.Count); // Verify the correct Number
        }

        /// <summary>
        /// insert a new customerr
        /// </summary>
        [TestMethod]
        public void CanInsertCustomer()
        {
            // Create a new product, not I do not supply an id
            Customer newCustomer = TestData.GetCustomerTestData();

            int customerCount = this.MockCustomerRepository.SelectAll().ToList().Count;
            Assert.AreEqual(10, customerCount); // Verify the expected Number pre-insert

            // try saving our new customer
            this.MockCustomerRepository.Insert(newCustomer);

            
            customerCount = this.MockCustomerRepository.SelectAll().ToList().Count;
            //Assert
            Assert.AreEqual(11, customerCount); // Verify the expected Number post-insert

        }      

    }
}
