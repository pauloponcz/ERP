namespace ComodoroERP.Services
{
    public class BackupService
    {
        private readonly ConfiguracaoService _configuracaoService = new();

        public void CriarBackupAutomatico()
        {
            string pastaBase = AppDomain.CurrentDomain.BaseDirectory;

            string pastaDados = Path.Combine(pastaBase, "dados");
            string pastaBackups = _configuracaoService.ObterPastaBackups();

            string caminhoBanco = Path.Combine(pastaDados, "comodoro.db");

            if (!File.Exists(caminhoBanco))
                return;

            if (!Directory.Exists(pastaBackups))
                Directory.CreateDirectory(pastaBackups);

            string dataHoje = DateTime.Now.ToString("yyyyMMdd");

            string caminhoBackup = Path.Combine(
                pastaBackups,
                $"comodoro_backup_{dataHoje}.db"
            );

            if (File.Exists(caminhoBackup))
                return;

            File.Copy(caminhoBanco, caminhoBackup, true);
        }
    }
}