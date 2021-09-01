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
using APX_Steel;
using APX_Concrete;
using APX_PublishTEXtoPDF;
using static APX_InputDataValidation.InputDataValidation;
using ValuesFromSSA;
using APX_SolveManager;

namespace Anna.Lyashenko.Concrete
{
    /// <summary>
    /// Логика взаимодействия для ConcreteAnchor.xaml
    /// </summary>
    public partial class Concrete1 : UserControl, ILinkToMainProject, IValuesFromSSA
    {
        const string MODULE_Name = "СП63-Местное сжатие";
        public Concrete1()
        {
            InitializeComponent();
            Steel.fillComboBoxByRSteelClass(SteelClass1, RSteelClass.A240);
            APX_Concrete.Concrete.fillComboBoxByClass(ConcClass, ConcreteClass.B40);
            Гамма1.Items.Add("1.0");
            Гамма1.Items.Add("0.9");
            Гамма1.Items.Add("0.85");
            Гамма2.Items.Add("1.0");
            Гамма2.Items.Add("0.9");
            Гамма3.Items.Add("1.0");
            Гамма3.Items.Add("0.85");
            Распределение.Items.Add("Равномерная");
            Распределение.Items.Add("Неравномерная");
            
            //Вид.Items.Add("Расчет на смятие");
            //Способ_задания_арматуры.Items.Add("С помощью диаметра");
            //Способ_задания_арматуры.Items.Add("С помощью площади");
            if (SteelClass1.Text == "A240") { Диаметр.ItemsSource = APX_Steel.A240.Diams; }
            else if (SteelClass1.Text == "A400") { Диаметр.ItemsSource = APX_Steel.A400.Diams; }
            else if (SteelClass1.Text == "A500") { Диаметр.ItemsSource = APX_Steel.A500.Diams;  }
            else if (SteelClass1.Text == "B500") { Диаметр.ItemsSource = APX_Steel.B500.Diams;  }
            else if (SteelClass1.Text == "Bp500") { Диаметр.ItemsSource = APX_Steel.Bp500.Diams;  }
            else if (SteelClass1.Text == "Bp1200") { Диаметр.ItemsSource = APX_Steel.Bp1200.Diams;  }
            else if (SteelClass1.Text == "Bp1300") { Диаметр.ItemsSource = APX_Steel.Bp1300.Diams; }
            else if (SteelClass1.Text == "Bp1400") { Диаметр.ItemsSource = APX_Steel.Bp1400.Diams; }
            else if (SteelClass1.Text == "Bp1500") { Диаметр.ItemsSource = APX_Steel.Bp1500.Diams;  }
            else if (SteelClass1.Text == "Bp1600") { Диаметр.ItemsSource = APX_Steel.Bp1600.Diams;  }
            else if (SteelClass1.Text == "K1400") { Диаметр.ItemsSource = APX_Steel.K1400.Diams;  }
            else if (SteelClass1.Text == "K1500") { Диаметр.ItemsSource = APX_Steel.K1500.Diams; }
            else if (SteelClass1.Text == "K1600") { Диаметр.ItemsSource = APX_Steel.K1600.Diams;  }
            else if (SteelClass1.Text == "K1700") { Диаметр.ItemsSource = APX_Steel.K1700.Diams; }
            solveManager solveMan = new solveManager(
        sp_solveManager,
        MODULE_Name,
        new object[] {
            Продольная_сила,
            Распределение,
            Ширина_зоны,
            Высота_зоны,
            Расстояние_низ,Расстояние_верх,Расстояние_вправо,Расстояние_влево,
            Гамма1,Гамма3,Гамма4,Гамма5,
            Мин_шаг_сет,Макс_шаг_стерж,
            Макс_шаг_сет,Мин_шаг_стерж,
            Шифр,Дата,Этаж,Конструкция,Оси,Комментарии,
            ConcClass,
            SteelClass1,
            gr1,Диаметр,Мин_защ_слой,Толщина_элемента,
                    }
                                                   );

        }
        //private void Вид_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (Вид.SelectedItem == "Расчет на смятие")
        //    {

        //    }
        //}

        bool cvet = true;
        Brush LightGray, Silver;
        private void Color(object sender, EventArgs e)
        {
            if (cvet)
            {
                btn_Color.Background = Brushes.LightGray;

                a.Background = Brushes.White;
                b.Background = Brushes.White;
                c.Background = Brushes.White;
                d.Background = Brushes.White;
                m.Background = Brushes.White;
                f.Background = Brushes.White;
                k.Background = Brushes.White;
                i.Background = Brushes.White;

                n.Background = Brushes.White;
                o.Background = Brushes.White;
                p.Background = Brushes.White;
                q.Background = Brushes.White;
                r.Background = Brushes.White;
                s.Background = Brushes.White;
                t.Background = Brushes.White;
                u.Background = Brushes.White;

            }
            else
            {
                btn_Color.Background = Brushes.White;

                a.Background = Brushes.Gainsboro;
                b.Background = Brushes.Gainsboro;
                c.Background = Brushes.Gainsboro;
                d.Background = Brushes.Gainsboro;
                m.Background = Brushes.Gainsboro;
                f.Background = Brushes.Gainsboro;
                k.Background = Brushes.Gainsboro;
                i.Background = Brushes.Gainsboro;

                n.Background = Brushes.Silver;
                o.Background = Brushes.Silver;
                p.Background = Brushes.Silver;
                q.Background = Brushes.Silver;
                r.Background = Brushes.Silver;
                s.Background = Brushes.Silver;
                t.Background = Brushes.Silver;
                u.Background = Brushes.Silver;
            }
            cvet = !cvet;
        }


