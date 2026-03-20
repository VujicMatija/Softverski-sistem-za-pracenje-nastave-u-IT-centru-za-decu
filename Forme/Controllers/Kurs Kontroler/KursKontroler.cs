using Domeni;
using Forme.User_controlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers
{
    internal class KursKontroler
    {

        UCradSaKursom ucKurs;

        Kurs globalniKurs = new Kurs();

        internal Control CreateRadSaKursom()
        {
            ucKurs = new UCradSaKursom();
            try
            {
                Komunikacija.Instance.PoveziSe();
                ucKurs.cbTezina.DataSource = Enum.GetValues<TezinaKursa>();
                ucKurs.cbUzrast.DataSource = Enum.GetValues<Uzrast>();
                ucKurs.dgvPodaci.DataSource = Komunikacija.Instance.VratiListuSviKursevi();
                foreach (DataGridViewColumn col in ucKurs.dgvPodaci.Columns)
                {
                    col.Visible = false;
                }

                ucKurs.dgvPodaci.Columns[1].Visible = true;
                ucKurs.dgvPodaci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ucKurs.btnIzmeni.Click += Izmeni;
                ucKurs.btnKreiraj.Click += Kreiraj;
                ucKurs.btnOmoguciIzmene.Click += OmoguciIzmene;
                ucKurs.btnPretrazi.Click += Pretrazi;
                ucKurs.btnPrikazi.Click += Prikazi;

            }
            catch (Exception)
            {
                MessageBox.Show("Greška prilikom rada sa serverom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            return ucKurs;
        }

        internal Control CreateRadSaKursom(Kurs kurs)
        {
            ucKurs = new UCradSaKursom();

            globalniKurs = kurs;
            ucKurs.cbTezina.DataSource = Enum.GetValues<TezinaKursa>();
            ucKurs.cbUzrast.DataSource = Enum.GetValues<Uzrast>();
            
            try
            {
                Komunikacija.Instance.PoveziSe();
                //ucKurs.dgvPodaci.DataSource = Komunikacija.Instance.VratiListuEvidencijaNastave(null, null, null, kurs, null);
                ucKurs.dgvPodaci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                foreach (DataGridViewColumn col in ucKurs.dgvPodaci.Columns)
                {
                    col.Visible = false;
                }
                ucKurs.dgvPodaci.Columns[4].Visible = true;
            }
            catch { }
            InizijalizujFormu(kurs);


            ucKurs.btnIzmeni.Click += Izmeni;
            ucKurs.btnKreiraj.Click += Kreiraj;
            ucKurs.btnOmoguciIzmene.Click += OmoguciIzmene;
            ucKurs.btnPretrazi.Click += Pretrazi;
            ucKurs.btnPrikazi.Click += Prikazi;

            return ucKurs;
        }


        private void Kreiraj(object sender, EventArgs e)
        {

            try
            {
                Komunikacija.Instance.PoveziSe();
                if (ValidirajKurs())
                {
                    Kurs k = new Kurs()
                    {
                        NazivKursa = ucKurs.txtNaziv.Text,
                        TezinaKursa = (TezinaKursa)ucKurs.cbTezina.SelectedItem,
                        UzrastKursa = (Uzrast)ucKurs.cbUzrast.SelectedItem,
                        TrajanjeKursa = (int)ucKurs.numTrajanje.Value,
                        OznakaKursa = ucKurs.txtOznaka.Text
                    };

                    try
                    {
                        Komunikacija.Instance.KreirajKurs(k);
                        MessageBox.Show("Kurs je kreiran!");
                        ucKurs.dgvPodaci.DataSource = Komunikacija.Instance.VratiListuSviKursevi();
                        ResetujPolja();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Trenutno nije moguće kreirati kurs!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void Pretrazi(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                if (string.IsNullOrWhiteSpace(ucKurs.txtNaziv.Text))
                {
                    ucKurs.dgvPodaci.DataSource = Komunikacija.Instance.VratiListuSviKursevi();
                }
                else
                {
                    Kurs zaPretragu = new Kurs() { NazivKursa = ucKurs.txtNaziv.Text };
                    zaPretragu.SelectCondition = $" nazivKursa like '{zaPretragu.NazivKursa}%'";
                    ucKurs.dgvPodaci.DataSource = Komunikacija.Instance.VratiListuKurseva(zaPretragu);
                    foreach (DataGridViewColumn col in ucKurs.dgvPodaci.Columns)
                    {
                        col.Visible = false;
                    }

                    ucKurs.dgvPodaci.Columns[1].Visible = true;

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Trenutno nije moguće pretražiti kurseve!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Prikazi(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                if (ucKurs.dgvPodaci.CurrentRow != null)
                {
                    MainCoordinator.Instance.ShowRadSaKursom((Kurs)ucKurs.dgvPodaci.CurrentRow.DataBoundItem);
                   
                }
                else
                {
                    MessageBox.Show("Niste odabrali kurs!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        private void Izmeni(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                if (ValidirajKurs())
                {
                    Kurs k = new Kurs()
                    {
                        IdKursa = globalniKurs.IdKursa,
                        NazivKursa = ucKurs.txtNaziv.Text,
                        TezinaKursa = (TezinaKursa)ucKurs.cbTezina.SelectedItem,
                        UzrastKursa = (Uzrast)ucKurs.cbUzrast.SelectedItem,
                        TrajanjeKursa = (int)ucKurs.numTrajanje.Value,
                        OznakaKursa = ucKurs.txtOznaka.Text
                    };

                    DialogResult res = MessageBox.Show("Da li ste sigurni da zelite da promenite kurs?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {


                        try
                        {
                            k.SelectCondition = $" idKurs = {k.IdKursa}";
                            Komunikacija.Instance.PromeniKurs(k);
                            MessageBox.Show("Kurs je promenjen!");

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
                MessageBox.Show("Trenutno nije moguće promeniti kurs!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void OmoguciIzmene(object sender, EventArgs e)
        {
            omoguciPolja(true);
            ucKurs.btnOmoguciIzmene.Visible = false;
            ucKurs.txtOznaka.Enabled = false;
            ucKurs.btnIzmeni.Visible = true;
            ucKurs.txtOznaka.Enabled = true;
        }

        public bool ValidirajKurs()
        {
            ucKurs.txtNaziv.BackColor = SystemColors.Window;
            ucKurs.numTrajanje.BackColor = SystemColors.Window;
            ucKurs.txtOznaka.BackColor = SystemColors.Window;
            Color boja = ColorTranslator.FromHtml("#d96f6f"); ;
            bool uspesno = true;
            string poruka = "";
            if (string.IsNullOrEmpty(ucKurs.txtNaziv.Text))
            {
                poruka = poruka + "Naziv kursa ne sme biti prazan\n";
                ucKurs.txtNaziv.BackColor = boja;
            }
            if (string.IsNullOrEmpty(ucKurs.txtOznaka.Text))
            {
                poruka = poruka + "Unesite oznaku kursa\n";
                ucKurs.txtOznaka.BackColor = boja;
            }
            if (ucKurs.numTrajanje.Value == 0)
            {
                poruka = poruka + "Kurs mora da traje makar jedan čas\n";
                ucKurs.numTrajanje.BackColor = boja;
            }
            if (string.IsNullOrEmpty(poruka) == false)
            {
                MessageBox.Show("Greska prilikom validacije\n" + poruka);
                uspesno = false;
            }
            return uspesno;
        }



        public void ResetujPolja()
        {
            ucKurs.txtNaziv.Text = "";
            ucKurs.txtOznaka.Text = "";
            ucKurs.cbTezina.SelectedIndex = 0;
            ucKurs.cbUzrast.SelectedIndex = 0;
            ucKurs.numTrajanje.Value = 0;
        }

        private void omoguciPolja(bool x)
        {
            ucKurs.numTrajanje.Enabled = x;
            ucKurs.cbTezina.Enabled = x;
            ucKurs.cbUzrast.Enabled = x;
            ucKurs.txtNaziv.Enabled = x;
            ucKurs.txtOznaka.Enabled = x;
        }

        public void InizijalizujFormu(Kurs kurs)
        {
            ucKurs.txtNaziv.Text = kurs.NazivKursa;
            ucKurs.txtOznaka.Text = kurs.OznakaKursa;
            ucKurs.numTrajanje.Value = kurs.TrajanjeKursa;
            ucKurs.cbTezina.SelectedItem = kurs.TezinaKursa;
            ucKurs.cbUzrast.SelectedItem = kurs.UzrastKursa;
            omoguciPolja(false);
            ucKurs.btnKreiraj.Visible = false;
            ucKurs.btnPretrazi.Visible = false;
            ucKurs.btnPrikazi.Visible = false;
            ucKurs.btnOmoguciIzmene.Visible = true;
        }

    }
}
