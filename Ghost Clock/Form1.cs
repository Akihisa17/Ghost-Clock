using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ghost_Clock
{
    public partial class Form1 : Form
    {
        //store gradient themes
        List<Dictionary<string, Color>> templates = new List<Dictionary<string, Color>>();


        public Form1()
        {
            InitializeComponent();


            this.FormBorderStyle = FormBorderStyle.None;


            //lets add some templates
            Dictionary<string, Color> template = new Dictionary<string, Color>();
            this.Opacity = 0.9;
            template.Add("bottomleft", Color.FromArgb(0, 0, 0));
            template.Add("bottomright", Color.FromArgb(0, 0, 0));
            template.Add("topleft", Color.FromArgb(64, 64, 64));
            template.Add("topright", Color.FromArgb(64, 64, 64));

            templates.Add(template);

            template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.FromArgb(0, 0, 0));
            template.Add("bottomright", Color.FromArgb(0, 0, 0));
            template.Add("topleft", Color.FromArgb(64, 64, 64));
            template.Add("topright", Color.FromArgb(64, 64, 64));

            templates.Add(template);
        }
        public void load_theme(Dictionary<string, Color> theme)
        {
            this.Opacity = 0.7;
            bunifuGradientPanel1.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel1.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel1.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel1.GradientTopRight = theme["topright"];

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int step = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {

            switch (step)
            {
                case 0:
                //this.Enabled = false;
                //timer1.Interval = 2000;
                //break;

                case 1:
                    label1.Text = "Ghost Clock is preparing...10%";
                    break;

                case 2:
                    label1.Text = "Ghost Clock is preparing...40% ";
                    break;

                case 3:
                    label1.Text = "Ghost Clock is preparing...75%";
                    break;

                case 4:
                    label1.Text = "Ghost Clock is preparing...100%";
                    break;

                case 7:
                    this.Hide();

                    Form2 form2 = new Form2();
                    form2.Show();
                    break;
            }
            step++;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //My Github
            {
                System.Diagnostics.Process.Start("https://github.com/Akihisa17");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //My Twitter
            {
                System.Diagnostics.Process.Start("https://twitter.com/Reiyo37");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //My Google 
            {
                System.Diagnostics.Process.Start("https://plus.google.com/115893377135438113894");
            }
        }
    }

}

