using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1451
{

    class Program
    {
        static void Main(string[] args)
        {
			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;

            TwitterUser donald = new TwitterUser("donald");
            donald.Post_a_Message("Всем добра!");

            TwitterUser vladimir = new TwitterUser("vladimir");
            donald.Post += vladimir.Feed;

            donald.Post_a_Message("Всем успехов!");

            TwitterUser ivan = new TwitterUser("ivan");
            donald.Post += ivan.Feed;

            donald.Post_a_Message("Всем процветания!");

            TwitterUser denis = new TwitterUser("denis");
            donald.Post += denis.Feed;

            donald.Post_a_Message("Всем C#!", new Image(), new Document(), new Audio());


            vladimir.Post += donald.Feed;
            vladimir.Post_a_Message("Ку-ку");

        }
    }
}
