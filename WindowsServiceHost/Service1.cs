using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;
using Services;

namespace WindowsServiceHost
{
    public partial class BookServiceHost : ServiceBase
    {
        private ServiceHost host = new ServiceHost(typeof(BookService));
        public BookServiceHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            host.Open();
        }

        protected override void OnStop()
        {
            host.Close();
        }
    }
}
