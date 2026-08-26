using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;

namespace ComodoroERP.Services
{
    public class AtualizacaoService
    {
        private const string UsuarioGithub = "pauloponcz";
        private const string RepositorioGithub = "ERP";

        public async Task VerificarAtualizacaoAsync()
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
                    return;

                if (versaoGithub > versaoAtual)
                {
                    DialogResult resultado = MessageBox.Show(
                        $"Existe uma nova versão disponível.\n\n" +
                        $"Versão instalada: {versaoAtual}\n" +
                        $"Nova versão: {versaoGithub}\n\n" +
                        $"Deseja abrir a página para baixar a atualização?",
                        "Atualização disponível",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = paginaRelease,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch
            {
                // Não mostra erro para o usuário.
                // Se estiver sem internet ou o GitHub falhar, o sistema abre normalmente.
            }
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
    }
}