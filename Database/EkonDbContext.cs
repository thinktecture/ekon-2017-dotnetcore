using Microsoft.EntityFrameworkCore;

public class EkonDbContext: DbContext
{
	public DbSet<Person> Persons { get; set; }
	public DbSet<Booking> Bookings { get; set; }

	public EkonDbContext()
	{
	}

	public EkonDbContext(DbContextOptions<EkonDbContext> options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Person>().ToTable("Person");
		modelBuilder.Entity<Booking>().ToTable("Booking");
	}
}
