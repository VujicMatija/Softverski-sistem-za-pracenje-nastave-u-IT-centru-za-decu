using Domeni;
using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Zajednicki.Komunikacija;

namespace Forme
{
    internal class Komunikacija
    {
        public static Komunikacija instance;

        public static Komunikacija Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Komunikacija();
                }
                return instance;
            }

        }

        private Komunikacija()
        {

        }

        private Socket soket;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public void PoveziSe()
        {
            if(soket == null || !soket.Connected)
            {
                soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                soket.Connect("127.0.0.1", 9999);
                stream = new NetworkStream(soket);
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);
                writer.AutoFlush = true;
            }
           
        }

        //UCITELJ
        #region

        internal Ucitelj? PrijaviUcitelja(Ucitelj ucitelj)
        {
            try
            {
                Zahtev zahtev = new Zahtev()
                {
                    Operacija = Operacija.PrijaviUcitelja,
                    Objekat = ucitelj
                };
                if(writer == null || reader == null)
                {
                    throw new Exception("Server nije dostupan!");
                }
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor o = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (o.Uspesno)
                {
                    Ucitelj prijavljeniUcitelj = JsonSerializer.Deserialize<Ucitelj>(o.Objekat.ToString());
                    return prijavljeniUcitelj;
                }
                else
                {
                    throw new Exception(o.Greska);
                }
            }
            catch(Exception ex)
            {
                throw ex;
                
            }
            
        }

        internal Ucitelj PretraziUcitelja(Ucitelj ucitelj)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PretraziUcitelja, Objekat = ucitelj };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    Ucitelj res = JsonSerializer.Deserialize<Ucitelj>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch(SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }catch(Exception ex)
            {
                throw new Exception("Greska!");
            }
            
        }

        internal void promeniUcitelja(Ucitelj ucitelj)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PromeniUcitelja, Objekat = ucitelj };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

        internal void obrisiUcitelja(Ucitelj ucitelj)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.ObrisiUcitelja, Objekat = ucitelj };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

        internal void KreirajUcitelja(Ucitelj ucitelj)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.UbaciUcitelja, Objekat = ucitelj };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

        internal BindingList<Ucitelj> VratiListuSviUcitelji()
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuSviUcitelji };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<Ucitelj> res = JsonSerializer.Deserialize<BindingList<Ucitelj>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greška prilikom rada sa serverom!");
            }
           
        }


        internal BindingList<Ucitelj> VratiListuUcitelja(Ucitelj ucitelj)
        {
            try
            {
               
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuUcitelji, Objekat = ucitelj};
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<Ucitelj> res = JsonSerializer.Deserialize<BindingList<Ucitelj>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Greška prilikom rada sa serverom!");
            }

        }
#endregion

        //SERTIFIKAT

        #region

        internal BindingList<Sertifikat> VratiListuSviSertifikati()
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuSviSertifikati };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<Sertifikat> res = JsonSerializer.Deserialize<BindingList<Sertifikat>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Greška prilikom rada sa serverom!");
            }
           
        }

        internal Sertifikat PretraziSertifiakt(Sertifikat sertifikat)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PretraziSertifikat, Objekat = sertifikat};
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    Sertifikat res = JsonSerializer.Deserialize<Sertifikat>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }

        }


        internal BindingList<Sertifikat> VratiListuSertifikata(Sertifikat sertifikat)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuSertifikata, Objekat = sertifikat };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<Sertifikat> res = JsonSerializer.Deserialize<BindingList<Sertifikat>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Greška prilikom rada sa serverom!");
            }
            
        }

        internal void PromeniSertifikat(Sertifikat sertifikat)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PromeniSertifikat, Objekat = sertifikat };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

        internal void ObrisiSertifikat(Sertifikat sertifikat)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.ObrisiSertifikat, Objekat = sertifikat };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

        internal void UbaciSertifikat(Sertifikat sertifikat)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.UbaciSertifikat, Objekat = sertifikat };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }
