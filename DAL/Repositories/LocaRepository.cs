using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class LocaRepository
    {
        //Champs = Ctor
        private readonly string _connectionString;

        public LocaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        //Mapper
        public static Locataire Mapper(IDataRecord record)
        {
            return new Locataire
            {
                id = (int)record["Id"],
                nom = (string)record["Nom"],
                prenom = (string)record["Prenom"],
                mail = (string)record["Mail"],
                telephone = (string)record["Telephone"],
                description = (string)record["Description"],
            };
        }

        //Methodes

        public IEnumerable<Locataire> GetAll() 
        {
            using (SqlConnection connection =new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM [dbo].[Locataire]";
                    connection.Open();

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            yield return Mapper(reader);
                        }
                    }

                }
                connection.Close();
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------    

        public Locataire Create (Locataire locataireToInsert)
        {
            Locataire newLocataire;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO [dbo].[Locataire] (Nom, Prenom, Mail, Telephone, Description) " +
                                          "OUTPUT inserted.* " +
                                          "VALUES (@nom, @prenom, @mail, @telephone, @description)";

                    command.Parameters.AddWithValue("@nom", locataireToInsert.nom);
                    command.Parameters.AddWithValue("@prenom", locataireToInsert.prenom);
                    command.Parameters.AddWithValue("@mail", locataireToInsert.mail);
                    command.Parameters.AddWithValue("@telephone", locataireToInsert.telephone);
                    command.Parameters.AddWithValue("@description", locataireToInsert.description);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            newLocataire = Mapper(reader);
                        }
                        else
                        {
                            throw new Exception("Probleme");
                        }
                    }
                }
                connection.Close();
            }
            return newLocataire;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        public IEnumerable<Locataire> DeleteLoca(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM [dbo].[Locataire] WHERE Id = @id";

                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    command.ExecuteNonQuery();

                    return GetAll();
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------

        public void AddLoca()
        {
            //finir pour le service de la bll
        }



    }
}
