using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeaderConsole.View
{
    /// <summary>
    /// mainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class mainPage : Page
    {
        public mainPage()
        {
            InitializeComponent();
        }


       public void mainPage_Load(object sender, RoutedEventArgs e)
        {
                HttpClient client = new HttpClient();
         
                string url = "http://apis.data.go.kr/1360000/MidFcstInfoService/getMidLandFcst"; // URL
                url += "?ServiceKey=" + "CO5AAa%2Bz%2FvhOJ88caWzYfMEzejHmUUAt7AjDXNfaMzaDLDUMTppC82szj9hBh86dhjsOIcWyQO6ag4SWOv6XbA%3D%3D"; // Service Key
                url += "&pageNo=1";
                url += "&numOfRows=10";
                url += "&dataType=JSON";
                url += "&stnId=108";
                url += "&tmFc=202212030600";

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                string results = string.Empty;
                HttpWebResponse? response;
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    results = reader.ReadToEnd();
                }

                Console.WriteLine(results);
            
        }
    }
}
