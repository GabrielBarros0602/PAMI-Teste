namespace GabrielTestePAM;

public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    public NotePage()
    {
        InitializeComponent();

        if (File.Exists(_fileName))
            TextEditor.Text = File.ReadAllText(_fileName);
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, TextEditor.Text);
        await DisplayAlert(nameof(NotePage), "Arquivo criado com sucesso", "Ok");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (!File.Exists(_fileName))
        {
            await DisplayAlert("Deletar arquivo", "Parece que você não possui esse arquivo.", "Ok");
        }

        if (File.Exists(_fileName))
        {
            File.Delete(_fileName);
            await DisplayAlert("Deletar arquivo", "Arquivo deletado com sucesso!", "Ok");
            TextEditor.Text = string.Empty;

        }
    }
}