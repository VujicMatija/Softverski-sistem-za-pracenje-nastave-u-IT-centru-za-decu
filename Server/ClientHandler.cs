using BrokerBazePodataka;
using Domeni;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Zajednicki.Komunikacija;

namespace Server
{
    internal class ClientHandler
    {

        private Socket soket;
       

        private JsonNetworkSerializer serializer;


        public ClientHandler(Socket soket)
        {
            this.soket = soket;
           
            serializer = new JsonNetworkSerializer(this.soket);
        }

        public void Handle()
        {
            try
            {

                while (true)
                {
                    Zahtev zahtev = serializer.Receive<Zahtev>();
                    ProcesuirajZahtev(zahtev);

                }


            }
            catch (IOException ie)
            {
                Debug.Write(">>>>> IE: " + ie.Message);
            }
            catch (SocketException se)
            {
                Debug.Write(">>>>> SE: " + se.Message);
            }
            catch (Exception ex)
            {
                Debug.Write(">>>>> EX: " + ex.Message);
            }
        }

        private void ProcesuirajZahtev(Zahtev zahtev)
        {
            Odgovor odgovor = new Odgovor();
            odgovor.Uspesno = true;
            try
            {
                switch (zahtev.Operacija)
                {

                    case Operacija.PrijaviUcitelja:
                        odgovor.Objekat = Kontroler.Instance.PrijaviUcitelja(serializer.ReadType<Ucitelj>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;

                    case Operacija.PretraziUcitelja:
                        odgovor.Objekat = Kontroler.Instance.PretraziUcitelja(serializer.ReadType<Ucitelj>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.PromeniUcitelja:
                        Kontroler.Instance.PromeniUcitelja(serializer.ReadType<Ucitelj>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.ObrisiUcitelja:
                        Kontroler.Instance.ObrisiUcitelja(serializer.ReadType<Ucitelj>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.UbaciUcitelja:
                        Kontroler.Instance.UbaciUcitelja(serializer.ReadType<Ucitelj>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuSviSertifikati:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSviSertifikati();
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuSviUcitelji:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSviUcitelji();
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuUcitelji:
                        odgovor.Objekat = Kontroler.Instance.VratiListuUcitelja(serializer.ReadType<Ucitelj>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.UbaciLicencu:
                        Kontroler.Instance.UbaciLicencu(serializer.ReadType<Licenca>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.PromeniLicencu:
                        Kontroler.Instance.PromeniLicencu(serializer.ReadType<Licenca>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuSveLicence:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSveLicence();
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuLicence:
                        odgovor.Objekat = Kontroler.Instance.VratiListuLicenca(serializer.ReadType<Licenca>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.KreirajEvidencujuNastave:
                        Kontroler.Instance.KreirajEvidencijuNastave(serializer.ReadType<EvidencijaNastave>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuUcenika:
                        odgovor.Objekat = Kontroler.Instance.VratiListuUcenika(serializer.ReadType<Ucenik>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.PretraziKurs:
                        odgovor.Objekat = Kontroler.Instance.PretraziKurs(serializer.ReadType<Kurs>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuSveGrupeUcenika:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSveGrupeUcenika();
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuSviUcenici:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSviUcenici();
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuSveEvidencijeNastave:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSveEvidencijeNastave();
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuEvidencijaNastave:
                        odgovor.Objekat = Kontroler.Instance.VratiListuEvidencijeNastave(serializer.ReadType<EvidencijaNastave>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuStavkiEvidencijeNastave:
                        odgovor.Objekat = Kontroler.Instance.VratiListuStavkiEvidencijeNastave(serializer.ReadType<StavkaEvidencijeNastave>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.PromeniEvidencijuNastave:
                        Kontroler.Instance.PromeniEvidencijuNastave(serializer.ReadType<EvidencijaNastave>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.KreirajStavkuEvidencijeNastave:
                        Kontroler.Instance.UbaciStavkuEvidencijeNastave(serializer.ReadType<StavkaEvidencijeNastave>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.PromeniStavkuEvidencijeNastave:
                        Kontroler.Instance.PromeniStavkuEvidencijeNastave(serializer.ReadType<StavkaEvidencijeNastave>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.KreirajUcenika:
                        Kontroler.Instance.UbaciUcenika(serializer.ReadType<Ucenik>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.ObrisiUcenika:
                        Kontroler.Instance.ObrisiUcenika(serializer.ReadType<Ucenik>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.PromeniUcenika:
                        Kontroler.Instance.PromeniUcenika(serializer.ReadType<Ucenik>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiZauzeteTermine:
                        //HandleVratiZauzeteTermine(zahtev);
                        odgovor.Objekat = Kontroler.Instance.VratiZauzeteTermine();
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuSviKursevi:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSviKursevi();
                        serializer.Send(odgovor);
                        break;
                    case Operacija.KreirajGrupuUcenika:
                        //HandleKreirajGrupuUcenika(zahtev);
                        Kontroler.Instance.UbaciGrupuUcenika(serializer.ReadType<GrupaUcenika>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.PromeniGrupuUcenika:
                        Kontroler.Instance.PromeniGrupuUcenika(serializer.ReadType<GrupaUcenika>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.ObrisiGrupuUcenika:
                        Kontroler.Instance.ObrisiGrupuUcenika(serializer.ReadType<GrupaUcenika>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.UbaciKurs:
                        Kontroler.Instance.UbaciKurs(serializer.ReadType<Kurs>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.PromeniKurs:
                        Kontroler.Instance.PromeniKurs(serializer.ReadType<Kurs>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuKurseva:
                        odgovor.Objekat = Kontroler.Instance.VratiListuKurseva(serializer.ReadType<Kurs>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.UbaciSertifikat:
                        Kontroler.Instance.UbaciSertifikat(serializer.ReadType<Sertifikat>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.PromeniSertifikat:
                        Kontroler.Instance.PromeniSertifikat(serializer.ReadType<Sertifikat>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.ObrisiSertifikat:
                        Kontroler.Instance.ObrisiSertifikat(serializer.ReadType<Sertifikat>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.KreirajUcenikGrupa:
                        Kontroler.Instance.UbaciUcenikGrupu(serializer.ReadType<UcenikGrupa>(zahtev.Objekat));
                        break;
                    case Operacija.VratiListuGrupeUcenika:
                        odgovor.Objekat = Kontroler.Instance.VratiListuGrupaUcenika(serializer.ReadType<GrupaUcenika>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.VratiListuSertifikata:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSertifikata(serializer.ReadType<Sertifikat>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.SacuvajPromeneNadStavkama:
                        Kontroler.Instance.SacuvajPromeneNadStavkama(serializer.ReadType<EvidencijaNastave>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.PretraziEvidencijuNastave:
                        odgovor.Objekat =  Kontroler.Instance.PretraziEvidencijuNastave(serializer.ReadType<EvidencijaNastave>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;
                    case Operacija.PretraziUcenika:
                        odgovor.Objekat = Kontroler.Instance.PretraziUcenika(serializer.ReadType<Ucenik>(zahtev.Objekat));
                        serializer.Send(odgovor);
                        break;


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(odgovor.Greska);
                
                odgovor.Greska = ex.Message;
                odgovor.Uspesno = false;
                serializer.Send(odgovor);
            }
            
            
        }




    }
}






