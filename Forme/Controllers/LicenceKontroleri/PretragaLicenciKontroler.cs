using Domeni;
using Forme.User_controlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers.LicenceKontroleri
{
    internal class PretragaLicenciKontroler
    {
        UCpretraziLicencu ucPretraziLicencu;

        internal Control CreatePretraziLicencu()
        {
            ucPretraziLicencu = new UCpretraziLicencu();
            try
            {
                ucPretraziLicencu.cbUcitelj.DataSource = Komunikacija.Instance.VratiListuSviUcitelji();
                ucPretraziLicencu.cbSertifikat.DataSource = Komunikacija.Instance.VratiListuSviSertifikati();
                ucPretraziLicencu.cbSertifikat.SelectedIndex = -1;
                ucPretraziLicencu.cbUcitelj.SelectedIndex = -1;
                ucPretraziLicencu.dgvLicence.DataSource = Komunikacija.Instance.VratiListuSveLicence();
                SrediDGV();
                ucPretraziLicencu.btnPretazi.Click += Pretraga;
                ucPretraziLicencu.btnPrikazi.Click += Prikazi;
                ucPretraziLicencu.btnResetuj.Click += Resetuj;
            }
            catch (Exception)
            {
                MessageBox.Show("Trenutno nije moguće pretražiti licence!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
            return ucPretraziLicencu;
        }

        

        private void Pretraga(object sender, EventArgs e)
        {
            try
            {
                string condition = "";
                string join = "l join Ucitelj u on (l.idUcitelj = u.idUcitelj) join Sertifikat s on (s.idSertifikat = l.idSertifikat)";
                if (ucPretraziLicencu.cbSertifikat.SelectedItem != null && ucPretraziLicencu.cbUcitelj.SelectedItem != null)
                {
                    Ucitelj ucitelj = (Ucitelj)ucPretraziLicencu.cbUcitelj.SelectedItem;
                    Sertifikat sertifikat = (Sertifikat)ucPretraziLicencu.cbSertifikat.SelectedItem;
                    condition = $"s.idSertifikat = {sertifikat.IdSertifikata} and u.idUcitelj = {ucitelj.Id}";
                    ucPretraziLicencu.dgvLicence.DataSource = Komunikacija.Instance.vratiListuLicence(new Licenca() { SelectCondition = condition });

                }
                else if (ucPretraziLicencu.cbSertifikat.SelectedItem != null)
                {
                    Sertifikat sertifikat = (Sertifikat)ucPretraziLicencu.cbSertifikat.SelectedItem;
                    condition = $"s.idSertifikat = {sertifikat.IdSertifikata}";
                    ucPretraziLicencu.dgvLicence.DataSource = Komunikacija.Instance.vratiListuLicence(new Licenca() { SelectCondition = condition });

                }
                else if (ucPretraziLicencu.cbUcitelj.SelectedItem != null)
                {
                    Ucitelj ucitelj = (Ucitelj)ucPretraziLicencu.cbUcitelj.SelectedItem;
                    condition = $"u.idUcitelj = {ucitelj.Id}";
                    ucPretraziLicencu.dgvLicence.DataSource = Komunikacija.Instance.vratiListuLicence(new Licenca() { SelectCondition = condition });

                }
                else
                {
                    ucPretraziLicencu.dgvLicence.DataSource = Komunikacija.Instance.VratiListuSveLicence();
                }
                SrediDGV();
                ucPretraziLicencu.dgvLicence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception)
            {
                MessageBox.Show("Trenutno nije moguće pretražiti grupe učenika!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Resetuj(object sender, EventArgs e)
        {
            try
            {
                ucPretraziLicencu.cbUcitelj.SelectedItem = null;
                ucPretraziLicencu.cbSertifikat.SelectedItem = null;
                ucPretraziLicencu.dgvLicence.DataSource = Komunikacija.Instance.VratiListuSveLicence();
            }
            catch (Exception)
            {
                MessageBox.Show("Greška prilikom rada sa serverom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void Prikazi(object sender, EventArgs e)
        {
            try
            {
                if(ucPretraziLicencu.dgvLicence.CurrentRow != null)
                {
                    Licenca licenca = Komunikacija.Instance.PretraziLicencu((Licenca)ucPretraziLicencu.dgvLicence.CurrentRow.DataBoundItem);
                    MainCoordinator.Instance.ShowDodajLicencuForma(licenca);
                    
                }
                else
                {
                    MessageBox.Show("Niste odabrali licencu za prikaz", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Komunikacija.Instance.VratiListuSveLicence();
                SrediDGV();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom prikaza licence!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SrediDGV()
        {
            foreach (DataGridViewColumn col in ucPretraziLicencu.dgvLicence.Columns)
            {
                col.Visible = false;
            }
            ucPretraziLicencu.dgvLicence.Columns[0].Visible = true;
            ucPretraziLicencu.dgvLicence.Columns[1].Visible = true;
            ucPretraziLicencu.dgvLicence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
