﻿// See https://aka.ms/new-console-template for more information

using RabbitMQ.Client;
using System.Text;


var factory = new ConnectionFactory()
{
    HostName = "localhost"
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
const string fila = "fila_teste";
channel.QueueDeclare(queue: fila,
                     durable: false,
                     exclusive: false,
                     arguments: null);

int contador = 0;
while (contador < 5) { 
string mensagem = $"Mensagem{contador} ";
var body = Encoding.UTF8.GetBytes(mensagem);

channel.BasicPublish(exchange: "",
                     routingKey: fila,
                     basicProperties: null,
                     body: body);
    Thread.Sleep(3000);
    contador++;
}
Console.WriteLine("Hello, World!");
Console.ReadLine();