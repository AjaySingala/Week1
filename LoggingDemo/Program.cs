using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LoggingDemo
{
    class Program
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
        // System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly log4net.ILog log = 
            log4net.LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            // Configure log4net.
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));

            var repo = log4net.LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), 
                typeof(log4net.Repository.Hierarchy.Hierarchy)
            );

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

            // Start using logger.
            log.Debug("This is a Debug log.");
            log.Info("This is an Information log.");
            log.Warn("This is Warning log.");
            log.Error("This is an Error log.");
            log.Fatal("This is a Fatal log.");

            MethodA();
            
            Console.WriteLine("Press <ENTER>...");
            Console.ReadLine();
        }

        static void MethodA()
        {
            // TRACE LOG.
            log.Debug("BEGIN MethodA()");
            // some code.
            MethodB("some string");
            log.Debug("END MethodA()");
        }

        static void MethodB(string message)
        {
            log.Debug($"BEGIN MethodB({message})");
            // some code.
            MethodC(125);
            log.Debug($"END MethodB({message})");
        }

        static void MethodC(int number)
        {
            log.Debug($"BEGIN MethodC({number})");
            // some code.
            try
            {
                throw new Exception("To test error logging and tracing.");
            }
            catch(Exception ex)
            {
                log.Error("ERROR!!", ex);
            }
            log.Debug($"END MethodC({number})");
        }
    }
}
