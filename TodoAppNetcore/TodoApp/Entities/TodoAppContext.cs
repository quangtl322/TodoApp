using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Entities
{
    public class TodoAppContext :DbContext  
    {
        public TodoAppContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Employee> Employees{ get; set; }
       
    }
}
