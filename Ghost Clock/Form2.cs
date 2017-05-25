using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ghost_Clock
{
    public partial class Form2 : Form
    {

        //store gradient themes
        List<Dictionary<string, Color>> templates = new List<Dictionary<string, Color>>();

        public Form2()
        {
            InitializeComponent();


            this.Opacity = 0.9;
            loader.Dock = DockStyle.Fill;
           
            //lets add some templates
            Dictionary<string, Color> template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.FromArgb(52, 52, 52));
            template.Add("bottomright", Color.FromArgb(32, 32, 32));
            template.Add("topleft", Color.FromArgb(32, 32, 32));
            template.Add("topright", Color.FromArgb(32, 32, 32));

            templates.Add(template);

            template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.FromArgb(52, 52, 52));
            template.Add("bottomright", Color.FromArgb(32, 32, 32));
            template.Add("topleft", Color.FromArgb(32, 32, 32));
            template.Add("topright", Color.FromArgb(32, 32, 32));

            templates.Add(template);

            //init fist theme
            load_theme(templates[cur_template]);
        }

        public void load_theme(Dictionary<string, Color> theme)
        {
            this.Opacity = 0.9;

            bunifuGradientPanel1.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel1.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel1.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel1.GradientTopRight = theme["topright"];
            
            loader.Visible = true;
            hideloader.Start();

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.9;
            timer1.Start();

           
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //Themes
            loader.Dock = DockStyle.Fill;
            Random r = new Random();
            //lets add awsome templates
            Dictionary<string, Color> template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.FromArgb(r.Next(0, 255), r.Next(0, 225), r.Next(0, 255)));
            template.Add("bottomright", Color.FromArgb(r.Next(0, 255), r.Next(0, 225), r.Next(0, 255)));
            template.Add("topleft", Color.FromArgb(r.Next(0, 255), r.Next(0, 225), r.Next(0, 255)));
            template.Add("topright", Color.FromArgb(r.Next(0, 255), r.Next(0, 225), r.Next(0, 255)));

            load_theme(template);
            hideloader.Start();

            //safe theme
            templates.Add(template);

            if (panel1.Height == 257 & panel1.Width == 202)
            {
                panel1.Height = 257;

                panel1.Width = 0;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh");
            label2.Text = DateTime.Now.ToString("mm");
            label4.Text = DateTime.Now.ToString("ss");
            label6.Text = DateTime.Now.ToString("tt");
            label7.Text = DateTime.Now.ToString("ddd ,");
            label8.Text = DateTime.Now.ToString("dd MMM yyyy");

        }

        private void hideloader_Tick(object sender, EventArgs e)
        {
            hideloader.Stop();
            loader.Visible = false;
           
            this.Opacity = 0.9;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Close
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            if (panel1.Width==0)
            {

                //Expand
                //Expand the panel , w = 202

                panel1.Visible = false;
                panel1.Width = 202;
                animator1.ShowSync(panel1);
                
            }

            else

            {
                //Minimize
                //Using the Animator
                //Slide the panel, w = 0

                panel1.Visible = false;
                panel1.Width = 0;
                animator1.ShowSync(panel1);
            }


          
           
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            if (panel1.Height == 257 & panel1.Width == 202)
            {
                panel1.Height = 257;

                panel1.Width = 0;

            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            //About

            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            //Support
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            //Updates

            UpdateCheckInfo info;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                try
                {
                    info = ad.CheckForDetailedUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application can't be download at this time. \n\n Please check your network connection or try again later. Error:" + dde.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Can't check for a new version of the application. The ClickOne deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application can't be updated. Its likely not ClickOne application. Error:" + ioe.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    if (MessageBox.Show("A newer version is available. Would you like to update now?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        try
                        {
                            ad.Update();
                            Application.Restart();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
            else
                MessageBox.Show("You are running the latest version.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            {
                Form4 form4 = new Form4();
                form4.ShowDialog();

            }



        }

        int cur_template = 0;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //Default Theme
            load_theme(templates[cur_template]);

            if (panel1.Height == 257 & panel1.Width == 202)
            {
                panel1.Height = 257;

                panel1.Width = 0;

            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            //Minimize
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
