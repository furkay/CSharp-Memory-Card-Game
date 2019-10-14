using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KartOyunu
{
    public partial class Form1 : Form
    {
        Image[] images = {
            Properties.Resources.C1,
            Properties.Resources.C2,
            Properties.Resources.C3,
            Properties.Resources.C4,
            Properties.Resources.C5,
            Properties.Resources.C6,
            Properties.Resources.C7,
            Properties.Resources.C8
        };

        int[] indexes = {0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7};
        PictureBox fBox;
        int fIndex,counter,ta;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            imageShake();



        }

        private void imageShake()
        {
            Random rnd = new Random();
            for (int i=0;  i<16; i++ )
            {
                int num = rnd.Next(16);
                int tmp = indexes[i];
                indexes[i] = indexes[num];
                indexes[num] = tmp;


            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            int boxNum =int.Parse(box.Name.Substring(10));
            int indexNum = indexes[boxNum-1];
            box.Image= images[indexNum];
            box.Refresh();
            if (fBox==null)
            {
                fBox = box;
                fIndex = indexNum;
                
                ta++;

            }
            else
            {
                System.Threading.Thread.Sleep(1000);

                fBox.Image = null;
                box .Image = null;
                if (fIndex == indexNum && boxNum!=int.Parse(fBox.Name.Substring(10)))
                {
                    counter++;
                    fBox.Visible = false;
                    box.Visible = false;

                    if (counter == 8)
                    {


                        MessageBox.Show("Tebriklerrr   " +ta+" denemede buldunuz.");
                        counter = 0;
                        ta=0;

                        foreach (Control control in Controls)
                        {
                            control.Visible = true;

                        }
                        imageShake();


                    }
                }
                fBox = null;
    

            }
        }

      
    }
}
