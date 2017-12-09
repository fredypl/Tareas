using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;

namespace Tareas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Usuarios : ContentPage
    {
        public ObservableCollection<_13090300> Items { get; set; }
        public MobileServiceUser user;
        public Usuarios(MobileServiceUser usu)
        {
            InitializeComponent();
            user = usu;
            LeerTabla();
        }

         async void Lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushAsync(new Usuario(e.SelectedItem as _13090300));
        }
        private async void LeerTabla()
        {
               IEnumerable<_13090300> elementos = await DataPage.Tabla.ToEnumerableAsync();
                Items = new ObservableCollection<_13090300>(elementos);
                BindingContext = this;
                Lista.ItemsSource = Items;

              
        }
    }
}