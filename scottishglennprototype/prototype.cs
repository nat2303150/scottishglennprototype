using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Expr;
using Microsoft.VisualBasic.ApplicationServices;



namespace scottishglennprototype
{
    public partial class prototype : Form
    {
        private int userID;

        //connect to db
        private string connectionString = "Data Source=lochnagar.abertay.ac.uk;Initial Catalog=sql2303150;User ID=sql2303150;Password=perry-pearl-staff-floral";

        public prototype()
        {
            InitializeComponent();
        }

        public prototype(int userID)
        {
            InitializeComponent();
            this.userID = userID;

        }

        private void prototype_Load(object sender, EventArgs e)
        {
            loadAssets();
        }


        //function loads assets from database
        private void loadAssets()
        {
            //loads assets from database to display in table
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT e.EmployeeID, e.FirstName, e.LastName, e.Email, d.Name AS DepartmentName, " +
                               "a.SystemName, a.Model, a.Manufacturer, a.AssetType, a.IPAddress, a.PurchaseDate, a.TextNote, a.AssetID " +
                               "FROM Employees e " +
                               "JOIN Departments d ON e.DepartmentID = d.DepartmentID " +
                               "LEFT JOIN Assets a ON e.EmployeeID = a.EmployeeID";




                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable assetTable = new DataTable();
                adapter.Fill(assetTable);

                dataGridViewAssets.DataSource = assetTable;
            }
        }

        private void getSystemData(object sender, EventArgs e)
        {
            //todo
        }


        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            string systemName = Interaction.InputBox("Enter System Name:", "Add Asset", "");
            string model = Interaction.InputBox("Enter Model:", "Add Asset", "");
            string manufacturer = Interaction.InputBox("Enter Manufacturer:", "Add Asset", "");
            string assetType = Interaction.InputBox("Enter Asset Type:", "Add Asset", "");
            string ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            DateTime purchaseDate = DateTime.Now;
            string textNote = Interaction.InputBox("Enter Note:", "Add Asset", "");
            int employeeID = Convert.ToInt32(Interaction.InputBox("Enter Employee ID:", "Add Asset", "1"));

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Assets (SystemName, Model, Manufacturer, AssetType, IPAddress, PurchaseDate, TextNote, EmployeeID) " +
                              "VALUES (@SystemName, @Model, @Manufacturer, @AssetType, @IPAddress, @PurchaseDate, @TextNote, @EmployeeID)";


                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SystemName", systemName);
                    command.Parameters.AddWithValue("@Model", model);
                    command.Parameters.AddWithValue("@Manufacturer", manufacturer);
                    command.Parameters.AddWithValue("@AssetType", assetType);
                    command.Parameters.AddWithValue("@IPAddress", ipAddress);
                    command.Parameters.AddWithValue("@PurchaseDate", purchaseDate);
                    command.Parameters.AddWithValue("@TextNote", textNote);
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);


                    command.ExecuteNonQuery();
                }
            }

            loadAssets();
        }


        //function to edit the selected asset in the table
        private void btnEditAsset_Click(object sender, EventArgs e)
        {

                if (dataGridViewAssets.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an asset to edit.", "Edit Asset", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dataGridViewAssets.SelectedRows[0];
                int assetID = Convert.ToInt32(selectedRow.Cells["AssetID"].Value);

                
                string newSystemName = Interaction.InputBox("Enter new System Name:", "Edit Asset", selectedRow.Cells["SystemName"].Value.ToString());
                string newModel = Interaction.InputBox("Enter new Model:", "Edit Asset", selectedRow.Cells["Model"].Value.ToString());
                string newManufacturer = Interaction.InputBox("Enter new Manufacturer:", "Edit Asset", selectedRow.Cells["Manufacturer"].Value.ToString());
                string newAssetType = Interaction.InputBox("Enter new Asset Type:", "Edit Asset", selectedRow.Cells["AssetType"].Value.ToString());

                // updates database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Assets SET SystemName = @SystemName, Model = @Model, Manufacturer = @Manufacturer, AssetType = @AssetType WHERE AssetID = @AssetID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SystemName", newSystemName);
                        command.Parameters.AddWithValue("@Model", newModel);
                        command.Parameters.AddWithValue("@Manufacturer", newManufacturer);
                        command.Parameters.AddWithValue("@AssetType", newAssetType);
                        command.Parameters.AddWithValue("@AssetID", assetID);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Asset was updated successfully.", "Edit Asset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadAssets(); 
                        }
                        else
                        {
                            MessageBox.Show("Failed to update the asset. Please try again.", "Edit Asset", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            
        }



        // function deletes selected asset 
        private void btnDeleteAsset_Click(object sender, EventArgs e)
        {
            if (dataGridViewAssets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an asset to delete from the table above.", "Delete Asset", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //gets asset id from the table
            int assetID = Convert.ToInt32(dataGridViewAssets.SelectedRows[0].Cells["AssetID"].Value);

            //  checks user wants to delete the asset
            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to delete this asset?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Assets WHERE AssetID = @AssetID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AssetID", assetID);

                        try
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Asset was deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadAssets(); 
                            }
                            else
                            {
                                MessageBox.Show("No asset was found with the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while deleting the asset: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
