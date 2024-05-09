using Microsoft.EntityFrameworkCore;
using Trek_Booking_DataAccess.Data;
using Trek_Booking_Repository.Repositories;
using Trek_Booking_Repository.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(item =>
{
    item.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// add scoped
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddScoped<ITourImageRepository, TourImageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPaymentInforRepository, PaymentInfoRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
