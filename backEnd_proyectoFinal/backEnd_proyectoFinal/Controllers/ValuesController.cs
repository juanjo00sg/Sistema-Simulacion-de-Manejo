using Microsoft.AspNetCore.Cors;//libreria cor
using Microsoft.AspNetCore.Mvc;
using backEnd_proyectoFinal.Models;
using System.Collections.Generic;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backEnd_proyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]//libreria cors
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public string Get()
        {
            User u = new User(0);
            string m = u.listar();
            return m;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {

            Usuario u = new Usuario();
            string m = u.listar(id);
            return m;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public bool Post([FromBody] JsonElement value)
        {
            string ced = value.GetProperty("ced").ToString();
            string nombre = value.GetProperty("nom").ToString();  
            string email = value.GetProperty("email").ToString();
            string password = value.GetProperty("pass").ToString();            
            int tiempo = value.GetProperty("tiempo").GetInt32();
            int edad = value.GetProperty("edad").GetInt32();

            if (ced == null && nombre == null && tiempo  == null)
            {
                User u = new User(email, password); //login()
                string m = u.login();
            } else if (email == null && password == null )
            {
                User u = new User(ced, nombre, tiempo); //ingresar()
                string m = u.ingresarTiempo();
            } else if (tiempo == null )
            {
                User u = new User(ced, nombre, password, edad, email); //registrar()
                string m = u.registrar();
            }
            
            return m;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public string Put(string id, [FromBody] JsonElement value)
        {
            string ced = value.GetProperty("ced").ToString();
            string nombre = value.GetProperty("nom").ToString();              
            int edad = value.GetProperty("edad").GetInt32();
            User u = new User(ced, nombre, edad);
            string m = u.modificar();
            return m;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            Usuario u = new Usuario(id);
            string m = u.eliminar();
            return m;
        }

    }
}
