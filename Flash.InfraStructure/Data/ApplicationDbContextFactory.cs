using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Flash.InfraStructure.Data;
using System;

namespace Flash.InfraStructure
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql("Server=localhost;User=root;password=eltinho123;database=bd_flash", ServerVersion.AutoDetect("Server=localhost;User=root;password=eltinho123;database=bd_flash"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
