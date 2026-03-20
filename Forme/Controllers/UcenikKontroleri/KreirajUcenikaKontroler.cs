using Domeni;
using Forme.User_controlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers.UcenikKontroleri
{
    internal class KreirajUcenikaKontroler
    {

        UCradSaUcenikom ucKreirajUcenika;

        Ucenik globalniUcenik = new Ucenik();

        internal Control CreateKreirajUcenika()
        {
        
            ucKreirajUcenika = new UCradSaUcenikom();

            ucKreirajUcenika.cbPol.DataSource = Enum.GetValues<Pol>();
            ucKreirajUcenika.btnOmoguciIzmene.Visible = false;
            ucKreirajUcenika.btnObrisi.Visible = false;
            ucKreirajUcenika.btnIzmeni.Visible = false;

            ucKreirajUcenika.btnKreiraj.Click += Kreiraj;
            ucKreirajUcenika.btnIzmeni.Click += Izmeni;
            ucKreirajUcenika.btnObrisi.Click += Obrisi;
            ucKreirajUcenika.btnOmoguciIzmene.Click += OmoguciIzmene;

            return ucKreirajUcenika;
        }

        internal Control CreateKreirajUcenika(Ucenik ucenik)
        {
            ucKreirajUcenika = new UCradSaUcenikom();

            ucKreirajUcenika.dgvGrupe.Visible = true;
            globalniUcenik = ucenik;
            ucKreirajUcenika.cbPol.DataSource = Enum.GetValues<Pol>();


            ucKreirajUcenika.txtImeUcenika.Text = ucenik.ImeUcenika;
            ucKreirajUcenika.txtPrezimeUcenika.Text = ucenik.PrezimeUcenika;
            ucKreirajUcenika.txtImeRoditelja.Text = ucenik.ImeRoditelja;
            ucKreirajUcenika.txtPrezimeRoditelja.Text = ucenik.PrezimeRoditelja;
            ucKreirajUcenika.txtEmailUcenika.Text = ucenik.EmailUcenika;
            ucKreirajUcenika.txtTelefonUcenika.Text = ucenik.TelefonUcenika;
            ucKreirajUcenika.txtTelefonRoditelja.Text = ucenik.TelefonRoditelja;
            ucKreirajUcenika.dateDatumRodjenja.Value = ucenik.DatumRodjenjaUcenika;
            ucKreirajUcenika.cbPol.SelectedItem = ucenik.PolUcenika;


            ucKreirajUcenika.btnKreiraj.Visible = false;
            GrupaUcenika grupaUcenika = new GrupaUcenika();
            grupaUcenika.SelectCondition = $" ug.idUcenik = {ucenik.IdUcenika}";
            try
            {
                Komunikacija.Instance.PoveziSe();
                ucKreirajUcenika.dgvGrupe.DataSource = Komunikacija.Instance.vratiListuGrupaUcenika(grupaUcenika);
            }
            catch (Exception)
            {
                MessageBox.Show("Greška prilikom preuzimanja podataka sa servera!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
         
            foreach (DataGridViewColumn col in ucKreirajUcenika.dgvGrupe.Columns)
            {
                col.Visible = false;
            }
            ucKreirajUcenika.dgvGrupe.Columns[1].Visible = true;
            ucKreirajUcenika.dgvGrupe.Columns[3].Visible = true;
            ucKreirajUcenika.dgvGrupe.Columns[4].Visible = true;
            ucKreirajUcenika.dgvGrupe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ucKreirajUcenika.dgvGrupe.Enabled = false;
            ucKreirajUcenika.btnOmoguciIzmene.Visible = true;
            omoguciPolja(false);
            ucKreirajUcenika.btnObrisi.Visible = false;
            ucKreirajUcenika.btnIzmeni.Visible = false;

            ucKreirajUcenika.btnKreiraj.Click += Kreiraj;
            ucKreirajUcenika.btnIzmeni.Click += Izmeni;
            ucKreirajUcenika.btnObrisi.Click += Obrisi;
            ucKreirajUcenika.btnOmoguciIzmene.Click += OmoguciIzmene;

            return ucKreirajUcenika;
        }

        private void Kreiraj(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                if (ValidirajUcenika())
                {
                    Ucenik ucenik = new Ucenik()
                    {
                        ImeUcenika = ucKreirajUcenika.txtImeUcenika.Text,
                        PrezimeUcenika = ucKreirajUcenika.txtPrezimeUcenika.Text,
                        PolUcenika = (Pol)ucKreirajUcenika.cbPol.SelectedItem,
                        ImeRoditelja = ucKreirajUcenika.txtImeRoditelja.Text,
                        PrezimeRoditelja = ucKreirajUcenika.txtPrezimeRoditelja.Text,
                        TelefonRoditelja = ucKreirajUcenika.txtTelefonRoditelja.Text,
                        DatumRodjenjaUcenika = ucKreirajUcenika.dateDatumRodjenja.Value,
                        TelefonUcenika = ucKreirajUcenika.txtTelefonUcenika.Text,
                        EmailUcenika = ucKreirajUcenika.txtEmailUcenika.Text
                    };
                    try
                    {
                        Komunikacija.Instance.UbaciUcenika(ucenik);
                        MessageBox.Show("Ucenik je uspesno kreiran");
                        ocistiPolja();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Trenutno nije moguće kreirati novog učenika!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                if (ValidirajUcenika())
                {
                    Ucenik ucenik = new Ucenik()
                    {
                        IdUcenika = globalniUcenik.IdUcenika,
                        ImeUcenika = ucKreirajUcenika.txtImeUcenika.Text,
                        PrezimeUcenika = ucKreirajUcenika.txtPrezimeUcenika.Text,
                        ImeRoditelja = ucKreirajUcenika.txtImeRoditelja.Text,
                        PrezimeRoditelja = ucKreirajUcenika.txtPrezimeRoditelja.Text,
                        TelefonRoditelja = ucKreirajUcenika.txtTelefonRoditelja.Text,
                        TelefonUcenika = ucKreirajUcenika.txtTelefonUcenika.Text,
                        EmailUcenika = ucKreirajUcenika.txtEmailUcenika.Text,
                        PolUcenika = (Pol)ucKreirajUcenika.cbPol.SelectedItem,
                        DatumRodjenjaUcenika = ucKreirajUcenika.dateDatumRodjenja.Value
                    };
                    DialogResult res = MessageBox.Show("Da li ste sigurni da želite da izmenite učenika?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {
                            ucenik.SelectCondition = $" idUcenik = {ucenik.IdUcenika}";
                            Komunikacija.Instance.PromeniUcenika(ucenik);
                            MessageBox.Show("Promene su sačuvane!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Trenutno nije moguće promeniti učenika!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Obrisi(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Da li ste sigurni da želite da obrišete učenika?", "Potvrda", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                try
                {
                    Komunikacija.Instance.PoveziSe();
                    globalniUcenik.SelectCondition = $" idUcenik = {globalniUcenik.IdUcenika}";
                    Komunikacija.Instance.ObrisiUcenika(globalniUcenik);
                    MessageBox.Show("Ucenik je obrisan!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Trenutno nije moguće izbrisati učenika!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("OK");
            }
        }

        private void omoguciPolja(bool x)
        {
            ucKreirajUcenika.txtImeUcenika.Enabled = x;
            ucKreirajUcenika.txtPrezimeUcenika.Enabled = x;
            ucKreirajUcenika.txtImeRoditelja.Enabled = x;
            ucKreirajUcenika.txtPrezimeRoditelja.Enabled = x;
            ucKreirajUcenika.txtEmailUcenika.Enabled = x;
            ucKreirajUcenika.txtTelefonUcenika.Enabled = x;
            ucKreirajUcenika.txtTelefonRoditelja.Enabled = x;
            ucKreirajUcenika.dateDatumRodjenja.Enabled = x;
            ucKreirajUcenika.cbPol.Enabled = x;
        }

        private void OmoguciIzmene(object sender, EventArgs e)
        {
            ucKreirajUcenika.btnOmoguciIzmene.Visible = false;
            omoguciPolja(true);
            ucKreirajUcenika.btnObrisi.Visible = true;
            ucKreirajUcenika.btnIzmeni.Visible = true;

        }

        private void ocistiPolja()
        {
            ucKreirajUcenika.txtImeUcenika.Text = "";
            ucKreirajUcenika.txtPrezimeUcenika.Text = "";
            ucKreirajUcenika.txtImeRoditelja.Text = "";
            ucKreirajUcenika.txtPrezimeRoditelja.Text = "";
            ucKreirajUcenika.txtTelefonRoditelja.Text = "";
            ucKreirajUcenika.txtTelefonUcenika.Text = "";
            ucKreirajUcenika.txtEmailUcenika.Text = "";

        }

        internal bool ValidirajUcenika()
        {
            ucKreirajUcenika.txtImeUcenika.BackColor = SystemColors.Window;
            ucKreirajUcenika.txtPrezimeUcenika.BackColor = SystemColors.Window;
            ucKreirajUcenika.txtImeRoditelja.BackColor = SystemColors.Window;
            ucKreirajUcenika.txtPrezimeRoditelja.BackColor = SystemColors.Window;
            ucKreirajUcenika.txtTelefonRoditelja.BackColor = SystemColors.Window;
            ucKreirajUcenika.txtTelefonUcenika.BackColor = SystemColors.Window;
            ucKreirajUcenika.txtEmailUcenika.BackColor = SystemColors.Window;
            ucKreirajUcenika.txtImeUcenika.BackColor = SystemColors.Window;

            string poruka = "";
            Color boja = ColorTranslator.FromHtml("#d96f6f");
            bool uspesno = true;
            if (ucKreirajUcenika.txtImeUcenika.Text.Length < 3)
            {
                poruka = poruka + "Ime ucenika mora biti duze od dva karaktera";
                ucKreirajUcenika.txtImeUcenika.BackColor = boja;
            }
            if (ucKreirajUcenika.txtPrezimeUcenika.Text.Length < 3)
            {
                poruka = poruka + "Prezime ucenika mora biti duze od dva karaktera";
                ucKreirajUcenika.txtPrezimeUcenika.BackColor = boja;
            }

            if (ucKreirajUcenika.txtEmailUcenika.Text.Contains("@") == false || ucKreirajUcenika.txtEmailUcenika.Text.Contains(".com") == false)
            {
                poruka = poruka + "Email mora da sadrzi @ i .com";
                ucKreirajUcenika.txtEmailUcenika.BackColor = boja;
            }

            if (ucKreirajUcenika.txtImeRoditelja.Text.Length < 3)
            {
                poruka = poruka + "Ime roditelja mora biti duze od dva karaktera";
                ucKreirajUcenika.txtImeRoditelja.BackColor = boja;
            }
            if (ucKreirajUcenika.txtPrezimeRoditelja.Text.Length < 3)
            {
                poruka = poruka + "Prezime roditelja mora biti duze od dva karaktera";
                ucKreirajUcenika.txtPrezimeRoditelja.BackColor = boja;
            }
            if (ucKreirajUcenika.txtTelefonRoditelja.Text == ucKreirajUcenika.txtTelefonUcenika.Text)
            {
                poruka = poruka + "Telefon roditelja i ucenika mora da se razlikuje!";
                ucKreirajUcenika.txtTelefonRoditelja.BackColor = boja;
                ucKreirajUcenika.txtTelefonUcenika.BackColor = boja;
            }

            if (string.IsNullOrEmpty(poruka) == false)
            {
                MessageBox.Show("Neuspesna validacija ucenika\n" + poruka);
                uspesno = false;
            }

            return uspesno;
        }


    }
}
