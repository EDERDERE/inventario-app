﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class InventarioContext : DbContext
{
    public InventarioContext(DbContextOptions<InventarioContext> options) : base(options) { }

    public DbSet<Producto> Productos { get; set; }
}
