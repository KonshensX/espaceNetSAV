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
        public BonReception bonObject;
        public string diagnostics;
        public string tasks;
        public Status status;

        public Technique() { this.databaseObject = new Database(); }

        public Technique(string diag, string task, Status myStatus, BonReception bon)
        {
            this.databaseObject = new Database();
            this.bonObject = bon;
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
                        this.bonObject = bonObject.getItem((int)myReader[3]);
                        this.status = getStatus(Convert.ToInt32(myReader["fixed"]));
                    }
                }
                return this;
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

        public void persistObjectToDatabase()
        {
            string query = "INSERT INTO `techniques`(`diagno`, `tasks`, `bon_id`, `fixed`) VALUES (@diagno, @tasks, @bon_id, @fixed)";
            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@diagno", this.diagnostics);
                myCommand.Parameters.AddWithValue("@tasks", this.tasks);
                myCommand.Parameters.AddWithValue("@bon_id", this.bonObject.id);
                myCommand.Parameters.AddWithValue("@fixed", this.getStatus(status));

                myCommand.ExecuteNonQuery();
            }
        }

    }
}
