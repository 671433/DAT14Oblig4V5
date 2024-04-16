using System;
using System.Collections.Generic;
using AppFrontDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace AppFrontDesk.Data;

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
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

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

        modelBuilder.Entity<BedOption>(entity =>
        {
            entity.HasKey(e => e.BedOptionsId).HasName("PK__bed_opti__4B15DD0B9E132F86");

            entity.Property(e => e.BedOptionsId).ValueGeneratedNever();
        });

        modelBuilder.Entity<DayView>(entity =>
        {
            entity.HasKey(e => e.DayViewId).HasName("PK__tmp_ms_x__7427BCEDC852097A");

            entity.HasOne(d => d.CleaningStatusNavigation).WithMany(p => p.DayViewCleaningStatusNavigations).HasConstraintName("fk_Cleaning_status");

            entity.HasOne(d => d.MaintenanceStatusNavigation).WithMany(p => p.DayViewMaintenanceStatusNavigations).HasConstraintName("fk_Maintenance_status");

            entity.HasOne(d => d.Reservation).WithMany(p => p.DayViews).HasConstraintName("FK__Day_view__Reserv__46B27FE2");

            entity.HasOne(d => d.RoomNrNavigation).WithMany(p => p.DayViews).HasConstraintName("FK__Day_view__Room_n__3D2915A8");

            entity.HasOne(d => d.RoomStatusNavigation).WithMany(p => p.DayViews).HasConstraintName("fk_Room_status");

            entity.HasOne(d => d.ServiceStatusNavigation).WithMany(p => p.DayViewServiceStatusNavigations).HasConstraintName("fk_Service_status");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotels__46023BBF1E9135A7");

            entity.Property(e => e.HotelId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__tmp_ms_x__AA2FFB853737B371");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.People).HasConstraintName("fk_Person_Role");
        });

        modelBuilder.Entity<Quality>(entity =>
        {
            entity.HasKey(e => e.QualityId).HasName("PK__quality__F7EDEE51F299C378");

            entity.Property(e => e.QualityId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__tmp_ms_x__B7EE5F04E64EF8D0");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reservations).HasConstraintName("FK__Reservati__Custo__489AC854");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Reservations).HasConstraintName("FK__Reservati__Hotel__498EEC8D");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__role__CD98460A8E0F7C6E");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomNr).HasName("PK__Room__19EC8599D039D6E1");

            entity.Property(e => e.RoomNr).ValueGeneratedNever();

            entity.HasOne(d => d.BedOptionNavigation).WithMany(p => p.Rooms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Bed_option");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms).HasConstraintName("fk_HotelID");

            entity.HasOne(d => d.QualityNavigation).WithMany(p => p.Rooms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Quality");
        });

        modelBuilder.Entity<RoomRequestEnum>(entity =>
        {
            entity.HasKey(e => e.RoomRequestEnumId).HasName("PK__room_req__D78CF54B01E0DFBA");

            entity.Property(e => e.RoomRequestEnumId).ValueGeneratedNever();
        });

        modelBuilder.Entity<RoomRequestNote>(entity =>
        {
            entity.HasKey(e => e.RoomRequestId).HasName("PK__tmp_ms_x__5DD345DE1F876C22");

            entity.HasOne(d => d.DayViewNavigation).WithMany(p => p.RoomRequestNotes).HasConstraintName("FK__room_requ__DayVi__4D5F7D71");

            entity.HasOne(d => d.Person).WithMany(p => p.RoomRequestNotes).HasConstraintName("FK__room_requ__Perso__4C6B5938");
        });

        modelBuilder.Entity<RoomStatus>(entity =>
        {
            entity.HasKey(e => e.RoomStatusId).HasName("PK__room_sta__ACD0100C2CA9B64F");

            entity.Property(e => e.RoomStatusId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
