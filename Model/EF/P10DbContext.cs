using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.EF
{
    public partial class P10DbContext : DbContext
    {
        public P10DbContext()
            : base("name=P10DbContext2")
        {
        }

        public virtual DbSet<Categorys> Categorys { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Posts_Categorys> Posts_Categorys { get; set; }
        public virtual DbSet<Profiles> Profiles { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Posts>()
                .Property(e => e.Title)
                .IsUnicode(true);

            modelBuilder.Entity<Posts>()
                .Property(e => e.Sumary)
                .IsUnicode(true);

            modelBuilder.Entity<Posts>()
                .Property(e => e.Content)
                .IsUnicode(true);

            modelBuilder.Entity<Profiles>()
                .Property(e => e.Intro)
                .IsUnicode(true);

            modelBuilder.Entity<Profiles>()
                .Property(e => e.Publications)
                .IsUnicode(true);

            modelBuilder.Entity<Profiles>()
                .Property(e => e.ResearchArea)
                .IsUnicode(true);

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsUnicode(true);
        }
    }
}
