﻿using Bll.Dtos;
using Bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
	/// <summary>
	/// Controller for all the itineraries, which are defined by the users.
	/// </summary>
	[Route("api/itinerary")]
	[ApiController]
	public class ItineraryController : ControllerBase
	{
		private readonly IItineraryService itineraryService;

        public ItineraryController(IItineraryService service)
        {
			itineraryService = service;
        }

		// POST: api/itinerary
		/// <summary>
		/// Creates a new itinerary.
		/// </summary>
		/// <returns></returns>
		/// <response code="201">The creation of the new itinerary is succesful</response>
		[ProducesResponseType(StatusCodes.Status201Created)]
		[HttpPost]
		public ActionResult<ItineraryDto> CreateNewItinerary([FromBody]ItineraryDto itinerary)
		{
			itineraryService.CreateNewItinerary(itinerary);
			
			return Ok("Hello World!");
		}

		//PUT: api/itinerary/{id}
		/// <summary>
		/// Modify an existing itinerary.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <response code="202">The update of the itinerary is succesful</response>
		[ProducesResponseType(StatusCodes.Status202Accepted)]
		[HttpPut("{id}")]
		public ActionResult<ItineraryDto> UpdateItinerary(int id, [FromBody]ItineraryDto itinerary)
		{
			itineraryService.UpdateItinerary(id, itinerary);

			return Ok("Hello World!");
		}

		//GET: api/itinerary/start={start}&end={end}
		/// <summary>
		/// Gets an itinerary between two locations.
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		/// <response code="200">The found itinerary is returned</response>
		/// <response code="404">The itinerary is not found</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet]
		public ActionResult<IEnumerable<ItineraryDto>> GetItinerary(string start = null, string end = null)
		{
			itineraryService.GetItinerary(start, end);

			return Ok($"Hello! Start is {start} end is {end}");
		}

		//GET: api/itinerary/user={userId}
		/// <summary>
		/// Gets all itineraries for a user.
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		/// <response code="200">The found itineraries are returned</response>
		/// <response code="404">The itineraries are not found</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet("{userId}")]
		public ActionResult<IEnumerable<ItineraryDto>> GetItinerary(int userId)
		{
			itineraryService.GetItinerary(userId);

			return Ok($"Hello! User is {userId}");
		}
	}
}
