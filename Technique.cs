using System;
using MySql.Data.MySqlClient;

namespace espaceNetSAV
{
    public enum Status
    {
        Fixed, 
        BeingRepeared
    }
    public class Technique
    {
        private Database databaseObject;
        public int id;
        //public BonReception bonObject;
        public int bon_id; //TEMP SOLUTION
        public string diagnostics;
        public string tasks;
        public Status status = Status.BeingRepeared;

        public Technique() 
        {
            this.databaseObject = new Database();
            if (this.tableHasRow())
                this.id = this.getLastID() + 1;
            else
                this.id = 1;
        }

        public Technique(string diag, string task, Status myStatus, BonReception bon)
        {
            this.databaseObject = new Database();
            if (this.tableHasRow())
                this.id = this.getLastID() + 1;
            else
                this.id = 1;
            //this.bonObject = bon;
            this.diagnostics = diag;
            this.tasks = task;
            this.status = myStatus;
        }

        /// <summary>
        /// Gets the item that coresponds to the given ID
        /// This is such a shit comment
        /// </summary>
        /// <param name="id">Bon id to look for tech infos about</param>
        /// <returns></returns>
        public Technique getItem(int id) 
        {
            try
            {
                string query = "SELECT * FROM techniques WHERE id = @id";
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    BonReception bonObject = new BonReception();
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@id", id);
                    var myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        this.id = (int)myReader[0];
                        this.diagnostics = myReader[1].ToString();
                        this.tasks = myReader[2].ToString();
                        this.bon_id = (int)myReader[3];
                        this.status = getStatus(Convert.ToInt32(myReader["fixed"]));
                    }
                    myReader.Close();
                }
                return this;
            }
            finally
            {
                //this.
                this.databaseObject.closeConnection();
            }
        }
        /// <summary>
        /// This functions returns either 0 or 1 based on the items Status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public int getStatus(Status status)
        {
            switch (status)
            {
                case Status.Fixed:
                    return 1;
                case Status.BeingRepeared:
                    return 0;
                default:
                    return 0;
            }
        }
        /// <summary>
        /// This functions returns either Fixed or BeingRepearede based on theitems status in the DB
        /// </summary>
        /// <param name="status">Status int from the database</param>
        /// <returns></returns>
        public Status getStatus(int DBstatus)
        {
            switch (DBstatus)
            {
                case 1:
                    return Status.Fixed;
                case 0:
                    return Status.BeingRepeared;
                default:
                    return Status.BeingRepeared;
            }
            
            
        }

        /// <summary>
        /// persist the current object to the database
        /// </summary>
        public void persistObjectToDatabase(int bon_id)
        {
            try
            {
                string query = "INSERT INTO `techniques`(`diagno`, `tasks`, `bon_id`, `fixed`) VALUES (@diagno, @tasks, @bon_id, @fixed)";
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@diagno", this.diagnostics);
                    myCommand.Parameters.AddWithValue("@tasks", this.tasks);
                    myCommand.Parameters.AddWithValue("@bon_id", bon_id);
                    myCommand.Parameters.AddWithValue("@fixed", this.getStatus(status));

                    myCommand.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally { this.databaseObject.closeConnection(); }
        }

        /// <summary>
        /// Gets the last ID from the database
        /// </summary>
        /// <returns></returns>
        private int getLastID()
        {
            try
            {
                string query = "SELECT MAX(id) FROM techniques";
                var lastID = 0;
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    lastID = Convert.ToInt32(myCommand.ExecuteScalar());
                }
                return lastID;
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
        /// This will update o arow in the database
        /// </summary>
        public int UpdateObject(string diagno, string tasks, int bon_id)
        {
            try
            {
                //Temporarely passing the values here 
                //Maybe i should re design the whole project and be done with this mess 
                //TODO UPDATE THE QUERY
                string query = "UPDATE `techniques` SET `diagno`= @diagno,`tasks`= @tasks WHERE bon_id = @bon_id ";

                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@bon_id", bon_id);
                    myCommand.Parameters.AddWithValue("@diagno", diagno);
                    myCommand.Parameters.AddWithValue("@tasks", tasks);

                    return myCommand.ExecuteNonQuery();
                }
            } catch (Exception)
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
                string query = "SELECT * FROM `techniques`";
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

        public void updateItemStatus(Status myStatus)
        {
            try
            {
                //ID is this.id 
                string query = "UPDATE techniques SET fixed = @status WHERE id = @tech_id";
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection
                    ()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@status", this.getStatus(myStatus));
                    myCommand.Parameters.AddWithValue("@tech_id", this.id);
                    myCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                this.databaseObject.closeConnection();
            }


        }
    }
}
