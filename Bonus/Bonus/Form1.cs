using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bonus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-G3GOK72;Initial Catalog=Hadasim;Integrated Security=True");
            sqlConnection.Open();
            DataTable memberTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Member", sqlConnection);
            adapter.Fill(memberTable);

            
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("ActivePatients", typeof(int));
            dt.PrimaryKey = new DataColumn[] { dt.Columns["Date"] }; // set primary key


            DateTime startDate = DateTime.Today.AddMonths(-1).Date;
            DateTime endDate = DateTime.Today.Date;
            // Initialize the dictionary with zeros for each day
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                dt.Rows.Add(date, 0);
            }

            // Count the active patients for each day
            foreach (DataRow memberRow in memberTable.Rows)
            {
                DateTime positiveAnswerDate = (DateTime)memberRow["PositiveAnswerDate"];
                DateTime? recoveryDate = memberRow.Field<DateTime?>("RecoveryDate");
                if (positiveAnswerDate >= startDate && positiveAnswerDate <= endDate && (recoveryDate == null || recoveryDate > endDate))
                {
                    DateTime date = positiveAnswerDate.Date;
                    while (date <= endDate && (recoveryDate == null || date <= recoveryDate))
                    {
                        DataRow activePatientsCountRow = dt.Rows.Find(date);
                        activePatientsCountRow["ActivePatients"] = ((int)activePatientsCountRow["ActivePatients"]) + 1;
                        date = date.AddDays(1);
                    }
                }
            }




            sqlConnection.Close();
            chart1.DataSource = dt;
            chart1.Series["numberOfPositive"].XValueMember = "Date";
            chart1.Series["numberOfPositive"].YValueMembers = "ActivePatients";
            chart1.Titles.Add("Active Patients per Date");



            SqlDataAdapter adapter1 = new SqlDataAdapter(
               "SELECT COUNT(*) AS NumOfNonVacPeople " +
               "FROM Member M " +
               "WHERE NOT EXISTS (SELECT Id FROM Vaccine V WHERE M.Id = V.Id )", sqlConnection);

            DataTable resultTable = new DataTable();
            adapter1.Fill(resultTable);

            if (resultTable.Rows.Count > 0)
            {
                int numOfNonVacPeople = Convert.ToInt32(resultTable.Rows[0]["NumOfNonVacPeople"]);
                label1.Text = "Number of non-vaccinated people: " + numOfNonVacPeople;
            }

        }
    }
}
