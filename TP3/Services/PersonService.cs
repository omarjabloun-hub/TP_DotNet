using System;
using System.Data.SQLite;
using TP3.Models;

namespace TP3.Services
{
    public class PersonService
    {

        public List<Person> GetAllPerson()
        {
            var allPersons = new List<Person>();

            SQLiteConnection sqlite_conn = new SQLiteConnection("DataSource=database.db"); ;
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd;
            string query = "SELECT * FROM personal_info";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = query;
            sqlite_cmd.ExecuteNonQuery();
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                Person person = new Person();
                person.Id = sqlite_datareader.GetInt16(0);
                person.FirstName = sqlite_datareader.GetString(1);
                person.LastName = sqlite_datareader.GetString(2);
                person.Email = sqlite_datareader.GetString(3);
                person.DateBirth = sqlite_datareader.GetString(4);
                person.Country = sqlite_datareader.GetString(6);


                allPersons.Add(person);

            }

            sqlite_conn.Close();


            return allPersons;
        }
        public Person GetPersonById(int idDto)
        {


            SQLiteConnection sqlite_conn = new SQLiteConnection("DataSource=database.db"); ;
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd;
            string query = "SELECT *  FROM personal_info WHERE id=@param1 ";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = query;
            sqlite_cmd.Parameters.AddWithValue("param1", idDto);
            sqlite_cmd.ExecuteNonQuery();
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            var person = new Person();
            sqlite_datareader.Read();
            // verify if it's empty
            if (!sqlite_datareader.HasRows)
            {
                return null;
            }

            
            person.Id = sqlite_datareader.GetInt16(0);
            person.FirstName = sqlite_datareader.GetString(1);
            person.LastName = sqlite_datareader.GetString(2);
            person.Email = sqlite_datareader.GetString(3);
            person.DateBirth = sqlite_datareader.GetString(4);
            person.Country = sqlite_datareader.GetString(6);



            sqlite_conn.Close();


            return person;
        }

        public Person Search( string country, string firstname = "Conroy")
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection("DataSource=database.db"); ;
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd;
            string query = "SELECT *  FROM personal_info WHERE first_name=@param1 AND country=@param2 ";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = query;
            sqlite_cmd.Parameters.AddWithValue("param1", firstname);
            sqlite_cmd.Parameters.AddWithValue("param2", country);
            sqlite_cmd.ExecuteNonQuery();
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            var person = new Person();
            sqlite_datareader.Read();
            // verify if it's empty
            if (!sqlite_datareader.HasRows)
            {
                return null;
            }


            person.Id = sqlite_datareader.GetInt16(0);
            person.FirstName = sqlite_datareader.GetString(1);
            person.LastName = sqlite_datareader.GetString(2);
            person.Email = sqlite_datareader.GetString(3);
            person.DateBirth = sqlite_datareader.GetString(4);
            person.Country = sqlite_datareader.GetString(6);



            sqlite_conn.Close();


            return person;
        }

    }
}
