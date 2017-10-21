using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Person
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id {get; set;}
	public string FirstName { get; set; }
	public string LastName { get; set; }

	public ICollection<Booking> Bookings { get; set; }
}
