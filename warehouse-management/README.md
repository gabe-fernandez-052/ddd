# warehouse-management-api

## Definitions
* **Supplier Order** - an order issued by a buyer to a seller, indicating the purchasing of products from a supplier.
* **Receiver** - a parent transaction type which represents a collection of supplier order items received at a warehouse.
* **Receiver Item** - a child transaction type which represents an individual supplier order item received at at warehouse.
* **Customer Order** - an order issued by a buyer to a seller, indicating the purchasing of products from a warehouse.  
* **Shipment** - a parent transaction type which represents a collection of customer order items shipped from a warehouse.
* **Shipment Item** - a child transaction type which represents an individual customer order item shipped from a warehouse.

## Set Up
1. Clone the repository<br/>`git clone https://github.com/LogisticsFlow/warehouse-management-api.git`
1. Navigate to the WarehouseManagement.API folder
* **User Secrets**
    * Set up the secret for the db connection string<br/>`dotnet user-secrets set "ConnectionStrings:DbConnectionString" "<CONNECTION STRING>"`
    * Set up the secret for the Jwt key<br/>`dotnet user-secrets set "Jwt:Key" "<JWT KEY>"`
    * Set up the secret for the user clientId<br/>`dotnet user-secrets set "Users:0:ClientId" "<Client Id>"`
    * Set up the secret for the user role<br/>`dotnet user-secrets set "Users:0:Roles:0" "<Role>"`
    * Set up the secret for the Azure Monitor connection string<br/>`dotnet user-secrets set "AzureMonitor:ConnectionString" "<CONNECTION STRING>"`
1. Navigate to the WarehouseManagement.Infrastructure folder
1. Run the scaffold file in a powershell window (_Note: dotnet-ef tool must be installed_)
* It is recommended to copy and paste the scaffold command since it does not have a file extension

More Information about user secrets & environment variables can be found [here](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows)

## Development
We are using the EntityFramework tool to build the context and scaffold out the entities. To download the tool execute the following command<br/>
`dotnet tool install --global dotnet-ef`
