using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AutoDataReader.ApiClients;
using AutoDataReader.Entities;
using AutoDataReader.Helpers;
using AutoDataReader.Service.Contracts;

namespace AutoDataReader
{
    public class Program
    {
        private static IWordService _service;
        static readonly ApiWordClient _api = new ApiWordClient();

        public static void Main(string[] args)
        {
            _service = WordServiceHelper.GetService();
            CleanLocalDataBase();
            PopulateDataBase();
            CheckForNewData();
            GetDateFromApi();


            Console.WriteLine("Finished!");
            Console.ReadKey();
        }

        private static void GetDateFromApi()
        {
            var result = _api.GetAll();

            if (result.Count == 0)
                return;

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Getting all data from API...");
            Console.WriteLine(Environment.NewLine);

            foreach (var word in result)
            {
                Console.WriteLine($"Word: {word.Name} created date: {word.CreatedDate} in Web Api successfully!");
            }
        }

        private static void CheckForNewData()
        {
            var deadLine = DateTime.Now.AddMinutes(1);
            var doIt = DateTime.Now;
            IEnumerable<Word> wordList;

            do
            {
                wordList = _service.GetAll().Where(x => x.CreatedDate <= DateTime.Now);

                if (wordList.Count() == 0)
                    Thread.Sleep(2000);

                foreach (var word in wordList)
                {
                    CreateWordApi(word);
                    _service.Delete(word);
                }

            } while (DateTime.Now <= deadLine);
        }

        private static void PopulateDataBase()
        {
            var wordList = new List<Word>
            {
                new Word {Name = "Frog"},
                new Word {Name = "Cat"},
                new Word {Name = "Bird"},
                new Word {Name = "Mouse"},
                new Word {Name = "Fish"},
                new Word {Name = "Cheese"},
                new Word {Name = "Lemon"},
                new Word {Name = "Orange"},
                new Word {Name = "Pineapple"},
                new Word {Name = "Banana"},
                new Word {Name = "Airplane"},
                new Word {Name = "Car"},
                new Word {Name = "Bus"},
                new Word {Name = "Bike"},
                new Word {Name = "Flashdrive"},

            };

            foreach (var word in wordList)
            {
                _service.Create(word);
            }

            var words = _service.GetAll();
            var addTime = DateTime.Now;

            foreach (var word in words)
            {
                addTime = addTime.AddSeconds(4);
                word.CreatedDate = addTime;
                _service.Update(word);
            }
        }

        private static void CleanLocalDataBase()
        {
            var oldWords = _service.GetAll();

            if(oldWords != null)
            {
                foreach (var word in oldWords)
                {
                    _service.Delete(word);
                }
            }
        }

        private static void CreateWordApi(Word word)
        {
            //var api = new ApiWordClient();
            var response = _api.Create(word);

            if (response.IsSuccessStatusCode)
                Console.WriteLine($"Word: {word.Name} sent successfully to API at {DateTime.Now}");
            else
                Console.WriteLine($"Something went wrong!");
        }


        #region Tests
        private void DoSomething()
        {
            var teste = new ApiWordClient();
            var result0 = teste.Get(3);
            var result1 = teste.GetAll();

        }

        static void TestSomething()
        {

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
        #endregion
    }
}
