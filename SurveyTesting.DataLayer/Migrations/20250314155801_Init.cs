using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurveyTesting.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeleteDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SurveyId = table.Column<int>(type: "integer", nullable: false),
                    PassingDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CompletionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeleteDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interviews_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    SurveyId = table.Column<int>(type: "integer", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeleteDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeleteDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InterviewId = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    AnswerId = table.Column<int>(type: "integer", nullable: true),
                    AnswerText = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeleteDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Results_Interviews_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "CreateDateTime", "DeleteDateTime", "Description", "Name", "UpdateDateTime" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9723), new TimeSpan(0, 0, 0, 0, 0)), null, "Описание примера анкеты", "Пример анкеты", null });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreateDateTime", "DeleteDateTime", "Order", "SurveyId", "Text", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9837), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 1, "В каком регионе Вы проживаете?", null },
                    { 2, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9840), new TimeSpan(0, 0, 0, 0, 0)), null, 2, 1, "Сколько вам лет?", null },
                    { 3, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9841), new TimeSpan(0, 0, 0, 0, 0)), null, 3, 1, "Готовы к переезду?", null }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "CreateDateTime", "DeleteDateTime", "Order", "QuestionId", "Text", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9855), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 1, "Москва", null },
                    { 2, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9857), new TimeSpan(0, 0, 0, 0, 0)), null, 2, 1, "Московская область", null },
                    { 3, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9858), new TimeSpan(0, 0, 0, 0, 0)), null, 3, 1, "Санкт-Петербург", null },
                    { 4, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9859), new TimeSpan(0, 0, 0, 0, 0)), null, 4, 1, "Ленинградская область", null },
                    { 5, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9860), new TimeSpan(0, 0, 0, 0, 0)), null, 5, 1, "Рязанская область", null },
                    { 6, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9861), new TimeSpan(0, 0, 0, 0, 0)), null, 6, 1, "Владимирская область", null },
                    { 7, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9862), new TimeSpan(0, 0, 0, 0, 0)), null, 7, 1, "Тульская область", null },
                    { 8, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9863), new TimeSpan(0, 0, 0, 0, 0)), null, 8, 1, "Другой регион", null },
                    { 9, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9879), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 2, "18-30", null },
                    { 10, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9880), new TimeSpan(0, 0, 0, 0, 0)), null, 2, 2, "30-45", null },
                    { 11, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9881), new TimeSpan(0, 0, 0, 0, 0)), null, 3, 2, "45-60", null },
                    { 12, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9882), new TimeSpan(0, 0, 0, 0, 0)), null, 4, 2, "60-70", null },
                    { 13, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9883), new TimeSpan(0, 0, 0, 0, 0)), null, 5, 2, "Старше 70", null },
                    { 14, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9894), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 3, "Да", null },
                    { 15, new DateTimeOffset(new DateTime(2025, 3, 14, 15, 58, 0, 959, DateTimeKind.Unspecified).AddTicks(9895), new TimeSpan(0, 0, 0, 0, 0)), null, 2, 3, "Нет", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Id_QuestionId",
                table: "Answers",
                columns: new[] { "Id", "QuestionId" });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_Id_UserId_SurveyId",
                table: "Interviews",
                columns: new[] { "Id", "UserId", "SurveyId" });

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_SurveyId",
                table: "Interviews",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Id_SurveyId",
                table: "Questions",
                columns: new[] { "Id", "SurveyId" });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_AnswerId",
                table: "Results",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_Id_InterviewId_QuestionId",
                table: "Results",
                columns: new[] { "Id", "InterviewId", "QuestionId" });

            migrationBuilder.CreateIndex(
                name: "IX_Results_InterviewId",
                table: "Results",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_QuestionId",
                table: "Results",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_Id_Name",
                table: "Surveys",
                columns: new[] { "Id", "Name" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
