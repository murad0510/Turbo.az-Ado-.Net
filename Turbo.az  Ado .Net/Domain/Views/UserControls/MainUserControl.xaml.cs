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
using Turbo.az__Ado.Net.Domain.ViewModels;

namespace Turbo.az__Ado.Net.Domain.Views.UserControls
{
    /// <summary>
    /// Interaction logic for MainUserControl.xaml
    /// </summary>
    public partial class MainUserControl : UserControl
    {
        public MainUserControl()
        {
            InitializeComponent();
            MainUserControlViewModel viewModel = new MainUserControlViewModel();
            this.DataContext = viewModel;   
        }
    }
}
