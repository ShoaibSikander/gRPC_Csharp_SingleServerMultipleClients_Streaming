using System;
using Grpc.Net.Client;
using System.Threading.Tasks;
using Grpc.Core;

namespace Client_One
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("This is Client 1");
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            Console.WriteLine(" ***** Unary Communication ***** ");
            var clientOneUnary = new testing.testingClient(channel);
            string msgU = "Hello from Client 1";
            var clientOneUnaryReq = new TestReq { Req = msgU };
            Console.WriteLine("Client sent a test request to the server ...");
            var clientOneResp = await clientOneUnary.TestWorkUnaryAsync(clientOneUnaryReq);
            Console.WriteLine("Client received a test response from the server ...");
            Console.WriteLine("Received message from the server: " + clientOneResp.Resp);

            Console.WriteLine(" \n --------------------------------------------- \n ");

            Console.WriteLine(" ***** Server Streaming Communication ***** ");
            var clientOneServerStream = new testing.testingClient(channel);
            string msgSS = "Hello from Client 1";
            var clientOneServerStreamReq = new TestReq { Req = msgSS };
            Console.WriteLine("Client sent a test request to the server ...");
            using var callSS = clientOneServerStream.TestWorkServerStream(clientOneServerStreamReq);
            Console.WriteLine("Client is receiving a stream of test responses from the server ...");
            while (await callSS.ResponseStream.MoveNext())
            {
                Console.WriteLine("Received message from the server: " + callSS.ResponseStream.Current.Resp);
            }

            Console.WriteLine(" \n --------------------------------------------- \n ");

            Console.WriteLine(" ***** Client Streaming Communication ***** ");
            var clientOneClientStream = new testing.testingClient(channel);
            string msgCS = "Hello from Client 1";
            var clientOneClientStreamReq = new TestReq { Req = msgCS };
            Console.WriteLine("Client is sending a stream of messages to the server ...");
            using var callCS = clientOneClientStream.TestWorkClientStream();
            for (var i = 0; i < 10; i++)
            {
                await callCS.RequestStream.WriteAsync(clientOneClientStreamReq);
                await Task.Delay(1000);
            }
            await callCS.RequestStream.CompleteAsync();
            var responseCS = await callCS;
            Console.WriteLine("Client received a test response from the server ...");
            Console.WriteLine($"Received message from the server: {responseCS.Resp}");

            Console.WriteLine(" \n --------------------------------------------- \n ");

            Console.WriteLine(" ***** Bidirectional Streaming Communication ***** ");
            var clientOneBidirectionalStream = new testing.testingClient(channel);
            string msgBS = "Hello from Client 1";
            var clientOneBidirectionalStreamReq = new TestReq { Req = msgBS };
            Console.WriteLine("Client is sending a stream of messages to the server ...");
            using var callBS = clientOneBidirectionalStream.TestWorkBidirectionalStream();
            for (var i = 0; i < 15; i++)
            {
                await callBS.RequestStream.WriteAsync(clientOneBidirectionalStreamReq);
                await Task.Delay(1000);
            }
            Console.WriteLine("Client is receiving a stream of messages from the server ...");
            var responseBS = Task.Run(async () =>
            {
                await foreach (var rm in callBS.ResponseStream.ReadAllAsync())
                {
                    Console.WriteLine("Received message from the server: " + rm.Resp);
                }
            });
            await callBS.RequestStream.CompleteAsync();
            await responseBS;
        }
    }
}
