using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Polar.Model;
using Polar.ViewModel;
using Xamarin.Forms;

namespace Polar
{
    public partial class DoListPage : ContentPage
    {
        DoListVM doListVm;
        //public ObservableCollection<(string projectName, Piece piece)> PieceTupleList { get; private set; }
        public DoListPage()
        {
            InitializeComponent();

            doListVm = new DoListVM();
            BindingContext = doListVm;

            //PieceTupleList = new ObservableCollection<(string projectName, Piece piece)>();
            //PieceTupleList.Add(("test", new Piece { PieceName = "pn" }));


            listView.ItemsSource = doListVm.PieceTupleList;

        }
    }
}
