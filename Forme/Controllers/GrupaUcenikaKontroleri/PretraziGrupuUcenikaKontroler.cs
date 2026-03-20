using Domeni;
using Forme.User_controlers;
using Forme.Utils;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers.GrupaUcenikaKontroleri
{
    internal class PretraziGrupuUcenikaKontroler
    {
        UCpretraziGrupuUcenika ucPretragaGrupa;

        internal Control CreatePretragaGrupa()
        {
            ucPretragaGrupa = new UCpretraziGrupuUcenika();
            try
            {
                Komunikacija.Instance.PoveziSe();
                ucPretragaGrupa.cbKursevi.DataSource = Komunikacija.Instance.VratiListuSviKursevi();
                ucPretragaGrupa.cbKursevi.SelectedItem = null;
                ucPretragaGrupa.dgvGrupeUcenika.DataSource = Komunikacija.Instance.VratiListuSveGrupeUcenika();
                SrediDGV();

                ucPretragaGrupa.btnPretrazi.Click += Pretrazi;
                ucPretragaGrupa.btnPrikaziGrupu.Click += PrikaziGrupu;
            }
            catch (Exception)
            {

                MessageBox.Show("Trenutno nije moguće pretražiti grupe učenika!","Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

            return ucPretragaGrupa;
        }

        

        private void Pretrazi(object sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                if (ucPretragaGrupa.cbKursevi.SelectedItem == null)
                {
                    
                    ucPretragaGrupa.dgvGrupeUcenika.DataSource = Komunikacija.Instance.VratiListuSveGrupeUcenika();
                    SrediDGV();
                }
                else
                {
                    Kurs k = (Kurs)ucPretragaGrupa.cbKursevi.SelectedItem;
                    GrupaUcenika grupaUcenika = new GrupaUcenika();
                    grupaUcenika.Join = "gu join Kurs k on(gu.idKurs = k.idKurs) ";
                    grupaUcenika.SelectCondition = $"k.idKurs = {k.IdKursa}";
                    List<GrupaUcenika> pretrazene = Komunikacija.Instance.vratiListuGrupaUcenika(grupaUcenika).ToList();

                    ucPretragaGrupa.dgvGrupeUcenika.DataSource = pretrazene;
                    if (pretrazene.IsNullOrEmpty())
                    {
                        MessageBox.Show("Sistem ne može da nađe grupe učenika po zadatim kriterijumima!");
                    }
                    else
                    {
                        MessageBox.Show("Sistem je našao grupe učenika po zadatim kriterijumima!");
                    }
                    ucPretragaGrupa.dgvGrupeUcenika.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    ucPretragaGrupa.dgvGrupeUcenika.Columns[0].Visible = false;

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Trenutno nije moguće pretražiti grupe učenika!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        

        private void PrikaziGrupu(object sender, EventArgs e)
        {
            if (ucPretragaGrupa.dgvGrupeUcenika.CurrentRow != null)
            {
                try
                {
                    Komunikacija.Instance.PoveziSe();
                    GrupaUcenika selektova = (GrupaUcenika)ucPretragaGrupa.dgvGrupeUcenika.CurrentRow.DataBoundItem;
                    selektova.Join = "gu join Kurs k on(gu.idKurs = k.idKurs)";
                    GrupaUcenika grupa = Komunikacija.Instance.PretraziGrupuUcenika(selektova);
                    MessageBox.Show("Sistem je našao grupu učenika!");
                    MainCoordinator.Instance.ShowKreirajGrupaUcenika(grupa, WorkMode.READ);
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistem ne može da nađe grupu učenika!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
               
                

            }
            else
            {
                MessageBox.Show("Morate odabrati grupu učenika", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SrediDGV()
        {
            foreach (DataGridViewColumn col in ucPretragaGrupa.dgvGrupeUcenika.Columns)
            {
                col.Visible = false;
            }
            ucPretragaGrupa.dgvGrupeUcenika.Columns[1].Visible = true;
            ucPretragaGrupa.dgvGrupeUcenika.Columns[2].Visible = true;
            ucPretragaGrupa.dgvGrupeUcenika.Columns[3].Visible = true;
            ucPretragaGrupa.dgvGrupeUcenika.Columns[4].Visible = true;
            ucPretragaGrupa.dgvGrupeUcenika.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

    }
}
