using Domeni;
using Forme.User_controlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Forme.Controllers.UciteljKontroleri
{
    internal class KreirajUciteljaKontroler
    {
        private UCradSaUciteljem ucRadSaUciteljem;
        internal Control CreateKreirajUcitelja()
        {
            ucRadSaUciteljem = new UCradSaUciteljem();
            ucRadSaUciteljem.datePocetakRada.MaxDate = DateTime.Today;
            ucRadSaUciteljem.btnKreiraj.Click += Kreiraj;
            return ucRadSaUciteljem;
        }

        private void Kreiraj(object sender, EventArgs e)
        {
            Ucitelj u = new Ucitelj();
            RestartujTextBoxove();
            try
            {
                Komunikacija.Instance.PoveziSe();
                u = new Ucitelj
                {
                    ImeUcitelja =ucRadSaUciteljem.txtIme.Text,
                    PrezimeUcitelja = ucRadSaUciteljem.txtPrezime.Text,
                    Email = ucRadSaUciteljem.txtEmail.Text,
                    Telefon = ucRadSaUciteljem.txtTelefon.Text,
                    KorisnickoIme = ucRadSaUciteljem.txtKorisnickoIme.Text,
                    Lozinka = ucRadSaUciteljem.txtLozinka.Text,
                    DatumPocetkaRada = ucRadSaUciteljem.datePocetakRada.Value
                };
                if (ValidirajUcitelja())
                {
                    try
                    {
                        Komunikacija.Instance.KreirajUcitelja(u);
                        MessageBox.Show("Učitelj je kreiran!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Trenutno nije moguće kreirati učitelja!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);



            }


        }

        private void RestartujTextBoxove()
        {
            ucRadSaUciteljem.txtIme.BackColor = SystemColors.Window;
            ucRadSaUciteljem.txtPrezime.BackColor = SystemColors.Window;
            ucRadSaUciteljem.txtEmail.BackColor = SystemColors.Window;
            ucRadSaUciteljem.txtTelefon.BackColor = SystemColors.Window;
            ucRadSaUciteljem.txtLozinka.BackColor = SystemColors.Window;
            ucRadSaUciteljem.txtKorisnickoIme.BackColor = SystemColors.Window;
        }

        internal bool ValidirajUcitelja()
        {
            Color boja = ColorTranslator.FromHtml("#d96f6f");
            bool uspesno = true;
            string poruka = "";
            if (ucRadSaUciteljem.txtIme.Text.Length < 3)
            {
                ucRadSaUciteljem.txtIme.BackColor = boja;
                poruka = poruka + "Ime mora imati vise od 2 slova!\n";
            }
            if (ucRadSaUciteljem.txtPrezime.Text.Length < 3)
            {
                ucRadSaUciteljem.txtPrezime.BackColor = boja;
                poruka = poruka + "Prezime mora imati vise od 2 slova!\n";
            }
            if (ucRadSaUciteljem.txtEmail.Text.Contains("@") == false || ucRadSaUciteljem.txtEmail.Text.Contains(".com") == false)
            {
                ucRadSaUciteljem.txtEmail.BackColor = boja;
                poruka = poruka + "Email mora da sadrzi @ i .com\n";
            }
            if (ucRadSaUciteljem.txtTelefon.Text.Length > 3 && ucRadSaUciteljem.txtTelefon.Text.Substring(0, 2) != "06")
            {
                poruka = poruka + "Broj telefona mora da pocinenje sa 06!\n";
                ucRadSaUciteljem.txtTelefon.BackColor = boja;
            }
            else if (ucRadSaUciteljem.txtTelefon.Text.Length < 3)
            {
                poruka = poruka + "Broj telefona mora da pocinenje sa 06!\n";
                ucRadSaUciteljem.txtTelefon.BackColor = boja;
            }
            if (ucRadSaUciteljem.txtKorisnickoIme.Text.Length < 8)
            {
                poruka = poruka + "Korisnicko ime mora biti duze od 7 karaktera\n";
                ucRadSaUciteljem.txtKorisnickoIme.BackColor = boja;
            }
            if (ucRadSaUciteljem.txtLozinka.Text.Length < 10)
            {
                poruka = poruka + "Lozinka mora imati minimum 10 karaktera\n";
                ucRadSaUciteljem.txtLozinka.BackColor = boja;
            }
            if (ucRadSaUciteljem.txtKorisnickoIme.Text == ucRadSaUciteljem.txtLozinka.Text)
            {
                ucRadSaUciteljem.txtLozinka.BackColor = boja;
                ucRadSaUciteljem.txtKorisnickoIme.BackColor = boja;
                poruka = poruka + "Lozinka i korisnicko ime moraju  da se razlikuju\n";
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
