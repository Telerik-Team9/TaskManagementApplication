using System;
using WorkManagementSystem.Core;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;

namespace WorkManagementSystem.CLI
{
    public class Startup
    {
        private readonly static IInstanceFactory instanceFactory = new InstanceFactory();
        private readonly static IEngine engine = new Engine(instanceFactory);

        public static void Main()
        {
            //Console.SetWindowSize(70, 70);


            engine.Run();




            /*
                        // Comments
                        var magi = new Member("Magi Nikolova");
                        var cmt1 = new Comment("komentar1", magi);
                        var ali = new Member("Aliiiiii");
                        var cmt2 = new Comment("komentar2", ali);
                        var radko = new Member("Radko mentor");
                        var cmt3 = new Comment("komentar 3", radko);
                        var comments = new List<IComment>();
                        comments.Add(cmt1);
                        comments.Add(cmt2);
                        comments.Add(cmt3);



                        var list = new List<Feedback>();

                        var fb1 = new Feedback("my Title is long I promise", "a random fb, descr should be 10 symb", 8);
                        var fb2 = new Feedback("my Title2 it really is", "now thfffffffffffffdis is a test, siuhsja ssjhksh", 10);
                        var fb3 = new Feedback("mini title - obc not", "spi mi seeeeeeeeeeeeeeeee", 1);
                        var fb4 = new Feedback("idk anymore, mini title #2 I guess", "ama i na men mi sa spi chast 2", 5);
                        list.Add(fb1);
                        list.Add(fb2);
                        list.Add(fb3);
                        list.Add(fb4);

                        // History
                        List<string> hist = new List<string>() { "history 1", "history 2" };


                        //var bs = BugSeverity.Critical;

                        var bug = new Bug("Titleeeeeee bug", "Descriptiooooon" *//*severity = BugSeverity.Critical*//*);
                        bug.AddComments(comments);
                        bug.AddHistory(hist);
                        Console.WriteLine("THIS IS BUG INFO: " + bug.PrintInfo());
                        Console.WriteLine("-----------------------------");

                        var story = new Story("Story title", "Story descriptions");
                        //story.AddComments(comments);
                        //story.AddHistory(hist);
                        Console.WriteLine("THIS IS STORY INFO: " + story.PrintInfo());
                        Console.WriteLine("-----------------------------");

                        // fix newline
                        var feedback = new Feedback("Titleeeeeee for fb", "feeeeeeeeeeeeeeeeedback descr", 5);
                        //feedback.AddComments(comments);
                        feedback.AddHistory(hist);
                        Console.WriteLine("THIS IS FEEDBACK INFO: " + feedback.PrintInfo());
                        Console.WriteLine("-----------------------------");


            */





            /*IEnumerable<Tuple<int, string, string>> authors =
                new[]
                {
                  Tuple.Create(1, "Isaac", "Asimov"),
                  Tuple.Create(2, "Robert", "Heinlein"),
                  Tuple.Create(3, "Frank", "Herbert"),
                  Tuple.Create(4, "Aldous", "Huxley"),
                };*/

            /*
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

            */






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
