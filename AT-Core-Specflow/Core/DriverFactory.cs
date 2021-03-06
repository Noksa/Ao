﻿using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.Extensions;
using Allure.Commons;

namespace AT_Core_Specflow.Core
{
    public abstract class DriverFactory
    {
        private static readonly ThreadLocal<IWebDriver> Driver = new ThreadLocal<IWebDriver>();
        public static IWebDriver GetDriver()
        {
            if (!Driver.IsValueCreated)
                throw new NullReferenceException(
                    "Драйвер не был инициализирован. Проинициализируйте драйвер перед его использованием, путём вызова метода DriverFactory.InitDriver(driverType)");
            return Driver.Value;
        }

        public static IWebElement BodyElement => GetDriver().FindElement(By.TagName("body"));

        public static void InitDriver(Browser browserType)
        {
            switch (browserType)
            {
                case Browser.Chrome:
                    Driver.Value = new ChromeDriver();
                    break;
                case Browser.Firefox:
                    Driver.Value = new FirefoxDriver();
                    break;
                case Browser.Ie:
                    Driver.Value = new InternetExplorerDriver();
                    break;
                case Browser.Safari:
                    Driver.Value = new SafariDriver();
                    break;
                case Browser.Opera:
                    Driver.Value = new OperaDriver();
                    break;
                default:
                    throw new ArgumentNullException($"Неизвестный тип драйвера \"{browserType}\". Невозможно проинициализировать драйвер.");
            }
            Driver.Value.Manage().Window.Maximize();
        }


        public static void Dispose()
        {
            if (Driver.Value == null) return;
            Driver.Value.Quit();
            Driver.Value = null;
        }

        public static void MakeScreenshot()
        {
            AllureLifecycle.Instance.AddAttachment($"Screenshot {Guid.NewGuid()}", "image/png",
                GetDriver().TakeScreenshot().AsByteArray, ".png");
        }
    }
}