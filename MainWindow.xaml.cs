using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ind
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        void main()
        {
            textBox.Text = "";
            nomber.Text = "";
            XXX.Text = "";
            double x = Convert.ToDouble(X0.Text);
            double h = Convert.ToDouble(H.Text);
            double y = Convert.ToDouble(Y0.Text);
            int temp = 0;
            for (double i = x; i <= y; i += h)
            {
                temp += 1;
            }
            textBox1.Text = "   x           Yt              Ych";
            double[] Yn = new double[temp + 1];
            Yn[0] = y;
            int j = 1;
            for (double i = x; i <= Yn[0] || j < temp; i += h, j++)
            {
                Yn[j] = nahN(Yn[j - 1], i);
                Yn[j] = Math.Round(Yn[j], 6);
                textBox.Text += Yn[j].ToString() + "\n";
                nomber.Text += j + "\n";
                XXX.Text += i + "\n";
            }
        }

        double nahN(double y, double x)
        {
            double N;
            N = y + triY(Convert.ToDouble(H.Text), monster(x, y));
            return (N);
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            main();
        }

        double triY(double h, double f)
        {
            double triY = h * f;
            return (triY);
        }

        double vnesh2(double x, double y)
        {

            double vnesh2;
            vnesh2 = Convert.ToDouble(Y0.Text) + Convert.ToDouble(H.Text) / 2 * obr(x, y);
            return (vnesh2);

        }

        double monster(double x, double y)
        {
            return (Funk_f(vnesh1(x), vnesh2(x, y)));



        }

        double obr(double x, double y)
        {
            string s = twoCha.Text;
            s = s.Replace("x", x.ToString());
            s = s.Replace("y", y.ToString());
            s = SKib(s);
            s = skob(s);
            s = Step(s);
            s = delen(s);
            s = umn(s);
            s = minus(s);
            s = sum(s);
            if ((s[0] == '-') && (s[1] == '-')) s = s.Replace("--", "-");

            return (Convert.ToDouble(s));
        }

        double vnesh1(double X)
        {
            double Temp;
            Temp = X + Convert.ToDouble(H.Text) / 2;
            return (Temp);
        }

        double Funk_f(double x, double y)
        {

            return (Convert.ToDouble(obr(x, y)));

        }

         
        string Step(string temp)
        {
            int POP = 0;
            string temp1, temp2, temp3;
            while (POP != 1)
            {
                Regex regex1 = new Regex(@"\-*\w+\^\-*\w+[\.|\,]*\w*");
                MatchCollection matches = regex1.Matches(temp);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        textBox1.Text = match.Value;
                    temp1 = textBox1.Text;
                    int N = 0, m = temp1.Length;
                    for (int i = 0; i < m; i++)
                    {
                        if (temp1[i] == '^')
                            if (temp1[i + 1] != '-')
                            {
                                temp2 = temp1.Substring(0, i);
                                temp3 = temp1.Substring(i + 1);
                                double a, b;
                                a = Convert.ToDouble(temp2);
                                b = Convert.ToDouble(temp3);
                                textBox1.Text = Math.Round((Math.Pow(a, b)), 6, MidpointRounding.AwayFromZero).ToString();
                                break;
                            }
                        /* else
                            {
                                temp2 = temp1.Substring(0, i);
                                temp3 = temp1.Substring(i + 1);
                                double a, b;
                                a = Convert.ToDouble(temp2);
                                b = Convert.ToDouble(temp3);
                                textBox1.Text = Math.Round((Math.Sqrt(a)), 6, MidpointRounding.AwayFromZero).ToString();
                                break;
                            }*/
                    }
                    temp = temp.Replace(temp1, textBox1.Text);


                }
                else
                {
                    POP = 1;
                }
            }
            return (temp);
        }
        string SKib(string temp)
        {
            int POP = 0;
            string temp1, temp2, temp3;
            while (POP != 1)
            {
                Regex regex1 = new Regex(@"\(\-\w+\)");
                MatchCollection matches = regex1.Matches(temp);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        textBox1.Text = match.Value;
                    temp1 = textBox1.Text;
                    temp2 = temp1;
                    temp2 = temp2.Replace("(", "");
                    temp2 = temp2.Replace(")", "");
                    temp = temp.Replace(temp1, temp2);


                }
                else
                {
                    POP = 1;
                }
            }
            return (temp);
        }
        string skob(string temp)
        {
            int POP = 0;
            string temp1, temp2;
            while (POP != 1)
            {
                Regex regex1 = new Regex(@"\(.+\)");
                MatchCollection matches = regex1.Matches(temp);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        textBox1.Text = match.Value;

                    temp1 = textBox1.Text;
                    temp2 = temp1;

                    temp2 = SKib(temp2);
                    temp2 = delen(temp1);
                    temp2 = umn(temp1);
                    temp2 = minus(temp1);
                    temp2 = sum(temp1);
                    temp2 = temp2.Replace("(", "");
                    temp2 = temp2.Replace(")", "");
                    temp = temp.Replace(temp1, temp2);


                }



                else
                {
                    POP = 1;
                }
            }
            return (temp);
        }
        string sum(string temp)
        {
            int POP = 0;
            string temp1, temp2, temp3;
            while (POP != 1)
            {
                Regex regex1 = new Regex(@"\-*\w+[\.|\,]*\w*\+\-*\w+[\.|\,]*\w*");
                MatchCollection matches = regex1.Matches(temp);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        textBox1.Text = match.Value;
                    temp1 = textBox1.Text;
                    int N = 0, m = temp1.Length;
                    for (int i = 0; i < m; i++)
                    {

                        if (temp1[i] == '+')
                        {
                            temp2 = temp1.Substring(0, i);
                            temp3 = temp1.Substring(i + 1);
                            textBox1.Text = (Math.Round((Convert.ToDouble(temp2) + (Convert.ToDouble(temp3))), 6, MidpointRounding.AwayFromZero)).ToString();
                            break;
                        }
                    }
                    temp = temp.Replace(temp1, textBox1.Text);

                }



                else
                {
                    POP = 1;
                }
            }
            return (temp);
        }
        string delen(string temp)
        {
            int POP = 0;
            string temp1, temp2, temp3;
            while (POP != 1)
            {
                Regex regex1 = new Regex(@"\-*\w+[\.|\,]*\w*\/\-*\w+[\.|\,]*\w*");
                MatchCollection matches = regex1.Matches(temp);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        textBox1.Text = match.Value;
                    temp1 = textBox1.Text;
                    int N = 0, m = temp1.Length;
                    for (int i = 0; i < m; i++)
                    {
                        if (temp1[i] == '/')
                        {
                            temp2 = temp1.Substring(0, i);
                            temp3 = temp1.Substring(i + 1);
                            textBox1.Text = (Math.Round((Convert.ToDouble(temp2) / (Convert.ToDouble(temp3))), 6, MidpointRounding.AwayFromZero)).ToString();
                            break;
                        }
                    }
                    temp = temp.Replace(temp1, textBox1.Text);


                }
                else
                {
                    POP = 1;
                }
            }
            return (temp);
        }
        string minus(string temp)
        {
            int POP = 0;
            string temp1, temp2, temp3;
            while (POP != 1)
            {
                Regex regex1 = new Regex(@"\w+[\.|\,]*\w*\-\-*\w+[\.|\,]*\w*");
                MatchCollection matches = regex1.Matches(temp);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        textBox1.Text = match.Value;
                    temp1 = textBox1.Text;
                    int N = 0, m = temp1.Length;
                    for (int i = 0; i < m; i++)
                    {
                        if (temp1[i] == '-')
                        {
                            temp2 = temp1.Substring(0, i);
                            temp3 = temp1.Substring(i + 1);
                            textBox1.Text = (Math.Round((Convert.ToDouble(temp2) - (Convert.ToDouble(temp3))), 6, MidpointRounding.AwayFromZero)).ToString();
                            break;
                        }
                    }
                    temp = temp.Replace(temp1, textBox1.Text);


                }
                else
                {
                    POP = 1;
                }
            }
            return (temp);
        }
        string umn(string temp)
        {

            int POP = 0;
            string temp1, temp2, temp3;
            while (POP != 1)
            {
                Regex regex1 = new Regex(@"\w+[\.|\,]*\w*\*\-*\w+[\.|\,]*\w*");
                MatchCollection matches = regex1.Matches(temp);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        textBox1.Text = match.Value;
                    temp1 = textBox1.Text;
                    int N = 0, m = temp1.Length;
                    for (int i = 0; i < m; i++)
                    {
                        if (temp1[i] == '*')
                        {
                            temp2 = temp1.Substring(0, i);
                            temp3 = temp1.Substring(i + 1);
                            textBox1.Text = (Math.Round((Convert.ToDouble(temp2) * (Convert.ToDouble(temp3))), 6, MidpointRounding.AwayFromZero)).ToString();
                            break;
                        }
                    }

                    temp = temp.Replace(temp1, textBox1.Text);
                    if ((temp[0] == '-') && (temp[1] == '-')) temp = temp.Replace("--", "");
                    else temp = temp.Replace("--", "+");

                }
                else
                {

                    POP = 1;
                }
            }
            return (temp);
        }

    }

}