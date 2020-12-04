using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Example_1461
{

    class DataProvider
    {
        DispatcherTimer timer;
        public ObservableCollection<Coin> Data;
        Random r = new Random();

        public DataProvider()
        {
            r = new Random();

            Data = new ObservableCollection<Coin>()
            {
                new Coin(){ CoinName = "GBP", Value = 78},
                new Coin(){ CoinName = "USD", Value = 63},
                new Coin(){ CoinName = "EUR", Value = 70},
                new Coin(){ CoinName = "AUD", Value = 44},
                new Coin(){ CoinName = "JPY", Value = 58},
                new Coin(){ CoinName = "SEK", Value = 67},
            };

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Data.Count; i++)
            {
                double d = r.Next(-5, 6);
                Data[i].Value += d;
                Data[i].Delta = d;
            }

            //foreach (var item in Data) Console.Write($"{item} ");
            //Console.WriteLine();
        }
    }
}
