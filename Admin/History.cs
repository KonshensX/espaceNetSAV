using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace espaceNetSAV.Admin
{
    class History
    {

        private Database databaseObject { get; set; }
        public int ID { get; set; }
        public DateTime Date { get; set; }

        public int BonNumero { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public User User { get; set; }


        public History(int bonNumero, string oldValue, string newValue, User user)
        {
            this.databaseObject = new Database();
            this.ID = 1;
            this.Date = DateTime.Now;
            this.BonNumero = bonNumero;
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.User = user;
        }

        public History()
        {
            this.databaseObject = new Database();
            this.Date = DateTime.Now;
            this.BonNumero = 0; 
            this.OldValue = "";
            this.NewValue = "";
            this.User = new User();
        }

        public History(User currentUser)
        {
            this.databaseObject = new Database();
            this.Date = DateTime.Now;
            this.OldValue = "";
            this.NewValue = "";
            this.User = currentUser;
        }

        /// <summary>
        /// Save the history object to the database
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                string query = "INSERT INTO `historique`(`date`, `bon_num`, `oldvalue`, `newvalue`, `user_id`) VALUES (@date, @bonnum, @oldvalue, @newvalue, @user_id)";//TODO: Fix the query 

                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@date", this.Date);
                    myCommand.Parameters.AddWithValue("@bonnum", this.BonNumero);
                    myCommand.Parameters.AddWithValue("@oldvalue", this.OldValue);
                    myCommand.Parameters.AddWithValue("@newvalue", this.NewValue);
                    myCommand.Parameters.AddWithValue("@user_id", this.User.ID);

                    return (myCommand.ExecuteNonQuery() == 1) ? true : false;
                }
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        /// <summary>
        /// Get the current user history from the database
        /// </summary>
        /// <returns></returns>
        public List<History> GetUserHistory()
        {
            try
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
                                History history = new History(Program._USER);
                                history.ID = Convert.ToInt32(myReader[0]);
                                history.Date = Convert.ToDateTime(myReader[1]);
                                history.BonNumero = Convert.ToInt32(myReader[2]);
                                history.OldValue = myReader[3].ToString();
                                history.NewValue = myReader[4].ToString();
                                history.User.GetUser(Convert.ToInt32(myReader[5]));

                                myList.Add(history);
                            }
                        }
                    }

                }
                return myList;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        public List<History> GetUserHistoryLast30Days()
        {
            try
            {
                List<History> myList = new List<History>();

                string query = "SELECT * FROM historique, users WHERE historique.user_id = users.id AND user_id = @user_id AND (date(date)) > (date(now()) - interval 30 day)";

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
                                History history = new History(Program._USER);
                                history.ID = Convert.ToInt32(myReader[0]);
                                history.Date = Convert.ToDateTime(myReader[1]);
                                history.BonNumero = Convert.ToInt32(myReader[2]);
                                history.OldValue = myReader[3].ToString();
                                history.NewValue = myReader[4].ToString();
                                history.User.Name = myReader["username"].ToString();

                                myList.Add(history);
                            }
                        }
                    }
                }
                return myList.OrderByDescending(o => o.Date).ToList(); ;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        /// <summary>
        /// This will emtpy the entire history table 
        /// </summary>
        /// <returns></returns>
        public bool EmptyHistory()
        {
            try
            {
                string query = "TRUNCATE TABLE historique";

                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    return (myCommand.ExecuteNonQuery() == 0) ? true : false;
                }
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        //Gets the complete history list with the users 
        public List<History> GetCompleteHistoryWithUsers()
        {
            try
            {
                List<History> myList = new List<History>();

                string query = "SELECT * FROM historique, users WHERE historique.user_id = users.id";
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
                                history.BonNumero = Convert.ToInt32(myReader[2]);
                                history.OldValue = myReader[3].ToString();
                                history.NewValue = myReader[4].ToString();
                                history.User.Name = myReader["username"].ToString();

                                myList.Add(history);
                            }
                        }
                    }
                }

                return myList.OrderByDescending(o => o.Date).ToList(); 
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }


    }
}
