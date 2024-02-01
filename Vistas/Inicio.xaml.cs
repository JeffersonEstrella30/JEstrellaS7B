using JEstrellaS7B.Modelos;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace JEstrellaS7B.Vistas;

public partial class Inicio : ContentPage
{
    private const string Url = "http://192.168.100.234/moviles/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> estudies;
	public Inicio()
	{
		InitializeComponent();
        Obtener();
	}
      public async void Obtener()
    {
        try 
        {
            var content = await cliente.GetStringAsync(Url);
            List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
            estudies = new ObservableCollection<Estudiante>(mostrarEst);
            listaEstudiantes.ItemsSource = estudies;
       
        }
        catch (Exception ex) 
        {
           Console.WriteLine("Error al obtener los Datos: " + ex.Message);
        }
    }
    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            var objetoestudiante = (Estudiante)e.SelectedItem;
            Navigation.PushAsync(new ActualizarEliminar(objetoestudiante));
            listaEstudiantes.SelectedItem = null;
        }

    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnAdd_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Vistas.Agregar());

    }
}