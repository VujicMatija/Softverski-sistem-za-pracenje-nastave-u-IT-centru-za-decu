using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicki.Komunikacija
{
    public enum Operacija
    {

        //Evidencija nastave
        KreirajEvidencujuNastave,
        VratiListuSveEvidencijeNastave,
        VratiListuEvidencijaNastave,
        PromeniEvidencijuNastave,
        PretraziEvidencijuNastave,

        //Stavke evidencije nastave
        VratiListuStavkiEvidencijeNastave,
        KreirajStavkuEvidencijeNastave,
        PromeniStavkuEvidencijeNastave,

        //Ucitelj
        PrijaviUcitelja,
        PretraziUcitelja,
        PromeniUcitelja,
        ObrisiUcitelja,
        UbaciUcitelja,
        VratiListuSviUcitelji,
        VratiListuUcitelji,

        //Ucenici
        KreirajUcenika,
        PromeniUcenika,
        ObrisiUcenika,
        VratiListuUcenika,
        VratiListuSviUcenici,
        PretraziUcenika,


       //GrupeUcenika
        KreirajGrupuUcenika,
        PromeniGrupuUcenika,
        ObrisiGrupuUcenika,
        VratiListuSlobodneGrupe,
        VratiListuSveGrupeUcenika,
        VratiZauzeteTermine,
        VratiListuGrupeUcenika,

        //Kurs
        UbaciKurs,
        PromeniKurs,
        PretraziKurs,
        VratiListuSviKursevi,
        VratiListuKurseva,

        //Sertifikati
        
        VratiListuSviSertifikati,
        UbaciSertifikat,
        PromeniSertifikat,
        ObrisiSertifikat,
        VratiListuSertifikata,

        //LICENECE
        UbaciLicencu,
        PromeniLicencu,
        VratiListuSveLicence,
        VratiListuLicence,

        //UCENIK GRUPA
        KreirajUcenikGrupa,
        SacuvajPromeneNadStavkama,
        PretraziGrupuUcenika,
        PretraziLicencu,
        PretraziSertifikat,
        PretraziStavkuEvidencijeNastave


        //VratiListuEvidencijeNastavePoKursu,
        //VratiListuLicencePoSertifikatu,
        //VratiListuLicencePoUcitelju,
        //VratiListuSertifikataPoNazivu,
        //VratiListuSertifikataPoUcitelju,
        //vratiListuGrupeUcenikaPoUcitelju,
        // VratiListuGrupeUcenikaPoUceniku,
        //VratiListuGrupeUcenikaPoKursu,
        // PretraziUcenikaPoImenu,
        //VratiListuUciteljaPoSertifikatu,
        //VratiListuUciteljaPoUcitelju,
        // VratiListuStavkiEvidencijeNastavePoUceniku,


    }
}
