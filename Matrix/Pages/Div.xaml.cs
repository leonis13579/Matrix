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
    public partial class Div : Page
    {
        List<Grid> containers;
        List<TextBox> input1_containers;
        List<TextBox> input2_containers;
        List<TextBox> inputOut_containers;

        public Div()
        {
            InitializeComponent();

            SizeX.ItemsSource = Matrix_Logic.LenghtLong;
            SizeY.ItemsSource = Matrix_Logic.LenghtLong;

            containers = new List<Grid>() { Sum1, Sum2, SumOut };

            input1_containers = new List<TextBox>();
            input2_containers = new List<TextBox>();
            inputOut_containers = new List<TextBox>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((NavigationWindow)Application.Current.MainWindow).GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<int> nums1 = new List<int>();
            List<int> nums2 = new List<int>();
            bool error = false;

            foreach (TextBox tb in input1_containers)
            {
                if (Matrix_Logic.IsDigit(tb.Text)) {
                    ((Border)tb.Parent).Background = Brushes.White;
                    nums1.Add(int.Parse(tb.Text));
                }else
                {
                    ((Border)tb.Parent).Background = Brushes.Red;
                    error = true;
                }
            }
            foreach (TextBox tb in input2_containers)
            {
                if (Matrix_Logic.IsDigit(tb.Text))
                {
                    ((Border)tb.Parent).Background = Brushes.White;
                    nums2.Add(int.Parse(tb.Text));
                }
                else
                {
                    ((Border)tb.Parent).Background = Brushes.Red;
                    error = true;
                }
            }

            if (!error) {
                List<int> summ = Matrix_Logic.Div(nums1, nums2);
                for (int i = 0; i < summ.Count; i++)
                {
                    inputOut_containers[i].Text = summ[i].ToString();
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach(Grid container in containers)
            {
                container.Children.Clear();
                
                container.ColumnDefinitions.Clear();
                container.ColumnDefinitions.Add(new ColumnDefinition());
                container.ColumnDefinitions.Add(new ColumnDefinition());

                container.RowDefinitions.Clear();
            }

            if (SizeX.SelectedItem != null && SizeY.SelectedItem != null)
            {
                for (int n = 0; n < (int)SizeX.SelectedItem; n++)
                {
                    Sum1.RowDefinitions.Add(new RowDefinition());
                    Sum2.RowDefinitions.Add(new RowDefinition());
                    SumOut.RowDefinitions.Add(new RowDefinition());
                }
                for (int m = 0; m < (int)SizeY.SelectedItem; m++)
                {
                    Sum1.ColumnDefinitions.Add(new ColumnDefinition());
                    Sum2.ColumnDefinitions.Add(new ColumnDefinition());
                    SumOut.ColumnDefinitions.Add(new ColumnDefinition());
                }

                for (int n = 0; n < (int)SizeX.SelectedItem; n++)
                {
                    for (int m = 0; m < (int)SizeY.SelectedItem; m++)
                    {
                        foreach (Grid container in containers)
                        {
                            Border b = new Border()
                            {
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                Margin = new Thickness(5),
                                MinWidth = 50,
                                IsEnabled = container.Name == "SumOut" ? false : true,
                                Background = Brushes.White
                            };
                            Grid.SetRow(b, n);
                            Grid.SetColumn(b, m + 1);

                            TextBox tb = new TextBox()
                            {
                                FontSize = 50,
                                HorizontalAlignment = HorizontalAlignment.Stretch,
                                TextAlignment = TextAlignment.Center,
                                Background = Brushes.Transparent
                            };
                            b.Child = tb;

                            switch (container.Name)
                            {
                                case "Sum1":
                                    input1_containers.Add(tb);
                                    break;
                                case "Sum2":
                                    input2_containers.Add(tb);
                                    break;
                                case "SumOut":
                                    inputOut_containers.Add(tb);
                                    break;
                            }

                            container.Children.Add(b);
                        }
                    }
                }
                foreach (Grid container in containers)
                {
                    TextBlock tb1 = new TextBlock()
                    {
                        Text = "(",
                        FontSize = 50,
                        VerticalAlignment = VerticalAlignment.Center
                    };
                    Grid.SetRow(tb1, 0);
                    Grid.SetColumn(tb1, 0);
                    Grid.SetRowSpan(tb1, (int)SizeX.SelectedItem);
                    container.Children.Add(tb1);

                    TextBlock tb2 = new TextBlock()
                    {
                        Text = ")",
                        FontSize = 50,
                        VerticalAlignment = VerticalAlignment.Center

                    };
                    Grid.SetRow(tb2, 0);
                    Grid.SetColumn(tb2, (int)SizeY.SelectedItem + 1);
                    Grid.SetRowSpan(tb2, (int)SizeX.SelectedItem);
                    container.Children.Add(tb2);
                }
                
            }
        }
    }
}
