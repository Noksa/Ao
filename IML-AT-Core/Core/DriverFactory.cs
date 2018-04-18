﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace IML_AT_Core.Core
{
    public abstract class DriverFactory
    {

        private static ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();





        public static IWebDriver GetDriver()

        {

            if (!_driver.IsValueCreated)
                throw new NullReferenceException(
                    "Драйвер не был инициализирован. Проинициализируйте драйвер перед его использованием, путём вызова метода DriverFactory.InitDriver(driverType)");

            return _driver.Value;

        }



        public static void InitDriver(string driverType)

        {

            switch (driverType.ToLower())

            {

                case "chrome":

                    _driver.Value = new ChromeDriver();

                    break;

                case "firefox":

                    _driver.Value = new FirefoxDriver();

                    break;

                case "ie":

                    _driver.Value = new InternetExplorerDriver();

                    break;

                default:

                    throw new ArgumentNullException("Неизвестный тип драйвера \"" + driverType +
                                                    "\". Невозможно проинициализировать драйвер.");

            }

            _driver.Value.Manage().Window.Maximize();

            _driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        public static void Dispose()

        {
            if (_driver.Value == null && _driver == null) return;
            _driver.Value.Close();

            _driver.Value = null;

            _driver.Dispose();

            _driver = null;
        }





    }


}