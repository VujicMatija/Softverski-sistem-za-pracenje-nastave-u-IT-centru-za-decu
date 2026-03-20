using Domeni;
using Forme.User_controlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Forme.Controllers.UciteljKontroleri
{
    internal class PrikazUciteljaKontroler
    {

        private UCPrikazUcitelja ucPrikazUcitelja;
        private Ucitelj ucitelj;

        internal Control CreatePrikazUcitelja(Ucitelj u)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                ucitelj = u;
                ucPrikazUcitelja = new UCPrikazUcitelja(ucitelj);
                ucPrikazUcitelja.btnDodajLicencu.Click += DodajLicencu;
                ucPrikazUcitelja.btnIzmeni.Click += Izmeni;
                ucPrikazUcitelja.btnObrisi.Click += Obrisi;
                ucPrikazUcitelja.btnOmoguciIzmenu.Click += OmoguciIzmenu;
                ucitelj = Komunikacija.Instance.PretraziUcitelja(u);
                PopuniPoljaSaPodacima(ucitelj);
                ucPrikazUcitelja.dateDatumPocetka.MaxDate = DateTime.Today;


                ucPrikazUcitelja.btnDodajLicencu.Visible = false;

              
                string condition = $"l.idUcitelj = {ucitelj.Id}";
                Sertifikat sertifikat = new Sertifikat();
                sertifikat.SelectCondition = condition;
                ucPrikazUcitelja.dgvLicence.DataSource = Komunikacija.Instance.VratiListuSertifikata(sertifikat);
               
                foreach (DataGridViewColumn col in ucPrikazUcitelja.dgvLicence.Columns)
                {
                    col.Visible = false;
                }
                ucPrikazUcitelja.dgvLicence.Columns[1].Visible = true;
                ucPrikazUcitelja.dgvLicence.RowHeadersVisible = false;
                GrupaUcenika grupaUcenika = new GrupaUcenika();
                grupaUcenika.Join = $" gu join EvidencijaNastave ev on (ev.idGrupa = gu.idGrupa)  join Kurs k on(gu.idKurs = k.idKurs) ";
                grupaUcenika.SelectCondition = $" idUcitelja = {ucitelj.Id}";
                ucPrikazUcitelja.dgvGrupe.DataSource = Komunikacija.Instance.vratiListuGrupaUcenika(grupaUcenika);
                foreach (DataGridViewColumn col in ucPrikazUcitelja.dgvGrupe.Columns)
                {
                    col.Visible = false;
                }
                ucPrikazUcitelja.dgvGrupe.Columns[1].Visible = true;
                ucPrikazUcitelja.dgvGrupe.RowHeadersVisible = false;
                ucPrikazUcitelja.dgvGrupe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ucPrikazUcitelja.dgvLicence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ucPrikazUcitelja.btnObrisi.Visible = false;
            }
            catch (Exception)
            {

                MessageBox.Show("Trenutno nije moguće prikazati učitelja!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            return ucPrikazUcitelja;
        }

        private void OmoguciIzmenu(object sender, EventArgs e)
        {
            ucPrikazUcitelja.btnIzmeni.Visible = true;
            ucPrikazUcitelja.btnOmoguciIzmenu.Visible = false;
            ucPrikazUcitelja.btnDodajLicencu.Visible = true;
            ucPrikazUcitelja.btnObrisi.Visible = true;
            enejbul(true);
        }


        private void Izmeni(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                RestartujTextBoxove();
                Ucitelj novi = new Ucitelj()
                {
                    Id = ucitelj.Id,
                    ImeUcitelja = ucPrikazUcitelja.txtIme.Text,
                    PrezimeUcitelja = ucPrikazUcitelja.txtPrezime.Text,
                    Email = ucPrikazUcitelja.txtEmail.Text,
                    DatumPocetkaRada = ucPrikazUcitelja.dateDatumPocetka.Value,
                    Telefon = ucPrikazUcitelja.txtTelefon.Text,
                    Lozinka = ucitelj.Lozinka,
                    KorisnickoIme = ucitelj.KorisnickoIme

                };
                if (ValidirajUcitelja())
                {
                    try
                    {
                        DialogResult res = MessageBox.Show("Da li ste sigurni da želite da promenite učitelja?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            novi.SelectCondition = $" idUcitelj = {novi.Id}";
                            Komunikacija.Instance.promeniUcitelja(novi);
                            MessageBox.Show("Promene su sacuvane!");
                            PopuniPoljaSaPodacima(novi);
                        }
                        else
                        {
                            MessageBox.Show("OK");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Trenutno nije moguće izmeniti učitelja!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DodajLicencu(object sender, EventArgs e)
        {
            MainCoordinator.Instance.ShowDodajLicencuForma(ucitelj);
            try
            {
                Komunikacija.Instance.PoveziSe();
                string condition = $"l.idUcitelj = {ucitelj.Id}";
                Sertifikat sertifikat = new Sertifikat();
                sertifikat.SelectCondition = condition;
                BindingList<Sertifikat> uciteljeviSertifikati = Komunikacija.Instance.VratiListuSertifikata(sertifikat);
                ucPrikazUcitelja.dgvLicence.DataSource = uciteljeviSertifikati;
                foreach (DataGridViewColumn col in ucPrikazUcitelja.dgvLicence.Columns)
                {
                    col.Visible = false;
                }
                ucPrikazUcitelja.dgvLicence.Columns[1].Visible = true;
                ucPrikazUcitelja.dgvLicence.RowHeadersVisible = false;
                ucPrikazUcitelja.dgvLicence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception)
            {

                MessageBox.Show("Trenutno nije moguće dodati licencu!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void Obrisi(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                DialogResult res = MessageBox.Show("Da li ste sigurni da želite da obrišete učitelja?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    ucitelj.SelectCondition = $"idUcitelj = {ucitelj.Id}";
                    Komunikacija.Instance.obrisiUcitelja(ucitelj);
                    MessageBox.Show("Obrisano!");
                }
                else
                {
                    MessageBox.Show("OK");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom brisanja!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PopuniPoljaSaPodacima(Ucitelj ucitelj)
        {
            ucPrikazUcitelja.txtIme.Text = ucitelj.ImeUcitelja;
            ucPrikazUcitelja.txtPrezime.Text = ucitelj.PrezimeUcitelja;
            ucPrikazUcitelja.txtTelefon.Text = ucitelj.Telefon;
            ucPrikazUcitelja.txtEmail.Text = ucitelj.Email;
            ucPrikazUcitelja.dateDatumPocetka.Value = ucitelj.DatumPocetkaRada;
            ucPrikazUcitelja.btnDodajLicencu.Visible = false;
            ucPrikazUcitelja.btnIzmeni.Visible = false;
            enejbul(false);
        }

        private void enejbul(bool x)
        {
            ucPrikazUcitelja.txtIme.Enabled = x;
            ucPrikazUcitelja.txtPrezime.Enabled = x;
            ucPrikazUcitelja.txtEmail.Enabled = x;
            ucPrikazUcitelja.txtTelefon.Enabled = x;
            ucPrikazUcitelja.dateDatumPocetka.Enabled = x;
        }

        private void RestartujTextBoxove()
        {
            ucPrikazUcitelja.txtIme.BackColor = SystemColors.Window;
            ucPrikazUcitelja.txtPrezime.BackColor = SystemColors.Window;
            ucPrikazUcitelja.txtEmail.BackColor = SystemColors.Window;
            ucPrikazUcitelja.txtTelefon.BackColor = SystemColors.Window;

        }


        internal bool ValidirajUcitelja()
        {
            Color boja = ColorTranslator.FromHtml("#d96f6f");
            bool uspesno = true;
            string poruka = "";
            if (ucPrikazUcitelja.txtIme.Text.Length < 3)
            {
                ucPrikazUcitelja.txtIme.BackColor = boja;
                poruka = poruka + "Ime mora imati vise od 2 slova!\n";
            }
            if (ucPrikazUcitelja.txtPrezime.Text.Length < 3)
            {
                ucPrikazUcitelja.txtPrezime.BackColor = boja;
                poruka = poruka + "Prezime mora imati vise od 2 slova!\n";
            }
            if (ucPrikazUcitelja.txtEmail.Text.Contains("@") == false || ucPrikazUcitelja.txtEmail.Text.Contains(".com") == false)
            {
                ucPrikazUcitelja.txtEmail.BackColor = boja;
                poruka = poruka + "Email mora da sadrzi @ i .com\n";
            }
            if (ucPrikazUcitelja.txtTelefon.Text.Length > 3 && ucPrikazUcitelja.txtTelefon.Text.Substring(0, 2) != "06")
            {
                poruka = poruka + "Broj telefona mora da pocinenje sa 06!\n";
                ucPrikazUcitelja.txtTelefon.BackColor = boja;
            }
            else if (ucPrikazUcitelja.txtTelefon.Text.Length < 3)
            {
                poruka = poruka + "Broj telefona mora da pocinenje sa 06!\n";
                ucPrikazUcitelja.txtTelefon.BackColor = boja;
            }

            if (string.IsNullOrEmpty(poruka) == false)
            {
                uspesno = false;
                MessageBox.Show("Neuspesna validacija podataka\n" + poruka);
            }
            return uspesno;
        }

    }
}
