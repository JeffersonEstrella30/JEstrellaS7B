using System.Linq.Expressions;
namespace JEstrellaS7B.Vistas;

public partial class Agregar : ContentPage
{
	public Agregar()
	{
		InitializeComponent();
	}

   

    private async void btnAgregar_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            var httpClient = new HttpClient();
            var parametros = new List<KeyValuePair<string, string>>
            { new KeyValuePair<string, string>("nombre", txtNombre.Text),
            new KeyValuePair<string, string>("apellido", txtApellido.Text),
            new KeyValuePair<string, string>("edad", txtEdad.Text)
            };
            var content = new FormUrlEncodedContent(parametros);
            var response = await httpClient.PatchAsync("http://192.168.100.234/moviles/post.php", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Exito", "Estudiante agregado correctamente", "OK");
                await Navigation.PushAsync(new Inicio());
            }
            else
            {
                await DisplayAlert("Error", "No se puede agregar al estudiante", "OK");
            }

        }

        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
