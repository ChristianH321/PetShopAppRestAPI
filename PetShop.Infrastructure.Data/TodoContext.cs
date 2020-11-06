﻿using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using ToDoApiAuthentication;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace PetShop.Infrastructure.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<TodoItem> TodoItems { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }

    }
}
