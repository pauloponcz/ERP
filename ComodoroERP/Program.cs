using ComodoroERP.Data;
using QuestPDF.Infrastructure;

namespace ComodoroERP
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            QuestPDF.Settings.License = LicenseType.Community;

            Database.Inicializar();

            Application.Run(new FrmMenu());
        }
    }
}