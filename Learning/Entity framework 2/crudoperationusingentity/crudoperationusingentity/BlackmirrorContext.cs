using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace crudoperationusingentity;

public partial class BlackmirrorContext : DbContext
{
    public BlackmirrorContext()
    {
    }

    public BlackmirrorContext(DbContextOptions<BlackmirrorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-URM2ERI;Initial Catalog=blackmirror;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("students");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Rollno).HasColumnName("rollno");
            entity.Property(e => e.Studept).HasColumnName("studept");
            entity.Property(e => e.Stuname).HasColumnName("stuname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
