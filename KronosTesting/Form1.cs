using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Windows.Forms;
using unirest_net.http;

namespace KronosTesting
{
    /// <summary>
    /// One window for this program
    /// </summary>
    public partial class Form1 : Form
    {
        private static DataTable dtCustomers = null;
        private static SqlConnection conn = null;
        private static string token = ReadToken();

        //some fields may be hidden later
        private string sqlBase = "SELECT [ID], [First Name], [Last Name], Email, [Secondary Email], [Work Phone],[Cell Phone], " +
            "[Home Phone], [Company: Phone], Company, LEFT(CONVERT(VARCHAR, [DOB], 120), 10) AS BirthDay, " + 
            "CONVERT(int,ROUND(DATEDIFF(hour,[DOB],GETDATE())/8766.0,0)) AS Age ,'$' + CONVERT(varchar(12), salary, 1) as Salary, " + 
            "link, REPLICATE('0',4-LEN(RTRIM(Last4))) + RTRIM(Last4) as Last4SSN FROM All_Employees";
        private string sql = "";
        private static readonly HttpClient client = new HttpClient();
        
        private static string userName = GetUserName();
        private static List<Tuple<string, int>> agents = null;
        private static List<string> agentNames = null;

        /// <summary>
        /// Constuctor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            StartUp();//builds the SQL connection, etc
            //MakeLinkCells();
            WindowState = FormWindowState.Maximized;
            Console.WriteLine(userName);
        }


        private static string GetUserName() {
            return Environment.UserName;
            //return (string)collection.Cast<ManagementBaseObject>().First()["UserName"];
        }

        /// <summary>
        /// This will apply an sql like filter on the DataGridView according to the TextBoxes
        /// </summary>
        private void ResetData()
        {
            //build the row filter
            sql = "([Email] like '%" + tbEmail.Text.Trim() + "%'";
            sql += " OR [Secondary Email] like '%" + tbEmail.Text.Trim() + "%')";
            sql += " AND ([Work Phone] like '%" + tbPhone.Text.Trim() + "%'";
            sql += " OR [Cell Phone] like '%" + tbPhone.Text.Trim() + "%'";
            sql += " OR [Home Phone] like '%" + tbPhone.Text.Trim() + "%')";

            //NOTE: All should be converted to open wildcard
            if(cbSchools.Text.Trim() == "All")
            {
                sql += " AND [Company] like '%'";
            } else
            {
                sql += " AND [Company] like '%" + cbSchools.Text.Trim() + "%'";
            }

            sql += " AND [First Name] like '%" + tbfName.Text.Trim() + "%'";
            sql += " AND [Last Name] like '%" + tblName.Text.Trim() + "%'";

            //Adding last 4

            sql += " AND [Last4SSN] like'%" + tbLast4.Text.Trim() + "%'";
            Console.WriteLine(sql);
            
            //set row filter
            ((DataTable)dgData.DataSource).DefaultView.RowFilter = sql;

            //update record count
            lblRecordCount.Text = "Record Count: " + ((DataTable)dgData.DataSource).DefaultView.Count;
        }

        /// <summary>
        /// Builds SQL connection, loads data to DataGridView, 
        /// </summary>
        private void StartUp()
        {
            dgData.AutoSize = true;
            dgData.Dock = DockStyle.Fill;
            dtCustomers = new DataTable();
            //BuildSQL();
            Console.WriteLine(sqlBase);
            conn = new SqlConnection("Data Source=RALIMSQL1;Initial Catalog=Kronos;Integrated Security=SSPI;");
            SqlCommand cmd = new SqlCommand(sqlBase, conn);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dtCustomers);

            dgData.DataSource = dtCustomers;
            
            dgData.Refresh();

            lblRecordCount.Text = "Record Count: " + ((DataTable)dgData.DataSource).DefaultView.Count;
            dgData.Refresh();

