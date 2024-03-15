using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    internal class Контекст : DbContext
    {
        public DbSet<Пользователи> Пользователи { get; set; }
        public DbSet<Фотографии> Фотографии { get; set; }
        public DbSet<Отметки_на_фото> Отметки_на_фото { get; set; }

        public Контекст()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Ebnia.db");
        }

    }
}
