using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ArtemisAssignments;




namespace ArtemisAssignments
{
    public partial class Crew : Form
    {
        Assignments crewassignments;

        public Crew()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                playSound("add.wav");
                lstNames.Items.Add(txtName.Text);
                txtName.Text = "";
                txtName.Focus();
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lstNames.SelectedIndex >= 0)
            {
                playSound("delete.wav");
                lstNames.Items.RemoveAt(lstNames.SelectedIndex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void playSound(string SoundName)
        {
            SoundPlayer simpleSound = new SoundPlayer(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\DATA\SOUNDS\" + SoundName);
            simpleSound.Play();
        }

        private void cmdGetAssignments_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //add items to a list string
            string[] players;
            players = new string[lstNames.Items.Count];
            for (int i = 0; i <= lstNames.Items.Count - 1; i++)
            {
                players[i] = lstNames.Items[i].ToString();
            }

            string[] shuffle = RandomStringArrayTool.RandomizeStrings(players);
            //assign the shuffled results
            
           crewassignments = new Assignments();
            for (int i = 0; i <= lstNames.Items.Count - 1; i++)
            {
               
                switch(i) {
                    case 0:
                        crewassignments.Captain = shuffle[i];
                        break;
                    case 1:
                        crewassignments.Comms = shuffle[i];
                        break;
                    case 2:
                        crewassignments.Helm = shuffle[i];
                        break;
                    case 3:
                        crewassignments.Weapons = shuffle[i];
                        break;
                    case 4:
                        crewassignments.Engineering = shuffle[i];
                        break;
                    case 5:
                        crewassignments.Science  = shuffle[i];
                        break;   
                }  
            }
             playSound("complete.wav");
            crewassignments.Show();
        }

     

    }
    static class RandomStringArrayTool
    {
        static Random _random = new Random();

        public static string[] RandomizeStrings(string[] arr)
        {
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            // Add all strings from array
            // Add new random int each time
            foreach (string s in arr)
            {
                list.Add(new KeyValuePair<int, string>(_random.Next(), s));
            }
            // Sort the list by the random number
            var sorted = from item in list
                         orderby item.Key
                         select item;
            // Allocate new string array
            string[] result = new string[arr.Length];
            // Copy values to array
            int index = 0;
            foreach (KeyValuePair<int, string> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }
            // Return copied array
            return result;
        }
    }
}

