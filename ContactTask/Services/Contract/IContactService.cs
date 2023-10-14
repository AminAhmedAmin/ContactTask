using ContactTask.ViewModels;
using ContactTask.ViewModels.Login;

namespace ContactTask.Services.Contract
{
    public interface IContactService
    {

        Task<int> Login(LoginViewModel LoginViewModel);
        Task<int> allcount();
        Task<List<ContactViewModel>> Readall(int page = 1, int pageSize = 2);
        Task<int> create(AddContactViewModel ViewModel);

        Task<ContactViewModel> Readbyid(int id);
        Task<bool> Update(EditContactViewModel ViewModel);

        Task<bool> delete(int id);
    }
}
