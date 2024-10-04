using ClientManagementService;
using DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<DbConnectionFactory>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    string connectionString = configuration.GetConnectionString("DefaultConnection");
    return new DbConnectionFactory(connectionString);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp", policy =>
    {
        policy.WithOrigins("http://localhost:5073") 
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();  // Optional if you're using cookies or authentication
    });
});

builder.Services.AddControllers();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
//app.MapRazorPages();
app.MapControllers();

// Enable CORS
app.UseCors("AllowBlazorApp");


app.Run();
