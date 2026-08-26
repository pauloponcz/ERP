using System.Drawing;

namespace ComodoroERP
{
    public class FrmBase : Form
    {
        private static readonly Icon? IconeAplicacao =
            Icon.ExtractAssociatedIcon(Application.ExecutablePath);

        public FrmBase()
        {
            if (IconeAplicacao != null)
            {
                Icon = IconeAplicacao;
                ShowIcon = true;
            }
        }
    }
}