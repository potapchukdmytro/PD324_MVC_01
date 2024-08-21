using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PD324_01.Migrations
{
    /// <inheritdoc />
    public partial class adddataseeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Processors" },
                    { 2, "Videocards" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CatgoryId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "", "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcRC98q4Vog6E0ThvsYJZ9M4zQYc7dC-BPrOut3rXMOpAHCgdRd4wlG7b7Y2Ml30vh9ijbrRhVrhizkWlyfQRB2AzspjWn3WTg4muTZFkWA&usqp=CAE", "AMD Ryzen 5 5500U", 3700.0m },
                    { 2, 1, "", "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcTR0a-LCLAsE8kD7EyVZtQ4fWuOJFUr7om5GatUqr_LNAkbon0RnDxfWLE-uxZhFHuL_EWYtSRj3M5MTWlQsVymGKfBaDkbjBySMoIwj6qDdHa7xTmQOVD1&usqp=CAE", "intel core i9 14900k", 26406.0m },
                    { 3, 1, "", "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcTTuRvD4ecfGFUT5OPX7Y0DUMVCa91IHyzbeqwO3TY6UNwhpfJoB6Harwwm83LcDEfP1bYo34LvJH-PkaKODY8Xwh-x1c1R6pqW_oRaeWDdkMjMTSWIzN8-gg&usqp=CAE", "AMD Ryzen Threadripper PRO 7995WX", 512876.0m },
                    { 4, 2, "", "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcT_OzFW3PueJdquyAqLvXML8ex14absxwEKb9_ai1zWa3_bzk-GccmBsWblN47cJQXndg_ni1lcz8v1y0xTs3BGiu8NSgRXCYRElUKdTvyKjySYjbPQIQz8&usqp=CAE", "Nvidia RTX 4090", 88999.0m },
                    { 5, 2, "", "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSN-HOzsGtF5sr9xFHO2ttuITyboTba__ey5QJXz5_vfQT2t_qdV9-qRnqgHlK4tvbY7DoprOEmbrqAW5VnDOZcdK2WkStUAMW-duANTnk&usqp=CAE", "AMD RX 6600", 7999.0m },
                    { 6, 2, "", "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSbElEyWjjPP1cYTHLoyhnkZ3EJDbFsXQD1pNvJe6bSr1F5uCmMFThovMt2hRaP8BASxdTA5P2M6WIGNKnNnIwHb6OKPIy0LoyD6GurgAXU4iEen_Foj5W4&usqp=CAE", "Nvidia GeForce GTX 1080", 6500.0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