#endregion

        //GRUPA UCENIKA
        #region  

        internal BindingList<GrupaUcenika> vratiListuSlobodneGrupe()
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuSlobodneGrupe };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<GrupaUcenika> res = JsonSerializer.Deserialize<BindingList<GrupaUcenika>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }

        }

        internal BindingList<GrupaUcenika> VratiListuSveGrupeUcenika()
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuSveGrupeUcenika };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<GrupaUcenika> res = JsonSerializer.Deserialize<BindingList<GrupaUcenika>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
           
        }

        internal List<string> VratiZauzeteTermine()
        {
            try
            {

                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiZauzeteTermine };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    List<string> res = JsonSerializer.Deserialize<List<string>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal GrupaUcenika PretraziGrupuUcenika(GrupaUcenika grupaUcenika)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PretraziGrupuUcenika, Objekat = grupaUcenika };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    GrupaUcenika res = JsonSerializer.Deserialize<GrupaUcenika>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }

        }

        internal void PromeniGrupuUcenika(GrupaUcenika grupa)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PromeniGrupuUcenika, Objekat = grupa };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

        internal void ObrisiGrupuUcenika(GrupaUcenika grupa)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.ObrisiGrupuUcenika, Objekat = grupa };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

        internal void KreirajGrupuUcenika(GrupaUcenika grupa)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.KreirajGrupuUcenika, Objekat = grupa };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }


        internal BindingList<GrupaUcenika> vratiListuGrupaUcenika(GrupaUcenika grupa)
        {
            try
            {
                
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuGrupeUcenika, Objekat = grupa };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<GrupaUcenika> res = JsonSerializer.Deserialize<BindingList<GrupaUcenika>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }

        }
#endregion

        //LICENCA
        #region

        internal Licenca PretraziLicencu(Licenca licenca)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PretraziLicencu, Objekat = licenca };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    Licenca res = JsonSerializer.Deserialize<Licenca>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }

        }

        internal void KreirajLicencu(Licenca licenca)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.UbaciLicencu, Objekat = licenca };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if(odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        internal void PromeniLicencu(Licenca licenca)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PromeniLicencu, Objekat = licenca };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal BindingList<Licenca> VratiListuSveLicence()
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuSveLicence };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<Licenca> res = JsonSerializer.Deserialize<BindingList<Licenca>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

       
        internal BindingList<Licenca> vratiListuLicence(Licenca licenca)
        {

            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuLicence, Objekat = licenca };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<Licenca> res = JsonSerializer.Deserialize<BindingList<Licenca>>(odg.Objekat.ToString());

                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }
#endregion


        //EVIDENCIJA NASTAVE
        #region
        internal void KreirajEvidencijuNastave(EvidencijaNastave evidencija)
        {
            try
            {
                //Zahtev zahtev = new Zahtev() { Operacija = Operacija.KreirajEvidencujuNastave, Objekat1 = evidencija , Objekat2 = stavke};
                
                
                
                Zahtev zahtev = new Zahtev { Operacija = Operacija.KreirajEvidencujuNastave , Objekat = evidencija};
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal EvidencijaNastave PretraziEvidencijuNastave(EvidencijaNastave evidencija)
        {
            try
            {

                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PretraziEvidencijuNastave, Objekat = evidencija };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    EvidencijaNastave res = JsonSerializer.Deserialize<EvidencijaNastave>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }



        internal BindingList<EvidencijaNastave> VratiListuSveEvidencijeNastave()
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuSveEvidencijeNastave };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<EvidencijaNastave> res = JsonSerializer.Deserialize<BindingList<EvidencijaNastave>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

       
        internal List<EvidencijaNastave> VratiListuEvidencijaNastave( EvidencijaNastave evidencija )
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuEvidencijaNastave, Objekat = evidencija };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    List<EvidencijaNastave> res = JsonSerializer.Deserialize<List<EvidencijaNastave>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

           
        }

        internal void PromeniEvidencijuNastave(EvidencijaNastave evidencija)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PromeniEvidencijuNastave, Objekat = evidencija };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }
        
        internal void SacuvajPromeneNadStavkama(EvidencijaNastave evidencija)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.SacuvajPromeneNadStavkama, Objekat = evidencija };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }
