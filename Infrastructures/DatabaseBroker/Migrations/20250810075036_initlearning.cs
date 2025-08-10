using System;
using System.Collections.Generic;
using Entity.Models.Common;
using Entity.Models.Learning;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseBroker.Migrations
{
    /// <inheritdoc />
    public partial class initlearning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "learning");

            migrationBuilder.CreateTable(
                name: "authors",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    image_link = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.id);
                    table.ForeignKey(
                        name: "FK_authors_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "auth",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<MultiLanguageField>(type: "jsonb", nullable: false),
                    description = table.Column<MultiLanguageField>(type: "jsonb", nullable: false),
                    image_link = table.Column<string>(type: "text", nullable: false),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quizzes",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    total_score = table.Column<decimal>(type: "numeric", nullable: false),
                    passing_score = table.Column<decimal>(type: "numeric", nullable: true),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    heart = table.Column<int>(type: "integer", nullable: false),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizzes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "test_contents",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content = table.Column<string>(type: "text", nullable: false),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_contents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "video_of_courses",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    link = table.Column<string>(type: "text", nullable: false),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_of_courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "articles",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.id);
                    table.ForeignKey(
                        name: "FK_articles_authors_author_id",
                        column: x => x.author_id,
                        principalSchema: "learning",
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articles_categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "learning",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    language_code = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_courses_authors_author_id",
                        column: x => x.author_id,
                        principalSchema: "learning",
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courses_categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "learning",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "seminar_videos",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    video_linc = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seminar_videos", x => x.id);
                    table.ForeignKey(
                        name: "FK_seminar_videos_authors_author_id",
                        column: x => x.author_id,
                        principalSchema: "learning",
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seminar_videos_categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "learning",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "short_videos",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    video_linc = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_short_videos", x => x.id);
                    table.ForeignKey(
                        name: "FK_short_videos_authors_author_id",
                        column: x => x.author_id,
                        principalSchema: "learning",
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_short_videos_categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "learning",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exams",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    close_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    used_heart = table.Column<int>(type: "integer", nullable: false),
                    quiz_id = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.id);
                    table.ForeignKey(
                        name: "FK_exams_quizzes_quiz_id",
                        column: x => x.quiz_id,
                        principalSchema: "learning",
                        principalTable: "quizzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_exams_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "auth",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quiz_id = table.Column<long>(type: "bigint", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    question_type = table.Column<int>(type: "integer", nullable: false),
                    question_content = table.Column<string>(type: "text", nullable: true),
                    image_link = table.Column<string>(type: "text", nullable: true),
                    doc_link = table.Column<string>(type: "text", nullable: true),
                    total_ball = table.Column<decimal>(type: "numeric", nullable: true),
                    options = table.Column<List<SimpleQuestionOption>>(type: "jsonb", nullable: true),
                    possible_answer = table.Column<string>(type: "text", nullable: true),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_questions_quizzes_quiz_id",
                        column: x => x.quiz_id,
                        principalSchema: "learning",
                        principalTable: "quizzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "modules",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    lesson_count = table.Column<int>(type: "integer", nullable: false),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    course_id = table.Column<long>(type: "bigint", nullable: false),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.id);
                    table.ForeignKey(
                        name: "FK_modules_courses_course_id",
                        column: x => x.course_id,
                        principalSchema: "learning",
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question_in_exams",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    exam_id = table.Column<long>(type: "bigint", nullable: false),
                    question_id = table.Column<long>(type: "bigint", nullable: false),
                    question_type = table.Column<int>(type: "integer", nullable: false),
                    selected = table.Column<Guid>(type: "uuid", nullable: true),
                    options = table.Column<List<SimpleQuestionOption>>(type: "jsonb", nullable: true),
                    written_answer = table.Column<string>(type: "text", nullable: true),
                    @checked = table.Column<bool>(name: "checked", type: "boolean", nullable: true),
                    accumulated_ball = table.Column<decimal>(type: "numeric", nullable: true),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question_in_exams", x => x.id);
                    table.ForeignKey(
                        name: "FK_question_in_exams_exams_exam_id",
                        column: x => x.exam_id,
                        principalSchema: "learning",
                        principalTable: "exams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_question_in_exams_questions_question_id",
                        column: x => x.question_id,
                        principalSchema: "learning",
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "course_items",
                schema: "learning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<byte>(type: "smallint", nullable: false),
                    docs_url = table.Column<List<string>>(type: "text[]", nullable: false),
                    module_id = table.Column<long>(type: "bigint", nullable: false),
                    quiz_id = table.Column<long>(type: "bigint", nullable: true),
                    video_of_course_id = table.Column<long>(type: "bigint", nullable: true),
                    text_content_id = table.Column<long>(type: "bigint", nullable: true),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_course_items_modules_module_id",
                        column: x => x.module_id,
                        principalSchema: "learning",
                        principalTable: "modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_items_quizzes_quiz_id",
                        column: x => x.quiz_id,
                        principalSchema: "learning",
                        principalTable: "quizzes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_course_items_test_contents_text_content_id",
                        column: x => x.text_content_id,
                        principalSchema: "learning",
                        principalTable: "test_contents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_course_items_video_of_courses_video_of_course_id",
                        column: x => x.video_of_course_id,
                        principalSchema: "learning",
                        principalTable: "video_of_courses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_articles_author_id",
                schema: "learning",
                table: "articles",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_articles_category_id",
                schema: "learning",
                table: "articles",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_authors_user_id",
                schema: "learning",
                table: "authors",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_course_items_module_id",
                schema: "learning",
                table: "course_items",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_course_items_quiz_id",
                schema: "learning",
                table: "course_items",
                column: "quiz_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_course_items_text_content_id",
                schema: "learning",
                table: "course_items",
                column: "text_content_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_course_items_video_of_course_id",
                schema: "learning",
                table: "course_items",
                column: "video_of_course_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_courses_author_id",
                schema: "learning",
                table: "courses",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_courses_category_id",
                schema: "learning",
                table: "courses",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_exams_quiz_id",
                schema: "learning",
                table: "exams",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_exams_user_id",
                schema: "learning",
                table: "exams",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_modules_course_id",
                schema: "learning",
                table: "modules",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_question_in_exams_exam_id",
                schema: "learning",
                table: "question_in_exams",
                column: "exam_id");

            migrationBuilder.CreateIndex(
                name: "IX_question_in_exams_question_id",
                schema: "learning",
                table: "question_in_exams",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_questions_quiz_id",
                schema: "learning",
                table: "questions",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_seminar_videos_author_id",
                schema: "learning",
                table: "seminar_videos",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_seminar_videos_category_id",
                schema: "learning",
                table: "seminar_videos",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_short_videos_author_id",
                schema: "learning",
                table: "short_videos",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_short_videos_category_id",
                schema: "learning",
                table: "short_videos",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles",
                schema: "learning");

            migrationBuilder.DropTable(
                name: "course_items",
                schema: "learning");

            migrationBuilder.DropTable(
                name: "question_in_exams",
                schema: "learning");

            migrationBuilder.DropTable(
                name: "seminar_videos",
                schema: "learning");

            migrationBuilder.DropTable(
                name: "short_videos",
                schema: "learning");

            migrationBuilder.DropTable(
                name: "modules",
                schema: "learning");

            migrationBuilder.DropTable(
                name: "test_contents",
                schema: "learning");

            migrationBuilder.DropTable(
                name: "video_of_courses",
                schema: "learning");

            migrationBuilder.DropTable(
                name: "exams",
                schema: "learning");

            migrationBuilder.DropTable(
                name: "questions",
                schema: "learning");

            migrationBuilder.DropTable(
                name: "courses",
                schema: "learning");

            migrationBuilder.DropTable(
                name: "quizzes",
                schema: "learning");

            migrationBuilder.DropTable(
                name: "authors",
                schema: "learning");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "learning");
        }
    }
}
