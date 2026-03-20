using Domeni;
using Forme.User_controlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers.UcenikKontroleri
{
    internal class PretragaUcenikaKontroler
    {
        UCpretraziUcenika ucPretragaUcenika;

        internal Control CreatePretraziUcenika()
        {
            ucPretragaUcenika = new UCpretraziUcenika();
            try
            {
                Komunikacija.Instance.PoveziSe();
                ucPretragaUcenika.dgvUcenici.DataSource = Komunikacija.Instance.VratiListuSviUcenici();
                foreach (DataGridViewColumn col in ucPretragaUcenika.dgvUcenici.Columns)
                {
                    col.Visible = false;
                }
                ucPretragaUcenika.dgvUcenici.Columns[1].Visible = true;
                ucPretragaUcenika.dgvUcenici.Columns[2].Visible = true;
                ucPretragaUcenika.dgvUcenici.Columns[4].Visible = true;
                ucPretragaUcenika.dgvUcenici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ucPretragaUcenika.btnPretraga.Click += Pretraga;
                ucPretragaUcenika.butnPrikaz.Click += Prikaz;

            }
            catch (Exception)
            {

                MessageBox.Show("Trenutno nije moguće pretraživati učenika!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            return ucPretragaUcenika;
        }

        private void Pretraga(object sender, EventArgs e)
        {
            Ucenik ucenik = new Ucenik();
            try
            {
                Komunikacija.Instance.PoveziSe();
                if (string.IsNullOrEmpty(ucPretragaUcenika.txtImePrezime.Text) == false)
                {

                    string[] uc = ucPretragaUcenika.txtImePrezime.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string ime = uc[0] != null ? uc[0] : "";
                    string prezime = "";
                    try
                    {
                        prezime = uc[1] != null ? uc[1] : "";
                    }
                    catch
                    {
                        prezime = "";
                    }

                    ucenik = new Ucenik
                    {
                        ImeUcenika = char.ToUpper(ime[0]) + ime.Substring(1),
                        PrezimeUcenika = prezime != "" ? char.ToUpper(prezime[0]) + prezime.Substring(1) : ""
                    };
                }
            }
            catch
            {
                ucenik = null;
            }

            if (ucenik == null)
            {
                MessageBox.Show("Greška");
            }
            else
            {
                try
                {
                    string condtion = $" imeUcenika like '{ucenik.ImeUcenika}%' and prezimeUcenika like '{ucenik.PrezimeUcenika}%'";
                    ucenik.SelectCondition = condtion;
                    ucenik.Join = "";
                    ucPretragaUcenika.dgvUcenici.DataSource = Komunikacija.Instance.VratiListuUcenika(ucenik: ucenik);
                    foreach (DataGridViewColumn col in ucPretragaUcenika.dgvUcenici.Columns)
                    {
                        col.Visible = false;
                    }
                    ucPretragaUcenika.dgvUcenici.Columns[1].Visible = true;
                    ucPretragaUcenika.dgvUcenici.Columns[2].Visible = true;
                    ucPretragaUcenika.dgvUcenici.Columns[4].Visible = true;
                    ucPretragaUcenika.dgvUcenici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception)
                {
                    MessageBox.Show("Trenutno nije moguće pretraživati učenika!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                
            }
        }

        private void Prikaz(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                if (ucPretragaUcenika.dgvUcenici.CurrentRow == null)
                {
                    MessageBox.Show("Odaberite učenika za prikaz!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                {

                    Ucenik ucenik = (Ucenik)ucPretragaUcenika.dgvUcenici.CurrentRow.DataBoundItem;
                    MainCoordinator.Instance.ShowKreiranjeUcenika(ucenik);
                }

            }
            catch
            {
                MessageBox.Show("Greska!");
            }
        }
    }
}
