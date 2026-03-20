using Domeni;
using Forme.User_controlers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers.StavkeEvidencijeKontroler
{
    internal class RadSaStavkomEvidencijeKontroler
    {
        UCradSaStavkomEvidencijeNastave ucRadSaStavkom;

        EvidencijaNastave globalnaEvidencija = new EvidencijaNastave();
        StavkaEvidencijeNastave globalnaStavka = new StavkaEvidencijeNastave();

        internal Control CreateRadSaStavkomEvidencijeNastave(EvidencijaNastave evidencija)
        {
            ucRadSaStavkom = new UCradSaStavkomEvidencijeNastave(evidencija);
            try
            {
                Komunikacija.Instance.PoveziSe();
                globalnaEvidencija = evidencija;
                ucRadSaStavkom.txtEvidencija.Text = evidencija.ToString();
                ucRadSaStavkom.txtEvidencija.Enabled = false;
                string condition = $" gu.idGrupa = {evidencija.Grupa.IdGrupe}";
                ucRadSaStavkom.cbUcenik.DataSource = Komunikacija.Instance.VratiListuUcenika(new Ucenik { SelectCondition = condition });
                Kurs k = Komunikacija.Instance.PretraziKurs(new Kurs() { IdKursa = evidencija.Grupa.Kurs.IdKursa });
                ucRadSaStavkom.cbRedniBrojCasa.DataSource = Enumerable.Range(1, Komunikacija.Instance.PretraziKurs(k).TrajanjeKursa).ToList();
                ucRadSaStavkom.dateDatum.MaxDate = DateTime.Today;

                ucRadSaStavkom.btnDodaj.Click += Dodaj;
                ucRadSaStavkom.btnOmoguciIzmenu.Click += OmoguciIzmenu;
                ucRadSaStavkom.btnPromeni.Click += Promeni;
            }
            catch (Exception)
            {
                MessageBox.Show("Trenutno nije moguće raditi sa stavkom evidencije nastave!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            

            return ucRadSaStavkom;
        }

        internal Control CreateRadSaStavkomEvidencijeNastave(StavkaEvidencijeNastave stavka)
        {
            ucRadSaStavkom = new UCradSaStavkomEvidencijeNastave(stavka);
            try
            {
                Komunikacija.Instance.PoveziSe();
                globalnaEvidencija = stavka.Evidencija;
                globalnaStavka = stavka;
                ucRadSaStavkom.txtEvidencija.Enabled = false;
                ucRadSaStavkom.txtEvidencija.Text = stavka.Evidencija.ToString();
                ucRadSaStavkom.btnOmoguciIzmenu.Visible = true;
                ucRadSaStavkom.txtKomentar.Text = stavka.Komentar;
                string condition = $" gu.idGrupa = {stavka.Evidencija.Grupa.IdGrupe}";
                ucRadSaStavkom.cbUcenik.DataSource = Komunikacija.Instance.VratiListuUcenika(new Ucenik { SelectCondition = condition });
                ucRadSaStavkom.cbUcenik.SelectedItem = stavka.Ucenik;
                Kurs k = Komunikacija.Instance.PretraziKurs(new Kurs() { IdKursa = stavka.Evidencija.Grupa.Kurs.IdKursa });
                ucRadSaStavkom.cbRedniBrojCasa.DataSource = Enumerable.Range(1, Komunikacija.Instance.PretraziKurs(k).TrajanjeKursa).ToList();
                ucRadSaStavkom.cbRedniBrojCasa.SelectedItem = stavka.RedniBrojCasa;
                ucRadSaStavkom.dateDatum.Value = stavka.DatumOdrzavanja;
                ucRadSaStavkom.chDomaci.Checked = stavka.UradjenDomaci;
                ucRadSaStavkom.chPrisustvo.Checked = stavka.Prisustvo;
                ucRadSaStavkom.btnDodaj.Visible = false;
                omoguciPolja(false);
                ucRadSaStavkom.btnObrisiStavku.Visible = true;
                ucRadSaStavkom.btnDodaj.Click += Dodaj;
                ucRadSaStavkom.btnOmoguciIzmenu.Click += OmoguciIzmenu;
                ucRadSaStavkom.btnPromeni.Click += Promeni;
                ucRadSaStavkom.btnObrisiStavku.Click += ObrisiStavku;
            }
            catch (Exception)
            {
                MessageBox.Show("Trenutno nije moguće raditi sa stavkom evidencije nastave!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            return ucRadSaStavkom;
        }

        private void ObrisiStavku(object? sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Da li ste sigurni da želite da obrišete stavku?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                globalnaStavka.ZaBrisanje = true;
                StavkaEvidencijeNastave stavka = globalnaStavka;
                stavka.ZaBrisanje = true;
                globalnaEvidencija.stavkeEvidencijeNastave.Add(stavka);
                globalnaEvidencija.stavkeEvidencijeNastave.Remove(globalnaStavka);
                MessageBox.Show("Brisanje će biti kompletirano kada potvrdite promene nad stavkama evidencije");
            }else
            {
                MessageBox.Show("OK");
            }
            
        }

        private void omoguciPolja(bool x)
        {
            ucRadSaStavkom.cbUcenik.Enabled = x;
            ucRadSaStavkom.cbRedniBrojCasa.Enabled = x;
            ucRadSaStavkom.txtKomentar.Enabled = x;
            ucRadSaStavkom.chDomaci.Enabled = x;
            ucRadSaStavkom.chPrisustvo.Enabled = x;
            ucRadSaStavkom.dateDatum.Enabled = x;

        }

        private void Dodaj(object sender, EventArgs e)
        {
            try
            {
                StavkaEvidencijeNastave stavka = new StavkaEvidencijeNastave()
                {
                    Evidencija = globalnaEvidencija,
                    Ucenik = (Ucenik)ucRadSaStavkom.cbUcenik.SelectedItem,
                    RedniBrojCasa = (int)ucRadSaStavkom.cbRedniBrojCasa.SelectedItem,
                    Prisustvo = ucRadSaStavkom.chPrisustvo.Checked,
                    UradjenDomaci = ucRadSaStavkom.chDomaci.Checked,
                    Komentar = ucRadSaStavkom.txtKomentar.Text,
                    DatumOdrzavanja = ucRadSaStavkom.dateDatum.Value,

                };
                stavka.validiraj();
                try
                {
                    stavka.ZaUbacivanje = true;
                    globalnaEvidencija.stavkeEvidencijeNastave.Add(stavka);
                    //Komunikacija.Instance.UbaciStavkuEvidencijeNastave(stavka);
                    MessageBox.Show("Stavka će biti dodata kada sačuvate promene nad svim stavkama!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void OmoguciIzmenu(object sender, EventArgs e)
        {
            ucRadSaStavkom.btnOmoguciIzmenu.Visible = false;
            ucRadSaStavkom.btnPromeni.Visible = true;
            omoguciPolja(true);
            ucRadSaStavkom.cbUcenik.Enabled = false;
        }

        private void Promeni(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                ucRadSaStavkom.txtKomentar.BackColor = SystemColors.Window;
                if (ucRadSaStavkom.txtKomentar.Text.Length < 11)
                {
                    MessageBox.Show("Komentar mora biti duzi od 10 karaktera");
                    ucRadSaStavkom.txtKomentar.BackColor = ColorTranslator.FromHtml("#d96f6f");
                }
                else
                {
                    StavkaEvidencijeNastave stavka = new StavkaEvidencijeNastave()
                    {
                        Ucenik = globalnaStavka.Ucenik,
                        Evidencija = globalnaStavka.Evidencija,
                        idStavkeEvidencije = globalnaStavka.idStavkeEvidencije,
                        Prisustvo = ucRadSaStavkom.chPrisustvo.Checked,
                        UradjenDomaci = ucRadSaStavkom.chDomaci.Checked,
                        DatumOdrzavanja = ucRadSaStavkom.dateDatum.Value,
                        Komentar = ucRadSaStavkom.txtKomentar.Text,
                        RedniBrojCasa = (int)ucRadSaStavkom.cbRedniBrojCasa.SelectedItem
                    };
                    DialogResult res = MessageBox.Show("Da li ste sigurni da zelite da zapamtite promenu?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {
                            string condition = $" idStavkaEvidencije = {stavka.idStavkeEvidencije}";
                            stavka.SelectCondition = condition;
                            stavka.ZaUpdate = true;
                            globalnaEvidencija.stavkeEvidencijeNastave.Add(stavka);
                            globalnaEvidencija.stavkeEvidencijeNastave.Remove(globalnaStavka);

                            
                            MessageBox.Show("Promene će biti sačuvane kada potvrdite promene nad svim stavkama!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("OK");
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
