using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CameraShop.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace CameraShop.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("ShopContext")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FileImg> FileImgs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            this.Configuration.LazyLoadingEnabled = false;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Product>()
             .HasMany(c => c.FileImgs).WithMany(i => i.Products)
            .Map(t => t.MapLeftKey("ProductID")
             .MapRightKey("file_id")
            .ToTable("ProductImg"));



        }
        public virtual int sp_insert_file(string file_name, string file_ext, string file_base64)
        {
            var file_nameParameter = file_name != null ?
                new ObjectParameter("file_name", file_name) :
                new ObjectParameter("file_name", typeof(string));

            var file_extParameter = file_ext != null ?
                new ObjectParameter("file_ext", file_ext) :
                new ObjectParameter("file_ext", typeof(string));

            var file_base64Parameter = file_base64 != null ?
                new ObjectParameter("file_base64", file_base64) :
                new ObjectParameter("file_base64", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_insert_file", file_nameParameter, file_extParameter, file_base64Parameter);
        }

        
    }


}