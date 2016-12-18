using System;
using System.Net;
using System.Web.Services;
using System.Web.Services.Protocols;
using DictServiceSample.com.aonaware.services;
using NConsoler;

namespace DictServiceSample
{
	/// <summary>
	/// The main class
	/// </summary>
	class MainClass
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Consolery.Run(typeof(MainClass), args);
		}

        private static void SetupProxyServer(HttpWebClientProtocol ws, string proxyUrl, string user, string password, string domain)
        {
            if (!String.IsNullOrEmpty(proxyUrl))
            {
                WebProxy wp = new WebProxy();
                Uri uri = new Uri(proxyUrl);
                wp.Address = uri;

                if (!String.IsNullOrEmpty(user) || !String.IsNullOrEmpty(password) || !String.IsNullOrEmpty(domain))
                {
                    NetworkCredential credentials = new NetworkCredential(user, password, domain);
                    wp.Credentials = credentials;
                }

                ws.Proxy = wp;
            }
        }

        [Action]
        public static void DictionaryList(
            [Optional("", Description = "The url of the proxy server to use for http requests")] string proxy,
            [Optional("", Description = "The user name to use when the connecting to a proxy server that requires authentication")] string proxyusername,
            [Optional("", Description = "The password to use when the connecting to a proxy server that requires authentication")] string proxypassword,
            [Optional("", Description = "The domain to use when the connecting to a proxy server that requires authentication")] string proxydomain
            )
        {
            try
            {
                DictService svc = new DictService();
                SetupProxyServer(svc, proxy, proxyusername, proxypassword, proxydomain);
                Dictionary[] dicts = svc.DictionaryList();
                foreach (Dictionary d in dicts)
                {
                    Console.WriteLine("{0} : {1}", d.Id, d.Name);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

		[Action]
		public static void Define(
			[Required(Description="Word to define")] string word,
            [Optional("", Description = "Dictionary identifier")] string dict,
            [Optional("", Description = "The url of the proxy server to use for http requests")] string proxy,
            [Optional("", Description = "The user name to use when the connecting to a proxy server that requires authentication")] string proxyusername,
            [Optional("", Description = "The password to use when the connecting to a proxy server that requires authentication")] string proxypassword,
            [Optional("", Description = "The domain to use when the connecting to a proxy server that requires authentication")] string proxydomain
            )
		{
			try
			{
                DictService svc = new DictService();
                SetupProxyServer(svc, proxy, proxyusername, proxypassword, proxydomain);
				WordDefinition wd;
                if (String.IsNullOrEmpty(dict))
                    wd = svc.Define(word);
                else
                    wd = svc.DefineInDict(dict, word);

                if (wd.Definitions.Length == 0)
                {
                    Console.WriteLine("No definitions for {0} found.", word);
                    return;
                }

                foreach (Definition d in wd.Definitions)
                {
                    Console.WriteLine("From {0}:", d.Dictionary.Name);
                    Console.WriteLine(d.WordDefinition);
                    Console.WriteLine();
                }
			}
			catch (System.Exception e)
			{
				Console.WriteLine("Error: {0}", e.Message);
			}
		}

        [Action]
        public static void ServerInfo(
            [Optional("", Description = "The url of the proxy server to use for http requests")] string proxy,
            [Optional("", Description = "The user name to use when the connecting to a proxy server that requires authentication")] string proxyusername,
            [Optional("", Description = "The password to use when the connecting to a proxy server that requires authentication")] string proxypassword,
            [Optional("", Description = "The domain to use when the connecting to a proxy server that requires authentication")] string proxydomain
            )
        {
            try
            {
                DictService svc = new DictService();
                SetupProxyServer(svc, proxy, proxyusername, proxypassword, proxydomain);
                Console.WriteLine(svc.ServerInfo());
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        [Action]
        public static void DictionaryInfo(
            [Required(Description = "Dictionary identifier")] string dict,
            [Optional("", Description = "The url of the proxy server to use for http requests")] string proxy,
            [Optional("", Description = "The user name to use when the connecting to a proxy server that requires authentication")] string proxyusername,
            [Optional("", Description = "The password to use when the connecting to a proxy server that requires authentication")] string proxypassword,
            [Optional("", Description = "The domain to use when the connecting to a proxy server that requires authentication")] string proxydomain
            )
        {
            try
            {
                DictService svc = new DictService();
                SetupProxyServer(svc, proxy, proxyusername, proxypassword, proxydomain);
                Console.WriteLine(svc.DictionaryInfo(dict));
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        [Action]
        public static void StrategyList(
            [Optional("", Description = "The url of the proxy server to use for http requests")] string proxy,
            [Optional("", Description = "The user name to use when the connecting to a proxy server that requires authentication")] string proxyusername,
            [Optional("", Description = "The password to use when the connecting to a proxy server that requires authentication")] string proxypassword,
            [Optional("", Description = "The domain to use when the connecting to a proxy server that requires authentication")] string proxydomain
            )
        {
            try
            {
                DictService svc = new DictService();
                SetupProxyServer(svc, proxy, proxyusername, proxypassword, proxydomain);
                Strategy[] strats = svc.StrategyList();
                foreach (Strategy s in strats)
                {
                    Console.WriteLine("{0} : {1}", s.Id, s.Description);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        [Action]
        public static void Match(
            [Required(Description = "Word to match")] string word,
            [Required(Description = "Strategy identifier")] string strategy,
            [Optional("", Description = "Dictionary identifier")] string dict,
            [Optional("", Description = "The url of the proxy server to use for http requests")] string proxy,
            [Optional("", Description = "The user name to use when the connecting to a proxy server that requires authentication")] string proxyusername,
            [Optional("", Description = "The password to use when the connecting to a proxy server that requires authentication")] string proxypassword,
            [Optional("", Description = "The domain to use when the connecting to a proxy server that requires authentication")] string proxydomain
            )
        {
            try
            {
                DictService svc = new DictService();
                SetupProxyServer(svc, proxy, proxyusername, proxypassword, proxydomain);

                DictionaryWord[] words;
                if (String.IsNullOrEmpty(dict))
                    words = svc.Match(word, strategy);
                else
                    words = svc.MatchInDict(dict, word, strategy);

                foreach (DictionaryWord w in words)
                {
                    Console.WriteLine("{0} : {1}", w.DictionaryId, w.Word);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
	}
}
