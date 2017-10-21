using System.ComponentModel.DataAnnotations.Schema;

public class Booking
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string Title { get; set; }

	public Person Person { get; set; }
}
