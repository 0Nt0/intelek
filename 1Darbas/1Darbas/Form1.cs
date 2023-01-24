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
using System.IO;
using System.Collections;

namespace _1Darbas
{
    public partial class Form1 : Form
    {
        
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Intelektikos1;Integrated Security=True");
        ArrayList array = new ArrayList();
        ArrayList array2 = new ArrayList();
        ArrayList array3 = new ArrayList();
        ArrayList array4 = new ArrayList();
        ArrayList simbArray = new ArrayList();
        ArrayList simbArray3 = new ArrayList();
        ArrayList simbArray2 = new ArrayList();
        ArrayList simbArray4 = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            int pl = 0, mn = 0, nan = 0;
            int pl2 = 0, mn2 = 0, nan2 = 0;

            string e7x1=textBox3.Text, e8x1=textBox4.Text, e7x2=textBox5.Text, e8x2=textBox6.Text;
            int k = Convert.ToInt32(textBox1.Text);
            if(String.IsNullOrEmpty(e7x1)||String.IsNullOrWhiteSpace(e7x1)||String.IsNullOrWhiteSpace(textBox1.Text)||String.IsNullOrEmpty(textBox1.Text) ||String.IsNullOrEmpty(e8x1) || String.IsNullOrWhiteSpace(e8x1)|| String.IsNullOrEmpty(e7x2) || String.IsNullOrWhiteSpace(e7x2)|| String.IsNullOrEmpty(e8x2) || String.IsNullOrWhiteSpace(e8x2))
            {
                MessageBox.Show("Negali būti tuščia");
            }

            con.Open();
            SqlCommand command2 = new SqlCommand("Select *  from mokymo_imtis ", con);
            SqlDataReader DataRead = command2.ExecuteReader();
            while(DataRead.Read())
            {
                array.Add(Math.Sqrt(Math.Pow(Convert.ToInt32(e7x1) - Convert.ToInt32(DataRead["x1"].ToString()),2)+Math.Pow(Convert.ToInt32(e7x2)-Convert.ToInt32(DataRead["x2"].ToString()),2)));
                Label ItemPic3 = new Label();
                ItemPic3.Width = 250;
                ItemPic3.Height = 30;
                ItemPic3.BackColor = Color.FromArgb(100, 100, 100, 100);
                ItemPic3.ForeColor = Color.FromArgb(0, 0, 0, 0);
                ItemPic3.Text = "D(e7,"+DataRead["e"].ToString()+ ")=­­­Sqrt(("+e7x1+"-"+DataRead["x1"].ToString()+")^2+("+e7x2+"-"+DataRead["x2"].ToString()+")^2)="+(Math.Sqrt(Math.Pow(Convert.ToInt32(e7x1) - Convert.ToInt32(DataRead["x1"].ToString()), 2) + Math.Pow(Convert.ToInt32(e7x2) - Convert.ToInt32(DataRead["x2"].ToString()), 2))).ToString();
                ItemPic3.TextAlign = ContentAlignment.TopLeft;
                flowLayoutPanel2.Controls.Add(ItemPic3);
            }
            DataRead.Close();

            Label ItemPic4 = new Label();
            ItemPic4.Width = 250;
            ItemPic4.Height = 30;
            ItemPic4.BackColor = Color.FromArgb(100, 100, 100, 100);
            ItemPic4.ForeColor = Color.FromArgb(0, 0, 0, 0);
            ItemPic4.Text = "       ";
            ItemPic4.TextAlign = ContentAlignment.TopLeft;
            flowLayoutPanel2.Controls.Add(ItemPic4);

            SqlDataReader DataRead2 = command2.ExecuteReader();
            while (DataRead2.Read())
            {
                array2.Add(Math.Sqrt(Math.Pow(Convert.ToInt32(e8x1) - Convert.ToInt32(DataRead2["x1"].ToString()), 2) + Math.Pow(Convert.ToInt32(e8x2) - Convert.ToInt32(DataRead2["x2"].ToString()), 2)));
                Label ItemPic5 = new Label();
                ItemPic5.Width = 250;
                ItemPic5.Height = 30;
                ItemPic5.BackColor = Color.FromArgb(100, 100, 100, 100);
                ItemPic5.ForeColor = Color.FromArgb(0, 0, 0, 0);
                ItemPic5.Text = "D(e8," + DataRead2["e"].ToString() + ")=­­­Sqrt((" + e8x1 + "-" + DataRead2["x1"].ToString() + ")^2+(" + e8x2 + "-" + DataRead2["x2"].ToString() + ")^2)=" + (Math.Sqrt(Math.Pow(Convert.ToInt32(e8x1) - Convert.ToInt32(DataRead2["x1"].ToString()), 2) + Math.Pow(Convert.ToInt32(e8x2) - Convert.ToInt32(DataRead2["x2"].ToString()), 2))).ToString();
                ItemPic5.TextAlign = ContentAlignment.TopLeft;
                flowLayoutPanel2.Controls.Add(ItemPic5);
            }
            array2.Add(Math.Sqrt(Math.Pow(Convert.ToInt32(e8x1) - Convert.ToInt32(e7x1), 2) + Math.Pow(Convert.ToInt32(e8x2) - Convert.ToInt32(e7x2), 2)));

