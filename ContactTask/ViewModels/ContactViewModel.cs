using System.ComponentModel.DataAnnotations;

namespace ContactTask.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        
        public string Phone { get; set; }


       
        public string Adress { get; set; }


      
        public string Notes { get; set; }


        public bool IsLocked { get; set; }


        public bool allcontactcount { get; set; }

    }
}
