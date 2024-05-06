namespace Palworld.RESTSharp.Client
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            FormMain mainForm = new FormMain();
            try
            {
                Application.Run(mainForm);
            }
            catch(Exception ex)
            {
                mainForm.DisplayError("An unhandled error has occurred. Please open a bug report at https://github.com/Balphagorevr/palworld-restsharp/issues.");
            }
        }
    }
}