﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorCondominios.DAL.Migrations
{
    public partial class criacaoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcoes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meses",
                columns: table => new
                {
                    MesId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meses", x => x.MesId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimeiroAcesso = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Funcoes_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Funcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alugueis",
                columns: table => new
                {
                    AluguelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MesId = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alugueis", x => x.AluguelId);
                    table.ForeignKey(
                        name: "FK_Alugueis_Meses_MesId",
                        column: x => x.MesId,
                        principalTable: "Meses",
                        principalColumn: "MesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoRecursos",
                columns: table => new
                {
                    HistoricoRecursosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    MesId = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoRecursos", x => x.HistoricoRecursosId);
                    table.ForeignKey(
                        name: "FK_HistoricoRecursos_Meses_MesId",
                        column: x => x.MesId,
                        principalTable: "Meses",
                        principalColumn: "MesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartamentos",
                columns: table => new
                {
                    ApartamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Andar = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoradorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProprietarioId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamentos", x => x.ApartamentoId);
                    table.ForeignKey(
                        name: "FK_Apartamentos_Usuarios_MoradorId",
                        column: x => x.MoradorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apartamentos_Usuarios_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Funcoes_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Funcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_Eventos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.ServicoId);
                    table.ForeignKey(
                        name: "FK_Servicos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.VeiculoId);
                    table.ForeignKey(
                        name: "FK_Veiculos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    PagamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AluguelId = table.Column<int>(type: "int", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.PagamentoId);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Alugueis_AluguelId",
                        column: x => x.AluguelId,
                        principalTable: "Alugueis",
                        principalColumn: "AluguelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicoPredios",
                columns: table => new
                {
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    ServicoPredioId = table.Column<int>(type: "int", nullable: false),
                    DataExecucao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoPredios", x => x.ServicoId);
                    table.ForeignKey(
                        name: "FK_ServicoPredios_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3412090d-2191-41b1-8ff3-03ee5dc9c249", "30f4baa4-341f-4611-84d6-9f6cb67bbf56", "Morador do Prédio", "Morador", "MORADOR" },
                    { "e31a34bb-edcf-4908-a9f3-945d08da0e31", "07ea5cdd-17b2-4dd5-a32b-071e5a021a68", "Sindico do Prédio", "Sindico", "SINDICO" },
                    { "5b18b4da-8420-4062-809c-d461f73ad10f", "b2f537c6-81a0-45a1-9652-93ccb2c0411d", "Administrador do Prédio", "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "Meses",
                columns: new[] { "MesId", "Nome" },
                values: new object[,]
                {
                    { 1, "Janeiro" },
                    { 2, "Fevereiro" },
                    { 3, "Março" },
                    { 4, "Abril" },
                    { 5, "Maio" },
                    { 6, "Junho" },
                    { 7, "Julho" },
                    { 8, "Agosto" },
                    { 9, "Setembro" },
                    { 10, "Outubro" },
                    { 11, "Novembro" },
                    { 12, "Dezembro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_MesId",
                table: "Alugueis",
                column: "MesId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_MoradorId",
                table: "Apartamentos",
                column: "MoradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_ProprietarioId",
                table: "Apartamentos",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UsuarioId",
                table: "Eventos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Funcoes",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoRecursos_MesId",
                table: "HistoricoRecursos",
                column: "MesId");

            migrationBuilder.CreateIndex(
                name: "IX_Meses_Nome",
                table: "Meses",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_AluguelId",
                table: "Pagamentos",
                column: "AluguelId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_UsuarioId",
                table: "Pagamentos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_UsuarioId",
                table: "Servicos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Usuarios",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CPF",
                table: "Usuarios",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Usuarios",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_Placa",
                table: "Veiculos",
                column: "Placa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_UsuarioId",
                table: "Veiculos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartamentos");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "HistoricoRecursos");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "ServicoPredios");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Funcoes");

            migrationBuilder.DropTable(
                name: "Alugueis");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Meses");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
