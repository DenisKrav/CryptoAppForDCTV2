using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using CryptoAppForDCTV2.Forms;

namespace CryptoAppForDCTV2.Classes
{
    public class ApplicationViewModel : DependencyObject
    {
        static private Coin selectedCoin = new Coin();


        public ObservableCollection<Coin> Coins { get; set; }


        public Coin SelectedCoin
        {
            get { return selectedCoin; }
            set
            {
                selectedCoin = value;

                CoinInformation coinInformation = new CoinInformation();
                coinInformation.Show();
            }
        }


        public ApplicationViewModel()
        {
            RestClient client = new RestClient("http://api.coincap.io/v2/assets");
            RestRequest request = new RestRequest();
            RestResponse response = client.Execute(request);
            request.AddHeader("Authorization", "Bearer 935bf130 - e617 - 4926 - 8b3d - 6469e88ff2d3");
            string data = response.Content;
            dynamic d = JsonConvert.DeserializeObject<dynamic>(data);

            Coins = new ObservableCollection<Coin>();
            foreach (var coin in d.data)
            {
                Coins.Add(new Coin
                {
                    Id = coin.id,
                    Rank = coin.rank,
                    Symbol = coin.symbol,
                    Name = coin.name,
                    Supply = coin.supply,
                    MaxSupply = coin.maxSupply,
                    MarketCapUsd = coin.marketCapUsd,
                    VolumeUsd24Hr = coin.volumeUsd24Hr,
                    PriceUsd = coin.priceUsd,
                    ChangePercent24Hr = coin.changePercent24Hr,
                    Vwap24Hr = coin.vwap24Hr
                });
            }

            FilteredCoin = CollectionViewSource.GetDefaultView(Coins);
            FilteredCoin.Filter = FilterByCoin;
        }


        public ICollectionView FilteredCoin
        {
            get { return (ICollectionView)GetValue(FilteredCoinProperty); }
            set { SetValue(FilteredCoinProperty, value); }
        }

        public static readonly DependencyProperty FilteredCoinProperty =
           DependencyProperty.Register("FilteredCoin", typeof(ICollectionView), typeof(ApplicationViewModel), new PropertyMetadata(null));



        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        public static readonly DependencyProperty FilterTextProperty =
           DependencyProperty.Register("FilterText", typeof(string), typeof(ApplicationViewModel), new PropertyMetadata("", FilterText_Changed));


        public static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as ApplicationViewModel;
            if (current != null)
            {
                current.FilteredCoin.Filter = null;
                current.FilteredCoin.Filter = current.FilterByCoin;
            }
        }

      
        public bool FilterByCoin(object obj)
        {
            bool result = true;
            Coin current = obj as Coin;
            if (!string.IsNullOrEmpty(FilterText) && current != null &&
                !current.Name.ToLower().Contains(FilterText.ToLower()) &&
                !current.Symbol.ToLower().Contains(FilterText.ToLower()))
            {
                result = false;
            }
            return result;
        }
    }
}
