using Homework19.Data;
using Homework19.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Homework19.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly PersonContext _dbContext;

		public PersonController(PersonContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpPost("AddUser")]
		public IActionResult AddUser(Person person)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_dbContext.Persons.Add(person);
			_dbContext.SaveChanges();

			return Ok(_dbContext.Persons.ToList());
		}

		[HttpGet("GetUsers")]
		public IActionResult GetUsers()
		{
			return Ok(_dbContext.Persons.ToList());
		}

		[HttpGet("{id}")]
		public IActionResult GetUserById(int id)
		{
			var person = _dbContext.Persons.Find(id);
			if (person == null)
			{
				return NotFound();
			}

			return Ok(person);
		}


		[HttpDelete("{id}")]
		public IActionResult DeleteUser(int id)
		{
			var person = _dbContext.Persons.Find(id);
			if (person == null)
			{
				return NotFound();
			}

			_dbContext.Persons.Remove(person);
			_dbContext.SaveChanges();

			return Ok(_dbContext.Persons.ToList());
		}


		[HttpPut("{id}")]
		public IActionResult UpdatePerson(int id, Person updatedPerson)
		{
			var person = _dbContext.Persons.Find(id);
			if (person == null)
			{
				return NotFound();
			}

			_dbContext.SaveChanges();

			return Ok(_dbContext.Persons.ToList());
		}


	}
}
