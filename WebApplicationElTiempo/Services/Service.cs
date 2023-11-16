using Newtonsoft.Json;
using System.Text;
using System.Transactions;
using WebApplicationElTiempo.Models;

namespace WebApplicationElTiempo.Services
{
    public class Service : IService
    {
        private static string _baseUrl;

        public Service()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<bool> AddUsuario(Usuario obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/v1/Usuario/CrearUsuario", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
        public async Task<List<Usuario>> ListUsuario(int? usrId)
        {
            List<Usuario> lista = new List<Usuario>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("api/v1/Usuario/ListarUsuarios");

            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Usuario>>(json_respuesta);
                lista = resultado;
            }

            return lista;
        }
        public async Task<Usuario> GetUsuario(int usrId)
        {
            var lista = new Usuario();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("api/v1/Usuario/ListarUsuarios?Id=" + usrId);
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Usuario>>(json_respuesta);
                lista = new Usuario()
                {
                    Nombre = resultado.FirstOrDefault().Nombre,
                    Contrasena = resultado.FirstOrDefault().Contrasena,
                    CorreoElectronico = resultado.FirstOrDefault().CorreoElectronico

                };
            }
            return lista;
        }
        public async Task<bool> DelUsuario(int usrId)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            Usuario obj = new Usuario();
            obj.Id = usrId;
            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/v1/Usuario/EliminarUsuario", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
        public async Task<bool> UpUsuario(Usuario obj)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/v1/Usuario/ActualizarUsuario", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
    }
}
