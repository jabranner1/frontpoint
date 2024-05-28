using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frontpoint.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Individuals",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Prefix = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                MiddleName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                TelephoneNumber = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                AddressLine1 = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                AddressLine2 = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                State = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                Zip = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                CreatedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                LastUpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                LastUpdatedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Individuals", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Individuals");
    }
}
