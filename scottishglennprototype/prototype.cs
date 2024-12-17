using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Expr;
using Microsoft.VisualBasic.ApplicationServices;
using System.Management;
using System.Text.Json;
using System.Text;




namespace scottishglennprototype
{
    public partial class prototype : Form
    {
        private int userID;
        private bool isAdmin;

        //connect to db
        private string connectionString = "Data Source=lochnagar.abertay.ac.uk;Initial Catalog=sql2303150;User ID=sql2303150;Password=perry-pearl-staff-floral";

        public prototype()
        {
            InitializeComponent();
        }

        public prototype(int userID, bool isAdmin)
        {
            InitializeComponent();
            this.userID = userID;
            this.isAdmin = isAdmin;

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
                               "a.SystemName, a.Model, a.Manufacturer, a.AssetType, a.IPAddress, a.PurchaseDate, a.TextNote, a.AssetID, a.OSName, a.OSVersion " +
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
            string osName = "";
            string osVersion = "";
            string manufacturer = "";


            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                osName = os["Caption"].ToString();
                osVersion = os["Version"].ToString();
                manufacturer = os["Manufacturer"].ToString();
            }
            Console.WriteLine($"OS Name: {osName}, Version: {osVersion}, Manufacturer: {manufacturer}");
        }

        // function to add new asset
        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            string systemName = Interaction.InputBox("Enter System Name:", "Add Asset", "");
            string model = Interaction.InputBox("Enter Model:", "Add Asset", "");
            string manufacturer = Interaction.InputBox("Enter Manufacturer:", "Add Asset", "");
            string assetType = Interaction.InputBox("Enter Asset Type:", "Add Asset", "");
            string ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            DateTime purchaseDate = DateTime.Now;
            string textNote = Interaction.InputBox("Enter Note:", "Add Asset", "");
            int employeeID = userID;

            // atomatically get system data 
            getSystemData(sender, e);

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
        private async Task<string> CheckNVDForVulnerabilities(string systemName, string version)
        {
            string apiUrl = $"https://services.nvd.nist.gov/rest/json/cves/2.0?keywordSearch={systemName} {version}&resultsPerPage=10";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        return responseData;

                    }
                    else
                    {
                        MessageBox.Show($"Failed to retrieve vulnerabilities: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while checking vulnerabilities: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



        private async void btnCheckVulnerabilities_Click(object sender, EventArgs e)
        {

            if (!isAdmin)
            {
                MessageBox.Show("Access denied. This feature is restricted to IT department employees.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridViewAssets.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a software asset to check vulnerabilities.", "Check Vulnerabilities", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dataGridViewAssets.SelectedRows[0];
                string systemName = selectedRow.Cells["OSName"].Value.ToString();
                string version = selectedRow.Cells["OSVersion"].Value.ToString();


                string assetType = selectedRow.Cells["AssetType"].Value.ToString();
                if (assetType != "Operating System")
                {
                    MessageBox.Show("This feature is only available for software assets (e.g., Operating Systems).", "Check Vulnerabilities", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string vulnerabilities = await CheckNVDForVulnerabilities(systemName, version);
                if (string.IsNullOrWhiteSpace(vulnerabilities))
                {
                    MessageBox.Show("No high or critical vulnerabilities found.", "Check Vulnerabilities", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(vulnerabilities, "Vulnerabilities Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            
        }
    }
}
