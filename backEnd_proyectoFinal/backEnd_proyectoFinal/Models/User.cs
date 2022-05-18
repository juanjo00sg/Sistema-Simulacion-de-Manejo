using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace backEnd_proyectoFinal.Models
{
    public class User
    {
        string ced { get; set; }
        string nombre { get; set; }
        int tiempo { get; set; }
        
        NpgsqlConnection bd; //Variable para la coneccion a la bd

        public User(string ced,string nombre,int tiempo)
        {
            this.ced = ced;
            this.nombre = nombre;
            this.tiempo = tiempo;
            conectar();
        }

        public void conectar()
        {
            bd = new NpgsqlConnection("server=localhost; User Id=trabajo_final; Password=hola123 ; Database=trabajo_final");
            this.bd.Open();
        }

        public string ingresar()
        {
            try
            {
                string sql = "insert into simulacion values ('" + this.ced + "','" + this.nombre + "'," + this.tiempo + ");";
                new NpgsqlCommand(sql, this.bd).ExecuteNonQuery();
                return "Datos ingresados...";
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
    }
}
