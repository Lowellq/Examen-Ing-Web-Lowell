using System;
using System.Collections.Generic;
using Examen_Ing_Web_Lowell.Models;

using Microsoft.Data.Sqlite;
using System.Linq;
using Dapper;



namespace Examen_Ing_Web_Lowell {


public class ContactosRepositorio {

    public ContactosRepositorio()
    {
        
    }


    private const string ConeccionSQL = @"Data Source=mydb.db;";
    public static void IniciarBD(){
       using (var connection = new SqliteConnection(ConeccionSQL))
//       ("" +    new SqliteConnectionStringBuilder()  {        DataSource = "data.db"  }))
        {
            connection.Open();
            connection.Execute(
                @"CREATE TABLE IF NOT EXISTS Contactos (
                        Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        Nombre TEXT NULL,
                        Correo TEXT NULL,
                        Edad INT NULL
                ) ;");
        }
    }

        internal List<Contacto> LeerTodos()
        {
             using(var con = new SqliteConnection(ConeccionSQL)){

                return con.Query<Contacto>("SELECT Id, Nombre, Correo, Edad FROM Contactos").ToList();
            }

        }

        internal Contacto LeerPorId(int id)
        {
            using(var con = new SqliteConnection(ConeccionSQL)){
                return con.Query<Contacto>("SELECT Id, Nombre, Correo, Edad FROM Contactos WHERE Id = @Id " , new { Id = id }).FirstOrDefault();

            }

        }

        internal void Crear(Contacto model)
        {
              using(var con = new SqliteConnection(ConeccionSQL)){
                con.Execute("INSERT INTO Contactos ( Nombre, Correo, Edad) VALUES ( @Nombre, @Correo, @Edad ) " , model);
              }

        }

        internal void Actualizar(Contacto model)
        {
              using(var con = new SqliteConnection(ConeccionSQL)){
                 con.Execute("UPDATE Contactos SET  Nombre = @Nombre , Correo = @Correo, Edad = @Edad WHERE Id = @Id ", model);
            }

        }

        internal void Borrar(int id)
        {
             using(var con = new SqliteConnection(ConeccionSQL)){
                con.Execute("DELETE FROM Contactos WHERE Id = @Id "
                    , new { Id = id });
             }        

        }
    }


}
