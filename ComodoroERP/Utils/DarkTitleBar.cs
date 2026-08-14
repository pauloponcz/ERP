using System.Runtime.InteropServices;

namespace ComodoroERP.Utils
{
    public static class DarkTitleBar
    {
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(
            IntPtr hwnd,
            int attr,
            ref int attrValue,
            int attrSize
        );

        public static void Ativar(Form form)
        {
            if (form == null)
                return;

            int usarModoEscuro = 1;

            // Windows 10/11 moderno
            DwmSetWindowAttribute(
                form.Handle,
                20,
                ref usarModoEscuro,
                sizeof(int)
            );

            // Compatibilidade com algumas versões antigas do Windows 10
            DwmSetWindowAttribute(
                form.Handle,
                19,
                ref usarModoEscuro,
                sizeof(int)
            );
        }
    }
}