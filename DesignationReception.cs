using System;
using MySql.Data.MySqlClient;

namespace espaceNetSAV
{
    class DesignationReception
    {
        private Database databaseObject;
        public int? id;
        public string designation;
        public string probleme;

        public DesignationReception()
        { 
            this.databaseObject = new Database();
            this.id = getLastID() + 1; 
        }

        public DesignationReception(string designation, string probleme)
        {
            this.databaseObject = new Database();
            this.id = getLastID() + 1;
            this.designation = designation;
            this.probleme = probleme;
        }

        public void persistObjectToDatabase()
        {
            string query = "INSERT INTO `receptiondesignation`(`designation`, `probleme`) VALUES (@designation, @probleme)";
            try
            {
                using (MySqlCommand myCommand = new MySqlCommand(query, databaseObject.getConnection()))
                {
                    databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@designation", this.designation);
                    myCommand.Parameters.AddWithValue("@probleme", this.probleme);
                    var result = myCommand.ExecuteNonQuery();
                }
            } catch (MySqlException)
            {
                throw;
            }
            finally
            {
                databaseObject.closeConnection();
            }
        }

        public int getLastID()
        {
            string query = "SELECT MAX(id) FROM `receptiondesignation`";
            int lastID = 0;
            try
            {
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection())) 
                {
                    this.databaseObject.openConnection();
                    MySqlDataReader myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        lastID = (int)myReader[0];
                    }
                }
            } catch (MySqlException)
            {
                throw;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
            return lastID;
        }

        public DesignationReception getLastItemFromDatabase()
        {
            DesignationReception desReception = new DesignationReception();
            string query = "SELECT * FROM receptiondesignation WHERE id = @id";
            try
            {
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
            return desReception;
        }
    }
}
