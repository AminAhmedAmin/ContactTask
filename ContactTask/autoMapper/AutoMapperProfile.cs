using AutoMapper;
using ContactTask.Models;
using ContactTask.ViewModels;
using System.Net;

namespace ContactTask.autoMapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {

            CreateMap<Contact, ContactViewModel>();


            CreateMap<AddContactViewModel,Contact >();



            CreateMap<Contact, EditContactViewModel>();

            CreateMap<EditContactViewModel, Contact >();





        }
    }
}
