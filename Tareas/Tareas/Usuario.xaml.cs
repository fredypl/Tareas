using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tareas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Usuario : ContentPage
    {
        public ObservableCollection<_13090300> Items { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090300> Tabla;
        public static MobileServiceUser usu;

        public Usuario(object selectedItem)
        {
            InitializeComponent();
            var dato = selectedItem as _13090300;
            BindingContext = dato;
            string[] perasig = { "oscar", "juan", "teo", "jessi", "freddy" };
            Picker_PerAsig.ItemsSource = perasig;
            Picker_PerAsig.SelectedItem = dato.PerAsig;
            string[] prioridad = { "Ahora", "Despues", "Final" };
            Picker_Prioridad.ItemsSource = prioridad;
            Picker_Prioridad.SelectedItem = dato.Prioridad;
            string[] dependencia = { "primera tarea", "segunda tarea", "tercer tarea" };
            Picker_Dependencia.ItemsSource = dependencia;
            Picker_Dependencia.SelectedItem = dato.Dependencia;
            string[] status = { "Creada", "En Ejecucion", "Completada", "No Completada" };
            Picker_Status.ItemsSource = status;
            Picker_Status.SelectedItem = dato.Status;
        }

        private async void Button_Enviar_Clicked(object sender, EventArgs e)
        {
            var Id = new _13090300
            {
                Id = Entry_Id.Text,
                Titulo = Entry_Titulo.Text,
                Descripcion = Entry_Descripcion.Text,
                PerAsig = Convert.ToString(Picker_PerAsig.SelectedItem),
                Prioridad = Convert.ToString(Picker_Prioridad.SelectedItem),
                Fecha = Entry_Fecha.Date,
                Dependencia = Convert.ToString(Picker_Dependencia.SelectedItem),
                Status = Convert.ToString(Picker_Status.SelectedItem)


            };
            await DataPage.Tabla.UpdateAsync(Id);
            await DisplayAlert("Tarea enviada", "", "OK");
            await Navigation.PopToRootAsync();
        }
    }
}