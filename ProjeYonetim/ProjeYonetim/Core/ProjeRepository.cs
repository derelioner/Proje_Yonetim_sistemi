using ProjeYonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeYonetim.Core
{
    public class ProjeRepository
    {
        #region Proje
        public static List<VW_Projeler> GetProjelist()
        {
            using (var context = new ProjeYonetimEntities())
            {
                return context.VW_Projeler.ToList();
            }
        }

        public static bool ProjeEkle(Projeler proje)
        {
            try
            {
                using (var context = new ProjeYonetimEntities())
                {
                    context.Projeler.Add(proje);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ProjeGuncelle(Projeler proje)
        {
            try
            {
                using (var context = new ProjeYonetimEntities())
                {
                    var item = context.Projeler.Find(proje.ID);
                    item.ProjeAdi = proje.ProjeAdi;
                    item.KullaniciId = proje.KullaniciId;
                    item.BaslangicTarihi = proje.BaslangicTarihi;
                    item.BitisTarihi = proje.BitisTarihi;
                    item.DurumId = proje.DurumId;
                    item.Aciklama = proje.Aciklama;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ProjeSil(int Id)
        {
            try
            {
                using (var context = new ProjeYonetimEntities())
                {
                    var item = context.Projeler.Find(Id);
                    context.Projeler.Remove(item);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Projeler ProjeGetir(int Id)
        {
            using (var context = new ProjeYonetimEntities())
            {
                var item = context.Projeler.Find(Id);
                if (item != null)
                    return item;
                else
                    return null;
            }
        }
        #endregion


        #region ProjeDurum
        public static List<ProjeDurumlari> GetProjeDurumList()
        {
            using (var context = new ProjeYonetimEntities())
            {
                return context.ProjeDurumlari.OrderBy(a => a.DurumAdi).ToList();
            }
        }
        public static bool ProjeDurumEkle(ProjeDurumlari projeDurum)
        {
            try
            {
                using (var context = new ProjeYonetimEntities())
                {
                    context.ProjeDurumlari.Add(projeDurum);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ProjeDurumGuncelle(ProjeDurumlari projeDurum)
        {
            try
            {
                using (var context = new ProjeYonetimEntities())
                {
                    var item = context.ProjeDurumlari.Find(projeDurum.ID);
                    item.DurumAdi = projeDurum.DurumAdi;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ProjeDurumSil(int Id)
        {
            try
            {
                using (var context = new ProjeYonetimEntities())
                {
                    if (!context.Projeler.Any(a => a.DurumId == Id))
                    {
                        var item = context.ProjeDurumlari.Find(Id);
                        context.ProjeDurumlari.Remove(item);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static ProjeDurumlari ProjeDurumGetir(int Id)
        {
            using (var context = new ProjeYonetimEntities())
            {
                var item = context.ProjeDurumlari.Find(Id);
                if (item != null)
                    return item;
                else
                    return null;
            }
        }
        #endregion


        #region Kullanici
        public static List<Kullanicilar> GetProjeKullaniciList()
        {
            using (var context = new ProjeYonetimEntities())
            {
                return context.Kullanicilar.OrderBy(a => a.KullaniciAdi).ToList();
            }
        }
        public static bool KullaniciEkle(Kullanicilar kullanici)
        {
            try
            {
                using (var context = new ProjeYonetimEntities())
                {
                    context.Kullanicilar.Add(kullanici);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool KullaniciGuncelle(Kullanicilar kullanici)
        {
            try
            {
                using (var context = new ProjeYonetimEntities())
                {
                    var item = context.Kullanicilar.Find(kullanici.ID);
                    item.Email = kullanici.Email;
                    item.KullaniciAdi = kullanici.KullaniciAdi;
                    item.Sifre = kullanici.Sifre;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool KullaniciSil(int Id)
        {
            try
            {
                using (var context = new ProjeYonetimEntities())
                {
                    if (!context.Projeler.Any(a => a.DurumId == Id))
                    {
                        var item = context.Kullanicilar.Find(Id);
                        context.Kullanicilar.Remove(item);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static Kullanicilar KullaniciGetir(int Id)
        {
            using (var context = new ProjeYonetimEntities())
            {
                var item = context.Kullanicilar.Find(Id);
                if (item != null)
                    return item;
                else
                    return null;
            }
        }

        public static Kullanicilar Giris(string KullaniciAdi, string Sifre)
        {
            using (var context = new ProjeYonetimEntities())
            {
                var item = context.Kullanicilar.FirstOrDefault(a => a.KullaniciAdi == KullaniciAdi && a.Sifre == Sifre);
                if (item != null)
                    return item;
                else
                    return null;
            }
        }
        #endregion


    }
}