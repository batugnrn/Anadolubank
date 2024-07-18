using Bank.Infrastructure;
using Bank.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddCors(options => options.AddDefaultPolicy(policy=>
//policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
//));



builder.Services.AddPersistanceServices();
builder.Services.AddInfrastactureServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Customer" , options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,  // hangi sitelerin kabul edildiði yer  sitenin linki
            ValidateAudience = true,  // hangi api daðýttýðýný ifade eder  api linki
            ValidateLifetime = true,  // oluþturulan tokenýn süresini kontrol eder.
            ValidateIssuerSigningKey = true, // tokeýnýn bizim uygulamaya ait olup olmadýðýný kontrol eder.

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, Validationparameters) => expires != null ? expires > DateTime.UtcNow : false
        };
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
