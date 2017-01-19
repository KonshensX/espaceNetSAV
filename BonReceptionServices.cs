using System;
using MySql.Data.MySqlClient;


namespace espaceNetSAV
{
    class BonReceptionServices
    {
        Database databaseObject;
        Client client;
        DesignationReception designationReception;
        BonReception bonReception;
    

        public BonReceptionServices() { }

        public BonReceptionServices(Client client, DesignationReception designation, BonReception bonReception)
        {
            databaseObject = new Database();
            this.client = client;
            this.designationReception = designation;
            this.bonReception = bonReception;
        }


        #region Methodes 
        public void persistObjectToDatabase(BonReception bonReceptionObject)
        {
            string query = "INSERT INTO ";
            using (MySqlCommand myCommand = new MySqlCommand(query, databaseObject.getConnection()))
            {
                
            }
        }
        #endregion
    }
}
