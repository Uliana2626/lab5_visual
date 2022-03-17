using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace lab5_visual.Views
{
    public partial class Regex : Window
    {
        public Regex()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("ok").Click += async delegate
            {
                var textbox = this.FindControl<TextBox>("Regex_Input");
                Close(textbox.Text);
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
