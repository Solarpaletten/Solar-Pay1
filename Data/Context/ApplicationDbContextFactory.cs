using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Data.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new NpgsqlDbContextOptionsBuilder<DataContext>();

            optionsBuilder.UseNgsql("Host=localhost;port=5432;Database=solarpay_db;User Id=postgres;Password=root;");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
