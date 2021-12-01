using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OutdatedCalendarChatCore.Models
{
    public partial class OutdatedCalendarContext : DbContext
    {
        public OutdatedCalendarContext()
        {
        }

        public OutdatedCalendarContext(DbContextOptions<OutdatedCalendarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<EventObject> EventObjects { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageRecipient> MessageRecipients { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:outdatedcalendar.database.windows.net,1433;Initial Catalog=OutdatedCalendar;Persist Security Info=False;User ID=outdatedcalendar;Password=Zoie4121harris;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Age).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventObject>(entity =>
            {
                entity.ToTable("EventObject");

                entity.Property(e => e.Creator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Tags)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.SentDate).HasColumnType("datetime");

                entity.HasOne(d => d.FromPerson)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.FromPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Person");
            });

            modelBuilder.Entity<MessageRecipient>(entity =>
            {
                entity.HasKey(e => new { e.MessageId, e.ToPersonId });

                entity.ToTable("MessageRecipient");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.MessageRecipients)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageRecipient_Message");

                entity.HasOne(d => d.ToPerson)
                    .WithMany(p => p.MessageRecipients)
                    .HasForeignKey(d => d.ToPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageRecipient_Person");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
