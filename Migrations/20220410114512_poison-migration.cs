using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoisonClassifierWebAPI.Migrations
{
    public partial class poisonmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AggregateStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AggregateStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DegreeImpacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeImpacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NatureImpacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupNameSG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupDescriptionSG = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureImpacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Origions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubGroup = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Output = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubstanceClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chapter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubGroup = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstanceClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganPath",
                columns: table => new
                {
                    OrgansId = table.Column<int>(type: "int", nullable: false),
                    PathsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganPath", x => new { x.OrgansId, x.PathsId });
                    table.ForeignKey(
                        name: "FK_OrganPath_Organs_OrgansId",
                        column: x => x.OrgansId,
                        principalTable: "Organs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganPath_Paths_PathsId",
                        column: x => x.PathsId,
                        principalTable: "Paths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Substances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubstanceClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Substances_SubstanceClasses_SubstanceClassId",
                        column: x => x.SubstanceClassId,
                        principalTable: "SubstanceClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndustrialVenoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubstanceId = table.Column<int>(type: "int", nullable: false),
                    NatureImpactId = table.Column<int>(type: "int", nullable: false),
                    DegreeImpactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustrialVenoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndustrialVenoms_DegreeImpacts_DegreeImpactId",
                        column: x => x.DegreeImpactId,
                        principalTable: "DegreeImpacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndustrialVenoms_NatureImpacts_NatureImpactId",
                        column: x => x.NatureImpactId,
                        principalTable: "NatureImpacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndustrialVenoms_Substances_SubstanceId",
                        column: x => x.SubstanceId,
                        principalTable: "Substances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalVenoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrigionId = table.Column<int>(type: "int", nullable: false),
                    AggregateStateId = table.Column<int>(type: "int", nullable: false),
                    NatureImpactId = table.Column<int>(type: "int", nullable: false),
                    SubstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalVenoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalVenoms_AggregateStates_AggregateStateId",
                        column: x => x.AggregateStateId,
                        principalTable: "AggregateStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalVenoms_NatureImpacts_NatureImpactId",
                        column: x => x.NatureImpactId,
                        principalTable: "NatureImpacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalVenoms_Origions_OrigionId",
                        column: x => x.OrigionId,
                        principalTable: "Origions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalVenoms_Substances_SubstanceId",
                        column: x => x.SubstanceId,
                        principalTable: "Substances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DegreeToxicities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndustrialVenomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeToxicities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DegreeToxicities_IndustrialVenoms_IndustrialVenomId",
                        column: x => x.IndustrialVenomId,
                        principalTable: "IndustrialVenoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndustrialVenomPath",
                columns: table => new
                {
                    IndustrialVenomsId = table.Column<int>(type: "int", nullable: false),
                    PathsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustrialVenomPath", x => new { x.IndustrialVenomsId, x.PathsId });
                    table.ForeignKey(
                        name: "FK_IndustrialVenomPath_IndustrialVenoms_IndustrialVenomsId",
                        column: x => x.IndustrialVenomsId,
                        principalTable: "IndustrialVenoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndustrialVenomPath_Paths_PathsId",
                        column: x => x.PathsId,
                        principalTable: "Paths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndustrialVenomSymptom",
                columns: table => new
                {
                    IndustrialVenomsId = table.Column<int>(type: "int", nullable: false),
                    SymptomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustrialVenomSymptom", x => new { x.IndustrialVenomsId, x.SymptomsId });
                    table.ForeignKey(
                        name: "FK_IndustrialVenomSymptom_IndustrialVenoms_IndustrialVenomsId",
                        column: x => x.IndustrialVenomsId,
                        principalTable: "IndustrialVenoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndustrialVenomSymptom_Symptoms_SymptomsId",
                        column: x => x.SymptomsId,
                        principalTable: "Symptoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalVenomSymptom",
                columns: table => new
                {
                    MedicalVenomsId = table.Column<int>(type: "int", nullable: false),
                    SymptomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalVenomSymptom", x => new { x.MedicalVenomsId, x.SymptomsId });
                    table.ForeignKey(
                        name: "FK_MedicalVenomSymptom_MedicalVenoms_MedicalVenomsId",
                        column: x => x.MedicalVenomsId,
                        principalTable: "MedicalVenoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalVenomSymptom_Symptoms_SymptomsId",
                        column: x => x.SymptomsId,
                        principalTable: "Symptoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DegreeToxicities_IndustrialVenomId",
                table: "DegreeToxicities",
                column: "IndustrialVenomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndustrialVenomPath_PathsId",
                table: "IndustrialVenomPath",
                column: "PathsId");

            migrationBuilder.CreateIndex(
                name: "IX_IndustrialVenoms_DegreeImpactId",
                table: "IndustrialVenoms",
                column: "DegreeImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_IndustrialVenoms_NatureImpactId",
                table: "IndustrialVenoms",
                column: "NatureImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_IndustrialVenoms_SubstanceId",
                table: "IndustrialVenoms",
                column: "SubstanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndustrialVenomSymptom_SymptomsId",
                table: "IndustrialVenomSymptom",
                column: "SymptomsId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalVenoms_AggregateStateId",
                table: "MedicalVenoms",
                column: "AggregateStateId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalVenoms_NatureImpactId",
                table: "MedicalVenoms",
                column: "NatureImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalVenoms_OrigionId",
                table: "MedicalVenoms",
                column: "OrigionId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalVenoms_SubstanceId",
                table: "MedicalVenoms",
                column: "SubstanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalVenomSymptom_SymptomsId",
                table: "MedicalVenomSymptom",
                column: "SymptomsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganPath_PathsId",
                table: "OrganPath",
                column: "PathsId");

            migrationBuilder.CreateIndex(
                name: "IX_Substances_SubstanceClassId",
                table: "Substances",
                column: "SubstanceClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DegreeToxicities");

            migrationBuilder.DropTable(
                name: "IndustrialVenomPath");

            migrationBuilder.DropTable(
                name: "IndustrialVenomSymptom");

            migrationBuilder.DropTable(
                name: "MedicalVenomSymptom");

            migrationBuilder.DropTable(
                name: "OrganPath");

            migrationBuilder.DropTable(
                name: "IndustrialVenoms");

            migrationBuilder.DropTable(
                name: "MedicalVenoms");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "Organs");

            migrationBuilder.DropTable(
                name: "Paths");

            migrationBuilder.DropTable(
                name: "DegreeImpacts");

            migrationBuilder.DropTable(
                name: "AggregateStates");

            migrationBuilder.DropTable(
                name: "NatureImpacts");

            migrationBuilder.DropTable(
                name: "Origions");

            migrationBuilder.DropTable(
                name: "Substances");

            migrationBuilder.DropTable(
                name: "SubstanceClasses");
        }
    }
}
