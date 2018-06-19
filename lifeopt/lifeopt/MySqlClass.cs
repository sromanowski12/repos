using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace lifeopt
{
    public class MySqlClass : Form1
    {
        public MySqlConnection mySql;
        public MySqlCommand cmd;
        public MySqlDataAdapter adapter;
        public string connectStr = "server=localhost;user=root;database=sakila;port=3306;pwd=Baseball33;";
        public string query;
        public MySqlClass()
        {
            try
            {
                mySql = new MySqlConnection(connectStr);
                mySql.Open();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        public void closeConnect()
        {
            mySql.Close();
            MessageBox.Show("Closed");
        }
        public void setQuery(string inputQuery)
        {
            query = inputQuery;
        }
        public void executeNonQuery()
        {
            cmd.ExecuteNonQuery();
        }
        public void executeScalar(ref int count)
        {
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                count = Convert.ToInt32(result);
                Console.WriteLine("Number of countries in the world database is: " + count);
            }
        }
        public void setCmd()
        {
            cmd = new MySqlCommand(query, mySql);
        }
        public void setAdapter()
        {
            adapter = new MySqlDataAdapter();
        }
        public void setAdapterSelectCmd()
        {
            adapter.SelectCommand = cmd;
        }
        public void setAdapterInsertCmd()
        {
            adapter.InsertCommand = cmd;
        }
    }
}
