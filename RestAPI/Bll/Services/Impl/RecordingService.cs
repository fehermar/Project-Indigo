﻿using Bll.Dtos;
using Bll.Exceptions;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Services.Impl
{
	public class RecordingService : IRecordingService
	{
		private readonly TransportationContext transportationContext;

		public RecordingService(TransportationContext transportationContext)
		{
			this.transportationContext = transportationContext;
		}

		public RecordingDto CreateNewRecording(RecordingDto recording)
		{
			Recording entity = new Recording
			{
				Itinerary = new Itinerary
				{
					Start = recording.Itinerary.Start,
					End = recording.Itinerary.End,
				}
			};
			transportationContext.Recordings.Add(entity);
			transportationContext.SaveChanges();
			return new RecordingDto
			{
				ID = entity.ID,
				Itinerary = new ItineraryDto
				{
					ID = entity.Itinerary.ID,
					Start = entity.Itinerary.Start,
					End = entity.Itinerary.End,
				}
			};
		}

		public RecordingDto GetRecording(int id)
		{
			if(transportationContext.Recordings.Any(r => r.ID == id))
				return transportationContext.Recordings.Where(r => r.ID == id).Select(r => new RecordingDto
				{
					ID = r.ID,
					Itinerary = new ItineraryDto()
					{
						ID = r.Itinerary.ID,
						Start = r.Itinerary.Start,
						End = r.Itinerary.End,
					}
				}).FirstOrDefault();
			else
				throw new EntityNotFoundException("The recording with the given id does not exist");
		}

		public IEnumerable<RecordingDto> GetRecordings()
		{
			return transportationContext.Recordings.Select(r => new RecordingDto
			{
				ID = r.ID,
				Itinerary = new ItineraryDto()
				{
					ID = r.Itinerary.ID,
					Start = r.Itinerary.Start,
					End = r.Itinerary.End,
				}
			});
		}
	}
}
