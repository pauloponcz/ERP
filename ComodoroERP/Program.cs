using ComodoroERP.Data;
using QuestPDF.Infrastructure;
using ComodoroERP.Services;

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

            new BackupService().CriarBackupAutomatico();

            Application.Run(new FrmMenu());
        }
    }
}