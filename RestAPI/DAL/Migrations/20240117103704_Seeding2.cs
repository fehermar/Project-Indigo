﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
	/// <inheritdoc />
	public partial class Seeding2 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "Routes",
				columns: new[] { "ID", "Provider", "RouteNumber" },
				values: new object[,]
				{
					{ 21, "BKK", "8E" },
					{ 22, "BKK", "9" },
					{ 23, "BKK", "72" },
					{ 24, "BKK", "80" },
					{ 25, "BKK", "77" }
				});

			migrationBuilder.InsertData(
				table: "Stops",
				columns: new[] { "ID", "Name" },
				values: new object[,]
				{
					{ 261, "Sasadi út" },
					{ 262, "Nagyszeben út" },
					{ 263, "Gazdagréti út" },
					{ 264, "Regős köz" },
					{ 265, "Frankhegy utca" },
					{ 266, "Kaptárkő utca" },
					{ 267, "Telekes utca" },
					{ 268, "Gazdagréti tér" },
					{ 269, "Szent Pio atya tér" },
					{ 270, "Irhás árok" },
					{ 271, "Oltvány köz" },
					{ 272, "Eper utca" },
					{ 273, "Márton Áron tér" },
					{ 274, "Sümeg utca" },
					{ 275, "Farkasréti temető" },
					{ 276, "Hegytető utca" },
					{ 277, "Korompai utca" },
					{ 278, "Sion lépcső" },
					{ 279, "Breznó lépcső" },
					{ 280, "Zólyomi út" },
					{ 281, "BAH-csomópont" },
					{ 282, "Mészáros utca" },
					{ 283, "Sánc utca" },
					{ 284, "Nagyszeben tér" },
					{ 285, "Jégvirág utca" },
					{ 286, "Óbuda, Bogdáni út" },
					{ 287, "Bogdáni út" },
					{ 288, "Raktár utca" },
					{ 289, "Kiscelli utca" },
					{ 290, "Tímár utca" },
					{ 291, "Galagonya utca" },
					{ 292, "Kolosy tér" },
					{ 293, "Zsigmond tér" },
					{ 294, "Császár-Komjádi uszoda" },
					{ 295, "Báthory utca / Bajcsy-Zsilinszky utca" },
					{ 296, "Szent István Bazilika" },
					{ 297, "Szentkirályi utca" },
					{ 298, "Horváth Mihály tér" },
					{ 299, "Muzsikus cigányok parkja" },
					{ 300, "Orczy tér" },
					{ 301, "Kőbányai út 31." },
					{ 302, "Eiffel Műhelyház" },
					{ 303, "Egészségház" },
					{ 304, "Liget tér" },
					{ 305, "Kálvária tér" },
					{ 306, "Ferdinánd híd (Izabella utca)" },
					{ 307, "Szinyei Merse utca" },
					{ 308, "Bajza utca" },
					{ 309, "Munkácsy Mihály utca" },
					{ 310, "Honvédkórház (Hősök tere M)" },
					{ 311, "Állatkert" },
					{ 312, "Kós Károly sétány" },
					{ 313, "Bethesda utca" },
					{ 314, "Ciklámen utca" },
					{ 315, "Vakok intézete" },
					{ 316, "Zugló vasútállomás (Hermina út)" },
					{ 317, "Nyugati pályaudvar M (Pocmaniczky utca)" },
					{ 318, "Rippl-Rónai utca" },
					{ 319, "Csobánc utca" },
					{ 320, "Orczy út" },
					{ 300, "" },
				});

			migrationBuilder.InsertData(
				table: "RouteStops",
				columns: new[] { "Direction", "Order", "RouteID", "StopID" },
				values: new object[,]
				{
					{ "Outbound", 1, 21, 96 },
					{ "Outbound", 2, 21, 261 },
					{ "Outbound", 3, 21, 262 },
					{ "Outbound", 4, 21, 263 },
					{ "Outbound", 5, 21, 264 },
					{ "Outbound", 6, 21, 265 },
					{ "Outbound", 7, 21, 266 },
					{ "Outbound", 8, 21, 267 },
					{ "Outbound", 9, 21, 268 },
					{ "Outbound", 10, 21, 269 },
					{ "Outbound", 11, 21, 270 },
					{ "Outbound", 12, 21, 271 },
					{ "Outbound", 13, 21, 272 },
					{ "Outbound", 14, 21, 273 },
					{ "Outbound", 15, 21, 274 },
					{ "Outbound", 16, 21, 275 },
					{ "Outbound", 17, 21, 276 },
					{ "Outbound", 18, 21, 277 },
					{ "Outbound", 19, 21, 278 },
					{ "Outbound", 20, 21, 279 },
					{ "Outbound", 21, 21, 280 },
					{ "Outbound", 22, 21, 281 },
					{ "Outbound", 23, 21, 281 },
					{ "Outbound", 24, 21, 282 },
					{ "Outbound", 25, 21, 283 },
					{ "Outbound", 26, 21, 241 },
					{ "Outbound", 27, 21, 18 },
					{ "Outbound", 28, 21, 19 },
					{ "Outbound", 29, 21, 20 },
					{ "Outbound", 30, 21, 21 },
					{ "Outbound", 31, 21, 22 },
					{ "Outbound", 32, 21, 24 },
					{ "Outbound", 33, 21, 28 },
					{ "Outbound", 34, 21, 29 },
					{ "Outbound", 35, 21, 30 },
					{ "Outbound", 36, 21, 33 },
					{ "Outbound", 37, 21, 34 },
					{ "Outbound", 38, 21, 35 },
					{ "Outbound", 39, 21, 37 },
					{ "Outbound", 40, 21, 38 },
					{ "Outbound", 41, 21, 39 },
					{ "Inbound", 1, 21, 39 },
					{ "Inbound", 2, 21, 38 },
					{ "Inbound", 3, 21, 37 },
					{ "Inbound", 4, 21, 35 },
					{ "Inbound", 5, 21, 34 },
					{ "Inbound", 6, 21, 33 },
					{ "Inbound", 7, 21, 30 },
					{ "Inbound", 8, 21, 29 },
					{ "Inbound", 9, 21, 28 },
					{ "Inbound", 10, 21, 24 },
					{ "Inbound", 11, 21, 22 },
					{ "Inbound", 12, 21, 21 },
					{ "Inbound", 13, 21, 20 },
					{ "Inbound", 14, 21, 19 },
					{ "Inbound", 15, 21, 18 },
					{ "Inbound", 16, 21, 241 },
					{ "Inbound", 17, 21, 283 },
					{ "Inbound", 18, 21, 282 },
					{ "Inbound", 19, 21, 281 },
					{ "Inbound", 20, 21, 280 },
					{ "Inbound", 21, 21, 279 },
					{ "Inbound", 22, 21, 278 },
					{ "Inbound", 23, 21, 277 },
					{ "Inbound", 24, 21, 276 },
					{ "Inbound", 25, 21, 275 },
					{ "Inbound", 26, 21, 274 },
					{ "Inbound", 27, 21, 273 },
					{ "Inbound", 28, 21, 272 },
					{ "Inbound", 29, 21, 271 },
					{ "Inbound", 30, 21, 270 },
					{ "Inbound", 31, 21, 269 },
					{ "Inbound", 32, 21, 268 },
					{ "Inbound", 33, 21, 267 },
					{ "Inbound", 34, 21, 266 },
					{ "Inbound", 35, 21, 265 },
					{ "Inbound", 36, 21, 264 },
					{ "Inbound", 37, 21, 284 },
					{ "Inbound", 38, 21, 263 },
					{ "Inbound", 39, 21, 285 },
					{ "Inbound", 40, 21, 96 },
					{ "Outbound", 1, 22, 286 },
					{ "Outbound", 2, 22, 287 },
					{ "Outbound", 3, 22, 288 },
					{ "Outbound", 4, 22, 184 },
					{ "Outbound", 5, 22, 289 },
					{ "Outbound", 6, 22, 290 },
					{ "Outbound", 7, 22, 291 },
					{ "Outbound", 8, 22, 292 },
					{ "Outbound", 9, 22, 293 },
					{ "Outbound", 10, 22, 294 },
					{ "Outbound", 11, 22, 97 },
					{ "Outbound", 12, 22, 187 },
					{ "Outbound", 13, 22, 81 },
					{ "Outbound", 14, 22, 295 },
					{ "Outbound", 15, 22, 82 },
					{ "Outbound", 16, 22, 296 },
					{ "Outbound", 17, 22, 59 },
					{ "Outbound", 18, 22, 20 },
					{ "Outbound", 19, 22, 83 },
					{ "Outbound", 20, 22, 297 },
					{ "Outbound", 21, 22, 223 },
					{ "Outbound", 22, 22, 298 },
					{ "Outbound", 23, 22, 299 },
					{ "Outbound", 24, 22, 305 },
					{ "Outbound", 25, 22, 300 },
					{ "Outbound", 26, 22, 301 },
					{ "Outbound", 27, 22, 174 },
					{ "Outbound", 28, 22, 302 },
					{ "Outbound", 29, 22, 217 },
					{ "Outbound", 30, 22, 304 },
					{ "Outbound", 31, 22, 204 },
					{ "Outbound", 32, 22, 205 },
					{ "Inbound", 1, 22, 205 },
					{ "Inbound", 2, 22, 204 },
					{ "Inbound", 3, 22, 304 },
					{ "Inbound", 4, 22, 217 },
					{ "Inbound", 5, 22, 302 },
					{ "Inbound", 6, 22, 174 },
					{ "Inbound", 7, 22, 301 },
					{ "Inbound", 8, 22, 300 },
					{ "Inbound", 9, 22, 305 },
					{ "Inbound", 10, 22, 299 },
					{ "Inbound", 11, 22, 298 },
					{ "Inbound", 12, 22, 223 },
					{ "Inbound", 13, 22, 297 },
					{ "Inbound", 14, 22, 83 },
					{ "Inbound", 15, 22, 20 },
					{ "Inbound", 16, 22, 59 },
					{ "Inbound", 17, 22, 296 },
					{ "Inbound", 18, 22, 82 },
					{ "Inbound", 19, 22, 295 },
					{ "Inbound", 20, 22, 81 },
					{ "Inbound", 21, 22, 187 },
					{ "Inbound", 22, 22, 97 },
					{ "Inbound", 23, 22, 294 },
					{ "Inbound", 24, 22, 293 },
					{ "Inbound", 25, 22, 292 },
					{ "Inbound", 26, 22, 291 },
					{ "Inbound", 27, 22, 290 },
					{ "Inbound", 28, 22, 289 },
					{ "Inbound", 30, 22, 288 },
					{ "Inbound", 31, 22, 286 },
					{ "Inbound", 29, 22, 184 },
					{ "Outbound", 1, 23, 300 },
					{ "Outbound", 2, 23, 305 },
					{ "Outbound", 3, 23, 299 },
					{ "Outbound", 4, 23, 223 },
					{ "Outbound", 5, 23, 297 },
					{ "Outbound", 6, 23, 83 },
					{ "Outbound", 7, 23, 20 },
					{ "Outbound", 8, 23, 59 },
					{ "Outbound", 9, 23, 296 },
					{ "Outbound", 10, 23, 82 },
					{ "Outbound", 11, 23, 295 },
					{ "Outbound", 12, 23, 317 },
					{ "Outbound", 13, 23, 306 },
					{ "Outbound", 14, 23, 307 },
					{ "Outbound", 15, 23, 308 },
					{ "Outbound", 16, 23, 309 },
					{ "Outbound", 17, 23, 310 },
					{ "Outbound", 18, 23, 311 },
					{ "Outbound", 19, 23, 67 },
					{ "Outbound", 20, 23, 312 },
					{ "Outbound", 21, 23, 313 },
					{ "Outbound", 22, 23, 314 },
					{ "Outbound", 23, 23, 315 },
					{ "Outbound", 24, 23, 316 },
					{ "Inbound", 1, 23, 316 },
					{ "Inbound", 2, 23, 27 },
					{ "Inbound", 3, 23, 315 },
					{ "Inbound", 4, 23, 314 },
					{ "Inbound", 5, 23, 313 },
					{ "Inbound", 6, 23, 67 },
					{ "Inbound", 7, 23, 311 },
					{ "Inbound", 8, 23, 310 },
					{ "Inbound", 9, 23, 318 },
					{ "Inbound", 10, 23, 308 },
					{ "Inbound", 11, 23, 307 },
					{ "Inbound", 12, 23, 306 },
					{ "Inbound", 13, 23, 317 },
					{ "Inbound", 14, 23, 295 },
					{ "Inbound", 15, 23, 82 },
					{ "Inbound", 16, 23, 296 },
					{ "Inbound", 17, 23, 59 },
					{ "Inbound", 18, 23, 20 },
					{ "Inbound", 19, 23, 83 },
					{ "Inbound", 20, 23, 297 },
					{ "Inbound", 21, 23, 223 },
					{ "Inbound", 22, 23, 298 },
					{ "Inbound", 23, 23, 299 },
					{ "Inbound", 24, 23, 305 },
					{ "Inbound", 25, 23, 319 },
					{ "Inbound", 26, 23, 320 },
					{ "Inbound", 27, 23, 300 },
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Routes",
				keyColumn: "ID",
				keyValue: 22);

			migrationBuilder.DeleteData(
				table: "Routes",
				keyColumn: "ID",
				keyValue: 23);

			migrationBuilder.DeleteData(
				table: "Routes",
				keyColumn: "ID",
				keyValue: 24);

			migrationBuilder.DeleteData(
				table: "Routes",
				keyColumn: "ID",
				keyValue: 25);

			migrationBuilder.DeleteData(
				table: "Stops",
				keyColumn: "ID",
				keyValue: 262);

			migrationBuilder.DeleteData(
				table: "Routes",
				keyColumn: "ID",
				keyValue: 21);

			migrationBuilder.DeleteData(
				table: "Stops",
				keyColumn: "ID",
				keyValue: 261);
		}
	}
}
