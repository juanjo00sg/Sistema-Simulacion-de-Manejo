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
            User u = new User("", "", 0);
            string m = u.listar();
            return m;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post([FromBody] JsonElement value)
        {
            string ced = value.GetProperty("ced").ToString();
            string nombre = value.GetProperty("nom").ToString();
            int tiempo = value.GetProperty("tiempo").GetInt32();
            User u = new User(ced, nombre, tiempo);
            string m = u.ingresar();
            return m;
        }

    }
}
