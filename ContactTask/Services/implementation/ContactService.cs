using AutoMapper;
using ContactTask.Models;
using ContactTask.Services.Contract;
using ContactTask.ViewModels;
using ContactTask.ViewModels.Login;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Linq;
using System.Net;

namespace ContactTask.Services.implementation
{
    public class ContactService : IContactService
    {



        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ContactService(AppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }



        public async Task<int> Login( LoginViewModel LoginViewModel)
        {
           
            if ((LoginViewModel.username == "user1" && LoginViewModel.password == "user1") || (LoginViewModel.username == "user2" && LoginViewModel.password == "user2"))
            {
                return 1;
            }
            else
            {
               return -1;
            }

        }


        public async Task<List<ContactViewModel>> Readall(int page = 1, int pageSize = 5)
        {

            if (page == 0) page = 1;

          
            var Contacts = await _context.Contacts
               .OrderBy(e => e.Id)
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            var employeeDTOs = _mapper.Map<List<ContactViewModel>>(Contacts);
            

            return employeeDTOs;
        }


        public async Task<int> allcount()
        {

            var AllContacts =await _context.Contacts.AsNoTracking().AsQueryable().CountAsync();


            return AllContacts;
        }

        public async Task<ContactViewModel> Readbyid(int id)
        {
            var Contacts = _context.Contacts.Find(id);

            if (Contacts == null)
            {
                return new ContactViewModel();
            }

            var Contact = _mapper.Map<ContactViewModel>(Contacts);

            return Contact;


        }




        public async Task<int> create(AddContactViewModel AddContact)
        {

            try
            {
                var Contact = _mapper.Map<Contact>(AddContact);

                await _context.Contacts.AddAsync(Contact);
                var res = await _context.SaveChangesAsync();

                return res;
            }
            catch (Exception)
            {

                return -1;
            }

        }


        public async Task<bool> Update(EditContactViewModel EditContact)
        {


            try
            {
                var existingContact = _context.Contacts.FirstOrDefault(x=>x.Id==EditContact.Id);

                if (existingContact == null)
                {
                    return false;
                }


                //existingContact = _mapper.Map<Contact>(EditContact);
                existingContact.Name = EditContact.Name;
                existingContact.Adress  = EditContact.Adress;
                existingContact.Phone = EditContact.Phone;
                existingContact.Notes = EditContact.Notes;

                existingContact.IsLocked = true;
                _context.Update(existingContact); ;

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                return false;
            }

         
        }





        public async Task<bool> delete(int id)
        {
            var Contact = _context.Contacts.Find(id);

            if (Contact == null)
            {
                return false;
            }



            Contact.IsDeleted = true;


            await _context.SaveChangesAsync();


            return  Contact.IsDeleted;
        }















    }
}
