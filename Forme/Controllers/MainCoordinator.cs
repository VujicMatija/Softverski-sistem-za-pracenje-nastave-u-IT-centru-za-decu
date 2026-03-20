using Domeni;
using Forme.Controllers.EvidencijaNastaveKontroleri;
using Forme.Controllers.GrupaUcenikaKontroleri;
using Forme.Controllers.LicenceKontroleri;
using Forme.Controllers.SertifikatKontroleri;
using Forme.Controllers.StavkeEvidencijeKontroler;
using Forme.Controllers.UcenikGrupaKontroleri;
using Forme.Controllers.UcenikKontroleri;
using Forme.Controllers.UciteljKontroleri;
using Forme.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.Controllers
{
    internal class MainCoordinator
    {

        private Glavna glvFrm;
        private DodajLicencuForma dodajLicencuForma;
        private PomocnaForma pomocnaFrm;
        private LogIn logInFrm;

        private PrikazUciteljaKontroler prikazUciteljaKontroler;
        private KreirajUciteljaKontroler kreirajUciteljaKontroler;
        private PretragaUciteljaKontroler pretragaUciteljaKontroler;
        private PretragaLicenciKontroler pretragaLicenciKontroler;
        private KreirajLicencuKontroler kreirajLicencuKontroler;
        private KreirajEvidencijuNastaveKontroler kreirajEvidencijuNastaveKontroler;
        private PretraziEvidencijuNastaveKontroler pretraziEvidencijuNastaveKontroler;
        private PrikazEvidencijeNastaveKontroler prikazEvidencijeNastaveKontroler;
        private KreirajUcenikaKontroler kreirajUcenikaKontroler;
        private PretragaUcenikaKontroler pretragaUcenikaKontroler;
        private KreirajGrupuUcenikaKontroler kreirajGrupuUcenikaKontroler;
        private PretraziGrupuUcenikaKontroler pretraziGrupuUcenikaKontroler;
        private KursKontroler kursKontroler;
        private RadSaSertifikatomKontroler sertfikatKontroler;
        private RadSaStavkomEvidencijeKontroler radSaStavkomEvidencijeKontroler;
        private UcenikGrupaKontroler ucenikGrupaKontroler;
        private LogInKontroler logInKontroler;

        private static MainCoordinator instance;

        public static MainCoordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainCoordinator();
                }

                return instance;
            }
        }

        private MainCoordinator()
        {
            prikazUciteljaKontroler = new PrikazUciteljaKontroler();
            kreirajUciteljaKontroler = new KreirajUciteljaKontroler();
            pretragaUciteljaKontroler = new PretragaUciteljaKontroler();
            pretragaLicenciKontroler = new PretragaLicenciKontroler();
            kreirajLicencuKontroler = new KreirajLicencuKontroler();
            kreirajEvidencijuNastaveKontroler = new KreirajEvidencijuNastaveKontroler();
            pretraziEvidencijuNastaveKontroler = new PretraziEvidencijuNastaveKontroler();
            prikazEvidencijeNastaveKontroler = new PrikazEvidencijeNastaveKontroler();
            kreirajUcenikaKontroler = new KreirajUcenikaKontroler();
            pretragaUcenikaKontroler = new PretragaUcenikaKontroler();
            kreirajGrupuUcenikaKontroler = new KreirajGrupuUcenikaKontroler();
            pretraziGrupuUcenikaKontroler = new PretraziGrupuUcenikaKontroler();
            kursKontroler = new KursKontroler();
            sertfikatKontroler = new RadSaSertifikatomKontroler();
            radSaStavkomEvidencijeKontroler = new RadSaStavkomEvidencijeKontroler();
            ucenikGrupaKontroler = new UcenikGrupaKontroler();
            logInKontroler = new LogInKontroler();
            
        }

        internal void ShowMain(Ucitelj ucitelj)
        {
            glvFrm = new Glavna(ucitelj);
            Debug.WriteLine("GLAVNA KREIRANA");
            glvFrm.ShowDialog();
        }

       

        internal void ShowPrikazUcitelja(Ucitelj ucitelj)
        {
            glvFrm.ChangePanel(prikazUciteljaKontroler.CreatePrikazUcitelja(ucitelj));
        }

        internal void ShowKreirajUcitelja()
        {
            glvFrm.ChangePanel(kreirajUciteljaKontroler.CreateKreirajUcitelja());
        }

        internal void ShowPretraziUcitelja()
        {
            glvFrm.ChangePanel(pretragaUciteljaKontroler.CreatePretragaUcitelja());
        }

        internal void ShowPretragaLicenci()
        {
            glvFrm.ChangePanel(pretragaLicenciKontroler.CreatePretraziLicencu());
        }

        internal void ShowKreirajEvidencijuNastave()
        {
            glvFrm.ChangePanel(kreirajEvidencijuNastaveKontroler.CreateKreirajEvidencijuNastave());
        }

        internal void ShowPretraziEvidencijeNastave()
        {
            glvFrm.ChangePanel(pretraziEvidencijuNastaveKontroler.CreatePretraziEvidencijuNastave());
        }


        internal void ShowKreiranjeUcenika()
        {
            glvFrm.ChangePanel(kreirajUcenikaKontroler.CreateKreirajUcenika());
        }

        internal void ShowKreiranjeUcenika(Ucenik ucenik)
        {
            glvFrm.ChangePanel(kreirajUcenikaKontroler.CreateKreirajUcenika(ucenik));
        }

        internal void ShowPretragaUcenika()
        {
            glvFrm.ChangePanel(pretragaUcenikaKontroler.CreatePretraziUcenika());
        }

        internal void ShowKreirajGrupaUcenika(GrupaUcenika grupa = null, WorkMode mode = WorkMode.CREATE)
        {
            glvFrm.ChangePanel(kreirajGrupuUcenikaKontroler.CreateKreirajGrupuUcenika(mode, grupa));
        }

        internal void ShowPretraziGrupuUcenika()
        {
            glvFrm.ChangePanel(pretraziGrupuUcenikaKontroler.CreatePretragaGrupa());
        }

        internal void ShowRadSaKursom()
        {
            glvFrm.ChangePanel(kursKontroler.CreateRadSaKursom());
        }

        internal void ShowRadSaKursom(Kurs kurs)
        {
            glvFrm.ChangePanel(kursKontroler.CreateRadSaKursom(kurs));
        }

        internal void ShowRadSaSertifikatom()
        {
            glvFrm.ChangePanel(sertfikatKontroler.CreateRadSaSertifikatom());
        }

        internal void ShowRadSaSertifikatom(Sertifikat sertifikat)
        {
            glvFrm.ChangePanel(sertfikatKontroler.CreateRadSaSertifikatom(sertifikat));
        }

        //POMOCNA FORMA

        internal void ShowPomocna(EvidencijaNastave ev, WorkMode mode)
        {
            pomocnaFrm = new PomocnaForma(ev, mode);
            pomocnaFrm.ShowDialog();
        }

        internal void ShowPomocna(EvidencijaNastave ev)
        {
            pomocnaFrm = new PomocnaForma(ev);
            pomocnaFrm.ShowDialog();
        }

        internal void ShowPomocna(StavkaEvidencijeNastave stavka)
        {
            pomocnaFrm = new PomocnaForma(stavka);
            pomocnaFrm.ShowDialog();
        }

        internal void ShowPomocna(GrupaUcenika grupa)
        {
            pomocnaFrm = new PomocnaForma(grupa);
            pomocnaFrm.ShowDialog();
        }

        internal void ShowPrikazEvidencijeNastave(EvidencijaNastave ev, WorkMode mode)
        {
            pomocnaFrm.ChangePanel(prikazEvidencijeNastaveKontroler.CreatePrikazEvidencijeNastave(ev, mode));
        }
        
        internal void ShowDodajUcenika(GrupaUcenika grupa)
        {
            pomocnaFrm.ChangePanel(ucenikGrupaKontroler.CreateDodajUcenikaUGrupu(grupa));
        }

        internal void ShowRadSaStavkomEvidencijeNastave(EvidencijaNastave evidencija)
        {
            pomocnaFrm.ChangePanel(radSaStavkomEvidencijeKontroler.CreateRadSaStavkomEvidencijeNastave(evidencija));
        }

        internal void ShowRadSaStavkomEvidencijeNastave(StavkaEvidencijeNastave stavka)
        {
            pomocnaFrm.ChangePanel(radSaStavkomEvidencijeKontroler.CreateRadSaStavkomEvidencijeNastave(stavka));
        }

        //DODAJ LICENCU FORMA

        internal void ShowDodajLicencuForma(Ucitelj ucitelj)
        {

            dodajLicencuForma = new DodajLicencuForma(ucitelj);
            dodajLicencuForma.ShowDialog();
        }

        internal void ShowDodajLicencuForma(Licenca licenca)
        {

            dodajLicencuForma = new DodajLicencuForma(licenca);
            dodajLicencuForma.ShowDialog();
        }

        internal void ShowKreirajLicencu(Ucitelj ucitelj)
        {
            dodajLicencuForma.ChangePanel(kreirajLicencuKontroler.CreateKreirajLicencu(ucitelj));
        }

        internal void ShowKreirajLicencu(Licenca licenca)
        {
            dodajLicencuForma.ChangePanel(kreirajLicencuKontroler.CreateKreirajLicencu(licenca));
        }

        // LOG IN

        internal void ShowLogIn()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            logInFrm = new LogIn();
            Application.Run(logInFrm);
            
            
        }

        internal void ShowLogInControl()
        {
            logInFrm.ChangePanel(logInKontroler.CreateLogIn());
        }

    }
}
