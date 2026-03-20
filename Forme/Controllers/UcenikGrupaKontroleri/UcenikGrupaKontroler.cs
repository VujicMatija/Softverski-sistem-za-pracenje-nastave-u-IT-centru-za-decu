using Domeni;
using Forme.User_controlers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers.UcenikGrupaKontroleri
{
    internal class UcenikGrupaKontroler
    {
        UCdodajUcenikGrupa ucUcenikGrupa;

        GrupaUcenika globalnaGrupa = new GrupaUcenika();

        internal Control CreateDodajUcenikaUGrupu(GrupaUcenika grupa)
        {
            ucUcenikGrupa = new UCdodajUcenikGrupa(grupa);
            try
            {
                Komunikacija.Instance.PoveziSe();
                globalnaGrupa = grupa;
                ucUcenikGrupa.lblGrupa.Text = $"Učenici grupe {grupa.OznakaGrupe}";
                string condition = $" gu.idGrupa = {globalnaGrupa.IdGrupe}";
                ucUcenikGrupa.dgvTrenutni.DataSource = Komunikacija.Instance.VratiListuUcenika(new Ucenik() { SelectCondition = condition });
                foreach (DataGridViewColumn col in ucUcenikGrupa.dgvTrenutni.Columns)
                {
                    col.Visible = false;
                }
                ucUcenikGrupa.dgvTrenutni.Columns[1].Visible = true;
                ucUcenikGrupa.dgvTrenutni.Columns[2].Visible = true;
                ucUcenikGrupa.dgvTrenutni.Columns[4].Visible = true;
                ucUcenikGrupa.dgvTrenutni.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ucUcenikGrupa.dgvRaspolozivi.DataSource = Komunikacija.Instance.VratiListuSviUcenici();
                foreach (DataGridViewColumn col in ucUcenikGrupa.dgvRaspolozivi.Columns)
                {
                    col.Visible = false;
                }
                ucUcenikGrupa.dgvRaspolozivi.Columns[1].Visible = true;
                ucUcenikGrupa.dgvRaspolozivi.Columns[2].Visible = true;
                // dgvRaspolozivi.Columns[4].Visible = true;
                ucUcenikGrupa.dgvRaspolozivi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ucUcenikGrupa.btnPretrazi.Click += Pretrazi;
                ucUcenikGrupa.btnDodaj.Click += UbaciUcenikaUGrupu;
            }
            catch (Exception)
            {

                MessageBox.Show("Greška prilikom rada sa serverom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            return ucUcenikGrupa;
        }

        private void Pretrazi(object sender, EventArgs e)
        {
            Ucenik ucenik = new Ucenik();
            try
            {
                Komunikacija.Instance.PoveziSe();
                if (string.IsNullOrEmpty(ucUcenikGrupa.txtImePrezime.Text) == false)
                {

                    string[] uc = ucUcenikGrupa.txtImePrezime.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string ime = uc[0] != null ? uc[0] : "";
                    string prezime = "";
                    try
                    {
                        prezime = uc[1] != null ? uc[1] : "";
                    }
                    catch
                    {
                        prezime = "";
                    }

                    ucenik = new Ucenik
                    {
                        ImeUcenika = char.ToUpper(ime[0]) + ime.Substring(1),
                        PrezimeUcenika = prezime != "" ? char.ToUpper(prezime[0]) + prezime.Substring(1) : ""
                    };
                }
            }
            catch
            {
                ucenik = null;
            }

            if (ucenik == null)
            {
                MessageBox.Show("Greška");
            }
            else
            {
                try
                {
                    
                    string condition = $" imeUcenika like '{ucenik.ImeUcenika}%' and prezimeUcenika like  '{ucenik.PrezimeUcenika}%'";
                    ucenik.Join = "";
                    ucenik.SelectCondition = condition;
                    ucUcenikGrupa.dgvRaspolozivi.DataSource = Komunikacija.Instance.VratiListuUcenika(ucenik);
                    foreach (DataGridViewColumn col in ucUcenikGrupa.dgvRaspolozivi.Columns)
                    {
                        col.Visible = false;
                    }
                    ucUcenikGrupa.dgvRaspolozivi.Columns[1].Visible = true;
                    ucUcenikGrupa.dgvRaspolozivi.Columns[2].Visible = true;
                    // dgvRaspolozivi.Columns[4].Visible = true;
                    ucUcenikGrupa.dgvRaspolozivi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception)
                {
                    MessageBox.Show("Greška prilikom pretrage učenika !", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
               
            }
        }

       

        private void UbaciUcenikaUGrupu(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                DialogResult res = MessageBox.Show($"Da li ste sigruni da želite da ubacite učenika u grupu {globalnaGrupa.OznakaGrupe}?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        if(ucUcenikGrupa.dgvRaspolozivi.CurrentRow == null)
                        {
                            MessageBox.Show("Niste odabrali učenika", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            UcenikGrupa ug = new UcenikGrupa
                            { ucenik = (Ucenik)ucUcenikGrupa.dgvRaspolozivi.CurrentRow.DataBoundItem, grupaUcenika = globalnaGrupa };
                            Komunikacija.Instance.KreirajUcenikGrupa(ug);
                            MessageBox.Show("Ucenik je dodat u grupu");
                            globalnaGrupa.BrojUcenika++;
                            globalnaGrupa.SelectCondition = $" idGrupa = {globalnaGrupa.IdGrupe}";
                            Komunikacija.Instance.PromeniGrupuUcenika(globalnaGrupa);
                            string condition = $" gu.idGrupa = {globalnaGrupa.IdGrupe}";
                            ucUcenikGrupa.dgvTrenutni.DataSource = Komunikacija.Instance.VratiListuUcenika(new Ucenik() { SelectCondition = condition });

                            foreach (DataGridViewColumn col in ucUcenikGrupa.dgvTrenutni.Columns)
                            {
                                col.Visible = false;
                            }
                            ucUcenikGrupa.dgvTrenutni.Columns[1].Visible = true;
                            ucUcenikGrupa.dgvTrenutni.Columns[2].Visible = true;
                            ucUcenikGrupa.dgvTrenutni.Columns[4].Visible = true;
                            ucUcenikGrupa.dgvTrenutni.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                            
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
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom rada sa serverom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
