using System;
using MySql.Data.MySqlClient;

namespace espaceNetSAV
{
    public class DesignationReception
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
            if (this.tableHasRow())
                this.id = getLastID() + 1;
            else
                this.id = 1;
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
                this.databaseObject.closeConnection();
            }
        }

        public int getLastID()
        {
            //Checking if theres a row in the table
            
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
                    myReader.Close();
                }
                if(this.tableHasRow())
                    return lastID;
                return 0;
            } 
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
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

        public DesignationReception getDesignationByID(int ID)
        {

            try
            {
                string query = "SELECT * FROM receptiondesignation WHERE id = @id ";
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    myCommand.Parameters.AddWithValue("@id", ID);
                    this.databaseObject.openConnection();
                    var myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        this.id = (int)myReader[0];
                        this.designation = myReader[1].ToString();
                        this.probleme = myReader[2].ToString();
                    }
                }

                return this;
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        /// <summary>
        /// Checks whether the table has any rows or empty
        /// </summary>
        /// <returns></returns>
        private bool tableHasRow()
        {
            try
            {
                string query = "SELECT * FROM `receptiondesignation`";
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    var myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }
    }
}
