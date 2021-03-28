using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace mvcApp.Models
{
    public class BdPerson
    {
        public static string conectionstring = "Data source =MUHAMMAD\\SQLEXPRESS; Initial Catalog = Test;Trusted_Connection = True;";
        public List<Person> GetPersons()
        {
            using(SqlConnection conn = new SqlConnection(conectionstring))
            {
                conn.Open();
                var persons = conn.Query<Person>("Select * from Person").ToList();
                conn.Close();
                return persons;
            }
        }
        public List<Person> GetPersonByFIO(Person p)
        {
            using(SqlConnection conn = new SqlConnection(conectionstring))
            {
                conn.Open();
                var persons = conn.Query<Person>($"Select * from Person where FirstName = '{p.FirstName}' AND LastName = '{p.LastName}' AND MiddleName = '{p.MiddleName}'").ToList();
                conn.Close();
                return persons;
            }           
        }
        public void InsertPerson(Person p)
        {
            using(SqlConnection conn = new SqlConnection(conectionstring)){
                
                conn.Open();
                conn.Execute($"INSERT into Person(FirstName, LastName, MiddleName) VALUES('{p.FirstName}', '{p.LastName}', '{p.MiddleName}')");
                conn.Close();
            }
        }
    }
}