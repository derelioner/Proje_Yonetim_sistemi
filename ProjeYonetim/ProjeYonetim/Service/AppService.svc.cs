using ProjeYonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjeYonetim.Service
{
    public class AppService : IAppService
    {
        public bool ProjeEkle(Projeler proje)
        {
            return Core.ProjeRepository.ProjeEkle(proje);
        }
        public bool ProjeGuncelle(Projeler proje)
        {
            return Core.ProjeRepository.ProjeGuncelle(proje);
        }
        public List<VW_Projeler> ProjeListele()
        {
            return Core.ProjeRepository.GetProjelist();
        }
        public Projeler ProjeGetir(int Id)
        {
            return Core.ProjeRepository.ProjeGetir(Id);
        }

        public bool ProjeDurumEkle(ProjeDurumlari projeDurumlari)
        {
            return Core.ProjeRepository.ProjeDurumEkle(projeDurumlari);
        }

        [OperationContract]
        public bool ProjeDurumGuncelle(ProjeDurumlari projeDurumlari)
        {
            return Core.ProjeRepository.ProjeDurumGuncelle(projeDurumlari);
        }

        [OperationContract]
        public ProjeDurumlari ProjeDurumGetir(int Id)
        {
            return Core.ProjeRepository.ProjeDurumGetir(Id);
        }

        [OperationContract]
        public List<ProjeDurumlari> ProjeDurumlariListele()
        {
            return Core.ProjeRepository.GetProjeDurumList();
        }

        [OperationContract]
        public bool KullaniciEkle(Kullanicilar kullanici)
        {
            return Core.ProjeRepository.KullaniciEkle(kullanici);
        }

        [OperationContract]
        public bool KullaniciGuncelle(Kullanicilar kullanici)
        {
            return Core.ProjeRepository.KullaniciGuncelle(kullanici);
        }

        [OperationContract]
        public Kullanicilar KullaniciGetir(int Id)
        {
            return Core.ProjeRepository.KullaniciGetir(Id);
        }

        [OperationContract]
        public List<Kullanicilar> KullaniciListele()
        {
            return Core.ProjeRepository.GetProjeKullaniciList();
        }

        [OperationContract]
        public Kullanicilar Giris(string kullaniciAdi,string sifre)
        {
            return Core.ProjeRepository.Giris(kullaniciAdi, sifre);
        }





















    }
}
