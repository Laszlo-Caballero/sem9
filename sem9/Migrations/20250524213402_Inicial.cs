using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sem9.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ASESOR",
                columns: table => new
                {
                    idAsesor = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    carrera = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ASESOR__A801FCE9550BEADD", x => x.idAsesor);
                });

            migrationBuilder.CreateTable(
                name: "ESTUDIANTE",
                columns: table => new
                {
                    idEstudiante = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    direccion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    carrera = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESTUDIAN__AEFFDBC50AAD64AA", x => x.idEstudiante);
                });

            migrationBuilder.CreateTable(
                name: "JURADO",
                columns: table => new
                {
                    idJurado = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    carrera = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JURADO__778A32DEAF695123", x => x.idJurado);
                });

            migrationBuilder.CreateTable(
                name: "PAGO_CARPETA",
                columns: table => new
                {
                    idPago = table.Column<int>(type: "int", nullable: false),
                    idEstudiante = table.Column<int>(type: "int", nullable: false),
                    metodoPago = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PAGO_CAR__BD2295AD2DB412E0", x => x.idPago);
                    table.ForeignKey(
                        name: "FK__PAGO_CARP__idEst__47DBAE45",
                        column: x => x.idEstudiante,
                        principalTable: "ESTUDIANTE",
                        principalColumn: "idEstudiante");
                });

            migrationBuilder.CreateTable(
                name: "TESIS",
                columns: table => new
                {
                    idTesis = table.Column<int>(type: "int", nullable: false),
                    idEstudiante = table.Column<int>(type: "int", nullable: false),
                    tipoTesis = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    lineaInvestigacion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    objetivo = table.Column<string>(type: "text", nullable: true),
                    fechaInicio = table.Column<DateOnly>(type: "date", nullable: true),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TESIS__2E2073ED92DF67BA", x => x.idTesis);
                    table.ForeignKey(
                        name: "FK__TESIS__idEstudia__3D5E1FD2",
                        column: x => x.idEstudiante,
                        principalTable: "ESTUDIANTE",
                        principalColumn: "idEstudiante");
                });

            migrationBuilder.CreateTable(
                name: "SOLICITUD_TESIS",
                columns: table => new
                {
                    idSolicitud = table.Column<int>(type: "int", nullable: false),
                    idPago = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SOLICITU__D801DDB8210A1D2F", x => x.idSolicitud);
                    table.ForeignKey(
                        name: "FK__SOLICITUD__idPag__4AB81AF0",
                        column: x => x.idPago,
                        principalTable: "PAGO_CARPETA",
                        principalColumn: "idPago");
                });

            migrationBuilder.CreateTable(
                name: "ASIGNAR_ASESOR",
                columns: table => new
                {
                    idAsignar = table.Column<int>(type: "int", nullable: false),
                    idTesis = table.Column<int>(type: "int", nullable: false),
                    idAsesor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ASIGNAR___8319E6556D1245BF", x => x.idAsignar);
                    table.ForeignKey(
                        name: "FK__ASIGNAR_A__idAse__44FF419A",
                        column: x => x.idAsesor,
                        principalTable: "ASESOR",
                        principalColumn: "idAsesor");
                    table.ForeignKey(
                        name: "FK__ASIGNAR_A__idTes__440B1D61",
                        column: x => x.idTesis,
                        principalTable: "TESIS",
                        principalColumn: "idTesis");
                });

            migrationBuilder.CreateTable(
                name: "ASIGNAR_ESTUDIANTE",
                columns: table => new
                {
                    idAsignacion = table.Column<int>(type: "int", nullable: false),
                    idTesis = table.Column<int>(type: "int", nullable: false),
                    idEstudiante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ASIGNAR___E17144781DF73DD8", x => x.idAsignacion);
                    table.ForeignKey(
                        name: "FK__ASIGNAR_E__idEst__412EB0B6",
                        column: x => x.idEstudiante,
                        principalTable: "ESTUDIANTE",
                        principalColumn: "idEstudiante");
                    table.ForeignKey(
                        name: "FK__ASIGNAR_E__idTes__403A8C7D",
                        column: x => x.idTesis,
                        principalTable: "TESIS",
                        principalColumn: "idTesis");
                });

            migrationBuilder.CreateTable(
                name: "SUSTENTACION_FINAL",
                columns: table => new
                {
                    idSustentacion = table.Column<int>(type: "int", nullable: false),
                    idTesis = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    modalidad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    calificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SUSTENTA__F5B1C0083188C7C2", x => x.idSustentacion);
                    table.ForeignKey(
                        name: "FK__SUSTENTAC__idTes__4D94879B",
                        column: x => x.idTesis,
                        principalTable: "TESIS",
                        principalColumn: "idTesis");
                });

            migrationBuilder.CreateTable(
                name: "ASIGNAR_JURADO",
                columns: table => new
                {
                    idAsignacion = table.Column<int>(type: "int", nullable: false),
                    idSustentacion = table.Column<int>(type: "int", nullable: false),
                    idJurado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ASIGNAR___E1714478BA6D2F3A", x => x.idAsignacion);
                    table.ForeignKey(
                        name: "FK__ASIGNAR_J__idJur__5165187F",
                        column: x => x.idJurado,
                        principalTable: "JURADO",
                        principalColumn: "idJurado");
                    table.ForeignKey(
                        name: "FK__ASIGNAR_J__idSus__5070F446",
                        column: x => x.idSustentacion,
                        principalTable: "SUSTENTACION_FINAL",
                        principalColumn: "idSustentacion");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNAR_ASESOR_idAsesor",
                table: "ASIGNAR_ASESOR",
                column: "idAsesor");

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNAR_ASESOR_idTesis",
                table: "ASIGNAR_ASESOR",
                column: "idTesis");

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNAR_ESTUDIANTE_idEstudiante",
                table: "ASIGNAR_ESTUDIANTE",
                column: "idEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNAR_ESTUDIANTE_idTesis",
                table: "ASIGNAR_ESTUDIANTE",
                column: "idTesis");

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNAR_JURADO_idJurado",
                table: "ASIGNAR_JURADO",
                column: "idJurado");

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNAR_JURADO_idSustentacion",
                table: "ASIGNAR_JURADO",
                column: "idSustentacion");

            migrationBuilder.CreateIndex(
                name: "IX_PAGO_CARPETA_idEstudiante",
                table: "PAGO_CARPETA",
                column: "idEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_SOLICITUD_TESIS_idPago",
                table: "SOLICITUD_TESIS",
                column: "idPago");

            migrationBuilder.CreateIndex(
                name: "IX_SUSTENTACION_FINAL_idTesis",
                table: "SUSTENTACION_FINAL",
                column: "idTesis");

            migrationBuilder.CreateIndex(
                name: "IX_TESIS_idEstudiante",
                table: "TESIS",
                column: "idEstudiante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASIGNAR_ASESOR");

            migrationBuilder.DropTable(
                name: "ASIGNAR_ESTUDIANTE");

            migrationBuilder.DropTable(
                name: "ASIGNAR_JURADO");

            migrationBuilder.DropTable(
                name: "SOLICITUD_TESIS");

            migrationBuilder.DropTable(
                name: "ASESOR");

            migrationBuilder.DropTable(
                name: "JURADO");

            migrationBuilder.DropTable(
                name: "SUSTENTACION_FINAL");

            migrationBuilder.DropTable(
                name: "PAGO_CARPETA");

            migrationBuilder.DropTable(
                name: "TESIS");

            migrationBuilder.DropTable(
                name: "ESTUDIANTE");
        }
    }
}
