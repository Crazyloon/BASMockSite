using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace BASMockSite.Migrations
{
    public partial class UpdateApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Degree_College_CollegeID", table: "Degree");
            migrationBuilder.DropForeignKey(name: "FK_Degree_ProgramManager_ProgramManagerID", table: "Degree");
            migrationBuilder.DropForeignKey(name: "FK_Image_College_CollegeID", table: "Image");
            migrationBuilder.DropForeignKey(name: "FK_ProgramEntry_Degree_DegreeID", table: "ProgramEntry");
            migrationBuilder.DropForeignKey(name: "FK_ProgramManager_College_CollegeID", table: "ProgramManager");
            migrationBuilder.DropForeignKey(name: "FK_ProgramStructure_ProgramEntry_ProgramEntryID", table: "ProgramStructure");
            migrationBuilder.DropForeignKey(name: "FK_BASMenu_ProgramManager_ManagerID", table: "BASMenu");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.AddColumn<int>(
                name: "BASManagerID",
                table: "AspNetUsers",
                nullable: true,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Degree_College_CollegeID",
                table: "Degree",
                column: "CollegeID",
                principalTable: "College",
                principalColumn: "CollegeID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Degree_ProgramManager_ProgramManagerID",
                table: "Degree",
                column: "ProgramManagerID",
                principalTable: "ProgramManager",
                principalColumn: "ManagerID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Image_College_CollegeID",
                table: "Image",
                column: "CollegeID",
                principalTable: "College",
                principalColumn: "CollegeID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ProgramEntry_Degree_DegreeID",
                table: "ProgramEntry",
                column: "DegreeID",
                principalTable: "Degree",
                principalColumn: "DegreeID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ProgramManager_College_CollegeID",
                table: "ProgramManager",
                column: "CollegeID",
                principalTable: "College",
                principalColumn: "CollegeID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ProgramStructure_ProgramEntry_ProgramEntryID",
                table: "ProgramStructure",
                column: "ProgramEntryID",
                principalTable: "ProgramEntry",
                principalColumn: "EntryID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_BASMenu_ProgramManager_ManagerID",
                table: "BASMenu",
                column: "ManagerID",
                principalTable: "ProgramManager",
                principalColumn: "ManagerID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Degree_College_CollegeID", table: "Degree");
            migrationBuilder.DropForeignKey(name: "FK_Degree_ProgramManager_ProgramManagerID", table: "Degree");
            migrationBuilder.DropForeignKey(name: "FK_Image_College_CollegeID", table: "Image");
            migrationBuilder.DropForeignKey(name: "FK_ProgramEntry_Degree_DegreeID", table: "ProgramEntry");
            migrationBuilder.DropForeignKey(name: "FK_ProgramManager_College_CollegeID", table: "ProgramManager");
            migrationBuilder.DropForeignKey(name: "FK_ProgramStructure_ProgramEntry_ProgramEntryID", table: "ProgramStructure");
            migrationBuilder.DropForeignKey(name: "FK_BASMenu_ProgramManager_ManagerID", table: "BASMenu");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "BASManagerID", table: "AspNetUsers");
            migrationBuilder.AddForeignKey(
                name: "FK_Degree_College_CollegeID",
                table: "Degree",
                column: "CollegeID",
                principalTable: "College",
                principalColumn: "CollegeID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Degree_ProgramManager_ProgramManagerID",
                table: "Degree",
                column: "ProgramManagerID",
                principalTable: "ProgramManager",
                principalColumn: "ManagerID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Image_College_CollegeID",
                table: "Image",
                column: "CollegeID",
                principalTable: "College",
                principalColumn: "CollegeID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ProgramEntry_Degree_DegreeID",
                table: "ProgramEntry",
                column: "DegreeID",
                principalTable: "Degree",
                principalColumn: "DegreeID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ProgramManager_College_CollegeID",
                table: "ProgramManager",
                column: "CollegeID",
                principalTable: "College",
                principalColumn: "CollegeID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ProgramStructure_ProgramEntry_ProgramEntryID",
                table: "ProgramStructure",
                column: "ProgramEntryID",
                principalTable: "ProgramEntry",
                principalColumn: "EntryID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_BASMenu_ProgramManager_ManagerID",
                table: "BASMenu",
                column: "ManagerID",
                principalTable: "ProgramManager",
                principalColumn: "ManagerID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
