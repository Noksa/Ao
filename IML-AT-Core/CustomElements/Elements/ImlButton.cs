﻿using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace IML_AT_Core.CustomElements.Elements
{
    public class ImlButton : CustomElement
    {
        public ImlButton(IElementLocator locator, IEnumerable<By> bys, bool cache, string elementTitle) : base(locator, bys, cache, elementTitle)
        {
        }
    }
}