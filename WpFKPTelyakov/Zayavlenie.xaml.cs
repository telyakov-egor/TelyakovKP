using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;

namespace WpFKPTelyakov
{
    /// <summary>
    /// Логика взаимодействия для Zayavlenie.xaml
    /// </summary>
    public partial class Zayavlenie : Window
    {

        public Zayavlenie()
        {
            InitializeComponent();
            
        }
        public bool redaktir = false;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на действие: ректирование или создание нового абитуриента
            if(redaktir)
            {
                try
                {
                    dcAbiturDataContext dbAbit = new dcAbiturDataContext();
                    Abityrients abit = dbAbit.Abityrients.FirstOrDefault(abiter => abiter.kod_LD.Equals( txtNumLd.Text));
                    abit.Familiy = txtFamiliy.Text;
                    abit.Name =  txtName.Text;
                    abit.Otchestvo =  txtOtschestv.Text;
                    abit.Pol =  cmbGender.Text;
                    abit.Data_rozdeniy =  btpBirth.Text;
                    abit.Phone =  txtNumTel.Text;
                    abit.Snils =  txtSNILS.Text;
                    abit.Vibor_special =  cmbVibrSpec.Text;
                    var SelectQuery = from a in dbAbit.GetTable<Abityrients>() select a;
                    dbAbit.SubmitChanges();

                    dcDocumLicnostDataContext dbdocLich = new dcDocumLicnostDataContext();
                    Documents_abit docAbLic = dbdocLich.Documents_abit.FirstOrDefault(abiter => abiter.Kod_LD.Equals( txtNumLd.Text));
                    docAbLic.Grazdanstvo =  cmbGrazhdanstvo.Text;
                    docAbLic.Tip_docum =  cmbVidDocumLucnost.Text;
                    docAbLic.Seriy_num =  txtSeriaNomDocumL.Text;
                    docAbLic.Data_vidach =  btpDataVidDocum.SelectedDate;
                    docAbLic.Kod_podraz =  txtKodPodr.Text;
                    docAbLic.Kem_vidan =  txtKemVidanLic.Text;
                    docAbLic.Mesto_rozden =  txtMestoRozhden.Text;
                    var SelectQuery1 = from a in dbdocLich.GetTable<Documents_abit>() select a;
                    dbdocLich.SubmitChanges();

                    dcAdresAbitDataContext dbAdresAbit = new dcAdresAbitDataContext();
                    Adres_Abityrients adrAbit = dbAdresAbit.Adres_Abityrients.FirstOrDefault(abiter => abiter.kod_LD.Equals( txtNumLd.Text));
                    adrAbit.StranaP =  txtStrana.Text;
                    adrAbit.RegionP =  txtRegion.Text;
                    adrAbit.RaionP =  txtRaionProp.Text;
                    adrAbit.GorodP =  txtGorodP.Text;
                    adrAbit.YlitsaP =  txtYlitca.Text;
                    adrAbit.DomP =  txtDom.Text;
                    adrAbit.KvP =  txtKvartira.Text;
                    adrAbit.IndexP =  txtIdex.Text;
                    adrAbit.StranaF =  cmbStranaF.Text;
                    adrAbit.RegionF =  cmbRegionF.Text;
                    adrAbit.RaionF =  txtRaionF.Text;
                    adrAbit.GorodF =  txtGorodF.Text;
                    adrAbit.YlitsaF =  txtYlitcaF.Text;
                    adrAbit.DomF =  txtDomF.Text;
                     txtKvartiraF.Text =  txtKvartira.Text;
                    adrAbit.KvF =  txtKvartiraF.Text;
                    adrAbit.IndexF =  txtIdexF.Text;
                    var SelectQuery2 = from a in dbAdresAbit.GetTable<Adres_Abityrients>() select a;
                    dbAdresAbit.SubmitChanges();

                    dcObrazvAbitDataContext dcObrazvAbit = new dcObrazvAbitDataContext();
                    Obrazovanie_Abityr obrazAbit = dcObrazvAbit.Obrazovanie_Abityr.FirstOrDefault(abiter => abiter.Kod_LD.Equals( txtNumLd.Text));
                    obrazAbit.Tip_YZ =  txtTipYz.Text;
                    obrazAbit.Name_YZ =  txtNameYZ.Text;
                    obrazAbit.Region =  txtRegYz.Text;
                    obrazAbit.Izych_yazik =  txtLang.Text;
                    obrazAbit.Vid_docum_obr =  txtVidDocObr.Text;
                    obrazAbit.Seriy_num_doc_obr =  txtSeriaNomDocumObr.Text;
                    obrazAbit.Data_vidachi_obr =  btpDataVidDocumObr.Text;
                    var SelectQuery4 = from a in dcObrazvAbit.GetTable<Obrazovanie_Abityr>() select a;
                    dcObrazvAbit.SubmitChanges();

                    dcOtsenkAbitDataContext dcOtsenkAbit = new dcOtsenkAbitDataContext();
                    Otsenki_abityr otsAbit = dcOtsenkAbit.Otsenki_abityr.FirstOrDefault(abiter => abiter.Kod_LD.Equals( txtNumLd.Text));
                    otsAbit.kol_vo_3 = Convert.ToInt32( txtYdovl.Text);
                    otsAbit.kol_vo_4 = Convert.ToInt32( txtXor.Text);
                    otsAbit.kol_vo_5 = Convert.ToInt32( txtOtl.Text);
                    otsAbit.Sred_ball = Convert.ToDouble( txtSrBall.Text);
                    abit.kod_LD =  txtNumLd.Text;
                    docAbLic.Kod_LD =  txtNumLd.Text;
                    adrAbit.kod_LD =  txtNumLd.Text;
                    obrazAbit.Kod_LD =  txtNumLd.Text;
                    otsAbit.Kod_LD =  txtNumLd.Text;
                    var SelectQuery5 = from a in dcOtsenkAbit.GetTable<Otsenki_abityr>() select a;
                    dcOtsenkAbit.SubmitChanges();

                    MessageBox.Show("Данные изменены!", "Готово");
                    Close();
                    wSpisocAbityrientov w1 = new wSpisocAbityrientov();
                    w1.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверте данные!");
                }
            }
            else
            {
                try
                {
                    dcAbiturDataContext ab = new dcAbiturDataContext();
                    Abityrients abityrients = new Abityrients();
                    abityrients.kod_LD = txtNumLd.Text;
                    abityrients.Familiy = txtFamiliy.Text;
                    abityrients.Name = txtName.Text;
                    abityrients.Otchestvo = txtOtschestv.Text;
                    abityrients.Pol = cmbGender.Text;
                    abityrients.Data_rozdeniy = btpBirth.Text;
                    abityrients.Phone = txtNumTel.Text;
                    abityrients.Snils = txtSNILS.Text;
                    abityrients.Vibor_special = cmbVibrSpec.Text;

                    dcDocumLicnostDataContext docL = new dcDocumLicnostDataContext();
                    Documents_abit docAbLi = new Documents_abit();

                    docAbLi.Grazdanstvo = cmbGrazhdanstvo.Text;
                    docAbLi.Tip_docum = cmbVidDocumLucnost.Text;
                    docAbLi.Seriy_num = txtSeriaNomDocumL.Text;
                    docAbLi.Data_vidach = btpDataVidDocum.SelectedDate;
                    docAbLi.Kod_podraz = txtKodPodr.Text;
                    docAbLi.Kem_vidan = txtKemVidanLic.Text;
                    docAbLi.Mesto_rozden = txtMestoRozhden.Text;

                    dcAdresAbitDataContext dbAdrAbit = new dcAdresAbitDataContext();
                    Adres_Abityrients adAbit = new Adres_Abityrients();
                    adAbit.StranaP = txtStrana.Text;
                    adAbit.RegionP = txtRegion.Text;
                    adAbit.RaionP = txtRaionProp.Text;
                    adAbit.GorodP = txtGorodP.Text;
                    adAbit.YlitsaP = txtYlitca.Text;
                    adAbit.DomP = txtDom.Text;
                    adAbit.KvP = txtKvartira.Text;
                    adAbit.IndexP = txtIdex.Text;

                    adress.IsEnabled = false;
                    adAbit.StranaF = cmbStranaF.Text;
                    adAbit.RegionF = cmbRegionF.Text;
                    adAbit.RaionF = txtRaionF.Text;
                    adAbit.GorodF = txtGorodF.Text;
                    adAbit.YlitsaF = txtYlitcaF.Text;
                    adAbit.DomF = txtDomF.Text;
                    txtKvartiraF.Text = txtKvartira.Text;
                    adAbit.KvF = txtKvartiraF.Text;
                    adAbit.IndexF = txtIdexF.Text;

                    dcObrazvAbitDataContext dcObrAbit = new dcObrazvAbitDataContext();
                    Obrazovanie_Abityr obrAbit = new Obrazovanie_Abityr();
                    obrAbit.Tip_YZ = txtTipYz.Text;
                    obrAbit.Name_YZ = txtNameYZ.Text;
                    obrAbit.Region = txtRegYz.Text;
                    obrAbit.Izych_yazik = txtLang.Text;
                    obrAbit.Vid_docum_obr = txtVidDocObr.Text;
                    obrAbit.Seriy_num_doc_obr = txtSeriaNomDocumObr.Text;
                    obrAbit.Data_vidachi_obr = btpDataVidDocumObr.Text;

                    dcOtsenkAbitDataContext dcOtsenAbit = new dcOtsenkAbitDataContext();
                    Otsenki_abityr otAbit = new Otsenki_abityr();
                    otAbit.kol_vo_3 = Convert.ToInt32(txtYdovl.Text);
                    otAbit.kol_vo_4 = Convert.ToInt32(txtXor.Text);
                    otAbit.kol_vo_5 = Convert.ToInt32(txtOtl.Text);
                    otAbit.Sred_ball = Convert.ToDouble(txtSrBall.Text);

                    docAbLi.Kod_LD = txtNumLd.Text;
                    adAbit.kod_LD = txtNumLd.Text;
                    obrAbit.Kod_LD = txtNumLd.Text;
                    otAbit.Kod_LD = txtNumLd.Text;

                    ab.GetTable<Abityrients>().InsertOnSubmit(abityrients);
                    ab.SubmitChanges();

                    docL.GetTable<Documents_abit>().InsertOnSubmit(docAbLi);
                    docL.SubmitChanges();

                    dbAdrAbit.GetTable<Adres_Abityrients>().InsertOnSubmit(adAbit);
                    dbAdrAbit.SubmitChanges();

                    dcObrAbit.GetTable<Obrazovanie_Abityr>().InsertOnSubmit(obrAbit);
                    dcObrAbit.SubmitChanges();

                    dcOtsenAbit.GetTable<Otsenki_abityr>().InsertOnSubmit(otAbit);
                    dcOtsenAbit.SubmitChanges();
                    string spec = cmbVibrSpec.Text;

                    dcSpecialDataContext dcSpec = new dcSpecialDataContext();
                    Specialnocti special = dcSpec.Specialnocti.FirstOrDefault(speci => speci.Name_special.Equals(cmbVibrSpec.Text));
                    special.kolvo_zauav++;
                    dcSpec.SubmitChanges();
                    glavn gl = new glavn();
                    gl.Show();
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверте данные!");
                }

            }

        }

