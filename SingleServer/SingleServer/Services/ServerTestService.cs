using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SingleServer
{
    public class Global
    {
        public static string rcvdStrBS;
        public static string clientNumberBS;
    }

    public class ServerTestService : testing.testingBase
    {


        private readonly ILogger<ServerTestService> _logger;
        public ServerTestService(ILogger<ServerTestService> logger)
        {
            _logger = logger;
        }

        public override Task<TestResp> TestWorkUnary(TestReq request, ServerCallContext context)
        {
            Console.WriteLine("UC --> Server received a test request ...");
            string rcvdStrUC = string.Empty;
            string clientNumberUC = string.Empty;
            rcvdStrUC = request.Req;
            Console.WriteLine($"UC --> Received message from the client: {rcvdStrUC}");

            Console.WriteLine("UC --> Server is preparing data to respond the test request ...");
            string testResult = "Test result for client no. : ";
            if (rcvdStrUC.Contains("1"))
            {
                clientNumberUC = "1";
            }
            else if (rcvdStrUC.Contains("2"))
            {
                clientNumberUC = "2";
            }
            else
            {
                clientNumberUC = "Unknown";
            }
            TestResp sentStr = new TestResp();
            sentStr.Resp = testResult+ clientNumberUC;
            Console.WriteLine("UC --> Server sent the test response successfully ...");
            return Task.FromResult(sentStr);
        }

        public override async Task TestWorkServerStream(TestReq request, IServerStreamWriter<TestResp> responseStream, ServerCallContext context)
        {
            Console.WriteLine("SS --> Server received a test request ...");
            string rcvdStrSS = string.Empty;
            string clientNumberSS = string.Empty;
            rcvdStrSS = request.Req;
            Console.WriteLine($"SS --> Received message from the client: {rcvdStrSS}");

            Console.WriteLine("SS --> Server is responding with a stream of response messages ...");
            string testResult = "Test result for client no. : ";
            if (rcvdStrSS.Contains("1"))
            {
                clientNumberSS = "1";
            }
            else if (rcvdStrSS.Contains("2"))
            {
                clientNumberSS = "2";
            }
            else
            {
                clientNumberSS = "Unknown";
            }
            TestResp sentStr = new TestResp();
            sentStr.Resp = testResult + clientNumberSS;
            for (int i=0; i<10; i++)
            {
                await responseStream.WriteAsync(sentStr);
                await Task.Delay(1000);
            }
            Console.WriteLine("SS --> Server sent the test response successfully ...");
        }

        public override async Task<TestResp> TestWorkClientStream(IAsyncStreamReader<TestReq> requestStream, ServerCallContext context)
        {
            Console.WriteLine("CS --> Server is receiving a stream of test requests from the client ...");
            string rcvdStrCS = string.Empty;
            string clientNumberCS = string.Empty;
            string testResult = "Test result for client no. : ";
            await foreach(var request in requestStream.ReadAllAsync())
            {
                rcvdStrCS = request.Req;
                Console.WriteLine($"CS --> Received message from the client: {rcvdStrCS}");  
            }
            if (rcvdStrCS.Contains("1"))
            {
                clientNumberCS = "1";
            }
            else if (rcvdStrCS.Contains("2"))
            {
                clientNumberCS = "2";
            }
            else
            {
                clientNumberCS = "Unknown";
            }
            Console.WriteLine("CS --> Server is preparing data to respond the test request ...");
            TestResp sentStr = new TestResp();
            sentStr.Resp = testResult + clientNumberCS;

            Console.WriteLine("CS --> Server sent the test response successfully ...");
            Console.WriteLine("************************************************" + sentStr.Resp);
            return sentStr;
        }

        public override async Task TestWorkBidirectionalStream(IAsyncStreamReader<TestReq> requestStream, IServerStreamWriter<TestResp> responseStream, ServerCallContext context)
        {
            try
            {
                var ClientToServer = ClientToServerTask(requestStream, context);
                var ServerToClient = ServerToClientTask(responseStream, context);
                await Task.WhenAll(ClientToServer, ServerToClient);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
            }
        }

        private async Task ClientToServerTask(IAsyncStreamReader<TestReq> requestStream, ServerCallContext context)
        {
            Console.WriteLine("BS --> Server is receiving a stream of messages from the client ...");
            await foreach (var request in requestStream.ReadAllAsync())
            {
                Global.rcvdStrBS = request.Req;
                Console.WriteLine($"BS --> Received message from the client: {Global.rcvdStrBS}");
                if (Global.rcvdStrBS.Contains("1"))
                {
                    Global.clientNumberBS = "1";
                }
                else if (Global.rcvdStrBS.Contains("2"))
                {
                    Global.clientNumberBS = "2";
                }
                else
                {
                    Global.clientNumberBS = "Unknown";
                }
            }
        }

        private async Task ServerToClientTask(IServerStreamWriter<TestResp> responseStream, ServerCallContext context)
        {
            Console.WriteLine("BS --> Server is sending a stream of messages to the client ...");
            string testResult = "Test result for client no. : ";
            TestResp sentStr = new TestResp();
            sentStr.Resp = testResult+ Global.clientNumberBS;
            for (int i = 0; i < 15; i++)
            {
                await responseStream.WriteAsync(sentStr);
                await Task.Delay(1000);
            }
            Console.WriteLine("BS --> Server sent the test response successfully ...");
        }
    }
}
