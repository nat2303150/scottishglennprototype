using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace scottishglennprototype
{
    public partial class prototype : Form
    {
        //connect to db
        private string connectionString = "Data Source=lochnagar.abertay.ac.uk;Initial Catalog=sql2303150;User ID=sql2303150;Password=perry-pearl-staff-floral";

        public prototype()
        {
            InitializeComponent();
        }

        private void prototype_Load(object sender, EventArgs e)
        {
            loadAssets();
        }

        private void loadAssets()
        {
            //loads assets from database to display in table
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT e.EmployeeID, e.FirstName, e.LastName, e.Email, d.Name AS DepartmentName, " +
                               "a.SystemName, a.Model, a.Manufacturer, a.AssetType, a.IPAddress, a.PurchaseDate, a.TextNote " +
                               "FROM Employees e " +
                               "JOIN Departments d ON e.DepartmentID = d.DepartmentID " +
                               "LEFT JOIN Assets a ON e.EmployeeID = a.EmployeeID";




                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable assetTable = new DataTable();
                adapter.Fill(assetTable);

                dataGridViewAssets.DataSource = assetTable;
            }
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

        private void btnViewAsset_Click(object sender, EventArgs e)
        {
            //todo
        }

        private void btnEditAsset_Click(object sender, EventArgs e)
        {
            //todo
        }

        private void btnDeleteAsset_Click(object sender, EventArgs e)
        {
            //todo
        }
    }
}
