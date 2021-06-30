using System;
using System.Configuration;
namespace ConsoleApplication1
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://one-sthead.hatenablog.com/entry/2019/05/09/011909
    /// https://stackoverflow.com/questions/9486087/how-to-mock-configurationmanager-appsettings-with-moq
    /// </remarks>
    public class ConfigurationWrapper : IConfiguration
    {
        public string User() => ConfigurationManager.AppSettings["hoge"];
    }
}