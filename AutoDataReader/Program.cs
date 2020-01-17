using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AutoDataReader.Entities;
using AutoDataReader.Helpers;
using AutoDataReader.Service.Contracts;

namespace AutoDataReader
{
    public class Program
    {
        private static IWordService _service;

        public static void Main(string[] args)
        {
            _service = WordServiceHelper.GetService();
            TestSomething();
            Console.WriteLine("Finished!");
            Console.ReadKey();
        }

        static void TestSomething()
        {
            var wordList = new List<Word>
            {
                new Word {Name = "Frog"},
                new Word {Name = "Cat"},
                new Word {Name = "Bird"},
                new Word {Name = "Mouse"},
                new Word {Name = "Fish"},
                new Word {Name = "Chesse"},
                new Word {Name = "Beer"},
                new Word {Name = "Brazil"},
                new Word {Name = "House"},
                new Word {Name = "Laptop"},
                new Word {Name = "Flashdrive"},
                new Word {Name = "Lemon"},
                new Word {Name = "Orange"},
                new Word {Name = "Grepe"},
                new Word {Name = "Pineapple"},
                new Word {Name = "Banana"},
                new Word {Name = "Airplane"},
                new Word {Name = "Car"},
                new Word {Name = "Bus"},
                new Word {Name = "Bike"},

            };

            //foreach (var item in results.Words)
            //{
            //    _service.Delete(item.Id);
            //}

            //foreach (var word in wordList)
            //{
            //    _service.Create(word);
            //}

            //DateTime doIt = DateTime.Now.AddSeconds(2);

            //foreach (var word in wordList)
            //{
            //    if (DateTime.Now >= doIt)
            //    {
            //        //_service.Create(word);
            //        Console.WriteLine($"Palavra: {word.Name} em: {doIt}");
            //        doIt = doIt.AddSeconds(2);
            //    }
            //    Thread.Sleep(2000);
            //}

            var result = _service.GetAll();

            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
