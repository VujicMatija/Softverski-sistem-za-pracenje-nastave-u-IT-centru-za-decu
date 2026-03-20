using Domeni;
using Forme.User_controlers;
using Forme.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers.EvidencijaNastaveKontroleri
{
    internal class PretraziEvidencijuNastaveKontroler
    {
        UCPretraziEvidencijuNastave ucPretraziEvidencijuNastave;

        internal Control CreatePretraziEvidencijuNastave()
        {
            ucPretraziEvidencijuNastave = new UCPretraziEvidencijuNastave();
            try
            {
                Komunikacija.Instance.PoveziSe();
                BindingList<Ucitelj> sviUcitelji = Komunikacija.Instance.VratiListuSviUcitelji();
                ucPretraziEvidencijuNastave.cbUcitelj.DataSource = sviUcitelji;
                ucPretraziEvidencijuNastave.cbUcitelj.SelectedItem = null;
                BindingList<GrupaUcenika> sveGrupeUcenika = Komunikacija.Instance.VratiListuSveGrupeUcenika();
                ucPretraziEvidencijuNastave.cbGrupa.DataSource = sveGrupeUcenika;
                ucPretraziEvidencijuNastave.cbGrupa.SelectedItem = null;
                BindingList<Ucenik> sviUcenici = Komunikacija.Instance.VratiListuSviUcenici();
                ucPretraziEvidencijuNastave.cbUcenik.DataSource = sviUcenici;
                ucPretraziEvidencijuNastave.cbUcenik.SelectedItem = null;
                ucPretraziEvidencijuNastave.dgvEvidencije.DataSource = Komunikacija.Instance.VratiListuSveEvidencijeNastave();
                SrediDGV();

                
                ucPretraziEvidencijuNastave.btnOcistiFiltere.Click += OcistiFiltere;
                ucPretraziEvidencijuNastave.btnPretraziEvidencije.Click += PretraziEvidencije;
                ucPretraziEvidencijuNastave.btnPrikazi.Click += Prikazi;
                ucPretraziEvidencijuNastave.btnRestart1.Click += Restart1;
                ucPretraziEvidencijuNastave.btnRestart2.Click += Restart2;
                ucPretraziEvidencijuNastave.btnRestart3.Click += Restart3;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Pretraga evidencija trenutno nije moguća");
            }
           

            return ucPretraziEvidencijuNastave;
        }

        private void PretraziEvidencije(object sender, EventArgs e)
        {
            Komunikacija.Instance.PoveziSe();
            ucPretraziEvidencijuNastave.dgvEvidencije.DataSource = null;
            string condition = "";
            string join = " ";
            if(ucPretraziEvidencijuNastave.cbGrupa.SelectedItem != null)
            {
                GrupaUcenika grupa = (GrupaUcenika)ucPretraziEvidencijuNastave.cbGrupa.SelectedItem;
                condition += $" gu.idGrupa = {grupa.IdGrupe}";
                join = "  ev JOIN GrupaUcenika gu ON ev.idGrupa = gu.idGrupa JOIN Ucitelj u ON ev.idUcitelja = u.idUcitelj ";


            }
            
            if(ucPretraziEvidencijuNastave.cbUcitelj.SelectedItem!= null)
            {
                Ucitelj ucitelj = (Ucitelj)ucPretraziEvidencijuNastave.cbUcitelj.SelectedItem;
                if (condition != "")
                {
                    condition += " and ";
                }
                condition += $" ev.idUcitelja =  {ucitelj.Id}";
                join = "  ev JOIN GrupaUcenika gu ON ev.idGrupa = gu.idGrupa JOIN Ucitelj u ON ev.idUcitelja = u.idUcitelj ";

            }

            if (ucPretraziEvidencijuNastave.cbUcenik.SelectedItem != null)
            {
                Ucenik ucenik = (Ucenik)ucPretraziEvidencijuNastave.cbUcenik.SelectedItem;
                if (condition != "")
                {
                    condition += " and ";
                }
                condition += $" ug.idUcenik =  {ucenik.IdUcenika}";
                join = "  ev JOIN GrupaUcenika gu ON ev.idGrupa = gu.idGrupa JOIN Ucitelj u ON ev.idUcitelja = u.idUcitelj join UcenikGrupa ug on (ug.idGrupaUcenika= gu.idGrupa)";



            }

            EvidencijaNastave evidencija = new EvidencijaNastave() { SelectCondition = condition , Join = join, SelectValues = "ev.idEvidencijaNastave, u.imeUcitelja, u.prezimeUcitelja, gu.oznakaGrupe" };
            try
            {
                if (condition == "")
                {
                    ucPretraziEvidencijuNastave.dgvEvidencije.DataSource =
                   Komunikacija.Instance.VratiListuSveEvidencijeNastave();
                }
                else
                {
                    ucPretraziEvidencijuNastave.dgvEvidencije.DataSource =
                   Komunikacija.Instance.VratiListuEvidencijaNastave(evidencija);
                }
                

                SrediDGV();
                if (ucPretraziEvidencijuNastave.dgvEvidencije.Rows.Count == 0)
                {
                    MessageBox.Show("Sistem ne može da nađe evidencije nastave po zadatim kriterijuma!");
                }
                else
                {
                    MessageBox.Show("Sistem je našao evidencije nastave po zadatim kriterijuma!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sistem ne može da nađe evidencije nastave po zadatim kriterijuma!");
            }
           
            
        }

        private void SrediDGV()
        {
            foreach(DataGridViewColumn col in ucPretraziEvidencijuNastave.dgvEvidencije.Columns)
            {
                col.Visible = false;
            }
            ucPretraziEvidencijuNastave.dgvEvidencije.Columns[3].Visible = true;
            ucPretraziEvidencijuNastave.dgvEvidencije.Columns[4].Visible = true;
            ucPretraziEvidencijuNastave.dgvEvidencije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Prikazi(object sender, EventArgs e)
        {
            Komunikacija.Instance.PoveziSe();
            EvidencijaNastave ev = new EvidencijaNastave();
            if (ucPretraziEvidencijuNastave.dgvEvidencije.CurrentRow == null)
            {
                MessageBox.Show("Niste izabrali evidenciju za prikaz!");
            }
            else
            {
                try
                {
                    ev = Komunikacija.Instance.PretraziEvidencijuNastave((EvidencijaNastave)ucPretraziEvidencijuNastave.dgvEvidencije.CurrentRow.DataBoundItem);
                    MessageBox.Show("Sistem je našao evidenciju nastave!");
                    MainCoordinator.Instance.ShowPomocna(ev, WorkMode.READ);
                }
                catch (Exception)
                {

                    MessageBox.Show("Sistem ne može da nađe evidenciju nastave");
                }
  


               
            }
        }

        private void Izmeni(object sender, EventArgs e)
        {
            Komunikacija.Instance.PoveziSe();
            EvidencijaNastave ev = new EvidencijaNastave();
            if (ucPretraziEvidencijuNastave.dgvEvidencije.CurrentRow == null)
            {
                MessageBox.Show("Niste izabrali evidenciju za prikaz!");
            }
            else
            {
                try
                {
                    ev = Komunikacija.Instance.PretraziEvidencijuNastave((EvidencijaNastave)ucPretraziEvidencijuNastave.dgvEvidencije.CurrentRow.DataBoundItem);
                    MainCoordinator.Instance.ShowPomocna(ev, Utils.WorkMode.UPDATE);
                }
                catch (Exception)
                {
                    MessageBox.Show("Prikaz evidencije nastave trenutno nije moguće");
                }
                
        
            }
        }

        private void Restart1(object sender, EventArgs e)
        {
            ucPretraziEvidencijuNastave.cbUcitelj.SelectedItem = null;
        }

        private void Restart2(object sender, EventArgs e)
        {
            ucPretraziEvidencijuNastave.cbUcenik.SelectedItem = null;
        }

        private void Restart3(object sender, EventArgs e)
        {
            ucPretraziEvidencijuNastave.cbGrupa.SelectedItem = null;
        }

        private void OcistiFiltere(object sender, EventArgs e)
        {
            Komunikacija.Instance.PoveziSe();
            try
            {
                ucPretraziEvidencijuNastave.cbUcitelj.SelectedItem = null;
                ucPretraziEvidencijuNastave.cbUcenik.SelectedItem = null;
                ucPretraziEvidencijuNastave.cbGrupa.SelectedItem = null;
                ucPretraziEvidencijuNastave.dgvEvidencije.DataSource = Komunikacija.Instance.VratiListuSveEvidencijeNastave();
                SrediDGV();
            }
            catch (Exception)
            {

                MessageBox.Show("Greška prilikom rada!");
            }
            

        }

    }
}
