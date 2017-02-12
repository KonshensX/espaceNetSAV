using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace espaceNetSAV
{
    //Client est 0
    //Raison Sociale est 1
    //NULL est -1
    public enum ClientType {
        Client,
        RaisonSociale,
        Nothing
    }

    public class Client
    {
        private Database databaseObject;
        public int? id;
        public string nom;
        public string tel;
        public string email;
        public string fax;
        public ClientType clientType;

        //Default constructor
        public Client() 
        {
            this.databaseObject = new Database();
            if (this.tableHasRow())
                this.id = getLastID() + 1;
            else
                this.id = 1;
        }
        public Client(string nom ,string tel, string email, string fax, string contact, ClientType typeClient)
        {
            databaseObject = new Database();
            this.id = this.getLastID() + 1; 
            this.nom = nom;
            this.tel = tel;
            this.email = email;
            this.fax = fax;
            this.clientType = typeClient;
        }

        #region Methodes 
        public int getClientType(ClientType clientType)
        {
            switch(clientType)
            {
                case ClientType.Client:
                    return 0;
                case ClientType.RaisonSociale:
                    return 1;
                default:
                    return -1;
            }
        }
        #endregion

        public void persistClientToDatabase()
        {
            string query = "INSERT INTO `client`(`nom`, `tel`, `email`, `fax`, `contact`, `client_type`) VALUES (@nom, @tel, @email, @fax, @contact, @clientType)";
            try
            {
                using (MySqlCommand myCommand = new MySqlCommand(query, databaseObject.getConnection()))
                {

                    databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@nom", this.nom);
                    myCommand.Parameters.AddWithValue("@tel", this.tel);
                    myCommand.Parameters.AddWithValue("@email", this.email);
                    myCommand.Parameters.AddWithValue("@fax", this.fax);
                    myCommand.Parameters.AddWithValue("@clientType", getClientType(this.clientType));

                    var someResult = myCommand.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                databaseObject.closeConnection();
            }
            
        }

        public bool clientExists(string nom, string tel)
        {
            //TODO: fix the query
            string query = "SELECT * FROM client WHERE nom like @nom AND tel like @tel";
            try
            {
                using (MySqlCommand myCommand = new MySqlCommand(query, databaseObject.getConnection()))
                {
                    databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@nom", nom);
                    myCommand.Parameters.AddWithValue("@tel", tel);
                    MySqlDataReader myReader = myCommand.ExecuteReader();
                    if (!myReader.HasRows)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                databaseObject.closeConnection();
            }

        }

        public List<string> getClientsList()
        {
            List<string> namesCollection = new List<string>();
            string query = "SELECT nom FROM client";
            try
            {
                using (MySqlCommand myCommand = new MySqlCommand(query, databaseObject.getConnection()))
                {
                    databaseObject.openConnection();
                    MySqlDataReader myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        namesCollection.Add(myReader[0].ToString());
                    }
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                databaseObject.closeConnection();
            }
            return namesCollection;
        }

        public Client getClientByName(string nom)
        {
            Client client = new Client();
            //TODO: fix the query
            string query = "SELECT * FROM client WHERE nom like @nom";
            try
            {
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@nom", nom);
                    MySqlDataReader myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            client.id = (int?)myReader[0];
                            client.nom = myReader[1].ToString();
                            client.tel = myReader[2].ToString();
                            client.email = myReader[3].ToString();
                            client.fax = myReader[4].ToString();
                            client.clientType = setClientType(Convert.ToInt32(myReader[5]));
                        }
                    }
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
            return client;
        }

        public Client getClientByNameAndPhone(string nom, string tel)
        {
            Client client = new Client();
            //TODO: fix the query
            string query = "SELECT * FROM client WHERE nom like @nom AND tel like @tel";
            try
            {
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@nom", nom);
                    myCommand.Parameters.AddWithValue("@tel", tel);
                    MySqlDataReader myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            client.id = (int?)myReader[0];
                            client.nom = myReader[1].ToString();
                            client.tel = myReader[2].ToString();
                            client.email = myReader[3].ToString();
                            client.fax = myReader[4].ToString();
                            client.clientType = setClientType(Convert.ToInt32(myReader[5]));
                        }
                    }
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
            return client;
        }

        public ClientType setClientType(int type)
        {
            switch (type)
            {
                case 0:
                    return ClientType.Client;
                case 1:
                    return ClientType.RaisonSociale;
                default:
                    return ClientType.Nothing;
            }
        }

        /// <summary>
        /// Gets the last ID in teh database
        /// </summary>
        /// <returns></returns>
        public int getLastID()
        {
            //TODO: write the query 

            
            string query = "SELECT MAX(id) FROM `client`";
            int lastId;
            try
            {
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    lastId = (int)myCommand.ExecuteScalar();
                    
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
            return lastId;
        }

        /// <summary>
        /// Gets client by ID
        /// </summary>
        /// <param name="ID">ID of the client to get </param>
        /// <returns></returns>
        public Client getClientByID(int ID)
        {

            try
            {
                string query = "SELECT * FROM client WHERE id = @id";
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@id", ID);
                    var myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        this.id = (int)myReader[0];
                        this.nom = myReader[1].ToString();
                        this.tel = myReader[2].ToString();
                        this.email = myReader[3].ToString();
                        this.fax = myReader[4].ToString();
                        this.clientType = getType(Convert.ToInt32(myReader[5]));
                    }
                }

                return this;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
            //try
            //{
                
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //finally 
            //{
            //    this.databaseObject.closeConnection();
            //}
        }
        
        /// <summary>
        /// This will get the client type to an enum
        /// </summary>
        /// <param name="id">ID of the client</param>
        /// <returns></returns>
        private ClientType getType(int id)
        {
            switch (id)
            {
                case 0:
                    return ClientType.Client;
                case 1:
                    return ClientType.RaisonSociale;
                default:
                    return ClientType.Nothing;
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
