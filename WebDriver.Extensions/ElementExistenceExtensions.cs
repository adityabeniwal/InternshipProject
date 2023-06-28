using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebDriver.Extensions
{
    public static class ElementExistenceExtensions
    {
        /// <summary>
        ///     Tries to find an element inside a "search context". e.g. webPage, other webElement, etc...
        /// </summary>
        /// <param name="searchContext">"search context". e.g. webPage, other webElement, etc...</param>
        /// <param name="by">Element locator instance.</param>
        /// <returns>WebElement instance if element present of page, otherwise null.</returns>
        public static IWebElement SafeFindElement(this ISearchContext searchContext, By by)
        {
            try
            {
                return searchContext.FindElement(by);
            }
            catch (ElementNotVisibleException)
            {
                return null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (TargetInvocationException)
            {
                return null;
            }
            catch (NoSuchWindowException)
            {
                return null;
            }
        }

        public static ReadOnlyCollection<IWebElement> SafeFindElements(this ISearchContext searchContext, By by)
        {
            try
            {
                return searchContext.FindElements(by);
            }
            catch (ElementNotVisibleException)
            {
                return null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (TargetInvocationException)
            {
                return null;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        /// <summary>
        ///     Checks in a web element exist on a page.
        /// </summary>
        /// <param name="driver">Selenium WebDriver instance</param>
        /// <param name="by">Element locator instance.</param>
        /// <returns>True if element is present, otherwise false.</returns>
        public static bool HasElement(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);

                return true;
            }
            catch (ElementNotVisibleException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public static bool HasElement(this IWebDriver driver, IWebElement element)
        {
            try
            {
                element.GetAttribute("class");

                return true;
            }
            catch (ElementNotVisibleException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        ///     Checks in a web element exist inside a given search context.
        /// </summary>
        /// <param name="searchContext">"search context". e.g. webPage, other webElement, etc...</param>
        /// <param name="by">Element locator instance.</param>
        /// <returns>True if element is present, otherwise false.</returns>
        public static bool HasElement(this ISearchContext el, By by)
        {
            try
            {
                el.FindElement(by);

                return true;
            }
            catch (ElementNotVisibleException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (TargetInvocationException ex) when (ex.InnerException is NoSuchElementException)
            {
                return false;
            }
        }


        /// <summary>
        ///     Checks if element is diplayed on a page.
        /// </summary>
        /// <param name="driver">Selenium WebDriver instance</param>
        /// <param name="element">Web Element to check.</param>
        /// <returns>True if element is displayed, otherwise false.</returns>
        public static bool OnPage(this IWebDriver driver, IWebElement element)
        {
            if (element == null) return false;
            try
            {
                var dis = element.Displayed;

                return true;
            }
            catch (ElementNotVisibleException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static string InnerHtml(this IWebDriver driver, IWebElement element)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].innerHTML;", element).ToString();
        }

        public static bool isDisabled(this IWebElement element)
        {
            return element.HasElement(By.CssSelector("[class*='apex_disabled']")) ||
                   element.GetAttribute("disabled") == "true";
        }

        public static bool isReadOnly(this IWebElement element)
        {
            return element.HasElement(By.CssSelector("span.display_only.apex-item-display-only"));
        }
    }
}
