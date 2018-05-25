using System;
namespace Repository_Database
{
  public  interface INorthwind_DBEntities
    {
        System.Data.Entity.DbSet<Alphabetical_list_of_product> Alphabetical_list_of_products { get; set; }
        System.Data.Entity.DbSet<Category> Categories { get; set; }
        System.Data.Entity.DbSet<Category_Sales_for_1997> Category_Sales_for_1997 { get; set; }
        System.Data.Entity.DbSet<Current_Product_List> Current_Product_Lists { get; set; }
        System.Data.Entity.DbSet<Customer_and_Suppliers_by_City> Customer_and_Suppliers_by_Cities { get; set; }
        System.Data.Entity.DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        System.Data.Entity.DbSet<Customer> Customers { get; set; }
        System.Data.Entity.Core.Objects.ObjectResult<CustOrderHist_Result> CustOrderHist(string customerID);
        System.Data.Entity.Core.Objects.ObjectResult<CustOrdersDetail_Result> CustOrdersDetail(int? orderID);
        System.Data.Entity.Core.Objects.ObjectResult<CustOrdersOrders_Result> CustOrdersOrders(string customerID);
        System.Data.Entity.Core.Objects.ObjectResult<Employee_Sales_by_Country_Result> Employee_Sales_by_Country(DateTime? beginning_Date, DateTime? ending_Date);
        System.Data.Entity.DbSet<Employee> Employees { get; set; }
        System.Data.Entity.DbSet<Invoice> Invoices { get; set; }
        System.Data.Entity.DbSet<Order_Detail> Order_Details { get; set; }
        System.Data.Entity.DbSet<Order_Details_Extended> Order_Details_Extendeds { get; set; }
        System.Data.Entity.DbSet<Order_Subtotal> Order_Subtotals { get; set; }
        System.Data.Entity.DbSet<Order> Orders { get; set; }
        System.Data.Entity.DbSet<Orders_Qry> Orders_Qries { get; set; }
        System.Data.Entity.DbSet<Product_Sales_for_1997> Product_Sales_for_1997 { get; set; }
        System.Data.Entity.DbSet<Product> Products { get; set; }
        System.Data.Entity.DbSet<Products_Above_Average_Price> Products_Above_Average_Prices { get; set; }
        System.Data.Entity.DbSet<Products_by_Category> Products_by_Categories { get; set; }
        System.Data.Entity.DbSet<Region> Regions { get; set; }
        System.Data.Entity.DbSet<Sales_by_Category> Sales_by_Categories { get; set; }
        System.Data.Entity.Core.Objects.ObjectResult<Sales_by_Year_Result> Sales_by_Year(DateTime? beginning_Date, DateTime? ending_Date);
        System.Data.Entity.DbSet<Sales_Totals_by_Amount> Sales_Totals_by_Amounts { get; set; }
        System.Data.Entity.Core.Objects.ObjectResult<SalesByCategory_Result> SalesByCategory(string categoryName, string ordYear);
        int SaveChanges();
        System.Data.Entity.DbSet<Shipper> Shippers { get; set; }
        int sp_alterdiagram(string diagramname, int? owner_id, int? version, byte[] definition);
        int sp_creatediagram(string diagramname, int? owner_id, int? version, byte[] definition);
        int sp_dropdiagram(string diagramname, int? owner_id);
        System.Data.Entity.Core.Objects.ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, int? owner_id);
        System.Data.Entity.Core.Objects.ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, int? owner_id);
        int sp_renamediagram(string diagramname, int? owner_id, string new_diagramname);
        int sp_upgraddiagrams();
        System.Data.Entity.DbSet<Summary_of_Sales_by_Quarter> Summary_of_Sales_by_Quarters { get; set; }
        System.Data.Entity.DbSet<Summary_of_Sales_by_Year> Summary_of_Sales_by_Years { get; set; }
        System.Data.Entity.DbSet<Supplier> Suppliers { get; set; }
        System.Data.Entity.DbSet<sysdiagram> sysdiagrams { get; set; }
        System.Data.Entity.Core.Objects.ObjectResult<Ten_Most_Expensive_Products_Result> Ten_Most_Expensive_Products();
        System.Data.Entity.DbSet<Territory> Territories { get; set; }
    }
}
