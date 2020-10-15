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
    public class Planes : IPlanes
    {
        private readonly AppDBContext _appDBContext;

        public Planes(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<PlanesModel> CreateRecord(PlanesModel request)
        {
            _appDBContext.Add(request);

            await _appDBContext.SaveChangesAsync();

            return request;
        }

        public async Task<PlanesModel> DeleteRecord(PlanesModel request)
        {
            var entity = await _appDBContext.Planes.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

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

        public async Task<List<PlanesModel>> GetAllList()
        {
            return await _appDBContext.Planes.ToListAsync();
        }

        public async Task<PlanesModel> UpdateRecord(PlanesModel request)
        {
            var entity = await _appDBContext.Planes.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

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
