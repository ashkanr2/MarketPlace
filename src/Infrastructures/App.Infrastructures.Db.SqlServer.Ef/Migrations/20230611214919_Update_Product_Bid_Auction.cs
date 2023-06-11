using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructures.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class Update_Product_Bid_Auction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Bids",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_BidId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "BidId",
                table: "Auctions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "provinces",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldFixedLength: true,
                oldMaxLength: 30);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AuctionId",
                table: "Bids",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AuctionId",
                table: "Bids",
                column: "AuctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Auctions",
                table: "Bids",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Auctions",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_AuctionId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AuctionId",
                table: "Bids");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "provinces",
                type: "nvarchar(30)",
                fixedLength: true,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "BidId",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_BidId",
                table: "Auctions",
                column: "BidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Bids",
                table: "Auctions",
                column: "BidId",
                principalTable: "Bids",
                principalColumn: "Id");
        }
    }
}
