﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class TransportationContext : DbContext
	{
		public DbSet<Route> Routes { get; set; }
		public DbSet<Stop> Stops { get; set; }
		public DbSet<BoundedWalk> BoundedWalks { get; set; }
		public DbSet<Walk> Walks { get; set; }
		public DbSet<Itinerary> Itineraries { get; set; }
		public DbSet<Recording> Recordings { get; set; }
		public DbSet<RouteJourney> RouteJourneys { get; set; }
		public DbSet<RouteStop> RouteStops { get; set; }


		public TransportationContext() : base() { }

		public TransportationContext(DbContextOptions<TransportationContext> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Route>()
				.HasMany(r => r.Stops)
				.WithMany(s => s.Routes)
				.UsingEntity<RouteStop>();

			var recordingTypeConverter = new EnumToStringConverter<RecordingType>();
			modelBuilder.Entity<Recording>()
				.Property(r => r.RecordingType)
				.HasConversion(recordingTypeConverter);

			var directionTypeConverter = new EnumToStringConverter<Direction>();
			modelBuilder.Entity<RouteStop>()
				.Property(rs => rs.Direction)
				.HasConversion(directionTypeConverter);

			#region Seeding
			modelBuilder.Entity<Route>().HasData(
				new Route { ID = 01, Provider = "BKK", RouteNumber = "7" },
				new Route { ID = 02, Provider = "BKK", RouteNumber = "7E" },
				new Route { ID = 03, Provider = "BKK", RouteNumber = "82" },
				new Route { ID = 04, Provider = "BKK", RouteNumber = "82A" },
				new Route { ID = 05, Provider = "BKK", RouteNumber = "M1" },
				new Route { ID = 06, Provider = "BKK", RouteNumber = "M2" },
				new Route { ID = 07, Provider = "BKK", RouteNumber = "M3" },
				new Route { ID = 08, Provider = "BKK", RouteNumber = "M4" },
				new Route { ID = 09, Provider = "BKK", RouteNumber = "H5" }
				//new Route { ID = 10, Provider = "BKK", RouteNumber = "H6" },
				//new Route { ID = 11, Provider = "BKK", RouteNumber = "H7" },
				//new Route { ID = 12, Provider = "BKK", RouteNumber = "H8" },
				//new Route { ID = 13, Provider = "BKK", RouteNumber = "H9" }
				);

			modelBuilder.Entity<Stop>().HasData(
				new Stop { ID = 001, Name = "Albertfalva vasútállomás" },
				new Stop { ID = 002, Name = "Fonyód utca / Sáfrány utca" },
				new Stop { ID = 003, Name = "Herend utca" },
				new Stop { ID = 004, Name = "Nyírbátor utca" },
				new Stop { ID = 005, Name = "Csurgói utca" },
				new Stop { ID = 006, Name = "Andor utca / Tétényi utca" },
				new Stop { ID = 007, Name = "Bornemissza tér" },
				new Stop { ID = 008, Name = "Puskás Tivadar utca" },
				new Stop { ID = 009, Name = "Bikás park M" },
				new Stop { ID = 010, Name = "Tétényi út 30." },
				new Stop { ID = 011, Name = "Szent Imre Kórház" },
				new Stop { ID = 012, Name = "Karolina út" },
				new Stop { ID = 013, Name = "Kosztolány Dezső tér" },
				new Stop { ID = 014, Name = "Móricz Zsigmond körtér M" },
				new Stop { ID = 015, Name = "Gárdonyi tér" },
				new Stop { ID = 016, Name = "Szent Gellért tér - Műegyetem M" },
				new Stop { ID = 017, Name = "Rudas Gyógyfürdő" },
				new Stop { ID = 018, Name = "Március 15. tér" },
				new Stop { ID = 019, Name = "Ferenciek tere M" },
				new Stop { ID = 020, Name = "Astoria M" },
				new Stop { ID = 021, Name = "Uránia" },
				new Stop { ID = 022, Name = "Blaha Lujza tér M" },
				new Stop { ID = 023, Name = "Huszár utca" },
				new Stop { ID = 024, Name = "Keleti pályaudvar M" },
				new Stop { ID = 025, Name = "Reiner Frigyes park" },
				new Stop { ID = 026, Name = "Cházár András utca" },
				new Stop { ID = 027, Name = "Stefánia út / Thököly út" },
				new Stop { ID = 028, Name = "Zugló vasútállomás" },
				new Stop { ID = 029, Name = "Tisza István tér" },
				new Stop { ID = 030, Name = "Bosnyák tér" },
				new Stop { ID = 031, Name = "Rákospatak utca / Csömöri út" },
				new Stop { ID = 032, Name = "Miskolci utca / Csömöri út" },
				new Stop { ID = 033, Name = "Cinkotai út" },
				new Stop { ID = 034, Name = "Molnár Viktor utca" },
				new Stop { ID = 035, Name = "Apolló utca" },
				new Stop { ID = 036, Name = "Madách utca" },
				new Stop { ID = 037, Name = "Fő tér" },
				new Stop { ID = 038, Name = "Vásárcsarnok" },
				new Stop { ID = 039, Name = "Újpalota, Nyírpalota út" },
				new Stop { ID = 040, Name = "Mexikói út M" },
				new Stop { ID = 041, Name = "Kassai tér" },
				new Stop { ID = 042, Name = "Uzsoki Utcai Kórház" },
				new Stop { ID = 043, Name = "Szugló utca / Róna utca" },
				new Stop { ID = 044, Name = "Szugló utca / Nagy Lajos király útja" },
				new Stop { ID = 045, Name = "Fűrész utca / Szugló utca" },
				new Stop { ID = 046, Name = "Komócsy utca" },
				new Stop { ID = 047, Name = "Egressy út / Vezér utca" },
				new Stop { ID = 048, Name = "Mogyoródi út" },
				new Stop { ID = 049, Name = "Gödöllői utca" },
				new Stop { ID = 050, Name = "Fogarasi út" },
				new Stop { ID = 051, Name = "Tihamér utca" },
				new Stop { ID = 052, Name = "Füredi utca" },
				new Stop { ID = 053, Name = "Álmos vezér útja" },
				new Stop { ID = 054, Name = "Örs vezér tere M+H" },
				new Stop { ID = 055, Name = "Erzsébet királyné útja / Róna utca" },
				new Stop { ID = 056, Name = "Laky Adolf utca" },
				new Stop { ID = 057, Name = "Erzsébet királyné útja, aluljáró" },
				new Stop { ID = 058, Name = "Vörösmarty tér M" },
				new Stop { ID = 059, Name = "Deák Ferenc tér M" },
				new Stop { ID = 060, Name = "Bajcsy-Zsilinszky út M" },
				new Stop { ID = 061, Name = "Opera M" },
				new Stop { ID = 062, Name = "Oktogon M" },
				new Stop { ID = 063, Name = "Vörösmarty utca M" },
				new Stop { ID = 064, Name = "Kodály körönd M" },
				new Stop { ID = 065, Name = "Bajza utca M" },
				new Stop { ID = 066, Name = "Hősök tere M" },
				new Stop { ID = 067, Name = "Széchenyi fürdő M" },
				new Stop { ID = 068, Name = "Déli pályaudvar M" },
				new Stop { ID = 069, Name = "Széll Kálmán tér M" },
				new Stop { ID = 070, Name = "Batthyány tér M+H" },
				new Stop { ID = 071, Name = "Kossuth Lajos tér M" },
				new Stop { ID = 072, Name = "Puskás Ferenc Stadion M" },
				new Stop { ID = 073, Name = "Pillangó utca M" },
				new Stop { ID = 074, Name = "Újpest-központ M" },
				new Stop { ID = 075, Name = "Újpest-városkapu M" },
				new Stop { ID = 076, Name = "Gyöngyösi utca M" },
				new Stop { ID = 077, Name = "Forgách utca M" },
				new Stop { ID = 078, Name = "Göncz Árpád városközpont M" },
				new Stop { ID = 079, Name = "Dózsa György út M" },
				new Stop { ID = 080, Name = "Lehel tér M" },
				new Stop { ID = 081, Name = "Nyugati pályaudvar M" },
				new Stop { ID = 082, Name = "Arany János utca M" },
				new Stop { ID = 083, Name = "Kálvin tér M" },
				new Stop { ID = 084, Name = "Corvin-negyed M" },
				new Stop { ID = 085, Name = "Semmelweis Klinikák M" },
				new Stop { ID = 086, Name = "Nagyvárad tér M" },
				new Stop { ID = 087, Name = "Népliget M" },
				new Stop { ID = 088, Name = "Ecseri út M" },
				new Stop { ID = 089, Name = "Pöttyös utca M" },
				new Stop { ID = 090, Name = "Határ út M" },
				new Stop { ID = 091, Name = "Kőbánya-Kispest M" },
				new Stop { ID = 092, Name = "II. János Pál pápa tér M" },
				new Stop { ID = 093, Name = "Rákóczi tér M" },
				new Stop { ID = 094, Name = "Fővám tér M" },
				new Stop { ID = 095, Name = "Újbuda-központ M" },
				new Stop { ID = 096, Name = "Kelenföld vasútállomás M" },
				new Stop { ID = 097, Name = "Margit híd, budai hídfő H" },
				new Stop { ID = 098, Name = "Szépvölgyi út H" },
				new Stop { ID = 099, Name = "Tímár utca H" },
				new Stop { ID = 100, Name = "Szentlélek tér H" },
				new Stop { ID = 101, Name = "Filatorigát" },
				new Stop { ID = 102, Name = "Kaszásdűlő H" },
				new Stop { ID = 103, Name = "Aquincum H" },
				new Stop { ID = 104, Name = "Rómaifürdő H" },
				new Stop { ID = 105, Name = "Csillaghegy H" },
				new Stop { ID = 106, Name = "Békásmegyer H" },
				new Stop { ID = 107, Name = "Budakalász" },
				new Stop { ID = 108, Name = "Budakalász, Lenfonó H" },
				new Stop { ID = 109, Name = "Szentistvántelep H" },
				new Stop { ID = 110, Name = "Pomáz H" },
				new Stop { ID = 111, Name = "Pannóniatelep" },
				new Stop { ID = 112, Name = "Szentendre" }
				);

			modelBuilder.Entity<RouteStop>().HasData(
				new RouteStop { RouteID = 01, StopID = 001, Direction = Direction.Outbound, Order = 1 },
				new RouteStop { RouteID = 01, StopID = 002, Direction = Direction.Outbound, Order = 2 },
				new RouteStop { RouteID = 01, StopID = 003, Direction = Direction.Outbound, Order = 3 },
				new RouteStop { RouteID = 01, StopID = 004, Direction = Direction.Outbound, Order = 4 },
				new RouteStop { RouteID = 01, StopID = 005, Direction = Direction.Outbound, Order = 5 },
				new RouteStop { RouteID = 01, StopID = 006, Direction = Direction.Outbound, Order = 6 },
				new RouteStop { RouteID = 01, StopID = 007, Direction = Direction.Outbound, Order = 7 },
				new RouteStop { RouteID = 01, StopID = 008, Direction = Direction.Outbound, Order = 8 },
				new RouteStop { RouteID = 01, StopID = 009, Direction = Direction.Outbound, Order = 9 },
				new RouteStop { RouteID = 01, StopID = 010, Direction = Direction.Outbound, Order = 10 },
				new RouteStop { RouteID = 01, StopID = 011, Direction = Direction.Outbound, Order = 11 },
				new RouteStop { RouteID = 01, StopID = 012, Direction = Direction.Outbound, Order = 12 },
				new RouteStop { RouteID = 01, StopID = 013, Direction = Direction.Outbound, Order = 13 },
				new RouteStop { RouteID = 01, StopID = 014, Direction = Direction.Outbound, Order = 14 },
				new RouteStop { RouteID = 01, StopID = 015, Direction = Direction.Outbound, Order = 15 },
				new RouteStop { RouteID = 01, StopID = 016, Direction = Direction.Outbound, Order = 16 },
				new RouteStop { RouteID = 01, StopID = 017, Direction = Direction.Outbound, Order = 17 },
				new RouteStop { RouteID = 01, StopID = 018, Direction = Direction.Outbound, Order = 18 },
				new RouteStop { RouteID = 01, StopID = 019, Direction = Direction.Outbound, Order = 19 },
				new RouteStop { RouteID = 01, StopID = 020, Direction = Direction.Outbound, Order = 20 },
				new RouteStop { RouteID = 01, StopID = 021, Direction = Direction.Outbound, Order = 21 },
				new RouteStop { RouteID = 01, StopID = 022, Direction = Direction.Outbound, Order = 22 },
				new RouteStop { RouteID = 01, StopID = 023, Direction = Direction.Outbound, Order = 23 },
				new RouteStop { RouteID = 01, StopID = 024, Direction = Direction.Outbound, Order = 24 },
				new RouteStop { RouteID = 01, StopID = 025, Direction = Direction.Outbound, Order = 25 },
				new RouteStop { RouteID = 01, StopID = 026, Direction = Direction.Outbound, Order = 26 },
				new RouteStop { RouteID = 01, StopID = 027, Direction = Direction.Outbound, Order = 27 },
				new RouteStop { RouteID = 01, StopID = 028, Direction = Direction.Outbound, Order = 28 },
				new RouteStop { RouteID = 01, StopID = 029, Direction = Direction.Outbound, Order = 29 },
				new RouteStop { RouteID = 01, StopID = 030, Direction = Direction.Outbound, Order = 30 },
				new RouteStop { RouteID = 01, StopID = 031, Direction = Direction.Outbound, Order = 31 },
				new RouteStop { RouteID = 01, StopID = 032, Direction = Direction.Outbound, Order = 32 },
				new RouteStop { RouteID = 01, StopID = 033, Direction = Direction.Outbound, Order = 33 },
				new RouteStop { RouteID = 01, StopID = 034, Direction = Direction.Outbound, Order = 34 },
				new RouteStop { RouteID = 01, StopID = 035, Direction = Direction.Outbound, Order = 35 },
				new RouteStop { RouteID = 01, StopID = 036, Direction = Direction.Outbound, Order = 36 },
				new RouteStop { RouteID = 01, StopID = 037, Direction = Direction.Outbound, Order = 37 },
				new RouteStop { RouteID = 01, StopID = 038, Direction = Direction.Outbound, Order = 38 },
				new RouteStop { RouteID = 01, StopID = 039, Direction = Direction.Outbound, Order = 39 },
				new RouteStop { RouteID = 01, StopID = 039, Direction = Direction.Inbound, Order = 1 },
				new RouteStop { RouteID = 01, StopID = 038, Direction = Direction.Inbound, Order = 2 },
				new RouteStop { RouteID = 01, StopID = 037, Direction = Direction.Inbound, Order = 3 },
				new RouteStop { RouteID = 01, StopID = 036, Direction = Direction.Inbound, Order = 4 },
				new RouteStop { RouteID = 01, StopID = 035, Direction = Direction.Inbound, Order = 5 },
				new RouteStop { RouteID = 01, StopID = 034, Direction = Direction.Inbound, Order = 6 },
				new RouteStop { RouteID = 01, StopID = 033, Direction = Direction.Inbound, Order = 7 },
				new RouteStop { RouteID = 01, StopID = 032, Direction = Direction.Inbound, Order = 8 },
				new RouteStop { RouteID = 01, StopID = 031, Direction = Direction.Inbound, Order = 9 },
				new RouteStop { RouteID = 01, StopID = 030, Direction = Direction.Inbound, Order = 10 },
				new RouteStop { RouteID = 01, StopID = 029, Direction = Direction.Inbound, Order = 11 },
				new RouteStop { RouteID = 01, StopID = 028, Direction = Direction.Inbound, Order = 12 },
				new RouteStop { RouteID = 01, StopID = 027, Direction = Direction.Inbound, Order = 13 },
				new RouteStop { RouteID = 01, StopID = 026, Direction = Direction.Inbound, Order = 14 },
				new RouteStop { RouteID = 01, StopID = 025, Direction = Direction.Inbound, Order = 15 },
				new RouteStop { RouteID = 01, StopID = 024, Direction = Direction.Inbound, Order = 16 },
				new RouteStop { RouteID = 01, StopID = 023, Direction = Direction.Inbound, Order = 17 },
				new RouteStop { RouteID = 01, StopID = 022, Direction = Direction.Inbound, Order = 18 },
				new RouteStop { RouteID = 01, StopID = 021, Direction = Direction.Inbound, Order = 19 },
				new RouteStop { RouteID = 01, StopID = 020, Direction = Direction.Inbound, Order = 20 },
				new RouteStop { RouteID = 01, StopID = 019, Direction = Direction.Inbound, Order = 21 },
				new RouteStop { RouteID = 01, StopID = 018, Direction = Direction.Inbound, Order = 22 },
				new RouteStop { RouteID = 01, StopID = 017, Direction = Direction.Inbound, Order = 23 },
				new RouteStop { RouteID = 01, StopID = 016, Direction = Direction.Inbound, Order = 24 },
				new RouteStop { RouteID = 01, StopID = 015, Direction = Direction.Inbound, Order = 25 },
				new RouteStop { RouteID = 01, StopID = 014, Direction = Direction.Inbound, Order = 26 },
				new RouteStop { RouteID = 01, StopID = 013, Direction = Direction.Inbound, Order = 27 },
				new RouteStop { RouteID = 01, StopID = 012, Direction = Direction.Inbound, Order = 28 },
				new RouteStop { RouteID = 01, StopID = 011, Direction = Direction.Inbound, Order = 29 },
				new RouteStop { RouteID = 01, StopID = 010, Direction = Direction.Inbound, Order = 30 },
				new RouteStop { RouteID = 01, StopID = 009, Direction = Direction.Inbound, Order = 31 },
				new RouteStop { RouteID = 01, StopID = 008, Direction = Direction.Inbound, Order = 32 },
				new RouteStop { RouteID = 01, StopID = 007, Direction = Direction.Inbound, Order = 33 },
				new RouteStop { RouteID = 01, StopID = 005, Direction = Direction.Inbound, Order = 34 },
				new RouteStop { RouteID = 01, StopID = 004, Direction = Direction.Inbound, Order = 35 },
				new RouteStop { RouteID = 01, StopID = 003, Direction = Direction.Inbound, Order = 36 },
				new RouteStop { RouteID = 01, StopID = 002, Direction = Direction.Inbound, Order = 37 },
				new RouteStop { RouteID = 01, StopID = 001, Direction = Direction.Inbound, Order = 38 },
				new RouteStop { RouteID = 02, StopID = 022, Direction = Direction.Outbound, Order = 1},
				new RouteStop { RouteID = 02, StopID = 022, Direction = Direction.Outbound, Order = 2},
				new RouteStop { RouteID = 02, StopID = 024, Direction = Direction.Outbound, Order = 3},
				new RouteStop { RouteID = 02, StopID = 028, Direction = Direction.Outbound, Order = 4},
				new RouteStop { RouteID = 02, StopID = 030, Direction = Direction.Outbound, Order = 5},
				new RouteStop { RouteID = 02, StopID = 034, Direction = Direction.Outbound, Order = 6},
				new RouteStop { RouteID = 02, StopID = 037, Direction = Direction.Outbound, Order = 7},
				new RouteStop { RouteID = 02, StopID = 038, Direction = Direction.Outbound, Order = 8},
				new RouteStop { RouteID = 02, StopID = 039, Direction = Direction.Outbound, Order = 9},
				new RouteStop { RouteID = 02, StopID = 039, Direction = Direction.Inbound, Order = 1},
				new RouteStop { RouteID = 02, StopID = 038, Direction = Direction.Inbound, Order = 2},
				new RouteStop { RouteID = 02, StopID = 037, Direction = Direction.Inbound, Order = 3},
				new RouteStop { RouteID = 02, StopID = 034, Direction = Direction.Inbound, Order = 4},
				new RouteStop { RouteID = 02, StopID = 030, Direction = Direction.Inbound, Order = 5},
				new RouteStop { RouteID = 02, StopID = 028, Direction = Direction.Inbound, Order = 6},
				new RouteStop { RouteID = 02, StopID = 024, Direction = Direction.Inbound, Order = 7},
				new RouteStop { RouteID = 02, StopID = 022, Direction = Direction.Inbound, Order = 8},
				new RouteStop { RouteID = 02, StopID = 022, Direction = Direction.Inbound, Order = 9},
				new RouteStop { RouteID = 03, StopID = 040, Direction = Direction.Outbound, Order = 1},
				new RouteStop { RouteID = 03, StopID = 041, Direction = Direction.Outbound, Order = 2},
				new RouteStop { RouteID = 03, StopID = 042, Direction = Direction.Outbound, Order = 3},
				new RouteStop { RouteID = 03, StopID = 029, Direction = Direction.Outbound, Order = 4},
				new RouteStop { RouteID = 03, StopID = 043, Direction = Direction.Outbound, Order = 5},
				new RouteStop { RouteID = 03, StopID = 044, Direction = Direction.Outbound, Order = 6},
				new RouteStop { RouteID = 03, StopID = 045, Direction = Direction.Outbound, Order = 7},
				new RouteStop { RouteID = 03, StopID = 046, Direction = Direction.Outbound, Order = 8},
				new RouteStop { RouteID = 03, StopID = 047, Direction = Direction.Outbound, Order = 9},
				new RouteStop { RouteID = 03, StopID = 048, Direction = Direction.Outbound, Order = 10},
				new RouteStop { RouteID = 03, StopID = 049, Direction = Direction.Outbound, Order = 11},
				new RouteStop { RouteID = 03, StopID = 050, Direction = Direction.Outbound, Order = 12},
				new RouteStop { RouteID = 03, StopID = 051, Direction = Direction.Outbound, Order = 13},
				new RouteStop { RouteID = 03, StopID = 052, Direction = Direction.Outbound, Order = 14},
				new RouteStop { RouteID = 03, StopID = 053, Direction = Direction.Outbound, Order = 15},
				new RouteStop { RouteID = 03, StopID = 054, Direction = Direction.Outbound, Order = 16},
				new RouteStop { RouteID = 03, StopID = 054, Direction = Direction.Inbound, Order = 1},
				new RouteStop { RouteID = 03, StopID = 053, Direction = Direction.Inbound, Order = 2},
				new RouteStop { RouteID = 03, StopID = 052, Direction = Direction.Inbound, Order = 3},
				new RouteStop { RouteID = 03, StopID = 051, Direction = Direction.Inbound, Order = 4},
				new RouteStop { RouteID = 03, StopID = 050, Direction = Direction.Inbound, Order = 5},
				new RouteStop { RouteID = 03, StopID = 049, Direction = Direction.Inbound, Order = 6},
				new RouteStop { RouteID = 03, StopID = 048, Direction = Direction.Inbound, Order = 7},
				new RouteStop { RouteID = 03, StopID = 047, Direction = Direction.Inbound, Order = 8},
				new RouteStop { RouteID = 03, StopID = 046, Direction = Direction.Inbound, Order = 9},
				new RouteStop { RouteID = 03, StopID = 045, Direction = Direction.Inbound, Order = 10},
				new RouteStop { RouteID = 03, StopID = 044, Direction = Direction.Inbound, Order = 11},
				new RouteStop { RouteID = 03, StopID = 043, Direction = Direction.Inbound, Order = 12},
				new RouteStop { RouteID = 03, StopID = 029, Direction = Direction.Inbound, Order = 13},
				new RouteStop { RouteID = 03, StopID = 042, Direction = Direction.Inbound, Order = 14},
				new RouteStop { RouteID = 03, StopID = 055, Direction = Direction.Inbound, Order = 15},
				new RouteStop { RouteID = 03, StopID = 056, Direction = Direction.Inbound, Order = 16},
				new RouteStop { RouteID = 03, StopID = 057, Direction = Direction.Inbound, Order = 17},
				new RouteStop { RouteID = 03, StopID = 040, Direction = Direction.Inbound, Order = 18},
				new RouteStop { RouteID = 04, StopID = 055, Direction = Direction.Outbound, Order = 1},
				new RouteStop { RouteID = 04, StopID = 042, Direction = Direction.Outbound, Order = 2},
				new RouteStop { RouteID = 04, StopID = 029, Direction = Direction.Outbound, Order = 3},
				new RouteStop { RouteID = 04, StopID = 043, Direction = Direction.Outbound, Order = 4},
				new RouteStop { RouteID = 04, StopID = 044, Direction = Direction.Outbound, Order = 5},
				new RouteStop { RouteID = 04, StopID = 045, Direction = Direction.Outbound, Order = 6},
				new RouteStop { RouteID = 04, StopID = 046, Direction = Direction.Outbound, Order = 7},
				new RouteStop { RouteID = 04, StopID = 047, Direction = Direction.Outbound, Order = 8},
				new RouteStop { RouteID = 04, StopID = 048, Direction = Direction.Outbound, Order = 9},
				new RouteStop { RouteID = 04, StopID = 049, Direction = Direction.Outbound, Order = 10},
				new RouteStop { RouteID = 04, StopID = 050, Direction = Direction.Outbound, Order = 11},
				new RouteStop { RouteID = 04, StopID = 051, Direction = Direction.Outbound, Order = 12},
				new RouteStop { RouteID = 04, StopID = 052, Direction = Direction.Outbound, Order = 13},
				new RouteStop { RouteID = 04, StopID = 053, Direction = Direction.Outbound, Order = 14},
				new RouteStop { RouteID = 04, StopID = 054, Direction = Direction.Outbound, Order = 15},
				new RouteStop { RouteID = 04, StopID = 054, Direction = Direction.Inbound, Order = 1},
				new RouteStop { RouteID = 04, StopID = 053, Direction = Direction.Inbound, Order = 2},
				new RouteStop { RouteID = 04, StopID = 052, Direction = Direction.Inbound, Order = 3},
				new RouteStop { RouteID = 04, StopID = 051, Direction = Direction.Inbound, Order = 4},
				new RouteStop { RouteID = 04, StopID = 050, Direction = Direction.Inbound, Order = 5},
				new RouteStop { RouteID = 04, StopID = 049, Direction = Direction.Inbound, Order = 6},
				new RouteStop { RouteID = 04, StopID = 048, Direction = Direction.Inbound, Order = 7},
				new RouteStop { RouteID = 04, StopID = 047, Direction = Direction.Inbound, Order = 8},
				new RouteStop { RouteID = 04, StopID = 046, Direction = Direction.Inbound, Order = 9},
				new RouteStop { RouteID = 04, StopID = 045, Direction = Direction.Inbound, Order = 10},
				new RouteStop { RouteID = 04, StopID = 044, Direction = Direction.Inbound, Order = 11},
				new RouteStop { RouteID = 04, StopID = 043, Direction = Direction.Inbound, Order = 12},
				new RouteStop { RouteID = 04, StopID = 029, Direction = Direction.Inbound, Order = 13},
				new RouteStop { RouteID = 04, StopID = 042, Direction = Direction.Inbound, Order = 14},
				new RouteStop { RouteID = 04, StopID = 055, Direction = Direction.Inbound, Order = 15},
				new RouteStop { RouteID = 05, StopID = 058, Direction = Direction.Outbound, Order = 1},
				new RouteStop { RouteID = 05, StopID = 059, Direction = Direction.Outbound, Order = 2},
				new RouteStop { RouteID = 05, StopID = 060, Direction = Direction.Outbound, Order = 3},
				new RouteStop { RouteID = 05, StopID = 061, Direction = Direction.Outbound, Order = 4},
				new RouteStop { RouteID = 05, StopID = 062, Direction = Direction.Outbound, Order = 5},
				new RouteStop { RouteID = 05, StopID = 063, Direction = Direction.Outbound, Order = 6},
				new RouteStop { RouteID = 05, StopID = 064, Direction = Direction.Outbound, Order = 7},
				new RouteStop { RouteID = 05, StopID = 065, Direction = Direction.Outbound, Order = 8},
				new RouteStop { RouteID = 05, StopID = 066, Direction = Direction.Outbound, Order = 9},
				new RouteStop { RouteID = 05, StopID = 067, Direction = Direction.Outbound, Order = 10},
				new RouteStop { RouteID = 05, StopID = 040, Direction = Direction.Outbound, Order = 11},
				new RouteStop { RouteID = 05, StopID = 040, Direction = Direction.Inbound, Order = 1},
				new RouteStop { RouteID = 05, StopID = 067, Direction = Direction.Inbound, Order = 2},
				new RouteStop { RouteID = 05, StopID = 066, Direction = Direction.Inbound, Order = 3},
				new RouteStop { RouteID = 05, StopID = 065, Direction = Direction.Inbound, Order = 4},
				new RouteStop { RouteID = 05, StopID = 064, Direction = Direction.Inbound, Order = 5},
				new RouteStop { RouteID = 05, StopID = 063, Direction = Direction.Inbound, Order = 6},
				new RouteStop { RouteID = 05, StopID = 062, Direction = Direction.Inbound, Order = 7},
				new RouteStop { RouteID = 05, StopID = 061, Direction = Direction.Inbound, Order = 8},
				new RouteStop { RouteID = 05, StopID = 060, Direction = Direction.Inbound, Order = 9},
				new RouteStop { RouteID = 05, StopID = 059, Direction = Direction.Inbound, Order = 10},
				new RouteStop { RouteID = 05, StopID = 058, Direction = Direction.Inbound, Order = 11},
				new RouteStop { RouteID = 06, StopID = 068, Direction = Direction.Outbound, Order = 1},
				new RouteStop { RouteID = 06, StopID = 069, Direction = Direction.Outbound, Order = 2},
				new RouteStop { RouteID = 06, StopID = 070, Direction = Direction.Outbound, Order = 3},
				new RouteStop { RouteID = 06, StopID = 071, Direction = Direction.Outbound, Order = 4},
				new RouteStop { RouteID = 06, StopID = 059, Direction = Direction.Outbound, Order = 5},
				new RouteStop { RouteID = 06, StopID = 020, Direction = Direction.Outbound, Order = 6},
				new RouteStop { RouteID = 06, StopID = 022, Direction = Direction.Outbound, Order = 7},
				new RouteStop { RouteID = 06, StopID = 024, Direction = Direction.Outbound, Order = 8},
				new RouteStop { RouteID = 06, StopID = 072, Direction = Direction.Outbound, Order = 9},
				new RouteStop { RouteID = 06, StopID = 073, Direction = Direction.Outbound, Order = 10},
				new RouteStop { RouteID = 06, StopID = 054, Direction = Direction.Outbound, Order = 11},
				new RouteStop { RouteID = 06, StopID = 054, Direction = Direction.Inbound, Order = 1},
				new RouteStop { RouteID = 06, StopID = 073, Direction = Direction.Inbound, Order = 2},
				new RouteStop { RouteID = 06, StopID = 072, Direction = Direction.Inbound, Order = 3},
				new RouteStop { RouteID = 06, StopID = 024, Direction = Direction.Inbound, Order = 4},
				new RouteStop { RouteID = 06, StopID = 022, Direction = Direction.Inbound, Order = 5},
				new RouteStop { RouteID = 06, StopID = 020, Direction = Direction.Inbound, Order = 6},
				new RouteStop { RouteID = 06, StopID = 059, Direction = Direction.Inbound, Order = 7},
				new RouteStop { RouteID = 06, StopID = 071, Direction = Direction.Inbound, Order = 8},
				new RouteStop { RouteID = 06, StopID = 070, Direction = Direction.Inbound, Order = 9},
				new RouteStop { RouteID = 06, StopID = 069, Direction = Direction.Inbound, Order = 10},
				new RouteStop { RouteID = 06, StopID = 068, Direction = Direction.Inbound, Order = 11},
				new RouteStop { RouteID = 07, StopID = 074, Direction = Direction.Outbound, Order = 1},
				new RouteStop { RouteID = 07, StopID = 075, Direction = Direction.Outbound, Order = 2},
				new RouteStop { RouteID = 07, StopID = 076, Direction = Direction.Outbound, Order = 3},
				new RouteStop { RouteID = 07, StopID = 077, Direction = Direction.Outbound, Order = 4},
				new RouteStop { RouteID = 07, StopID = 078, Direction = Direction.Outbound, Order = 5},
				new RouteStop { RouteID = 07, StopID = 079, Direction = Direction.Outbound, Order = 6},
				new RouteStop { RouteID = 07, StopID = 080, Direction = Direction.Outbound, Order = 7},
				new RouteStop { RouteID = 07, StopID = 081, Direction = Direction.Outbound, Order = 8},
				new RouteStop { RouteID = 07, StopID = 082, Direction = Direction.Outbound, Order = 9},
				new RouteStop { RouteID = 07, StopID = 059, Direction = Direction.Outbound, Order = 10},
				new RouteStop { RouteID = 07, StopID = 019, Direction = Direction.Outbound, Order = 11},
				new RouteStop { RouteID = 07, StopID = 083, Direction = Direction.Outbound, Order = 12},
				new RouteStop { RouteID = 07, StopID = 084, Direction = Direction.Outbound, Order = 13},
				new RouteStop { RouteID = 07, StopID = 085, Direction = Direction.Outbound, Order = 14},
				new RouteStop { RouteID = 07, StopID = 086, Direction = Direction.Outbound, Order = 15},
				new RouteStop { RouteID = 07, StopID = 087, Direction = Direction.Outbound, Order = 16},
				new RouteStop { RouteID = 07, StopID = 088, Direction = Direction.Outbound, Order = 17},
				new RouteStop { RouteID = 07, StopID = 089, Direction = Direction.Outbound, Order = 18},
				new RouteStop { RouteID = 07, StopID = 090, Direction = Direction.Outbound, Order = 19},
				new RouteStop { RouteID = 07, StopID = 091, Direction = Direction.Outbound, Order = 20},
				new RouteStop { RouteID = 07, StopID = 091, Direction = Direction.Inbound, Order = 1},
				new RouteStop { RouteID = 07, StopID = 090, Direction = Direction.Inbound, Order = 2},
				new RouteStop { RouteID = 07, StopID = 089, Direction = Direction.Inbound, Order = 3},
				new RouteStop { RouteID = 07, StopID = 088, Direction = Direction.Inbound, Order = 4},
				new RouteStop { RouteID = 07, StopID = 087, Direction = Direction.Inbound, Order = 5},
				new RouteStop { RouteID = 07, StopID = 086, Direction = Direction.Inbound, Order = 6},
				new RouteStop { RouteID = 07, StopID = 085, Direction = Direction.Inbound, Order = 7},
				new RouteStop { RouteID = 07, StopID = 084, Direction = Direction.Inbound, Order = 8},
				new RouteStop { RouteID = 07, StopID = 083, Direction = Direction.Inbound, Order = 9},
				new RouteStop { RouteID = 07, StopID = 019, Direction = Direction.Inbound, Order = 10},
				new RouteStop { RouteID = 07, StopID = 059, Direction = Direction.Inbound, Order = 11},
				new RouteStop { RouteID = 07, StopID = 082, Direction = Direction.Inbound, Order = 12},
				new RouteStop { RouteID = 07, StopID = 081, Direction = Direction.Inbound, Order = 13},
				new RouteStop { RouteID = 07, StopID = 080, Direction = Direction.Inbound, Order = 14},
				new RouteStop { RouteID = 07, StopID = 079, Direction = Direction.Inbound, Order = 15},
				new RouteStop { RouteID = 07, StopID = 078, Direction = Direction.Inbound, Order = 16},
				new RouteStop { RouteID = 07, StopID = 077, Direction = Direction.Inbound, Order = 17},
				new RouteStop { RouteID = 07, StopID = 076, Direction = Direction.Inbound, Order = 18},
				new RouteStop { RouteID = 07, StopID = 075, Direction = Direction.Inbound, Order = 19},
				new RouteStop { RouteID = 07, StopID = 074, Direction = Direction.Inbound, Order = 20},
				new RouteStop { RouteID = 08, StopID = 024, Direction = Direction.Outbound, Order = 1},
				new RouteStop { RouteID = 08, StopID = 092, Direction = Direction.Outbound, Order = 2},
				new RouteStop { RouteID = 08, StopID = 093, Direction = Direction.Outbound, Order = 3},
				new RouteStop { RouteID = 08, StopID = 083, Direction = Direction.Outbound, Order = 4},
				new RouteStop { RouteID = 08, StopID = 094, Direction = Direction.Outbound, Order = 5},
				new RouteStop { RouteID = 08, StopID = 016, Direction = Direction.Outbound, Order = 6},
				new RouteStop { RouteID = 08, StopID = 014, Direction = Direction.Outbound, Order = 7},
				new RouteStop { RouteID = 08, StopID = 095, Direction = Direction.Outbound, Order = 8},
				new RouteStop { RouteID = 08, StopID = 009, Direction = Direction.Outbound, Order = 9},
				new RouteStop { RouteID = 08, StopID = 096, Direction = Direction.Outbound, Order = 10},
				new RouteStop { RouteID = 08, StopID = 096, Direction = Direction.Inbound, Order = 1},
				new RouteStop { RouteID = 08, StopID = 009, Direction = Direction.Inbound, Order = 2},
				new RouteStop { RouteID = 08, StopID = 095, Direction = Direction.Inbound, Order = 3},
				new RouteStop { RouteID = 08, StopID = 014, Direction = Direction.Inbound, Order = 4},
				new RouteStop { RouteID = 08, StopID = 016, Direction = Direction.Inbound, Order = 5},
				new RouteStop { RouteID = 08, StopID = 094, Direction = Direction.Inbound, Order = 6},
				new RouteStop { RouteID = 08, StopID = 083, Direction = Direction.Inbound, Order = 7},
				new RouteStop { RouteID = 08, StopID = 093, Direction = Direction.Inbound, Order = 8},
				new RouteStop { RouteID = 08, StopID = 092, Direction = Direction.Inbound, Order = 9},
				new RouteStop { RouteID = 08, StopID = 024, Direction = Direction.Inbound, Order = 10},
				new RouteStop { RouteID = 09, StopID = 070, Direction = Direction.Outbound, Order = 1},
				new RouteStop { RouteID = 09, StopID = 097, Direction = Direction.Outbound, Order = 2},
				new RouteStop { RouteID = 09, StopID = 098, Direction = Direction.Outbound, Order = 3},
				new RouteStop { RouteID = 09, StopID = 099, Direction = Direction.Outbound, Order = 4},
				new RouteStop { RouteID = 09, StopID = 100, Direction = Direction.Outbound, Order = 5},
				new RouteStop { RouteID = 09, StopID = 101, Direction = Direction.Outbound, Order = 6},
				new RouteStop { RouteID = 09, StopID = 102, Direction = Direction.Outbound, Order = 7},
				new RouteStop { RouteID = 09, StopID = 103, Direction = Direction.Outbound, Order = 8},
				new RouteStop { RouteID = 09, StopID = 104, Direction = Direction.Outbound, Order = 9},
				new RouteStop { RouteID = 09, StopID = 105, Direction = Direction.Outbound, Order = 10},
				new RouteStop { RouteID = 09, StopID = 106, Direction = Direction.Outbound, Order = 11},
				new RouteStop { RouteID = 09, StopID = 107, Direction = Direction.Outbound, Order = 12},
				new RouteStop { RouteID = 09, StopID = 108, Direction = Direction.Outbound, Order = 13},
				new RouteStop { RouteID = 09, StopID = 109, Direction = Direction.Outbound, Order = 14},
				new RouteStop { RouteID = 09, StopID = 110, Direction = Direction.Outbound, Order = 15},
				new RouteStop { RouteID = 09, StopID = 111, Direction = Direction.Outbound, Order = 16},
				new RouteStop { RouteID = 09, StopID = 112, Direction = Direction.Outbound, Order = 17},
				new RouteStop { RouteID = 09, StopID = 112, Direction = Direction.Inbound, Order = 1},
				new RouteStop { RouteID = 09, StopID = 111, Direction = Direction.Inbound, Order = 2},
				new RouteStop { RouteID = 09, StopID = 110, Direction = Direction.Inbound, Order = 3},
				new RouteStop { RouteID = 09, StopID = 109, Direction = Direction.Inbound, Order = 4},
				new RouteStop { RouteID = 09, StopID = 108, Direction = Direction.Inbound, Order = 5},
				new RouteStop { RouteID = 09, StopID = 107, Direction = Direction.Inbound, Order = 6},
				new RouteStop { RouteID = 09, StopID = 106, Direction = Direction.Inbound, Order = 7},
				new RouteStop { RouteID = 09, StopID = 105, Direction = Direction.Inbound, Order = 8},
				new RouteStop { RouteID = 09, StopID = 104, Direction = Direction.Inbound, Order = 9},
				new RouteStop { RouteID = 09, StopID = 103, Direction = Direction.Inbound, Order = 10},
				new RouteStop { RouteID = 09, StopID = 102, Direction = Direction.Inbound, Order = 11},
				new RouteStop { RouteID = 09, StopID = 101, Direction = Direction.Inbound, Order = 12},
				new RouteStop { RouteID = 09, StopID = 100, Direction = Direction.Inbound, Order = 13},
				new RouteStop { RouteID = 09, StopID = 099, Direction = Direction.Inbound, Order = 14},
				new RouteStop { RouteID = 09, StopID = 098, Direction = Direction.Inbound, Order = 15},
				new RouteStop { RouteID = 09, StopID = 097, Direction = Direction.Inbound, Order = 16},
				new RouteStop { RouteID = 09, StopID = 070, Direction = Direction.Inbound, Order = 17}

				);
			#endregion
		}
	}
}