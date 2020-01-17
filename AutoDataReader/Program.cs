using System;
using AutoDataReader.Entities;
using AutoDataReader.Helpers;
using AutoDataReader.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace AutoDataReader
{
    public class Program
    {
        private static IWordService _service;

        static void Main(string[] args)
        {
            DoSomething();
            Console.ReadKey();
        }

        static void DoSomething()
        {
            _service = WordServiceHelper.GetService();
            //var word = new Word
            //{
            //    Name = "Test"
            //};

            //var allRegisters = _service.GetAll();
            //_service.Create(word);
            var result = _service.Get(1);
            Console.WriteLine($"Resultado: {result.Name} ");
        }
    }
}
