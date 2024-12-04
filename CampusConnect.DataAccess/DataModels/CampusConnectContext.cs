using Microsoft.EntityFrameworkCore;
using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.DataModels.CampusConnect.DataAccess.DataModels;

namespace CampusConnect.DataAccess.DataModels
{
    public partial class CampusConnectContext : DbContext
    {
        public CampusConnectContext()
        {
        }

        public CampusConnectContext(DbContextOptions<CampusConnectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventCategory> EventCategories { get; set; }
        public virtual DbSet<EventAttendee> EventAttendees { get; set; }
        public virtual DbSet<GroupChat> GroupChats { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<EventOrganizer> EventOrganizers { get; set; }
        // public virtual DbSet<UserSetting> UserSettings { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.UserRole).IsRequired().HasMaxLength(20).HasDefaultValue("User");
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });
            
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventID);
                entity.Property(e => e.EventName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasColumnType("ntext");
                entity.Property(e => e.StartDateTime).IsRequired();
                entity.Property(e => e.EndDateTime).IsRequired();
                entity.Property(e => e.Location).HasMaxLength(255);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                entity.Property(e=>e.IsActive).HasDefaultValue(1);
                entity.HasOne(d => d.Category).WithMany(p => p.Events).HasForeignKey(d => d.CategoryID);
            });

            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryID);
                entity.Property(e => e.CategoryName).IsRequired().HasMaxLength(50);
            });
            
            modelBuilder.Entity<EventAttendee>(entity =>
            {
                entity.HasKey(e => e.AttendeeID);
                entity.Property(e => e.RSVPStatus).HasMaxLength(20);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                entity.HasOne(d => d.Event).WithMany(p => p.Attendees).HasForeignKey(d => d.EventID);
                entity.HasOne(d => d.User).WithMany(p => p.EventAttendees).HasForeignKey(d => d.UserID);
            });

            modelBuilder.Entity<GroupChat>(entity =>
            {
                entity.HasKey(e => e.ChatID);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                entity.HasOne(d => d.Event).WithOne(p => p.GroupChat).HasForeignKey<GroupChat>(d => d.EventID);
            });

            modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.HasKey(e => e.MessageID);
                entity.Property(e => e.MessageContent).HasColumnType("ntext");
                entity.Property(e => e.SentAt).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                entity.HasOne(d => d.GroupChat).WithMany(p => p.Messages).HasForeignKey(d => d.ChatID);
                entity.HasOne(d => d.User).WithMany(p => p.ChatMessages).HasForeignKey(d => d.UserID);
            });

            modelBuilder.Entity<EventOrganizer>(entity =>
            {
                entity.HasKey(e => e.EventOrganizerID);
                entity.Property(e => e.Role).HasMaxLength(50);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                entity.HasOne(d => d.Event).WithMany(p => p.Organizers).HasForeignKey(d => d.EventID);
                entity.HasOne(d => d.User).WithMany(p => p.OrganizedEvents).HasForeignKey(d => d.UserID);
            });

            // modelBuilder.Entity<UserSetting>(entity =>
            // {
            //     entity.HasKey(e => e.SettingID);
            //     entity.Property(e => e.SettingKey).IsRequired().HasMaxLength(50);
            //     entity.Property(e => e.SettingValue).HasMaxLength(255);
            //     entity.HasOne(d => d.User).WithMany(p => p.UserSettings).HasForeignKey(d => d.UserID);
            // });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.HasKey(e => e.VolunteerID);
                entity.Property(e => e.Status).HasMaxLength(20);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                entity.HasOne(d => d.Event).WithMany(p => p.Volunteers).HasForeignKey(d => d.EventID);
                entity.HasOne(d => d.User).WithMany(p => p.VolunteeredEvents).HasForeignKey(d => d.UserID);
            });
        }
    }
}