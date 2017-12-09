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
    public partial class DataPage : ContentPage
    {
        public ObservableCollection<_13090300> Items { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090300> Tabla;
        public static MobileServiceUser usuario;
        public static MobileServiceUser usu;

        public DataPage()
        {
            InitializeComponent();
            Cliente = new MobileServiceClient(AzureConecction.URLAzure);
            Tabla = Cliente.GetTable<_13090300>();
        }

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushAsync(new SelectPage(e.SelectedItem as _13090300));
        }
       
        private void Boton_Insertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertPage());
        }
        private async void LeerTabla()
        {
            IEnumerable<_13090300> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<_13090300>(elementos);
            BindingContext = this;
            Lista.ItemsSource = Items;
        }

        private void Boton_Recuperar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Recuperados(usuario));
        }

        private async void Boton_Login_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (App.Authenticator != null)
                {
                    usuario = await App.Authenticator.Authenticate();

                    if (usuario != null)
                    {
                        await DisplayAlert("ADMINISTRADOR AUTENTICADO", usuario.UserId, "OK");
                        LeerTabla();
                    }
                    if (usuario == null)

                    {
                                         
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "ok");
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (usuario != null)
            {
                LeerTabla();
            }
        }
       
    }
        
}

    