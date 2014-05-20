using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services;
using System.ServiceModel;

namespace ConsoleBookServiceHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            //实例化ServiceHost服务承载器，并在构造函数中指定要发布的BookService
            ServiceHost host = new ServiceHost(typeof(BookService));
            //打开服务承载器，读取配置文件中的WCF服务的配置信息
            host.Open();
            Console.WriteLine("服务已启动......");
            Console.ReadLine();
            host.Close();
        }
    }
}
