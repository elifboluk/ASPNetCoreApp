using ASPNetServer.Data;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000","https://appname.azurestaticapps.net");
        });

});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(SwaggerGenOptions =>
{
    SwaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo{ Title = "ASP.Net Server", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "ASP.Net Server";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json","Wep API serving a very simple Order model.");
    swaggerUIOptions.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");



app.MapGet("/get-all-orders", async () => await OrderRepository.GetOrdersAsync()).WithTags("Orders Endpoints");

app.MapGet("/get-order-by-id/{orderId}", async (int orderId) =>
{
    Order orderToReturn = await OrderRepository.GetOrdersByIdAsync(orderId);
    if (orderToReturn != null)
    {
        return Results.Ok(orderToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Orders Endpoints");

app.MapPost("/create-order", async (Order orderToCreate) =>
{
    bool createSuccesful = await OrderRepository.CreateOrdersAsync(orderToCreate);
    
    if (createSuccesful)
    {
        return Results.Ok("Create succesful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Orders Endpoints");

app.MapPut("/update-order", async (Order orderToUpdate) =>
{
    bool updateSuccesful = await OrderRepository.UpdateOrdersAsync(orderToUpdate);

    if (updateSuccesful)
    {
        return Results.Ok("Update succesful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Orders Endpoints");

app.MapDelete("/delete-order-by-id/{orderId}", async (int postId) =>
{
    bool deleteSuccesful = await OrderRepository.DeleteOrdersAsync(postId);

    if (deleteSuccesful)
    {
        return Results.Ok("Delete succesful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Orders Endpoints");

//

app.MapGet("/get-all-products", async () => await ProductRepository.GetProductsAsync()).WithTags("Products Endpoints");

app.MapGet("/get-product-by-id/{productId}", async (int productId) =>
{
    Product productToReturn = await ProductRepository.GetProductsByIdAsync(productId);
    if (productToReturn != null)
    {
        return Results.Ok(productToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Product Endpoints");

app.MapPost("/create-product", async (Product productToCreate) =>
{
    bool createSuccesful = await ProductRepository.CreateProductsAsync(productToCreate);

    if (createSuccesful)
    {
        return Results.Ok("Create succesful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Products Endpoints");

app.MapPut("/update-product", async (Product productToUpdate) =>
{
    bool updateSuccesful = await ProductRepository.UpdateProductsAsync(productToUpdate);

    if (updateSuccesful)
    {
        return Results.Ok("Update succesful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Products Endpoints");

app.MapDelete("/delete-product-by-id/{productId}", async (int productId) =>
{
    bool deleteSuccesful = await ProductRepository.DeleteProductsAsync(productId);

    if (deleteSuccesful)
    {
        return Results.Ok("Delete succesful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Products Endpoints");

//

app.MapGet("/get-all-orderdetails", async () => await OrderDetailRepository.GetOrderDetailsAsync()).WithTags("Order Details Endpoints");

app.MapGet("/get-order-by-id/{orderdetailId}", async (int orderDetailId) =>
{
    OrderDetail orderDetailToReturn = await OrderDetailRepository.GetOrderDetailsByIdAsync(orderDetailId);
    if (orderDetailToReturn != null)
    {
        return Results.Ok(orderDetailToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Order Details Endpoints");

app.MapPost("/create-order-detail", async (OrderDetail orderDetailToCreate) =>
{
    bool createSuccesful = await OrderDetailRepository.CreateOrderDetailsAsync(orderDetailToCreate);

    if (createSuccesful)
    {
        return Results.Ok("Create succesful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Order Details Endpoints");

app.MapPut("/update-order-detail", async (OrderDetail orderDetailToUpdate) =>
{
    bool updateSuccesful = await OrderDetailRepository.UpdateOrderDetailsAsync(orderDetailToUpdate);

    if (updateSuccesful)
    {
        return Results.Ok("Update succesful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Order Details Endpoints");

app.MapDelete("/delete-order-detail-by-id/{orderdetailId}", async (int orderdetailId) =>
{
    bool deleteSuccesful = await OrderDetailRepository.DeleteOrderDetailsAsync(orderdetailId);

    if (deleteSuccesful)
    {
        return Results.Ok("Delete succesful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Order Details Endpoints");


app.Run(); 

