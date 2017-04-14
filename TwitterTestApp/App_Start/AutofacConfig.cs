using Autofac;
using Autofac.Integration.Mvc;
using NLog;
using System;
using System.Configuration;
using System.Web.Mvc;
using TwitterTestApp.Services;

namespace TwitterTestApp
{
    public class AutofacConfig
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public static IContainer Register()
        {
            var assembly = typeof(MvcApplication).Assembly;
            var builder = new ContainerBuilder();

            builder.RegisterControllers(assembly);
            RegisterTypes(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
            return container;
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            var twitterConfig = LoadTwitterConfig();
            builder.RegisterInstance(twitterConfig);

            var twitterSearchConfig = LoadTwitterSearchConfig();
            builder.RegisterInstance(twitterSearchConfig);

            builder.RegisterType<TwitterService>();

            var objectMapper = ObjectMapperConfig.Create();
            builder.RegisterInstance(objectMapper);
        }

        private static TwitterConfig LoadTwitterConfig()
        {
            string key = ConfigurationManager.AppSettings["ConsumerKey"];
            string secret = ConfigurationManager.AppSettings["ConsumerSecret"];

            return new TwitterConfig(key, secret);
        }

        private static TwitterSearchConfig LoadTwitterSearchConfig()
        {
            string hashTag = ConfigurationManager.AppSettings["HashTag"];
            string twitsCountString = ConfigurationManager.AppSettings["TwitsCount"];

            int twitsCount;
            if (!int.TryParse(twitsCountString, out twitsCount))
            {
                throw new Exception(string.Format("Cannot parse TwitsCount, {0} is not correct value", twitsCountString));
            }

            logger.Info("TwitterSearchConfig loaded: hashtag = {0}, twitsCount = {1}", hashTag, twitsCount);

            return new TwitterSearchConfig(hashTag, twitsCount);
        }
    }
}
