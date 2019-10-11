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

namespace Bsp_Ressourcen
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //ressourcen per programm erstellen
            Style style = new Style(typeof(Label));
            style.Setters.Add(new Setter(Label.BackgroundProperty, Brushes.LightPink));
            style.Setters.Add(new Setter(Label.ForegroundProperty, Brushes.DarkMagenta));
            Resources.Add("XY", style);

            SolidColorBrush sb = new SolidColorBrush(Color.FromArgb(255, 200, 15, 200));
            Resources.Add("SCB", sb);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //combobox mit styles aus der ressource befüllen
            foreach (var item in Resources.Keys)
            {
                //nur objekte vom typ style sollen angezeigt werden
                if (Resources[item] is Style)
                {
                    cb1.Items.Add(item);
                }
            }

            //combobox mit brushes aus der ressource befüllen
            var qry = from string t in Resources.Keys
                      where Resources[t] is Brush
                      select t;
            cbo_fill.ItemsSource = qry;
            cbo_stroke.ItemsSource = qry;


        }

        private void Cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ausgewählten Style auf das label anwenden

            string item = (string)cb1.SelectedItem;
            Style s1 = Resources[item] as Style;
            lb1.Style = s1;
        }

        private void Cbo_fill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string t = (sender as ComboBox).SelectedItem as string;
            var b = FindResource(t) as SolidColorBrush;
            elli.Fill = b;

        }

        private void Cbo_stroke_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string t = (sender as ComboBox).SelectedItem as string;
            var b = FindResource(t) as SolidColorBrush;
            elli.Stroke = b;
        }
    }
}