            Label ItemPic6 = new Label();
            ItemPic6.Width = 250;
            ItemPic6.Height = 30;
            ItemPic6.BackColor = Color.FromArgb(100, 100, 100, 100);
            ItemPic6.ForeColor = Color.FromArgb(0, 0, 0, 0);
            ItemPic6.Text = "D(e8, e7)=­­­Sqrt((" + e8x1 + "-" + e7x1 + ")^2+(" + e8x2 + "-" + e7x2 + ")^2)=" + (Math.Sqrt(Math.Pow(Convert.ToInt32(e8x1) - Convert.ToInt32(e7x1), 2) + Math.Pow(Convert.ToInt32(e8x2) - Convert.ToInt32(e7x2), 2))).ToString();
            ItemPic6.TextAlign = ContentAlignment.TopLeft;
            flowLayoutPanel2.Controls.Add(ItemPic6);

            DataRead2.Close();
            array.Sort();
            array2.Sort();
            
            int counter = 0;
            foreach (double i in array)
            {
                if (counter < k)
                {
                    array3.Add(i);
                    counter++;
                }
                else break;
            }

            int counter2 = 0;
            foreach (double i in array2)
            {
                
                if (counter2 < k)
                {
                    array4.Add(i);
                    counter2++;
                }
                else break;
            }
            /////////////////////////////////////////////
            SqlCommand command3 = new SqlCommand("Select *  from mokymo_imtis ", con);
           SqlDataReader DataRead3 = command3.ExecuteReader();
            while (DataRead3.Read())
            {
               foreach(double i in array3)
                {
                    
                    if ((Math.Sqrt(Math.Pow(Convert.ToInt32(e7x1) - Convert.ToInt32(DataRead3["x1"].ToString()), 2) + Math.Pow(Convert.ToInt32(e7x2) - Convert.ToInt32(DataRead3["x2"].ToString()), 2)))==i)
                    {
                        simbArray.Add(DataRead3["class"].ToString());
                        
                    }
                }
            }
            DataRead3.Close();

            simbArray.Sort();
            ///////////////////////////////////////////////////
            int counter3 = 0;

            foreach (string i in simbArray)
            {
                if (counter3 < k)
                {
                    simbArray3.Add(i);
                    counter3++;
                }
                else break;
            }

            foreach (string i in simbArray3)
            {
                if (i == "+")
                {
                    pl++;
                }
                else if (i == "-")
                { mn++; }
                else if(i=="nan") 
                { nan++; }
            }
            if (pl > mn)
            {
                label5.Text = "e7 klasė: +";
                SqlCommand command11 = new SqlCommand("Insert mokymo_imtis( e, x1,x2, class)VALUES('e7','" + e7x1 + "','" + e7x2 + "', '+')", con);
                command11.ExecuteNonQuery();
            }
            else if (pl < mn)
            {
                label5.Text = "e7 klasė: -";
                SqlCommand command11 = new SqlCommand("Insert mokymo_imtis( e, x1,x2, class)VALUES('e7','" + e7x1 + "','" + e7x2 + "', '-')", con);
                command11.ExecuteNonQuery();
            }
            else if(pl==mn)
            {
                label5.Text = "e7 klasė: nežinoma";
                SqlCommand command11 = new SqlCommand("Insert mokymo_imtis( e, x1,x2, class)VALUES('e7','" + e7x1 + "','" + e7x2 + "', 'nan')", con);
                command11.ExecuteNonQuery();
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            int counter1_5 = 0;
            string eLt="";
              SqlCommand command4 = new SqlCommand("Select *  from mokymo_imtis ", con);
              SqlDataReader DataRead4 = command4.ExecuteReader();

              while (DataRead4.Read())
              {
                  foreach (double i in array4)
                  {
                 
                    if ((Math.Sqrt(Math.Pow(Convert.ToInt32(e8x1) - Convert.ToInt32(DataRead4["x1"].ToString()), 2) + Math.Pow(Convert.ToInt32(e8x2) - Convert.ToInt32(DataRead4["x2"].ToString()), 2))) == i && counter1_5<k && eLt!=DataRead4["e"].ToString())
                     {
                        simbArray2.Add(DataRead4["class"].ToString());
                        counter1_5++;
                        eLt = DataRead4["e"].ToString();
                     }
                  }
              }
              DataRead4.Close();

            simbArray.Sort();

            int counter4 = 0;
           
            foreach (string i in simbArray2)
            {
                if (counter4 < k)
                {
                    simbArray4.Add(i);
                    counter4++;
                }
                else break;
            }

            foreach (string i in simbArray4)
            {
               
                if (i == "+")
                {
                    pl2++;
                }
                else if (i == "-")
                { mn2++; }
                else if(i=="nan") 
                { nan2++; }
            }
          
            if (pl2 > mn2 && pl2>nan2 )
            {
                
               label14.Text = "e8 klasė: +";
               
               
            }
            else if (pl2 < mn2 && mn2> nan2 )
            {

               
                 label14.Text = "e8 klasė: -" ;

            }
            else 
            {
                
                 label14.Text = "e8 klasė: nežinoma" ;

            }
           
            

            SqlCommand command0 = new SqlCommand("Delete from mokymo_imtis where e='e7'", con);
            command0.ExecuteNonQuery();
            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("Select *  from mokymo_imtis ", con);
            SqlDataReader DataRead = command.ExecuteReader();
            while (DataRead.Read())
            {
                Label ItemPic2 = new Label();
                ItemPic2.Width = 250;
                ItemPic2.Height = 20;
                ItemPic2.BackColor = Color.FromArgb(100, 100, 100, 100);
                ItemPic2.ForeColor = Color.FromArgb(0, 0, 0, 0);
                ItemPic2.Text = DataRead["e"].ToString() + "                " + DataRead["x1"].ToString() + "                    " + DataRead["x2"].ToString() + "                   " + DataRead["class"].ToString();
                ItemPic2.TextAlign = ContentAlignment.TopLeft;

                flowLayoutPanel1.Controls.Add(ItemPic2);
            }

          

            DataRead.Close();
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
