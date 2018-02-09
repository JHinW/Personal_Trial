using System;
using System.Net.Http;

class program
{
    static void Main()
    {
        string type = "type";
        string value = "2";
        string url = $"https://opgapim.azure-api.cn/api/operation/{type}/{value}";


        HttpClient httpClient = new HttpClient();

        string ResourceKey = "89a847882152472d995405adea2caf1f";

        httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ResourceKey);

        HttpResponseMessage response = httpClient.GetAsync(url).Result;

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }

        else
        {
            Console.WriteLine(response.ToString());
        }
    }
}

