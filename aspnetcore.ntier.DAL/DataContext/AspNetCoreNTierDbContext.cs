
using aspnetcore.ntier.BLL;
using aspnetcore.ntier.DAL.Entities;
using aspnetcore.ntier.DAL.Password;
using Microsoft.EntityFrameworkCore;
using System;

namespace aspnetcore.ntier.DAL.DataContext;


public partial class AspNetCoreNTierDbContext : DbContext
{
    public AspNetCoreNTierDbContext()
    {
    }
    public AspNetCoreNTierDbContext(DbContextOptions<AspNetCoreNTierDbContext> options)
        : base(options)
    {
    }
    public DbSet<ApiUser> ApiUsers { get; set; }
    public DbSet<DashboardUser> DashboardUsers { get; set; }
    public virtual DbSet<CameraTbl> CameraTbls { get; set; }

    public virtual DbSet<ComScreenSetting> ComScreenSettings { get; set; }

    public virtual DbSet<ComSettingTbl> ComSettingTbls { get; set; }

    public virtual DbSet<DriversTbl> DriversTbls { get; set; }

    public virtual DbSet<LogTbl> LogTbls { get; set; }

    public virtual DbSet<NationTbl> NationTbls { get; set; }

    public virtual DbSet<PicturesTbl> PicturesTbls { get; set; }

    public virtual DbSet<ProductsTbl> ProductsTbls { get; set; }

    public virtual DbSet<SettingTbl> SettingTbls { get; set; }

    public virtual DbSet<SiteTbl> SiteTbls { get; set; }

    public virtual DbSet<TrucksTbl> TrucksTbls { get; set; }

    public virtual DbSet<UserPSettingTbl> UserPSettingTbls { get; set; }

    public virtual DbSet<UsersPerTbl> UsersPerTbls { get; set; }

    public virtual DbSet<UsersTbl> UsersTbls { get; set; }

    public virtual DbSet<WeightClassTbl> WeightClassTbls { get; set; }

    public virtual DbSet<WeightTbl> WeightTbls { get; set; }
    public virtual DbSet<Log> Logs { get; set; }



