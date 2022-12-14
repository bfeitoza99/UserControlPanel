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
            optionsBuilder.UseSqlServer("Server=localhost; Integrated Security =true; Database=UserControlPanel;Trusted_Connection=True; Encrypt=False; Persist Security Info =False;", x =>
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
                  Description = "Masculino",
                  Initials = "M"
              },
              new UserGender
              {
                  Id = 2,
                  CreatedDate = DateTime.Now,
                  DeletedDate = null,
                  Description = "Feminino",
                  Initials = "F"
              },
              new UserGender
              {
                  Id = 3,
                  CreatedDate = DateTime.Now,
                  DeletedDate = null,
                  Description = "Outro",
                  Initials = "OT"
              },
              new UserGender
              {
                  Id = 4,
                  CreatedDate = DateTime.Now,
                  DeletedDate = null,
                  Description = "Prefiro não dizer",
                  Initials = "PND"
              });

            base.OnModelCreating(modelBuilder);
        }
    }
}
