using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using BASMockSite.Models;

namespace BASMockSite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20151222031819_ModelUpdateAgain")]
    partial class ModelUpdateAgain
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

            modelBuilder.Entity("BASMockSite.Models.CourseModel", b =>
                {
                    b.Property<int>("ModelID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DegreeDegreeID");

                    b.Property<int>("Structure");

                    b.HasKey("ModelID");
                });

            modelBuilder.Entity("BASMockSite.Models.Degree", b =>
                {
                    b.Property<int>("DegreeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ProgramDuration")
                        .IsRequired();

                    b.Property<int?>("ProgramManagerManagerID");

                    b.Property<string>("ProgramURL")
                        .IsRequired();

                    b.Property<int?>("SchoolSchoolID");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("DegreeID");
                });

            modelBuilder.Entity("BASMockSite.Models.ProgramEntry", b =>
                {
                    b.Property<int>("EntryID");

                    b.Property<DateTime>("ApplicationDeadline");

                    b.Property<string>("EntrySummary");

                    b.Property<int>("Season");

                    b.HasKey("EntryID");
                });

            modelBuilder.Entity("BASMockSite.Models.ProgramManager", b =>
                {
                    b.Property<int>("ManagerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<int?>("SchoolSchoolID");

                    b.HasKey("ManagerID");
                });

            modelBuilder.Entity("BASMockSite.Models.School", b =>
                {
                    b.Property<int>("SchoolID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Accredited");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("County")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("HomeWebAddress")
                        .IsRequired();

                    b.Property<string>("MainPhone")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<decimal>("Tuition");

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("SchoolID");
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

            modelBuilder.Entity("BASMockSite.Models.CourseModel", b =>
                {
                    b.HasOne("BASMockSite.Models.Degree")
                        .WithMany()
                        .HasForeignKey("DegreeDegreeID");
                });

            modelBuilder.Entity("BASMockSite.Models.Degree", b =>
                {
                    b.HasOne("BASMockSite.Models.ProgramManager")
                        .WithMany()
                        .HasForeignKey("ProgramManagerManagerID");

                    b.HasOne("BASMockSite.Models.School")
                        .WithMany()
                        .HasForeignKey("SchoolSchoolID");
                });

            modelBuilder.Entity("BASMockSite.Models.ProgramEntry", b =>
                {
                    b.HasOne("BASMockSite.Models.CourseModel")
                        .WithOne()
                        .HasForeignKey("BASMockSite.Models.ProgramEntry", "EntryID");
                });

            modelBuilder.Entity("BASMockSite.Models.ProgramManager", b =>
                {
                    b.HasOne("BASMockSite.Models.School")
                        .WithMany()
                        .HasForeignKey("SchoolSchoolID");
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
