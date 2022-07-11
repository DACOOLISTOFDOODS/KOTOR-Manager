﻿using System;
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

namespace KOTOR_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainLoaded;
        }

        private void MainLoaded(object sender, RoutedEventArgs e)
        {
            Home.Background = (Brush)new BrushConverter().ConvertFrom("#1A1A1A");
            Home.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F9F9");
            Saves.Background = (Brush)new BrushConverter().ConvertFrom("#1A1A1A");
            Saves.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F9F9");
            Mods.Background = (Brush)new BrushConverter().ConvertFrom("#1A1A1A");
            Mods.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F9F9");
            Options.Background = (Brush)new BrushConverter().ConvertFrom("#1A1A1A");
            Options.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F9F9");
            
            Tabs.Background = (Brush)new BrushConverter().ConvertFrom("#1A1A1A");
        }

        private void L1_Click(object sender, RoutedEventArgs e)
        {
            //launch kotor 1
        }
    }
}