using StackExchange.Redis;

// ConnectionMultiplexer sınıfı üzerinden Redis sunucusuna bir bağlantı oluşturunuz.
ConnectionMultiplexer connection = await ConnectionMultiplexer.ConnectAsync("localhost:6379");

// Devamında bu bağlantı üzerinden subscriber oluşturacağız
ISubscriber subscriber = connection.GetSubscriber();

// subscribe olarak consume islemini gerceklestirebilriz
await subscriber.SubscribeAsync("mychannel.*", (channel, value) =>
{
    // mesaj string olarak gelecektir
    Console.WriteLine(value);

});

Console.Read();