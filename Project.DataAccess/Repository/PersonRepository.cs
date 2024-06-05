using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context) 
        {                
            _context = context;
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Add(Person model)
        {
            await _context.AddAsync(model);
            await Save();
            
        }

        public async Task<bool> Delete(int id)
        {
           bool status = false;
           var person = await _context.Persons.FindAsync(id);
           if(person!= null)
           {
                _context.Persons.Remove(person);
                await Save();
                status = true;
           }
           return status;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var persons = await _context.Persons.ToListAsync();
            return persons;
        }

        public async Task<Person> GetById(int id)
        {
            return await _context.Persons.FindAsync(id);
                  
        }

        public async Task Update(Person model)
        {
            var peron = await _context.Persons.FindAsync(model.Person_Id);
            if(peron != null)
            {
                peron.Name = model.Name;
                peron.Email = model.Email;
                peron.MobileNo = model.MobileNo;
                peron.Address = model.Address;
                peron.City_Id = model.City_Id;             
                peron.State_Id = model.State_Id;
                _context.Update(peron);
                await Save();
            }

        }
    }
}
