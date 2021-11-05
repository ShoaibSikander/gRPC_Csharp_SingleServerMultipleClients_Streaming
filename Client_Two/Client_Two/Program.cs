using System;
using Grpc.Net.Client;
using System.Threading.Tasks;
using Grpc.Core;

namespace Client_Two
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("This is Client 2");
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            Console.WriteLine(" ***** Unary Communication ***** ");
            var clientTwoUnary = new testing.testingClient(channel);
            string msgU = "Hello from Client 2";
            var clientTwoUnaryReq = new TestReq { Req = msgU };
            Console.WriteLine("Client sent a test request to the server ...");
            var clientTwoResp = await clientTwoUnary.TestWorkUnaryAsync(clientTwoUnaryReq);
            Console.WriteLine("Client received a test response from the server ...");
            Console.WriteLine("Received message from the server: " + clientTwoResp.Resp);

            Console.WriteLine(" \n --------------------------------------------- \n ");

            Console.WriteLine(" ***** Server Streaming Communication ***** ");
            var clientTwoServerStream = new testing.testingClient(channel);
            string msgSS = "Hello from Client 2";
            var clientTwoServerStreamReq = new TestReq { Req = msgSS };
            Console.WriteLine("Client sent a test request to the server ...");
            using var callSS = clientTwoServerStream.TestWorkServerStream(clientTwoServerStreamReq);
            Console.WriteLine("Client is receiving a stream of test responses from the server ...");
            while (await callSS.ResponseStream.MoveNext())
            {
                Console.WriteLine("Received message from the server: " + callSS.ResponseStream.Current.Resp);
            }

            Console.WriteLine(" \n --------------------------------------------- \n ");

            Console.WriteLine(" ***** Client Streaming Communication ***** ");
            var clientTwoClientStream = new testing.testingClient(channel);
            string msgCS = "Hello from Client 2";
            var clientTwoClientStreamReq = new TestReq { Req = msgCS };
            Console.WriteLine("Client is sending a stream of messages to the server ...");
            using var callCS = clientTwoClientStream.TestWorkClientStream();
            for (var i = 0; i < 10; i++)
            {
                await callCS.RequestStream.WriteAsync(clientTwoClientStreamReq);
                await Task.Delay(1000);
            }
            await callCS.RequestStream.CompleteAsync();
            var responseCS = await callCS;
            Console.WriteLine("Client received a test response from the server ...");
            Console.WriteLine($"Received message from the server: {responseCS.Resp}");

            Console.WriteLine(" \n --------------------------------------------- \n ");

            Console.WriteLine(" ***** Bidirectional Streaming Communication ***** ");
            var clientTwoBidirectionalStream = new testing.testingClient(channel);
            string msgBS = "Hello from Client 2";
            var clientTwoBidirectionalStreamReq = new TestReq { Req = msgBS };
            Console.WriteLine("Client is sending a stream of messages to the server ...");
            using var callBS = clientTwoBidirectionalStream.TestWorkBidirectionalStream();
            for (var i = 0; i < 15; i++)
            {
                await callBS.RequestStream.WriteAsync(clientTwoBidirectionalStreamReq);
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
