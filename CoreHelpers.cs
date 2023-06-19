using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Bogus;
using OpenQA.Selenium;

namespace TesteProjeto
{
    public static class CoreHelpers
    {
        public static bool IsNatura => true;
        public static int TimeSpan => 60;
        public static int Pixels => 300;

        public static void ScrollVertical(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, {Pixels});");
        }
    }
}
