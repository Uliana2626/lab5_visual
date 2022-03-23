using Avalonia.Controls;
using Avalonia.Interactivity;
using lab5_visual.ViewModels;
using System.IO;

namespace lab5_visual.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("Set_Regex").Click += RegSubHandler;


            this.FindControl<Button>("Open_File").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Open file",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);
                string[]? path = await taskPath;
                string clear_path;

                if (path != null) {
                    var context = this.DataContext as MainWindowViewModel;
                    clear_path = string.Join(@"\", path);

                    string s = File.ReadAllText(clear_path);

                    context.Text = s;
                }
                    

            };

            this.FindControl<Button>("Save_File").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Save File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? path = await taskPath;
                var context = this.DataContext as MainWindowViewModel;
                if (path != null)
                {
                    using (StreamWriter sw = File.CreateText(string.Join(@"\", path)))
                    {
                        sw.WriteLine(context.Result);
                    }
                }
            };
        }
        private async void RegSubHandler(object sender, RoutedEventArgs e)
        {
            string? str = await new Regex().ShowDialog<string?>((Window)this.VisualRoot);
            var context = this.DataContext as MainWindowViewModel;
            context.Regex = str;
            context.Result = context.Regex_Result();
        }
    }
}
