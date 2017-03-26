using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Domain;

namespace Session
{
    public class Broker
    {
        OleDbConnection connection;
        OleDbCommand command;

        private void ConnectTo()
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\.NET Programming\VB_Prog\InsertUpdateDeleteModify\IVDU\IVDU_demo\Database.accdb");
            command = connection.CreateCommand();
        }  // DB CONNECTION STRING

        public Broker()
        {
            ConnectTo();
        }

        public void Insert(Person p)   // INSERT PROGRAM TO THE DB
        {
            try
            {
                command.CommandText = "INSERT INTO TPersons (FirstName, LastName) VALUES('" + p.FirstName + "', '" + p.LastName + "')";
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(connection != null)
                {
                    connection.Close();
                }
            }
          
        }

        public List<Person> FillComboBox()  // VIEW PROGRAM TO THE DB
        {
            List<Person> personList = new List<Person>();
            try
            {
                command.CommandText = "SELECT * FROM TPersons";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Person p = new Person();

                    p.Id = Convert.ToInt32(reader["ID"].ToString());
                    p.FirstName = reader["FirstName"].ToString();
                    p.LastName = reader["LastName"].ToString();

                    personList.Add(p);
                }
                return personList;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void Update(Person oldPerson, Person newPerson)  // UPDATE PROGRAM TO THE DB
        {
            
            try
            {
                command.CommandText = "UPDATE TPersons SET FirstName= '" + newPerson.FirstName + "',LastName= '" + newPerson.LastName + "' WHERE ID= " + oldPerson.Id;
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }


        public void Delete(Person p)  // DELETE PROGRAM TO THE DB
        {
            try
            {
                command.CommandText = "DELETE FROM TPersons WHERE ID="+p.Id;
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }


    }

}
