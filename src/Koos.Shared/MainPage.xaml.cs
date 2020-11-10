using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Koos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private static string DatabasePath => Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "MyData.db");
        public MainPage()
        {
            this.InitializeComponent();


            this.Loaded += (sender, e) =>
            {
                InitDatabase();
                using var db = GetDatabase();
                UpdateList(db);
            };

        }

        public void OnClickMe()
        {
            using var db = GetDatabase();
            AddStock(db, stockSymbol.Text);
            UpdateList(db);
        }

        private static void InitDatabase()
        {
            var exists = File.Exists(DatabasePath);
            using var db = new SQLiteConnection(DatabasePath);
            if (!exists)
            {
                db.CreateTable<Stock>();
                db.CreateTable<Valuation>();
            }
        }

        private static SQLiteConnection GetDatabase()
        {
            return new SQLiteConnection(DatabasePath);
        }

        private void UpdateList(SQLiteConnection db)
        {
            symbolsList.ItemsSource = db.Table<Stock>().Select(s => s.Symbol).ToList();
        }

        public static void AddStock(SQLiteConnection db, string symbol)
        {
            var stock = new Stock()
            {
                Symbol = symbol
            };
            db.Insert(stock);
            Console.WriteLine("{0} == {1}", stock.Symbol, stock.Id);
        }
    }

    public class Stock
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Symbol { get; set; }
    }

    public class Valuation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int StockId { get; set; }
        public DateTime Time { get; set; }
        public decimal Price { get; set; }
    }
}