        private void Распределение_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Распределение.SelectedItem == "Равномерная")
            {
                //double ψ = 1;
            }
            else if (Распределение.SelectedItem == "Неавномерная")
            {
                //double ψ= 0.75;
            }
        }



        public string GetCalculateName()
        {
            return "Расчет на местное сжатие";
        }

        public object GetClass()
        {
            return this;
        }

        public void GetValues(Dictionary<string, double> Values)
        {
            throw new NotImplementedException();
        }

        private void textBoxTextChaned(object sender, TextChangedEventArgs e) //Проверка все ли ячейки введены верно
        {
            DoubleOnly(e);
        }
        private void Otchet2_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            //MessageBox.Show(PDF.Content.ToString() + "не отмечен");

            PDF.Visibility = System.Windows.Visibility.Hidden;
            Otchet1.Visibility = System.Windows.Visibility.Hidden;


        }

        private void Otchet2_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;

            PDF.Visibility = System.Windows.Visibility.Visible;
            Otchet1.Visibility = System.Windows.Visibility.Visible;



        }



        private void PDF_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            //MessageBox.Show(PDF.Content.ToString() + " отмечен");
            if (PDF.IsChecked == true)
            {
                Otchet1.IsChecked = false;
            }

        }
        private void PDF_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;

        }






        private void Otchet1_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            if (Otchet1.IsChecked == true)
            {
                PDF.IsChecked = false;
            }
        }
        private void Otchet1_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;

        }

        
        private void Armir_Unchecked(object sender, RoutedEventArgs e)// учитываем косвенное армирование
        {
            CheckBox chBox = (CheckBox)sender;
            gr1.Visibility = Visibility.Collapsed;
            //Способ_задания_арматуры.Visibility = Visibility.Hidden;


        }
        private void Armir_Checked(object sender, RoutedEventArgs e)
        {

            CheckBox chBox = (CheckBox)sender;

            gr1.Visibility = Visibility.Visible;
            //Способ_задания_арматуры.Visibility = Visibility.Visible;
        }



        private void  Аверх_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            Расстояние_верх.Visibility = Visibility.Collapsed;
            ав.Visibility = Visibility.Hidden;


        }
        private void Аверх_Checked(object sender, RoutedEventArgs e)
        {

            CheckBox chBox = (CheckBox)sender;
            Расстояние_верх.Visibility = Visibility.Visible;
            ав.Visibility = Visibility.Visible;
        }

        private void Аниж_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            Расстояние_низ.Visibility = Visibility.Hidden;
            ан.Visibility = Visibility.Hidden;


        }
        private void Аниж_Checked(object sender, RoutedEventArgs e)
        {

            CheckBox chBox = (CheckBox)sender;

            Расстояние_низ.Visibility = Visibility.Visible;
            ан.Visibility = Visibility.Visible;
        }

        private void Алев_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            Расстояние_влево.Visibility = Visibility.Hidden;
            ал.Visibility = Visibility.Hidden;


        }
        private void Алев_Checked(object sender, RoutedEventArgs e)
        {

            CheckBox chBox = (CheckBox)sender;

            Расстояние_влево.Visibility = Visibility.Visible;
            ал.Visibility = Visibility.Visible;
        }

        private void Аправ_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            Расстояние_вправо.Visibility = Visibility.Hidden;
            ап.Visibility = Visibility.Hidden;
            
        }
        private void Аправ_Checked(object sender, RoutedEventArgs e)
        {

            CheckBox chBox = (CheckBox)sender;

            Расстояние_вправо.Visibility = Visibility.Visible;
            ап.Visibility = Visibility.Visible;
        }

        


        private void Calculate(object sender, RoutedEventArgs e)
        {
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            string An, lya, name,sluch1,risunok,rezult;
            rezult = "";
            Результаты.Document.Blocks.Clear();
            double γb1 = 1;
            double γb3 = 1;
            double γb2 = 1;
            //double γb5=1;
            if (Гамма1.Text == "1.0") { γb1 = 1; }
            else if (Гамма1.Text == "0.9") { γb1 = 0.9; }
            else if (Гамма1.Text == "0.85") { γb1 = 0.85; }

            if (Гамма2.Text == "1.0") { γb2 = 1; }
            else if (Гамма2.Text == "0.9") { γb2 = 0.9; }

            if (Гамма3.Text == "1.0") { γb3 = 1; }
            else if (Гамма3.Text == "0.85") { γb3 = 0.85; }


            //if (Гамма4.Text == "") { γb4 = 1; }
            //else { γb4 = float.Parse(Гамма4.Text); }
            //if (Гамма5.Text == "") { γb5 = 1; }
            //else { γb5 = float.Parse(Гамма5.Text); }
            double γb4 = double.Parse(Гамма4.Text);
            double γb5 = double.Parse(Гамма5.Text);
            double ψ = 1;
            if (Распределение.SelectedItem == "Равномерная")
            {
                ψ = 1;
            }
            else if (Распределение.SelectedItem == "Неравномерная")
            {
                ψ = 0.75;
            }
            string shifr = Шифр.Text;
            string data = Дата.Text;
            string etach = Этаж.Text;
            string constr = Конструкция.Text;
            string osi = Оси.Text;
            string comment = Комментарии.Text;

           
            double N = double.Parse(Продольная_сила.Text);
            double a1 = double.Parse(Ширина_зоны.Text);
            double a2 = double.Parse(Высота_зоны.Text);
            
            double Rb = APX_Concrete.Concrete.getStressByClass(ConcClass.SelectedIndex, ConcreteStressType.Rb);
            double Rsxy = Steel.getStressByClass(SteelClass1.SelectedIndex, RSteelStressType.Rs);

            double ав = 1;
            double ап = 1;
            double ал = 1;
            double ан = 1;
            if (Аверх.IsChecked == true) //если не отмечен галочкой ,значит край далеко, если отмечен-надо ввести число
            {
                if (Расстояние_верх.Text == "")
                {
                    MessageBox.Show("Введите размер края");
                    return;
                }
                else { ав = double.Parse(Расстояние_верх.Text); }

            }
            else
            {
                ав = a1;
            }


            if (Алев.IsChecked == true)
            {
                if (Расстояние_влево.Text == "")
                {
                    MessageBox.Show("Введите размер края");
                    return;
                }
                else{ ал = double.Parse(Расстояние_влево.Text); }
               
            }
            else
            {
                ал = a2;
            }

            if (Аправ.IsChecked == true)
            {
                if (Расстояние_вправо.Text == "")
                {
                    MessageBox.Show("Введите размер края");
                    return;
                }
                else { ап = double.Parse(Расстояние_вправо.Text); }
               
            }
            else
            {
                ап = a2;
            }


            if (Аниж.IsChecked == true )
            {
                if (Расстояние_низ.Text == "")
                {
                    MessageBox.Show("Введите размер края");
                    return;
                }
                else { ан = double.Parse(Расстояние_низ.Text); }
                
            }
            else
            {
                ан = a1;
            }


            double Abmax=1;
            double Afac = 1;
            double Abloc = a1 * a2;
            double Amin = 1;
            double ав1=ав;
            double ан1 = ан;
            double ап1 = ап;
            double ал1 = ал;

            Rb = Rb * γb2* γb1 * γb3 * γb4 * γb5;
            sluch1 = "\n\\textbf{Расчет}\n" +
                $"\n$$ A_{{b,loc}}=a_1 \\cdot a_2={a1} \\cdot {a2}={Abloc.ToString("0.##")}\\text{{ см}}^2;$$\n";

            //введем масштабный коэффициент
            double gor = ап + ал + a1;//общий размер горизонтальный
            double ver = ав + ан + a1;//общий размер вертикаль
            double[] ar = { ан, ав, ап, ал,gor,ver };
            Array.Sort(ar);
            double maxValue = ar[ar.Length - 1];
            double G = 90 / maxValue;


            risunok = $"\n\\begin{{center}}\\begin{{tikzpicture}}\\filldraw[fill=blue!20!white, draw=blue](0,0)--({(a1 *G/ 15)},0)--({(a1 * G / 15)},{(a2 * G / 15)})--(0,{(a2 * G / 15)})--cycle;";
            //Посередине
            if (ав!=0 & ан!= 0 & ал!= 0 & ап!= 0)
            {
               
                    
                //Abmax = (2 * a2 + a1) * (2 * a1 + a2);
                //sluch1 = sluch1 +  $"\n$$ A_{{b,max}}=(2a_2+a_1) \\cdot (2a_1+a_2)=(2 \\cdot {a2}+{a1})(2 \\cdot {a1}+ {a2})={Abmax.ToString("0.##")}\\text{{ см}}^2;$$\n";
               

                if (ав1 > a1) { ав1 = a1; }
                if (ан1 > a1) { ан1 = a1;}
                if (ап1 > a2) { ап1 = a2; }
                if (ал1 > a2) { ал1 = a2;  }
                //для элемента у края
                if (ан1 < a1 & ав > ан) { ав1 = ан;  }
                if (ав1 < a1 & ан > ав) { ан1 = ав;  }
                if (ап1 < a2 & ал >ап) { ал1 = ап; }
                if (ал1 < a1 & ап >ал) { ап1 = ал;  }

                if (Аправ.IsChecked == true)
                {
                    risunok = risunok +
                    $"\\draw[black,thick]({((a1 + ап) *G/15)},{(a2 + ав) *G/15})--({((ап + a1) *G/15)},{(-ан) *G/15});";
                }
                if (Алев.IsChecked == true)
                {
                    risunok = risunok +
                    $"\\draw[black,thick]({(-ал) *G/15}, {(-ан) *G/15})--({(-ал) *G/15},{(a2 + ав) *G/15});";
                }
                if (Аверх.IsChecked == true)
                {
                    risunok = risunok +
                    $"\\draw[black,thick]({(-ал) *G/15},{(a2 + ав) *G/15})--({((a1 + ап) *G/15)},{(a2 + ав) *G/15});";
                }
                if (Аниж.IsChecked == true)
                {
                    risunok = risunok +
                    $"\\draw[black,thick]({(-ал) *G/15}, {(-ан) *G/15})--({((a1 + ап) *G/15)},{(-ан) *G/15});";
                }

                //если размеры сторон большие и введены то добавляем их размеры
                if (ав > ав1 & Аверх.IsChecked == true)
                {
                    risunok = risunok +
                   $"\\draw({((-ал) *G/ 15) - 0.1},{(a2 + ав) * G / 15})--({((-ал * G) / 15) - 0.8},{(a2 + ав) * G / 15});" +
                   $"\\draw({((-ал) * G / 15) - 0.7},{(a2 + ав) * G / 15 + 0.1})--({((-ал) * G / 15) - 0.7},0);" +
                   $"\\node [rotate=90]at ({((-ал) * G / 15) - 0.9}, {((a2 + ав) * G / 15) - ((ав - ав1) * G / 30)}) {{{ав - ав1}}};";
                }
                if (ан > ан1 & Аниж.IsChecked == true)
                {

                    risunok = risunok +
                  $"\\draw({((-ал) * G / 15) - 0.1},{(-ан) * G / 15})--({((-ал) * G / 15) - 0.8},{(-ан) * G / 15});" +
                  $"\\draw({((-ал) * G / 15) - 0.7},{(-ан) * G / 15 - 0.1})--({((-ал) * G / 15) - 0.7},0);" +
                  $"\\node [rotate=90]at ({((-ал) * G / 15) - 0.9}, {((-ан) * G / 15) + ((ан - ан1) * G / 30)}) {{{ан - ан1}}};";

                }
                if (ап > ап1 & Аправ.IsChecked == true)
                {
                    risunok = risunok +
                     $"\\draw({(ап+a1) * G/15},{-ан * G / 15-0.1})--({(ап + a1) * G / 15},{-ан * G / 15 - 0.8});" +
                     $"\\draw({(ап + a1) * G / 15+0.1},{-ан * G / 15 - 0.7})--({(ап1 + a1) * G / 15},{-ан * G / 15 - 0.7});"+
                      $"\\node at ({(ап + a1) * G / 15 -(ап - ап1) * G / 30},{-ан * G / 15 - 0.4}) {{{ап - ап1}}};";
                }
                if (ал > ал1 & Алев.IsChecked == true)
                {
                    risunok = risunok +
                     $"\\draw({(-ал) * G / 15},{-ан * G / 15 - 0.1})--({(-ал) * G / 15},{-ан * G / 15 - 0.8});" +
                     $"\\draw({(-ал) * G / 15 - 0.1},{-ан * G / 15 - 0.7})--({(-ал1) * G / 15},{-ан * G / 15 - 0.7});" +
                      $"\\node at ({(-ал) * G / 15+(ал - ал1) * G / 30},{-ан * G / 15 - 0.4}) {{{ал - ал1}}};";
                }
                    Afac = (ал1 + ап1 + a1) * (ан1 + ав1 + a2);
                sluch1 = sluch1  +$"\n$ \\text{{Фактическая расчетная площадь: }}$\n" +
                    $"\n$$ A_{{b,fac}}= (a_{{\\text{{л}}}}+ a_{{\\text{{п}}}}+a_1)\\cdot (a_{{\\text{{н}}}}+ a_{{\\text{{в}}}}+a_2)=({ал1}+ {ап1}+{a1})\\cdot ({ан1}+ {ав1}+{a2})={Afac} \\text{{ см}}^2;$$\n";
                //if (Afac < Abmax) { Abmax = Afac; sluch1 = sluch1 + $"\n$$ \\text{{Принимаем: }} A_{{b,max}}={Abmax.ToString("0.##")} \\text{{ см}}^2;$$\n"; }

                risunok = risunok +
             $"\\draw[black,dashed]({(-ал1) *G/15}, {(-ан1) *G/15})--({((a1 + ап1) *G/15)},{(-ан1) *G/15})--({((a1 + ап1) *G/15)},{(ав1 + a2) *G/15})--({(-ал1) *G/15}, {(a2 + ав1) *G/15})--cycle;" +

             //добавим размеры нижние
             $"\\draw({(-ал1) *G/15}, {((-ан) *G/15)-0.1})--({(-ал1) *G/15}, {((-ан) *G/15) - 0.8});" +
             $"\\draw({(a1+ап1) *G/15}, {((-ан) *G/15) - 0.1})--({(a1 + ап1) *G/15}, {((-ан) *G/15) - 0.8});" +
             $"\\draw({((-ал1) *G/15)-0.1}, {((-ан) *G/15) - 0.7})--({((a1 + ап1) *G/15) + 0.1}, {((-ан) *G/15) - 0.7});" +
             $"\\draw(0, {((-ан) *G/15) - 0.1})--(0, {((-ан) *G/15) - 0.8});" +
             $"\\draw({a1 * G / 15}, {((-ан) *G/15) - 0.1})--({a1 *G/15}, {((-ан) *G/15) - 0.8});" +
             $"\\node at ({-ал1 * G / 30}, {((-ан) *G/15) - 0.4}) {{{ал1}}};" +
             $"\\node at ({a1 * G / 30}, {((-ан) *G/15) - 0.4}) {{{a1}}};" +
             $"\\node at ({(a1 *G/15)+(ап1 * G / 30)}, {((-ан) *G/15) - 0.4}) {{{ап1}}};" +

             //добавим размеры верхние
             $"\\draw({((-ал) *G/15) - 0.1}, {((-ан1) *G/15)})--({((-ал) *G/15) - 0.8}, {((-ан1) *G/15) });" +
             $"\\draw({((-ал) *G/15) - 0.1}, {((a2+ав1) *G/15)})--({((-ал) *G/15) - 0.8}, {((a2 + ав1) *G/15) });" +
             $"\\draw({((-ал) *G/15) - 0.7}, {(((-ан1) *G/15)-0.1)})--({((-ал) *G/15) - 0.7}, {(((a2 + ав1) *G/15)+0.1) });" +
              //$"\\draw({((-ал) *G/15) - 1.2}, {(((-ан) *G/15) - 0.1)})--({((-ал) *G/15) - 1.2}, {(((a2 + ав) *G/15) + 0.1) });" +
             $"\\draw({((-ал) *G/15) - 0.1}, 0)--({((-ал) *G/15) - 0.8}, 0);" +
             $"\\draw({((-ал) *G/15) - 0.1}, {a2 *G/15})--({((-ал) *G/15) - 0.8}, {a2 *G/15});" +
             $"\\node[rotate=90] at ({((-ал) *G/15) - 0.9}, {a2 * G / 30}) {{{a2}}};" +
             $"\\node [rotate=90]at ({((-ал) *G/15) - 0.9}, {-ан1 * G / 30}) {{{ан1}}};" +
             $"\\node [rotate=90]at ({((-ал) *G/15) - 0.9}, {(a2 *G/15) + (ав1 * G / 30)}) {{{ав1}}};" +
             //$"\\node[rotate=90] at ({((-ал) *G/15) - 1.4}, {(a2) / (2 * 15)}) {{{a2 + ав + ан}}};" +

                $"\\end{{tikzpicture}}\\end{{center}}\n";


            }
           
            //У края по всей ширине
            else if ((ав == 0 & ан == 0 & ап == 0) || (ав == 0 & ан == 0 & ал == 0) || (ав == 0 & ал == 0 & ап == 0) || (ан == 0 & ап == 0 & ал == 0))
            {
                
                Abmax = a1 * a2;
                Afac = a1 * a2;
                sluch1 = sluch1 + $"\n$$ A_{{b,fac}}=a_1\\cdot a_2 ={a1}\\cdot{a2}={Afac.ToString("0.##")}\\text{{ см}}^2;$$\n";
                if (ан==0 & ал==0 & ап == 0)
                {
                    if (Аверх.IsChecked == false)
                    {
                        risunok = risunok + $"\n\\draw[black,thick](0,0)--(0,{(a2 + ав)  *G/15});"+
                            $"\n\\draw[black,thick]({(a1)  *G/15}, 0)--({((a1)  *G/15)},{(a2 + ав)  *G/15});"+
                            $"\n\\draw[black,thick](0, 0)--({(a1)  *G/15}, 0);";
                    }
                    else
                    {
                        risunok = risunok + $"\n\\draw[black,thick](0,0)--(0,{(a2 + ав) * G / 15})--({((a1) * G / 15)},{(a2 + ав) * G / 15})--({(a1) * G / 15}, 0)--cycle;" +
                            $"\\draw({ -0.1}, {((a2 + ав) * G / 15)})--({ -0.8}, {((a2 + ав) * G / 15) });" +
                            $"\\draw({ -0.7}, {((a2) * G / 15) })--({-0.7}, {(((a2 + ав) * G / 15) + 0.1) });" +
                            $"\\node [rotate=90]at ({((-ал) * G / 15) - 0.9}, {(a2 * G / 15) + (ав * G / 30)}) {{{ав}}};";

                    }
                    risunok = risunok +
             //добавим размеры нижние

             $"\\draw({-0.1}, {-0.7})--({((a1)  *G/15) + 0.1}, { -0.7});" +
             $"\\draw(0, {((-ан)  *G/15) - 0.1})--(0, {((-ан)  *G/15) - 0.8});" +
             $"\\draw({a1  *G/15}, {-0.1})--({a1  *G/15}, { -0.8});" +
             $"\\node at ({a1 *G/30}, {((-ан)  *G/15) - 0.4}) {{{a1}}};" +

             //добавим размеры верхние

             
             $"\\draw({ -0.7}, {(-0.1)})--({-0.7}, {(((a2)  *G/15) + 0.1) });" +

             $"\\draw({ -0.1}, 0)--({-0.8}, 0);" +
             $"\\draw({ -0.1}, {a2  *G/15})--({-0.8}, {a2  *G/15});" +
             $"\\node[rotate=90] at ({((-ал)  *G/15) - 0.9}, {a2 *G/30}) {{{a2}}};" ;
                }
                if (ав == 0 & ал == 0 & ап == 0)
                {
                    if (Аниж.IsChecked == false)
                    {
                        risunok = risunok + $"\n\\draw[black,thick](0,{a2  *G/15})--(0,{(-ан)  *G/15});" +
                            $"\n\\draw[black,thick]({(a1)  *G/15}, {a2  *G/15})--({(a1)  *G/15}, {(-ан)  *G/15});"+
                            $"\n\\draw[black,thick](0, {a2 *G/15})--({(a1)  *G/15},{a2  *G/15});";
                    }
                    else
                    {
                        risunok = risunok +
                       $"\n\\draw[black,thick](0,0)--(0,{(-ан)  *G/15})--({((a1)  *G/15)},{(-ан)  *G/15})--({(a1)  *G/15}, {(a2)  *G/15})--(0, {(a2)  *G/15})--cycle;"+
                       $"\\draw({-0.1}, {((-ан) * G / 15)})--(- 0.8, {((-ан) * G / 15) });" +
                        $"\\draw({ -0.7}, {(((-ан) * G / 15) - 0.1)})--({ -0.7}, {(((a2) * G / 15) + 0.1) });" +
             $"\\node [rotate=90]at ({((-ал) * G / 15) - 0.9}, {-ан * G / 30}) {{{ан}}};";
                    }
                    risunok = risunok +

             //добавим размеры нижние

             $"\\draw({-0.1}, {((-ан) * G / 15) - 0.7})--({(a1 * G / 15) + 0.1}, {((-ан) * G / 15) - 0.7});" +
             $"\\draw(0, {((-ан) * G / 15) - 0.1})--(0, {((-ан) * G / 15) - 0.8});" +
             $"\\draw({a1 * G / 15}, {((-ан) * G / 15) - 0.1})--({a1 * G / 15}, {((-ан) * G / 15) - 0.8});" +
             $"\\node at ({a1 * G / 30}, {((-ан) * G / 15) - 0.4}) {{{a1}}};" +

             //добавим размеры верхние

             $"\\draw({ -0.7}, - 0.1)--({ -0.7}, {(((a2) * G / 15) + 0.1) });" +

             $"\\draw({ -0.1}, 0)--({ -0.8}, 0);" +
             $"\\draw({ -0.1}, {a2 * G / 15})--({ -0.8}, {a2 * G / 15});" +
             $"\\node[rotate=90] at ({((-ал) * G / 15) - 0.9}, {a2 * G / 30}) {{{a2}}};";
                }
                if (ав == 0 & ал == 0 & ан == 0)
                {
                    if (Аправ.IsChecked == false)
                    {
                        risunok = risunok + $"\n\\draw[black,thick](0,0)--({(ап + a1) * G / 15},0);" +
                            $"\n\\draw[black,thick](0, {(a2) * G / 15})--({(ап + a1) * G / 15},{(a2) * G / 15});" +
                            $"\n\\draw[black,thick](0, {a2 * G / 15})--(0,0);" ;
                    }
                    else
                    {
                        risunok = risunok +
                     $"\n\\draw[black,thick](0,0)--({(ап + a1) * G / 15},0)--({(ап + a1) * G / 15},{(a2) * G / 15})--(0, {(a2) * G / 15})--cycle;" +
                            $"\\draw({(a1 + ап) * G / 15}, { -0.1})--({(a1 + ап) * G / 15}, { -0.8});" +
                            $"\\draw({a1 * G / 15}, {-0.7 })--({((a1 + ап) * G / 15) + 0.1}, {-0.7});" +
                            $"\\node at ({(a1 * G / 15) + (ап * G / 30)}, {((-ан) * G / 15) - 0.4}) {{{ап}}};";


                    }
                    risunok = risunok +
                     //размеры нижние
                     
                    $"\\draw({-0.1}, { -0.7})--({((a1)  *G/15) + 0.1}, {-0.7});" +
                    $"\\draw(0, {-0.1})--(0, { -0.8});" +
                   $"\\draw({a1  *G/15}, {((-ан)  *G/15) - 0.1})--({a1  *G/15}, {((-ан)  *G/15) - 0.8});" +
                   $"\\node at ({a1  *G/30}, {((-ан)  *G/15) - 0.4}) {{{a1}}};" +
                   

                    //добавим размеры верхние

                   $"\\draw({ -0.1}, {((a2)  *G/15)})--({-0.8}, {((a2)  *G/15) });" +
                   $"\\draw({ -0.7}, {-0.1})--({ -0.7}, {(((a2)  *G/15) + 0.1) });" +

                  $"\\draw({ -0.1}, 0)--({-0.8}, 0);" +
                  $"\\node[rotate=90] at ({((-ал)  *G/15) - 0.9}, {a2 *G/30}) {{{a2}}};";
                }
                if (ан == 0 & ав == 0 & ап == 0)
                {
                    if (Алев.IsChecked == false)
                    {
                        risunok = risunok + $"\n\\draw[black,thick]({a1  *G/15},0)--({(-ал)  *G/15},0);" +
                        $"\n\\draw[black,thick]({a1  *G/15}, {(a2)  *G/15})--({-(ал)  *G/15}, {(a2)  *G/15});"+
                        $"\n\\draw[black,thick]({a1  *G/15},0)--({a1  *G/15}, {(a2)  *G/15});";
                    }
                    else
                    {
                        risunok = risunok +
                     $"\n\\draw[black,thick](0,0)--({(-ал) * G / 15},0)--({(-ал) * G / 15},{(a2) * G / 15})--({a1 * G / 15}, {(a2) * G / 15})--({a1 * G / 15}, 0)--cycle;" +
                     $"\\draw({(-ал) * G / 15}, {-0.1})--({(-ал) * G / 15}, { -0.8});" +
                     $"\\draw({((-ал) * G / 15) - 0.1}, { -0.7})--(0, {-0.7});" +
                     $"\\node at ({-ал * G / 30}, {((-ан) * G / 15) - 0.4}) {{{ал}}};";
                    }

                    risunok = risunok +

             //добавим размеры нижние
             $"\\draw(-0.1, { -0.7})--({a1 * G / 15}, {-0.7});"+
             $"\\draw(0, {-0.1})--(0, { -0.8});" +
             $"\\draw({a1  *G/15}, { -0.1})--({a1  *G/15}, { -0.8});" +
             
             $"\\node at ({a1  *G/30}, {((-ан)  *G/15) - 0.4}) {{{a1}}};" +

             //добавим размеры верхние

             $"\\draw({((-ал)  *G/15) - 0.7}, {-0.1})--({((-ал)  *G/15) - 0.7}, {(((a2)  *G/15) + 0.1) });" +

             $"\\draw({((-ал)  *G/15) - 0.1}, 0)--({((-ал)  *G/15) - 0.8}, 0);" +
             $"\\draw({((-ал)  *G/15) - 0.1}, {a2  *G/15})--({((-ал)  *G/15) - 0.8}, {a2  *G/15});" +
             $"\\node[rotate=90] at ({((-ал)  *G/15) - 0.9}, {a2  *G/30}) {{{a2}}};";
                }



                risunok = risunok +
                                    $"\n\\draw[dashed](0, 0)--({ (a1  *G/15)},0)--({ (a1  *G/15)},{ (a2  *G/15)})--(0,{ (a2  *G/15)})--cycle; "+
                    $"\\end{{tikzpicture}}\\end{{center}}\n";

            }

            //По всей ширине элемента
            else if ((ав == 0 & ан == 0) || (ал == 0 & ап == 0))
            {

                if (ав1 > a1) { ав1 = a1; }
                if (ан1 > a1) { ан1 = a1; }
                if (ап1 > a2) { ап1 = a2; }
                if (ал1 > a2) { ал1 = a2;  }
               
                if (ан1 < a1 & ав > ан) { ав1 = ан;}
                if (ав1 < a1 & ан > ав) { ан1 = ав;  }
                if (ап1 < a2 & ал > ап) { ал1 = ап; }
                if (ал1 < a1 & ап > ал) { ап1 = ал; }
                if (ал == 0 & ап == 0)
                {
                    //Abmax = (a1 * 2 + a2) * a1;
                    //sluch1 = sluch1 + $"\n$$ A_{{b,max}}=(2a_1+a_2)\\cdot a_1 =(2\\cdot{a1}+{a2})\\cdot{a1}={Abmax.ToString("0.##")}\\text{{ см}}^2;$$\n";
                    if (ав > a1) { ав1 = a1; }
                    if (ан > a1) { ан1 = a1;}
                    Afac = (ан1 + ав1 + a2) * a1;
                    sluch1 = sluch1 + $"\n$ \\text{{Фактическая расчетная площадь: }}$\n" +
                        $"\n$$ A_{{b,fac}}= (a_{{\\text{{н}}}}+ a_{{\\text{{в}}}}+a_2)\\cdot a_1=({ан1}+{ав1}+{a2})\\cdot {a1}={Afac.ToString("0.##")} \\text{{ см}}^2;$$\n";
                    //if (Afac < Abmax) { Abmax = Afac; sluch1 = sluch1 + $"\n$$ \\text{{Принимаем: }} A_{{b,max}}={Abmax.ToString("0.##")} \\text{{ см}}^2;$$\n"; }
                    if (Аверх.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick](0,{(a2 + ав)  *G/15})--({(a1)  *G/15},{(a2 + ав)  *G/15});";
                    }
                    if (Аниж.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick](0,{(-ан  *G/15)})--({(a1)  *G/15},{(-ан  *G/15)});";
                    }


                    //добавим размеры к сторонам если они большие
                    if (Аверх.IsChecked == true & ав>ав1)
                    {
                        risunok = risunok + $"\\draw(-0.1,{(ав * G / 15)})--(-0.8,{(ав * G / 15)});" +
                             $"\\draw(-0.7,{((a2+ав) * G / 15) + 0.1})--(-0.7,{((a2 + ав1) * G / 15)});" +
                             $"\\node [rotate=90]at ({ -0.9}, {(a2 + ав) * G / 15 - (ав - ав1) * G / 30}) {{{ав- ав1}}};";
                    }
                    if (Аниж.IsChecked == true & ан > ан1)
                    {
                        risunok = risunok + $"\\draw(-0.1,{(-ан * G / 15)})--(-0.8,{(-ан * G / 15)});" +
                            $"\\draw(-0.7,{(-ан * G / 15) - 0.1})--(-0.7,{(-ан1 * G / 15)});" +
                            $"\\node [rotate=90]at ({ -0.9}, {-ан * G / 15 + (ан - ан1) * G / 30}) {{{ан- ан1}}};";
                    }

                    risunok = risunok + $"\\draw[thick](0,{(-ан  *G/15)})--(0,{(a2 + ав)  *G/15});" +
                     $"\\draw[thick]({(a1)  *G/15},{(-ан  *G/15)})--({(a1)  *G/15},{(a2 + ав)  *G/15});";

                    risunok = risunok +
                    //$"\n\\draw[black,dashed](0,{(-a1  *G/15)})--({(a1  *G/15)},{(-a1  *G/15)})--({(a1  *G/15)},{(a2 + a1)  *G/15})--(0, {(a2 + a1)  *G/15})--cycle;" +

             //добавим размеры нижние
             $"\\draw({-0.1}, {((-ан)  *G/15) - 0.7})--({((a1)  *G/15) + 0.1}, {((-ан)  *G/15) - 0.7});" +
             $"\\draw(0, {((-ан)  *G/15) - 0.1})--(0, {((-ан)  *G/15) - 0.8});" +
             $"\\draw({a1  *G/15}, {((-ан)  *G/15) - 0.1})--({a1  *G/15}, {((-ан)  *G/15) - 0.8});" +
             $"\\node at ({a1  *G/30}, {((-ан)  *G/15) - 0.4}) {{{a1}}};" +

             //добавим размеры верхние
             $"\\draw({((-ал)  *G/15) - 0.1}, {((-ан1)  *G/15)})--( {-0.8}, {((-ан1)  *G/15) });" +
             $"\\draw({((-ал)  *G/15) - 0.1}, {((a2 + ав1)  *G/15)})--({ -0.8}, {((a2 + ав1)  *G/15) });" +
             $"\\draw({-0.7}, {(((-ан1)  *G/15) - 0.1)})--({-0.7}, {(((a2 + ав1)  *G/15) + 0.1) });" +

             $"\\draw({ -0.1}, 0)--({ -0.8}, 0);" +
             $"\\draw({ -0.1}, {a2  *G/15})--({-0.8}, {a2  *G/15});" +
             $"\\node[rotate=90] at ({-0.9}, {a2  *G/30}) {{{a2}}};" +
             $"\\node [rotate=90]at ({ -0.9}, {-ан1  *G/30}) {{{ан1}}};" +
             $"\\node [rotate=90]at ({-0.9}, {(a2  *G/15) + (ав1  *G/30)}) {{{ав1}}};";


                }

                if (ав == 0 & ан == 0)
                {
                    //Abmax = (a2 * 2 + a1) * a2;
                    //sluch1 = sluch1 + $"\n$$ A_{{b,max}}=(2a_2+a_1)\\cdot a_2 =(2\\cdot{a2}+{a1})\\cdot{a2}={Abmax.ToString("0.##")}\\text{{ см}}^2;$$\n";
                    if (ап > a1) { ап1 = a2; }
                    if (ал > a1) { ал1 = a2;  }

                    Afac = (ал1 + ап1 + a1) * a2;
                    sluch1 = sluch1 + $"\n$ \\text{{Фактическая расчетная площадь: }}$\n" +
                        $"\n$$ A_{{b,fac}}=(a_{{\\text{{л}}}}+ a_{{\\text{{п}}}}+a_1)\\cdot a_2=({ал1}+{ап1}+{a1})\\cdot {a2}={Afac} \\text{{ см}}^2;$$\n";
                    //if (Afac < Abmax) { Abmax = Afac; sluch1 = sluch1 + $"\n$$ \\text{{Принимаем: }} A_{{b,max}}={Abmax.ToString("0.##")} \\text{{ см}}^2;$$\n"; }
                    if (Аправ.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({((a1 + ап)  *G/15)}, 0)--({((a1 + ап)  *G/15)}, {(a2)  *G/15});";
                    }
                    if (Алев.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({(-ал)  *G/15}, 0)--({(-ал)  *G/15}, {(a2)  *G/15});";
                    }


                    //добавим размеры к сторонам если они большие
                    if (Аправ.IsChecked == true & ап > ап1)
                    {
                        risunok = risunok + $"\\draw({(ап+a1) * G / 15}, {-0.1})--({(ап+a1) * G / 15}, {-0.8});" +
                            $"\\draw({(ап+a1) * G / 15 + 0.1}, {-0.7})--({(ап1+a1) * G / 15}, {-0.7});" +
                             $"\\node at ({((ап+a1) * G) / 15 - (ап - ап1) * G / 30}, { -0.4}) {{{ап - ап1}}};";
                    }
                    if (Алев.IsChecked == true & ал > ал1)
                    {
                        risunok = risunok + $"\\draw({((-ал)) * G / 15}, {-0.1})--({(-ал) * G / 15}, {-0.8});" +
                            $"\\draw({(-ал) * G / 15 - 0.1}, {-0.7})--({(-ал1) * G / 15}, {-0.7});" +
                             $"\\node at ({((-ал) * G) / 15 + (ал - ал1) * G / 30}, { -0.4}) {{{ал - ал1}}};";
                    }
                    risunok = risunok + $"\\draw[thick]({(-ал)  *G/15}, 0)--({((a1 + ап)  *G/15)},0);" +
               $"\\draw[thick]({(a1 + ап)  *G/15}, {(a2)  *G/15})--({((-ал)  *G/15)},{(a2)  *G/15});" +
         

             //добавим размеры нижние
             $"\\draw({(-ал1)  *G/15}, {-0.1})--({(-ал1)  *G/15}, {-0.8});" +
             $"\\draw({(a1 + ап1)  *G/15}, {-0.1})--({(a1 + ап1)  *G/15}, {-0.8});" +
             $"\\draw({((-ал1)  *G/15) - 0.1}, {-0.7})--({((a1 + ап1)  *G/15) + 0.1}, {-0.7});" +
             $"\\draw(0, {-0.1})--(0, {-0.8});" +
             $"\\draw({a1  *G/15}, {-0.1})--({a1  *G/15}, {-0.8});" +
             $"\\node at ({-ал1  *G/30}, { -0.4}) {{{ал1}}};" +
             $"\\node at ({a1  *G/30}, {-0.4}) {{{a1}}};" +
             $"\\node at ({(a1  *G/15) + (ап1  *G/30)}, {-0.4}) {{{ап1}}};" +

             //добавим размеры верхние
             $"\\draw({((-ал)  *G/15) - 0.1}, 0)--({((-ал)  *G/15) - 0.8}, 0);" +
             $"\\draw({((-ал)  *G/15) - 0.1}, {((a2)  *G/15)})--({((-ал)  *G/15) - 0.8}, {((a2)  *G/15) });" +
             $"\\draw({((-ал)  *G/15) - 0.7}, {(-0.1)})--({((-ал)  *G/15) - 0.7}, {(((a2)  *G/15) + 0.1) });" +

             $"\\node[rotate=90] at ({((-ал)  *G/15) - 0.9}, {a2  *G/30}) {{{a2}}};";


                }


                risunok = risunok + $"\\draw[black,dashed]({(-ал1) * G / 15}, {(-ан1) * G / 15})--({((a1 + ап1) * G / 15)},{(-ан1) * G / 15})--({((a1 + ап1) * G / 15)},{(ав1 + a2) * G / 15})--({(-ал1) * G / 15}, {(a2 + ав1) * G / 15})--cycle;" +
                        $"\\end{{tikzpicture}}\\end{{center}}\n";

            }

            //на углу элемента
            else if ((ан == 0 & ал == 0) || (ан == 0 & ап == 0) || (ав == 0 & ап == 0) || (ав == 0 & ал == 0))
            {
                risunok = risunok+
                    $"\n\\draw[black,dashed](0,0)--({(a1*G / 15)},0)--({(a1 * G / 15)},{(a2 * G / 15)})--(0,{(a2 * G / 15)})--cycle;";
                Abmax = a1 * a2;
                Afac = a1 * a2;
                sluch1 = sluch1 + $"\n$$ A_{{b,fac}}=a_1\\cdot a_2 ={a1}\\cdot{a2}={Afac.ToString("0.##")}\\text{{ см}}^2;$$\n";
                if (ав == 0 & ап == 0)
                {
                    Amin = (ал + a1) * (ан + a2);
                    if (Аниж.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({((a1) *G/15)}, {(-ан) *G/15})--({((-ал) *G/15)}, {(-ан) *G/15});"+
                            $"\\draw({((-ал) * G / 15) - 0.1}, {((-ан) * G / 15)})--({((-ал) * G / 15) - 0.8}, {((-ан) * G / 15) });" +
                            $"\\draw({((-ал) * G / 15) - 0.7}, {(((-ан) * G / 15) - 0.1)})--({((-ал) * G / 15) - 0.7}, 0);" +
                             $"\\node [rotate=90]at ({((-ал) * G / 15) - 0.9}, {-ан * G / 30}) {{{ан}}};";

                    }
                    if (Алев.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({(-ал) * G / 15}, {(a2) * G / 15})--({(-ал) * G / 15}, {(-ан) * G / 15});" +
                             $"\\draw({(-ал) * G / 15}, {((-ан) * G / 15) - 0.1})--({(-ал) * G / 15}, {((-ан) * G / 15) - 0.8});" +
                             $"\\draw({((-ал) * G / 15) - 0.1}, {((-ан) * G / 15) - 0.7})--(0, {((-ан) * G / 15) - 0.7});" +
                                  $"\\node at ({-ал * G / 30}, {((-ан) * G / 15) - 0.4}) {{{ал}}};";
                    }

                    risunok = risunok + $"\\draw[thick]({((a1) * G / 15)},{(a2) * G / 15})--({((a1) * G / 15)},{(-ан) * G / 15});" +
               $"\\draw[thick]({((a1) * G / 15)}, {(a2) * G / 15})--({((-ал) * G / 15)},{(a2) * G / 15});" +
                    //добавим размеры нижние
             $"\\draw(0, {((-ан) * G / 15) - 0.7})--({((a1) * G / 15) + 0.1}, {((-ан) * G / 15) - 0.7});" +
             $"\\draw(0, {((-ан) * G / 15) - 0.1})--(0, {((-ан) * G / 15) - 0.8});" +
             $"\\draw({a1 * G / 15}, {((-ан) * G / 15) - 0.1})--({a1 * G / 15}, {((-ан) * G / 15) - 0.8});" +

             $"\\node at ({a1 * G / 30}, {((-ан) * G / 15) - 0.4}) {{{a1}}};" +

             //добавим размеры верхние

             $"\\draw({((-ал) * G / 15) - 0.7}, - 0.1)--({((-ал) * G / 15) - 0.7}, {(((a2) * G / 15) + 0.1) });" +

             $"\\draw({((-ал) * G / 15) - 0.1}, 0)--({((-ал) * G / 15) - 0.8}, 0);" +
             $"\\draw({((-ал) * G / 15) - 0.1}, {a2 * G / 15})--({((-ал) * G / 15) - 0.8}, {a2 * G / 15});" +
             $"\\node[rotate=90] at ({((-ал) * G / 15) - 0.9}, {a2 * G / 30}) {{{a2}}};";
            
                }
                if (ав == 0 & ал == 0)
                {
                    Amin = (ап + a1) * (ан + a2);
                    if (Аниж.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick](0,{-ан *G/15})--({(a1 + ап) *G/15},{-ан *G/15});"+
                            $"\\draw(- 0.1, {((-ан) * G / 15)})--({ - 0.8}, {((-ан) * G / 15) });" +
                            $"\\draw(- 0.7, {(((-ан) * G / 15) - 0.1)})--({ - 0.7}, 0);" +
                             $"\\node [rotate=90]at ({- 0.9}, {-ан * G / 30}) {{{ан}}};";
                    }
                    if (Аправ.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({(a1 + ап) * G / 15},{a2 * G / 15})--({(a1 + ап) * G / 15},{-ан * G / 15});" +
                             $"\\draw({(a1 + ап) * G / 15}, {((-ан) * G / 15) - 0.1})--({(a1 + ап) * G / 15}, {((-ан) * G / 15) - 0.8});" +
                              $"\\draw({((a1) * G / 15)}, {((-ан) * G / 15) - 0.7})--({((a1 + ап) * G / 15) + 0.1}, {((-ан) * G / 15) - 0.7});" +
                              $"\\node at ({(a1 * G / 15) + (ап * G / 30)}, {((-ан) * G / 15) - 0.4}) {{{ап}}};";
                    }

                    risunok = risunok + $"\\draw[thick](0,{-ан *G/15})--(0,{a2 *G/15})--({(a1 + ап) *G/15},{a2 *G/15});" +
             //добавим размеры нижние
             
             $"\\draw({-0.1}, {((-ан) *G/15) - 0.7})--({((a1) *G/15) + 0.1}, {((-ан) *G/15) - 0.7});" +
             $"\\draw(0, {((-ан) *G/15) - 0.1})--(0, {((-ан) *G/15) - 0.8});" +
             $"\\draw({a1 *G/15}, {((-ан) *G/15) - 0.1})--({a1 *G/15}, {((-ан) *G/15) - 0.8});" +
             $"\\node at ({a1 *G/30}, {((-ан) *G/15) - 0.4}) {{{a1}}};" +
             

             //добавим размеры верхние
             $"\\draw({- 0.1}, {((ав) *G/15)})--({- 0.8}, {((ав) *G/15) });" +

             $"\\draw({- 0.7}, { - 0.1})--({- 0.7}, {(((a2) *G/15) + 0.1) });" +

             $"\\draw({ - 0.1}, 0)--({ - 0.8}, 0);" +
             $"\\draw({- 0.1}, {a2 *G/15})--({ - 0.8}, {a2 *G/15});" +
             $"\\node[rotate=90] at ({((-ал) *G/15) - 0.9}, {a2 *G/30}) {{{a2}}};" ;
                }
                if (ан == 0 & ал == 0)
                {
                    Amin = (ап + a1) * (ав + a2);

                    if (Аправ.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({(a1 + ап) * G / 15},0)--({(a1 + ап) * G / 15},{(a2 + ав) * G / 15});" +
                             $"\\draw({(a1 + ап) * G / 15}, {((-ан) * G / 15) - 0.1})--({(a1 + ап) * G / 15}, {((-ан) * G / 15) - 0.8});" +
                             $"\\draw({((a1) * G / 15)}, {((-ан) * G / 15) - 0.7})--({((a1 + ап) * G / 15) + 0.1}, {((-ан) * G / 15) - 0.7});" +
                              $"\\node at ({(a1 * G / 15) + (ап * G / 30)}, {((-ан) * G / 15) - 0.4}) {{{ап}}};";
                    }
                    if (Аверх.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick](0,{(a2 + ав) *G/15})--({(a1 + ап) *G/15},{(a2 + ав) *G/15});"+
                            $"\\draw({ -0.1}, {((a2 + ав) * G / 15)})--({ -0.8}, {((a2 + ав) * G / 15) });" +
                             $"\\draw({ -0.7}, {((a2) * G / 15)})--({ -0.7}, {(((a2 + ав) * G / 15) + 0.1) });" +
                             $"\\node [rotate=90]at ({-0.9}, {(a2 * G / 15) + (ав * G / 30)}) {{{ав}}};";
                    }

                    risunok = risunok + $"\\draw[thick](0,{(a2 + ав) * G / 15})--(0,0)--({(a1 + ап) * G / 15},0);" +
             //добавим размеры нижние


             $"\\draw({-0.1}, {((-ан) * G / 15) - 0.7})--({((a1) * G / 15) + 0.1}, {((-ан) * G / 15) - 0.7});" +
             $"\\draw(0, {((-ан) * G / 15) - 0.1})--(0, {((-ан) * G / 15) - 0.8});" +
             $"\\draw({a1 * G / 15}, {((-ан) * G / 15) - 0.1})--({a1 * G / 15}, {((-ан) * G / 15) - 0.8});" +
             $"\\node at ({a1 * G / 30}, {((-ан) * G / 15) - 0.4}) {{{a1}}};" +


             //добавим размеры верхние
             $"\\draw({ -0.1}, 0)--({ -0.8}, 0);" +

             $"\\draw({ -0.7}, {(-0.1)})--({ -0.7}, {(((a2) * G / 15) + 0.1) });" +

             $"\\draw({ -0.1}, {a2 * G / 15})--({-0.8}, {a2 * G / 15});" +
             $"\\node[rotate=90] at ({ -0.9}, {a2 * G / 30}) {{{a2}}};";
             

                }
                if (ан == 0 & ап == 0)
                {
                    Amin = (ал + a1) * (ав + a2);
                    if (Алев.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({-ал * G / 15},0)--({-ал * G / 15},{(a2 + ав) * G / 15});" +
                             $"\\draw({(-ал) * G / 15}, {-0.1})--({(-ал) * G / 15}, { -0.8});" +
                             $"\\draw({((-ал) * G / 15) - 0.1}, {-0.7})--(0, { -0.7});" +
                             $"\\node at ({-ал * G / 30}, {((-ан) * G / 15) - 0.4}) {{{ал}}};";
                    }
                    if (Аверх.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({-ал *G/15},{(a2 + ав) *G/15})--({(a1) *G/15},{(a2 + ав) *G/15});"+
                             $"\\draw({((-ал) * G / 15) - 0.1}, {((a2 + ав) * G / 15)})--({((-ал) * G / 15) - 0.8}, {((a2 + ав) * G / 15) });" +
                             $"\\draw({((-ал) * G / 15) - 0.7}, {((a2 ) * G / 15)})--({((-ал) * G / 15) - 0.7}, {(((a2 + ав) * G / 15) + 0.1) });" +
                              $"\\node [rotate=90]at ({((-ал) * G / 15) - 0.9}, {(a2 * G / 15) + (ав * G / 30)}) {{{ав}}};";
                    }

                    risunok = risunok + $"\\draw[thick]({-ал * G / 15},0)--({(a1) * G / 15},0)--({(a1) * G / 15},{(a2 + ав) * G / 15});" +
             //добавим размеры нижние


             $"\\draw({-0.1}, {-0.7})--({((a1) * G / 15) + 0.1}, { -0.7});" +
             $"\\draw(0, {-0.1})--(0, { -0.8});" +
             $"\\draw({a1 * G / 15}, {-0.1})--({a1 * G / 15}, {-0.8});" +

             $"\\node at ({a1 * G / 30}, {((-ан) * G / 15) - 0.4}) {{{a1}}};" +

             //добавим размеры верхние

             $"\\draw({((-ал) * G / 15) - 0.7}, {(-0.1)})--({((-ал) * G / 15) - 0.7}, {(((a2) * G / 15) + 0.1) });" +

             $"\\draw({((-ал) * G / 15) - 0.1}, 0)--({((-ал) * G / 15) - 0.8}, 0);" +
             $"\\draw({((-ал) * G / 15) - 0.1}, {a2 * G / 15})--({((-ал) * G / 15) - 0.8}, {a2 * G / 15});" +
             $"\\node[rotate=90] at ({((-ал) * G / 15) - 0.9}, {a2 * G / 30}) {{{a2}}};";
            
                }

                risunok = risunok + 
                    $"\\end{{tikzpicture}}\\end{{center}}\n";

            }
            
            //у одного края элемента
            else if (ав==0 || ан==0 || ал==0 || ап==0)
            {

                if (ав1 > a1) { ав1 = a1;}
                if (ан1 > a1) { ан1 = a1; }
                if (ап1 > a2) { ап1 = a2;  }
                if (ал1 > a2) { ал1 = a2;  }

                if (ан1 < a1 & ав > ан) { ав1 = ан;  }
                if (ав1 < a1 & ан > ав) { ан1 = ав; }
                if (ап1 < a2 & ал > ап) { ал1 = ап; }
                if (ал1 < a1 & ап > ал) { ап1 = ал;  }
               
                if (ал == 0)
                {
                    //Abmax = (a2 + a1 * 2) * a1;
                    //sluch1 = sluch1 + $"\n$$ A_{{b,max}}=(a_2+2a_1)\\cdot a_1 =({a2}+2\\cdot{a1})\\cdot{a1}={Abmax.ToString("0.##")}\\text{{ см}}^2;$$\n";
                    if (ав1 > a1) { ав1 = a1;  }
                    if (ан1 > a1) { ан1 = a1;}
                    Afac = (a2 + ав1 + ан1) * a1;
                    sluch1 = sluch1 + $"\n$ \\text{{Фактическая расчетная площадь: }}$\n" +
                        $"\n$$ A_{{b,fac}}= (a_2+ a_{{\\text{{в}}}}+a_{{\\text{{н}}}})\\cdot a_1=({a2}+{ав1}+{ан1})\\cdot {a1}={Afac} \\text{{ см}}^2;$$\n";
                    if (Аверх.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick](0,{(a2 + ав) * G / 15})--({(a1 + ап) * G / 15},{(a2 + ав) * G / 15});" +
                            $"\\draw({ -0.1}, {((a2 + ав) * G / 15)})--( - 0.8, {((a2 + ав) * G / 15) });" +
                             $"\\draw({-0.7}, {(((a2 + ав1) * G / 15))})--(- 0.7, {(((a2 + ав) * G / 15) + 0.1) });";
                             if (ав > ав1)
                        {
                            risunok = risunok + $"\\node [rotate=90]at ({-0.9}, {((a2 + ав1) * G / 15) + ((ав - ав1) * G / 30)}) {{{ав}}};";
                        }
                           
                    }
                    if (Аниж.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick](0,{(-ан * G / 15)})--({(a1 + ап) * G / 15},{(-ан * G / 15)});" +
                             $"\\draw({ -0.1}, {((-ан) * G / 15)})--({ -0.8}, {((-ан) * G / 15) });" +
                             $"\\draw({-0.7}, {(((-ан1) * G / 15) - 0.1)})--(- 0.7, {((-ан) * G / 15)});";
                        if (ан>ан1)
                        {
                            risunok = risunok + $"\\node [rotate=90]at ({-0.9}, {-ан1 * G / 30}) {{{ан1}}};";
                        }
                        
                    }
                    if (Аправ.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({(a1 + ап) * G / 15},{(-ан * G / 15)})--({(a1 + ап) * G / 15},{(a2 + ав) * G / 15});" +
                            $"\\draw({(a1 + ап) * G / 15}, {((-ан) * G / 15) - 0.1})--({(a1 + ап) * G / 15}, {((-ан) * G / 15) - 0.8});" +
                            $"\\draw({((a1) * G / 15)}, {((-ан) * G / 15) - 0.7})--({((a1 + ап) * G / 15) + 0.1}, {((-ан) * G / 15) - 0.7});" +
                             $"\\node at ({(a1 * G / 15) + (ап * G / 30)}, {((-ан) * G / 15) - 0.4}) {{{ап}}};";
                    }
                        risunok = risunok + $"\\draw[thick](0,{(-ан *G/15)})--(0,{(a2 + ав) *G/15});" +
                    

                    //добавим размеры нижние
                    
             $"\\draw({-0.1}, {((-ан) *G/15) - 0.7})--({((a1) *G/15) + 0.1}, {((-ан) *G/15) - 0.7});" +
             $"\\draw(0, {((-ан) *G/15) - 0.1})--(0, {((-ан) *G/15) - 0.8});" +
             $"\\draw({a1 *G/15}, {((-ан) *G/15) - 0.1})--({a1 *G/15}, {((-ан) *G/15) - 0.8});" +
             $"\\node at ({a1 *G/30}, {((-ан) *G/15) - 0.4}) {{{a1}}};" +


             //добавим размеры верхние
             $"\\draw({ -0.1}, {((a2 + ав1) * G / 15)})--( - 0.8, {((a2 + ав1) * G / 15) });" +
             $"\\draw({-0.7}, {(((a2) * G / 15))})--(- 0.7, {(((a2 + ав1) * G / 15) + 0.1) });" +
             $"\\node [rotate=90]at ({-0.9}, {(a2 * G / 15) + (ав1 * G / 30)}) {{{ав1}}};"+

              $"\\draw({ -0.1}, {((-ан1) * G / 15)})--({ -0.8}, {((-ан1) * G / 15) });" +
             $"\\draw({-0.7}, {(((-ан1) * G / 15) - 0.1)})--(- 0.7, 0);" +
             $"\\node [rotate=90]at ({-0.9}, {-ан1 * G / 30}) {{{ан1}}};"+

             $"\\draw({-0.7}, { -0.1})--(- 0.7, {((a2) *G/15) });" +
             $"\\draw({ -0.1}, 0)--({ - 0.8}, 0);" +
             $"\\draw({ -0.1}, {a2 *G/15})--({ - 0.8}, {a2 *G/15});" +
             $"\\node[rotate=90] at ({-0.9}, {a2 *G/30}) {{{a2}}};" ;

                }
                if (ап == 0)
                {
                    //Abmax = (a2 + a1 * 2) * a1;
                    //sluch1 = sluch1 + $"\n$$ A_{{b,max}}=(a_2+2a_1)\\cdot a_1 =({a2}+2\\cdot{a1})\\cdot{a1}={Abmax.ToString("0.##")}\\text{{ см}}^2;$$\n";
                    if (ав1 > a1) { ав1 = a1; /*sluch1 = sluch1 + $"\n$$ \\text{{Принимаем в учет: }} a_{{\\text{{в}}}} ={ав1}\\text{{ см}}^2;$$\n"; */}
                    if (ан1 > a1) { ан1 = a1; /*sluch1 = sluch1 + $"\n$$ \\text{{Принимаем в учет: }} a_{{\\text{{н}}}} ={ан1}\\text{{ см}}^2;$$\n";*/ }
                    Afac = (a2 + ав1 + ан1) * a1;
                    sluch1 = sluch1 + $"\n$ \\text{{Фактическая расчетная площадь: }}$\n" +
                       $"\n$$  A_{{b,fac}}= (a_2+ a_{{\\text{{в}}}}+a_{{\\text{{н}}}})\\cdot a_1=({a2}+{ав1}+{ан1})\\cdot {a1}={Afac} \\text{{ см}}^2;$$\n";
                    if (Аверх.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({-ал * G / 15},{(a2 + ав) * G / 15})--({(a1) * G / 15},{(a2 + ав) * G / 15});" +
                              $"\\draw({((-ал) * G / 15) - 0.1},{(((a2 + ав) * G / 15)) })--({((-ал) * G / 15) - 0.8},{(((a2 + ав) * G / 15)) });" +
                             $"\\draw({((-ал) * G / 15) - 0.7}, {((a2 + ав1) * G / 15) })--({((-ал) * G / 15) - 0.7}, {(((a2 + ав) * G / 15) + 0.1) });";
                        if (ав > ав1)
                        {
                            risunok = risunok + $"\\node [rotate=90]at ({((-ал) * G / 15) - 0.9}, {((a2 + ав1) * G / 15) + ((ав - ав1) * G / 30)}) {{{ав - ав1}}};";
                        }
                        
                    }
                    if (Аниж.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({-ал * G / 15},{(-ан * G / 15)})--({(a1) * G / 15},{(-ан * G / 15)});" +
                            $"\\draw({((-ал) * G / 15) - 0.1}, {((-ан) * G / 15)})--({((-ал) * G / 15) - 0.8}, {((-ан) * G / 15) });" +
                            $"\\draw({((-ал) * G / 15) - 0.7}, {((-ан) * G / 15) - 0.1})--({((-ал) * G / 15) - 0.7}, {((-ан1) * G / 15) });";
                            if (ан > ан1)
                        {
                            risunok = risunok + $"\\node [rotate=90]at ({((-ал) * G / 15) - 0.9}, {-ан * G / 15 + (ан - ан1) * G / 30}) {{{ан - ан1}}};";
                        }
                        

                    }
                    if (Алев.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw({(-ал) * G / 15}, {((-ан) * G / 15) - 0.1})--({(-ал) * G / 15}, {((-ан) * G / 15) - 0.8});" +
                             $"\\draw({((-ал) * G / 15) - 0.1}, {((-ан) * G / 15) - 0.7})--(0, {((-ан) * G / 15) - 0.7});" +
                              $"\\draw[thick]({(-ал) * G / 15},{(-ан * G / 15)})--({(-ал) * G / 15},{(a2 + ав) * G / 15});" +
                              $"\\node at ({-ал * G / 30}, {((-ан) * G / 15) - 0.4}) {{{ал}}};";
                    }
                    risunok = risunok + $"\\draw[thick]({(a1) *G/15},{(-ан *G/15)})--({(a1) *G/15},{(a2 + ав) *G/15});" +
                   
                 //добавим размеры нижние
                    
             $"\\draw({- 0.1}, {((-ан) *G/15) - 0.7})--({((a1) *G/15) + 0.1}, {((-ан) *G/15) - 0.7});" +
             $"\\draw(0, {((-ан) *G/15) - 0.1})--(0, {((-ан) *G/15) - 0.8});" +
             $"\\draw({a1 *G/15}, {((-ан) *G/15) - 0.1})--({a1 *G/15}, {((-ан) *G/15) - 0.8});" +
             $"\\node at ({a1 *G/30}, {((-ан) *G/15) - 0.4}) {{{a1}}};" +
             $"\\draw({((-ал) * G / 15) - 0.7}, {((-ан1) * G / 15) - 0.1})--({((-ал) * G / 15) - 0.7}, 0);" +

             //добавим размеры верхние
             $"\\draw({((-ал) * G / 15) - 0.1}, {((a2 + ав1) * G / 15)})--({((-ал) * G / 15) - 0.8}, {((a2 + ав1) * G / 15) });" +
              $"\\draw({((-ал) * G / 15) - 0.7}, {(((-ан1) * G / 15) - 0.1)})--({((-ал) * G / 15) - 0.7}, {((-ан1) * G / 15) });" +
              $"\\draw({((-ал) * G / 15) - 0.7}, {((a2) * G / 15) })--({((-ал) * G / 15) - 0.7}, {(((a2 + ав1) * G / 15) + 0.1) });" +
              $"\\draw({((-ал) * G / 15) - 0.1}, {((-ан1) * G / 15)})--({((-ал) * G / 15) - 0.8}, {((-ан1) * G / 15) });" +

             $"\\draw({((-ал) *G/15) - 0.7}, {(- 0.1)})--({((-ал) *G/15) - 0.7}, {(((a2) *G/15) + 0.1) });" +
             $"\\draw({((-ал) *G/15) - 0.1}, 0)--({((-ал) *G/15) - 0.8}, 0);" +
             $"\\draw({((-ал) *G/15) - 0.1}, {a2 *G/15})--({((-ал) *G/15) - 0.8}, {a2 *G/15});" +
             $"\\node[rotate=90] at ({((-ал) *G/15) - 0.9}, {a2 *G/30}) {{{a2}}};" +
             $"\\node [rotate=90]at ({((-ал) *G/15) - 0.9}, {-ан1 *G/30}) {{{ан1}}};" +
             $"\\node [rotate=90]at ({((-ал) *G/15) - 0.9}, {(a2 *G/15) + (ав1 *G/30)}) {{{ав1}}};"+
              $"\\node [rotate=90]at ({((-ал) * G / 15) - 0.9}, {(a2 * G / 15) + (ав1 * G / 30)}) {{{ав1}}};";

                }
                if (ав == 0)
                {
                    //Abmax = (a1 + a2 * 2) * a2;
                    //sluch1 = sluch1 + $"\n$$ A_{{b,max}}=(a_1+2a_2)\\cdot a_2 =({a1}+2\\cdot{a2})\\cdot{a2}={Abmax.ToString("0.##")}\\text{{ см}}^2;$$\n";
                    if (ал1 > a2) { ал1 = a2; }
                    if (ап1 > a2) { ап1 = a2; }
                    Afac = (a1 + ал1 + ап1) * a2;
                    sluch1 = sluch1 + $"\n$ \\text{{Фактическая расчетная площадь: }}$\n" +
                        $"\n$$ A_{{b,fac}}= (a_1+ a_{{\\text{{п}}}}+a_{{\\text{{л}}}})\\cdot a_2=({a1}+{ап1}+{ал1})\\cdot {a2}={Afac} \\text{{ см}}^2;$$\n";
                    double ан3 = ан;
                   
                    if (Аниж.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({(-ал) * G / 15}, {(-ан * G / 15)})--({((a1 + ап) * G / 15)},{(-ан * G / 15)});" +
                            $"\\draw({((-ал) * G / 15) - 0.1}, {((-ан) * G / 15)})--({((-ал) * G / 15) - 0.8}, {((-ан) * G / 15) });" +
                             $"\\draw({((-ал) * G / 15) - 0.7}, {(((-ан) * G / 15) - 0.1)})--({((-ал) * G / 15) - 0.7}, 0);" +
                              $"\\node [rotate=90]at ({((-ал) * G / 15) - 0.9}, {-ан1 - (ан - ан1) * G / 30}) {{{ан - ан1}}};";
                    }
                    else { ан3 = 0; }
                    if (Аправ.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({((a1 + ап) * G / 15)}, {(-ан3 * G / 15)})--({((a1 + ап) * G / 15)}, {(a2) * G / 15});" +
                             $"\\draw({(a1 + ап) * G / 15}, {((-ан3) * G / 15) - 0.1})--({(a1 + ап) * G / 15}, {((-ан3) * G / 15) - 0.8});" +
                              $"\\draw({((a1 + ап1) * G / 15) }, {((-ан3) * G / 15) - 0.7})--({((a1 + ап) * G / 15) + 0.1}, {((-ан3) * G / 15) - 0.7});";
                        if (ап > ап1)
                        {
                            risunok = risunok + $"\\node at ({((a1 + ап1) * G / 15) + ((ап - ап1) * G / 30)}, {((-ан3) * G / 15) - 0.4}) {{{ап - ап1}}};";
                        }
                               
                    }
                    if (Алев.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({(-ал) * G / 15}, {(-ан3 * G / 15)})--({(-ал) * G / 15}, {(a2) * G / 15});" +
                             $"\\draw({(-ал) * G / 15}, {((-ан3) * G / 15) - 0.1})--({(-ал) * G / 15}, {((-ан3) * G / 15) - 0.8});" +
                             $"\\draw({((-ал) * G / 15) - 0.1}, {((-ан3) * G / 15) - 0.7})--({((-ап1) * G / 15) + 0.1}, {((-ан3) * G / 15) - 0.7});";

                        if (ал > ал1)
                        {
                            risunok = risunok + $"\\node at ({-ал1 * G / 15 - ((ал - ал1) * G / 30)}, {((-ан3) * G / 15) - 0.4}) {{{ал - ал1}}};";
                        }
                            
                    }


                    risunok = risunok + 
              $"\\draw[thick]({(a1 + ап) * G / 15}, {(a2) * G / 15})--({((-ал) * G / 15)},{(a2) * G / 15});" +
             //добавим размеры нижние
             $"\\draw({(-ал1) *G/15}, {((-ан3) *G/15) - 0.1})--({(-ал1) *G/15}, {((-ан3) *G/15) - 0.8});" +
             $"\\draw({(a1 + ап1) *G/15}, {((-ан3) *G/15) - 0.1})--({(a1 + ап1) *G/15}, {((-ан3) *G/15) - 0.8});" +
             $"\\draw({((-ал1) *G/15) - 0.1}, {((-ан3) *G/15) - 0.7})--({((a1 + ап1) *G/15) + 0.1}, {((-ан3) *G/15) - 0.7});" +
             $"\\draw(0, {((-ан3) *G/15) - 0.1})--(0, {((-ан3) *G/15) - 0.8});" +
             $"\\draw({a1 *G/15}, {((-ан3) *G/15) - 0.1})--({a1 *G/15}, {((-ан3) *G/15) - 0.8});" +
             $"\\node at ({-ал1 *G/30}, {((-ан3) *G/15) - 0.4}) {{{ал1}}};" +
             $"\\node at ({a1 *G/30}, {((-ан3) *G/15) - 0.4}) {{{a1}}};" +
             $"\\node at ({(a1 *G/15) + (ап1 *G/30)}, {((-ан3) *G/15) - 0.4}) {{{ап1}}};" +

             //добавим размеры верхние
             
             $"\\draw({((-ал) *G/15) - 0.1}, {((a2) *G/15)})--({((-ал) *G/15) - 0.8}, {((a2) *G/15) });" +
             $"\\draw({((-ал) * G / 15) - 0.7}, {a2 * G / 15}+0.1)--({((-ал) * G / 15) - 0.7}, -0.1);" +
             $"\\draw({((-ал) *G/15) - 0.1}, 0)--({((-ал) *G/15) - 0.8}, 0);" +
             $"\\node[rotate=90] at ({((-ал) *G/15) - 0.9}, {a2 *G/30}) {{{a2}}};" ;
                }
                if (ан == 0)
                {
                    //Abmax = (a1 + a2 * 2) * a2;
                    //sluch1 = sluch1 + $"\n$$ A_{{b,max}}=(a_1+2a_2)\\cdot a_2 =({a1}+2\\cdot{a2})\\cdot{a2}={Abmax.ToString("0.##")}\\text{{ см}}^2;$$\n";
                    if (ал1 > a2) { ал1 = a2;  }
                    if (ап1 > a2) { ап1 = a2;}
                    Afac = (a1 + ал1 + ап1) * a2;
                    sluch1 = sluch1 + $"\n$ \\text{{Фактическая расчетная площадь: }}$\n" +
                       $"\n$$ A_{{b,fac}}= (a_1+ a_{{\\text{{п}}}}+a_{{\\text{{л}}}})\\cdot a_2=({a1}+{ап1}+{ал1})\\cdot {a2}={Afac} \\text{{ см}}^2;$$\n";
                    if (Аправ.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({((a1 + ап) * G / 15)}, 0)--({((a1 + ап) * G / 15)}, {(a2 + ав) * G / 15});" +
                            $"\\draw({(a1 + ап) * G / 15}, {-0.1})--({(a1 + ап) * G / 15}, {-0.8});" +
                             $"\\draw({((a1) * G / 15) }, {-0.7})--({((a1 + ап) * G / 15) + 0.1}, { -0.7});" +
                               $"\\node at ({((a1+ап1) * G / 15) + ((ап-ап1) * G / 30)}, {-0.4}) {{{ап}}};";
                    }
                    if (Алев.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({(-ал) * G / 15}, 0)--({(-ал) * G / 15}, {(a2 + ав) * G / 15});" +
                             $"\\draw({(-ал) * G / 15}, {-0.1})--({(-ал) * G / 15}, { -0.8});" +
                              $"\\draw({((-ал) * G / 15) - 0.1}, {-0.7})--({((a1) * G / 15) }, { -0.7});" +
                              $"\\node at ({(-ал * G / 15) - (ал - ал1) * G / 30}, {-0.4}) {{{ал}}};";
                    }
                    if (Аверх.IsChecked == true)
                    {
                        risunok = risunok + $"\\draw[thick]({(-ал) * G / 15}, 0)--({(-ал) * G / 15}, {(a2 + ав) * G / 15});" +
                             $"\\draw[thick]({(a1 + ап) * G / 15},{(a2 + ав) * G / 15})--({((-ал) * G / 15)},{(a2 + ав) * G / 15});"+
                             $"\\draw({((-ал) * G / 15) - 0.1}, {((a2 + ав) * G / 15)})--({((-ал) * G / 15) - 0.8}, {((a2 + ав) * G / 15) });" +
                              $"\\draw({((-ал) * G / 15) - 0.7}, {a2 * G / 15})--({((-ал) * G / 15) - 0.7}, {(((a2 + ав) * G / 15) + 0.1) });" +
                              $"\\node [rotate=90]at ({((-ал) * G / 15) - 0.9}, {(a2 * G / 15) + ((ав-ав1) * G / 30)}) {{{ав}}};";
                    }

                    risunok = risunok + $"\\draw[thick]({(-ал) *G/15}, 0)--({((a1 + ап) *G/15)},0);" +
              
                    //добавим размеры нижние
             $"\\draw({(-ал1) *G/15}, {-0.1})--({(-ал1) *G/15}, { -0.8});" +
             $"\\draw({(a1 + ап1) *G/15}, {-0.1})--({(a1 + ап1) *G/15}, {-0.8});" +
             $"\\draw({((-ал1) *G/15) - 0.1}, {-0.7})--({((a1 + ап1) *G/15) + 0.1}, { -0.7});" +
             $"\\draw(0, {-0.1})--(0, { -0.8});" +
             $"\\draw({a1 *G/15}, {-0.1})--({a1 *G/15}, { -0.8});" +
             $"\\node at ({-ал1 *G/30}, {- 0.4}) {{{ал1}}};" +
             $"\\node at ({a1 *G/30}, {- 0.4}) {{{a1}}};" +
             $"\\node at ({(a1 *G/15) + (ап1 *G/30)}, {- 0.4}) {{{ап1}}};" +

             //добавим размеры верхние
             $"\\draw({((-ал) *G/15) - 0.1},0)--({((-ал) *G/15) - 0.8}, 0);" +
             
             $"\\draw({((-ал) *G/15) - 0.7}, {-0.1})--({((-ал) *G/15) - 0.7}, {(((a2) *G/15) + 0.1) });" +
             $"\\draw({((-ал) *G/15) - 0.1}, {a2 *G/15})--({((-ал) *G/15) - 0.8}, {a2 *G/15});" +
             $"\\node[rotate=90] at ({((-ал) *G/15) - 0.9}, {a2 *G/30}) {{{a2}}};";
                }

                //if (Afac < Abmax) { Abmax = Afac; sluch1 = sluch1 + $"\n$$ \\text{{Принимаем: }} A_{{b,max}}={Abmax.ToString("0.##")} \\text{{ см}}^2;$$\n"; }
                risunok=risunok + $"\\draw[black,dashed]({(-ал1*G) / 15}, {(-ан1 * G) / 15})--({((a1 + ап1) * G / 15)},{(-ан1) * G / 15})--({((a1 + ап1) * G / 15)},{(ав1 + a2) * G / 15})--({(-ал1) * G / 15}, {(a2 + ав1) * G / 15})--cycle;" +

                   $"\\end{{tikzpicture}}\\end{{center}}\n";

            }

            
            
            
            double φb = 0.8 * Math.Sqrt(Afac / Abloc);
            sluch1 = sluch1 + $"\n$$ \\phi_b=0.8 \\cdot \\sqrt{{ \\frac{{A_{{b,fac}}}}{{A_{{b,loc}}}} }}= 0.8 \\cdot \\sqrt{{ \\frac{{{Afac.ToString("0.##")}}}{{{Abloc.ToString("0.##")}}}}}={φb.ToString("0.##")};$$\n";
              
            if ( 1<φb & φb< 2.5)
            {
                sluch1 = sluch1 + $"\n$$ Условие 1 \\leq \\phi_b= {φb.ToString("0.##")} \\leq 2.5 выполняется.$$\n";
            }
            else if (φb < 1)
            {
                sluch1 = sluch1 + $"\n$$ Условие 1 \\nleq \\phi_b= {φb.ToString("0.##")} \\leq 2.5 не выполняется, \\text{{принимаем }} \\phi_b=1 $$\n";
                φb = 1;
            }
            else if (φb > 2.5)
            {
                sluch1 = sluch1 + $"\n$$ Условие 1 \\leq \\phi_b= {φb.ToString("0.##")} \\nleq 2.5 не выполняется, \\text{{принимаем }} \\phi_b=2.5 $$\n";
                φb = 2.5;
            }

            double Rbloc = Rb * φb;
            sluch1=sluch1+$"\n$$ R_{{b,loc}}=\\phi_b \\cdot R_b= {φb.ToString("0.##")} \\cdot {Rb}={Rbloc.ToString("0.##")}\\text{{ МПа}};$$\n";
            


            
            double mins0 = double.Parse(Мин_шаг_стерж.Text);
            double maxs0 = double.Parse(Макс_шаг_стерж.Text);
            double h = double.Parse(Толщина_элемента.Text);
            double Asx = 1;
            double Asy = 1;
            double ds=1;
            double mins = double.Parse(Мин_шаг_сет.Text);
            double maxs = double.Parse(Макс_шаг_сет.Text);
            double аз = double.Parse(Мин_защ_слой.Text);
            double s0 = maxs0;
            double s = maxs;
            double nx =1;
            double ny =1;
            double ly =1;
            double lx =1;
            double Ablocef=1;
            double φsxy = 1;
            double μsxy = 1;
            double Rbsloc = 1;
            double sx = 1;
            double sy = 1;
            double nset = (h/ maxs);
            double Ablocef1 = 1;

            double Nmax = (ψ * Rbsloc * Abloc) / 10;
            bool flag = true;

            if ( Armir.IsChecked==true)
            {    //если границы меньше чем предполагается,то вычитаем от них также защитный слой 
                //if (ав< a1) { ав1 = ав1-аз; }
                //if (ан < a1) { ан1 = ан1-аз; }
                //if (ап < a2) { ап1 = ап1 - аз; }
                //if (ал < a2) { ал1 = ал1 - аз; }
                
                ds = double.Parse(Диаметр.SelectedValue.ToString());
                flag = true;
              for (s0 = maxs0; s0 >=(mins0+1); s0--)
              { 
                // все 4 стороны
                if (ав != 0 & ан != 0 & ал != 0 & ап != 0)
                {
                    nx = ((ап1 + ал1 + a1) / s0) + 1;
                    lx = a1 + ап1 + ал1;
                    ny = ((ав1 + ан1 + a2) / s0) + 1;
                    ly = a2 + ан1 + ав1;
                   
                }

                //у края по всей ширине (1 сторона)
                 else if (ан == 0 & ал == 0 & ап == 0)
                    {
                        Abloc = (a1 - 2 * аз) * (a2 - аз);
                        nx = ((a1 - 2 * аз) / s0) + 1;
                        lx = (a1 - 2 * аз);
                        ny = ((a2 + ав1 - аз) / s0) + 1;
                        ly = a2 + ав1 - аз;


                    }
                 else if (ав == 0 & ал == 0 & ап == 0)
                    {
                        Abloc = (a1 - 2 * аз) * (a2 - аз);
                        nx = ((a1 - 2 * аз) / s0) + 1;
                        lx = (a1 - 2 * аз);
                        ny = ((a2 + ан1 - аз) / s0) + 1;
                        ly = a2 + ан1 - аз;

                    }
                 else if (ав == 0 & ал == 0 & ан == 0)
                    {
                        Abloc = (a2 - 2 * аз) * (a1 - аз);
                        nx = ((a1 + ап1 - аз) / s0) + 1;
                        lx = a1 + ап1 - аз;
                        ny = ((a2 - 2 * аз) / s0) + 1;
                        ly = a2 - 2 * аз;

                    }
                 else if (ав == 0 & ан == 0 & ап == 0)
                    {
                        Abloc = (a2 - 2 * аз) * (a1 - аз);
                        nx = ((a1 + ал1 - аз) / s0) + 1;
                        lx = a1 + ал1 - аз;
                        ny = ((a2 - 2 * аз) / s0) + 1;
                        ly = a2 - 2 * аз;

                    }

               

                //по всей ширине (2 стороны)
                else if (ап==0 & ал==0)
                {
                    Abloc = (a1 - 2*аз) * a2;
                    nx = ((a1 - 2 * аз) / s0) + 1;
                    lx = a1 - 2 * аз;
                    ny = ((a2 + ав1 + ан1) / s0) + 1;
                    ly = a2 + ав1 + ан1;
                   
                }
                else if (ав==0 & ан==0)
                {
                    Abloc = (a2 - 2*аз) * a1;
                    nx = ((a1 + ап1 + ал1) / s0) + 1;
                    lx = a1 + ап1 + ал1;
                    ny = ((a2 - 2 * аз) / s0) + 1;
                    ly = a2 - 2 * аз;
                    
                }
                // в углу (2 стороны)
                else if (ав==0 & ап==0)
                {
                    Abloc = (a1 - аз) * (a2 - аз);
                    nx = ((a1 + ал1 - аз) / s0) + 1;
                    lx = a1 + ал1 - аз;
                    ny = ((a2 + ан1 - аз) / s0) + 1;
                    ly = a2 + ан1 - аз;
                }
                else if (ав==0 & ал==0)
                {
                    Abloc = (a1 - аз) * (a2 - аз);
                    nx = ((a1 + ап1 - аз) / s0) + 1;
                    lx = a1 + ап1 - аз;
                    ny = ((a2 + ан1 - аз) / s0) + 1;
                    ly = a2 + ан1 - аз;
                   
                }
                else if (ал==0 & ан==0)
                {
                    Abloc = (a1 - аз) * (a2-аз);
                    nx = ((a1 + ап1 - аз) / s0) + 1;
                    lx = a1 + ап1 - аз;
                    ny = ((a2 + ав1 - аз) / s0) + 1;
                    ly = a2 + ав1 - аз;
                    
                }
                else if (ан==0 & ап==0)
                {
                    Abloc = (a1 - аз) * (a2 - аз);
                    nx = ((a1 + ал1 - аз) / s0) + 1;
                    lx = a1 + ал1 - аз;
                    ny = ((a2 + ав1 - аз) / s0) + 1;
                    ly = a2 + ав1 - аз;
                    
                }

                //у одного края (3 стороны)
                else if (ал == 0)
                    {

                        nx = ((a1 - аз) / s0) + 1;
                        lx = a1 - аз;
                        ny = ((ав1 + a2 + ан1) / s0) + 1;
                        ly = ав1 + a2 + ан1;
                        //sluch1 = sluch1 + $"\n$$ \\text{{Без учета защитного слоя бетона: }} A_{{b,loc}}=A_{{b,loc}}-(a_{{\\text{{з}}}}\\cdot a_2)={Abloc.ToString("0.##")}-({аз}) \\cdot {a2})={((a1 - аз) * a2).ToString("0.##")}\\text{{ см}}^2;$$\n";
                        Abloc = (a1 - аз) * a2;
                        //$"\n$$ n_x=\\frac{{(a_1-a_{{\\text{{з}}}})}}{{s_0}}+1=\\frac{{({a1}-{аз})}}{{{s0}}}+1={nx.ToString("0.##")}; $$" +
                        // $"$$ l_x=a_1-a_{{\\text{{з}}}}={a1}-{аз}={lx}\\text{{ см}};$$\n" +
                        //$"\n$$ n_y=\\frac{{(a_{{\\text{{в}}}}+a_2+a_{{\\text{{н}}}})}}{{s_0}}+1=\\frac{{({ав}+{a2}+{ан})}}{{{s0}}}+1={ny.ToString("0.##")};$$" +
                        //$"$$ l_y=a_{{\\text{{в}}}}+a_2+a_{{\\text{{н}}}}={ав}+{a2}+{ан}={ly}\\text{{ см}};$$\n";
                    }
                else if (ап == 0)
                    {

                        nx = ((a1 - аз) / s0) + 1;
                        lx = a1 - аз;
                        ny = ((ав1 + a2 + ан1) / s0) + 1;
                        ly = ав1 + a2 + ан1;
                        Abloc = (a1 - аз) * a2;
                    }
                else if (ав == 0)
                    {

                        nx = ((ап1 + ал1 + a1) / s0) + 1;
                        lx = ап1 + ал1 + a1;
                        ny = ((a2 - аз) / s0) + 1;
                        ly = a2 - аз;

                        Abloc = (a2 - аз) * a1;
                    }
                else if (ан == 0)
                    {

                        nx = (((ап1 + ал1 + a1) / s0) + 1);
                        lx = ап1 + ал1 + a1;
                        ny = ((a2 - аз) / s0) + 1;
                        ly = a2 - аз;
                        //sluch1 = sluch1 + $"\n$$ \\text{{Без учета защитного слоя бетона: }} A_{{b,loc}}=A_{{b,loc}}-(a_{{\\text{{з}}}}\\cdot a_1)={Abloc.ToString("0.##")}-({аз}) \\cdot {a1})={((a2 - аз) * a1).ToString("0.##")}\\text{{ см}}^2;$$\n";
                        Abloc = (a2 - аз) * a1;
                    }



                    ////переводим число в стержней в целые числа
                    //nx = (int)nx;
                    //ny = (int)ny;

                Asx = (Math.PI * ds * ds) / 400d;
                Asy = Asx;
                
                
                Ablocef = lx * ly;
                Ablocef1 = Ablocef;
                if (Ablocef > Afac)
                {
                   Ablocef1 = Afac; //текст перенесен вниз после цикла
                }
                else
                {
                    
                }
                 φsxy = Math.Sqrt(Ablocef1 / Abloc);
                 μsxy = (nx * Asx * lx + ny * Asy * ly) / (s * Ablocef);
                 Rbsloc = Rbloc + 2 * φsxy * Rsxy * (μsxy);
                
                Nmax = (ψ * Rbsloc * Abloc)/10;
                    if (Nmax > (2 * ((ψ * Rbloc * Abloc) / 10)))
                    {
                        Nmax = 2 * ((ψ * Rbloc * Abloc) / 10);
                    }

                    if ((Nmax >= N))
                    {
                            nx = Math.Ceiling(nx);
                            ny = Math.Ceiling(ny);
                            
                            break;
                        
                    }
                    
                    flag = false;
              }
                nx = Math.Ceiling(nx);
                ny = Math.Ceiling(ny);
                if (flag == false)
                {
                    for (s = maxs; s > mins; s--)
                    {
                        μsxy = (nx * Asx * lx + ny * Asy * ly) / (s * Ablocef);
                        Rbsloc = Rbloc + 2 * φsxy * Rsxy * (μsxy);
                        Nmax = (ψ * Rbsloc * Abloc) / 10;
                        if (Nmax > (2 * ((ψ * Rbloc * Abloc) / 10)))
                        {
                            Nmax = 2 * ((ψ * Rbloc * Abloc) / 10);
                        }
                        if ((Nmax >= N))
                        {
                            break;
                        }
                        
                    }
                    
                }
                nset = Math.Ceiling(((h-2*аз) / s)+1);
                s = h / (nset-1);

                //по всем 4 сторонам
                if (ав != 0 & ан != 0 & ал != 0 & ап != 0)
                {
                    sx = (ап1 + ал1 + a1) / (nx - 1);
                    sy= (ав1 + ан1 + a2) / (ny - 1);
                }

                //у края по всей ширине (1 сторона)
                else if (ан == 0 & ал == 0 & ап == 0)
                {
                    sx = (a1 - 2 * аз) / (nx - 1);
                    sy = (a2 + ав1 - аз) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n" +
                        $"\n$$ A_{{b,loc}}=(a_1-2 \\cdot a_{{\\text{{з}}}})(a_2-a_{{\\text{{з}}}})=({a1}-2 \\cdot {аз})({a2}-{аз})={Abloc} \\text{{ см}}^2;$$\n";
                }
                else if (ав == 0 & ал == 0 & ап == 0)
                {
                    sx = (a1 - 2 * аз) / (nx - 1);
                    sy = (a2 + ан1 - аз) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n" +
                        $"\n$$ A_{{b,loc}}=(a_1-2 \\cdot a_{{\\text{{з}}}})(a_2-a_{{\\text{{з}}}})=({a1}-2 \\cdot {аз})({a2}-{аз})={Abloc} \\text{{ см}}^2;$$\n";
                }
                else if (ав == 0 & ал == 0 & ан == 0)
                {
                    sx = (a1 + ап1 - аз) / (nx - 1);
                    sy = (a2 - 2 * аз) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n" +
                        $"\n$$ A_{{b,loc}}=(a_2-2 \\cdot a_{{\\text{{з}}}})(a_1-a_{{\\text{{з}}}})=({a2}-2 \\cdot {аз})({a1}-{аз})={Abloc} \\text{{ см}}^2;$$\n";
                }
                else if (ав == 0 & ан == 0 & ап == 0)
                {
                    sx = (a1 + ал1 - аз) / (nx - 1);
                    sy = (a2 - 2 * аз) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n" +
                        $"\n$$ A_{{b,loc}}=(a_2-2 \\cdot a_{{\\text{{з}}}})(a_1-a_{{\\text{{з}}}})=({a2}-2 \\cdot {аз})({a1}-{аз})={Abloc} \\text{{ см}}^2;$$\n";
                }

                //по всей ширине (2 стороны)
                else if (ап==0 & ал==0)
                {
                    sx = (a1 - 2 * аз) / (nx - 1);
                    sy= (a2 + ав1 + ан1) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n"+
                         $"\n$$ A_{{b,loc}}=(a_1-2 \\cdot a_{{\\text{{з}}}})\\cdot a_2=({a1}-2\\cdot {аз})\\cdot {a2}={Abloc}\\text{{ см}}^2 ;$$\n";
                }
                else if (ав==0 & ан==0)
                {
                    sx = (a1 + ап1 + ал1) / (nx - 1);
                    sy= (a2 - 2 * аз) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n"+
                         $"\n$$ A_{{b,loc}}=(a_2-2 \\cdot a_{{\\text{{з}}}})\\cdot a_1=({a2}-2\\cdot {аз})\\cdot {a1}={Abloc} \\text{{ см}}^2;$$\n";
                }
                // в углу (2 стороны)
                else if (ав==0 & ап==0)
                {
                    sx = (a1 + ал1 - аз) / (nx - 1);
                    sy= (a2 + ан1 - аз) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n"+
                         $"\n$$ A_{{b,loc}}=(a_1-a_{{\\text{{з}}}})(a_2-a_{{\\text{{з}}}})=({a1}-{аз})({a2}-{аз})={Abloc} \\text{{ см}}^2;$$\n";
                }
                else if (ав==0 & ал==0)
                {
                    sx = (a1 + ап1 - аз) / (nx - 1);
                    sy= (a2 + ан1 - аз) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n"+
                        $"\n$$ A_{{b,loc}}=(a_1-a_{{\\text{{з}}}})(a_2-a_{{\\text{{з}}}})=({a1}-{аз})({a2}-{аз})={Abloc} \\text{{ см}}^2;$$\n";
                }
                else if (ал==0 & ан==0)
                {
                    sx = (a1 + ап1 - аз) / (nx - 1);
                    sy= (a2 + ав1 - аз) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n"+
                        $"\n$$ A_{{b,loc}}=(a_1-a_{{\\text{{з}}}})(a_2-a_{{\\text{{з}}}})=({a1}-{аз})({a2}-{аз})={Abloc} \\text{{ см}}^2;$$\n";
                }
                else if (ан == 0 & ап == 0)
                {
                    sx = (a1 + ал1 - аз) / (nx - 1);
                    sy= (a2 + ав1 - аз) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n"+
                        $"\n$$ A_{{b,loc}}=(a_1-a_{{\\text{{з}}}})(a_2-a_{{\\text{{з}}}})=({a1}-{аз})({a2}-{аз})={Abloc} \\text{{ см}}^2;$$\n";
                }
                
                //у одного края (3 стороны)
                else if (ал == 0)
                {
                    sx = (a1 - аз) / (nx - 1);
                    sy = (ав1 + a2 + ан1) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n" +
                         $"\n$$ A_{{b,loc}}=(a_1- a_{{\\text{{з}}}})\\cdot a_2=({a1}-{аз})\\cdot {a2}={Abloc} \\text{{ см}}^2;$$\n";
                }
                else if (ап == 0)
                {
                    sx = (a1 - аз) / (nx - 1);
                    sy = (ав1 + a2 + ан1) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n" +
                        $"\n$$ A_{{b,loc}}=(a_1- a_{{\\text{{з}}}})\\cdot a_2=({a1}-{аз})\\cdot {a2}={Abloc} \\text{{ см}}^2;$$\n";
                }
                else if (ав == 0)
                {
                    sx = (ап1 + ал1 + a1) / (nx - 1);
                    sy = (a2 - аз) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n" +
                        $"\n$$ A_{{b,loc}}=(a_2- a_{{\\text{{з}}}})\\cdot a_1=({a2}-{аз})\\cdot {a1}={Abloc} \\text{{ см}}^2;$$\n";
                }
                else if (ан == 0)
                {
                    sx = (ап1 + ал1 + a1) / (nx - 1);
                    sy = (a2 - аз) / (ny - 1);
                    sluch1 = sluch1 + $"\n$ \\text{{Без учета площади, занятой защитным слоем бетона:}}$\n" +
                         $"\n$$ A_{{b,loc}}=(a_2- a_{{\\text{{з}}}})\\cdot a_1=({a2}-{аз})\\cdot {a1}={Abloc} \\text{{ см}}^2;$$\n";
                }

                if (lx * ly > Afac)
                {
                    sluch1 = sluch1 + $"\n$$ A_{{b,loc,ef}}=l_x \\cdot l_y={lx} \\cdot {ly} ={(lx * ly).ToString("0.##")}\\text{{ см}}^2 \\nleq A_{{b,fac}}={Afac.ToString("0.##")}\\text{{ см}}^2;$$\n";

                }
                else
                {
                    sluch1 = sluch1 + $"\n$$ A_{{b,loc,ef}}=l_x \\cdot l_y={lx} \\cdot {ly} ={Ablocef.ToString("0.##")}\\text{{ см}}^2 \\leq A_{{b,fac}}={Afac.ToString("0.##")} \\text{{ см}}^2;$$\n ";
                }

                sluch1 = sluch1 +$"\n$$ \\phi_{{sxy}}= \\sqrt{{\\frac{{A_{{b,loc,ef}}}}{{A_{{b,loc}} }} }}=\\sqrt{{\\frac{{{Ablocef1.ToString("0.##")}}}{{{Abloc.ToString("0.##")}}}}}={φsxy.ToString("0.##")};$$\n " +
                  $"\n$$ \\mu_{{s,xy}}=\\frac{{ n_x \\cdot A_{{sx}} \\cdot l_x +n_y \\cdot A_{{sy}} \\cdot l_y}}{{s \\cdot A_{{b,loc,ef}}}}=\\frac{{ {nx} \\cdot {Asx.ToString("0.##")} \\cdot {lx} +{ny} \\cdot {Asy.ToString("0.##")} \\cdot {ly}}}{{{s.ToString("0.#")} \\cdot {Ablocef.ToString("0.##")}}}={μsxy.ToString("0.###")};$$\n " +
                  $"\n$$ R_{{bs,loc}}=R_{{b,loc}}+2\\phi_{{sxy}} \\cdot R_{{sxy}} \\cdot \\mu_{{s,xy}}={Rbloc.ToString("0.##")}+2\\cdot {φsxy.ToString("0.##")} \\cdot {Rsxy.ToString("0.##")} \\cdot {μsxy.ToString("0.###")}={Rbsloc.ToString("0.##")} \\text{{ МПа}};$$\n ";


                double prots = Math.Abs(Nmax / (N));
                if ((Nmax < N))
                {
                    if (((ψ * Rbsloc * Abloc) / 10) > (2 * ((ψ * Rbloc * Abloc) / 10)))
                    {
                        sluch1 = sluch1 + $"\n$$  \\psi\\cdot R_{{bs,loc}} \\cdot A_{{b,loc}}={ψ.ToString("0.##")} \\cdot {Rbsloc.ToString("0.##")} \\cdot 10^{{-1}} \\cdot {Abloc.ToString("0.##")}={((ψ * Rbsloc * Abloc) / 10).ToString("0.##")} \\text{{ кН}} \\nleq  2 \\cdot\\psi\\cdot R_{{b,loc}} \\cdot A_{{b,loc}}={ψ.ToString("0.##")} \\cdot {Rbloc.ToString("0.##")} \\cdot 10^{{-1}} \\cdot {Abloc.ToString("0.##")}={Nmax.ToString("0.##")} \\text{{ кН}} $$\n" +
                           $"\n$$ N= {N}\\text{{ кН}} \\nleq 2 \\cdot\\psi\\cdot R_{{b,loc}} \\cdot A_{{b,loc}}={Nmax.ToString("0.##")} \\text{{ кН}} $$\n" +
                         "\n\\text{ Прочность не обеспечена.}\n"; ;
                    }
                    else
                    {
                    sluch1 = sluch1 + $"\n$$ N= {N}\\text{{ кН}} \\nleq \\psi\\cdot R_{{bs,loc}} \\cdot A_{{b,loc}}={ψ.ToString("0.##")} \\cdot {Rbsloc.ToString("0.##")} \\cdot 10^{{-1}} \\cdot {Abloc.ToString("0.##")}={Nmax.ToString("0.##")} \\text{{ кН}} $$\n" +
                         "\n\\text{ Прочность не обеспечена.}\n";
                    }
                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                    Результаты.AppendText(" " + Environment.NewLine);
                    Результаты.AppendText("Коэффициент запаса прочности γ= " + prots.ToString("0.##") + Environment.NewLine);
                    rezult =
                           ($"\n\\textbf{{Результаты расчета}}\n" +
                           "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                       "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");
                }
                else if (Nmax>=N)
                {
                    if (((ψ * Rbsloc * Abloc) / 10) > (2 * ((ψ * Rbloc * Abloc) / 10)))
                    {
                        sluch1 = sluch1 + $"\n$$  \\psi\\cdot R_{{bs,loc}} \\cdot A_{{b,loc}}={ψ.ToString("0.##")} \\cdot {Rbsloc.ToString("0.##")} \\cdot 10^{{-1}} \\cdot {Abloc.ToString("0.##")}={((ψ * Rbsloc * Abloc) / 10).ToString("0.##")} \\text{{ кН}} \\nleq  2 \\cdot\\psi\\cdot R_{{b,loc}} \\cdot A_{{b,loc}}={ψ.ToString("0.##")} \\cdot {Rbloc.ToString("0.##")} \\cdot 10^{{-1}} \\cdot {Abloc.ToString("0.##")}={Nmax.ToString("0.##")} \\text{{ кН}} $$\n" +
                           $"\n$$ N= {N}\\text{{ кН}} \\nleq 2 \\cdot\\psi\\cdot R_{{b,loc}} \\cdot A_{{b,loc}}={Nmax.ToString("0.##")} \\text{{ кН}} $$\n" +
                         "\n\\text{ Прочность обеспечена. }\n" +
                           $"$ \\text{{Сетки устанавливаем на глубину: }} {nset} \\cdot {s.ToString("0.#")}={(nset - 1) * s} \\text{{ см.}} $\n ";
                    }
                    else { 
                    sluch1 = sluch1 + $"\n$$ N= {N}\\text{{ кН}} \\leq \\psi\\cdot R_{{bs,loc}} \\cdot A_{{b,loc}}={ψ.ToString("0.##")} \\cdot {Rbsloc.ToString("0.##")} \\cdot 10^{{-1}} \\cdot {Abloc.ToString("0.##")}={Nmax.ToString("0.##")} \\text{{ кН}} $$\n" +
                        "\n\\text{ Прочность обеспечена. }"+
                        $"$ \\text{{Сетки устанавливаем на глубину: }} {nset} \\cdot {s.ToString("0.#")}={(nset-1) * s} \\text{{ см.}} $\n ";
                    }
                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                    Результаты.AppendText(" " + Environment.NewLine);
                    Результаты.AppendText("Коэффициент запаса прочности γ= " + prots.ToString("0.##") + Environment.NewLine);
                    rezult =
                           ($"\n\\textbf{{Результаты расчета}}\n" +
                           "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                       "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");
                }
               

            }
            else if(Armir.IsChecked == false )
            {
                 Nmax = (ψ * Rbloc * Abloc)/10;
                double prots = Math.Abs(Nmax  / (N));
                if (Nmax>=N)
                {
                    
                    sluch1 = sluch1 + $"\n$$ N= {N}\\text{{ кН}} \\leq \\psi\\cdot R_{{b,loc}} \\cdot A_{{b,loc}}={ψ.ToString("0.##")} \\cdot {Rbloc.ToString("0.##")} \\cdot 10^{{-1}} \\cdot {Abloc.ToString("0.##")}={Nmax.ToString("0.##")} \\text{{ кН}} $$\n" +
                        "\n\\text{ Прочность обеспечена.}\n";
                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                    Результаты.AppendText(" " + Environment.NewLine);
                    Результаты.AppendText("Коэффициент запаса прочности γ= " + prots.ToString("0.##") + Environment.NewLine);
                    //Результаты.AppendText("Abloc " + Abloc.ToString("0.#") + "Мпа" + Environment.NewLine);
                    rezult =
                           ($"\n\\textbf{{Результаты расчета}}\n" +
                           "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                       "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");
                }
                else
                {
                    sluch1 = sluch1 + $"\n$$ N= {N}\\text{{ кН}} \\nleq \\psi\\cdot R_{{b,loc}} \\cdot A_{{b,loc}}={ψ.ToString("0.##")} \\cdot {Rbloc.ToString("0.##")} \\cdot 10^{{-1}} \\cdot {Abloc.ToString("0.##")}={Nmax.ToString("0.##")} \\text{{ кН}} $$\n" +
                       "\n\\text{ Прочность не обеспечена.}\n";
                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                    Результаты.AppendText(" " + Environment.NewLine);
                    Результаты.AppendText("Коэффициент запаса прочности γ= " + prots.ToString("0.##") + Environment.NewLine);
                    rezult =
                           ($"\n\\textbf{{Результаты расчета}}\n" +
                           "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                       "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");
                }
            }
           


            lya = "D:\\ANNA"; //Вводим начальный текст одинаковый для всех ifelse
            name = "Otchet";
            string PROEKT = (shifr == "") ? ("") : (@"Проект: " + shifr);
            string DATA = (data == "") ? ("") : (@" Дата: " + data);
            string ETACH = (etach == "") ? ("") : (@" Этаж: " + etach);
            string CONSTR = (constr == "") ? ("") : (@" Конструкция: " + constr);
            string OSI = (osi == "") ? ("") : (@" Оси: " + osi);
            string COMMENT = (comment == "") ? ("") : ("\n Комментарий: " + comment + "\n$\\ $\n");

            An = "\n\\text{ }\n" +
            "\n\\textbf{Расчет железобетонных элементов на местное сжатие (СП 63.13330.2012).}\n" + "\n$\\ $\n" +
            "\n\\textbf{Исходные данные}\n" +
            "\n Размеры: " + $"$ \\text{{ }} h={h} \\text{{ см}}; $\n" +
            $"$ \\text{{ }}a_{{1}}={a1} \\text{{ см}}; \\text{{ }} a_{{2}}={a2} \\text{{ см}}$\n";
            if ((Расстояние_верх.Text != "") & ав!=0)
            { An = An + $"$ \\text{{ }}a_{{\\text{{в}}}}={ав} \\text{{ см}};$\n"; }
            if ((Расстояние_влево.Text != "") & ал != 0)
            { An = An + $"$ \\text{{ }}a_{{\\text{{л}}}}={ал} \\text{{ см}};$\n"; }
            if ((Расстояние_вправо.Text != "") & ап != 0)
            { An = An + $"$ \\text{{ }}a_{{\\text{{п}}}}={ап} \\text{{ см}};$\n"; }
            if ((Расстояние_низ.Text != "") & ан != 0)
            { An = An + $"$ \\text{{ }}a_{{\\text{{н}}}}={ан} \\text{{ см}};$\n"; }
            An = An+"\n Бетон: " + (ConcClass.SelectedValue) +
                $"$; R_b={(Rb / (γb1 * γb3 * γb4 * γb5 )).ToString("0.#")} \\text{{ МПа}}; $\n" +
                $"$ R_b\\cdot\\gamma_b={(Rb).ToString("0.#")}\\text{{ МПа}}; $\n" +
               $"$ \\gamma_{{b1}}={γb1.ToString("0.##")}; $\n" +
               $"$ \\gamma_{{b2}}={γb2.ToString("0.##")}; $\n" +
                $"$ \\gamma_{{b3}}={γb3.ToString("0.##")}; $\n" +
                $"$ \\gamma_{{b4}}={γb4.ToString("0.##")}; $\n" +
                $"$ \\gamma_{{b5}}={γb5.ToString("0.##")}; $\n" +
                
            "\n Усилия: " + $"$ N={N}\\text{{ кН}} $\n"+ $"$; \\psi={ ψ}; $\n";
            if (Armir.IsChecked == true)
            {
                An = An + "\n Арматура: " + (SteelClass1.SelectedValue);
                An = An + $"$ ; A_{{sx}}={Asx.ToString("0.##")} \\text{{ см}}^2 $" +
                $"$;  A_{{sy}}={Asy.ToString("0.##")} \\text{{ см}}^2 $" +
                    $"$; d_{{s}}={ds / 10} \\text{{ см}}$" +
                    $"$; \\text{{ }}a_{{\\text{{з}}}}={аз} \\text{{ см}} $\n" +
                     $"$; n_x={nx}; n_y={ny} $" +
                     $"$; l_x={lx}; l_y={ly} $" +
                     $"$; s={s.ToString("0.#")} \\text{{ см}} $" +
                      $"$; s_{{0x}}={sx.ToString("0.#")} \\text{{ см}} $"+
                      $"$; s_{{0y}}={sy.ToString("0.#")} \\text{{ см}}; $" + "\n$\\ $\n";


            }
            else if (Armir.IsChecked == false)
            {
            }
            


            if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
            {
                
            }
            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
            {
                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT+An+risunok + rezult + "\n\\textbf{ }\n" + sluch1 , System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
            }
            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
            {
                 PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT+An + risunok + rezult, System.Diagnostics.ProcessWindowStyle.Maximized, true);
            }
        }
    }
}
