using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace ComodoroERP.Services
{
    public class AtualizacaoDisponivel
    {
        public Version VersaoAtual { get; set; } = new Version(1, 0, 0, 0);
        public Version NovaVersao { get; set; } = new Version(1, 0, 0, 0);
        public string UrlDownload { get; set; } = string.Empty;
        public string PaginaRelease { get; set; } = string.Empty;
    }

    public class AtualizacaoService
    {
        private const string UsuarioGithub = "pauloponcz";
        private const string RepositorioGithub = "ERP";

        public async Task<AtualizacaoDisponivel?> VerificarAtualizacaoDisponivelAsync()
        {
            try
            {
                Version versaoAtual = ObterVersaoAtual();

                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.UserAgent.Add(
                    new ProductInfoHeaderValue("ComodoroERP", versaoAtual.ToString())
                );

                string url = $"https://api.github.com/repos/{UsuarioGithub}/{RepositorioGithub}/releases/latest";

                string json = await httpClient.GetStringAsync(url);

                using JsonDocument documento = JsonDocument.Parse(json);

                JsonElement root = documento.RootElement;

                string tagName = root.GetProperty("tag_name").GetString() ?? "";
                string paginaRelease = root.GetProperty("html_url").GetString() ?? "";

                Version? versaoGithub = ConverterTagParaVersao(tagName);

                if (versaoGithub == null)
                    return null;

                if (versaoGithub <= versaoAtual)
                    return null;

                string urlDownload = ObterUrlDownloadZip(root);

                return new AtualizacaoDisponivel
                {
                    VersaoAtual = versaoAtual,
                    NovaVersao = versaoGithub,
                    UrlDownload = urlDownload,
                    PaginaRelease = paginaRelease
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task InstalarAtualizacaoAsync(AtualizacaoDisponivel atualizacao)
        {
            if (atualizacao == null)
                return;

            if (string.IsNullOrWhiteSpace(atualizacao.UrlDownload))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = atualizacao.PaginaRelease,
                    UseShellExecute = true
                });

                return;
            }

            await BaixarEInstalarAtualizacaoAsync(
                atualizacao.UrlDownload,
                atualizacao.NovaVersao
            );
        }

        private async Task BaixarEInstalarAtualizacaoAsync(string urlDownload, Version novaVersao)
        {
            string pastaTemp = Path.Combine(Path.GetTempPath(), "ComodoroERP_Update");
            string pastaExtraida = Path.Combine(pastaTemp, "extraido");
            string arquivoZip = Path.Combine(pastaTemp, $"ComodoroERP-v{FormatarVersao(novaVersao)}.zip");
            string pastaAplicacao = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            string caminhoBat = Path.Combine(pastaTemp, "atualizar_comodoro.bat");

            if (Directory.Exists(pastaTemp))
                Directory.Delete(pastaTemp, true);

            Directory.CreateDirectory(pastaTemp);

            using var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("ComodoroERP", FormatarVersao(novaVersao))
            );

            byte[] conteudo = await httpClient.GetByteArrayAsync(urlDownload);

            await File.WriteAllBytesAsync(arquivoZip, conteudo);

            string conteudoBat = MontarScriptAtualizacao(
                arquivoZip,
                pastaExtraida,
                pastaAplicacao
            );

            await File.WriteAllTextAsync(caminhoBat, conteudoBat, Encoding.UTF8);

            Process.Start(new ProcessStartInfo
            {
                FileName = caminhoBat,
                UseShellExecute = true,
                WorkingDirectory = pastaTemp,
                WindowStyle = ProcessWindowStyle.Hidden
            });

            Application.Exit();
        }

        private string MontarScriptAtualizacao(
            string arquivoZip,
            string pastaExtraida,
            string pastaAplicacao)
        {
            string exeAplicacao = Path.Combine(pastaAplicacao, "ComodoroERP.exe");

            return $@"
@echo off
chcp 65001 >nul

set ""ZIP={arquivoZip}""
set ""TEMP={pastaExtraida}""
set ""DESTINO={pastaAplicacao}""
set ""EXE={exeAplicacao}""

timeout /t 3 /nobreak >nul

if exist ""%TEMP%"" rmdir /s /q ""%TEMP%""
mkdir ""%TEMP%""

powershell -NoProfile -ExecutionPolicy Bypass -Command ""Expand-Archive -Path '%ZIP%' -DestinationPath '%TEMP%' -Force""

if exist ""%TEMP%\ComodoroERP.exe"" copy /Y ""%TEMP%\ComodoroERP.exe"" ""%DESTINO%\ComodoroERP.exe""
if exist ""%TEMP%\e_sqlite3.dll"" copy /Y ""%TEMP%\e_sqlite3.dll"" ""%DESTINO%\e_sqlite3.dll""
if exist ""%TEMP%\qpdf.dll"" copy /Y ""%TEMP%\qpdf.dll"" ""%DESTINO%\qpdf.dll""
if exist ""%TEMP%\QuestPdfSkia.dll"" copy /Y ""%TEMP%\QuestPdfSkia.dll"" ""%DESTINO%\QuestPdfSkia.dll""

if exist ""%TEMP%\LatoFont"" (
    if exist ""%DESTINO%\LatoFont"" rmdir /s /q ""%DESTINO%\LatoFont""
    xcopy ""%TEMP%\LatoFont"" ""%DESTINO%\LatoFont\"" /E /Y /I >nul
)

start """" ""%EXE%""

exit
";
        }

        private string ObterUrlDownloadZip(JsonElement root)
        {
            if (!root.TryGetProperty("assets", out JsonElement assets))
                return "";

            foreach (JsonElement asset in assets.EnumerateArray())
            {
                string nomeArquivo = asset.GetProperty("name").GetString() ?? "";

                if (!nomeArquivo.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                    continue;

                string urlDownload = asset.GetProperty("browser_download_url").GetString() ?? "";

                if (!string.IsNullOrWhiteSpace(urlDownload))
                    return urlDownload;
            }

            return "";
        }

        private Version ObterVersaoAtual()
        {
            Version? versao = Assembly
                .GetExecutingAssembly()
                .GetName()
                .Version;

            return versao ?? new Version(1, 0, 0, 0);
        }

        private Version? ConverterTagParaVersao(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
                return null;

            tag = tag.Trim();

            if (tag.StartsWith("v", StringComparison.OrdinalIgnoreCase))
                tag = tag.Substring(1);

            if (Version.TryParse(tag, out Version? versao))
                return versao;

            return null;
        }

        public string FormatarVersao(Version versao)
        {
            int major = versao.Major < 0 ? 0 : versao.Major;
            int minor = versao.Minor < 0 ? 0 : versao.Minor;
            int build = versao.Build < 0 ? 0 : versao.Build;

            return $"{major}.{minor}.{build}";
        }
    }
}