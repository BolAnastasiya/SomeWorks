﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stilizasia
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HotelsEntities : DbContext
    {
        private static HotelsEntities _context;
        public HotelsEntities()
            : base("name=HotelsEntities")
        {
        }
    
        public static HotelsEntities GetContext()
        {
            if(_context == null)
            {
                _context = new HotelsEntities();
            }
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Country> Country { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Hotel_comment> Hotel_comment { get; set; }
        public DbSet<HotellImage> HotellImage { get; set; }
        public DbSet<Tour> Tour { get; set; }
        public DbSet<Type_Hotel> Type_Hotel { get; set; }
    }
}