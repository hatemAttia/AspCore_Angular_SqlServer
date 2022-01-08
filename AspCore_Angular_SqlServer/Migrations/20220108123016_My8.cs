using Microsoft.EntityFrameworkCore.Migrations;

namespace AspCore_Angular_SqlServer.Migrations
{
    public partial class My8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Tel = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eleve",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    nom = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    prenom = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    niveau = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    tel = table.Column<int>(nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    image = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleve", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    nom = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    prenom = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    tel = table.Column<int>(nullable: false),
                    specialite = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    image = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    title = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niveau",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    title = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    sectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveau", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Niveau_ToTable",
                        column: x => x.sectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matiere",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    title = table.Column<string>(fixedLength: true, maxLength: 200, nullable: false),
                    niveauId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_ToTable_1",
                        column: x => x.niveauId,
                        principalTable: "Niveau",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chapitre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    title = table.Column<string>(fixedLength: true, maxLength: 200, nullable: false),
                    matiereId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapitre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chapitre_ToTable_1",
                        column: x => x.matiereId,
                        principalTable: "Matiere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    titre = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    descrption = table.Column<string>(type: "text", nullable: false),
                    Prix = table.Column<float>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    chapitreId = table.Column<int>(nullable: true),
                    ensegnantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_ToTable",
                        column: x => x.chapitreId,
                        principalTable: "chapitre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lesson_ToTable2",
                        column: x => x.ensegnantId,
                        principalTable: "Enseignant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    title = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    lessonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_ToTable",
                        column: x => x.lessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lesson_Eleve",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    eleveId = table.Column<int>(nullable: true),
                    lessonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson_Eleve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_Eleve_ToTable",
                        column: x => x.eleveId,
                        principalTable: "Eleve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lesson_Eleve_ToTable_1",
                        column: x => x.lessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    title = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    descrption = table.Column<string>(type: "text", nullable: false),
                    lessonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_ToTable",
                        column: x => x.lessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chapitre_matiereId",
                table: "chapitre",
                column: "matiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_lessonId",
                table: "Document",
                column: "lessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_chapitreId",
                table: "Lesson",
                column: "chapitreId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_ensegnantId",
                table: "Lesson",
                column: "ensegnantId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_Eleve_eleveId",
                table: "Lesson_Eleve",
                column: "eleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_Eleve_lessonId",
                table: "Lesson_Eleve",
                column: "lessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_niveauId",
                table: "Matiere",
                column: "niveauId");

            migrationBuilder.CreateIndex(
                name: "IX_Niveau_sectionId",
                table: "Niveau",
                column: "sectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_lessonId",
                table: "Video",
                column: "lessonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Lesson_Eleve");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Eleve");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "chapitre");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "Matiere");

            migrationBuilder.DropTable(
                name: "Niveau");

            migrationBuilder.DropTable(
                name: "Section");
        }
    }
}
