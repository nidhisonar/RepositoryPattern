using FizzWare.NBuilder;
using Repository_Database;
using System.Collections;
using System.Collections.Generic;

namespace MockingDemo
{
    static class TestData
    {
        public static Customer GetCustomerTestData()
        {
            return Builder<Customer>.CreateNew().Build();
        }
        public static IList<Customer> GetCustomersListTestData()
        {
            return Builder<Customer>.CreateListOfSize(10).Build();
        }

        public static IList<Customer> GetCustomersListWithFakerTestData()
        {
            return Builder<Customer>.CreateListOfSize(10)
        .All()
            .With(c => c.ContactName = Faker.Name.First())
            .With(c => c.CompanyName = Faker.Company.Name())
            .With(c => c.Address = Faker.Address.StreetAddress())
            .With(c => c.City = Faker.Address.City())
            .With(c => c.Country = Faker.Address.Country())
            .With(c => c.CustomerID = Faker.RandomNumber.Next().ToString())
        .Build();
        }


    }
}
