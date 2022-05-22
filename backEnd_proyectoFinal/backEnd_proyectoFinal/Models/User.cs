using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace backEnd_proyectoFinal.Models
{
    public class User
    {
        string ced      { get; set; }
        string nombre   { get; set; }
        string password { get; set; }
        string email    { get; set; }
        int edad        { get; set; }
        int tiempo      { get; set; }             
            
        NpgsqlConnection bd; //Variable para la coneccion a la bd
        public User(string ced,string nombre, string password, int edad, string email)
        {
            this.ced = ced;
            this.nombre = nombre;
            this.password = password;
            this.edad = edad;
            this.email = email;
            conectar();
        }

        public User( string password,  string email)
        {
            
            this.password = password;            
            this.email = email;
            conectar();
        }

        public User(string ced)
        {
            this.ced = ced;                        
            conectar();
        }
        
        public User(string ced,string nombre,int tiempo )
        {
            this.ced = ced;
            this.nombre = nombre;
            this.tiempo = tiempo;
            conectar();
        }        

        public void conectar()
        {
            bd = new NpgsqlConnection("server=localhost; User Id=postgres; Password=hola1234 ; Database=trabajo_final");
            this.bd.Open();
        }        

        public string registrar()
        {
            try
            {
                string sql = "insert into simulacion (cedula, nombre, email, password, edad) values ('" + this.ced + "','" + 
                                this.nombre + "'," + this.email + "'," + this.password + "'," + this.edad + ");";
                new NpgsqlCommand(sql, this.bd).ExecuteNonQuery();
                return "Datos registrados...";
            }
            catch (Exception E)
            {
                return "Error: " + E;
            }
        }

        public string login()
        {
            try
            {
                string sql = "select email, password from simulacion where email = '" + this.email +
                             "', password = '" + this.password + "';";
                new NpgsqlCommand(sql, this.bd).ExecuteNonQuery();
                return "Logeado Correctamente";
            }
            catch (Exception E)
            {
                return "Error: " + E;
            }
        }

        public string ingresarTiempo()
        {
            try
            {
                string sql = "update simulacion set nombre ='"  + this.nombre + "', tiempo_simulacion = '"  +
                            this.tiempo + "' where cedula ='"  + this.ced + "';";
                new NpgsqlCommand(sql, this.bd).ExecuteNonQuery();
                return "Tiempo ingresado...";
            }
            catch (Exception E)
            {
                return "Error: " + E;
            }
        }

        public string listar()
        {
            try
            {
              
                string sql = "select * from simulacion order by tiempo_simulacion DESC";
                

                var reader = new NpgsqlCommand(sql, this.bd).ExecuteReader();
                var estudiantes = new List<dynamic>();
                while (reader.Read())
                {
                    dynamic estudiante = new ExpandoObject();
                    estudiante.cedula = reader.GetString(0);
                    estudiante.nombre = reader.GetString(1);
                    estudiante.tiempo_simulacion = reader.GetInt32(2);
                    estudiantes.Add(estudiante);
                }
                string json = JsonConvert.SerializeObject(estudiantes);
                reader.Close();
                return json;

            }
            catch (Exception E)
            {
                return "mensaje" + E;
            }
        }

        public string listar(string param)
        {            
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();                                
                string sql = "select * from simulacion where cedula = '" + param + "'";
                var reader = new NpgsqlCommand(sql, this.bd).ExecuteReader();
                var estudiantes = new List<dynamic>();
                while (reader.Read())
                {
                    dynamic estudiante = new ExpandoObject();

                    estudiante.cedula = reader.GetString(0);
                    estudiante.nombre = reader.GetString(1);
                    estudiante.edad = reader.GetInt32(2);

                    estudiantes.Add(estudiante);
                }
                string json = JsonConvert.SerializeObject(estudiantes);
                reader.Close();
                return json;
                
            }
            catch (Exception E)
            {
                return "Error: " + E;
            }
        }

        public string eliminar()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                string sql = "delete from simulacion where cedula='" + this.ced + "'";
                new NpgsqlCommand(sql, this.bd).ExecuteNonQuery();
                return "Registro eliminado...";
            }
            catch (Exception E)
            {
                return "Error: " + E;
            }
        }

        public string modificar() 
        {
            try
            {
                string sql = "update  simulacion set nombre = '" + this.nombre + "', edad = '" + this.edad +
                            "' where cedula = '" + this.ced + "';";
                new NpgsqlCommand(sql, this.bd).ExecuteNonQuery();
                return "Datos Modificados...";
            }
            catch (Exception E)
            {
                return "Error: " + E;
            }
        }
         


    }
}
