using ProjeYonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjeYonetim.Service
{

    [ServiceContract]
    public interface IAppService
    {
        [OperationContract]
        bool ProjeEkle(Projeler proje);

        [OperationContract]
        bool ProjeGuncelle(Projeler proje);

        [OperationContract]
        List<VW_Projeler> ProjeListele();

        [OperationContract]
        Projeler ProjeGetir(int Id);

        [OperationContract]
        bool ProjeDurumEkle(ProjeDurumlari projeDurumlari);

        [OperationContract]
        bool ProjeDurumGuncelle(ProjeDurumlari projeDurumlari);

        [OperationContract]
        ProjeDurumlari ProjeDurumGetir(int Id);

        [OperationContract]
        List<ProjeDurumlari> ProjeDurumlariListele();

        [OperationContract]
        bool KullaniciEkle(Kullanicilar kullanici);

        [OperationContract]
        bool KullaniciGuncelle(Kullanicilar kullanici);

        [OperationContract]
        Kullanicilar KullaniciGetir(int Id);

        [OperationContract]
        List<Kullanicilar> KullaniciListele();

        [OperationContract]
        Kullanicilar Giris(string kullaniciAdi, string sifre);

    }
}
