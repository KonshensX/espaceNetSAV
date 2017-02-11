using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace espaceNetSAV
{
    public enum Dossier
    {
        Valide, 
        EnCours,
        Nothing
    }
    public class BonReception
    {
        private Database databaseObject;
        public int id;
        public DateTime date;
        public Client client;
        public DesignationReception designationReception;
        public Technique tech;
        public string ref_achat;
        public string devis;
        public Dossier dossier;

        #region Methodes 
        public BonReception() 
        {
            this.databaseObject = new Database();
            if (this.tableHasRow())
                this.id = this.GetLastID() + 1;
            else
                this.id = 1;
            this.date = DateTime.Now; 
            this.client = new Client();
            this.designationReception = new DesignationReception();

            this.tech = new Technique();
            this.ref_achat = "";
            this.devis = "";
        }

        public BonReception(Client client,  DesignationReception desReception, Technique techObject, string ref_achat)
        {
            this.databaseObject = new Database();
            this.id = this.GetLastID() + 1;
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
            string query = "INSERT INTO `bonreception`(`bonDate`, `client_id`, `designation_id`, `ref_achat`, `tech_id`) VALUES (@date, @client_id, @designation_id, @ref_achat, @tech_id)";
            try
            {
                using (MySqlCommand myCommand = new MySqlCommand(query, databaseObject.getConnection()))
                {
                    databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@date", this.date.ToString("yyyy-MM-dd HH:mm:ss"));
                    myCommand.Parameters.AddWithValue("@client_id", this.client.id);
                    myCommand.Parameters.AddWithValue("@designation_id", this.designationReception.id);
                    myCommand.Parameters.AddWithValue("@ref_achat", this.ref_achat);
                    myCommand.Parameters.AddWithValue("@tech_id", this.tech.id);
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
                string query = "SELECT * FROM bonReception, client, receptiondesignation, techniques WHERE bonReception.client_id = client.id AND bonReception.designation_id = receptiondesignation.id AND bonreception.etatdossier = 0 AND (techniques.id = bonreception.tech_id) OR (techniques.id = null)";
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
                table.Columns["devis"].ColumnName = "Devis";
                table.Columns["etatdossier"].ColumnName = "Validé";
                table.Columns["tech_id"].ColumnName = "Tech ID";
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
                table.Columns["id3"].ColumnName = "Tech ID ID";
                table.Columns["diagno"].ColumnName = "Diagnostics";
                table.Columns["tasks"].ColumnName = "Tàches Effectuer";
                table.Columns["bon_id"].ColumnName = "ID BON";
                table.Columns["fixed"].ColumnName = "Etat";
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
            try
            {
                string query = "SELECT * FROM bonReception WHERE ID = @id";
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@id", id);
                    var myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        this.id = (int)myReader[0];
                        this.client = this.client.getClientByID((int)myReader[2]);
                        this.designationReception = this.designationReception.getDesignationByID((int)myReader[3]);
                        this.date = Convert.ToDateTime(myReader[1]);
                        this.ref_achat = myReader[4].ToString();
                        this.devis = myReader[6].ToString();
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
        /// Gets the item "Bon" coresponds to the given id
        /// </summary>
        /// <param name="bonID">Bon id</param>
        /// <returns></returns>
        public BonReception getItem(int bonID)
        {
            try
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
                        this.devis = myReader[6].ToString();
                        this.dossier = this.GetDossierStatus(Convert.ToInt32(myReader[7]));
                    }
                    myReader.Close();
                }
                
                return this;
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        /// <summary>
        /// This well get the last id in the BonReception table
        /// </summary>
        /// <returns></returns>
        public int GetLastID()
        {
            try
            {
                string query = "SELECT MAX(id) FROM bonreception";
                var lastID = 0;
                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    lastID = Convert.ToInt32(myCommand.ExecuteScalar());
                }
                return lastID;
            } 
            catch (MySqlException ex)
            {
                throw ex;
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
                string query = "SELECT * FROM `bonreception`";
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


        public void updateDevis()
        {
            try
            {
                string query = "UPDATE bonreception SET devis = @devis WHERE id = @bon_id";

                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@devis", this.devis);
                    myCommand.Parameters.AddWithValue("@bon_id", this.id);
                    myCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        public void onLoadUpdateEtat()
        {

        }

        /// <summary>
        /// This updates the current object `Folder` status
        /// </summary>
        /// <returns></returns>
        public int UpdateDossierStatus()
        {
            try
            {
                string query = "UPDATE bonreception SET etatdossier = @etat WHERE id = @bon_id";

                using (MySqlCommand myCommand = new MySqlCommand(query, this.databaseObject.getConnection()))
                {
                    this.databaseObject.openConnection();
                    myCommand.Parameters.AddWithValue("@etat", this.GetDossierStatus(this.dossier));
                    myCommand.Parameters.AddWithValue("@bon_id", this.id);

                    return Convert.ToInt32(myCommand.ExecuteNonQuery());
                }
            }
            finally
            {
                this.databaseObject.closeConnection();
            }
        }

        /// <summary>
        /// Get the status of the `Folder` based on database 
        /// </summary>
        /// <param name="status">ID of the `folder`</param>
        /// <returns></returns>
        public Dossier GetDossierStatus(int status)
        {
            switch (status)
            {
                case 0:
                    return Dossier.EnCours;
                case 1:
                    return Dossier.Valide;
                default:
                    return Dossier.Nothing;
            }
        }


        /// <summary>
        /// Get the status of the `Folder` based on the object Dossier
        /// </summary>
        /// <param name="dossier"></param>
        /// <returns></returns>
        public int GetDossierStatus(Dossier dossier)
        {
            switch (dossier)
            {
                case Dossier.EnCours:
                    return 0;
                case Dossier.Valide: 
                    return 1;
                default:
                    return -1;
            }
        }

        
    }
}
