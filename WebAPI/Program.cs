using Application;
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