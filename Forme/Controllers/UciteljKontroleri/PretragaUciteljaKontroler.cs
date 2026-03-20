using Domeni;
using Forme.User_controlers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Forme.Controllers.UciteljKontroleri
{
    internal class PretragaUciteljaKontroler
    {
        UCpretraziUcitelja ucPretragaUcitelja;

        internal Control CreatePretragaUcitelja()
        {
            ucPretragaUcitelja = new UCpretraziUcitelja();
            try
            {
                Komunikacija.Instance.PoveziSe();

                BindingList<Ucitelj> res = Komunikacija.Instance.VratiListuSviUcitelji();
                ucPretragaUcitelja.cbSertifikati.DataSource = Komunikacija.Instance.VratiListuSviSertifikati();
                ucPretragaUcitelja.cbSertifikati.SelectedItem = null;
                ucPretragaUcitelja.dgvUcitelji.DataSource = res;
                foreach (DataGridViewColumn col in ucPretragaUcitelja.dgvUcitelji.Columns)
                {
                    col.Visible = false;
                }
                ucPretragaUcitelja.dgvUcitelji.Columns[1].Visible = true;
                ucPretragaUcitelja.dgvUcitelji.Columns[2].Visible = true;
                ucPretragaUcitelja.dgvUcitelji.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ucPretragaUcitelja.btnPretrazi.Click += Pretraga;
                ucPretragaUcitelja.btnResetuj.Click += Resetuj;
                ucPretragaUcitelja.btnPrikazi.Click += Prikazi;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Trenutno nije moguće pretraživati učitelje!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ucPretragaUcitelja;
        }


        private void Pretraga(object sender, EventArgs e)
        {
           
            Ucitelj u = new Ucitelj();
            Sertifikat s = new Sertifikat();
            string join = "";
            string condition = "";
            if (ucPretragaUcitelja.cbSertifikati.SelectedItem != null)
            {
                s = (Sertifikat)ucPretragaUcitelja.cbSertifikati.SelectedItem;
                join += "u join Licenca l on (u.idUcitelj = l.idUcitelj) ";
                condition += $" l.idSertifikat = {s.IdSertifikata}";
            }
            else
            {
                s = null;
            }
            if (string.IsNullOrEmpty(ucPretragaUcitelja.txtIme.Text) != true && string.IsNullOrWhiteSpace(ucPretragaUcitelja.txtIme.Text) != true)
            {
                u.ImeUcitelja = ucPretragaUcitelja.txtIme.Text;
            }
            else
            {
                u.ImeUcitelja = "";
            }

            if (string.IsNullOrEmpty(ucPretragaUcitelja.txtPrezime.Text) != true && string.IsNullOrWhiteSpace(ucPretragaUcitelja.txtPrezime.Text) != true)
            {
                u.PrezimeUcitelja = ucPretragaUcitelja.txtPrezime.Text;
            }
            else
            {
                u.PrezimeUcitelja = "";
            }
            if (!condition.IsNullOrEmpty())
            {
                condition += " and ";
            }
            condition += $"imeUcitelja like '{u.ImeUcitelja}%' and prezimeUcitelja like '{u.PrezimeUcitelja}%'";
            if (string.IsNullOrEmpty(ucPretragaUcitelja.txtIme.Text) && string.IsNullOrWhiteSpace(ucPretragaUcitelja.txtIme.Text) && string.IsNullOrEmpty(ucPretragaUcitelja.txtPrezime.Text) && string.IsNullOrWhiteSpace(ucPretragaUcitelja.txtPrezime.Text))
            {
                u = null;
            }

            try
            {
                Komunikacija.Instance.PoveziSe();
                ucPretragaUcitelja.dgvUcitelji.DataSource = Komunikacija.Instance.VratiListuUcitelja(new Ucitelj() { SelectCondition = condition, Join = join });
            }
            catch (Exception)
            {

                MessageBox.Show("Trenutno nije moguće pretraživati učenika!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            

           
            foreach (DataGridViewColumn col in ucPretragaUcitelja.dgvUcitelji.Columns)
            {
                col.Visible = false;
            }
            ucPretragaUcitelja.dgvUcitelji.Columns[1].Visible = true;
            ucPretragaUcitelja.dgvUcitelji.Columns[2].Visible = true;
            ucPretragaUcitelja.dgvUcitelji.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Resetuj(object sender, EventArgs e)
        {
            try
            {
                ucPretragaUcitelja.cbSertifikati.SelectedItem = null;
                ucPretragaUcitelja.txtIme.Text = "";
                ucPretragaUcitelja.txtPrezime.Text = "";
                ucPretragaUcitelja.dgvUcitelji.DataSource = Komunikacija.Instance.VratiListuSviUcitelji();
            }
            catch (Exception)
            {
                MessageBox.Show("Greška prilikom preuzimanja podataka sa servera!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void Prikazi(object sender, EventArgs e)
        {
            try
            {
                if (ucPretragaUcitelja.dgvUcitelji.CurrentRow != null)
                {
                    MainCoordinator.Instance.ShowPrikazUcitelja((Ucitelj)ucPretragaUcitelja.dgvUcitelji.CurrentRow.DataBoundItem);
                    
                }
                else
                {
                    MessageBox.Show("Odaberite ucitelja za prikaz!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Odaberite ucitelja za prikaz!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
