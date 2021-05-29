using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DemoGraphQL.Models;
using Microsoft.Data.Sqlite;

namespace DemoGraphQL.AccesoDatos
{
    public class LugaresOperaciones
    {
       
        private string _connectionString = "Data Source=Product.sqlite";

        public LugaresOperaciones() {
            using var connection = new SqliteConnection(_connectionString);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Lugares';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "Lugares")
                return;

            connection.Execute("Create Table Lugares (" +
                "id INTEGER NOT NULL," +
                "nombre VARCHAR(100) NOT NULL," +
                "descripcion VARCHAR(100) NOT NULL," +
                "direccion VARCHAR(100) NOT NULL," +
                "telefono VARCHAR(100) NOT NULL," +
                "website VARCHAR(200) NOT NULL);");
        }
    

        public async Task insertLugar(Lugares lugar)
        {
            using var connection = new SqliteConnection(_connectionString);

            await connection.ExecuteAsync("INSERT INTO Lugares (id, nombre, descripcion, direccion, telefono, website)" +
                "VALUES (@id, @nombre, @descripcion, @direccion, @telefono, @website);", lugar);
        }

        public IEnumerable<Lugares> getLugares()
        {
            using var connection = new SqliteConnection(_connectionString);

            return  connection.Query<Lugares>("SELECT id, nombre, descripcion, direccion, telefono, website FROM Lugares;").ToList();
        }
    }
}
