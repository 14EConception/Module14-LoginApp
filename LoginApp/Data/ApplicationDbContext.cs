using Microsoft.EntityFrameworkCore;
using LoginApp.Model;
using System.IO;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(
       DbContextOptionsBuilder optionsBuilder)
    {

        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LoginApp", "LoginApp.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
        var connectionString = $"Data Source={dbPath}";

        optionsBuilder.UseSqlite(connectionString);

    }

    public DbSet<User> Users { get; set; }

    public void SeedData()
    {
        if (!Users.Any())
        {
            var hashedPassword1 = BCrypt.Net.BCrypt.HashPassword("motdepasse");
            var hashedPassword2 = BCrypt.Net.BCrypt.HashPassword("bonjour");
            var user1 = new User { Email = "admin@test.com", Password = hashedPassword1 };
            var user2 = new User { Email = "user@test.com", Password = hashedPassword2 };

            Users.AddRange(user1, user2);

            SaveChanges();
        }

    }
}
