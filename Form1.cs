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
namespace DataGridViewVeriSilmeVeKaydetme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan=new SqlConnection("Data Source=IRFAN\\SQLEXPRESS;Initial Catalog=Kitaplar;Integrated Security=True");
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da= new SqlDataAdapter(veriler,baglan);
            DataSet ds=new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {

            verilerigoster("Select *from kitapbilgi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into kitapbilgi (kitapad,kitapyazar,basimevi,sayfa) Values(@adi,@yazari,@basimyeri,@sayfasi)", baglan);
            komut.Parameters.AddWithValue("@adi", textBox1.Text);
            komut.Parameters.AddWithValue("@yazari", textBox2.Text);
            komut.Parameters.AddWithValue("@basimyeri", textBox3.Text);
            komut.Parameters.AddWithValue("@sayfasi", textBox4.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster("Select *from kitapbilgi");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from kitapbilgi where kitapad=@adi", baglan);
            komut.Parameters.AddWithValue("@adi", textBox5.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster("Select *from kitapbilgi");
        }
    }
}
