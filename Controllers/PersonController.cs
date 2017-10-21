using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[Route("api/[controller]")]
public class PersonController: Controller
{
	// Postman Collection to test this controller:
	// https://documenter.getpostman.com/view/485169/ekon-2017-net-core/71FVqCv

	private readonly ILogger<PersonController> _logger;
	private readonly PersonService _svc;

	public PersonController(ILogger<PersonController> logger, PersonService svc)
	{
		_logger = logger;
		_logger?.LogTrace("{controller} created", nameof(PersonController));

		_svc = svc ?? throw new ArgumentNullException(nameof(svc));
	}

	[HttpGet]
	public IEnumerable<Person> Get()
	{
		return _svc.LoadAll();
	}

	[HttpGet("{id}")]
	public Person Get(int id)
	{
		return _svc.LoadById(id);
	}

	[HttpPost]
	public Person Add([FromBody] Person person)
	{
		return _svc.Add(person);
	}

	[HttpPut("{id}")]
	public Person Update(int id, [FromBody] Person person)
	{
		return _svc.Update(id, person);
	}

	[HttpDelete("{id}")]
	public void Delete(int id)
	{
		_svc.Delete(id);
	}
}
