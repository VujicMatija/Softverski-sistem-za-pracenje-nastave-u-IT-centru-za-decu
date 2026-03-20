using Domeni;
using Forme.User_controlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers.SertifikatKontroleri
{
    internal class RadSaSertifikatomKontroler
    {
        UcRadSaSertifikatima ucRadSaSertifikatom;


        Sertifikat globalniSertifikat = new Sertifikat();
        internal Control CreateRadSaSertifikatom()
        {
            ucRadSaSertifikatom = new UcRadSaSertifikatima();
            try
            {
                Komunikacija.Instance.PoveziSe();
                ucRadSaSertifikatom.dgvPodaci.DataSource = Komunikacija.Instance.VratiListuSviSertifikati();
                ucRadSaSertifikatom.dgvPodaci.Columns[0].Visible = false;
                ucRadSaSertifikatom.dgvPodaci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                foreach (DataGridViewColumn col in ucRadSaSertifikatom.dgvPodaci.Columns)
                {
                    col.Visible = false;
                }
                ucRadSaSertifikatom.dgvPodaci.Columns[1].Visible = true;
                ucRadSaSertifikatom.btnIzmeni.Click += Izmeni;
                ucRadSaSertifikatom.btnObrisi.Click += Obrisi;
                ucRadSaSertifikatom.btnOmoguciIzmene.Click += OmoguciIzmene;
                ucRadSaSertifikatom.btnPretrazi.Click += Pretrazi;
                ucRadSaSertifikatom.btnPrikazi.Click += Prikazi;
                ucRadSaSertifikatom.btnUbaciSertifikat.Click += UbaciSertifikat;
            }
            catch (Exception)
            {
                MessageBox.Show("Rad sa sertifikatima trenutno nije moguć!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            

            return ucRadSaSertifikatom;
        }

        internal Control CreateRadSaSertifikatom(Sertifikat sertifikat)
        {
            ucRadSaSertifikatom = new UcRadSaSertifikatima(sertifikat);
            globalniSertifikat = sertifikat;

            ucRadSaSertifikatom.btnIzmeni.Visible = false;
            ucRadSaSertifikatom.btnOmoguciIzmene.Visible = true;
            ucRadSaSertifikatom.txtNazivSertifikata.Enabled = false;
            ucRadSaSertifikatom.btnPrikazi.Visible = false;
            ucRadSaSertifikatom.btnUbaciSertifikat.Visible = false;
            ucRadSaSertifikatom.btnPretrazi.Visible = false;
            ucRadSaSertifikatom.txtNazivSertifikata.Text = sertifikat.NazivSertifikata;
            try
            {
                Komunikacija.Instance.PoveziSe();
                ucRadSaSertifikatom.dgvPodaci.DataSource = Komunikacija.Instance.VratiListuSviSertifikati();
                foreach (DataGridViewColumn col in ucRadSaSertifikatom.dgvPodaci.Columns)
                {
                    col.Visible = false;
                }
                ucRadSaSertifikatom.dgvPodaci.Columns[1].Visible = true;
           
                ucRadSaSertifikatom.dgvPodaci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ucRadSaSertifikatom.btnIzmeni.Click += Izmeni;
                ucRadSaSertifikatom.btnObrisi.Click += Obrisi;
                ucRadSaSertifikatom.btnOmoguciIzmene.Click += OmoguciIzmene;
                ucRadSaSertifikatom.btnPretrazi.Click += Pretrazi;
                ucRadSaSertifikatom.btnPrikazi.Click += Prikazi;
                ucRadSaSertifikatom.btnUbaciSertifikat.Click += UbaciSertifikat;

            }
            catch (Exception)
            {
                MessageBox.Show("Rad sa sertifikatima trenutno nije moguć!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
            return ucRadSaSertifikatom;
        }

        private void UbaciSertifikat(object sender, EventArgs e)
        {

            try
            {
                Komunikacija.Instance.PoveziSe();
                if (ValidirajSertifikat())
                {
                    Sertifikat s = new Sertifikat() { NazivSertifikata = ucRadSaSertifikatom.txtNazivSertifikata.Text };
                    Komunikacija.Instance.UbaciSertifikat(s);
                    MessageBox.Show("Sistem je zapamtio sertifikat!");
                    ucRadSaSertifikatom.dgvPodaci.DataSource = Komunikacija.Instance.VratiListuSviSertifikati();
                    foreach (DataGridViewColumn col in ucRadSaSertifikatom.dgvPodaci.Columns)
                    {
                        col.Visible = false;
                    }
                    ucRadSaSertifikatom.dgvPodaci.Columns[1].Visible = true;

                    ucRadSaSertifikatom.dgvPodaci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti sertifikat!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void Prikazi(object sender, EventArgs e)
        {

            if(ucRadSaSertifikatom.dgvPodaci.CurrentRow != null)
            {
                Komunikacija.Instance.PoveziSe();
                try
                {

                    Sertifikat sertifikat = (Sertifikat)ucRadSaSertifikatom.dgvPodaci.CurrentRow.DataBoundItem;
                    sertifikat.Join = "";
                    sertifikat = Komunikacija.Instance.PretraziSertifiakt(sertifikat);
                    
                    MainCoordinator.Instance.ShowRadSaSertifikatom(sertifikat);
                }
                catch (Exception)
                {

                    MessageBox.Show("Sistem ne može da pronađe sertifikat!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
                
            }
            else
            {
                MessageBox.Show("Morate odabrati sertifikat!");
            }
        }

        private void OmoguciIzmene(object sender, EventArgs e)
        {
            ucRadSaSertifikatom.btnOmoguciIzmene.Visible = false;
            ucRadSaSertifikatom.btnObrisi.Visible = true;
            ucRadSaSertifikatom.btnIzmeni.Visible = true;
            ucRadSaSertifikatom.txtNazivSertifikata.Enabled = true;
        }

        private void Izmeni(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                if (ValidirajSertifikat())
                {
                    Sertifikat s = new Sertifikat() { IdSertifikata = globalniSertifikat.IdSertifikata, NazivSertifikata = ucRadSaSertifikatom.txtNazivSertifikata.Text };
                    DialogResult res = MessageBox.Show("Da li zelite da sacuvate promene?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {
                            s.SelectCondition = $" idSertifikat = {s.IdSertifikata}";
                            Komunikacija.Instance.PromeniSertifikat(s);
                            MessageBox.Show("Promena sacuvana!");
                            ucRadSaSertifikatom.dgvPodaci.DataSource = Komunikacija.Instance.VratiListuSviSertifikati();
                            foreach (DataGridViewColumn col in ucRadSaSertifikatom.dgvPodaci.Columns)
                            {
                                col.Visible = false;
                            }
                            ucRadSaSertifikatom.dgvPodaci.Columns[1].Visible = true;

                            ucRadSaSertifikatom.dgvPodaci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("OK!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Obrisi(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Da li ste sigurni da zelite da obrisete sertifikat?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    Komunikacija.Instance.PoveziSe();
                    globalniSertifikat.SelectCondition = $" idSertifikat = {globalniSertifikat.IdSertifikata}";
                    Komunikacija.Instance.ObrisiSertifikat(globalniSertifikat);
                    MessageBox.Show("Sertifikat obrisan!");
                    ucRadSaSertifikatom.dgvPodaci.DataSource = Komunikacija.Instance.VratiListuSviSertifikati();
                    foreach (DataGridViewColumn col in ucRadSaSertifikatom.dgvPodaci.Columns)
                    {
                        col.Visible = false;
                    }
                    ucRadSaSertifikatom.dgvPodaci.Columns[1].Visible = true;

                    ucRadSaSertifikatom.dgvPodaci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Trenutno nije moguće obrisati sertifikat!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("OK");
            }
        }

        private void Pretrazi(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ucRadSaSertifikatom.txtNazivSertifikata.Text))
                {
                    ucRadSaSertifikatom.dgvPodaci.DataSource = Komunikacija.Instance.VratiListuSviSertifikati();
                }
                else
                {

                    Sertifikat sertifikatZaPretragu = new Sertifikat() { NazivSertifikata = ucRadSaSertifikatom.txtNazivSertifikata.Text };
                    sertifikatZaPretragu.SelectCondition = $" NazivSertifikata like '{sertifikatZaPretragu.NazivSertifikata}%'";
                    sertifikatZaPretragu.Join = "";


                    ucRadSaSertifikatom.dgvPodaci.DataSource = Komunikacija.Instance.VratiListuSertifikata(sertifikat: sertifikatZaPretragu);
                    foreach (DataGridViewColumn col in ucRadSaSertifikatom.dgvPodaci.Columns)
                    {
                        col.Visible = false;
                    }
                    ucRadSaSertifikatom.dgvPodaci.Columns[1].Visible = true;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Pretraga sertifikata trenutno nije moguća", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        private bool ValidirajSertifikat()
        {
            bool uspesno = true;
            ucRadSaSertifikatom.txtNazivSertifikata.BackColor = SystemColors.Window;
            string poruka = "";
            if (string.IsNullOrEmpty(ucRadSaSertifikatom.txtNazivSertifikata.Text))
            {
                poruka = poruka + "Morate uneti naziv sertifikata";
                ucRadSaSertifikatom.txtNazivSertifikata.BackColor = ColorTranslator.FromHtml("#d96f6f");
            }
            if (string.IsNullOrEmpty(poruka) == false)
            {
                uspesno = false;
                MessageBox.Show("Validacija sertifikata nije uspesna\n" + poruka);
            }

            return uspesno;
        }
    }
}

