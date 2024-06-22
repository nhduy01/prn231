using Application;
using Infracstructures;
using Microsoft.EntityFrameworkCore;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddWebAPIService(builder);
builder.Services.AddInfractstructure(builder.Configuration);

// builder.Services.AddHttpsRedirection(options =>
// {
//     options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
//     options.HttpsPort = 5001; // Specify the HTTPS port
// });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
    //dbContext.Database.Migrate();
}

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// }

app.UseSwagger();
app.UseSwaggerUI();

#region Add sau

app.UseSession();

app.MapHealthChecks("/healthz");

//app.UseCors("_myAllowSpecificOrigins");

#endregion

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();