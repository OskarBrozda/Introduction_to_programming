using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace LogsAggregate
{
    class Logs
    {     
        static void Main(string[] args)
        {            
            int k = int.Parse(Console.ReadLine());            
            SortedDictionary <string,valueDictData> data = new SortedDictionary<string,valueDictData>();            
            for (int i = 0; i < k; i++)
            {               
                var input = Console.ReadLine().Split(' ');
                string ip = input[0];
                string name = input[1];
                int duration = int.Parse(input[2]);

                if (!data.ContainsKey(name))
                {
                    data[name] = new valueDictData
                    {
                        ipLogs = new SortedSet<string>() { ip },
                        duration = duration
                    };
                }
                else
                {
                    data[name].ipLogs.Add(ip);
                    data[name].duration += duration;
                }
            
            }
                        
            //wypisanie            
            foreach (KeyValuePair<string, valueDictData> kvp in data)
            {                     
                Console.WriteLine($"{kvp.Key}: {kvp.Value.duration} [{string.Join(", ", kvp.Value.ipLogs)}]");
            }
        }       
    }

    class valueDictData
    {
        public SortedSet<string> ipLogs;
        public int duration;
    }
}



//test
/*
7
192.168.0.11 peter 33
10.10.17.33 alex 12
10.10.17.35 peter 30
10.10.17.34 peter 120
10.10.17.34 peter 120
212.50.118.81 alex 46
212.50.118.81 alex 4
*/
