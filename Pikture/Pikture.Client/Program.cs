using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Pikture.Client
{
  class Program
  {
    async static Task Main(string[] args)
    {
      await RestApiAsync(); // run 0 - promise 0
      System.Console.WriteLine("END OF FILE"); // run 2 - execute, sync
      Console.ReadLine(); // run 3 - execute, sync

      // run 4 - promise 0 - execute, run 0

      // line 12 not finsihed
      // line 13 finished  - not executed
      // line 13 finshed - not executed
      // check all non-finished work
      // line 12 finished  - executed
      // line 13 - executed
      // line 14 - executed

      // var t1 = new Thread(() => { RestApiAsync(); });
      // var t2 = new Thread(() => System.Console.WriteLine("ENd OF FILE"));
      // var t3 = new Thread(() => Console.ReadLine());

      // t1.Start();
      // if (!t1.IsAlive && t1.ThreadState.HasFlag(ThreadState.Stopped))
      // {
      //   t2.Start();
      //   if (!t2.IsAlive)
      //   {
      //     t3.Start();
      //   }
      // }
    }

    async static Task RestApiAsync()
    {
      var http = new HttpClient();

      var response = http.GetAsync("http://localhost:5000/api/image").GetAwaiter().GetResult();
      var response2 = await http.GetAsync("http://localhost:5000/api/image");
      
      if (response2.StatusCode == HttpStatusCode.OK)
      {
        System.Console.WriteLine(await response.Content.ReadAsStringAsync());
      }
      else
      {
        System.Console.WriteLine($"Error: {await response.Content.ReadAsStringAsync()}");
      }
      

    }
  }
}
