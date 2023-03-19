
using StackExchange.Redis;

// ConnectionMultiplexer sınıfı üzerinden Redis sunucusuna bir bağlantı oluşturunuz.
ConnectionMultiplexer connection =  await ConnectionMultiplexer.ConnectAsync("localhost:6379");

// Devamında bu bağlantı üzerinden subscriber oluşturacağız
ISubscriber subscriber =  connection.GetSubscriber();

// mesaj olusturma

while (true)
{
    Console.Write("Mesajinizi Giriniz : ");
    string message = Console.ReadLine();

    // publish etme islemi
    await subscriber.PublishAsync("mychannel.apple", message);
}