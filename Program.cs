using Newtonsoft.Json;
using System;

namespace set_aws_headers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a url do endpoint: ");

            var url = Console.ReadLine();

            Console.WriteLine("Digite o método: ");

            var method = Console.ReadLine();

            Console.WriteLine("Digite os headers (separar por vírgula): ");

            var header = Console.ReadLine();
            var headers = header.Split(',');

            Console.WriteLine("Digite as querystrings (separar por vírgula): ");

            var querystring = Console.ReadLine();
            var querystrings = header.Split(',');

            Console.WriteLine("Digite o nome do autorizador (separar por vírgula): ");

            var authorizer = Console.ReadLine();
            var authorizers = authorizer.Split(',');
            var result = AmazonParametersFactory.Create(url, method, headers, querystrings, authorizers);
            var jsonResult = JsonConvert.SerializeObject(result);

            Console.WriteLine(jsonResult);

            Console.ReadKey();
        }
    }
}
