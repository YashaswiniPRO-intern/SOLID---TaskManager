using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Repositories.Entities;

namespace TaskManager.Repositories
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.User)//each task belongs to a user
                .WithMany(u => u.Tasks)//one user can have many tasks
                .HasForeignKey(t => t.UserId)//userId is the foreign key in tasks table
                .OnDelete(DeleteBehavior.Cascade);//if we delete a user, all tasks associated with them will be deleted 
            base.OnModelCreating(modelBuilder);
        }
    }

}
