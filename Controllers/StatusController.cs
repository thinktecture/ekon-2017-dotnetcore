using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[Route("api/[controller]")]
public class StatusController: Controller
{
	private readonly ILogger<StatusController> _logger;
	private readonly EkonDbContext _ctx;

	public StatusController(ILogger<StatusController> logger, EkonDbContext ctx)
	{
		_logger = logger;
		_logger?.LogTrace("{controller} created", nameof(StatusController));

		_ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
	}

	[HttpGet("ensureDatabase")]
	public string EnsureDatabase()
	{
		_ctx.Database.EnsureCreated();
		return "Okay";
	}
}
