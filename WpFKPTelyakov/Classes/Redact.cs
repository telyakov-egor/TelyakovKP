using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;

namespace WpFKPTelyakov
{
    class Redact
    {
        public string vb { get; set; }
        public void Zapoln()
        {
            Zayavlenie z = new Zayavlenie();
            z.Show();
            z.redaktir = true;
            dcAbiturDataContext db = new dcAbiturDataContext();
            z.txtFamiliy.Text = (from u in db.Abityrients
                                 where u.kod_LD == vb
                                 select u.Familiy).FirstOrDefault();
            z.txtName.Text = (from u in db.Abityrients
                              where u.kod_LD == vb
                              select u.Name).FirstOrDefault();
            z.btpBirth.Text = (from u in db.Abityrients
                               where u.kod_LD == vb
                               select u.Data_rozdeniy).FirstOrDefault();
            z.txtNumLd.Text = (from u in db.Abityrients
                               where u.kod_LD == vb
                               select u.kod_LD).FirstOrDefault();
            z.txtOtschestv.Text = (from u in db.Abityrients
                                   where u.kod_LD == vb
                                   select u.Otchestvo).FirstOrDefault();
            z.cmbGender.Text = (from u in db.Abityrients
                                where u.kod_LD == vb
                                select u.Pol).FirstOrDefault();
            z.cmbVibrSpec.Text = (from u in db.Abityrients
                                  where u.kod_LD == z.txtNumLd.Text
                                  select u.Vibor_special).FirstOrDefault();

            var db_doc = new dcDocumLicnostDataContext();

            z.cmbGrazhdanstvo.Text = (from u in db_doc.Documents_abit
                                      where u.Kod_LD == z.txtNumLd.Text
                                      select u.Grazdanstvo).FirstOrDefault();
            z.cmbVidDocumLucnost.Text = (from u in db_doc.Documents_abit
                                         where u.Kod_LD == z.txtNumLd.Text
                                         select u.Tip_docum).FirstOrDefault();
            z.txtSeriaNomDocumL.Text = (from u in db_doc.Documents_abit
                                        where u.Kod_LD == z.txtNumLd.Text
                                        select u.Seriy_num).FirstOrDefault();
            z.btpDataVidDocum.Text = Convert.ToString((from u in db_doc.Documents_abit
                                                       where u.Kod_LD == z.txtNumLd.Text
                                                       select u.Data_vidach).FirstOrDefault());
            z.txtKodPodr.Text = (from u in db_doc.Documents_abit
                                 where u.Kod_LD == z.txtNumLd.Text
                                 select u.Kod_podraz).FirstOrDefault();
            z.txtKemVidanLic.Text = (from u in db_doc.Documents_abit
                                     where u.Kod_LD == z.txtNumLd.Text
                                     select u.Kem_vidan).FirstOrDefault();
            z.txtMestoRozhden.Text = (from u in db_doc.Documents_abit
                                      where u.Kod_LD == z.txtNumLd.Text
                                      select u.Mesto_rozden).FirstOrDefault();
            z.txtNumTel.Text = (from u in db.Abityrients
                                where u.kod_LD == vb
                                select u.Phone).FirstOrDefault();
            z.txtSNILS.Text = (from u in db.Abityrients
                               where u.kod_LD == vb
                               select u.Snils).FirstOrDefault();
            var db_adr = new dcAdresAbitDataContext();
            z.txtStrana.Text = (from u in db_adr.Adres_Abityrients
                                where u.kod_LD == z.txtNumLd.Text
                                select u.StranaP).FirstOrDefault();
            z.txtRegion.Text = (from u in db_adr.Adres_Abityrients
                                where u.kod_LD == z.txtNumLd.Text
                                select u.RegionP).FirstOrDefault();
            z.txtRaionProp.Text = (from u in db_adr.Adres_Abityrients
                                   where u.kod_LD == z.txtNumLd.Text
                                   select u.RaionP).FirstOrDefault();
            z.txtGorodP.Text = (from u in db_adr.Adres_Abityrients
                                where u.kod_LD == z.txtNumLd.Text
                                select u.GorodP).FirstOrDefault();
            z.txtYlitca.Text = (from u in db_adr.Adres_Abityrients
                                where u.kod_LD == z.txtNumLd.Text
                                select u.YlitsaP).FirstOrDefault();
            z.txtDom.Text = (from u in db_adr.Adres_Abityrients
                             where u.kod_LD == z.txtNumLd.Text
                             select u.DomP).FirstOrDefault();
            z.txtKvartira.Text = (from u in db_adr.Adres_Abityrients
                                  where u.kod_LD == z.txtNumLd.Text
                                  select u.KvP).FirstOrDefault();
            z.txtIdex.Text = (from u in db_adr.Adres_Abityrients
                              where u.kod_LD == z.txtNumLd.Text
                              select u.IndexP).FirstOrDefault();
            z.cmbStranaF.Text = (from u in db_adr.Adres_Abityrients
                                 where u.kod_LD == z.txtNumLd.Text
                                 select u.StranaF).FirstOrDefault();
            z.cmbRegionF.Text = (from u in db_adr.Adres_Abityrients
                                 where u.kod_LD == z.txtNumLd.Text
                                 select u.RegionF).FirstOrDefault();
            z.txtRaionF.Text = (from u in db_adr.Adres_Abityrients
                                where u.kod_LD == z.txtNumLd.Text
                                select u.RegionF).FirstOrDefault();
            z.txtGorodF.Text = (from u in db_adr.Adres_Abityrients
                                where u.kod_LD == z.txtNumLd.Text
                                select u.GorodF).FirstOrDefault();
            z.txtYlitcaF.Text = (from u in db_adr.Adres_Abityrients
                                 where u.kod_LD == z.txtNumLd.Text
                                 select u.YlitsaF).FirstOrDefault();
            z.txtDomF.Text = (from u in db_adr.Adres_Abityrients
                              where u.kod_LD == z.txtNumLd.Text
                              select u.DomP).FirstOrDefault();
            z.txtKvartiraF.Text = (from u in db_adr.Adres_Abityrients
                                   where u.kod_LD == z.txtNumLd.Text
                                   select u.KvF).FirstOrDefault();
            z.txtIdexF.Text = (from u in db_adr.Adres_Abityrients
                               where u.kod_LD == z.txtNumLd.Text
                               select u.IndexF).FirstOrDefault();

            var db_ych = new dcObrazvAbitDataContext();
            z.txtTipYz.Text = (from u in db_ych.Obrazovanie_Abityr
                               where u.Kod_LD == z.txtNumLd.Text
                               select u.Tip_YZ).FirstOrDefault();
            z.txtNameYZ.Text = (from u in db_ych.Obrazovanie_Abityr
                                where u.Kod_LD == z.txtNumLd.Text
                                select u.Name_YZ).FirstOrDefault();
            z.txtRegYz.Text = (from u in db_ych.Obrazovanie_Abityr
                               where u.Kod_LD == z.txtNumLd.Text
                               select u.Region).FirstOrDefault();
            z.txtLang.Text = (from u in db_ych.Obrazovanie_Abityr
                              where u.Kod_LD == z.txtNumLd.Text
                              select u.Izych_yazik).FirstOrDefault();
            z.txtVidDocObr.Text = (from u in db_ych.Obrazovanie_Abityr
                                   where u.Kod_LD == z.txtNumLd.Text
                                   select u.Vid_docum_obr).FirstOrDefault();
            z.txtSeriaNomDocumObr.Text = (from u in db_ych.Obrazovanie_Abityr
                                          where u.Kod_LD == z.txtNumLd.Text
                                          select u.Seriy_num_doc_obr).FirstOrDefault();
            z.btpDataVidDocumObr.Text = (from u in db_ych.Obrazovanie_Abityr
                                         where u.Kod_LD == z.txtNumLd.Text
                                         select u.Data_vidachi_obr).FirstOrDefault();

            var db_ots = new dcOtsenkAbitDataContext();
            z.txtYdovl.Text = Convert.ToString((from u in db_ots.Otsenki_abityr
                                                where u.Kod_LD == z.txtNumLd.Text
                                                select u.kol_vo_3).FirstOrDefault());
            z.txtOtl.Text = Convert.ToString((from u in db_ots.Otsenki_abityr
                                              where u.Kod_LD == z.txtNumLd.Text
                                              select u.kol_vo_5).FirstOrDefault());
            z.txtXor.Text = Convert.ToString((from u in db_ots.Otsenki_abityr
                                              where u.Kod_LD == z.txtNumLd.Text
                                              select u.kol_vo_4).FirstOrDefault());
            z.txtSrBall.Text = Convert.ToString((from u in db_ots.Otsenki_abityr
                                                 where u.Kod_LD == z.txtNumLd.Text
                                                 select u.Sred_ball).FirstOrDefault());
        }
       
    }
}
