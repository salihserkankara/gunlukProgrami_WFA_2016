using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace demo
{
    public partial class Form1 : Form
    {
        private void veri_oku()
        {
            OleDbCommand veri = new OleDbCommand("select * from gunluk order by id", baglanti);
            OleDbDataReader oku = null;
            baglanti.Open();
            oku = veri.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem kayit = new ListViewItem(oku["id"].ToString());
                kayit.SubItems.Add(oku["tarih"].ToString());
                listView1.Items.Add(kayit);
            }
            oku.Close();
            baglanti.Close();
        }
        Font a = new Font("arial", 11);

        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veritabani.accdb");
        OleDbCommand komut = new OleDbCommand();

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            veri_oku();
            a = richTextBox1.Font;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text.Trim() != "" && dateTimePicker1.Text.Trim() != "")
            {
                string yazi = richTextBox1.Text.Trim();
                string tarih = dateTimePicker1.Text.Trim();
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "INSERT INTO gunluk(yazi, tarih) VALUES('" + yazi + "','" + tarih + "')";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                veri_oku();
                MessageBox.Show("Günlük Yazınız Başarıyla Eklenmiştir.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName);
            }
            richTextBox1.Focus();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
            richTextBox1.Focus();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = a;
            richTextBox1.ForeColor = Color.Black;
            richTextBox1.Focus();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.SelectionFont;
            if(fontDialog1.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
            richTextBox1.Focus();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = richTextBox1.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
            richTextBox1.Focus();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionBullet = !richTextBox1.SelectionBullet;
            richTextBox1.Focus();
        }

        private void solahizalabtn_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox1.Focus();
        }

        private void sagahizalabtn_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox1.Focus();
        }

        private void ortalabtn_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.Focus();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionIndent > 9) richTextBox1.SelectionIndent -= 10;
            else if (richTextBox1.SelectionIndent < 0) richTextBox1.SelectionIndent = 0;
            richTextBox1.Focus();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionIndent < 41) richTextBox1.SelectionIndent += 10;
            else if (richTextBox1.SelectionIndent < 50) richTextBox1.SelectionIndent = 50;
            richTextBox1.Focus();
        }
        int id = 0;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                OleDbCommand veri = new OleDbCommand("select yazi from gunluk where tarih='" + listView1.SelectedItems[0].SubItems[1].Text + "' and id=" + id + "", baglanti);
                OleDbDataReader oku = null;
                baglanti.Open();
                oku = veri.ExecuteReader();
                while (oku.Read())
                {
                    richTextBox1.Text = oku.GetString(0).ToString();
                }
                oku.Close();
                baglanti.Close();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a;
                a = int.Parse(listView1.SelectedItems[0].Text);
                OleDbCommand sil = new OleDbCommand("delete from gunluk where id =" + a + "", baglanti);
                baglanti.Open();
                sil.ExecuteNonQuery();
                baglanti.Close();
                veri_oku();
                MessageBox.Show("Silme İşlemi Başarılı");
            }
            catch
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Kayıtı Üstteki Tablodan Seçiniz");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Regular);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Bold);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Italic)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Regular);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Italic);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Underline)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Regular);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Underline);
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionFont.Strikeout)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Regular);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Strikeout);
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim() != "" && dateTimePicker1.Text.Trim() != "")
            {
                string yazi = richTextBox1.Text.Trim();
                string tarih = dateTimePicker1.Text.Trim();
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "INSERT INTO gunluk(yazi, tarih) VALUES('" + yazi + "','" + tarih + "')";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                veri_oku();
                MessageBox.Show("Günlük Yazınız Başarıyla Eklenmiştir.");
            }
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {

        }

        private void raporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rapor rpr = new rapor();
            rpr.ShowDialog();
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yardim yrdm = new yardim();
            yrdm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand guncelle = new OleDbCommand("update gunluk set yazi='" + richTextBox1.Text + "',tarih='" + dateTimePicker1.Text + "' where id=" + id + "", baglanti);
                baglanti.Open();
                guncelle.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme Başarılı..");
            }
            catch
            {
                MessageBox.Show("Güncelleme Başarısız!!");
            }

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
