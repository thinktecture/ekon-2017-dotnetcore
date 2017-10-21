using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class PersonService
{
	private readonly EkonDbContext _ctx;

	public PersonService(EkonDbContext ctx)
	{
		_ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
	}

	public IEnumerable<Person> LoadAll()
	{
		foreach (var entity in _ctx.Persons.AsNoTracking())
		{
			_ctx.Entry(entity).State = EntityState.Detached;
			yield return entity;
		}
	}

	public Person LoadById(int id)
	{
		var entity = _ctx.Persons
			.AsNoTracking()
			.Single(i => i.Id == id);

		_ctx.Entry(entity).State = EntityState.Detached;
		return entity;
	}

	public Person Add(Person entry)
	{
		var entity = new Person();

		// Todo: Copy properties
		entity.FirstName = entry.FirstName;
		entity.LastName = entry.LastName;

		_ctx.Persons.Add(entity);
		_ctx.SaveChanges();

		_ctx.Entry(entity).State = EntityState.Detached;
		return entity;
	}

	public Person Update(int id, Person entry)
	{
		var entity = _ctx.Persons
			.Single(i => i.Id == id);

		// todo: Copy properties
		entity.FirstName = entry.FirstName;
		entity.LastName = entry.LastName;

		_ctx.SaveChanges();

		_ctx.Entry(entity).State = EntityState.Detached;
		return entity;
	}

	public void Delete(int id)
	{
		var entity = new Person() { Id = id };
		_ctx.Persons.Attach(entity);

		_ctx.Persons.Remove(entity);
		_ctx.SaveChanges();
	}
}
