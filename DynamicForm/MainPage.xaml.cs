using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DynamicForm.Models;
using Newtonsoft.Json;
// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=391641

namespace DynamicForm
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página.
        /// Este parámetro se usa normalmente para configurar la página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Preparar la página que se va a mostrar aquí.

            // TODO: Si la aplicación contiene varias páginas, asegúrese de
            // controlar el botón para retroceder del hardware registrándose en el
            // evento Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Si usa NavigationHelper, que se proporciona en algunas plantillas,
            // el evento se controla automáticamente.
        }

        private async Task<String> ReadCategory()
        {
            var client = new HttpClient(); // Add: using System.Net.Http;
            var response = await client.GetAsync(new Uri("https://dynamicformapi.herokuapp.com/groups.json"));
            return  await response.Content.ReadAsStringAsync();
        }

        private async void BindCategoryData()
        {
            String res = await ReadCategory();
            List<Group> obj = JsonConvert.DeserializeObject<List<Group>>(res);
            CategoryList.ItemsSource= obj;            
            WebProgress.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            CategoryContent.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BindCategoryData();
        }

    }
}
