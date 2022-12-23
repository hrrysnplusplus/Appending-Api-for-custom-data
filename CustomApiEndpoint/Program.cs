
/*Creating a custom api endpoint that retreives data for different cryptocurrencies

 * the assets to retrieve are in a user's portfolio 
 * the api endpoint to receive selected coin data is... 
 * https://api.coinlore.net/api/ticker/?id=90,80,2 */


//Mock data of assets in a user's portfolio
Dictionary<string, string> userPortfolioDict = new Dictionary<string, string>
{
    { "Bitcoin", "90" },
    { "Ethereum", "80" },
    { "Doge", "2" },
    { "Dot", "45219" },
    { "Xrp", "52" }
};


var customApiEndpoint = await ConfigureApiEndpointAsync(userPortfolioDict);

Console.WriteLine(customApiEndpoint);




//appending the api endpoint with assets in a user's portfolio
async Task<string> ConfigureApiEndpointAsync(Dictionary<string, string> dict)
{
    var sb = new System.Text.StringBuilder();
    const string _apiUri = "https://api.coinlore.net/api/ticker/?id=";

    var count = dict.Count;
    var index = 0;
    foreach (var i in dict.Values)
    {
        if (index < count - 1)
        {
            sb.Append(i + ',');

        }
        if (index == count - 1)
        {
            sb.Append(i);
        }
        index++;
    }

    return await Task.FromResult(_apiUri + sb.ToString());
}


