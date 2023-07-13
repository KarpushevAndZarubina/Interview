using System.Net.Http.Json;

using Gov.ApiClient.Model;

namespace Gov.ApiClient;

public class GovApiClient
{
    public Task<FapResponse?> FapAsync(DateTime lastUpdateFrom, DateTime lastUpdateTo, int page)
    {
        using var httpClient = new System.Net.Http.HttpClient();
        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 YaBrowser/23.5.4.674 Yowser/2.5 Safari/537.36");
        return httpClient.GetFromJsonAsync<FapResponse>($"https://bus.gov.ru/public-rest/api/epbs/fap?LastUpdateFrom={lastUpdateFrom:dd.MM.yyyy}&lastUpdateTo={lastUpdateTo:dd.MM.yyyy}&page={page}&size=100");
        //var resp = await $"https://bus.gov.ru/public-rest/api/epbs/fap?LastUpdateFrom=04.12.2019&lastUpdateTo=10.12.2019&page={i}&size=100"
        //    .WithHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 YaBrowser/23.5.4.674 Yowser/2.5 Safari/537.36")
        //    .GetStringAsync();
    }
}
