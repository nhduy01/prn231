using System.Configuration;
using Application;
using Infracstructures;
using Microsoft.EntityFrameworkCore;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddWebAPIService(builder, builder.Configuration);
builder.Services.AddInfractstructure(builder.Configuration);


var app = builder.Build();



/*using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
    var appliedMigrations = dbContext.Database.GetAppliedMigrations();

    var allMigrations = dbContext.Database.GetMigrations();

    var pendingMigrations = allMigrations.Except(appliedMigrations);

    if (pendingMigrations.Any())
    {
        dbContext.Database.Migrate();
    }
}*/

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// }

app.UseSwagger();
app.UseSwaggerUI();

#region Add sau

app.UseSession();

app.MapHealthChecks("/healthz");

app.UseCors("_myAllowSpecificOrigins");

#endregion

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();