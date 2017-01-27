using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace espaceNetSAV
{
    public class BonReception
    {
        private Database databaseObject;
        public int id;
        public DateTime date;
        public Client client;
        public DesignationReception designationReception;
        public Technique tech;
        public string ref_achat;

        #region Methodes 
        public BonReception() 
        {
            this.databaseObject = new Database();
            this.tech = new Technique();
            this.date = DateTime.Now; 
        }

        public BonReception(Client client,  DesignationReception desReception, string ref_achat)
        {
            this.databaseObject = new Database();
            this.date = DateTime.Now;
            this.tech = new Technique();
            this.client = client;
            this.designationReception = desReception;
            this.ref_achat = ref_achat;
        }
        #endregion
        /// <summary>
        /// Saves the current object to the database
        /// </summary>
        public void persistObjectToDatabase()
        {
            //TODO: fix the query 
            string query = "INSERT INTO `bonreception`(`bonDate`, `client_id`, `designation_id`, `ref_achat`) VALUES (@date, @client_id, @designation_id, @ref_achat)";
            try
            {
                using (MySqlCommand myCommand = new MySqlCommand(query, databaseObject.getConnection()))
                {
                    databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@date", this.date.ToString("yyyy-MM-dd HH:mm:ss"));
                    myCommand.Parameters.AddWithValue("@client_id", this.client.id);
                    myCommand.Parameters.AddWithValue("@designation_id", this.designationReception.id);
                    myCommand.Parameters.AddWithValue("@ref_achat", this.ref_achat);
                    myCommand.ExecuteNonQuery();
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
        /// <summary>
        /// Gets all the data in the Bon Reception table
        /// </summary>
        /// <returns></returns>
        public DataTable GetData()
        {
            try
            {
                string query = "SELECT * FROM bonReception, client, receptiondesignation WHERE bonReception.client_id = client.id AND bonReception.designation_id = receptiondesignation.id";
                //string query = "SELECT * FROM client";
                MySqlDataAdapter adapter;
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = myCommand;
                }

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.Fill(table);
                table.Columns["id"].ColumnName = "Bon N°";
                table.Columns["bonDate"].ColumnName = "Date";
                table.Columns["client_id"].ColumnName = "Client ID";
                table.Columns["designation_id"].ColumnName = "Designation ID";
                table.Columns["ref_achat"].ColumnName = "Ref Achat";
                table.Columns["id1"].ColumnName = "Clients ID";
                table.Columns["nom"].ColumnName = "Nom";
                table.Columns["tel"].ColumnName = "Telephone";
                table.Columns["fax"].ColumnName = "Fax";
                table.Columns["email"].ColumnName = "Email";
                table.Columns["contact"].ColumnName = "Contact";
                table.Columns["client_type"].ColumnName = "Client Type";
                table.Columns["id2"].ColumnName = "Designations ID";
                table.Columns["designation"].ColumnName = "Designation";
                table.Columns["probleme"].ColumnName = "Problème";
                return table;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Gets the data for the PDF file
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BonReception getDataForPdf(int id)
        {
            BonReception bonObject = new BonReception();
            Client clientObject = new Client();
            DesignationReception designationObject = new DesignationReception();
            string query = "SELECT * FROM bonReception WHERE ID = @id";
            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
            {
                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@id", id);
                var myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    bonObject.id = (int)myReader[0];
                    bonObject.client = clientObject.getClientByID((int)myReader[2]);
                    bonObject.designationReception = designationObject.getDesignationByID((int)myReader[3]);
                    bonObject.date = Convert.ToDateTime(myReader[1]);
                    bonObject.ref_achat = myReader[4].ToString();
                }
            }

            return bonObject;
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
        /// Gets teh item "Bon" coresponds to the given id
        /// </summary>
        /// <param name="bonID">Bon id</param>
        /// <returns></returns>
        public BonReception getItem(int bonID)
        {
            string query = "SELECT * FROM bonReception WHERE  bonReception.id = @id";

            using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection())) 
            {
                Technique techObject = new Technique();
                Client clientObject = new Client();
                DesignationReception designationObject = new DesignationReception();
                this.databaseObject.openConnection();
                myCommand.Parameters.AddWithValue("@id", bonID);
                var myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    this.id = (int)myReader[0];
                    this.date = Convert.ToDateTime(myReader[1]);
                    this.client = clientObject.getClientByID(Convert.ToInt32(myReader[2]));
                    this.designationReception = designationObject.getDesignationByID((int)myReader[3]);
                    this.tech = techObject.getItem(Convert.ToInt32(myReader["tech_id"]));
                    this.ref_achat = myReader[4].ToString();
                    var shit = tech.getItem((int)myReader[5]);
                }
            }

            return this;
        }

    }
}
