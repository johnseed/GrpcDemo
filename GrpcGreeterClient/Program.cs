// See https://aka.ms/new-console-template for more information

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Greet;
using Grpc.Net.Client;

var httpHandler = new HttpClientHandler();
// Return `true` to allow certificates that are untrusted/invalid
httpHandler.ServerCertificateCustomValidationCallback =
    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

// The port number(5001) must match the port of the gRPC server.
//using var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpHandler = httpHandler });
using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new Greeter.GreeterClient(channel);
var reply = client.SayHello(new HelloRequest { Name = "GreeterClient" });
Console.WriteLine($"Greeting: {reply.Message}");
Console.WriteLine("Hello, World!");