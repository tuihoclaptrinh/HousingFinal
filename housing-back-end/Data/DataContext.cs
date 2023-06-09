﻿using housing_back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace housing_back_end.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}

    public DbSet<City> Cities { get; set; }
    public DbSet<User> Users { get; set; }

}