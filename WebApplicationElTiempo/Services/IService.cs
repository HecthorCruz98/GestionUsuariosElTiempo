using System.Transactions;
using WebApplicationElTiempo.Models;

namespace WebApplicationElTiempo.Services
{
    public interface IService
    {
        Task<List<Usuario>> ListUsuario(int? usrId);
        Task<bool> AddUsuario(Usuario obj);
        Task<bool> UpUsuario(Usuario obj);
        Task<bool> DelUsuario(int usrId);
        Task<Usuario> GetUsuario(int usrId);


    }
}