        private void ckbSofpadenAdres_Click(object sender, RoutedEventArgs e)
        {
            var chekB = sender as CheckBox;
            if (chekB.IsChecked.Value)
            {
                adress.IsEnabled = false;
                cmbStranaF.Text = txtStrana.Text;
                cmbRegionF.Text = txtRegion.Text;
                txtRaionF.Text = txtRaionProp.Text;
                txtGorodF.Text = txtGorodP.Text;
                txtYlitcaF.Text = txtYlitca.Text;
                txtDomF.Text = txtDom.Text;
                txtKvartiraF.Text = txtKvartira.Text;
                txtIdexF.Text = txtIdex.Text;
            }
            else
            {
                adress.IsEnabled = true;
            }
        }
        private void BtnChetSrball_Click(object sender, RoutedEventArgs e)
        {
            double tr = Convert.ToDouble(txtYdovl.Text);
            double ch = Convert.ToDouble(txtXor.Text);
            double otl = Convert.ToDouble(txtOtl.Text);
            double sumOts = (tr * 3) + (ch * 4) + (otl * 5);
            double kol = tr + ch + otl;
            double srBall = sumOts / kol;
            txtSrBall.Text = Convert.ToString(Math.Round(srBall,2));
        }
        //заполнение комбо бокса при загрузке формы
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using(DataContext db = new DataContext(Properties.Settings.Default.db))
            {
                dcSpecialDataContext dcSpecial = new dcSpecialDataContext();
                var spec = (from a in dcSpecial.Specialnocti
                            select a.Name_special);
                cmbVibrSpec.ItemsSource = spec;
            

                Table<Specialnocti> speci = db.GetTable<Specialnocti>();
                var query = from a in speci
                            select new { a.Kod_specialnosti, a.Name_special, a.kolvo_zauav };
                dgSpec.ItemsSource = query;
            }
        }
        //действие на кнопку назад
        private void BtnNazad_Click(object sender, RoutedEventArgs e)
        {
            glavn g1 = new glavn();
            g1.Show();
            Close();
        }
        //ограничение на ввод букв
        private void TxtNumLd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        //ограничение на ввод цифр
        private void TxtFamiliy_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void btnDalee_Click(object sender, RoutedEventArgs e)
        {
            tcInfo.SelectedIndex = (tcInfo.SelectedIndex + 1);
        }

        private void btnNaz_Click(object sender, RoutedEventArgs e)
        {
            if (tcInfo.SelectedIndex == 0)
            {
                btnNaz.IsEnabled = true;
            }
            else
            {
                tcInfo.SelectedIndex = (tcInfo.SelectedIndex - 1);

            }
        }

       
    }
}
