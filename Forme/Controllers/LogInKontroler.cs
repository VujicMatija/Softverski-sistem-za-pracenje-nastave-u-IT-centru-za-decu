using Domeni;
using Forme.User_controlers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers
{
    internal class LogInKontroler
    {
        ucLogIn ucLogIn;

        internal Control CreateLogIn()
        {
            ucLogIn = new ucLogIn();

            ucLogIn.btnPrijava.Click += Prijava;
            ucLogIn.Load += LogIn_Load;


            return ucLogIn;
        }

        private void Prijava(object sender, EventArgs e)
        {
            
                if (string.IsNullOrEmpty(ucLogIn.txtKorisnickoIme.Text) || string.IsNullOrEmpty(ucLogIn.txtLozinka.Text))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Ucitelj u = new Ucitelj
                    {
                        KorisnickoIme = ucLogIn.txtKorisnickoIme.Text,
                        Lozinka = ucLogIn.txtLozinka.Text
                    };

                    Ucitelj logovani = null;
                    try
                    {
                    Komunikacija.Instance.PoveziSe();
                    logovani = Komunikacija.instance.PrijaviUcitelja(u);
                        if (logovani == null)
                        {
                            MessageBox.Show("Korisničko ime i šifra nisu ispravni!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Debug.WriteLine("LOGOVANI>>>>>>>" + logovani.ToString());
                            MessageBox.Show($"Korisničko ime i sifra su ispravni, dobrodošli!", "Uspešna prijava", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            MainCoordinator.Instance.ShowMain(logovani);


                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ne može da se otvori glavna forma i meni!");
                        
                    }

                    
                }
           
            
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Neuspesno povezivanje");
                
            }
        }

    }
}
