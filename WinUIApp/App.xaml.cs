using Microsoft.UI.Xaml;

namespace WinUIApp
{
    public partial class App : Application
    {
        // On expose la fenêtre principale pour pouvoir l'utiliser dans les ViewModels (Popups)
        public static Window MainWindow { get; private set; }

        // Correction du nom de la variable ici (m_window au lieu de _window)
        private Window m_window;

        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            MainWindow = m_window; // On sauvegarde la référence publique
            m_window.Activate();
        }
    }
}