using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace espaceNetSAV.Admin
{
    class History
    {

        private Database databaseObject { get; set; }
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public User User { get; set; }

        public History() 
        {
            this.databaseObject = new Database();
            this.Date = DateTime.Now;
            this.OldValue = "";
            this.NewValue = "";
            this.User = new User();
        }

        public History(string oldValue, string newValue, User user)
        {
            this.databaseObject = new Database();
            this.Date = DateTime.Now;
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.User = user;
        }

        public History(User currentUser)
        {
            this.databaseObject = new Database();
            this.Date = DateTime.Now;
            this.OldValue = "";
            this.NewValue = "";
            this.User = currentUser;
        }


        public bool Save()
        {
            string query = "INSERT INTO `historique`(`date`, `oldvalue`, `newvalue`, `user_id`) VALUES (@date, @oldvalue, @newvalue, @user_id)";//TODO: Fix the query 

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@date", this.Date);
                myCommand.Parameters.AddWithValue("@oldvalue", this.OldValue);
                myCommand.Parameters.AddWithValue("@newvalue", this.NewValue);
                myCommand.Parameters.AddWithValue("@user_id", this.User.ID);

                return (myCommand.ExecuteNonQuery() == 1) ? true : false ;
            }
        }

        /// <summary>
        /// Get the current user history from the database
        /// </summary>
        /// <returns></returns>
        public List<History> GetUserHistory()
        {
            List<History> myList = new List<History>();

            string query = "SELECT * FROM historique WHERE user_id = @user_id";

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@user_id", this.User.ID);

                using (MySqlDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            History history = new History();
                            history.ID = Convert.ToInt32(myReader[0]);
                            history.Date = Convert.ToDateTime(myReader[1]);
                            history.OldValue = myReader[2].ToString();
                            history.NewValue = myReader[3].ToString();
                            history.User.GetUser(Convert.ToInt32(myReader[4]));

                            myList.Add(history);
                        }
                    }


                }

            }
            return myList;
        }

        public List<History> GetUserHistoryLast30Days()
        {
            List<History> myList = new List<History>();

            string query = "SELECT * FROM historique WHERE user_id = @user_id AND date BETWEEN now() and date_add(now(), INTERVAL 1 month)";

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@user_id", this.User.ID);

                using (MySqlDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            History history = new History();
                            history.ID = Convert.ToInt32(myReader[0]);
                            history.Date = Convert.ToDateTime(myReader[1]);
                            history.OldValue = myReader[2].ToString();
                            history.NewValue = myReader[3].ToString();
                            history.User.GetUser(Convert.ToInt32(myReader[4]));

                            myList.Add(history);
                        }
                    }


                }

            }
            return myList;
        }

        /// <summary>
        /// This will emtpy the entire history table 
        /// </summary>
        /// <returns></returns>
        public bool EmptyHistory()
        {
            string query = "TRUNCATE TABLE historique";

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                return (myCommand.ExecuteNonQuery() == 0)? true : false;
            }
        }

        public List<History> GetCompleteHistoryWithUsers()
        {
            List<History> myList = new List<History>();

            string query = "SELECT * FROM historique";
            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();

                using (MySqlDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            History history = new History();

                            history.ID = Convert.ToInt32(myReader[0]);
                            history.Date = Convert.ToDateTime(myReader[1]);
                            history.OldValue = myReader[2].ToString();
                            history.NewValue = myReader[3].ToString();
                            history.User.GetUser(Convert.ToInt32(myReader[4]));

                            myList.Add(history);
                        }
                    }
                }
            }

            return myList;
        }
    }
}