            cmd = new SqlCommand("SELECT Company FROM [Kronos].[dbo].[All_Employees] GROUP BY Company ORDER BY Company ASC", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            cbSchools.Items.Clear();
            cbSchools.Items.Add("All");
            while (reader.Read())
            {
                cbSchools.Items.Add(reader.GetString(0));
            }
            conn.Close();
            cmd.Dispose();
            cbSchools.SelectedIndex = 0;
            conn.Close();

            GetAgentNames();
            cbAgents.Items.Insert(0, "Change Default Agent");
            foreach(string name in agentNames) {
                cbAgents.Items.Add(name);
            }
            cbAgents.SelectedIndex = 0;

            ((DataTable)dgData.DataSource).DefaultView.RowFilter = null;
            
            lblRecordCount.Text = "Record Count: " + ((DataTable)dgData.DataSource).DefaultView.Count;
            //hide the ID column
            dgData.Columns[0].Visible = false; //ID
            dgData.Columns[10].Visible = false; 
            dgData.Columns[11].Visible = false;
            dgData.Columns[12].Visible = false;
            dgData.Columns[14].Visible = false;

        }

        private void btnName_Click(object sender, EventArgs e)
        {
            ((DataTable)dgData.DataSource).DefaultView.RowFilter = null;
            lblRecordCount.Text = "Record Count: " + ((DataTable)dgData.DataSource).DefaultView.Count;
            tbEmail.Text = "";
            tbfName.Text = "";
            tblName.Text = "";
            tbPhone.Text = "";
            tbLast4.Text = "";
        }


