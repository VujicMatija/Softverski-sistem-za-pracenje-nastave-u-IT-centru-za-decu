using Domeni;
using Forme.User_controlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers.LicenceKontroleri
{
    internal class KreirajLicencuKontroler
    {

        UCkreirajLicencu ucKreirajLicencu;
        Ucitelj globUcitelj;

        internal Control CreateKreirajLicencu(Ucitelj ucitelj)
        {
            ucKreirajLicencu = new UCkreirajLicencu(ucitelj);
            try
            {
                Komunikacija.Instance.PoveziSe();
                ucKreirajLicencu.txtUcitelj.Enabled = false;
                ucKreirajLicencu.txtUcitelj.Text = ucitelj.ToString();
                BindingList<Sertifikat> sviSertifikati = Komunikacija.Instance.VratiListuSviSertifikati();
                string condition = $"l.idUcitelj = {ucitelj.Id}";
                Sertifikat sertifikat = new Sertifikat();
                sertifikat.SelectCondition = condition;
                BindingList<Sertifikat> uciteljeviSertifikati = Komunikacija.Instance.VratiListuSertifikata(sertifikat);
                //BindingList<Sertifikat> uciteljeviSertifikati = Komunikacija.Instance.VratiListuSertifikata(ucitelj: ucitelj, sertifikat: null);
                ucKreirajLicencu.cbSertifikati.DataSource = sviSertifikati.Except(uciteljeviSertifikati).ToList();
                globUcitelj = ucitelj;
                ucKreirajLicencu.btnDodajLicencu.Click += DodajLicencu;
                ucKreirajLicencu.btnIzmeni.Click += Izmeni;
                ucKreirajLicencu.btnOmoguciIzmenu.Click += OmoguciIzmenu;
            }
            catch (Exception)
            {
                MessageBox.Show("Greška prilikom rada sa serverom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return ucKreirajLicencu;
        }

        internal Control CreateKreirajLicencu(Licenca licenca)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                ucKreirajLicencu = new UCkreirajLicencu(licenca);
                globUcitelj = licenca.ucitelj;
                ucKreirajLicencu.txtUcitelj.Enabled = false;
                ucKreirajLicencu.txtUcitelj.Text = licenca.ucitelj.ToString();
                ucKreirajLicencu.cbSertifikati.DataSource = Komunikacija.Instance.VratiListuSviSertifikati();
                ucKreirajLicencu.cbSertifikati.SelectedItem = licenca.sertifikat;
                ucKreirajLicencu.dateDobijanje.Value = licenca.DatumDobijanja;
                ucKreirajLicencu.txtUcitelj.Enabled = false;
                ucKreirajLicencu.cbSertifikati.Enabled = false;
                ucKreirajLicencu.dateDobijanje.Enabled = false;
                ucKreirajLicencu.btnOmoguciIzmenu.Visible = true;
                ucKreirajLicencu.btnDodajLicencu.Click += DodajLicencu;
                ucKreirajLicencu.btnIzmeni.Click += Izmeni;
                ucKreirajLicencu.btnOmoguciIzmenu.Click += OmoguciIzmenu;
            }
            catch (Exception)
            {
                MessageBox.Show("Greška prilikom rada sa serverom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            return ucKreirajLicencu;
            
        }

        private void DodajLicencu(object sender, EventArgs e)
        {
            Licenca licenca = new Licenca()
            {
                ucitelj = new Ucitelj
                {
                    Id = globUcitelj.Id
                },
                sertifikat = new Sertifikat
                {
                    IdSertifikata = ((Sertifikat)ucKreirajLicencu.cbSertifikati.SelectedItem).IdSertifikata
                },
                DatumDobijanja = ucKreirajLicencu.dateDobijanje.Value

            };
            try
            {
                Komunikacija.Instance.PoveziSe();
                Komunikacija.Instance.KreirajLicencu(licenca);
                MessageBox.Show("Licenca je dodata!");
            }
            catch
            {
                MessageBox.Show("Greška prilikom kreiranja licence!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OmoguciIzmenu(object sender, EventArgs e)
        {
            ucKreirajLicencu.btnOmoguciIzmenu.Visible = false;
            ucKreirajLicencu.btnIzmeni.Visible = true;
            ucKreirajLicencu.dateDobijanje.Enabled = true;
        }

        private void Izmeni(object sender, EventArgs e)
        {
            Licenca licenca = new Licenca
            {
                ucitelj = globUcitelj,
                sertifikat = (Sertifikat)ucKreirajLicencu.cbSertifikati.SelectedItem,
                DatumDobijanja = ucKreirajLicencu.dateDobijanje.Value
            };

            DialogResult res = MessageBox.Show("Da li ste sigurni da zelite da sacuvate promene?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    Komunikacija.Instance.PoveziSe();
                    licenca.SelectCondition = $" idUcitelj = {licenca.ucitelj.Id} and idSertifikat = {licenca.sertifikat.IdSertifikata}";
                    Komunikacija.Instance.PromeniLicencu(licenca);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška prilikom izmene licence!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
