using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
namespace WebAPI_week1; 

    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

        public DbSet<PersonalData> PersonalDatas => Set<PersonalData>();
        public DbSet<Address> Addresses => Set<Address>();

    }
