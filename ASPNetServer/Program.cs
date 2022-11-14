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

//

app.MapGet("/get-all-orderdetails", async () => await OrderDetailRepository.GetOrderDetailsAsync()).WithTags("Order Details Endpoints");

app.MapGet("/get-orderdetail-by-id/{orderdetailId}", async (int orderDetailId) =>
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

app.MapPost("/create-orderdetail", async (OrderDetail orderDetailToCreate) =>
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

app.MapPut("/update-orderdetail", async (OrderDetail orderDetailToUpdate) =>
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

app.MapDelete("/delete-orderdetail-by-id/{orderdetailId}", async (int orderdetailId) =>
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

