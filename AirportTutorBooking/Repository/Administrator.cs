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
    public class Administrator : IAdministrator
    {
        private readonly AppDBContext _appDBContext;

        public Administrator(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<AdministratorsModel> CreateRecord(AdministratorsModel request)
        {
            _appDBContext.Add(request);

            await _appDBContext.SaveChangesAsync();

            return request;
        }

        public async Task<AdministratorsModel> DeleteRecord(AdministratorsModel request)
        {
            var entity = await _appDBContext.Administrators.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

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

        public async Task<List<AdministratorsModel>> GetAllList()
        {
            return await _appDBContext.Administrators.Where(p => p.isActive == true).ToListAsync();
        }

        public async Task<AdministratorsModel> Login(AdministratorsModel request)
        {
            var entity = await _appDBContext.Administrators.Where(p => p.Email == request.Email && p.Password == request.Password && p.isActive == true).FirstOrDefaultAsync();

            if (entity != null)
                return entity;
            else
                return null;
        }

        public async Task<AdministratorsModel> UpdateRecord(AdministratorsModel request)
        {
            var entity = await _appDBContext.Administrators.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

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
