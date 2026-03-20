using Domeni;
using Forme.User_controlers;
using Forme.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers.GrupaUcenikaKontroleri
{
    internal class KreirajGrupuUcenikaKontroler
    {
        UCKreirajGrupuUčenika ucKreirajGrupuUcenika;


        List<string> sati = new List<string>() { "10:00h", "12:00h", "14:00h", "16:00h", "18:00h", "20:00h" };
        GrupaUcenika globalnaGrupa = new GrupaUcenika();
        List<string> zauzetiTermini = new List<string>();

        internal Control CreateKreirajGrupuUcenika(WorkMode mode = WorkMode.CREATE, GrupaUcenika grupa = null)
        {
            ucKreirajGrupuUcenika = new UCKreirajGrupuUčenika();
            try
            {
                Komunikacija.Instance.PoveziSe();
                zauzetiTermini = Komunikacija.Instance.VratiZauzeteTermine();
                ucKreirajGrupuUcenika.cbKursevi.DataSource = Komunikacija.Instance.VratiListuSviKursevi();
                ucKreirajGrupuUcenika.cbDani.DataSource = Enum.GetNames(typeof(Dani));
                ucKreirajGrupuUcenika.cbSati.DataSource = sati;
                ucKreirajGrupuUcenika.txtTermin.Visible = false;
                ucKreirajGrupuUcenika.btnObrisi.Visible = false;
                if (mode == WorkMode.CREATE)
                {
                    ucKreirajGrupuUcenika.btnKreiraj.Visible = true;
                    ucKreirajGrupuUcenika.btnIzmeni.Visible = false;
                    ucKreirajGrupuUcenika.txtTermin.Visible = false;
                    ucKreirajGrupuUcenika.numBrojUcenika.Visible = false;
                    ucKreirajGrupuUcenika.lblBrojUcenika.Visible = false;
                    ucKreirajGrupuUcenika.dgvUcenici.Visible = false;
                    ucKreirajGrupuUcenika.lblUcenici.Visible = false;
                    ucKreirajGrupuUcenika.btnDodajUcenika.Visible = false;
                    ucKreirajGrupuUcenika.slika.Visible = true;
                }
                else if (mode == WorkMode.UPDATE)
                {
                    ucKreirajGrupuUcenika.slika.Visible = false;
                    ucKreirajGrupuUcenika.btnKreiraj.Visible = false;
                    ucKreirajGrupuUcenika.btnOmoguciIzmene.Visible = false;
                    ucKreirajGrupuUcenika.btnIzmeni.Visible = true;
                    ucKreirajGrupuUcenika.txtTermin.Visible = false;
                    ucKreirajGrupuUcenika.cbDani.Enabled = true;
                    ucKreirajGrupuUcenika.cbSati.Enabled = true;
                    ucKreirajGrupuUcenika.numBrojUcenika.Visible = true;
                    ucKreirajGrupuUcenika.numBrojUcenika.Enabled = false;
                    ucKreirajGrupuUcenika.lblBrojUcenika.Visible = true;
                    ucKreirajGrupuUcenika.btnObrisi.Visible = true;
                    ucKreirajGrupuUcenika.btnDodajUcenika.Visible = true;
                    string condition = $" gu.idGrupa = {grupa.IdGrupe}";
                    ucKreirajGrupuUcenika.dgvUcenici.DataSource = Komunikacija.Instance.VratiListuUcenika(new Ucenik() { SelectCondition = condition });
                    foreach (DataGridViewColumn col in ucKreirajGrupuUcenika.dgvUcenici.Columns)
                    {
                        col.Visible = false;
                    }
                    ucKreirajGrupuUcenika.dgvUcenici.Columns[1].Visible = true;
                    ucKreirajGrupuUcenika.dgvUcenici.Columns[2].Visible = true;
                    ucKreirajGrupuUcenika.dgvUcenici.Columns[4].Visible = true;
                    ucKreirajGrupuUcenika.dgvUcenici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                }
                else if (mode == WorkMode.READ)
                {
                    ucKreirajGrupuUcenika.slika.Visible = false;
                    globalnaGrupa = grupa;
                    ucKreirajGrupuUcenika.cbKursevi.SelectedItem = grupa.Kurs;
                    ucKreirajGrupuUcenika.numBrojUcenika.Value = grupa.BrojUcenika;
                    ucKreirajGrupuUcenika.txtTermin.Text = grupa.Termin;
                    ucKreirajGrupuUcenika.txtOznaka.Text = grupa.OznakaGrupe;
                    ucKreirajGrupuUcenika.cbKursevi.Enabled = false;
                    ucKreirajGrupuUcenika.numBrojUcenika.Enabled = false;
                    ucKreirajGrupuUcenika.cbDani.Visible = false;
                    ucKreirajGrupuUcenika.cbSati.Visible = false;
                    ucKreirajGrupuUcenika.txtOznaka.Enabled = false;
                    ucKreirajGrupuUcenika.btnHint.Visible = false;
                    ucKreirajGrupuUcenika.btnIzmeni.Visible = false;
                    ucKreirajGrupuUcenika.btnKreiraj.Visible = false;
                    ucKreirajGrupuUcenika.btnOmoguciIzmene.Visible = true;
                    ucKreirajGrupuUcenika.txtTermin.Visible = true;
                    ucKreirajGrupuUcenika.txtTermin.Enabled = false;
                    ucKreirajGrupuUcenika.btnObrisi.Visible = false;
                    ucKreirajGrupuUcenika.numBrojUcenika.Visible = true;
                    ucKreirajGrupuUcenika.lblBrojUcenika.Visible = true;
                    ucKreirajGrupuUcenika.btnDodajUcenika.Visible = false;
                    string condition = $" gu.idGrupa = {grupa.IdGrupe}";
                    ucKreirajGrupuUcenika.dgvUcenici.DataSource = Komunikacija.Instance.VratiListuUcenika(new Ucenik() { SelectCondition = condition });
                    foreach (DataGridViewColumn col in ucKreirajGrupuUcenika.dgvUcenici.Columns)
                    {
                        col.Visible = false;
                    }
                    ucKreirajGrupuUcenika.dgvUcenici.Columns[1].Visible = true;
                    ucKreirajGrupuUcenika.dgvUcenici.Columns[2].Visible = true;
                    ucKreirajGrupuUcenika.dgvUcenici.Columns[4].Visible = true;
                    ucKreirajGrupuUcenika.dgvUcenici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                }

                ucKreirajGrupuUcenika.cbKursevi.SelectedIndexChanged += cbKursevi_SelectedIndexChanged;
                ucKreirajGrupuUcenika.cbDani.SelectedIndexChanged += cbDani_SelectedIndexChanged;
                ucKreirajGrupuUcenika.cbSati.SelectedIndexChanged += comboBox2_SelectedIndexChanged;


                ucKreirajGrupuUcenika.btnKreiraj.Click += Ubaci;
                ucKreirajGrupuUcenika.btnIzmeni.Click += Izmeni;
                ucKreirajGrupuUcenika.btnOmoguciIzmene.Click += OmoguciIzmene;
                ucKreirajGrupuUcenika.btnObrisi.Click += Obrisi;
                ucKreirajGrupuUcenika.btnDodajUcenika.Click += DodajUcenika;
                ucKreirajGrupuUcenika.btnHint.Click += Hint;

            }
            catch (Exception)
            {

                MessageBox.Show("Trenutno nije moguće kreirati grupu učenika!");
            }

            

            return ucKreirajGrupuUcenika;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucKreirajGrupuUcenika.txtOznaka.Text = formirajOznakuGrupe();
        }

        private string formirajOznakuGrupe()
        {
            if (ucKreirajGrupuUcenika.cbKursevi.SelectedItem != null && ucKreirajGrupuUcenika.cbDani.SelectedItem != null && ucKreirajGrupuUcenika.cbSati.SelectedItem != null)
            {
                return $"{((Kurs)ucKreirajGrupuUcenika.cbKursevi.SelectedItem).OznakaKursa}_{ucKreirajGrupuUcenika.cbDani.SelectedItem.ToString().Substring(0, 3)}_{ucKreirajGrupuUcenika.cbSati.SelectedItem.ToString().Substring(0, 2)}";
            }
            else
            {
                return string.Empty;
            }


        }

        private void cbKursevi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucKreirajGrupuUcenika.txtOznaka.Text = formirajOznakuGrupe();
        }

        private void cbDani_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucKreirajGrupuUcenika.txtOznaka.Text = formirajOznakuGrupe();
        }

        private void Ubaci(object sender, EventArgs e)
        {
            GrupaUcenika grupa = new GrupaUcenika()
            {
                BrojUcenika = (int)ucKreirajGrupuUcenika.numBrojUcenika.Value,
                Kurs = new Kurs
                {
                    IdKursa = ((Kurs)ucKreirajGrupuUcenika.cbKursevi.SelectedItem).IdKursa
                },
                Termin = ucKreirajGrupuUcenika.cbDani.SelectedItem + " " + ucKreirajGrupuUcenika.cbSati.SelectedItem,
                OznakaGrupe = ucKreirajGrupuUcenika.txtOznaka.Text
            };
            if (zauzetiTermini.Contains(grupa.Termin))
            {
                MessageBox.Show("Ovaj termin je vec zauzet, nije moguce kreirati grupu ucenika u tom terminu!");
                return;
            }

            try
            {
                Komunikacija.Instance.PoveziSe();
                DialogResult res = MessageBox.Show("Da li želite da kreirate grupu učenika?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    Komunikacija.Instance.KreirajGrupuUcenika(grupa);
                    zauzetiTermini = Komunikacija.Instance.VratiZauzeteTermine();
                    MessageBox.Show("Sistem je zapamtio grupu učenika!");
                    
                }
                else
                {
                    MessageBox.Show("OK");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti grupu učenika!");
            }
        }



        private void Izmeni(object sender, EventArgs e)
        {
            ucKreirajGrupuUcenika.slika.Visible = false;
            GrupaUcenika grupa = new GrupaUcenika()
            {
                BrojUcenika = (int)ucKreirajGrupuUcenika.numBrojUcenika.Value,
                Kurs = new Kurs
                {
                    IdKursa = ((Kurs)ucKreirajGrupuUcenika.cbKursevi.SelectedItem).IdKursa
                },
                Termin = ucKreirajGrupuUcenika.cbDani.SelectedItem + " " + ucKreirajGrupuUcenika.cbSati.SelectedItem,
                OznakaGrupe = ucKreirajGrupuUcenika.txtOznaka.Text,
                IdGrupe = globalnaGrupa.IdGrupe
            };
            if (zauzetiTermini.Contains(grupa.Termin))
            {
                MessageBox.Show("Ovaj termin je vec zauzet, nije moguce kreirati grupu ucenika u tom terminu!");
                return;
            }
            try
            {
                Komunikacija.Instance.PoveziSe();
                grupa.SelectCondition = $" idGrupa = {grupa.IdGrupe}";
                Komunikacija.Instance.PromeniGrupuUcenika(grupa);
                MessageBox.Show("Sistem je zapamtio grupu učenika!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti grupu učenika!");
            }

        }

        private void OmoguciIzmene(object sender, EventArgs e)
        {
            ucKreirajGrupuUcenika.btnOmoguciIzmene.Visible = false;
            ucKreirajGrupuUcenika.slika.Visible = false;
            ucKreirajGrupuUcenika.btnKreiraj.Visible = false;
            ucKreirajGrupuUcenika.btnIzmeni.Visible = true;
            ucKreirajGrupuUcenika.cbDani.Enabled = true;
            ucKreirajGrupuUcenika.cbSati.Enabled = true;
            ucKreirajGrupuUcenika.cbKursevi.Enabled = true;
            ucKreirajGrupuUcenika.numBrojUcenika.Enabled = true;
            ucKreirajGrupuUcenika.txtOznaka.Enabled = false;
            ucKreirajGrupuUcenika.btnHint.Visible = true;
            ucKreirajGrupuUcenika.btnIzmeni.Visible = true;
            ucKreirajGrupuUcenika.btnKreiraj.Visible = false;
            ucKreirajGrupuUcenika.cbDani.Visible = true;
            ucKreirajGrupuUcenika.cbSati.Visible = true;
            ucKreirajGrupuUcenika.btnObrisi.Visible = false;
            ucKreirajGrupuUcenika.txtTermin.Visible = false;
            ucKreirajGrupuUcenika.btnObrisi.Visible = true;
            ucKreirajGrupuUcenika.btnDodajUcenika.Visible = true;
            ucKreirajGrupuUcenika.numBrojUcenika.Enabled = false;
        }

        private void Obrisi(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                DialogResult res = MessageBox.Show("Da li ste sigurni da želite da obrišete grupu učenika?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    globalnaGrupa.SelectCondition = $"  idGrupa = {globalnaGrupa.IdGrupe} ";
                    Komunikacija.Instance.ObrisiGrupuUcenika(globalnaGrupa);
                    MessageBox.Show("Sistem je obrisao grupu ucenika");
                }
                else
                {
                    MessageBox.Show("Grupa nije obrisana");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Sistem ne može da obrise grupu ucenika");
            }
           
        }

       

        private void DodajUcenika(object sender, EventArgs e)
        {
            Komunikacija.Instance.PoveziSe();
            MainCoordinator.Instance.ShowPomocna(globalnaGrupa);
            string condition = $" gu.idGrupa = {globalnaGrupa.IdGrupe}";
            globalnaGrupa.Join = "gu join Kurs k on(gu.idKurs = k.idKurs)";
             globalnaGrupa= Komunikacija.Instance.PretraziGrupuUcenika(globalnaGrupa);
            ucKreirajGrupuUcenika.numBrojUcenika.Value = globalnaGrupa.BrojUcenika;
            ucKreirajGrupuUcenika.dgvUcenici.DataSource = Komunikacija.Instance.VratiListuUcenika(new Ucenik() { SelectCondition = condition });
            foreach (DataGridViewColumn col in ucKreirajGrupuUcenika.dgvUcenici.Columns)
            {
                col.Visible = false;
            }
            ucKreirajGrupuUcenika.dgvUcenici.Columns[1].Visible = true;
            ucKreirajGrupuUcenika.dgvUcenici.Columns[2].Visible = true;
            ucKreirajGrupuUcenika.dgvUcenici.Columns[4].Visible = true;
            ucKreirajGrupuUcenika.dgvUcenici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public string ispisZauzetihTermina()
        {
            List<string> dani = Enum.GetNames<Dani>().ToList();
            List<string> sveKombinacije = dani.SelectMany(dan => sati, (dan, sati) => $"{dan} {sati}").ToList();
            List<string> slobodni = sveKombinacije.Except(zauzetiTermini).ToList();
            string ispis = "\n";
            foreach (string s in slobodni)
            {
                ispis = ispis + s + "\n";
                //ispis.Concat(s + "\n");
            }
            return ispis;
        }

        private void Hint(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                zauzetiTermini = Komunikacija.Instance.VratiZauzeteTermine();
                MessageBox.Show($"Slobodni termini su {ispisZauzetihTermina()}");
                

            }
            catch (Exception)
            {

                MessageBox.Show("Greška prilikom vraćanja termina");
            }
           
        }

    }
}
