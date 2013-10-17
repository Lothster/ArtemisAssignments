using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ArtemisAssignments
{
    public partial class Assignments : Form
    {

        public string Captain { get; set; }
        public string Comms { get; set; }
        public string Helm { get; set; }
        public string Weapons { get; set; }
        public string Science { get; set; }
        public string Engineering { get; set; }

        public Assignments()
        {
            InitializeComponent();
            //captain
            var pos = this.PointToScreen(lblCaptain.Location);
            pos = picCaptian.PointToClient(pos);
            lblCaptain.Parent = picCaptian;
            lblCaptain.Location = pos;
            lblCaptain.BackColor = Color.Transparent;
            lblCaptain1.Parent = picCaptian;
             pos = this.PointToScreen(lblCaptain1.Location);
            pos = picCaptian.PointToClient(pos);
            lblCaptain1.Parent = picCaptian;
            lblCaptain1.Location = pos;
            lblCaptain1.BackColor = Color.Transparent;
            //engineer
             pos = this.PointToScreen(lblEngineering.Location);
            pos = picEngineering.PointToClient(pos);
            lblEngineering.Parent = picEngineering;
            lblEngineering.Location = pos;
            lblEngineering.BackColor = Color.Transparent;
            lblEngineering1.Parent = picEngineering;
            pos = this.PointToScreen(lblEngineering1.Location);
            pos = picEngineering.PointToClient(pos);
            lblEngineering1.Parent = picEngineering;
            lblEngineering1.Location = pos;
            lblEngineering1.BackColor = Color.Transparent;
            //Helm
             pos = this.PointToScreen(lblHelm.Location);
            pos = picHelm.PointToClient(pos);
            lblHelm.Parent = picHelm;
            lblHelm.Location = pos;
            lblHelm.BackColor = Color.Transparent;
            lblHelm1.Parent = picHelm;
            pos = this.PointToScreen(lblHelm1.Location);
            pos = picHelm.PointToClient(pos);
            lblHelm1.Parent = picHelm;
            lblHelm1.Location = pos;
            lblHelm1.BackColor = Color.Transparent;
            //weapons
            pos  = this.PointToScreen(lblWeapons.Location);
            pos = picWeapons.PointToClient(pos);
            lblWeapons.Parent = picWeapons;
            lblWeapons.Location = pos;
            lblWeapons.BackColor = Color.Transparent;
            lblWeapons1.Parent = picWeapons;
            pos = this.PointToScreen(lblWeapons1.Location);
            pos = picWeapons.PointToClient(pos);
            lblWeapons1.Parent = picWeapons;
            lblWeapons1.Location = pos;
            lblWeapons1.BackColor = Color.Transparent;
            //science
            pos  = this.PointToScreen(lblScience.Location);
            pos = picScience.PointToClient(pos);
            lblScience.Parent = picScience;
            lblScience.Location = pos;
            lblScience.BackColor = Color.Transparent;
            lblScience1.Parent = picScience;
            pos = this.PointToScreen(lblScience1.Location);
            pos = picScience.PointToClient(pos);
            lblScience1.Parent = picScience;
            lblScience1.Location = pos;
            lblScience1.BackColor = Color.Transparent;
            //comms
            pos = this.PointToScreen(lblComms.Location);
            pos = picComms.PointToClient(pos);
            lblComms.Parent = picComms;
            lblComms.Location = pos;
            lblComms.BackColor = Color.Transparent;
            lblComms1.Parent = picComms;
            pos = this.PointToScreen(lblComms1.Location);
            pos = picComms.PointToClient(pos);
            lblComms1.Parent = picComms;
            lblComms1.Location = pos;
            lblComms1.BackColor = Color.Transparent;
        }

        private void Assignments_Load(object sender, EventArgs e)
        {
            lblComms.Text = Comms;
            lblHelm.Text = Helm;
            lblEngineering.Text = Engineering;
            lblScience.Text = Science;
            lblWeapons.Text = Weapons;
            lblCaptain.Text = Captain;
            picCaptian.ImageLocation = getPicture("CAPTAIN");
            picEngineering.ImageLocation = getPicture("ENG");
            picScience.ImageLocation = getPicture("SCIENCE");
            picComms.ImageLocation = getPicture("COMMS");
            picHelm.ImageLocation = getPicture("HELM");
            picWeapons.ImageLocation = getPicture("WEAPONS");

        }


        private string getPicture(string dir)
        {
            DirectoryInfo diDirectory;
            FileInfo[] fiFiles;
            int i;
            string[] filenamess;
            diDirectory = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\DATA\" + dir);
            fiFiles = diDirectory.GetFiles();
            filenamess = new string[fiFiles.Length];
            if (fiFiles != null)
            {
                for (i = 0; i < fiFiles.Length; i++)
                {
                    filenamess[i] = fiFiles[i].Name;
                }
            }

            //get random file and assign it
            string[] shuffle = RandomStringArrayTool.RandomizeStrings(filenamess);
            string results = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\DATA\" + dir + @"\" + shuffle[0];
            return  results;
        }
    }
}
