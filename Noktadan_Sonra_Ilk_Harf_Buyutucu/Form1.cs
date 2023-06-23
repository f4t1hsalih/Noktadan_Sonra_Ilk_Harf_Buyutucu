using System;
using System.Windows.Forms;

namespace Noktadan_Sonra_Ilk_Harf_Buyutucu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string kelime, deger, karekter, yenikelime, kelimesonu;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Cümlenin ilk harfini ve noktadan sonraki harfini büyüten program. Cümlenin başındaki ve noktadan sonra bırakılan gereksiz boşluklarıda siler.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cümlenin başındaki gereksiz boşlukları venoktayı siler
            int sayac = 0;
            kelime = richTextBox1.Text;
            for (int x = 0; x < kelime.Length; x++)
            {
                deger = kelime.Substring(x, 1);
                if (deger == " " || deger == ".") sayac++;
                else break;
            }

            yenikelime = kelime.Substring(sayac);

            for (int i = 0; i < yenikelime.Length; i++)
            {
                if (i == 0)
                {   //kelimenin ilk harfini alıp büyütüyor,
                    //kelimenin ilk harfini siliyor ve gerikalan tüm harfleri küçültüyor,
                    //ve bu iki değeri birleştiriyor.
                    yenikelime = yenikelime.Substring(i, 1).ToUpper() + yenikelime.Substring(++i).ToLower();
                    i--;
                }

                karekter = yenikelime.Substring(i, 1);

                if (karekter == ".")
                {
                    //"."(nokta)ya kadar olan kısmı alır
                    kelime = yenikelime.Substring(0, i);
                    //MessageBox.Show("noktaya geldin. i'nin değeri: " + i + " yeni kelime: " + kelime);
                    sayac = i;
                    //"."(nokta)dan sonra gelen gereksiz boşlukları siler
                    do
                    {
                        kelimesonu = yenikelime.Substring(++sayac, 1).ToUpper();
                    } while (kelimesonu == " ");
                    //Cümlenin başını "."(nokta)yı ve vümlenin sonunu birleştirerek yeni kelimeyi oluşturuyor
                    yenikelime = kelime + ". " + kelimesonu + yenikelime.Substring(++sayac);
                    //MessageBox.Show("i'nin değeri " + i + "boşluktan çıktın i'nin değeri: " + i + " harf: " + kelimesonu + " sayacın değeri: " + sayac);
                }
            }
            richTextBox2.Text = yenikelime;
        }
    }
}
