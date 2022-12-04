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
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http
using System.Xml;

namespace WeaderConsole.View
{
    /// <summary>
    /// mainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class mainPage : Page
    {

        HttpClient client = new HttpClient();
        public mainPage()
        {
            InitializeComponent();
        }


        public void mainPage_Load(object sender, RoutedEventArgs e)
        {

            static void Main(string[] args)
            {
                string url = "http://apis.data.go.kr/1360000/VilageFcstInfoService_2.0/getVilageFcst"; // URL
                url += "?ServiceKey=" + "CO5AAa%2Bz%2FvhOJ88caWzYfMEzejHmUUAt7AjDXNfaMzaDLDUMTppC82szj9hBh86dhjsOIcWyQO6ag4SWOv6XbA%3D%3D"; // Service Key
                url += "&pageNo=1";
                url += "&numOfRows=500";
                url += "&dataType=JSON";
                url += "&base_date=20221204";
                url += "&base_time=0500";
                url += "&nx=55";
                url += "&ny=127";

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                string results = string.Empty;
                HttpWebResponse response;

                using (response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    results = reader.ReadToEnd();
                }


                var json_data = JObject.Parse(results);


                foreach (var item in json_data["response"]["body"]["items"]["item"])
                {

                    string sky;
                    string tem;
                    string rain;
                    string time;
                    string wet;

                    if ((string)item["category"] == "SKY")
                    {
                        sky = (string)item["fcstValue"];

                        if(sky == "1")
                        {
                            sky = "맑음";
                        }

                        else if (sky == "3")
                        {
                            sky = "구름많음";
                        }

                        else if (sky == "4")
                        {
                            sky = "흐림";
                        }
                    }


                    if ((string)item["category"] == "POP")
                    {
                        wet = (string)item["fcstValue"];

                    }

                    if ((string)item["category"] == "TMP")
                    {
                        tem = (string)item["fcstValue"];
                    }

                    if ((string)item["category"] == "POP")
                    {
                        wet = (string)item["fcstValue"];
                    }







                    if ((string)item["category"] == "PTY")
                    {
                        rain = (string)item["fcstValue"];

                         if(rain == "1")
                        {
                            sky = "비";
                        }

                        else if(rain == "2")
                        {
                            sky = "비/눈";
                        }

                        else if (rain == "3")
                        {
                            sky = "눈";
                        }

                        else if (rain == "4")
                        {
                            sky = "소나기";
                        }
                    }
                }


            }
        }


        private List<Model.WeatherModel> weatherModels = new List<Model.WeatherModel>();
    }

}
