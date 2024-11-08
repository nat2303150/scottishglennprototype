using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;

namespace scottishglennprototype
{
    public partial class prototype : Form
    {
        private string connectionString = "Data Source=tolmount.abertay.ac.uk;Initial Catalog=sql2303150;User ID=mssql2303150;Password=perry-pearl-staff-floral";

        public prototype()
        {
            InitializeComponent();
        }

        private void prototype_Load(object sender, EventArgs e)
        {
            loadAssets();
        }

        private void loadAssets() {
            //todo
        }
            
        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            //todo
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