    public virtual DbSet<WeightTicketTbl> WeightTicketTbls { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        byte[] hashedPassword;
        byte[] passwordSalt;

        HashPassword.CreatePasswordHash("123qwe", out hashedPassword, out passwordSalt);
        modelBuilder.Entity<ApiUser>().HasData(

             new ApiUser
             {
                 Id = 1,
                 Email = "admin@admin.com",
                 PasswordHash = new byte[] { 104, 136, 143, 19, 91, 5, 225, 182, 216, 68, 5, 115, 218, 150, 94, 159, 191, 141, 248, 163, 232, 71, 30, 153, 214, 80, 47, 192, 8, 145, 71, 249, 190, 24, 27, 7, 106, 166, 118, 135, 165, 169, 143, 163, 31, 23, 152, 100, 79, 110, 228, 225, 240, 16, 200, 173, 29, 142, 211, 253, 255, 82, 16, 97 },
                 PasswordSalt = new byte[] { 218, 41, 250, 3, 4, 72, 102, 113, 5, 134, 173, 68, 162, 218, 93, 198, 22, 180, 85, 173, 60, 242, 199, 254, 97, 8, 94, 144, 125, 214, 128, 39, 177, 255, 224, 218, 108, 38, 245, 243, 208, 203, 91, 11, 188, 249, 129, 161, 190, 87, 63, 83, 182, 112, 60, 6, 67, 66, 212, 55, 15, 25, 215, 50, 151, 219, 194, 22, 135, 232, 14, 178, 85, 175, 251, 202, 48, 67, 113, 113, 244, 107, 166, 193, 218, 172, 218, 137, 186, 116, 223, 232, 123, 148, 173, 121, 208, 147, 24, 133, 241, 42, 170, 40, 235, 98, 222, 132, 241, 72, 80, 43, 36, 132, 98, 218, 150, 169, 10, 230, 247, 28, 52, 138, 249, 206, 233, 59 }
             }
         );

        modelBuilder.Entity<DashboardUser>().HasData(
        new DashboardUser
        {
            Id = 1,
            Email = "admin@admin.com",
            Name = "Admin",
            PasswordHash = new byte[] { 104, 136, 143, 19, 91, 5, 225, 182, 216, 68, 5, 115, 218, 150, 94, 159, 191, 141, 248, 163, 232, 71, 30, 153, 214, 80, 47, 192, 8, 145, 71, 249, 190, 24, 27, 7, 106, 166, 118, 135, 165, 169, 143, 163, 31, 23, 152, 100, 79, 110, 228, 225, 240, 16, 200, 173, 29, 142, 211, 253, 255, 82, 16, 97 },
            PasswordSalt = new byte[] { 218, 41, 250, 3, 4, 72, 102, 113, 5, 134, 173, 68, 162, 218, 93, 198, 22, 180, 85, 173, 60, 242, 199, 254, 97, 8, 94, 144, 125, 214, 128, 39, 177, 255, 224, 218, 108, 38, 245, 243, 208, 203, 91, 11, 188, 249, 129, 161, 190, 87, 63, 83, 182, 112, 60, 6, 67, 66, 212, 55, 15, 25, 215, 50, 151, 219, 194, 22, 135, 232, 14, 178, 85, 175, 251, 202, 48, 67, 113, 113, 244, 107, 166, 193, 218, 172, 218, 137, 186, 116, 223, 232, 123, 148, 173, 121, 208, 147, 24, 133, 241, 42, 170, 40, 235, 98, 222, 132, 241, 72, 80, 43, 36, 132, 98, 218, 150, 169, 10, 230, 247, 28, 52, 138, 249, 206, 233, 59 },
            IsSuperAdmin = true,

        }
    );
        modelBuilder.Entity<CameraTbl>(entity =>
        {
            entity.HasKey(e => e.CamId);

            entity.ToTable("Camera_TBL");

            entity.Property(e => e.CamId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("CamID");
            entity.Property(e => e.CamIp)
                .IsUnicode(true)
                .HasColumnName("CamIP");
            entity.Property(e => e.CamModel)
                .HasMaxLength(50)
                .IsUnicode(true);
            entity.Property(e => e.CamName).IsUnicode(true);
            entity.Property(e => e.CamPassword)
                .HasMaxLength(50)
                .IsUnicode(true);
            entity.Property(e => e.CamUsername)
                .HasMaxLength(50)
                .IsUnicode(true);
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");

            entity.HasOne(d => d.Site).WithMany(p => p.CameraTbls)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Camera_TBL_Site_TBL");
        });

        modelBuilder.Entity<ComScreenSetting>(entity =>
        {
            entity.HasKey(e => e.ComId);

            entity.ToTable("COM_SCREEN_SETTING");

            entity.Property(e => e.ComId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(20, 0)")
                .HasColumnName("COM_ID");
            entity.Property(e => e.Bps).HasColumnName("BPS");
            entity.Property(e => e.ComName)
                .HasMaxLength(50)
                .HasColumnName("COM_NAME");
            entity.Property(e => e.Db).HasColumnName("DB");
            entity.Property(e => e.Hdsh)
                .HasMaxLength(50)
                .HasColumnName("HDSH");
            entity.Property(e => e.Parity)
                .HasMaxLength(50)
                .HasColumnName("PARITY");
            entity.Property(e => e.Sb).HasColumnName("SB");
            entity.Property(e => e.Send)
                .HasMaxLength(50)
                .HasColumnName("SEND");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("SITE_ID");
            entity.Property(e => e.Sstart)
                .HasMaxLength(50)
                .HasColumnName("SStart");

            entity.HasOne(d => d.Site).WithMany(p => p.ComScreenSettings)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COM_SCREEN_SETTING_Site_TBL");
        });

        modelBuilder.Entity<ComSettingTbl>(entity =>
        {
            entity.HasKey(e => e.ComId).HasName("PK_COM_SETTING_TBL_1");

            entity.ToTable("COM_SETTING_TBL");

            entity.Property(e => e.ComId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(20, 0)")
                .HasColumnName("COM_ID");
            entity.Property(e => e.Bps).HasColumnName("BPS");
            entity.Property(e => e.ComName)
                .HasMaxLength(50)
                .HasColumnName("COM_NAME");
            entity.Property(e => e.Db).HasColumnName("DB");
            entity.Property(e => e.Hdsh)
                .HasMaxLength(50)
                .HasColumnName("HDSH");
            entity.Property(e => e.Parity)
                .HasMaxLength(50)
                .HasColumnName("PARITY");
            entity.Property(e => e.Sb).HasColumnName("SB");
            entity.Property(e => e.Send)
                .HasMaxLength(50)
                .HasColumnName("SEND");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("SITE_ID");
            entity.Property(e => e.Sstart)
                .HasMaxLength(50)
                .HasColumnName("SStart");

            entity.HasOne(d => d.Site).WithMany(p => p.ComSettingTbls)
                .HasForeignKey(d => d.SiteId)
                .HasConstraintName("FK_COM_SETTING_TBL_Site_TBL");
        });

        modelBuilder.Entity<DriversTbl>(entity =>
        {
            entity.HasKey(e => e.DriverId);

            entity.ToTable("Drivers_TBL");

            entity.Property(e => e.DriverId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Driver_ID");
            entity.Property(e => e.DriverCode)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Driver_Code");
            entity.Property(e => e.DriverName)
                .HasMaxLength(200)
                .IsUnicode(true)
                .HasColumnName("Driver_Name");
            entity.Property(e => e.DriverState).HasColumnName("Driver_State");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");

            entity.HasOne(d => d.Site).WithMany(p => p.DriversTbls)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Drivers_TBL_Site_TBL");
        });

        modelBuilder.Entity<LogTbl>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("Log_TBL");

            entity.Property(e => e.LogId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Log_ID");
            entity.Property(e => e.LogCode)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Log_Code");
            entity.Property(e => e.LogDate).HasColumnName("Log_Date");
            entity.Property(e => e.LogName)
                .IsUnicode(true)
                .HasColumnName("Log_Name");
            entity.Property(e => e.LogTime).HasColumnName("Log_Time");
            entity.Property(e => e.LogTrans)
                .IsUnicode(true)
                .HasColumnName("Log_Trans");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");
            entity.Property(e => e.UserId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("User_ID");

            entity.HasOne(d => d.Site).WithMany(p => p.LogTbls)
                .HasForeignKey(d => d.SiteId)
                .HasConstraintName("FK_Log_TBL_Site_TBL");

            entity.HasOne(d => d.User).WithMany(p => p.LogTbls)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Log_TBL_Users_TBL");
        });

        modelBuilder.Entity<NationTbl>(entity =>
        {
            entity.HasKey(e => e.NationId);

            entity.ToTable("Nation_TBL");

            entity.Property(e => e.NationId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Nation_ID");
            entity.Property(e => e.NationCode)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Nation_Code");
            entity.Property(e => e.NationName)
                .HasMaxLength(200)
                .IsUnicode(true)
                .HasColumnName("Nation_Name");
            entity.Property(e => e.NationState).HasColumnName("Nation_State");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");

            entity.HasOne(d => d.Site).WithMany(p => p.NationTbls)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Nation_TBL_Site_TBL");
        });

        modelBuilder.Entity<PicturesTbl>(entity =>
        {
            entity.HasKey(e => e.PicId);

            entity.ToTable("Pictures_TBL");

            entity.HasIndex(e => e.PicDate, "NonClusteredIndex-20241209-112232");

            entity.HasIndex(e => new { e.PicId, e.PicTruckId }, "Pic_IDTruck_ID_INDEX").IsUnique();

            entity.Property(e => e.PicId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Pic_ID");
            entity.Property(e => e.PicCamera)
                .IsUnicode(true)
                .HasColumnName("Pic_Camera");
            entity.Property(e => e.PicDate).HasColumnName("Pic_date");
            entity.Property(e => e.PicImage)
                .IsUnicode(true)
                .HasColumnName("Pic_Image");
            entity.Property(e => e.PicState).HasColumnName("Pic_State");
            entity.Property(e => e.PicTime).HasColumnName("Pic_Time");
            entity.Property(e => e.PicTruckId)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("Pic_Truck_ID");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");

            entity.HasOne(d => d.Site).WithMany(p => p.PicturesTbls)
                .HasForeignKey(d => d.SiteId)
                .HasConstraintName("FK_Pictures_TBL_Site_TBL");
        });

        modelBuilder.Entity<ProductsTbl>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("Products_TBL");

            entity.Property(e => e.ProductId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Product_ID");
            entity.Property(e => e.ProductCode)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Product_Code");
            entity.Property(e => e.ProductLocation)
                .IsUnicode(true)
                .HasColumnName("Product_Location");
            entity.Property(e => e.ProductName)
                .HasMaxLength(200)
                .IsUnicode(true)
                .HasColumnName("Product_Name");
            entity.Property(e => e.ProductState).HasColumnName("Product_State");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");

            entity.HasOne(d => d.Site).WithMany(p => p.ProductsTbls)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Products_TBL_Site_TBL");
        });

        modelBuilder.Entity<SettingTbl>(entity =>
        {
            entity.ToTable("Setting_TBL");

            entity.Property(e => e.Id)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ID");
            entity.Property(e => e.Cprinter)
                .IsUnicode(true)
                .HasColumnName("CPrinter");
            entity.Property(e => e.Indecator).IsUnicode(true);
            entity.Property(e => e.Name).IsUnicode(true);
            entity.Property(e => e.Note).IsUnicode(true);
            entity.Property(e => e.Rprinter)
                .IsUnicode(true)
                .HasColumnName("RPrinter");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");
            entity.Property(e => e.Title).IsUnicode(true);

            entity.HasOne(d => d.Site).WithMany(p => p.SettingTbls)
                .HasForeignKey(d => d.SiteId)
                .HasConstraintName("FK_Setting_TBL_Site_TBL");
        });

        modelBuilder.Entity<SiteTbl>(entity =>
        {
            entity.HasKey(e => e.SiteId);

            entity.ToTable("Site_TBL");

            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");
            entity.Property(e => e.SiteCode)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_Code");
            entity.Property(e => e.SiteLocation)
                .IsUnicode(true)
                .HasColumnName("Site_Location");
            entity.Property(e => e.SiteName)
                .IsUnicode(true)
                .HasColumnName("Site_Name");
            entity.Property(e => e.SiteState).HasColumnName("Site_State");
            entity.Property(e => e.SiteTitle)
                .IsUnicode(true)
                .HasColumnName("Site_Title");
        });

        modelBuilder.Entity<TrucksTbl>(entity =>
        {
            entity.HasKey(e => e.TruckNum);

            entity.ToTable("Trucks_TBL");

            entity.Property(e => e.TruckNum)
                .HasMaxLength(200)
                .IsUnicode(true)
                .HasColumnName("Truck_Num");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");
            entity.Property(e => e.TruckCode)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Truck_Code");
            entity.Property(e => e.TruckId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Truck_ID");
            entity.Property(e => e.TruckState).HasColumnName("Truck_State");

            entity.HasOne(d => d.Site).WithMany(p => p.TrucksTbls)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Trucks_TBL_Site_TBL");
        });

        modelBuilder.Entity<UserPSettingTbl>(entity =>
        {
            entity.HasKey(e => e.UserPId);

            entity.ToTable("USER_P_Setting_TBL");

            entity.Property(e => e.UserPId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("USER_P_ID");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");
            entity.Property(e => e.UserPCode)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("USER_P_Code");
            entity.Property(e => e.UserPForm)
                .IsUnicode(true)
                .HasColumnName("USER_P_Form");
            entity.Property(e => e.UserPName1)
                .IsUnicode(true)
                .HasColumnName("USER_P_Name1");
            entity.Property(e => e.UserPName2)
                .IsUnicode(true)
                .HasColumnName("USER_P_Name2");
            entity.Property(e => e.UserPNote)
                .IsUnicode(true)
                .HasColumnName("USER_P_Note");
            entity.Property(e => e.UserPState).HasColumnName("USER_P_State");
        });

        modelBuilder.Entity<UsersPerTbl>(entity =>
        {
            entity.HasKey(e => e.UpId);

            entity.ToTable("Users_Per_TBL");

            entity.Property(e => e.UpId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("UP_ID");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");
            entity.Property(e => e.UpCode)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("UP_Code");
            entity.Property(e => e.UpNote)
                .IsUnicode(true)
                .HasColumnName("UP_Note");
            entity.Property(e => e.UpState).HasColumnName("UP_State");
            entity.Property(e => e.UserId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("User_ID");
            entity.Property(e => e.UserPId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("USER_P_ID");

            entity.HasOne(d => d.Site).WithMany(p => p.UsersPerTbls)
                .HasForeignKey(d => d.SiteId)
                .HasConstraintName("FK_Users_Per_TBL_Site_TBL");

            entity.HasOne(d => d.User).WithMany(p => p.UsersPerTbls)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Users_Per_TBL_Users_TBL");

            entity.HasOne(d => d.UserP).WithMany(p => p.UsersPerTbls)
                .HasForeignKey(d => d.UserPId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Users_Per_TBL_USER_P_Setting_TBL");
        });

        modelBuilder.Entity<UsersTbl>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("Users_TBL");

            entity.Property(e => e.UserId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("User_ID");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");
            entity.Property(e => e.UserCode)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("User_Code");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("User_Name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("User_Password");
            entity.Property(e => e.UserState).HasColumnName("User_State");
            entity.Property(e => e.UserType)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("User_Type");

            entity.HasOne(d => d.Site).WithMany(p => p.UsersTbls)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Users_TBL_Site_TBL");
        });

        modelBuilder.Entity<WeightClassTbl>(entity =>
        {
            entity.HasKey(e => e.WClassId);

            entity.ToTable("Weight_Class_TBL");

            entity.Property(e => e.WClassId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("W_Class_ID");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");
            entity.Property(e => e.WClassAxles).HasColumnName("W_Class_Axles");
            entity.Property(e => e.WClassCode)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("W_Class_Code");
            entity.Property(e => e.WClassImage)
                .IsUnicode(true)
                .HasColumnName("W_Class_Image");
            entity.Property(e => e.WClassName)
                .HasMaxLength(200)
                .IsUnicode(true)
                .HasColumnName("W_Class_Name");
            entity.Property(e => e.WClassState).HasColumnName("W_Class_State");
            entity.Property(e => e.WClassWeight).HasColumnName("W_Class_Weight");

            entity.HasOne(d => d.Site).WithMany(p => p.WeightClassTbls)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Weight_Class_TBL_Site_TBL");
        });

        modelBuilder.Entity<WeightTbl>(entity =>
        {
            entity.HasKey(e => e.WId);

            entity.ToTable("Weight_TBL");

            entity.HasIndex(e => e.InDate, "IN_DATE_INDEX");

            entity.HasIndex(e => e.SiteId, "SITE_ID_INDEX");

            entity.Property(e => e.WId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("W_ID");
            entity.Property(e => e.ClassWeight)
                .HasDefaultValue(0)
                .HasColumnName("Class_Weight");
            entity.Property(e => e.DiffWeight)
                .HasDefaultValue(0)
                .HasColumnName("Diff_Weight");
            entity.Property(e => e.DriverId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Driver_ID");
            entity.Property(e => e.InDate).HasColumnName("In_Date");
            entity.Property(e => e.InTime).HasColumnName("In_Time");
            entity.Property(e => e.NationId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Nation_ID");
            entity.Property(e => e.ProductId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Product_ID");
            entity.Property(e => e.SeqNo)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("SEQ_NO");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");
            entity.Property(e => e.TruckNum)
                .HasMaxLength(200)
                .IsUnicode(true)
                .HasColumnName("Truck_Num");
            entity.Property(e => e.TruckWeight)
                .HasDefaultValue(0)
                .HasColumnName("Truck_Weight");
            entity.Property(e => e.UserId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("User_ID");
            entity.Property(e => e.VioPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Vio_Price");
            entity.Property(e => e.VioWeight)
                .HasDefaultValue(0)
                .HasColumnName("Vio_Weight");
            entity.Property(e => e.WClassId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("W_Class_ID");
            entity.Property(e => e.WeightLocation).HasColumnName("Weight_Location");
            entity.Property(e => e.WeightNote)
                .IsUnicode(true)
                .HasColumnName("Weight_Note");
            entity.Property(e => e.WeightS)
                .IsUnicode(true)
                .HasColumnName("Weight_S");
            entity.Property(e => e.WeightState).HasColumnName("Weight_State");

            entity.HasOne(d => d.Driver).WithMany(p => p.WeightTbls)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK_Weight_TBL_Drivers_TBL");

            entity.HasOne(d => d.Nation).WithMany(p => p.WeightTbls)
                .HasForeignKey(d => d.NationId)
                .HasConstraintName("FK_Weight_TBL_Nation_TBL");

            entity.HasOne(d => d.Product).WithMany(p => p.WeightTbls)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Weight_TBL_Products_TBL");

            entity.HasOne(d => d.Site).WithMany(p => p.WeightTbls)
                .HasForeignKey(d => d.SiteId)
                .HasConstraintName("FK_Weight_TBL_Site_TBL");

            entity.HasOne(d => d.TruckNumNavigation).WithMany(p => p.WeightTbls)
                .HasForeignKey(d => d.TruckNum)
                .HasConstraintName("FK_Weight_TBL_Trucks_TBL");

            entity.HasOne(d => d.User).WithMany(p => p.WeightTbls)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Weight_TBL_Users_TBL");

            entity.HasOne(d => d.WClass).WithMany(p => p.WeightTbls)
                .HasForeignKey(d => d.WClassId)
                .HasConstraintName("FK_Weight_TBL_Weight_Class_TBL");
        });

        modelBuilder.Entity<WeightTicketTbl>(entity =>
        {
            entity.HasKey(e => e.WTicketId);

            entity.ToTable("Weight_Ticket_TBL");

            entity.Property(e => e.WTicketId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("W_Ticket_ID");
            entity.Property(e => e.SiteId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Site_ID");
            entity.Property(e => e.WTicketEnd).HasColumnName("W_Ticket_End");
            entity.Property(e => e.WTicketName)
                .IsUnicode(true)
                .HasColumnName("W_Ticket_Name");
            entity.Property(e => e.WTicketPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("W_Ticket_Price");
            entity.Property(e => e.WTicketStart).HasColumnName("W_Ticket_Start");
            entity.Property(e => e.WTicketState).HasColumnName("W_Ticket_State");

            entity.HasOne(d => d.Site).WithMany(p => p.WeightTicketTbls)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Weight_Ticket_TBL_Site_TBL");
        });
        OnModelCreatingPartial(modelBuilder);

    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
