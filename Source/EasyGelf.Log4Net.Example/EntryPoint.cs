using System;
using System.IO;
using System.Threading;
using log4net;
using log4net.Config;

namespace EasyGelf.Log4Net.Example
{
    public static class EntryPoint
    {
        private static readonly ILog Log = LogManager.GetLogger("ExampleLog");

        public static void Main()
        {
            ConfigureLogging();
            var cancelationTokenSource = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, eventArgs) => cancelationTokenSource.Cancel();
            //while (!cancelationTokenSource.IsCancellationRequested)
            //{
            //    Log.Info("I'm alive. This is the test log for easy gelf");
            //    Thread.Sleep(TimeSpan.FromSeconds(0.5));
            //}

			for (int i = 0; i < 10000; i++)
			{
				Log.Info("I'm alive. This is the test log for easy gelf i="+i + ". my local time is:"+ DateTime.Now);

		//		To generate windows event here
		//	   System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog();
		//appLog.Source = "Log generator application";
		//		appLog.WriteEntry("An entry to the Application event log. An entry to the Application event log. An entry to the Application event log.An entry to the Application event log.An entry to the Application event log.An entry to the Application event log. An entry to the Application event log. An entry to the Application event log.An entry to the Application event log.lkjflsdkjflsdkjfsdöfsdfjsldkfjsöldfkjsdölkfjsdölfkjsdlfkjsdölfkjsdölfkjsdöflksdjfölsdkfjsdölkfjsdölkfjsdlökfjsdlökfjsödlkfjsöldkjfsldökjfsdöl" + Environment.NewLine + "ölskdjfljsdöljölsdkjfölsdkjflöksdjfölsdfsdfdsfdjfsdlkjfölskdjfljsdöljölsdkjfölsdkjflöksdjfölsdfsdfdsfdjfsdlkjfölskdjfljsdöljölsdkjfölsdkjflöksdjfölsdfsdfdsfdjfsdlkjfölskdjfljsdöljölsdkjfölsdkjflöksdjfölsdfsdfdsfdjfsdlkjfölskdjfljsdöljölsdkjfölsdkjflöksdjfölsdfsdfdsfdjfsdlkjfölskdjfljsdöljölsdkjfölsdkjflöksdjfölsdfsdfdsfdjfsdlkjfölskdjfljsdöljölsdkjfölsdkjflöksdjfölsdfsdfdsfdjfsdlkjfölskdjfljsdöljölsdkjfölsdkjflöksdjfölsdfsdfdsfdjfsdlkjfölskdjfljsdöljölsdkjfölsdkjflöksdjfölsdfsdfdsfdjfsdlkjfölskdjfljsdöljölsdkjfölsdkjflöksdjfölsdfsdfdsfdjfsdlkjfölskdjfljsdöljölsdkjfölsdkjflöksdjfölsdfsdfdsfdjfsdlkjf");


				Thread.Sleep(TimeSpan.FromSeconds(3));
			}
        }

        private static void ConfigureLogging()
        {
            var fileInfo = new FileInfo("log4net.config");
            if (!fileInfo.Exists)
                throw new Exception();
            XmlConfigurator.Configure(fileInfo);
        }
    }
}
