using Domeni;
using Forme.User_controlers;
using Forme.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers.EvidencijaNastaveKontroleri
{
    internal class PrikazEvidencijeNastaveKontroler
    {

        UCPrikazEvidencijeNastave ucPrikazEvidencijeNastave;

        EvidencijaNastave globalna = new EvidencijaNastave();

        internal Control CreatePrikazEvidencijeNastave(EvidencijaNastave evidencija, WorkMode mode)
        {
            
            ucPrikazEvidencijeNastave = new UCPrikazEvidencijeNastave(evidencija);
            
            try
            {
                Komunikacija.Instance.PoveziSe();
                globalna = evidencija;
                string condition = $" sen.idEvidencijeNastave = {globalna.IdEvidencijeNastave}  ";

                ucPrikazEvidencijeNastave.cbGrupa.DataSource = Komunikacija.Instance.VratiListuSveGrupeUcenika();
                ucPrikazEvidencijeNastave.cbGrupa.SelectedItem = evidencija.Grupa;

                ucPrikazEvidencijeNastave.cbUcitelj.DataSource = Komunikacija.Instance.VratiListuSviUcitelji();
                ucPrikazEvidencijeNastave.cbUcitelj.SelectedItem = evidencija.Ucitelj;
                condition = $" gu.idGrupa = {evidencija.Grupa.IdGrupe}";
                ucPrikazEvidencijeNastave.dgvUcenici.DataSource = Komunikacija.Instance.VratiListuUcenika(new Ucenik() { SelectCondition = condition });
                ucPrikazEvidencijeNastave.cbUcenici.DataSource = Komunikacija.Instance.VratiListuUcenika(new Ucenik() { SelectCondition = condition });
                ucPrikazEvidencijeNastave.cbUcenici.SelectedItem = null;

                foreach (DataGridViewColumn col in ucPrikazEvidencijeNastave.dgvUcenici.Columns)
                {
                    col.Visible = false;
                }
                ucPrikazEvidencijeNastave.dgvUcenici.Columns[1].Visible = true;
                ucPrikazEvidencijeNastave.dgvUcenici.Columns[2].Visible = true;
                ucPrikazEvidencijeNastave.dgvUcenici.Columns[1].HeaderText = "Ime";
                ucPrikazEvidencijeNastave.dgvUcenici.Columns[2].HeaderText = "Prezime";
                ucPrikazEvidencijeNastave.dgvUcenici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //ucPrikazEvidencijeNastave.dgvStavke.ReadOnly = true;
                ucPrikazEvidencijeNastave.dgvStavke.DataSource = evidencija.stavkeEvidencijeNastave;
                SrediDGVStavke();

                ucPrikazEvidencijeNastave.datePocetak.Value = evidencija.DatumPocetkaRada;
                ucPrikazEvidencijeNastave.chAktivna.Checked = evidencija.StatusAktivnosti;

                if (mode == WorkMode.READ)
                {
                    ucPrikazEvidencijeNastave.chAktivna.Enabled = false;
                    ucPrikazEvidencijeNastave.datePocetak.Enabled = false;
                    ucPrikazEvidencijeNastave.cbUcitelj.Enabled = false;
                    ucPrikazEvidencijeNastave.cbGrupa.Enabled = false;
                    ucPrikazEvidencijeNastave.btnPromeni.Visible = false;
                }
                else if (mode == WorkMode.UPDATE)
                {
                    ucPrikazEvidencijeNastave.chAktivna.Enabled = true;
                    ucPrikazEvidencijeNastave.datePocetak.Enabled = true;
                    ucPrikazEvidencijeNastave.cbUcitelj.Enabled = true;
                    ucPrikazEvidencijeNastave.cbGrupa.Enabled = false;
                    ucPrikazEvidencijeNastave.btnPromeni.Enabled = true;
                    ucPrikazEvidencijeNastave.btnPromeni.Visible = true;
                }

                ucPrikazEvidencijeNastave.btnDodajStavku.Click += DodajStavku;
                ucPrikazEvidencijeNastave.btnPrikazStavke.Click += PrikazStavke;
                ucPrikazEvidencijeNastave.btnPromeni.Click += Promeni;
                ucPrikazEvidencijeNastave.btnRestart.Click += RestartCB;
                ucPrikazEvidencijeNastave.cbUcenici.SelectedIndexChanged += cbUcenici_SelectedIndexChanged;
                //ucPrikazEvidencijeNastave.btnSacuvajPromene.Click += SacuvajPromeneNadStavkama;
                ucPrikazEvidencijeNastave.btnOmoguciIzmene.Click += OmoguciIzmene;

            }
            catch (Exception)
            {

                MessageBox.Show("Trenutno nije moguće prikazati evidenciju nastave");
            }
           
            return ucPrikazEvidencijeNastave;
        }

        

        private void Promeni(object sender, EventArgs e)
        {
            EvidencijaNastave novaEvidencija = globalna;
            novaEvidencija.StatusAktivnosti = ucPrikazEvidencijeNastave.chAktivna.Checked;
            novaEvidencija.DatumPocetkaRada = ucPrikazEvidencijeNastave.datePocetak.Value;
            novaEvidencija.Ucitelj.Id = ((Ucitelj)ucPrikazEvidencijeNastave.cbUcitelj.SelectedItem).Id;
            novaEvidencija.stavkeEvidencijeNastave = globalna.stavkeEvidencijeNastave;
            try
            {
                Komunikacija.Instance.PoveziSe();
                if (globalna.stavkeEvidencijeNastave != null)
                {
                    foreach (var stavka in globalna.stavkeEvidencijeNastave)
                    {

                        stavka.Evidencija = new EvidencijaNastave { IdEvidencijeNastave = globalna.IdEvidencijeNastave };
                    }
                }
                novaEvidencija.SelectCondition = $"idEvidencijaNastave = {novaEvidencija.IdEvidencijeNastave}";
                DialogResult res = MessageBox.Show("Da li ste sigurni da želite da promenite evidenciju nastave?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(res == DialogResult.Yes)
                {
                    Komunikacija.Instance.PromeniEvidencijuNastave(novaEvidencija);
                    MessageBox.Show("Sistem je zapamtio evidenciju nastave");
                    globalna = Komunikacija.Instance.PretraziEvidencijuNastave(globalna);
                    VratiPodesavanjaStavki(globalna);
                    SrediDGVStavke();
                }
                else
                {
                    MessageBox.Show("OK");
                }
                ucPrikazEvidencijeNastave.cbUcitelj.Enabled = false;
                ucPrikazEvidencijeNastave.datePocetak.Enabled = false;
                ucPrikazEvidencijeNastave.btnPromeni.Visible = false;
                ucPrikazEvidencijeNastave.btnOmoguciIzmene.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti evidenciju nastave");
            }
        }

        private void DodajStavku(object sender, EventArgs e)
        {
            UCradSaStavkomEvidencijeNastave ucStavka = new UCradSaStavkomEvidencijeNastave(globalna);
            MainCoordinator.Instance.ShowPomocna(globalna);
            SrediDGVStavke();


        }

        private void OmoguciIzmene(object sender, EventArgs e)
        {
            ucPrikazEvidencijeNastave.chAktivna.Enabled = true;
            ucPrikazEvidencijeNastave.datePocetak.Enabled = true;
            ucPrikazEvidencijeNastave.cbUcitelj.Enabled = true;
            ucPrikazEvidencijeNastave.cbGrupa.Enabled = false;
            ucPrikazEvidencijeNastave.btnPromeni.Enabled = true;
            ucPrikazEvidencijeNastave.btnPromeni.Visible = true;
            ucPrikazEvidencijeNastave.btnOmoguciIzmene.Visible = false;
        }
        private void SacuvajPromeneNadStavkama(object sender, EventArgs e)
        {
            Komunikacija.Instance.PoveziSe();

            if (globalna.stavkeEvidencijeNastave != null)
            {
                foreach (var stavka in globalna.stavkeEvidencijeNastave)
                {
                   
                    stavka.Evidencija = new EvidencijaNastave { IdEvidencijeNastave = globalna.IdEvidencijeNastave };
                }
            }
            DialogResult res = MessageBox.Show("Da li ste sigurni da želite da zapamtite promene nad stavkama evidencijer?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                
                try
                {
                    Komunikacija.Instance.SacuvajPromeneNadStavkama(globalna);

                    
                    MessageBox.Show("Promene su uspesno sacuvane!");
                    globalna = Komunikacija.Instance.PretraziEvidencijuNastave(globalna);
                    VratiPodesavanjaStavki(globalna);
                    SrediDGVStavke();


                }
                catch(Exception ex)
                {
                    MessageBox.Show("Trenutno nije moguće sačuvati promene nad stavkama evidencije");
                }
            }
            else
            {
                MessageBox.Show("OK");
            }
                
            
        }

        private void cbUcenici_SelectedIndexChanged(object sender, EventArgs e)
        {
            Komunikacija.Instance.PoveziSe();
            if (ucPrikazEvidencijeNastave.cbUcenici.SelectedItem == null)
            {
                //ucPrikazEvidencijeNastave.dgvStavke.DataSource = globalna.stavkeEvidencijeNastave;
                ucPrikazEvidencijeNastave.dgvStavke.DataSource = globalna.stavkeEvidencijeNastave;
            }
            else
            {
                Ucenik selektovaniUcenik = (Ucenik)ucPrikazEvidencijeNastave.cbUcenici.SelectedItem;
                List<StavkaEvidencijeNastave> selektovaneStavkePoUceniku =  globalna.stavkeEvidencijeNastave.Where(s => s.Ucenik.ImeUcenika == selektovaniUcenik.ImeUcenika && s.Ucenik.PrezimeUcenika == selektovaniUcenik.PrezimeUcenika).ToList();
                ucPrikazEvidencijeNastave.dgvStavke.DataSource = selektovaneStavkePoUceniku;
                //SrediDGVStavke();

            }
            ucPrikazEvidencijeNastave.dgvStavke.Columns[0].Visible = false;
            ucPrikazEvidencijeNastave.dgvStavke.Columns[ucPrikazEvidencijeNastave.dgvStavke.Columns.Count - 1].Visible = false;
        }

        private void RestartCB(object sender, EventArgs e)
        {
            ucPrikazEvidencijeNastave.cbUcenici.SelectedIndex = -1;
        }

        private void PrikazStavke(object sender, EventArgs e)
        {
            if (ucPrikazEvidencijeNastave.dgvStavke.CurrentRow == null)
            {
                MessageBox.Show("Niste odabrali stavku evidencije za prikaz!");
            }
            else
            {

                try
                {
                    Komunikacija.Instance.PoveziSe();
                    StavkaEvidencijeNastave stavka = Komunikacija.instance.PretraziStavkuEvidencijeNastave((StavkaEvidencijeNastave)ucPrikazEvidencijeNastave.dgvStavke.CurrentRow.DataBoundItem);
                    stavka.Evidencija = globalna;
                    MainCoordinator.Instance.ShowPomocna(stavka);
                    SrediDGVStavke();
                }
                catch (Exception)
                {

                    MessageBox.Show("Sistem ne moze da pronadje stavku evidencije nastave!", "Greksa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                


            }
        }
        private void SrediDGVStavke()
        {
            ucPrikazEvidencijeNastave.dgvStavke.DataSource = null;
            ucPrikazEvidencijeNastave.dgvStavke.DataSource = globalna.stavkeEvidencijeNastave;
            foreach (DataGridViewColumn col in ucPrikazEvidencijeNastave.dgvStavke.Columns)
            {
                col.Visible = false;
            }
            ucPrikazEvidencijeNastave.dgvStavke.Columns[1].Visible = true;
            ucPrikazEvidencijeNastave.dgvStavke.Columns[2].Visible = true;
            ucPrikazEvidencijeNastave.dgvStavke.Columns[3].Visible = true;
            ucPrikazEvidencijeNastave.dgvStavke.Columns[4].Visible = true;
            ucPrikazEvidencijeNastave.dgvStavke.Columns[5].Visible = true;
            ucPrikazEvidencijeNastave.dgvStavke.Columns[6].Visible = true;
            ucPrikazEvidencijeNastave.dgvStavke.Columns[8].Visible = true;
        }


        private void VratiPodesavanjaStavki(EvidencijaNastave evidencija)
        {
            foreach(StavkaEvidencijeNastave stavka in evidencija.stavkeEvidencijeNastave)
            {
                
                stavka.ZaBrisanje = false;
                stavka.ZaUbacivanje = false;
                stavka.ZaUpdate = false;
                
            }
        }
    }
}
