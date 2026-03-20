using Domeni;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Zajednicki.Komunikacija;

namespace ServerskaAplikacija
{
    internal class ClientHandler
    {
        private Socket soket;
        Server server;

        private JsonNetworkSerializer serializer;



        public ClientHandler(Socket soket, Server server)
        {
            this.soket = soket;
            this.server = server;
            serializer = new JsonNetworkSerializer(this.soket);
        }

        public void Handle()
        {
            try
            {

                while (true)
                {
                    Zahtev zahtev = serializer.Receive<Zahtev>();
                    Odgovor odgovor = ProcesuirajZahtev(zahtev);
                    serializer.Send(odgovor);
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
            finally
            {
                if (soket.Connected)
                {
                    soket.Close();
                }
                server.RemoveClient(this);
            }
        }

        internal void CloseSocket()
        {
            soket.Close();
        }

        private Odgovor ProcesuirajZahtev(Zahtev zahtev)
        {
            Odgovor odgovor = new Odgovor();
            odgovor.Uspesno = true;
            try
            {
                switch (zahtev.Operacija)
                {

                    case Operacija.PrijaviUcitelja:
                        odgovor.Objekat = Kontroler.Instance.PrijaviUcitelja(serializer.ReadType<Ucitelj>(zahtev.Objekat));
                        break;
                    case Operacija.PretraziUcitelja:
                        odgovor.Objekat = Kontroler.Instance.PretraziUcitelja(serializer.ReadType<Ucitelj>(zahtev.Objekat));
                        break;
                    case Operacija.PromeniUcitelja:
                        Kontroler.Instance.PromeniUcitelja(serializer.ReadType<Ucitelj>(zahtev.Objekat));
                        break;
                    case Operacija.ObrisiUcitelja:
                        Kontroler.Instance.ObrisiUcitelja(serializer.ReadType<Ucitelj>(zahtev.Objekat));
                        break;
                    case Operacija.UbaciUcitelja:
                        Kontroler.Instance.UbaciUcitelja(serializer.ReadType<Ucitelj>(zahtev.Objekat));
                        break;
                    case Operacija.VratiListuSviSertifikati:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSviSertifikati();
                        break;
                    case Operacija.VratiListuSviUcitelji:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSviUcitelji();
                        break;
                    case Operacija.VratiListuUcitelji:
                        odgovor.Objekat = Kontroler.Instance.VratiListuUcitelja(serializer.ReadType<Ucitelj>(zahtev.Objekat));
                        break;
                    case Operacija.UbaciLicencu:
                        Kontroler.Instance.UbaciLicencu(serializer.ReadType<Licenca>(zahtev.Objekat));
                        break;
                    case Operacija.PromeniLicencu:
                        Kontroler.Instance.PromeniLicencu(serializer.ReadType<Licenca>(zahtev.Objekat));
                        break;
                    case Operacija.VratiListuSveLicence:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSveLicence();
                        break;
                    case Operacija.VratiListuLicence:
                        odgovor.Objekat = Kontroler.Instance.VratiListuLicenca(serializer.ReadType<Licenca>(zahtev.Objekat));
                        break;
                    case Operacija.KreirajEvidencujuNastave:
                        Kontroler.Instance.KreirajEvidencijuNastave(serializer.ReadType<EvidencijaNastave>(zahtev.Objekat));
                        break;
                    case Operacija.VratiListuUcenika:
                        odgovor.Objekat = Kontroler.Instance.VratiListuUcenika(serializer.ReadType<Ucenik>(zahtev.Objekat));
                        break;
                    case Operacija.PretraziKurs:
                        odgovor.Objekat = Kontroler.Instance.PretraziKurs(serializer.ReadType<Kurs>(zahtev.Objekat));
                        break;
                    case Operacija.VratiListuSveGrupeUcenika:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSveGrupeUcenika();
                        break;
                    case Operacija.VratiListuSviUcenici:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSviUcenici();
                        break;
                    case Operacija.VratiListuSveEvidencijeNastave:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSveEvidencijeNastave();
                        break;
                    case Operacija.VratiListuEvidencijaNastave:
                        odgovor.Objekat = Kontroler.Instance.VratiListuEvidencijeNastave(serializer.ReadType<EvidencijaNastave>(zahtev.Objekat));
                        break;
                    case Operacija.VratiListuStavkiEvidencijeNastave:
                        odgovor.Objekat = Kontroler.Instance.VratiListuStavkiEvidencijeNastave(serializer.ReadType<StavkaEvidencijeNastave>(zahtev.Objekat));
                        break;
                    case Operacija.PromeniEvidencijuNastave:
                        Kontroler.Instance.PromeniEvidencijuNastave(serializer.ReadType<EvidencijaNastave>(zahtev.Objekat));
                        break;
                    case Operacija.KreirajStavkuEvidencijeNastave:
                        Kontroler.Instance.UbaciStavkuEvidencijeNastave(serializer.ReadType<StavkaEvidencijeNastave>(zahtev.Objekat));
                        break;
                    case Operacija.PromeniStavkuEvidencijeNastave:
                        Kontroler.Instance.PromeniStavkuEvidencijeNastave(serializer.ReadType<StavkaEvidencijeNastave>(zahtev.Objekat));
                        break;
                    case Operacija.KreirajUcenika:
                        Kontroler.Instance.UbaciUcenika(serializer.ReadType<Ucenik>(zahtev.Objekat));
                        break;
                    case Operacija.ObrisiUcenika:
                        Kontroler.Instance.ObrisiUcenika(serializer.ReadType<Ucenik>(zahtev.Objekat));
                        break;
                    case Operacija.PromeniUcenika:
                        Kontroler.Instance.PromeniUcenika(serializer.ReadType<Ucenik>(zahtev.Objekat));
                        break;
                    case Operacija.VratiZauzeteTermine:
                        odgovor.Objekat = Kontroler.Instance.VratiZauzeteTermine();
                        break;
                    case Operacija.VratiListuSviKursevi:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSviKursevi();
                        break;
                    case Operacija.KreirajGrupuUcenika:
                        Kontroler.Instance.UbaciGrupuUcenika(serializer.ReadType<GrupaUcenika>(zahtev.Objekat));
                        break;
                    case Operacija.PromeniGrupuUcenika:
                        Kontroler.Instance.PromeniGrupuUcenika(serializer.ReadType<GrupaUcenika>(zahtev.Objekat));
                        break;
                    case Operacija.ObrisiGrupuUcenika:
                        Kontroler.Instance.ObrisiGrupuUcenika(serializer.ReadType<GrupaUcenika>(zahtev.Objekat));
                        break;
                    case Operacija.UbaciKurs:
                        Kontroler.Instance.UbaciKurs(serializer.ReadType<Kurs>(zahtev.Objekat));
                        break;
                    case Operacija.PromeniKurs:
                        Kontroler.Instance.PromeniKurs(serializer.ReadType<Kurs>(zahtev.Objekat));
                        break;
                    case Operacija.VratiListuKurseva:
                        odgovor.Objekat = Kontroler.Instance.VratiListuKurseva(serializer.ReadType<Kurs>(zahtev.Objekat));
                        break;
                    case Operacija.UbaciSertifikat:
                        Kontroler.Instance.UbaciSertifikat(serializer.ReadType<Sertifikat>(zahtev.Objekat));
                        break;
                    case Operacija.PromeniSertifikat:
                        Kontroler.Instance.PromeniSertifikat(serializer.ReadType<Sertifikat>(zahtev.Objekat));
                        break;
                    case Operacija.ObrisiSertifikat:
                        Kontroler.Instance.ObrisiSertifikat(serializer.ReadType<Sertifikat>(zahtev.Objekat));
                        break;
                    case Operacija.KreirajUcenikGrupa:
                        Kontroler.Instance.UbaciUcenikGrupu(serializer.ReadType<UcenikGrupa>(zahtev.Objekat));
                        break;
                    case Operacija.VratiListuGrupeUcenika:
                        odgovor.Objekat = Kontroler.Instance.VratiListuGrupaUcenika(serializer.ReadType<GrupaUcenika>(zahtev.Objekat));
                        break;
                    case Operacija.VratiListuSertifikata:
                        odgovor.Objekat = Kontroler.Instance.VratiListuSertifikata(serializer.ReadType<Sertifikat>(zahtev.Objekat));
                        break;
                    case Operacija.SacuvajPromeneNadStavkama:
                        Kontroler.Instance.SacuvajPromeneNadStavkama(serializer.ReadType<EvidencijaNastave>(zahtev.Objekat));
                        break;
                    case Operacija.PretraziEvidencijuNastave:
                        odgovor.Objekat = Kontroler.Instance.PretraziEvidencijuNastave(serializer.ReadType<EvidencijaNastave>(zahtev.Objekat));
                        break;
                    case Operacija.PretraziUcenika:
                        odgovor.Objekat = Kontroler.Instance.PretraziUcenika(serializer.ReadType<Ucenik>(zahtev.Objekat));
                        break;
                    case Operacija.PretraziGrupuUcenika:
                        odgovor.Objekat = Kontroler.Instance.PretraziGrupuUcenika(serializer.ReadType<GrupaUcenika>(zahtev.Objekat));
                        break;
                    case Operacija.PretraziLicencu:
                        odgovor.Objekat = Kontroler.Instance.PretraziLicencu(serializer.ReadType<Licenca>(zahtev.Objekat));
                        break;
                    case Operacija.PretraziSertifikat:
                        odgovor.Objekat = Kontroler.Instance.PretraziSertifikat(serializer.ReadType<Sertifikat>(zahtev.Objekat));
                        break;
                    case Operacija.PretraziStavkuEvidencijeNastave:
                        odgovor.Objekat = Kontroler.Instance.PretraziStavkuEvidencijeNastave(serializer.ReadType<StavkaEvidencijeNastave>(zahtev.Objekat));
                        break;


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(odgovor.Greska);

                odgovor.Greska = ex.Message;
                odgovor.Uspesno = false;
            }

            return odgovor;


        }



    }
}
