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
    public partial class Back : Page
    {
        List<TextBox> input1_containers;
        List<TextBox> inputOut_containers;

        public Back()
        {
            InitializeComponent();

            SizeX.ItemsSource = Matrix_Logic.LenghtShort;
            SizeY.ItemsSource = Matrix_Logic.LenghtShort;

            input1_containers = new List<TextBox>();
            inputOut_containers = new List<TextBox>();
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
                int opr_num = Matrix_Logic.opred(nums1, (int)SizeX.SelectedItem);
                opr.Text = opr_num.ToString();
                if (opr_num == 0) {
                    Out.Visibility = Visibility.Collapsed;
                    ErrorOper.Visibility = Visibility.Visible;
                } else
                {
                    ErrorOper.Visibility = Visibility.Collapsed;
                    Out.Visibility = Visibility.Visible;

                    List<double> summ = Matrix_Logic.Back(nums1, (int)SizeX.SelectedItem, opr_num);
                    for (int i = 0; i < summ.Count; i++)
                    {
                        inputOut_containers[i].Text = summ[i].ToString();
                    }
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {   
            input1_containers.Clear();
            inputOut_containers.Clear();
            Matrix.Children.Clear();
            Out.Children.Clear();

            Matrix.ColumnDefinitions.Clear();
            Out.ColumnDefinitions.Clear();
            Matrix.ColumnDefinitions.Add(new ColumnDefinition());
            Matrix.ColumnDefinitions.Add(new ColumnDefinition());
            Out.ColumnDefinitions.Add(new ColumnDefinition());
            Out.ColumnDefinitions.Add(new ColumnDefinition());

            Matrix.RowDefinitions.Clear();
            Out.RowDefinitions.Clear();

            Out.Visibility = Visibility.Collapsed;
            ErrorOper.Visibility = Visibility.Collapsed;
            opr.Text = "";

            if (SizeX.SelectedItem != null && SizeY.SelectedItem != null)
            {
                for (int n = 0; n < (int)SizeX.SelectedItem; n++)
                {
                    Matrix.RowDefinitions.Add(new RowDefinition());
                    Out.RowDefinitions.Add(new RowDefinition());
                }
                for (int m = 0; m < (int)SizeY.SelectedItem; m++)
                {
                    Matrix.ColumnDefinitions.Add(new ColumnDefinition());
                    Out.ColumnDefinitions.Add(new ColumnDefinition());
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
                    Text = "(",
                    FontSize = 50,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Grid.SetRow(tb1, 0);
                Grid.SetColumn(tb1, 0);

                TextBlock tb2 = new TextBlock()
                {
                    Text = ")",
                    FontSize = 50,
                    VerticalAlignment = VerticalAlignment.Center

                };
                Grid.SetRow(tb2, 0);
                Grid.SetColumn(tb2, (int)SizeY.SelectedItem + 1);

                Grid.SetRowSpan(tb1, (int)SizeX.SelectedItem);
                Grid.SetRowSpan(tb2, (int)SizeX.SelectedItem);

                Matrix.Children.Add(tb1);
                Matrix.Children.Add(tb2);


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
                            IsEnabled = false
                        };
                        b.Child = tb;

                        Grid.SetRow(b, n);
                        Grid.SetColumn(b, m + 1);
                        inputOut_containers.Add(tb);

                        Out.Children.Add(b);
                    }
                }

                TextBlock tb3 = new TextBlock()
                {
                    Text = "(",
                    FontSize = 50,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Grid.SetRow(tb3, 0);
                Grid.SetColumn(tb3, 0);

                TextBlock tb4 = new TextBlock()
                {
                    Text = ")",
                    FontSize = 50,
                    VerticalAlignment = VerticalAlignment.Center

                };
                Grid.SetRow(tb4, 0);
                Grid.SetColumn(tb4, (int)SizeY.SelectedItem + 1);

                Grid.SetRowSpan(tb3, (int)SizeX.SelectedItem);
                Grid.SetRowSpan(tb4, (int)SizeX.SelectedItem);

                Out.Children.Add(tb3);
                Out.Children.Add(tb4);
            }
        }

        private void SizeX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SizeY.SelectedIndex = SizeX.SelectedIndex;
        }
    }
}
