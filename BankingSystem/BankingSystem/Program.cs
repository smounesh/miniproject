using System.Text;
using System.Text.Json.Serialization;
using AutoMapper;
using BankingSystem.Contexts;
using BankingSystem.Models;
using BankingSystem.Repositories;
using BankingSystem.Repositories.Interfaces;
using BankingSystem.Services;
using BankingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Add this line to use lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure the DbContext
builder.Services.AddDbContext<BankingSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

#region JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
#endregion

# region roles
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EmployeePolicy", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("Employee")));

    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("Admin")));

    options.AddPolicy("UserPolicy", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("User")));

    options.AddPolicy("EmployeeOrUserPolicy", policy =>
    policy.RequireAssertion(context =>
        context.User.IsInRole("Employee") || context.User.IsInRole("User")));
});

# endregion

#region AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
#endregion

#region repositories
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserDetailRepository>();
builder.Services.AddScoped<TransactionRepository>();
builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<LoanRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<UserDetail>, UserDetailRepository>();
builder.Services.AddScoped<IRepository<Transaction>, TransactionRepository>();
builder.Services.AddScoped<IRepository<Account>, AccountRepository>();
builder.Services.AddScoped<IRepository<Loan>, LoanRepository>();
builder.Services.AddScoped<IRepository<Branch>, BranchRepository>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
#endregion

#region logging
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
    c.UseInlineDefinitionsForEnums();

    // Define the JWT bearer token scheme
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    };

    // Add the JWT bearer token scheme to the Swagger document
    c.AddSecurityDefinition("Bearer", securityScheme);

    // Add the JWT bearer token authentication requirement to the Swagger document
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();