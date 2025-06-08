using Microsoft.AspNetCore.Identity;
using ticket_management_api.Utilities;
using ticket_management_api.Services;
using ticket_management_api.Services.PasswordHasher;
using ticket_management_api.Data;
using Microsoft.EntityFrameworkCore;
using ticket_management_api.Data.Payloads.Requests;
using ticket_management_api.Utilities.Shared;
using ticket_management_api.Utilities.Errors;
using ticket_management_api.Data.Entities;
using ticket_management_api.Data.Payloads.Responses;
using AutoMapper;
using ticket_management_api.Data.Objects;
using ticket_management_api.Enum;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IPasswordHasherService, PasswordHasherService>();
builder.Services.AddSingleton<IPasswordHasherService, PasswordHasherService>();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/register/admin", async (RegisterAccountRequest request, IPasswordHasherService passwordHasher, IMapper mapper, DataContext dataContext) =>
{
    var role = AccountRoleEnum.Admin;

    var existingAccount = await dataContext.Accounts.SingleOrDefaultAsync(e => e.EmailAddress == request.EmailAddress);

    if (existingAccount != null)
    {
        return Result.Failure(AccountErrors.EmailAlreadyExists(existingAccount.EmailAddress));
    }

    var initialPasswordValue = Helper.RandomString(8);

    var password = passwordHasher.Hash(initialPasswordValue);

    var newAccount = Account.Create(request.CoordinatorId != null ? new AccountId(Guid.Parse(request.CoordinatorId)) : null, role, request.DisplayName, request.Address, request.MobileNumber, request.EmailAddress, request.Username, initialPasswordValue, password, request.GcashAccount);

    await dataContext.Accounts.AddAsync(newAccount);

    await dataContext.SaveChangesAsync();

    return Result.Success(new RegisterAccountResponse
    {
        Account = mapper.Map<AccountDto>(newAccount)
    });
});

app.MapPost("/register/coordinator", async (RegisterAccountRequest request, IPasswordHasherService passwordHasher, IMapper mapper, DataContext dataContext) =>
{
    var role = AccountRoleEnum.Coordinator;

    var existingAccount = await dataContext.Accounts.SingleOrDefaultAsync(e => e.EmailAddress == request.EmailAddress);

    if (existingAccount != null)
    {
        return Result.Failure(AccountErrors.EmailAlreadyExists(existingAccount.EmailAddress));
    }

    var initialPasswordValue = Helper.RandomString(8);

    var password = passwordHasher.Hash(initialPasswordValue);

    var newAccount = Account.Create(request.CoordinatorId != null ? new AccountId(Guid.Parse(request.CoordinatorId)) : null, role, request.DisplayName, request.Address, request.MobileNumber, request.EmailAddress, request.Username, initialPasswordValue, password, request.GcashAccount);

    await dataContext.Accounts.AddAsync(newAccount);

    await dataContext.SaveChangesAsync();

    return Result.Success(new RegisterAccountResponse
    {
        Account = mapper.Map<AccountDto>(newAccount)
    });
});

app.MapPost("/register/ticket-issuer", async (RegisterAccountRequest request, IPasswordHasherService passwordHasher, IMapper mapper, DataContext dataContext) =>
{
    var role = AccountRoleEnum.TicketIssuer;

    var existingAccount = await dataContext.Accounts.SingleOrDefaultAsync(e => e.EmailAddress == request.EmailAddress);

    if (existingAccount != null)
    {
        return Result.Failure(AccountErrors.EmailAlreadyExists(existingAccount.EmailAddress));
    }

    var initialPasswordValue = Helper.RandomString(8);

    var password = passwordHasher.Hash(initialPasswordValue);

    var newAccount = Account.Create(request.CoordinatorId != null ? new AccountId(Guid.Parse(request.CoordinatorId)) : null, role, request.DisplayName, request.Address, request.MobileNumber, request.EmailAddress, request.Username, initialPasswordValue, password, request.GcashAccount);

    await dataContext.Accounts.AddAsync(newAccount);

    await dataContext.SaveChangesAsync();

    return Result.Success(new RegisterAccountResponse
    {
        Account = mapper.Map<AccountDto>(newAccount)
    });
});

app.MapPost("/login", async (LoginAccountRequest request, IPasswordHasherService passwordHasher, IMapper mapper, DataContext dataContext) =>
{
    var existingAccount = await dataContext.Accounts.SingleOrDefaultAsync(e => e.Username == request.Username);

    if (existingAccount == null)
    {
        return Result.Failure(AccountErrors.NotFound(request.Username));
    }

    var passwordVerified = passwordHasher.Verify(request.Password, existingAccount.Password);

    if (!passwordVerified)
    {
        return Result.Failure(AccountErrors.InvalidUsernameOrPassword());
    }

    return Result.Success(new LoginAccountResponse
    {
        Account = mapper.Map<AccountDto>(existingAccount)
    });
});



app.UseSwaggerUI();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
