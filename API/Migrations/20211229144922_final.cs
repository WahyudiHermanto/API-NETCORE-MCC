using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_m_employee",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_m_employee", x => x.NIK);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rolename = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_m_university",
                columns: table => new
                {
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_m_university", x => x.UniversityId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_m_account",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    OTP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_m_account", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_Tb_m_account_Tb_m_employee_NIK",
                        column: x => x.NIK,
                        principalTable: "Tb_m_employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_m_education",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<float>(type: "real", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_m_education", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Tb_m_education_Tb_m_university_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Tb_m_university",
                        principalColumn: "UniversityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_tr_accountrole",
                columns: table => new
                {
                    AccountRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_tr_accountrole", x => x.AccountRoleId);
                    table.ForeignKey(
                        name: "FK_Tb_tr_accountrole_Tb_m_account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Tb_m_account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_tr_accountrole_tb_m_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tb_m_role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_tr_profilling",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_tr_profilling", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_Tb_tr_profilling_Tb_m_account_NIK",
                        column: x => x.NIK,
                        principalTable: "Tb_m_account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_tr_profilling_Tb_m_education_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Tb_m_education",
                        principalColumn: "EducationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_m_education_UniversityId",
                table: "Tb_m_education",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_tr_accountrole_AccountId",
                table: "Tb_tr_accountrole",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_tr_accountrole_RoleId",
                table: "Tb_tr_accountrole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_tr_profilling_EducationId",
                table: "Tb_tr_profilling",
                column: "EducationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_tr_accountrole");

            migrationBuilder.DropTable(
                name: "Tb_tr_profilling");

            migrationBuilder.DropTable(
                name: "tb_m_role");

            migrationBuilder.DropTable(
                name: "Tb_m_account");

            migrationBuilder.DropTable(
                name: "Tb_m_education");

            migrationBuilder.DropTable(
                name: "Tb_m_employee");

            migrationBuilder.DropTable(
                name: "Tb_m_university");
        }
    }
}
