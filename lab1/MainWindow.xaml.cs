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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Globalization;

namespace lab1
{
    /// <summary>
    /// floateraction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public object ResultText { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            
        }
        /*
        private void button_hehe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ok");
        }

        private void button_elo_Click(object sender, RoutedEventArgs e)
        {

            var btn = sender as Button;
            MessageBox.Show($"ok {btn.Content.ToString()}");

            if(float.TryParse("2,1", out float x))
                {
                MessageBox.Show($"{2 * x }");

            }
        }*/
        string Liczba1="";
        string Liczba2="";
        char RodzajDzialania=' ';
        float wynik;
        bool NastepneDzialanie = false;
        bool DzialanieNaWyniku = false;
        bool CzyZnak = false;
        string PomLiczba2 = "";
        char PomRodzajDzialania = ' ';
        bool Start = false;
        bool CzyKropka = false;
        bool CzyMinus = false;
        bool PoczMinus = false;
        bool Blad = false;
        bool Poczatek = true;
        


        private void Dzialanie(float liczba)
        {

                if (RodzajDzialania == ' ')
                {
                if (Wyswietl.Text.Length < 13)
                {

                    Liczba1 += liczba;
                    if (CzyMinus == true && PoczMinus == false)
                    {

                        Wyswietl.Text = "-" + Liczba1;
                        PoczMinus = true;
                    }
                    else
                    {
                        Wyswietl.Text = Liczba1;
                    }
                    
                }
                }
                else
                {
                
                 Wyswietl.Text = Liczba2;
                
                if (Wyswietl.Text.Length < 13)
                {
                    Liczba2 += liczba;
                    Wyswietl.Text = Liczba2;
                }
                }
            

        }

        private void button_cyfra_Click(object sender, RoutedEventArgs e)
        {
            if (Blad == true)
            {
                Blad = false;
                Wyswietl.Text = "0";
                Liczba1 = "";
                Liczba2 = "";
                RodzajDzialania = ' ';
                CzyZnak = false;
                NastepneDzialanie = false;
                DzialanieNaWyniku = false;
                PomLiczba2 = "";
                PomRodzajDzialania = ' ';
                Start = false;
                CzyKropka = false;
                CzyMinus = false;
                PoczMinus = false;
                Poczatek = true;
            }
            var button = sender as Button;
            var aktualna = button.Name[button.Name.Length - 1];

            float cyfra = aktualna - '0';

           
            if (NastepneDzialanie==true && DzialanieNaWyniku==true)
            {
                NastepneDzialanie = false;
                DzialanieNaWyniku = false;
            }
            if(NastepneDzialanie==true && DzialanieNaWyniku == false)
            {
                if(Liczba1!="0.")
                Liczba1 = "";
                NastepneDzialanie = false;
            }

           // if (Poczatek == true)
           // {
              //  if (cyfra != 0)
              //  {
                    Dzialanie(cyfra);
               //     Poczatek = false;
              //  }
          //  }
           // else {
              //  Dzialanie(cyfra);
           // }
            
            
        }


      
        private void button_kropka_Click(object sender, RoutedEventArgs e)
        {

            if (CzyKropka == false)
            {
                if (NastepneDzialanie == true && DzialanieNaWyniku == false)
                {
                    Liczba1 = "0.";
                    Wyswietl.Text = Liczba1;
                    CzyKropka = true;
                    Poczatek = false;

                }
                else if (Liczba1 == "" && NastepneDzialanie == false)
                {
                    Liczba1 = "0.";
                    Wyswietl.Text = Liczba1;
                    CzyKropka = true;
                    Poczatek = false;
                }
                else if (CzyZnak == true && Liczba2 == "")
                {
                    Liczba2 = "0.";
                    Wyswietl.Text = Liczba2;
                    CzyKropka = true;
                    Poczatek = false;
                }
                else if (CzyZnak == true && Liczba2 != "")
                {
                    Liczba2 += ".";
                    Wyswietl.Text = Liczba2;
                    CzyKropka = true;
                    Poczatek = false;
                }
                else
                {
                    Liczba1 += ".";
                    Wyswietl.Text = Liczba1;
                    CzyKropka = true;
                    Poczatek = false;
                }
            }
            
        }

        private void button_rowna_Click(object sender, RoutedEventArgs e)
        {
            if(Liczba2!="")
                Start = true;

            if (Start == true)
            {

                if (Liczba1 != "")
                {
                    
                    if (Liczba2 == "")
                    {
                        Liczba2 = PomLiczba2;
                        RodzajDzialania = PomRodzajDzialania;
                    }
                    
                    CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    Liczba1 = Liczba1.ToString(CultureInfo.CurrentCulture);
                    Liczba2 = Liczba2.ToString(CultureInfo.CurrentCulture);

                    

                    

                    switch (RodzajDzialania)
                    {
                        case ('+'):
                            if (CzyMinus == true)
                            {
                                float PomLiczba1 = float.Parse(Liczba1)*(-1);
                                wynik = PomLiczba1 + float.Parse(Liczba2);
                                if (float.IsNaN(wynik) | float.IsInfinity(wynik))
                                {
                                    Wyswietl.Text = "Liczba poza zakresem";
                                    Blad = true;
                                }
                                else
                                {
                                    Wyswietl.Text = (PomLiczba1 + float.Parse(Liczba2)).ToString();
                                }
                                
                                CzyMinus = false;
                            }
                            else
                            { 
                                wynik = float.Parse(Liczba1) + float.Parse(Liczba2);
                                if (float.IsNaN(wynik) | float.IsInfinity(wynik))
                                {
                                    Wyswietl.Text = "Liczba poza zakresem";
                                    Blad = true;
                                }
                                else
                                {
                                    Wyswietl.Text = (float.Parse(Liczba1) + float.Parse(Liczba2)).ToString();
                                }
                               
                            }
                            
                            PomRodzajDzialania = '+';
                            break;
                        case ('-'):
                            if (CzyMinus == true)
                            {
                                float PomLiczba1 = float.Parse(Liczba1) * (-1);
                                wynik = PomLiczba1 - float.Parse(Liczba2);
                                if (float.IsNaN(wynik) | float.IsInfinity(wynik))
                                {
                                    Wyswietl.Text = "Liczba poza zakresem";
                                    Blad = true;
                                }
                                else
                                {
                                    Wyswietl.Text = (PomLiczba1 - float.Parse(Liczba2)).ToString();
                                }
                                
                                CzyMinus = false;
                            }
                            else
                            {
                                wynik = float.Parse(Liczba1) - float.Parse(Liczba2);
                                if (float.IsNaN(wynik) | float.IsInfinity(wynik))
                                {
                                    Wyswietl.Text = "Liczba poza zakresem";
                                    Blad = true;
                                }
                                else
                                {
                                    Wyswietl.Text = (float.Parse(Liczba1) - float.Parse(Liczba2)).ToString();
                                }
                                
                            }
                            PomRodzajDzialania = '-';
                            break;
                        case ('*'):
                            if (CzyMinus == true)
                            {
                                float PomLiczba1 = float.Parse(Liczba1) * (-1);
                                wynik = PomLiczba1 * float.Parse(Liczba2);
                                if (float.IsNaN(wynik) | float.IsInfinity(wynik))
                                {
                                    Wyswietl.Text = "Liczba poza zakresem";
                                    Blad = true;
                                }
                                else
                                {
                                    Wyswietl.Text = (PomLiczba1 * float.Parse(Liczba2)).ToString();
                                }
                                
                                CzyMinus = false;
                            }
                            else
                            {
                                wynik = float.Parse(Liczba1) * float.Parse(Liczba2);
                                if (float.IsNaN(wynik) | float.IsInfinity(wynik))
                                {
                                    Wyswietl.Text = "Liczba poza zakresem";
                                    Blad = true;
                                }
                                else
                                {
                                    Wyswietl.Text = (float.Parse(Liczba1) * float.Parse(Liczba2)).ToString();
                                }
                                
                            }
                            PomRodzajDzialania = '*';
                            break;
                        case ('/'):
                            float zero = float.Parse(Liczba2);
                            if (zero==0)
                            {
                                Wyswietl.Text = "BŁĄD";
                                Blad = true;                            }
                            else
                            {
                                if (CzyMinus == true)
                                {
                                    float PomLiczba1 = float.Parse(Liczba1) * (-1);
                                    wynik = PomLiczba1 / float.Parse(Liczba2);
                                    if (float.IsNaN(wynik) | float.IsInfinity(wynik))
                                    {
                                        Wyswietl.Text = "Liczba poza zakresem";
                                        Blad = true;
                                    }
                                    else
                                    {
                                        Wyswietl.Text = (PomLiczba1 / float.Parse(Liczba2)).ToString();
                                    }
                                    
                                    CzyMinus = false;
                                }
                                else
                                {
                                    wynik = float.Parse(Liczba1) / float.Parse(Liczba2);
                                    if (float.IsNaN(wynik) | float.IsInfinity(wynik))
                                    {
                                        Wyswietl.Text = "Liczba poza zakresem";
                                        Blad = true;
                                    }
                                    else
                                    {
                                        Wyswietl.Text = (float.Parse(Liczba1) / float.Parse(Liczba2)).ToString();
                                    }
                                    
                                }
                                PomRodzajDzialania = '/';
                            }
                            break;

                    }
                    NastepneDzialanie = true;
                    Liczba1 = (wynik).ToString();
                    PomLiczba2 = Liczba2;
                    Liczba2 = "";
                    RodzajDzialania = ' ';
                    CzyZnak = false;
                    CzyKropka = false;
                    Poczatek = true;
                }
                
            }
        }

        
        private void button_plus_Click(object sender, RoutedEventArgs e)
        {
            if (Liczba2 == "")
            { 
                if (NastepneDzialanie == true)
                    DzialanieNaWyniku = true;

                if(Liczba1!="")
                {
                    RodzajDzialania = '+';
                    CzyZnak = true;
                }
                CzyKropka = false;
                Poczatek = true;
            }
            
        }

        private void button_minus_Click(object sender, RoutedEventArgs e)
        {
            
            if (Liczba2 == "")
            {
                if (NastepneDzialanie == true)
                    DzialanieNaWyniku = true;

                if (Liczba1 != "")
                {
                    RodzajDzialania = '-';
                    CzyZnak = true;
                }
                CzyKropka = false;
                Poczatek = true;
            }
            if (Liczba1 == "" && Start == false)
            {
                CzyMinus = true;
                Wyswietl.Text = "-";
            }

        }

        private void button_mnozenie_Click(object sender, RoutedEventArgs e)
        {
            if (Liczba2 == "")
            {
                if (NastepneDzialanie == true)
                    DzialanieNaWyniku = true;

                if (Liczba1 != "")
                {
                    RodzajDzialania = '*';
                    CzyZnak = true;
                }
                CzyKropka = false;
                Poczatek = true;
            }
            
        }

        private void button_dzielenie_Click(object sender, RoutedEventArgs e)
        {
            if (Liczba2 == "")
            {
                if (NastepneDzialanie == true)
                    DzialanieNaWyniku = true;

                if (Liczba1 != "")
                {
                    RodzajDzialania = '/';
                    CzyZnak = true;
                }
                CzyKropka = false;
                Poczatek = true;
            }
            
        }

        private void button_wyczysc_Click(object sender, RoutedEventArgs e)
        {
            Wyswietl.Text = "0";
            Liczba1 = "";
            Liczba2 = "";
            RodzajDzialania = ' ';
            CzyZnak = false;
            NastepneDzialanie = false;
            DzialanieNaWyniku = false;
            PomLiczba2 = "";
            PomRodzajDzialania = ' ';
            Start = false;
            CzyKropka = false;
            CzyMinus = false;
            PoczMinus = false;
            Poczatek = true;
        }

        
    }
}
