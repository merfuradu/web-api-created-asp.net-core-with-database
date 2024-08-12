using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using WebAPI_week1.Models;
namespace WebAPI_week1;

public class PersonsDB : DbContext
    {
        public PersonsDB(DbContextOptions<PersonsDB> options)
        : base(options) { }

        public DbSet<PersonalData> PersonalDatas => Set<PersonalData>();
        public DbSet<Address> Addresses => Set<Address>();

    }
