using System;
using System.Collections.Generic;
using Examen_Ing_Web_Lowell.Models;


namespace Examen_Ing_Web_Lowell {


public class ContactosRepositorio {

    public ContactosRepositorio()
    {
        
    }

    public static void IniciarBD(){
       using (var connection = new SqliteConnection(@"Data Source=mydb.db;"))
//       ("" +    new SqliteConnectionStringBuilder()  {        DataSource = "data.db"  }))
        {
            connection.Open();
            connection.Execute(
                @"CREATE TABLE IF NOT EXISTS Contactos (
                        id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        nombre TEXT NULL,
                        correo TEXT NULL,
                        edad INT NULL
                ) ;");
        }
    }

    public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public int edad { get; set; }




        internal List<Contacto> LeerTodos()
        {
            throw new NotImplementedException();
        }

        internal Contacto LeerPorId(int id)
        {
            throw new NotImplementedException();
        }

        internal void Crear(Contacto model)
        {
            throw new NotImplementedException();
        }

        internal void Actualizar(Contacto model)
        {
            throw new NotImplementedException();
        }

        internal void Borrar(int id)
        {
            throw new NotImplementedException();
        }
    }


}