#endregion
        //UCENIK
        #region
        internal BindingList<Ucenik> VratiListuUcenika(Ucenik ucenik)
        {

            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuUcenika, Objekat = ucenik };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<Ucenik> res = JsonSerializer.Deserialize<BindingList<Ucenik>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        internal Ucenik PretraziUcenika(Ucenik ucenik)
        {
            try
            {

                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PretraziUcenika, Objekat = ucenik };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    Ucenik res = JsonSerializer.Deserialize<Ucenik>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }



        internal BindingList<Ucenik> VratiListuSviUcenici()
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuSviUcenici };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<Ucenik> res = JsonSerializer.Deserialize<BindingList<Ucenik>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        internal void PromeniUcenika(Ucenik ucenik)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PromeniUcenika, Objekat = ucenik };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

        internal void ObrisiUcenika(Ucenik ucenik)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.ObrisiUcenika, Objekat = ucenik };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

        internal void UbaciUcenika(Ucenik ucenik)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.KreirajUcenika, Objekat = ucenik };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }
        #endregion

        //KURS

        #region 


        internal Kurs PretraziKurs(Kurs kurs)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PretraziKurs, Objekat = kurs };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    Kurs res = JsonSerializer.Deserialize<Kurs>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

        internal BindingList<Kurs> VratiListuSviKursevi()
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuSviKursevi };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<Kurs> res = JsonSerializer.Deserialize<BindingList<Kurs>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        internal void KreirajKurs(Kurs kurs)
        {

            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.UbaciKurs, Objekat = kurs };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

        internal void PromeniKurs(Kurs kurs)
        {
          
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PromeniKurs, Objekat = kurs };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

        internal BindingList<Kurs> VratiListuKurseva(Kurs k)
        {
           
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuKurseva, Objekat = k };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<Kurs> res = JsonSerializer.Deserialize<BindingList<Kurs>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }


        #endregion



        //STAVKE EVIDENCIJE NASTAVE
        #region


        internal StavkaEvidencijeNastave PretraziStavkuEvidencijeNastave(StavkaEvidencijeNastave stavka)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PretraziStavkuEvidencijeNastave, Objekat = stavka};
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    StavkaEvidencijeNastave res = JsonSerializer.Deserialize<StavkaEvidencijeNastave>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

        internal BindingList<StavkaEvidencijeNastave> VratiListuStavkiEvidencijeNastave(StavkaEvidencijeNastave stavka)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.VratiListuStavkiEvidencijeNastave, Objekat = stavka };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno)
                {
                    BindingList<StavkaEvidencijeNastave> res = JsonSerializer.Deserialize<BindingList<StavkaEvidencijeNastave>>(odg.Objekat.ToString());
                    return res;
                }
                else
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        

        internal void UbaciStavkuEvidencijeNastave(StavkaEvidencijeNastave stavka)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.KreirajStavkuEvidencijeNastave, Objekat = stavka };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if(odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>> " + se.Message);
                throw se;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        internal void PromeniStavkuEvidencijeNastave(StavkaEvidencijeNastave stavka)
        {
            try
            {
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.PromeniStavkuEvidencijeNastave, Objekat = stavka };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>> " + se.Message);
                throw se;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        //UCENIK GRUPA

        internal void KreirajUcenikGrupa( UcenikGrupa ug)
        {
            
            try
            {
                
                Zahtev zahtev = new Zahtev() { Operacija = Operacija.KreirajUcenikGrupa, Objekat = ug };
                writer.WriteLine(JsonSerializer.Serialize(zahtev));
                Odgovor odg = JsonSerializer.Deserialize<Odgovor>(reader.ReadLine());
                if (odg.Uspesno == false)
                {
                    throw new Exception(odg.Greska);
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(">>>>>" + se.Message);
                throw new Exception("Problem sa serverom!");
            }
            catch (Exception ex)
            {
                throw new Exception("Greska!");
            }
        }

    }

    
}
