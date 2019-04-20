using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Zapravka
{
    public partial class Form1 : Form
    {
        private int[] zena; 
        public Form1()
        {
            InitializeComponent();

            string[] benzins = { "A-95", "A-92", "A-76" };
            cmbBenzin.Items.AddRange(benzins);
            zena = new int[] { 25, 22, 16 };
            cmbBenzin.SelectedIndexChanged += CmbBenzin_SelectedIndexChanged;
            cmbBenzin.SelectedIndex = 0;
        }

        private void CmbBenzin_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbZena_Benzin.Text = zena[cmbBenzin.SelectedIndex].ToString();
        }

        private void rdbKol_CheckedChanged(object sender, EventArgs e)
        {
            txbLitri.Enabled = true;
            txbGrn.Enabled = false;
            txbGrn.Text = "";
        }

        private void rdbSumm_CheckedChanged(object sender, EventArgs e)
        {
            txbLitri.Enabled = false;
            txbLitri.Text = "";
            txbGrn.Enabled = true;
        }

        private void chbChotDog_CheckedChanged(object sender, EventArgs e)
        {
            if (chbChotDog.Checked == true)
            {
                txbCol_ChotDog.Enabled = true;
            }
            else
            {
                txbCol_ChotDog.Enabled = false;
                txbCol_ChotDog.Text = "";
            }
        }

        private void chbGamburger_CheckedChanged(object sender, EventArgs e)
        {
            if (chbGamburger.Checked == true)
            {
                txbCol_Gamburg.Enabled = true;
            }
            else
            {
                txbCol_Gamburg.Enabled = false;
                txbCol_Gamburg.Text = "";
            }
        }

        private void chbFri_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFri.Checked == true)
            {
                txbCol_Fri.Enabled = true;
            }
            else
            {
                txbCol_Fri.Enabled = false;
                txbCol_Fri.Text = "";
            }
        }

        private void chbKola_CheckedChanged(object sender, EventArgs e)
        {
            if (chbKola.Checked == true)
            {
                txbCol_Kola.Enabled = true;
            }
            else
            {
                txbCol_Kola.Enabled = false;
                txbCol_Kola.Text = "";
            }
        }

        private void txbLitri_TextChanged(object sender, EventArgs e)
        {
            if (txbLitri.Text != "")
            {
                lblKOplate_Avtozapr.Text = (int.Parse(txbLitri.Text) * int.Parse(txbZena_Benzin.Text)).ToString();
                lblGrnIliLitri.Text = "грн.";
            }
            else
                lblKOplate_Avtozapr.Text = "0,00";
        }

        private void txbGrn_TextChanged(object sender, EventArgs e)
        {
            if (txbGrn.Text != "")
            {
                grbKOplate_Avtozapr.Text = "К выдаче";
                lblGrnIliLitri.Text = "л.";
                double summa = (double.Parse(txbGrn.Text) / double.Parse(txbZena_Benzin.Text));
                lblKOplate_Avtozapr.Text = $"{summa:F2}";
            }
            else
                lblKOplate_Avtozapr.Text = "0,00";
        }

        private void txbCol_ChotDog_TextChanged(object sender, EventArgs e)
        {
            Poschitat_KOplate_MiniKafe();
        }

        private void txbCol_Gamburg_TextChanged(object sender, EventArgs e)
        {
            Poschitat_KOplate_MiniKafe();
        }

        private void txbCol_Fri_TextChanged(object sender, EventArgs e)
        {
            Poschitat_KOplate_MiniKafe();
        }

        private void txbCol_Kola_TextChanged(object sender, EventArgs e)
        {
            Poschitat_KOplate_MiniKafe();
        }
        private void Poschitat_KOplate_MiniKafe()
        {
            double summ = 0;
            if (txbCol_ChotDog.Text != "")
                summ += double.Parse(txbCol_ChotDog.Text) * double.Parse(txbZena_ChotDog.Text);
            if (txbCol_Gamburg.Text != "")
                summ += double.Parse(txbCol_Gamburg.Text) * double.Parse(txbZena_Gamburg.Text);
            if (txbCol_Fri.Text != "")
                summ += double.Parse(txbCol_Fri.Text) * double.Parse(txbZena_Fri.Text);
            if (txbCol_Kola.Text != "")
                summ += double.Parse(txbCol_Kola.Text) * double.Parse(txbZena_Kola.Text);
            lblKOplate_MiniKafe.Text = summ.ToString();
        }

        private void btnPoschitat_Click(object sender, EventArgs e)
        {
            double summ = double.Parse(lblKOplate_MiniKafe.Text);
            if (lblGrnIliLitri.Text == "грн.")
            {
                summ += double.Parse(lblKOplate_Avtozapr.Text);
            }
            else
            {
                summ += int.Parse(txbGrn.Text);
            }
            lblKOplate_Vsego.Text = summ.ToString();
        }
    }
}