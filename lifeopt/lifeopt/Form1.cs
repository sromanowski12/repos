using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Outlook = Microsoft.Office.Interop.Outlook;
using MySql.Data;
using MySql.Data.MySqlClient;
using AutoIt;
using AutoItX3Lib;
using AdvButton;
using iTunesLib;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace lifeopt
{
    public partial class Form1 : Telerik.WinControls.UI.RadForm
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void loadCmb(object sender, EventArgs e)
        {

            iTunes music = new iTunes();
            music.loadCmbPlaylists();
            for (int i = 1; i < music.playlists.Count + 1; i++)
            {
                cmbPlaylists.Items.Add(music.playlists[i].Name);
            }
        }
        private void loadDt(object sender, EventArgs e)
        {
            iTunes music = new iTunes();
            music.loadCmbPlaylists();
            DataTable dt = new DataTable();
            string playlistName;
            playlistName = cmbPlaylists.Text;
            music.playlists = music.tunes.LibrarySource.Playlists;

            music.songs = music.playlists.ItemByName[playlistName].Tracks;
            dataGridView3.Columns.Add("id", "id");
            dataGridView3.Columns.Add("artist", "artist");
            dataGridView3.Columns.Add("song", "song");
            dataGridView3.Columns.Add("album", "album");

            DataRow dr = dt.NewRow();

            for (int i = 1; i < music.songs.Count + 1; i++)
            {
                dataGridView3.Rows.Add(music.songs[i].trackID, music.songs[i].Artist, music.songs[i].Name, music.songs[i].Album);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application xl = null;
            Excel.Workbooks xlWbs = null;
            Excel.Workbook xlWb = null;
            Excel.Sheets xlSheets = null;
            Excel.Worksheet xlSheet = null;
            Excel.Range xlRng = null;

            xl = new Excel.Application();
            xlWbs = xl.Workbooks;
            xlWb = xlWbs.Add();
            xlSheets = xlWb.Sheets;
            //           xlSheet = xlSheets.Item[1];

            xl.Visible = true;
            //xlWbs = xl.Workbooks;
            string filePath = @"‪C:\Users\sroma\Desktop\test2.xlsx";
            xlWb.SaveAs(@"C:\Users\sroma\Desktop\test2.xlsx");
            //            xlSheets = xlWb.Sheets;
            xlSheet = (Excel.Worksheet)xlWb.Worksheets.get_Item(1);
            //           xlRng = (Excel.Range)xlSheet.Cells[1, 1];

            xl.Visible = true;
            xlSheet.Cells[1, 1] = "Test";

            xlWb.Close();

            xlWbs.Open(@"C:\Users\sroma\Desktop\test2.xlsx");

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //    Process.Start("excel.exe");
            Process Proc = new Process();
            Proc.StartInfo.FileName = @"cscript";
            Proc.StartInfo.Arguments = @"C:\Users\sroma\OneDrive\Education\Projects\testAssistant.bat";
            Proc.Start();
            Proc.WaitForExit();
            //    Proc.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            AutoItX.Run("notepad.exe", @"C:\Windows\system32\");
            AutoItX.WinWaitActive("Untitled");
            AutoItX.Send("Im in notepad");


        }

        private void btnSelectAllKeyword(object sender, EventArgs e)
        {

            MySqlClass sqlObj = new MySqlClass();
            sqlObj.setQuery("SELECT * FROM sakila.keyword");
            sqlObj.setCmd();
            sqlObj.setAdapter();
            sqlObj.setAdapterSelectCmd();

            DataTable dt = new DataTable();
            sqlObj.adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            formatGridAllKeywords(dataGridView1, e);
            sqlObj.closeConnect();
        }
        private void formatGridAllKeywords(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[1].HeaderText = "Course ID";
            dataGridView1.Columns[1].Width = 35;
            dataGridView1.Columns[2].HeaderText = "Course";
            dataGridView1.Columns[2].Width = 35;
            dataGridView1.Columns[3].HeaderText = "Chapter ID";
            dataGridView1.Columns[3].Width = 35;
            dataGridView1.Columns[4].HeaderText = "Chapter";
            dataGridView1.Columns[4].Width = 35;
            dataGridView1.Columns[5].HeaderText = "Chaoter Desc";
            dataGridView1.Columns[5].Width = 35;
            dataGridView1.Columns[6].HeaderText = "Section ID";
            dataGridView1.Columns[6].Width = 35;
            dataGridView1.Columns[7].HeaderText = "Section";
            dataGridView1.Columns[7].Width = 35;
            dataGridView1.Columns[8].HeaderText = "Pg #";
            dataGridView1.Columns[8].Width = 35;
            dataGridView1.Columns[9].HeaderText = "Keyword";
            dataGridView1.Columns[9].Width = 35;
            dataGridView1.Columns[10].HeaderText = "Type ID";
            dataGridView1.Columns[10].Width = 35;
            dataGridView1.Columns[11].HeaderText = "Type";
            dataGridView1.Columns[11].Width = 35;
            dataGridView1.Columns[12].HeaderText = "Keyword Desc";
            dataGridView1.Columns[12].Width = 35;
            dataGridView1.Columns[13].HeaderText = "Desc2";
            dataGridView1.Columns[13].Width = 35;
            dataGridView1.Columns[14].HeaderText = "Desc3";
            dataGridView1.Columns[14].Width = 35;
            dataGridView1.Columns[15].HeaderText = "Desc4";
            dataGridView1.Columns[15].Width = 35;
            dataGridView1.Columns[16].HeaderText = "Desc5";
            dataGridView1.Columns[16].Width = 35;
            dataGridView1.Columns[17].HeaderText = "Desc6";
            dataGridView1.Columns[17].Width = 35;
            dataGridView1.Columns[18].HeaderText = "Desc7";
            dataGridView1.Columns[18].Width = 35;
            dataGridView1.Columns[19].HeaderText = "Desc8";
            dataGridView1.Columns[19].Width = 35;
            dataGridView1.Columns[20].HeaderText = "Desc9";
            dataGridView1.Columns[20].Width = 35;
        }
    }
}
