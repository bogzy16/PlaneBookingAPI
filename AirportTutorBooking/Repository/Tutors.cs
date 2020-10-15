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
    public class Tutors : ITutors
    {
        private readonly AppDBContext _appDBContext;

        public Tutors(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<TutorsModel> CreateRecord(TutorsModel request)
        {
            _appDBContext.Add(request);

            await _appDBContext.SaveChangesAsync();

            return request;
        }

        public async Task<TutorsModel> DeleteRecord(TutorsModel request)
        {
            var entity = await _appDBContext.Tutors.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

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

        public async Task<List<TutorsModel>> GetAllList()
        {
            return await _appDBContext.Tutors.ToListAsync();
        }

        public async Task<TutorsModel> Login(TutorsModel request)
        {
            var entity = await _appDBContext.Tutors.Where(p => p.Email == request.Email && p.Password == request.Password && p.isActive == true).FirstOrDefaultAsync();

            if (entity != null)
                return entity;
            else
                return null;
        }

        public async Task<TutorsModel> UpdateRecord(TutorsModel request)
        {
                var entity = await _appDBContext.Tutors.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

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
