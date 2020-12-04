using System.ComponentModel;

namespace Example_1461
{

    //class Coin
    //{
    //    public string CoinName { get; set; }
    //    public double Delta { get; set; }
    //    public double Value { get; set; }
    //}


    #region ToDo

    class Coin : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string coinName;
        public string CoinName
        {
            get { return this.coinName; }
            set
            {
                this.coinName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CoinName)));
            }
        }

        public double delta;
        public double Delta
        {
            get { return this.delta; }
            set
            {
                this.delta = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Delta)));
            }
        }

        public double value;
        public double Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Value)));
            }
        }
    }

    #endregion
}