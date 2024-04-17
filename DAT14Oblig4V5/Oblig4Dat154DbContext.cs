using System;
using System.Collections.Generic;
using DAT14Oblig4V5.Models;
using Microsoft.EntityFrameworkCore;

namespace DAT14Oblig4V5;

public partial class Oblig4Dat154DbContext : DbContext
{
    public Oblig4Dat154DbContext()
    {
    }

    public Oblig4Dat154DbContext(DbContextOptions<Oblig4Dat154DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<BedOption> BedOptions { get; set; }

    public virtual DbSet<DayView> DayViews { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Quality> Qualities { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomRequestEnum> RoomRequestEnums { get; set; }

    public virtual DbSet<RoomRequestNote> RoomRequestNotes { get; set; }

    public virtual DbSet<RoomStatus> RoomStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:dat154oblig4.database.windows.net,1433;Database=Oblig4Dat154DB;User Id=satre;Password=Fisse9ls;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<BedOption>(entity =>
        {
            entity.HasKey(e => e.BedOptionsId).HasName("PK__bed_opti__4B15DD0B9E132F86");

            entity.ToTable("bed_options");

            entity.Property(e => e.BedOptionsId)
                .ValueGeneratedNever()
                .HasColumnName("bed_optionsID");
            entity.Property(e => e.BedOptionsDesctription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("bed_options_Desctription");
        });

        modelBuilder.Entity<DayView>(entity =>
        {
            entity.HasKey(e => e.DayViewId).HasName("PK__tmp_ms_x__7427BCEDC852097A");

            entity.ToTable("Day_view");

            entity.Property(e => e.DayViewId).HasColumnName("Day_viewID");
            entity.Property(e => e.CleaningStatus).HasColumnName("Cleaning_status");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.MaintenanceStatus).HasColumnName("Maintenance_status");
            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.RoomNr).HasColumnName("Room_nr");
            entity.Property(e => e.RoomService).HasColumnName("Room_service");
            entity.Property(e => e.RoomStatus).HasColumnName("Room_status");
            entity.Property(e => e.ServiceStatus).HasColumnName("Service_status");

            entity.HasOne(d => d.CleaningStatusNavigation).WithMany(p => p.DayViewCleaningStatusNavigations)
                .HasForeignKey(d => d.CleaningStatus)
                .HasConstraintName("fk_Cleaning_status");

            entity.HasOne(d => d.MaintenanceStatusNavigation).WithMany(p => p.DayViewMaintenanceStatusNavigations)
                .HasForeignKey(d => d.MaintenanceStatus)
                .HasConstraintName("fk_Maintenance_status");

            entity.HasOne(d => d.Reservation).WithMany(p => p.DayViews)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("FK__Day_view__Reserv__46B27FE2");

            entity.HasOne(d => d.RoomNrNavigation).WithMany(p => p.DayViews)
                .HasForeignKey(d => d.RoomNr)
                .HasConstraintName("FK__Day_view__Room_n__3D2915A8");

            entity.HasOne(d => d.RoomStatusNavigation).WithMany(p => p.DayViews)
                .HasForeignKey(d => d.RoomStatus)
                .HasConstraintName("fk_Room_status");

            entity.HasOne(d => d.ServiceStatusNavigation).WithMany(p => p.DayViewServiceStatusNavigations)
                .HasForeignKey(d => d.ServiceStatus)
                .HasConstraintName("fk_Service_status");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotels__46023BBF1E9135A7");

            entity.Property(e => e.HotelId)
                .ValueGeneratedNever()
                .HasColumnName("HotelID");
            entity.Property(e => e.HotelAdress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Hotel_Adress");
            entity.Property(e => e.HotelName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Hotel_name");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__tmp_ms_x__AA2FFB853737B371");

            entity.ToTable("Person");

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("fk_Person_Role");
        });

        modelBuilder.Entity<Quality>(entity =>
        {
            entity.HasKey(e => e.QualityId).HasName("PK__quality__F7EDEE51F299C378");

            entity.ToTable("quality");

            entity.Property(e => e.QualityId)
                .ValueGeneratedNever()
                .HasColumnName("qualityID");
            entity.Property(e => e.QualityDesctription)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("qualityDesctription");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__tmp_ms_x__B7EE5F04E64EF8D0");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.Checkin).HasColumnType("datetime");
            entity.Property(e => e.Checkout).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.ReservationEnd).HasColumnName("Reservation_end");
            entity.Property(e => e.ReservationStart).HasColumnName("Reservation_start");
            entity.Property(e => e.RoomNr).HasColumnName("RoomNR");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Reservati__Custo__489AC854");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK__Reservati__Hotel__498EEC8D");

            entity.HasOne(d => d.RoomNrNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomNr)
                .HasConstraintName("fk_Reservations_RoomNR");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__role__CD98460A8E0F7C6E");

            entity.ToTable("role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("roleID");
            entity.Property(e => e.RoleDesctription)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("role_Desctription");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomNr).HasName("PK__Room__19EC8599D039D6E1");

            entity.ToTable("Room");

            entity.Property(e => e.RoomNr)
                .ValueGeneratedNever()
                .HasColumnName("Room_nr");
            entity.Property(e => e.BedOption).HasColumnName("Bed_option");
            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.RoomSize).HasColumnName("Room_size");

            entity.HasOne(d => d.BedOptionNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.BedOption)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Bed_option");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("fk_HotelID");

            entity.HasOne(d => d.QualityNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.Quality)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Quality");
        });

        modelBuilder.Entity<RoomRequestEnum>(entity =>
        {
            entity.HasKey(e => e.RoomRequestEnumId).HasName("PK__room_req__D78CF54B01E0DFBA");

            entity.ToTable("room_request_enum");

            entity.Property(e => e.RoomRequestEnumId)
                .ValueGeneratedNever()
                .HasColumnName("room_request_enumID");
            entity.Property(e => e.RoomRequestEnumDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("room_request_enum_description");
        });

        modelBuilder.Entity<RoomRequestNote>(entity =>
        {
            entity.HasKey(e => e.RoomRequestId).HasName("PK__tmp_ms_x__5DD345DE1F876C22");

            entity.ToTable("room_request_notes");

            entity.Property(e => e.RoomRequestId).HasColumnName("Room_requestID");
            entity.Property(e => e.Finished).HasColumnType("datetime");
            entity.Property(e => e.InProgress)
                .HasColumnType("datetime")
                .HasColumnName("In_progress");
            entity.Property(e => e.New).HasColumnType("datetime");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.RoomRequestComment)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Room_request_comment");

            entity.HasOne(d => d.DayViewNavigation).WithMany(p => p.RoomRequestNotes)
                .HasForeignKey(d => d.DayView)
                .HasConstraintName("FK__room_requ__DayVi__4D5F7D71");

            entity.HasOne(d => d.Person).WithMany(p => p.RoomRequestNotes)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__room_requ__Perso__4C6B5938");
        });

        modelBuilder.Entity<RoomStatus>(entity =>
        {
            entity.HasKey(e => e.RoomStatusId).HasName("PK__room_sta__ACD0100C2CA9B64F");

            entity.ToTable("room_status");

            entity.Property(e => e.RoomStatusId)
                .ValueGeneratedNever()
                .HasColumnName("room_statusID");
            entity.Property(e => e.RoomStatusDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("room_status_description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
