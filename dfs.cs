using System;
using System.Collections.Generic;
 

namespace DFS_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            dfsmodel dfsmodel = new dfsmodel();
            dfsmodel.GetMapper();
        }
    }

    class dfsmodel
    {
        Action<object> show = ((object x) => Console.WriteLine(x));
        private List<string> totallist = new List<string>();
        public void GetMapper()
        {
            //Sum Array
            decimal[] sumarr = { 50.00M, 75.00M, 100.00M, 140.00M };
            //Detail Array
            decimal[] detailarr = { 10.00M, 20.00M, 22.00M, 23.00M, 30.00M, 30.00M, 30.00M, 40.00M, 40.00M, 50.00M, 70.00M };
            List<List<decimal>> resultprint = new List<List<decimal>>();

            List<decimal> list = new List<decimal>();

            Array.Sort(detailarr);
            for (int j = 0; j < sumarr.Length; j++)
            { 
                    dfs(0, sumarr[j], resultprint, list, detailarr,sumarr[j]); 
            }
            totallist.ForEach((x) => Console.WriteLine(x));
        }



        private void dfs(int start, decimal target, List<List<decimal>> rt, List<decimal> cur, decimal[] detailarr,decimal orgtarget)
        {
            if (target == 0)
            { 
                totallist.Add(orgtarget + "===========================>" + string.Join(",", cur));
                rt.Add(new List<decimal>(cur));
                return;
            }

            for (int i = start; i < detailarr.Length; i++)
            { 
                if (detailarr[i] > target)
                {
                    return;
                }
                cur.Add(detailarr[i]);
                dfs(i + 1, target - detailarr[i], rt, cur, detailarr, orgtarget);
                cur.Remove(detailarr[i]);
            }
        }


    }
}
