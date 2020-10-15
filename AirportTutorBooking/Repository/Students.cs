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
    public class Students : IStudents
    {
        private readonly AppDBContext _appDBContext;

        public Students(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<StudentsModel> CreateRecord(StudentsModel request)
        {
            _appDBContext.Add(request);

            await _appDBContext.SaveChangesAsync();

            return request;
        }

        public async Task<StudentsModel> DeleteRecord(StudentsModel request)
        {
            var entity = await _appDBContext.Students.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

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

        public async Task<List<StudentsModel>> GetAllList()
        {
            return await _appDBContext.Students.ToListAsync();
        }

        public async Task<StudentsModel> Login(StudentsModel request)
        {
            var entity = await _appDBContext.Students.Where(p => p.Email == request.Email && p.Password == request.Password && p.isActive == true).FirstOrDefaultAsync();

            if (entity != null)
                return entity;
            else
                return null;
        }

        public async Task<StudentsModel> UpdateRecord(StudentsModel request)
        {
            var entity = await _appDBContext.Students.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

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
