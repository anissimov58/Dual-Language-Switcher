namespace LDS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();


            // Create a named mutex with a unique name based on your application name
            bool createdNew;
            Mutex mutex = new Mutex(true, "DLS", out createdNew);

            if (!createdNew)
            {
                // Another instance of the application is already running
                // Display an error message and terminate this instance
                MessageBox.Show("Another instance of the application is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new MainForm());

            // Release the named mutex when the application exits
            mutex.ReleaseMutex();
        }
    }
}