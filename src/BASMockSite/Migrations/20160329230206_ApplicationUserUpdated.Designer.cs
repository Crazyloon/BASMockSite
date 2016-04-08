using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using BASMockSite.Models;

namespace BASMockSite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160329230206_ApplicationUserUpdated")]
    partial class ApplicationUserUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BASMockSite.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("BASMockSite.Models.College", b =>
                {
                    b.Property<int>("CollegeID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Accredited");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("County")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 2000);

                    b.Property<string>("HomeWebAddress")
                        .IsRequired();

                    b.Property<byte[]>("Logo");

                    b.Property<string>("MainPhone")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<decimal>("Tuition");

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("CollegeID");
                });

            modelBuilder.Entity("BASMockSite.Models.Degree", b =>
                {
                    b.Property<int>("DegreeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdmissionsSummary")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("CollegeID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 2000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<int>("ProgramManagerID");

                    b.Property<string>("ProgramURL")
                        .IsRequired();

                    b.Property<int>("RequiredCredits");

                    b.HasKey("DegreeID");
                });

            modelBuilder.Entity("BASMockSite.Models.Image", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alt");

                    b.Property<string>("Caption");

                    b.Property<int>("CollegeID");

                    b.Property<string>("ImageURL")
                        .IsRequired();

                    b.Property<string>("Title");

                    b.HasKey("ImageID");
                });

            modelBuilder.Entity("BASMockSite.Models.ProgramEntry", b =>
                {
                    b.Property<int>("EntryID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ApplicationDeadline");

                    b.Property<int>("DegreeID");

                    b.Property<int>("Season");

                    b.HasKey("EntryID");
                });

            modelBuilder.Entity("BASMockSite.Models.ProgramManager", b =>
                {
                    b.Property<int>("ManagerID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CollegeID");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.HasKey("ManagerID");
                });

            modelBuilder.Entity("BASMockSite.Models.ProgramStructure", b =>
                {
                    b.Property<int>("ProgramStructureID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProgramDuration")
                        .IsRequired();

                    b.Property<int>("ProgramEntryID");

                    b.Property<int>("Structure");

                    b.HasKey("ProgramStructureID");
                });

            modelBuilder.Entity("BASMockSite.ViewModels.BASManagers.BASMenu", b =>
                {
                    b.Property<int>("ManagerID");

                    b.Property<int?>("CollegeCollegeID");

                    b.HasKey("ManagerID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("BASMockSite.Models.Degree", b =>
                {
                    b.HasOne("BASMockSite.Models.College")
                        .WithMany()
                        .HasForeignKey("CollegeID");

                    b.HasOne("BASMockSite.Models.ProgramManager")
                        .WithMany()
                        .HasForeignKey("ProgramManagerID");
                });

            modelBuilder.Entity("BASMockSite.Models.Image", b =>
                {
                    b.HasOne("BASMockSite.Models.College")
                        .WithMany()
                        .HasForeignKey("CollegeID");
                });

            modelBuilder.Entity("BASMockSite.Models.ProgramEntry", b =>
                {
                    b.HasOne("BASMockSite.Models.Degree")
                        .WithMany()
                        .HasForeignKey("DegreeID");
                });

            modelBuilder.Entity("BASMockSite.Models.ProgramManager", b =>
                {
                    b.HasOne("BASMockSite.Models.College")
                        .WithMany()
                        .HasForeignKey("CollegeID");
                });

            modelBuilder.Entity("BASMockSite.Models.ProgramStructure", b =>
                {
                    b.HasOne("BASMockSite.Models.ProgramEntry")
                        .WithMany()
                        .HasForeignKey("ProgramEntryID");
                });

            modelBuilder.Entity("BASMockSite.ViewModels.BASManagers.BASMenu", b =>
                {
                    b.HasOne("BASMockSite.Models.College")
                        .WithMany()
                        .HasForeignKey("CollegeCollegeID");

                    b.HasOne("BASMockSite.Models.ProgramManager")
                        .WithMany()
                        .HasForeignKey("ManagerID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BASMockSite.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BASMockSite.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("BASMockSite.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
