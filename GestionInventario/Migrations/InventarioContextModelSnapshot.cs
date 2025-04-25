using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TuNamespace;

namespace TuNamespace.Migrations
{
    [DbContext(typeof(InventarioContext))]
    partial class InventarioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Producto", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("Oracle:Identity", "1, 1");

                b.Property<string>("Nombre")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.Property<string>("Descripcion")
                    .HasMaxLength(255)
                    .HasColumnType("varchar(255)");

                b.Property<decimal>("Precio")
                    .HasColumnType("number(10,2)");

                b.Property<int>("Cantidad")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Producto");
            });
        }
    }
}
