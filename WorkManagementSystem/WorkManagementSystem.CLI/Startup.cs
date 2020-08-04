using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common;

namespace WorkManagementSystem.CLI
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            //var engine = new Engine();
            //engine.Run();
            //Console.SetWindowSize(70, 70);

            var list = new List<Feedback>();

            var fb1 = new Feedback("my Title is long I promise", "a random fb, descr should be 10 symb", 8);
            var fb2 = new Feedback("my Title2 it really is", "now thfffffffffffffdis is a test, kjdsfsddfdsfkjxhkjsidjssisnmmmmmmmmmmjksihsjkbgngngfnbfgnb fgnfnfnfghsukshkjsa siuhsja ssjhksh", 10);
            var fb3 = new Feedback("mini title - obc not", "spi mi se", 1);
            var fb4 = new Feedback("idk anymore, mini title #2 I guess", "ama i na men mi sa spi chast 2", 5);
            list.Add(fb1);
            list.Add(fb2);
            list.Add(fb3);
            list.Add(fb4);



            /*IEnumerable<Tuple<int, string, string>> authors =
                new[]
                {
                  Tuple.Create(1, "Isaac", "Asimov"),
                  Tuple.Create(2, "Robert", "Heinlein"),
                  Tuple.Create(3, "Frank", "Herbert"),
                  Tuple.Create(4, "Aldous", "Huxley"),
                };*/
            Console.WriteLine();

            // Way 1
            Console.WriteLine(list.ToStringTable(
              new[] { "Title", "Description", "Rating*" },
              a => a.Title, a => a.Description, a => a.Rating));

            // Way 2 - test it
            var arrtest = list.ToArray();

            // Way 2.2 - test it with tring arr[]

            // Way 3
            var arr = new string[,] { { "Title", "Description" }, { "Description", "Rating*" }, { "Title", "Rating*" } };

            Console.WriteLine(arr.ToStringTable());








/*
            *//*//Setting a Stopwatch 
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //delay
            Console.ReadLine();

            //Stopping a Stopwatch
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            *//*

            //var ah = new ActivityHistory("hahah");

            try
            {
                //Board b = new Board("as");
                //Feedback f = new Feedback("sjndssdgdfgd", "sfsvsdfsdvfsj", 50);
                //var ah = new ActivityHistory("hahah");
                //var b = new Bug("sjsadasdasdasda", "ssadasdasdasdasdad");
                //var m = new Member("asdvdffdg");
                //var s = new Story("asdsasfadafdas", "asdfdsfsdfsdfdafd");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("Hello World!");*/

        }
    }
}
