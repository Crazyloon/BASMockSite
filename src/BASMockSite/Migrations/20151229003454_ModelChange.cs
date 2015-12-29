using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace BASMockSite.Migrations
{
    public partial class ModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Degree_ProgramManager_ProgramManagerID", table: "Degree");
            migrationBuilder.DropForeignKey(name: "FK_Degree_School_SchoolID", table: "Degree");
            migrationBuilder.DropForeignKey(name: "FK_ProgramEntry_Degree_DegreeID", table: "ProgramEntry");
            migrationBuilder.DropForeignKey(name: "FK_ProgramStructure_ProgramEntry_ProgramEntrylID", table: "ProgramStructure");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "School",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Degree_ProgramManager_ProgramManagerID",
                table: "Degree",
                column: "ProgramManagerID",
                principalTable: "ProgramManager",
                principalColumn: "ManagerID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Degree_School_SchoolID",
                table: "Degree",
                column: "SchoolID",
                principalTable: "School",
                principalColumn: "SchoolID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ProgramEntry_Degree_DegreeID",
                table: "ProgramEntry",
                column: "DegreeID",
                principalTable: "Degree",
                principalColumn: "DegreeID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ProgramStructure_ProgramEntry_ProgramEntrylID",
                table: "ProgramStructure",
                column: "ProgramEntrylID",
                principalTable: "ProgramEntry",
                principalColumn: "EntryID",
                onDelete: ReferentialAction.Cascade);
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
            migrationBuilder.DropForeignKey(name: "FK_Degree_ProgramManager_ProgramManagerID", table: "Degree");
            migrationBuilder.DropForeignKey(name: "FK_Degree_School_SchoolID", table: "Degree");
            migrationBuilder.DropForeignKey(name: "FK_ProgramEntry_Degree_DegreeID", table: "ProgramEntry");
            migrationBuilder.DropForeignKey(name: "FK_ProgramStructure_ProgramEntry_ProgramEntrylID", table: "ProgramStructure");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "Logo", table: "School");
            migrationBuilder.AddForeignKey(
                name: "FK_Degree_ProgramManager_ProgramManagerID",
                table: "Degree",
                column: "ProgramManagerID",
                principalTable: "ProgramManager",
                principalColumn: "ManagerID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Degree_School_SchoolID",
                table: "Degree",
                column: "SchoolID",
                principalTable: "School",
                principalColumn: "SchoolID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ProgramEntry_Degree_DegreeID",
                table: "ProgramEntry",
                column: "DegreeID",
                principalTable: "Degree",
                principalColumn: "DegreeID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ProgramStructure_ProgramEntry_ProgramEntrylID",
                table: "ProgramStructure",
                column: "ProgramEntrylID",
                principalTable: "ProgramEntry",
                principalColumn: "EntryID",
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
