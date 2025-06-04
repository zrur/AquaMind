using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquaMind.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlertaUmidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Mensagem = table.Column<string>(type: "TEXT", nullable: true),
                    DataAlerta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Lido = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataLeitura = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Prioridade = table.Column<string>(type: "TEXT", nullable: false),
                    ZonaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertaUmidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bombas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: true),
                    Potencia = table.Column<decimal>(type: "TEXT", nullable: true),
                    Localizacao = table.Column<string>(type: "TEXT", nullable: true),
                    Ativa = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ligada = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataInstalacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataUltimaManutencao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ZonaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bombas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracaoZonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UmidadeMinima = table.Column<decimal>(type: "TEXT", nullable: false),
                    UmidadeMaxima = table.Column<decimal>(type: "TEXT", nullable: false),
                    TempoIrrigacao = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    IntervaloIrrigacao = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    IrrigacaoAutomatica = table.Column<bool>(type: "INTEGER", nullable: false),
                    NotificacaoEmail = table.Column<bool>(type: "INTEGER", nullable: false),
                    NotificacaoSMS = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataUltimaAlteracao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ZonaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoZonas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sigla = table.Column<string>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoAcaoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Acao = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Entidade = table.Column<string>(type: "TEXT", nullable: true),
                    EntidadeId = table.Column<int>(type: "INTEGER", nullable: true),
                    EnderecoIP = table.Column<string>(type: "TEXT", nullable: true),
                    UserAgent = table.Column<string>(type: "TEXT", nullable: true),
                    DataAcao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAcaoUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogAcaoBombas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Acao = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    DataAcao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioAcao = table.Column<string>(type: "TEXT", nullable: true),
                    Automatica = table.Column<bool>(type: "INTEGER", nullable: false),
                    BombaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogAcaoBombas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propriedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", nullable: true),
                    Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    CEP = table.Column<string>(type: "TEXT", nullable: true),
                    AreaTotal = table.Column<decimal>(type: "TEXT", nullable: true),
                    Ativa = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propriedades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistroSensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Unidade = table.Column<string>(type: "TEXT", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", nullable: true),
                    SensorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroSensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: true),
                    Localizacao = table.Column<string>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataInstalacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataUltimaLeitura = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ZonaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Area = table.Column<decimal>(type: "TEXT", nullable: true),
                    TipoCultura = table.Column<string>(type: "TEXT", nullable: true),
                    Ativa = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PropriedadeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertaUmidades");

            migrationBuilder.DropTable(
                name: "Bombas");

            migrationBuilder.DropTable(
                name: "ConfiguracaoZonas");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "HistoricoAcaoUsuarios");

            migrationBuilder.DropTable(
                name: "LogAcaoBombas");

            migrationBuilder.DropTable(
                name: "Propriedades");

            migrationBuilder.DropTable(
                name: "RegistroSensors");

            migrationBuilder.DropTable(
                name: "Sensores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Zonas");
        }
    }
}
