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
    public partial class Mult : Page
    {
        List<Grid> containers;
        List<TextBox> input1_containers;
        List<TextBox> input2_containers;
        List<TextBox> inputOut_containers;

        public Mult()
        {
            InitializeComponent();

            SizeX1.ItemsSource = Matrix_Logic.LenghtLong;
            SizeY1.ItemsSource = Matrix_Logic.LenghtLong;
            SizeX2.ItemsSource = Matrix_Logic.LenghtLong;
            SizeY2.ItemsSource = Matrix_Logic.LenghtLong;

            containers = new List<Grid>() { Matrix, Matrix2, Out };

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
                List<int> outList = Matrix_Logic.Mult(nums1, nums2, (int)SizeX1.SelectedItem, (int)SizeY1.SelectedItem, (int)SizeX2.SelectedItem, (int)SizeY2.SelectedItem); //Change to correct method
                for (int i = 0; i < outList.Count; i++)
                {
                    inputOut_containers[i].Text = outList[i].ToString();
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            input1_containers.Clear();
            input2_containers.Clear();
            inputOut_containers.Clear();

            foreach (Grid container in containers)
            {
                container.Children.Clear();

                container.ColumnDefinitions.Clear();
                container.ColumnDefinitions.Add(new ColumnDefinition());
                container.ColumnDefinitions.Add(new ColumnDefinition());

                container.RowDefinitions.Clear();
            }

            if (SizeX1.SelectedItem != null && SizeY1.SelectedItem != null)
            {
                for (int n = 0; n < (int)SizeX1.SelectedItem; n++)
                {
                    Matrix.RowDefinitions.Add(new RowDefinition());
                }
                for (int m = 0; m < (int)SizeY1.SelectedItem; m++)
                {
                    Matrix.ColumnDefinitions.Add(new ColumnDefinition());
                }

                for (int n = 0; n < (int)SizeX1.SelectedItem; n++)
                {
                    for (int m = 0; m < (int)SizeY1.SelectedItem; m++)
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
                Grid.SetColumn(tb2, (int)SizeY1.SelectedItem + 1);
                Grid.SetRowSpan(tb1, (int)SizeX1.SelectedItem);
                Grid.SetRowSpan(tb2, (int)SizeX1.SelectedItem);

                Matrix.Children.Add(tb1);
                Matrix.Children.Add(tb2);
            }

            if (SizeX2.SelectedItem != null && SizeY2.SelectedItem != null) {
                for (int n = 0; n < (int)SizeX2.SelectedItem; n++)
                {
                    Matrix2.RowDefinitions.Add(new RowDefinition());
                }
                for (int m = 0; m < (int)SizeY2.SelectedItem; m++)
                {
                    Matrix2.ColumnDefinitions.Add(new ColumnDefinition());
                }

                for (int n = 0; n < (int)SizeX2.SelectedItem; n++)
                {
                    for (int m = 0; m < (int)SizeY2.SelectedItem; m++)
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
                            Background = Brushes.Transparent
                        };
                        b.Child = tb;

                        Grid.SetRow(b, n);
                        Grid.SetColumn(b, m + 1);
                        input2_containers.Add(tb);

                        Matrix2.Children.Add(b);
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
                Grid.SetColumn(tb2, (int)SizeY2.SelectedItem + 1);
                Grid.SetRowSpan(tb1, (int)SizeX2.SelectedItem);
                Grid.SetRowSpan(tb2, (int)SizeX2.SelectedItem);

                Matrix2.Children.Add(tb1);
                Matrix2.Children.Add(tb2);
            }

            if (SizeX1.SelectedItem != null && SizeY2.SelectedItem != null)
            {
                for (int n = 0; n < (int)SizeX1.SelectedItem; n++)
                {
                    Out.RowDefinitions.Add(new RowDefinition());
                }
                for (int m = 0; m < (int)SizeY2.SelectedItem; m++)
                {
                    Out.ColumnDefinitions.Add(new ColumnDefinition());
                }

                for (int n = 0; n < (int)SizeX1.SelectedItem; n++)
                {
                    for (int m = 0; m < (int)SizeY2.SelectedItem; m++)
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
                Grid.SetColumn(tb2, (int)SizeY2.SelectedItem + 1);
                Grid.SetRowSpan(tb1, (int)SizeX1.SelectedItem);
                Grid.SetRowSpan(tb2, (int)SizeX1.SelectedItem);

                Out.Children.Add(tb1);
                Out.Children.Add(tb2);
            }
        }

        private void SizeY1_Selected(object sender, RoutedEventArgs e)
        {
            SizeX2.SelectedIndex = SizeY1.SelectedIndex;
        }
    }
}
