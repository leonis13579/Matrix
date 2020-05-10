using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Matrix.Pages
{
    /// <summary>
    /// Логика взаимодействия для Sum.xaml
    /// </summary>
    public partial class Opr : Page
    {
        List<TextBox> input1_containers;

        public Opr()
        {
            InitializeComponent();

            SizeX.ItemsSource = Matrix_Logic.LenghtShort;
            SizeY.ItemsSource = Matrix_Logic.LenghtShort;

            input1_containers = new List<TextBox>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((NavigationWindow)Application.Current.MainWindow).GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<int> nums1 = new List<int>();
            bool error = false;
            
            foreach (TextBox tb in input1_containers)
            {
                if (Matrix_Logic.IsDigit(tb.Text))
                {
                    ((Border)tb.Parent).Background = Brushes.White;
                    nums1.Add(int.Parse(tb.Text));
                }
                else
                {
                    ((Border)tb.Parent).Background = Brushes.Red;
                    error = true;
                }
            }

            if (!error) {
                Out.Text = Matrix_Logic.opred(nums1, (int)SizeX.SelectedItem).ToString();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {   
            input1_containers.Clear();
            Matrix.Children.Clear();

            Matrix.ColumnDefinitions.Clear();
            Matrix.ColumnDefinitions.Add(new ColumnDefinition());
            Matrix.ColumnDefinitions.Add(new ColumnDefinition());

            Matrix.RowDefinitions.Clear();

            if (SizeX.SelectedItem != null && SizeY.SelectedItem != null)
            {
                for (int n = 0; n < (int)SizeX.SelectedItem; n++)
                {
                    Matrix.RowDefinitions.Add(new RowDefinition());
                }
                for (int m = 0; m < (int)SizeY.SelectedItem; m++)
                {
                    Matrix.ColumnDefinitions.Add(new ColumnDefinition());
                }

                for (int n = 0; n < (int)SizeX.SelectedItem; n++)
                {
                    for (int m = 0; m < (int)SizeY.SelectedItem; m++)
                    {
                        Border b = new Border()
                        {
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Margin = new Thickness(5),
                            MinWidth = 50,
                            Background = Brushes.White
                        };
                        

                        TextBox tb = new TextBox()
                        {
                            FontSize = 50,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            TextAlignment = TextAlignment.Center,
                            Background = Brushes.Transparent,
                        };
                        b.Child = tb;

                        Grid.SetRow(b, n);
                        Grid.SetColumn(b, m + 1);
                        input1_containers.Add(tb);

                        Matrix.Children.Add(b);
                    }
                }

                TextBlock tb1 = new TextBlock()
                {
                    Text = "|",
                    FontSize = 50,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Grid.SetRow(tb1, 0);
                Grid.SetColumn(tb1, 0);

                TextBlock tb2 = new TextBlock()
                {
                    Text = "|",
                    FontSize = 50,
                    VerticalAlignment = VerticalAlignment.Center

                };
                Grid.SetRow(tb2, 0);
                Grid.SetColumn(tb2, (int)SizeY.SelectedItem + 1);

                Grid.SetRowSpan(tb1, (int)SizeX.SelectedItem);
                Grid.SetRowSpan(tb2, (int)SizeX.SelectedItem);

                Matrix.Children.Add(tb1);
                Matrix.Children.Add(tb2);                
            }
        }

        private void SizeX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SizeY.SelectedIndex = SizeX.SelectedIndex;
        }
    }
}
