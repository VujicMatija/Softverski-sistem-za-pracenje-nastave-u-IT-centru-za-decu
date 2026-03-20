using Domeni;
using SistemskeOperacije;
using SistemskeOperacije.EvidencijaNastaveSO;
using SistemskeOperacije.GrupaUcenikaSO;
using SistemskeOperacije.KursSO;
using SistemskeOperacije.Licence;
using SistemskeOperacije.SertifikatSO;
using SistemskeOperacije.StavkeEvidencijeNastaveSO;
using SistemskeOperacije.UcenikSO;
using SistemskeOperacije.UciteljSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Server
{
    internal class Kontroler
    {
        private static Kontroler instance;
        public static Kontroler Instance
        {
            get
            {
                if (instance == null) instance = new Kontroler();
                return instance;
            }
        }
        private Kontroler()
        {
        }

        //UCITELJ

        public Ucitelj PrijaviUcitelja(Ucitelj u)
        {
            LoginSO so = new LoginSO(u);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Ucitelj> VratiListuSviUcitelji()
        {
            VratiListuSviUciteljiSO so = new VratiListuSviUciteljiSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public void UbaciUcitelja(Ucitelj ucitelj)
        {
            UbaciUciteljaSO so = new UbaciUciteljaSO(ucitelj);
            so.ExecuteTemplate();
        }

        public Ucitelj PretraziUcitelja(Ucitelj u)
        {
            PretraziUciteljaSO so = new PretraziUciteljaSO(u);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void PromeniUcitelja(Ucitelj ucitelj)
        {
            PromeniUciteljaSO so = new PromeniUciteljaSO(ucitelj);
            so.ExecuteTemplate();
        }

        public void ObrisiUcitelja(Ucitelj ucitelj)
        {
            ObrisiUciteljaSO so = new ObrisiUciteljaSO(ucitelj);
            so.ExecuteTemplate();
        }

        public List<Ucitelj> VratiListuUcitelja(Ucitelj ucitelj)
        {
            VratiListuUciteljaSO so = new VratiListuUciteljaSO(ucitelj);
            so.ExecuteTemplate();
            return so.Result;
        }

        //UCENIK

        public void UbaciUcenika(Ucenik ucenik)
        {
            UbaciUcenikaSO so = new UbaciUcenikaSO(ucenik);
            so.ExecuteTemplate();
        }

        public void ObrisiUcenika(Ucenik ucenik)
        {
            ObrisiUcenikaSO so = new ObrisiUcenikaSO(ucenik);
            so.ExecuteTemplate();
        }

        public void PromeniUcenika(Ucenik ucenik)
        {
            PromeniUcenikaSO so = new PromeniUcenikaSO(ucenik);
            so.ExecuteTemplate();
        }
        public List<Ucenik> VratiListuUcenika(Ucenik ucenik)
        {
            VratiListuUcenikaSO so = new VratiListuUcenikaSO(ucenik);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Ucenik> VratiListuSviUcenici()
        {
            VratiListuSviUceniciSO so = new VratiListuSviUceniciSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public Ucenik PretraziUcenika(Ucenik ucenik)
        {
            PretraziUcenikaSO so = new PretraziUcenikaSO(ucenik);
            so.ExecuteTemplate();
            return so.Result;
        }

        //GRUPA UCENIKA

        public void UbaciGrupuUcenika(GrupaUcenika grupa)
        {
            UbaciGrupuUcenikaSO so = new UbaciGrupuUcenikaSO(grupa);
            so.ExecuteTemplate();
        }

        public void ObrisiGrupuUcenika(GrupaUcenika grupa)
        {
            ObrisiGrupuUcenikaSO so = new ObrisiGrupuUcenikaSO(grupa);
            so.ExecuteTemplate();
        }

        public void PromeniGrupuUcenika(GrupaUcenika grupa)
        {
            PromeniGrupuUcenikaSO so = new PromeniGrupuUcenikaSO(grupa);
            so.ExecuteTemplate();
        }

        public List<GrupaUcenika> VratiListuGrupaUcenika(GrupaUcenika grupa)
        {
            VratiListuGrupaUcenikaSO so = new VratiListuGrupaUcenikaSO(grupa);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<GrupaUcenika> VratiListuSveGrupeUcenika()
        {
            VratiListuSveGrupeUcenikaSO so = new VratiListuSveGrupeUcenikaSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<string> VratiZauzeteTermine()
        {
            VratiListuGrupaUcenikaSO so = new VratiListuGrupaUcenikaSO(new GrupaUcenika() { Join = "gu join  EvidencijaNastave en on (en.idGrupa = gu.idGrupa) join Kurs k on (gu.idKurs = k.idKurs) ", SelectCondition = " en.statusAktivnosti = 1 "  });
            so.ExecuteTemplate();
            List<string> res = so.Result.Cast<GrupaUcenika>().ToList().Select(g => g.Termin).ToList();
            return res;
        }
        

        //KURS

        public void UbaciKurs(Kurs kurs)
        {
            UbaciKursSO so = new UbaciKursSO(kurs);
            so.ExecuteTemplate();
        }

        public void PromeniKurs(Kurs kurs)
        {
            PromeniKursSO so = new PromeniKursSO(kurs);
            so.ExecuteTemplate();
        }

        public List<Kurs> VratiListuSviKursevi()
        {
            VratiListuSviKurseviSO so = new VratiListuSviKurseviSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Kurs> VratiListuKurseva(Kurs kurs)
        {
            VratiListuKursevaSO so = new VratiListuKursevaSO(kurs);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Kurs PretraziKurs(Kurs kurs)
        {
            PretraziKursSO so = new PretraziKursSO(kurs);
            so.ExecuteTemplate();
            return so.Result;
        }

        //EVIDENCIJE NASTAVE

        public void KreirajEvidencijuNastave(EvidencijaNastave evidencijaNastave)
        {
            KreirajEvidencijuNastaveSO so = new KreirajEvidencijuNastaveSO(evidencijaNastave);
            so.ExecuteTemplate();
            
            

        }

        public EvidencijaNastave PretraziEvidencijuNastave(EvidencijaNastave evidencija)
        {
            PretraziEvidencijuNastaveSO so = new PretraziEvidencijuNastaveSO(evidencija);
            so.ExecuteTemplate();
            return so.Result;
        }
        public void PromeniEvidencijuNastave(EvidencijaNastave evidencija)
        {
            PromeniEvidencijuNastaveSO so = new PromeniEvidencijuNastaveSO(evidencija);
            so.ExecuteTemplate();
        }

        public void SacuvajPromeneNadStavkama(EvidencijaNastave evidencija)
        {
            SacuvajPromeneStavkiEvidencijeNastaveSO so = new SacuvajPromeneStavkiEvidencijeNastaveSO(evidencija);
            so.ExecuteTemplate();
        }

        public List<EvidencijaNastave> VratiListuSveEvidencijeNastave()
        {
            VratiListuSveEvidencijeNastaveSO so = new VratiListuSveEvidencijeNastaveSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<EvidencijaNastave> VratiListuEvidencijeNastave(EvidencijaNastave ev)
        {
            VratiListuEvidencijaNastaveSO so = new VratiListuEvidencijaNastaveSO(ev);
            so.ExecuteTemplate();
            return so.Result;
        }

        //STAVKA EVIDENCIJE NASTAVE

        public List<StavkaEvidencijeNastave> VratiListuStavkiEvidencijeNastave(StavkaEvidencijeNastave stavka)
        {
            VratiListuStavkiEvidencijeSO so = new VratiListuStavkiEvidencijeSO(stavka);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void UbaciStavkuEvidencijeNastave(StavkaEvidencijeNastave stavka)
        {
            UbaciStavkuEvidenceijeNastaveSO so = new UbaciStavkuEvidenceijeNastaveSO(stavka);
            so.ExecuteTemplate();
        }

        public void PromeniStavkuEvidencijeNastave(StavkaEvidencijeNastave stavka)
        {
            PromeniStavkuEvidencijeNastaveSO so = new PromeniStavkuEvidencijeNastaveSO(stavka);
            so.ExecuteTemplate();
            
        }

        //SERTIFIKAT

        public void UbaciSertifikat(Sertifikat sertifikat)
        {
            UbaciSertifikatSO so = new UbaciSertifikatSO(sertifikat);
            so.ExecuteTemplate();
        }

        public void PromeniSertifikat(Sertifikat sertifikat)
        {
            PromeniSertifikatSO so = new PromeniSertifikatSO(sertifikat);
            so.ExecuteTemplate();
        }

        public void ObrisiSertifikat(Sertifikat sertifikat)
        {
            ObrisiSertifikatSO so = new ObrisiSertifikatSO(sertifikat);
            so.ExecuteTemplate();
        }

        public List<Sertifikat> VratiListuSertifikata(Sertifikat sertifikat)
        {
            VratiListuSertifikataSO so = new VratiListuSertifikataSO(sertifikat);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Sertifikat> VratiListuSviSertifikati()
        {
            VratiListuSviSertifikatiSO so = new VratiListuSviSertifikatiSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        //LICENCE
        public void UbaciLicencu(Licenca licenca)
        {
            UbaciLicencuSO so = new UbaciLicencuSO(licenca);
            so.ExecuteTemplate();
        }

        public void PromeniLicencu(Licenca licenca)
        {
            PromeniLicencuSO so = new PromeniLicencuSO(licenca);
            so.ExecuteTemplate();
        }

        public List<Licenca> VratiListuSveLicence()
        {
            VratiListuSveLicenceSO so = new VratiListuSveLicenceSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Licenca> VratiListuLicenca(Licenca licenca)
        {
            VratiListuLicenceSO so = new VratiListuLicenceSO(licenca);
            so.ExecuteTemplate();
            return so.Result;
        }

        //UcenikGrupa

        public void UbaciUcenikGrupu(UcenikGrupa ucenikGrupa)
        {
            UbaciUcenikGrupuSO so = new UbaciUcenikGrupuSO(ucenikGrupa);
            so.ExecuteTemplate();
        }

    }
}
