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

    }

}