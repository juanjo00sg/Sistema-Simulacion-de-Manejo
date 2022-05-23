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
            User u = new User("");
            string m = u.listar();
            return m;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {

            User u = new User("");
            string m = u.listar(id);
            return m;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post([FromBody] JsonElement value)
        {
            string option = value.GetProperty("option").ToString();                      
            string m = "";

            if (option.Equals("login"))
            {
                string email = value.GetProperty("email").ToString();
                string password = value.GetProperty("pass").ToString();

                User u = new User(email, password); //login()
                m = u.login();
            } else if (option.Equals("ingresar"))
            {
                string ced = value.GetProperty("ced").ToString();
                string nombre = value.GetProperty("nom").ToString();
                int tiempo = value.GetProperty("tiempo").GetInt32();

                User u = new User(ced, nombre, tiempo); //ingresar()
                m = u.ingresarTiempo();
            } else if (option.Equals("registrar"))
            {
                string ced = value.GetProperty("ced").ToString();
                string nombre = value.GetProperty("nom").ToString();
                string email = value.GetProperty("email").ToString();
                string password = value.GetProperty("pass").ToString();
                int edad = value.GetProperty("edad").GetInt32();

                User u = new User(ced, nombre, password, edad, email); //registrar()
                m = u.registrar();
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
            User u = new User(id);
            string m = u.eliminar();
            return m;
        }

    }
}
