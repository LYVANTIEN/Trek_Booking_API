﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trek_Booking_DataAccess.Data;

#nullable disable

namespace Trek_Booking_DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240513073102_updateBookingCart")]
    partial class updateBookingCart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trek_Booking_DataAccess.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime?>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("RoomQuantity")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VoucherCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingId");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("bookings");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.BookingCart", b =>
                {
                    b.Property<int>("BookingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingCartId"));

                    b.Property<DateTime?>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("RoomQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VoucherCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingCartId");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("bookingCarts");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.CartTour", b =>
                {
                    b.Property<int>("CartTourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartTourId"));

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<decimal>("TourPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TourQuantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartTourId");

                    b.HasIndex("TourId");

                    b.HasIndex("UserId");

                    b.ToTable("cartTours");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateSubmitted")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("BookingId");

                    b.HasIndex("HotelId");

                    b.HasIndex("UserId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"));

                    b.Property<string>("HotelAvatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelCity")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("HotelDistrict")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HotelFulDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HotelPhone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsVerify")
                        .HasColumnType("bit");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("HotelId");

                    b.HasIndex("SupplierId");

                    b.ToTable("hotels");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.PaymentInformation", b =>
                {
                    b.Property<int>("PaymentInforId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentInforId"));

                    b.Property<float>("CartNumber")
                        .HasColumnType("real");

                    b.Property<DateTime?>("PaidDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PaymentFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PaymentInforId");

                    b.HasIndex("UserId");

                    b.ToTable("paymentInformations");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Rate", b =>
                {
                    b.Property<int>("RateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RateId"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RateValue")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RateId");

                    b.HasIndex("BookingId");

                    b.HasIndex("HotelId");

                    b.HasIndex("UserId");

                    b.ToTable("rates");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<float>("DiscountPercent")
                        .HasColumnType("real");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomAvailable")
                        .HasColumnType("int");

                    b.Property<int>("RoomCapacity")
                        .HasColumnType("int");

                    b.Property<string>("RoomDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RoomPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("RoomStatus")
                        .HasColumnType("bit");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Room3DImage", b =>
                {
                    b.Property<int>("RoomImage3DId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomImage3DId"));

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("RoomImage3DURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomImage3DId");

                    b.HasIndex("RoomId");

                    b.ToTable("room3DImages");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.RoomImage", b =>
                {
                    b.Property<int>("RoomImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomImageId"));

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("RoomImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomImageId");

                    b.HasIndex("RoomId");

                    b.ToTable("roomImages");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.RoomService", b =>
                {
                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("ServiceId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("roomServices");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<string>("ServiceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("services");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("Address")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsVerify")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SupplierId");

                    b.ToTable("suppliers");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.SupplierStaff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffAddress")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("StaffEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("StaffPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StaffPhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("StaffId");

                    b.HasIndex("SupplierId");

                    b.ToTable("supplierStaff");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Tour", b =>
                {
                    b.Property<int>("TourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourId"));

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("TourAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourCapacity")
                        .HasColumnType("int");

                    b.Property<string>("TourDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TourPrice")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TourTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TourTransportation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TourId");

                    b.HasIndex("SupplierId");

                    b.ToTable("tours");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.TourImage", b =>
                {
                    b.Property<int>("TourImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourImageId"));

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<string>("TourImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TourImageId");

                    b.HasIndex("TourId");

                    b.ToTable("tourImages");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.TourOrder", b =>
                {
                    b.Property<int>("TourOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourOrderId"));

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TourOrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TourOrderQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TourTotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TourOrderId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("TourId");

                    b.HasIndex("UserId");

                    b.ToTable("tourOrders");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsVerify")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Voucher", b =>
                {
                    b.Property<int>("VoucherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoucherId"));

                    b.Property<DateTime?>("AvailableDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("DiscountPercent")
                        .HasColumnType("real");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("VoucherCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VoucherQuantity")
                        .HasColumnType("int");

                    b.Property<bool>("VoucherStatus")
                        .HasColumnType("bit");

                    b.HasKey("VoucherId");

                    b.HasIndex("HotelId");

                    b.ToTable("vouchers");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.VoucherUsageHistory", b =>
                {
                    b.Property<int>("UserVoucherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserVoucherId"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VoucherId")
                        .HasColumnType("int");

                    b.HasKey("UserVoucherId");

                    b.HasIndex("BookingId");

                    b.HasIndex("UserId");

                    b.HasIndex("VoucherId");

                    b.ToTable("voucherUsageHistories");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Booking", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Hotel", "Hotel")
                        .WithMany("bookings")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.Room", "Room")
                        .WithMany("bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.User", "User")
                        .WithMany("bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.BookingCart", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Hotel", "Hotel")
                        .WithMany("bookingCarts")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.Room", "Room")
                        .WithMany("bookingCarts")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.User", "User")
                        .WithMany("bookingCarts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.CartTour", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Tour", "Tour")
                        .WithMany("cartTours")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.User", "User")
                        .WithMany("cartTours")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Comment", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Booking", "Booking")
                        .WithMany("comments")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.Hotel", "Hotel")
                        .WithMany("comments")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.User", "User")
                        .WithMany("comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Hotel", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Supplier", "Supplier")
                        .WithMany("hotels")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.PaymentInformation", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.User", "User")
                        .WithMany("paymentInformations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Rate", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Booking", "Booking")
                        .WithMany("rates")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.Hotel", "Hotel")
                        .WithMany("rates")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.User", "User")
                        .WithMany("rates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Room", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Hotel", "Hotel")
                        .WithMany("rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Room3DImage", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Room", "Room")
                        .WithMany("room3DImages")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.RoomImage", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Room", "Room")
                        .WithMany("roomImages")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.RoomService", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Room", "Room")
                        .WithMany("roomServices")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.Service", "Service")
                        .WithMany("roomServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.SupplierStaff", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Supplier", "Supplier")
                        .WithMany("supplierStaffs")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Tour", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Supplier", "Supplier")
                        .WithMany("tours")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.TourImage", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Tour", "Tour")
                        .WithMany("tourImages")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.TourOrder", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Supplier", "Supplier")
                        .WithMany("tourOrders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.Tour", "Tour")
                        .WithMany("tourOrders")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.User", "User")
                        .WithMany("tourOrders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");

                    b.Navigation("Tour");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Voucher", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Hotel", "Hotel")
                        .WithMany("vouchers")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.VoucherUsageHistory", b =>
                {
                    b.HasOne("Trek_Booking_DataAccess.Booking", "Booking")
                        .WithMany("voucherUsageHistory")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.User", "User")
                        .WithMany("voucherUsageHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trek_Booking_DataAccess.Voucher", "Voucher")
                        .WithMany("voucherUsageHistories")
                        .HasForeignKey("VoucherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("User");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Booking", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("rates");

                    b.Navigation("voucherUsageHistory");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Hotel", b =>
                {
                    b.Navigation("bookingCarts");

                    b.Navigation("bookings");

                    b.Navigation("comments");

                    b.Navigation("rates");

                    b.Navigation("rooms");

                    b.Navigation("vouchers");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Room", b =>
                {
                    b.Navigation("bookingCarts");

                    b.Navigation("bookings");

                    b.Navigation("room3DImages");

                    b.Navigation("roomImages");

                    b.Navigation("roomServices");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Service", b =>
                {
                    b.Navigation("roomServices");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Supplier", b =>
                {
                    b.Navigation("hotels");

                    b.Navigation("supplierStaffs");

                    b.Navigation("tourOrders");

                    b.Navigation("tours");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Tour", b =>
                {
                    b.Navigation("cartTours");

                    b.Navigation("tourImages");

                    b.Navigation("tourOrders");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.User", b =>
                {
                    b.Navigation("bookingCarts");

                    b.Navigation("bookings");

                    b.Navigation("cartTours");

                    b.Navigation("comments");

                    b.Navigation("paymentInformations");

                    b.Navigation("rates");

                    b.Navigation("tourOrders");

                    b.Navigation("voucherUsageHistories");
                });

            modelBuilder.Entity("Trek_Booking_DataAccess.Voucher", b =>
                {
                    b.Navigation("voucherUsageHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
