using CasaPoupança.database;
using System;
using System.Data.Entity;
using System.Windows.Forms;


namespace CasaPoupanca
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CasaPoupancaDB>());
            using (var db = new CasaPoupancaDB())
            {
                db.Database.Initialize(false);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using(FormLogin login = new FormLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new FormLogin());
                }
                else
                {
                    Application.Exit();
                }
                
            }
            
        }
    }
}
