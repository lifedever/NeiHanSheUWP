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
using Windows.Web.Http;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace neihanshe
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string NEIHAN_URL = "http://m.neihanshe.cn/apps/get_json.php?class=hot&page=1&day=1";
        public ObservableCollection<Article> ItemCollection = new ObservableCollection<Article>();
        public MainPage()
        {
            this.InitializeComponent();
            ArticlesListView.ItemsSource = ItemCollection;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(new Uri(NEIHAN_URL));
            var content = await response.Content.ReadAsStringAsync();
            content = content.Remove(1, content.IndexOf(","));
            List<Article> articles = JsonConvert.DeserializeObject<List<Article>>(content);
            foreach (var article in articles)
            {
                ItemCollection.Add(article);
            }
        }

    }
    
}
