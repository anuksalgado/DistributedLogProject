using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DSSystem
{
  internal class DBManager : DbContext
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

        modelBuilder.Entity<LoginStruct>().HasData(logins);


    }
      public DbSet<LoginStruct> LoginStruct { get; set; } = default!;
    #endregion
}

}
