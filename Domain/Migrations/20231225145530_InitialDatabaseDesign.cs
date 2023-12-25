using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChocieQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR", nullable: false),
                    Difficulty = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Mark = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OptionA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectChoice = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChocieQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrueAndFalseQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR", nullable: false),
                    Difficulty = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Mark = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CorrectAnswer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueAndFalseQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    TotalMarks = table.Column<decimal>(type: "decimal(3,3)", precision: 3, scale: 3, nullable: false),
                    Term = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Level = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
                columns: table => new
                {
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => new { x.ExamId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamSolutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMarks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSolutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamSolutions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamSolutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<bool>(type: "bit", nullable: true),
                    Choice = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_ExamSolutions_ExamSolutionId",
                        column: x => x.ExamSolutionId,
                        principalTable: "ExamSolutions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_ExamSolutionId",
                table: "Answer",
                column: "ExamSolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_QuestionId",
                table: "ExamQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CategoryId",
                table: "Exams",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSolutions_ExamId",
                table: "ExamSolutions",
                column: "ExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "ExamQuestion");

            migrationBuilder.DropTable(
                name: "MultipleChocieQuestions");

            migrationBuilder.DropTable(
                name: "TrueAndFalseQuestions");

            migrationBuilder.DropTable(
                name: "ExamSolutions");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