        private void cbSchools_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetData();
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            ResetData();
        }

        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            ResetData();
        }

        private void tblName_TextChanged(object sender, EventArgs e)
        {
            ResetData();
        }

        private void tbfName_TextChanged(object sender, EventArgs e)
        {
            ResetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnName_Click(null, null);
            StartUp();
        }

        /// <summary>
        /// Creates a base lead using basic contact info from Kronos. Placing them in Base<BR>
        /// Leave as sync (not async0 for API verification and error checking reasons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnMakeLead_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = null;
            if(dgData.SelectedRows.Count == 0) {
                int selected = dgData.SelectedCells[0].RowIndex;
                selectedRow = dgData.Rows[selected]; 
            } else {
                selectedRow = dgData.SelectedRows[0];
            }

            string postData = BuildJson(selectedRow);
            string userID = selectedRow.Cells[0].Value.ToString();
            //Console.WriteLine(postData);

            HttpResponse<string> jsonResponse = Unirest.post("https://api.getbase.com/v2/leads")
                  .header("accept", "application/json")
                  .header("Authorization", "Bearer " + token)
                  .header("Content-Type", "application/json")
                  .body(postData)
                  .asJson<string>();

            string body = jsonResponse.Body.ToString();
            JObject jo = JObject.Parse(body);
            string leadID = jo["data"]["id"].ToString();
            string URL = "https://app.futuresimple.com/leads/" + leadID;

            if(MessageBox.Show("Would you like to open the lead in base?",
                "Open in Base?", MessageBoxButtons.YesNo) == DialogResult.Yes){
                    System.Diagnostics.Process.Start(URL);
                }

            bool updated = WriteLink(URL, userID);
            if (updated) {
                selectedRow.Cells[13].Value = URL;
                //MakeLinkCells();
            }

            Console.WriteLine(jo);
        }

        private static bool WriteLink(string link, string userID) {
            SqlConnection tconn = new SqlConnection("Data Source=RALIMSQL1;Initial Catalog=Kronos;Integrated Security=SSPI;");
            string sqlStr = "UPDATE [Kronos].[dbo].[All_Employees] SET[link] = '" + link + "' WHERE[ID] = '" + userID + "'";

            SqlCommand cmd = new SqlCommand(sqlStr, tconn);
            tconn.Open();
            cmd.CommandType = System.Data.CommandType.Text;
            int rAffected = cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            if (rAffected != 1) {
                MessageBox.Show("Something went wrong writing link the database\n The lead was created however.");
                return false;
            } else {
                return true;
            }
        }

        private static string GetUserID() {
            string id = "";
            SqlConnection tconn = new SqlConnection("Data Source=RALIMSQL1;Initial Catalog=Kronos;Integrated Security=SSPI;");
            SqlCommand cmd = new SqlCommand("SELECT Kronos.dbo.userIDs.id FROM[Kronos].[dbo].[userIDs] Where uname = '" + userName +"';", tconn);
            tconn.Open();
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
               id = reader.GetString(0);
            }
            conn.Close();
            cmd.Dispose();
            return id;
        }

        private void tbLast4_TextChanged(object sender, EventArgs e) {
            ResetData();
        }

        public string BuildJson(DataGridViewRow row) {
            string[] arr = new string[1];
            arr[0] = tbTags.Text;
            int idNum = 0;
            if(cbAgents.SelectedItem == null || cbAgents.SelectedItem.ToString() == "Change Default Agent"){
                idNum = Convert.ToInt32(GetUserID());
            } else {
                idNum = GetAgentID();
            }

            JObject custSub = new JObject(
                new JProperty("Worksite Email", row.Cells[4].Value),
                new JProperty("Worksite Phone", row.Cells[5].Value),
                new JProperty("Home Phone", row.Cells[7].Value),
                new JProperty("District Phone", row.Cells[8].Value),
                new JProperty("District", row.Cells[9].Value)
                //new JProperty("DOB", row.Cells[10].Value),
                //new JProperty("Annual Salary", row.Cells[12].Value)
                );
            JObject data = new JObject(
                        new JProperty("owner_id", idNum),
                        new JProperty("first_name", row.Cells[1].Value),
                        new JProperty("last_name", row.Cells[2].Value),
                        new JProperty("email", row.Cells[3].Value),
                        new JProperty("mobile", row.Cells[6].Value),
                        new JProperty("tags", new JArray(arr)),
                        new JProperty("custom_fields", custSub)
                        );

            JObject json = new JObject(new JProperty("data", data));
            return json.ToString();
        }

        private void MakeLinkCells() {
            foreach(DataGridViewRow row in dgData.Rows) {
                if (!(row.Cells[13] is DataGridViewLinkCell)) {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    linkCell.Value = row.Cells[13].Value.ToString();
                    row.Cells[13] = linkCell;
                }
                //if(!(row.Cells[13] is DataGridViewLinkCell) && row.Cells[13].Value.ToString() != "" && row.Cells[13].Value != null){
                //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //    linkCell.Value = row.Cells[13].Value;
                //    row.Cells[13] = linkCell;
                //} else if(!(row.Cells[13] is DataGridViewLinkCell)) {
                //    row.Cells[13] = new DataGridViewLinkCell();
                //}
            }
        }


        private static string ReadToken() {
            try {
                System.IO.StreamReader tFile = new System.IO.StreamReader("\\\\nas3\\Shared\\RALIM\\James\\token.tkn");
                return tFile.ReadToEnd();
            } catch (Exception e) {
                MessageBox.Show("Could not find Base Token\nUnable to push lead\nContact Admin\n" + e);
                return "";
            }
        }

        private void dgData_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 13 && dgData.CurrentCell.Value != null && dgData.CurrentCell.Value.ToString() != "") {
                System.Diagnostics.Process.Start(dgData.CurrentCell.Value.ToString());
            }
            else if (dgData.CurrentCell.Value != null && dgData.CurrentCell.Value.ToString() != "") {
                Clipboard.SetText(dgData.CurrentCell.Value.ToString());
            }
        }

        private void dgData_CellClick(object sender, DataGridViewCellEventArgs e) {

        }

        public int GetAgentID() {
            if(agentNames == null || agentNames.Count == 0) {
                GetAgentNames();
            }

            foreach(Tuple<string, int> tuple in agents) {
                if(tuple.Item1 == cbAgents.SelectedItem.ToString()) {
                    return tuple.Item2;
                }
            }
            return 0;
        }

        private static void GetAgents() {
            string name = "";
            string idnum = "";
            agents = new List<Tuple<string, int>>();
            SqlConnection tconn = new SqlConnection("Data Source=RALIMSQL1;Initial Catalog=Kronos;Integrated Security=SSPI;");
            SqlCommand tcmd = new SqlCommand("SELECT * FROM [Kronos].[dbo].[userIDs]", tconn);
            tconn.Open();
            tcmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = tcmd.ExecuteReader();

            while (reader.Read()) {
                name = reader.GetString(1);
                idnum = reader.GetString(0);
                agents.Add(Tuple.Create(name, Convert.ToInt32(idnum)));
            }

            tconn.Close();
            tcmd.Dispose();
        }

        private void GetAgentNames() {
            if (agents == null || agents.Count == 0) {
                GetAgents();
            }

            agentNames = new List<string>();
            foreach (Tuple<string, int> tuple in agents) {
                agentNames.Add(tuple.Item1);
            }
        }
    }
}
