using System;
using System.Collections.Generic;
using System.Text;
using Web_HelpDesk.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Web_HelpDesk.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Priority> Priorities { get; set; } // *refer to notes (ENTITYNAMES)
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketDetail> TicketDetails { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<AdditionalNotification> AdditionalNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Tables            

            modelBuilder.Entity<Priority>().HasData(new Priority { Id = 1, PriorityLevel = "Low" });
            modelBuilder.Entity<Priority>().HasData(new Priority { Id = 2, PriorityLevel = "Medium" });
            modelBuilder.Entity<Priority>().HasData(new Priority { Id = 3, PriorityLevel = "High" });
            modelBuilder.Entity<Priority>().HasData(new Priority { Id = 4, PriorityLevel = "Critical" });

            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 1, TicketStatus = "New" });
            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 2, TicketStatus = "Open" });
            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 3, TicketStatus = "Closed" });
            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 4, TicketStatus = "On Hold" });

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, ProblemType = "Computer Hardware Problem" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, ProblemType = "Printer Problem" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, ProblemType = "Problem with ERP System" });            

            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, DepartmentName = "Accounts" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, DepartmentName = "Maintenance" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 3, DepartmentName = "Stores" });            


            modelBuilder.Entity<Ticket>().HasData(new Ticket { Id = 1, Logged = new DateTime(2020, 06, 30, 15, 00, 00), Creator = "John Bailey", Subject = "Computer not booting. Screen is blank.", EmailAddress = "john@john.com", Department = "Accounts", Location = "Durban", PriorityId = 2, StatusId = 1, Assignee = "1" });
            modelBuilder.Entity<Ticket>().HasData(new Ticket { Id = 2, Logged = new DateTime(2020, 06, 29, 14, 00, 00), Creator = "Joe Soap", Subject = "Phone not receiving email.", EmailAddress ="joe@joe.com", Department = "Maintenance", Location = "Capetown",  PriorityId = 4, StatusId = 1, Assignee = "1" });
        }
            
            
    }
}
