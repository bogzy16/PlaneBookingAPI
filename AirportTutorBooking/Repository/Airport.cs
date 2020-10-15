using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportTutorBooking.IRepository;
using AirportTutorBooking.Models;
using AirportTutorBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportTutorBooking.Repository
{
    public class Airport : IAirports
    {
        private readonly AppDBContext _appDBContext;

        public Airport(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<AirportsModel> CreateRecord(AirportsModel request)
        {
            _appDBContext.Add(request);

            await _appDBContext.SaveChangesAsync();

            return request;
        }

        public async Task<AirportsModel> DeleteRecord(AirportsModel request)
        {
            var entity = await _appDBContext.Airports.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

            if (entity != null)
            {
                entity.isActive = false;
                _appDBContext.Update(entity);
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<AirportsModel>> GetAirportPlanes(AirportsModel request)
        {
            return await _appDBContext.Airports.Where(p => p.Id == request.Id).Include(c => c.AirportPlanes).ToListAsync();
        }

        public async Task<List<AirportsModel>> GetAllList()
        {
            return await _appDBContext.Airports.ToListAsync();
        }

        public async Task<AirportsModel> UpdateRecord(AirportsModel request)
        {
            var entity = await _appDBContext.Airports.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

            if (entity != null)
            {
                _appDBContext.Update(entity);
                return entity;
            }
            else
            {
                return null;
            }
        }
    }
}
