using DSSystem.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DSSystem
{
  public class DBManager : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = customer.db");
    }

    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //Seeding initial DB
        String dateString, format;
        dateString = "12/11/2024";
        format = "d";
        //CultureInfo provider = CultureInfo.InvariantCulture;
        List<LoginStruct> logins = new List<LoginStruct>();
        LoginStruct login = new LoginStruct
        {
            Username = "Wilson",
            Password = "1234",
            DateTime = DateTime.ParseExact(dateString, format, null),
            Success = true
        };
        logins.Add(login);

        login = new LoginStruct
        {
            Username = "Isak",
            Password = "1234",
            DateTime = DateTime.ParseExact(dateString, format, null),
            Success = true
        };
        logins.Add(login);

        login = new LoginStruct
        {
            Username = "Burn",
            Password = "1234",
            DateTime = DateTime.ParseExact(dateString, format, null),
            Success = true
        };
        logins.Add(login);
        var receipts = new List<ReceiptStruct>
        {
            new ReceiptStruct { ReceiptID = "R001", cusName = "Anuk", puchaseDate = new DateTime(2024, 1, 10) },
            new ReceiptStruct { ReceiptID = "R002", cusName = "Palmer", puchaseDate = new DateTime(2024, 2, 14) },
            new ReceiptStruct { ReceiptID = "R003", cusName = "Jokovic", puchaseDate = new DateTime(2024, 3, 3) },
            new ReceiptStruct { ReceiptID = "R004", cusName = "Hazard", puchaseDate = new DateTime(2024, 4, 1) },
            new ReceiptStruct { ReceiptID = "R005", cusName = "Enzo", puchaseDate = new DateTime(2024, 1, 22) },
            new ReceiptStruct { ReceiptID = "R006", cusName = "Caicedo", puchaseDate = new DateTime(2024, 2, 5) },
            new ReceiptStruct { ReceiptID = "R007", cusName = "Lavia", puchaseDate = new DateTime(2024, 3, 7) },
            new ReceiptStruct { ReceiptID = "R008", cusName = "Cech", puchaseDate = new DateTime(2024, 4, 15) },
            new ReceiptStruct { ReceiptID = "R009", cusName = "Drogba", puchaseDate = new DateTime(2024, 1, 18) },
            new ReceiptStruct { ReceiptID = "R010", cusName = "Lamps", puchaseDate = new DateTime(2024, 2, 27) },
            new ReceiptStruct { ReceiptID = "R011", cusName = "Mount", puchaseDate = new DateTime(2024, 3, 13) },
            new ReceiptStruct { ReceiptID = "R012", cusName = "Kante", puchaseDate = new DateTime(2024, 4, 9) },
            new ReceiptStruct { ReceiptID = "R013", cusName = "Silva", puchaseDate = new DateTime(2024, 2, 20) },
            new ReceiptStruct { ReceiptID = "R014", cusName = "Sterling", puchaseDate = new DateTime(2024, 3, 29) },
            new ReceiptStruct { ReceiptID = "R015", cusName = "Nkunku", puchaseDate = new DateTime(2024, 1, 5) },
        };
        var items = new List<itemStruct>
        {
            new itemStruct { Id = 1, itemName = "Tomato", price = 12, quantity = 2, MFD = new DateTime(2023, 12, 5), ReceiptStructReceiptID = "R001" },
            new itemStruct { Id = 2, itemName = "Onion", price = 10, quantity = 1, MFD = new DateTime(2023, 12, 1), ReceiptStructReceiptID = "R002" },
            new itemStruct { Id = 3, itemName = "Cat Food", price = 124, quantity = 1, MFD = new DateTime(2023, 10, 10), ReceiptStructReceiptID = "R003" },
            new itemStruct { Id = 4, itemName = "Coca Cola", price = 13, quantity = 3, MFD = new DateTime(2023, 11, 5), ReceiptStructReceiptID = "R004" },
            new itemStruct { Id = 5, itemName = "Chicken", price = 134, quantity = 2, MFD = new DateTime(2023, 12, 20), ReceiptStructReceiptID = "R005" },
            new itemStruct { Id = 6, itemName = "Onion", price = 10, quantity = 4, MFD = new DateTime(2023, 9, 15), ReceiptStructReceiptID = "R006" },
            new itemStruct { Id = 7, itemName = "Chillies", price = 3, quantity = 1, MFD = new DateTime(2023, 10, 3), ReceiptStructReceiptID = "R007" },
            new itemStruct { Id = 8, itemName = "Tomato", price = 12, quantity = 3, MFD = new DateTime(2023, 12, 10), ReceiptStructReceiptID = "R008" },
            new itemStruct { Id = 9, itemName = "Chicken", price = 134, quantity = 1, MFD = new DateTime(2023, 8, 27), ReceiptStructReceiptID = "R009" },
            new itemStruct { Id = 10, itemName = "Coca Cola", price = 13, quantity = 2, MFD = new DateTime(2023, 7, 30), ReceiptStructReceiptID = "R010" },
            new itemStruct { Id = 11, itemName = "Cat Food", price = 124, quantity = 5, MFD = new DateTime(2023, 6, 5), ReceiptStructReceiptID = "R011" },
            new itemStruct { Id = 12, itemName = "Chillies", price = 3, quantity = 2, MFD = new DateTime(2023, 11, 12), ReceiptStructReceiptID = "R012" },
            new itemStruct { Id = 13, itemName = "Tomato", price = 12, quantity = 1, MFD = new DateTime(2023, 12, 8), ReceiptStructReceiptID = "R013" },
            new itemStruct { Id = 14, itemName = "Onion", price = 10, quantity = 2, MFD = new DateTime(2023, 10, 22), ReceiptStructReceiptID = "R014" },
            new itemStruct { Id = 15, itemName = "Coca Cola", price = 13, quantity = 4, MFD = new DateTime(2023, 9, 17), ReceiptStructReceiptID = "R015" },
        };
        modelBuilder.Entity<ReceiptStruct>().HasData(receipts);
        modelBuilder.Entity<itemStruct>().HasData(items);
        
        modelBuilder.Entity<LoginStruct>().HasData(logins);
    }
      public DbSet<LoginStruct> LoginStruct { get; set; } = default!;
      public DbSet<itemStruct> itemStruct { get; set; } = default!;
      public DbSet<ReceiptStruct> receiptStruct { get; set; } = default!;
    #endregion
}

}
