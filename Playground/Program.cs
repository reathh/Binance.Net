// See https://aka.ms/new-console-template for more information

//load settings from playgroundsettings.json

using Binance.Net.Clients;
using Binance.Net.Enums;
using CryptoExchange.Net.Authentication;
using Newtonsoft.Json;
using Playground;

var settings = System.Text.Json.JsonSerializer.Deserialize<PlaygroundSettings>(System.IO.File.ReadAllText("playgroundsettings.json"));

var credentials = new ApiCredentials(settings!.BinancePublicKey, settings.BinancePrivateKey);

// var binanceSocketClient = new BinanceSocketClient(options => options.ApiCredentials = credentials);

var binance = new BinanceRestClient(options => options.Margin = true);

binance.SetApiCredentials(credentials);

var response = await binance.SpotApi.Trading.PlaceMarginOrderAsync("BTCFDUSD",
    OrderSide.Buy,
    SpotOrderType.LimitMaker,
    0.0001m,
    price: 68000m,
    autoRepayAtCancel: true,
    sideEffectType: SideEffectType.AutoBorrowRepay,
    usePortfolioMargin: true);

var a = 5;

// var listenKey = await binanceRestClient.SpotApi.Account.StartMarginUserStreamAsync();
//
// if (listenKey.Success)
// {
//     Console.WriteLine("Successfully started user stream");
// }
// else
// {
//     Console.WriteLine($"Failed to start user stream: {listenKey.Error?.Message}");
//
//     return;
// }
//
// var tickerUpdatesSocket = await binanceSocketClient.SpotApi.Account.SubscribeToUserDataUpdatesAsync(listenKey.Data,
//     data => Console.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented)));
//
// _ = Task.Run(async () => {
//     while (true)
//     {
//         await Task.Delay(TimeSpan.FromMinutes(30));
//         await binanceRestClient.SpotApi.Account.KeepAliveMarginUserStreamAsync(listenKey.Data);
//     }
// });
//
// Console.WriteLine("Press any key to exit");
//
// Console.ReadKey();