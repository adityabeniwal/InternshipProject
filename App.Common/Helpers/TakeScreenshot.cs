
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationTestsDataAccess.Entities.Common;
using Microsoft.VisualBasic.CompilerServices;

namespace App.Common.Helpers
{
    public class TakeScreenshot
    {
        public static readonly List<ScreenshotAndDescription> ScreenshotsTaken = new List<ScreenshotAndDescription>();

        private static Image GetSc(IWebDriver wd)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var js = (IJavaScriptExecutor)wd;

            var pageHeight = getFullHeight(wd);
            var pageWidth = getFullWidth(wd);
            var viewportHeight = getWindowHeight(wd);

            var outputImage = new Bitmap(pageWidth, pageHeight, PixelFormat.Format32bppArgb);

            using (var graphics = Graphics.FromImage(outputImage))
            {
                var scrollTimes = (int)Math.Ceiling((double)pageHeight / viewportHeight);

                for (var n = 0; n < scrollTimes; n++)
                {
                    scrollVertically(js, viewportHeight * n);

                    var screenshotDriver = (ITakesScreenshot)wd;
                    var screenshot = screenshotDriver?.GetScreenshot();


                    if (screenshot != null)
                    {
                        var img = Image.FromStream(new MemoryStream(screenshot.AsByteArray));
                        var y = getCurrentScrollY(js);
                        y = y == 0 ? 0 : y + 95;
                        graphics.DrawImage(img, new Rectangle(new Point(0, y), img.Size),
                            new Rectangle(new Point(), img.Size), GraphicsUnit.Pixel);

                        var img2 = new Bitmap(img);
                        img2.Save("C:\\tmp\\1_" + n + ".jpg", ImageFormat.Jpeg);
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            outputImage.Save("C:\\tmp\\1.jpg", ImageFormat.Jpeg);

            return outputImage;
        }

        public static void Screenshot(IWebDriver driver, string description)
        {
            var customScreenshot = new ScreenshotAndDescription();

            customScreenshot.ScreenshotImage = GetSc(driver);
            customScreenshot.Description = description;
            ScreenshotsTaken.Add(customScreenshot);
        }


        private static int getFullHeight(IWebDriver wd)
        {
            //PAGE_HEIGHT_JS page_height.js
            var js = (IJavaScriptExecutor)wd;
            var ret = js.ExecuteScript(
                    "return Math.max(document.body.scrollHeight, document.body.offsetHeight,document.documentElement.clientHeight, document.documentElement.scrollHeight, document.documentElement.offsetHeight); ")
                .ToString();

            return int.Parse(ret);
        }

        private static int getFullWidth(IWebDriver wd)
        {
            //VIEWPORT_WIDTH_JS viewport_width.js
            var js = (IJavaScriptExecutor)wd;
            var ret = js.ExecuteScript(
                    "return window.innerWidth || document.documentElement.clientWidth || document.getElementsByTagName('body')[0].clientWidth;")
                .ToString();

            return int.Parse(ret);
        }

        private static int getWindowHeight(IWebDriver wd)
        {
            //VIEWPORT_HEIGHT_JS viewport_height.js
            var js = (IJavaScriptExecutor)wd;
            var ret = js.ExecuteScript(
                    "return window.innerHeight || document.documentElement.clientHeight || document.getElementsByTagName('body')[0].clientHeight;")
                .ToString();

            return int.Parse(ret);
        }

        private static void scrollVertically(IJavaScriptExecutor js, int scrollY)
        {
            js.ExecuteScript("scrollTo(0, arguments[0]); return [];", scrollY);
        }

        private static int getCurrentScrollY(IJavaScriptExecutor js)
        {
            var ret = js.ExecuteScript("var scrY = window.scrollY;"
                                       + "if(scrY){return scrY;} else {return 0;}").ToString();
            return (int)Double.Parse(ret);
        }
    }
}
