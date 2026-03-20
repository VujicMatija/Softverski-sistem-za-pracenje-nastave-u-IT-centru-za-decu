using Domeni;
using Forme.User_controlers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers.EvidencijaNastaveKontroleri
{
    internal class KreirajEvidencijuNastaveKontroler
    {
        UCRadSaEvidencijomNastave ucKreirajEvidencijuNastave;

        BindingList<StavkaEvidencijeNastave> stavke = new BindingList<StavkaEvidencijeNastave>();

        internal Control CreateKreirajEvidencijuNastave()
        {
            ucKreirajEvidencijuNastave = new UCRadSaEvidencijomNastave();

            ucKreirajEvidencijuNastave.dateDatumStavke.MaxDate = DateTime.Today;
            ucKreirajEvidencijuNastave.datePocetakRada.MaxDate = DateTime.Today;

            ucKreirajEvidencijuNastave.cbGrupa.MouseWheel += (s, e) =>
            {
                ((HandledMouseEventArgs)e).Handled = true;
            };

            ucKreirajEvidencijuNastave.cbRBCasa.MouseWheel += (s, e) =>
            {
                ((HandledMouseEventArgs)e).Handled = true;
            };

            ucKreirajEvidencijuNastave.cbUcenici.MouseWheel += (s, e) =>
            {
                ((HandledMouseEventArgs)e).Handled = true;
            };

            ucKreirajEvidencijuNastave.cbUcitelj.MouseWheel += (s, e) =>
            {
                ((HandledMouseEventArgs)e).Handled = true;
            };
            stavke.Clear();

            try
            {
                BindingList<Ucitelj> sviUcitelji = new BindingList<Ucitelj>();
                Komunikacija.Instance.PoveziSe();
                sviUcitelji = Komunikacija.Instance.VratiListuSviUcitelji();





                ucKreirajEvidencijuNastave.cbUcitelj.DataSource = sviUcitelji;
                ucKreirajEvidencijuNastave.cbUcitelj.SelectedItem = null;
                BindingList<GrupaUcenika> dostupneGrupeUcenika = VratiSlobodneGrupe();
                ucKreirajEvidencijuNastave.cbGrupa.DataSource = dostupneGrupeUcenika;
                if (dostupneGrupeUcenika.IsNullOrEmpty())
                {
                    MessageBox.Show("Nema slobodnih grupa!");
                }
                ucKreirajEvidencijuNastave.cbGrupa.SelectedItem = null;
                ucKreirajEvidencijuNastave.cbUcenici.DataSource = null;
                ucKreirajEvidencijuNastave.cbRBCasa.DataSource = null;
                ucKreirajEvidencijuNastave.dgvStavke.DataSource = stavke;
                SrediDGV();
                ucKreirajEvidencijuNastave.dgvStavke.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ucKreirajEvidencijuNastave.btnDodajStavku.Click += DodajStavku;
                ucKreirajEvidencijuNastave.btnKreiraj.Click += Kreiraj;
                ucKreirajEvidencijuNastave.cbGrupa.SelectedIndexChanged += cbGrupa_SelectedIndexChanged;
                ucKreirajEvidencijuNastave.cbGrupa.SelectionChangeCommitted += cbGrupa_SelectionChangeCommitted;
                ucKreirajEvidencijuNastave.cbGrupa.DropDown += cbGrupa_DropDown;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Trenutno nije moguće kreirati evidenciju nastave!");
            }
           

            return ucKreirajEvidencijuNastave;
        }

        

        private void Kreiraj(object sender, EventArgs e)
        {
            if (ucKreirajEvidencijuNastave.cbGrupa.SelectedItem == null || ucKreirajEvidencijuNastave.cbUcitelj.SelectedItem == null)
            {
                MessageBox.Show("Morate popuniti sva polja!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                EvidencijaNastave unos = new EvidencijaNastave
                {
                    StatusAktivnosti = ucKreirajEvidencijuNastave.chAktivna.Checked,
                    Ucitelj = (Ucitelj)ucKreirajEvidencijuNastave.cbUcitelj.SelectedItem,
                    Grupa = (GrupaUcenika)ucKreirajEvidencijuNastave.cbGrupa.SelectedItem,
                    DatumPocetkaRada = ucKreirajEvidencijuNastave.datePocetakRada.Value

                };

                DialogResult res = MessageBox.Show("Da li ste sigurni da zelite da kreirate evidenciju nastave?", "Potvrda", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        unos.stavkeEvidencijeNastave = stavke.ToList();
                        Komunikacija.Instance.PoveziSe();
                        Komunikacija.Instance.KreirajEvidencijuNastave(unos);
                        MessageBox.Show("Sistem je kreirao i zapamtio evidenciju nastave.");
                        resetujFormu();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sistem ne može da kreira i zapamti evidenciju nastave!");
                    }
                }
                else
                {
                    MessageBox.Show("OK!");
                }

            }
        }

       


        private void cbGrupa_SelectionChangeCommitted(object sender, EventArgs e)
        {


            if (stavke.IsNullOrEmpty() == false)
            {
                DialogResult res = MessageBox.Show("Da li ste sigurni da zelite da promenite grupu? Trenutno unete stavke ce biti ponistene!", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    try
                    {
                        ucKreirajEvidencijuNastave.cbGrupa.SelectedIndex = trenutniIndex;
                        //string join = " u join UcenikGrupa ug on (u.idUcenik = ug.idUcenik) join GrupaUcenika gu on (gu.idGrupa = ug.idGrupaUcenika) ";
                        string condition = $" gu.idGrupa = {trenutnaGrupa.IdGrupe}";
                        Komunikacija.Instance.PoveziSe();
                        ucKreirajEvidencijuNastave.cbUcenici.DataSource = Komunikacija.Instance.VratiListuUcenika(new Ucenik() { SelectCondition = condition});
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška prilikom rada sa serverom!");
                    }

                }
                else
                {
                    stavke.Clear();
                }
            }

        }

        private void cbGrupa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ucKreirajEvidencijuNastave.cbGrupa.SelectedItem != null)
                {

                    if (stavke.Count == 0)
                    {
                        GrupaUcenika novaGrupa = (GrupaUcenika)ucKreirajEvidencijuNastave.cbGrupa.SelectedItem;
                        string condition = $" gu.idGrupa = {novaGrupa.IdGrupe}";
                        Komunikacija.Instance.PoveziSe();
                        ucKreirajEvidencijuNastave.cbUcenici.DataSource = Komunikacija.instance.VratiListuUcenika(new Ucenik() { SelectCondition = condition });
                        Kurs k = Komunikacija.Instance.PretraziKurs(new Kurs() { IdKursa = novaGrupa.Kurs.IdKursa });
                        ucKreirajEvidencijuNastave.cbRBCasa.DataSource = Enumerable.Range(1, Komunikacija.Instance.PretraziKurs(k).TrajanjeKursa).ToList();
                    }
                    else
                    {
                        if (trenutniIndex >= 0)
                        {
                            ucKreirajEvidencijuNastave.cbGrupa.SelectedIndex = trenutniIndex;
                            ucKreirajEvidencijuNastave.cbGrupa.SelectedItem = trenutnaGrupa;
                            string condition = $" gu.idGrupa = {trenutnaGrupa.IdGrupe}";
                            Komunikacija.Instance.PoveziSe();
                            ucKreirajEvidencijuNastave.cbUcenici.DataSource = Komunikacija.instance.VratiListuUcenika(new Ucenik() { SelectCondition = condition });
                            Kurs k = Komunikacija.instance.PretraziKurs(new Kurs() { IdKursa = trenutnaGrupa.Kurs.IdKursa });
                            ucKreirajEvidencijuNastave.cbRBCasa.DataSource = Enumerable.Range(1, k.TrajanjeKursa).ToList();
                        }


                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greška prilikom rada sa serverom!");
            }
          

        }

        private void DodajStavku(object sender, EventArgs e)
        {
            ucKreirajEvidencijuNastave.txtKomentar.BackColor = SystemColors.Window;
            try
            {
                if (ucKreirajEvidencijuNastave.txtKomentar.Text.Length < 11)
                {
                    MessageBox.Show("Komentar mora biti duzi od 10 karaktera");
                    ucKreirajEvidencijuNastave.txtKomentar.BackColor = ColorTranslator.FromHtml("#d96f6f");
                }
                else
                {
                    StavkaEvidencijeNastave stavka = new StavkaEvidencijeNastave()
                    {
                        Prisustvo = ucKreirajEvidencijuNastave.chPrisustvo.Checked,
                        Komentar = ucKreirajEvidencijuNastave.txtKomentar.Text,
                        DatumOdrzavanja = ucKreirajEvidencijuNastave.dateDatumStavke.Value,
                        UradjenDomaci = ucKreirajEvidencijuNastave.chDomaci.Checked,
                        RedniBrojCasa = (int)ucKreirajEvidencijuNastave.cbRBCasa.SelectedItem,
                        Ucenik = (Ucenik)ucKreirajEvidencijuNastave.cbUcenici.SelectedItem
                    };
                    stavke.Add(stavka);
                    resetujStavku();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unos stavke neuspesan, probajte ponovo!");
            }


        }


        int trenutniIndex = 0;
        GrupaUcenika trenutnaGrupa;
        private void cbGrupa_DropDown(object sender, EventArgs e)
        {
            trenutniIndex = ucKreirajEvidencijuNastave.cbGrupa.SelectedIndex;
            trenutnaGrupa = (GrupaUcenika)ucKreirajEvidencijuNastave.cbGrupa.SelectedItem;
        }

        private void resetujStavku()
        {
            ucKreirajEvidencijuNastave.txtKomentar.Text = "";
            ucKreirajEvidencijuNastave.cbUcenici.SelectedIndex = -1;
            ucKreirajEvidencijuNastave.cbRBCasa.SelectedIndex = 0;
            ucKreirajEvidencijuNastave.chPrisustvo.Checked = false;
            ucKreirajEvidencijuNastave.chDomaci.Checked = false;
            ucKreirajEvidencijuNastave.dateDatumStavke.Value = DateTime.Today;
        }

        private void resetujFormu()
        {

            ucKreirajEvidencijuNastave.cbGrupa.DataSource = VratiSlobodneGrupe();
            ucKreirajEvidencijuNastave.cbGrupa.SelectedIndex = -1;
            ucKreirajEvidencijuNastave.cbUcitelj.SelectedIndex = -1;
            ucKreirajEvidencijuNastave.chAktivna.Checked = false;
            ucKreirajEvidencijuNastave.datePocetakRada.Value = DateTime.Today;
            ucKreirajEvidencijuNastave.dateDatumStavke.Value = DateTime.Today;
            ucKreirajEvidencijuNastave.txtKomentar.Text = "";
            ucKreirajEvidencijuNastave.cbUcenici.SelectedIndex = -1;
            ucKreirajEvidencijuNastave.cbRBCasa.SelectedIndex = -1;
            ucKreirajEvidencijuNastave.chPrisustvo.Checked = false;
            ucKreirajEvidencijuNastave.chDomaci.Checked = false;
            ucKreirajEvidencijuNastave.dateDatumStavke.Value = DateTime.Today;
            stavke.Clear();
        }

        private static BindingList<GrupaUcenika> VratiSlobodneGrupe()
        {
            try
            {
                string join = "gu left join EvidencijaNastave en on (gu.idGrupa = en.idGrupa) join Kurs k on (gu.idKurs = k.idKurs)";
                string condition = "en.idEvidencijaNastave is null";
                Komunikacija.Instance.PoveziSe();
                BindingList<GrupaUcenika> dostupneGrupeUcenika = Komunikacija.Instance.vratiListuGrupaUcenika(new GrupaUcenika() { SelectCondition = condition, Join = join });
                return dostupneGrupeUcenika;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greška prilikom rada sa serverom!");
            }
            return null;
            
        }

        private void SrediDGV()
        {
            foreach (DataGridViewColumn col in ucKreirajEvidencijuNastave.dgvStavke.Columns)
            {
                col.Visible = false;
            }
            ucKreirajEvidencijuNastave.dgvStavke.Columns[2].Visible = true;
            ucKreirajEvidencijuNastave.dgvStavke.Columns[3].Visible = true;
            ucKreirajEvidencijuNastave.dgvStavke.Columns[4].Visible = true;
            ucKreirajEvidencijuNastave.dgvStavke.Columns[5].Visible = true;
            ucKreirajEvidencijuNastave.dgvStavke.Columns[6].Visible = true;
            ucKreirajEvidencijuNastave.dgvStavke.Columns[1].Visible = true;
        }
    }
}
