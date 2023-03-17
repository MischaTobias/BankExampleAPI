using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.DevsuDbContext;

public partial class DevsuContext : DbContext
{
    public DevsuContext()
    {
    }

    public DevsuContext(DbContextOptions<DevsuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Accounttype> Accounttypes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Transactiontype> Transactiontypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PRIMARY");

            entity.ToTable("account");

            entity.HasIndex(e => e.AccountTypeId, "accountTypeId");

            entity.HasIndex(e => e.ClientId, "clientId");

            entity.Property(e => e.AccountNumber).HasColumnName("accountNumber");
            entity.Property(e => e.AccountTypeId).HasColumnName("accountTypeId");
            entity.Property(e => e.ClientId).HasColumnName("clientId");
            entity.Property(e => e.InitialBalance)
                .HasPrecision(10)
                .HasColumnName("initialBalance");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");

            entity.HasOne(d => d.AccountType).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccountTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("account_ibfk_2");

            entity.HasOne(d => d.Client).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("account_ibfk_1");
        });

        modelBuilder.Entity<Accounttype>(entity =>
        {
            entity.HasKey(e => e.AccountTypeId).HasName("PRIMARY");

            entity.ToTable("accounttype");

            entity.Property(e => e.AccountTypeId).HasColumnName("accountTypeId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PRIMARY");

            entity.ToTable("client");

            entity.HasIndex(e => e.PersonId, "personId");

            entity.Property(e => e.ClientId).HasColumnName("clientId");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");

            entity.HasOne(d => d.Person).WithMany(p => p.Clients)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_ibfk_1");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PRIMARY");

            entity.ToTable("person");

            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasColumnName("gender");
            entity.Property(e => e.Identification)
                .HasMaxLength(50)
                .HasColumnName("identification");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("transaction");

            entity.HasIndex(e => e.AccountNumber, "accountNumber");

            entity.HasIndex(e => e.TransactionTypeId, "transactionTypeId");

            entity.Property(e => e.TransactionId).HasColumnName("transactionId");
            entity.Property(e => e.AccountNumber).HasColumnName("accountNumber");
            entity.Property(e => e.Amount)
                .HasPrecision(10)
                .HasColumnName("amount");
            entity.Property(e => e.Balance)
                .HasPrecision(10)
                .HasColumnName("balance");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.TransactionTypeId).HasColumnName("transactionTypeId");

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AccountNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transaction_ibfk_1");

            entity.HasOne(d => d.TransactionType).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TransactionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transaction_ibfk_2");
        });

        modelBuilder.Entity<Transactiontype>(entity =>
        {
            entity.HasKey(e => e.TransactionTypeId).HasName("PRIMARY");

            entity.ToTable("transactiontype");

            entity.Property(e => e.TransactionTypeId).HasColumnName("transactionTypeId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
