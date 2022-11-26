using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.Domain.Entities.User;

namespace UserControlPanel.Data
{
    public class UserControlPanelContext : DbContext
    {
        public UserControlPanelContext(DbContextOptions<UserControlPanelContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<UserAdress> UserAdress { get; set; }
        public DbSet<UserGender> UserGender { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Initial Catalog=UserControlPanel; Data Source=localhost,1450; Persist Security Info=False;User ID=sa;Password=1234Teste@;Encrypt=False;", x =>
            {
                x.MigrationsAssembly("UserControlPanel.Data");
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGender>().HasData(
              new UserGender
              {
                  Id = 1,
                  CreatedDate = DateTime.Now,
                  DeletedDate = null,
                  Description = "",
                  Initials = ""
              },
              new UserGender
              {
                  Id = 2,
                  CreatedDate = DateTime.Now,
                  DeletedDate = null,
                  Description = "",
                  Initials = ""
              },
              new UserGender
              {
                  Id = 3,
                  CreatedDate = DateTime.Now,
                  DeletedDate = null,
                  Description = "",
                  Initials = ""
              },
              new UserGender
              {
                  Id = 4,
                  CreatedDate = DateTime.Now,
                  DeletedDate = null,
                  Description = "",
                  Initials = ""
              },
              new UserGender
              {
                  Id = 5,
                  CreatedDate = DateTime.Now,
                  DeletedDate = null,
                  Description = "",
                  Initials = ""
              });

            base.OnModelCreating(modelBuilder);
        }
    }
}
