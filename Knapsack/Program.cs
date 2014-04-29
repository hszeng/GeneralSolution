using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.Knapsack
{
    /// <summary>
    /// Project:Knapsack
    /// Author: Zeng Huansheng
    /// Email:andyzengsh@gmail.com 
    /// Date:2014/04/12
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            InitStates();
            int totalNumber = (States.Sum(s => s.TicketCount));
            if (totalNumber % 2 == 1)
                Console.WriteLine("No Possible to Equal!");
            int[,] Best = new int[States.Length + 1, totalNumber / 2 + 1];
            Console.WriteLine("Target is {0}.", totalNumber / 2);
            for (int i = 1; i <= States.Length - 1; i++)//
            {
                for (int j = 1; j <= totalNumber / 2; j++)
                {
                    if (j < States[i].TicketVolume)
                    {
                        Best[i, j] = Best[i - 1, j];
                    }
                    else
                    {
                        int tmp = Best[i - 1, j - States[i].TicketVolume] + States[i].TicketCount;
                        int tmp2 = Best[i - 1, j];
                        Best[i, j] = Math.Max(tmp, tmp2);
                    }
                }
            }
            Console.WriteLine("The best result for target {0} is {1}.", totalNumber / 2, Best[States.Length - 1, totalNumber / 2]);

            List<State> tmpStates = new List<State>();

            int lastMax = States.Length - 1;
            int lastTarget = totalNumber / 2;
            while (lastMax > 0 && lastTarget > 0 && Best[lastMax, lastTarget] > 0)
            {
                int currentMax = lastMax;
                for (int i = lastMax; i > 0; i--)
                {
                    if (Best[i, lastTarget] >= Best[lastMax, lastTarget])
                    { currentMax = i; }
                }

                if (lastMax >= currentMax)
                {
                    tmpStates.Add(States[currentMax]);
                    lastMax = currentMax;
                    lastTarget = lastTarget - States[currentMax].TicketCount;
                    lastMax--;
                }
                else
                {
                    tmpStates.Add(States[lastMax]);
                    lastTarget = lastTarget - States[lastMax].TicketVolume;
                    lastMax--;
                }
            }

            tmpStates.ForEach(s => { Console.WriteLine(s); });
            Console.WriteLine("TotalTickets:{0}", tmpStates.Sum(s => s.TicketCount));

            Console.ReadKey();
        }

        //Remember:i And v are both dynamic values.
        //F(i,v)=f(i-1,v) ,At this condition ,the number i thing's volume is biggger than the v
        //or
        //F(i,v)=Max{F(i-1,v),F(i-1,v-C(i))+W(i)},pick the biggest/best result


        private static State[] States;
        private static void InitStates()
        {
            var states = baseData.Split(',');
            States = new State[states.Length + 1];
            States[0] = new State() { Name = string.Empty, TicketCount = 0 };
            for (int i = 1; i <= states.Length; i++)
            {
                var tmpStrings = states[i - 1].Split(':');
                States[i] = new State() { Name = tmpStrings[0].Trim(), TicketCount = int.Parse(tmpStrings[1]) };
            }
        }
        #region baseData
        private const string
                    baseData = @"
                                阿拉巴马州:9,
                                阿拉斯加州:3,
                                亚利桑那州:10,
                                阿肯色州:6,
                                加利福尼亚州:55,
                                科罗拉多州:9,
                                康涅狄格州:7,
                                特拉华州:3,
                                哥伦比亚特区:3,
                                佛罗里达州:27,
                                乔治亚州:15,
                                夏威夷州:4,
                                爱达荷州:4,
                                伊利诺伊州:21,
                                印第安那州:11,
                                艾奥瓦州:7,
                                堪萨斯州:6,
                                肯塔基州:8,
                                路易斯安那州:9,
                                缅因州:4,
                                马里兰州:10,
                                马萨诸塞州:12,
                                密歇根州:17,
                                明尼苏达州:10,
                                密西西比州:6,
                                密苏里州:11,
                                蒙达拿州:3,
                                内布拉斯加州:5,
                                内华达州:5,
                                新罕布什尔州:4,
                                新泽西州:15,
                                新墨西哥州:5,
                                纽约州:31,
                                北卡罗来纳州:15,
                                北达科他州:3,
                                俄亥俄州:20,
                                俄克拉荷马州:7,
                                俄勒岗州:7,
                                宾夕法尼亚州:21,
                                罗德岛州:4,
                                南卡罗来纳州:8,
                                南达科达州:3,
                                田纳西州:11,
                                德克萨斯州:34,
                                犹他州:5,
                                蒙大拿州:3,
                                维吉尼亚州:13,
                                华盛顿州:11,
                                西维吉尼亚州:5,
                                威斯康辛州:10,
                                怀俄明州:3";
        #endregion
    }
    class State
    {
        public string Name { get; set; }
        public int TicketCount { get; set; }
        //In this issue , the Volume property is to simulate the Volume property from the Package Algorithm.
        public int TicketVolume { get { return TicketCount; } }
        public override string ToString()
        {
            return string.Format("{0}:{1}", Name, TicketCount);
        }
    }
}
