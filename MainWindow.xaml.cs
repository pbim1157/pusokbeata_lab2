using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace pusokbeata_lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DoughnutMachine myDoughnutMachine;
        private int m_RaisedGlazed;
        private int m_RaisedSugar;
        private int m_FilledLemon;
        private int m_FilledChocolate;
        private int m_FilledVanilla;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine = new DoughnutMachine();
            myDoughnutMachine.DoughnutComplete += new
            DoughnutMachine.DoughnutCompleteDelegate(DoughnutCompleteHandler);
        }

        private void glazedToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedToolStripMenuItem.IsChecked = true;
            sugarToolStripMenuItem.IsChecked = false;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Glazed);
        }
        private void sugarToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedToolStripMenuItem.IsChecked = false;
            sugarToolStripMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Sugar);
        }

        private void DoughnutCompleteHandler()
        {
            switch (myDoughnutMachine.Flavor)
            {
                case DoughnutType.Glazed:
                    {
                        m_RaisedGlazed++;
                        txtGlazedRaised.Text = m_RaisedGlazed.ToString();
                        break;
                    }
                case DoughnutType.Sugar:
                    {
                        m_RaisedSugar++;
                        txtSugarRaised.Text = m_RaisedSugar.ToString();
                        break;
                    }

                case DoughnutType.Lemon:
                    {
                        m_FilledLemon++;
                        txtLemonFilled.Text = m_FilledLemon.ToString();
                        break;
                    }
                case DoughnutType.Chocolate:
                    {
                        m_FilledChocolate++;
                        txtChocolateFilled.Text = m_FilledChocolate.ToString();
                        break;
                    }
                case DoughnutType.Vanilla:
                    {
                        m_FilledVanilla++;
                        txtVanillaFilled.Text = m_FilledVanilla.ToString();
                        break;
                    }
                default:
                    {
                        throw new InvalidEnumArgumentException($"Invalid Flavor {myDoughnutMachine.Flavor}");
                    }
            }
        }

        private void stopToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtQuantity_KeyPress(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }
    }
}

