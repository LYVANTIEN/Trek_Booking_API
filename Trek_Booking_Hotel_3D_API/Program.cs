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
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IRoomImageRepository, RoomImageRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRateRepository, RateRepository>();
builder.Services.AddScoped<ISupplierStaffRepository, SupplierStaffRepository>();
builder.Services.AddScoped<IBookingCartRepository, BookingCartRepository>();
builder.Services.AddScoped<IRoom3DImageRepository, Room3DImageRepository>();
builder.Services.AddScoped<IVoucherRepository, VoucherRepository>();
builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddScoped<ITourImageRepository, TourImageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPaymentInforRepository, PaymentInfoRepository>();
builder.Services.AddScoped<IVoucherUsageHistoryRepository, VoucherUsageHistoryRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<ICartTourRepository, CartTourRepository>();
builder.Services.AddScoped<ITourOrderRepository, TourOrderRepository>();


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
