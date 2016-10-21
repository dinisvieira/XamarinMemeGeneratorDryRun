using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinMemeGeneratorDryRun.UITest.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IAppExtension
    {
        /// <summary>
        /// 02-NOV-2014
        /// The default iOSApp.Back() method wasn't working on our test case, 
        /// it was waiting for a UINavigationItemButtonView, while our app had a UINavigationButton.
        /// 
        /// This should be removed when the above problem is somehow solved.
        /// </summary>
        //TODO delete this after the problem is solved
        public static void Back_iOSFix(this IApp app)
        {
            app.Tap(v => v.Class("UINavigationButton"));
        }

        /// <summary>
        /// Suspends the test execution for X seconds
        /// </summary>
        /// <param name="seconds">Seconds the app will wait/sleep</param>
        public static void Wait(this IApp app, float seconds)
        {
            var waitTime = DateTime.Now + TimeSpan.FromSeconds(seconds);

            app.WaitFor(() => DateTime.Now > waitTime);
        }

        /// <summary>
        /// Scrolls in a given direction, until the query returns at least one element, withing a given scroll limit.
        /// An Assertion will be thrown if the scroll limit is passed.
        /// 
        /// 
        /// NOTE: The scroll limit will prevent an endless loop, in case the query never returns one element
        /// </summary>
        /// <param name="query">Element query</param>
        /// <param name="scrollDirection">Scroll direction, Up or Down</param>
        /// <param name="scrollLimit">The scroll limit</param>
        /// <returns>The number of scrolls it took</returns>
        public static int ScrollUntil(this IApp app, Func<AppQuery, AppQuery> query, EScrollDirection scrollDirection, int scrollLimit = 10)
        {
            int i = 0;
            const float waitTime = 0.5f;
            Action<Func<AppQuery, AppQuery>, ScrollStrategy, double, int, bool> scroll;
            if (scrollDirection == EScrollDirection.Up)
                scroll = app.ScrollUp;
            else
                scroll = app.ScrollDown;

            do
            {
                Assert.LessOrEqual(i, scrollLimit, "Scroll limit exceeded, Element wasn't found.");

                scroll(null, ScrollStrategy.Auto, 0.67, 500, true);

                app.Wait(waitTime);

                Console.WriteLine("Waiting for {0} seconds", waitTime);
                ++i;
            } while (!app.Query(query).Any());

            return i;
        }

        /// <summary>
        /// Scrolls down, until the query returns at least one element, withing a given scroll limit.
        /// An Assertion will be thrown if the scroll limit is passed.
        /// 
        /// 
        /// NOTE: The scroll limit will prevent an endless loop, in case the query never returns one element
        /// </summary>
        /// <param name="query">Element query</param>
        /// <param name="scrollLimit">The scroll limit</param>
        /// <returns>The number of scrolls it took</returns>
        public static int ScrollDownUntil(this IApp app, Func<AppQuery, AppQuery> query, int scrollLimit = 10)
        {
            return ScrollUntil(app, query, EScrollDirection.Down, scrollLimit);
        }

        /// <summary>
        /// Scrolls up, until the query returns at least one element, withing a given scroll limit.
        /// An Assertion will be thrown if the scroll limit is passed.
        /// 
        /// 
        /// NOTE: The scroll limit will prevent an endless loop, in case the query never returns one element
        /// </summary>
        /// <param name="query">Element query</param>
        /// <param name="scrollLimit">The scroll limit</param>
        /// <returns>The number of scrolls it took</returns>
        public static int ScrollUpUntil(this IApp app, Func<AppQuery, AppQuery> query, int scrollLimit = 10)
        {
            return ScrollUntil(app, query, EScrollDirection.Up, scrollLimit);
        }

        /// <summary>
        /// Scrolls in a given direction, until the query returns at least one element, withing a given scroll limit.
        /// An Assertion will be thrown if the scroll limit is passed.
        /// 
        /// 
        /// NOTE: The scroll limit will prevent an endless loop, in case the query never returns one element
        /// </summary>
        /// <param name="scrollLimit">The scroll limit</param>
        /// <param name="scrollDirection">Scroll direction, Up or Down</param>
        /// <param name="query">Element query</param>
        /// <returns>The number of scrolls it took</returns>
        public static int ScrollUntil(this IApp app, Func<AppQuery, AppWebQuery> query, EScrollDirection scrollDirection, int scrollLimit = 10)
        {
            int i = 0;
            const float waitTime = 0.5f;
            Action<Func<AppQuery, AppQuery>, ScrollStrategy, double, int, bool> scroll;
            if (scrollDirection == EScrollDirection.Up)
                scroll = app.ScrollUp;
            else
                scroll = app.ScrollDown;

            do
            {
                Assert.LessOrEqual(i, scrollLimit, "Scroll limit exceeded, Element wasn't found.");
                scroll(null, ScrollStrategy.Auto, 0.67, 500, true);
                app.Wait(waitTime);

                Console.WriteLine("Waiting for {0} seconds", waitTime);
                ++i;
            } while (!app.Query(query).Any());

            return i;
        }

        /// <summary>
        /// Scrolls down, until the query returns at least one element, withing a given scroll limit.
        /// An Assertion will be thrown if the scroll limit is passed.
        /// 
        /// 
        /// NOTE: The scroll limit will prevent an endless loop, in case the query never returns one element
        /// </summary>
        /// <param name="query">Element query</param>
        /// <param name="scrollLimit">The scroll limit</param>
        /// <returns>The number of scrolls it took</returns>
        public static int ScrollDownUntil(this IApp app, Func<AppQuery, AppWebQuery> query, int scrollLimit = 10)
        {
            return ScrollUntil(app, query, EScrollDirection.Down, scrollLimit);
        }

        /// <summary>
        /// Scrolls up, until the query returns at least one element, withing a given scroll limit.
        /// An Assertion will be thrown if the scroll limit is passed.
        /// 
        /// 
        /// NOTE: The scroll limit will prevent an endless loop, in case the query never returns one element
        /// </summary>
        /// <param name="query">Element query</param>
        /// <param name="scrollLimit">The scroll limit</param>
        /// <returns>The number of scrolls it took</returns>
        public static int ScrollUpUntil(this IApp app, Func<AppQuery, AppWebQuery> query, int scrollLimit = 10)
        {
            return ScrollUntil(app, query, EScrollDirection.Up, scrollLimit);
        }

        public static int VerifyAndScrollUntil(this IApp app, Func<AppQuery, AppQuery> query, EScrollDirection scrollDirection, int scrollLimit = 10)
        {
            int i = 0;
            const float waitTime = 0.5f;
            Action<Func<AppQuery, AppQuery>, ScrollStrategy, double, int, bool> scroll;

            if (scrollDirection == EScrollDirection.Up)
                scroll = app.ScrollUp;
            else
                scroll = app.ScrollDown;
            while (!app.Query(query).Any())
            {
                Assert.LessOrEqual(i, scrollLimit, "Scroll limit exceeded, Element wasn't found.");
                scroll(null, ScrollStrategy.Auto, 0.67, 500, true);
                app.Wait(waitTime);

                Console.WriteLine("Waiting for {0} seconds", waitTime);
                ++i;
            }
            return i;
        }
        /// <summary>
        /// Scrolls down, until the query returns at least one element, withing a given scroll limit.
        /// An Assertion will be thrown if the scroll limit is passed.
        /// 
        /// 
        /// NOTE: The scroll limit will prevent an endless loop, in case the query never returns one element
        /// </summary>
        /// <param name="query">Element query</param>
        /// <param name="scrollLimit">The scroll limit</param>
        /// <returns>The number of scrolls it took</returns>
        public static int VerifyAndScrollDownUntil(this IApp app, Func<AppQuery, AppQuery> query, int scrollLimit = 10)
        {
            return VerifyAndScrollUntil(app, query, EScrollDirection.Down, scrollLimit);
        }

        /// <summary>
        /// Scrolls up, until the query returns at least one element, withing a given scroll limit.
        /// An Assertion will be thrown if the scroll limit is passed.
        /// 
        /// 
        /// NOTE: The scroll limit will prevent an endless loop, in case the query never returns one element
        /// </summary>
        /// <param name="query">Element query</param>
        /// <param name="scrollLimit">The scroll limit</param>
        /// <returns>The number of scrolls it took</returns>
        public static int FindAndTap(this IApp app, Func<AppQuery, AppQuery> query, EScrollDirection scrollDirection, int scrollLimit = 10)
        {
            int i = 0;
            const float waitTime = 0.5f;
            Action<Func<AppQuery, AppQuery>, ScrollStrategy, double, int, bool> scroll;

            if (scrollDirection == EScrollDirection.Up)
                scroll = app.ScrollUp;
            else
                scroll = app.ScrollDown;
            while (!app.Query(query).Any())
            {
                Assert.LessOrEqual(i, scrollLimit, "Scroll limit exceeded, Element wasn't found.");
                scroll(null, ScrollStrategy.Auto, 0.67, 500, true);
                app.Wait(waitTime);

                Console.WriteLine("Waiting for {0} seconds", waitTime);
                ++i;
            }
            app.Tap(query);
            return i;
        }
        /// <summary>
        /// Scrolls down, until the query returns at least one element, withing a given scroll limit.
        /// An Assertion will be thrown if the scroll limit is passed.
        /// 
        /// 
        /// NOTE: The scroll limit will prevent an endless loop, in case the query never returns one element
        /// </summary>
        /// <param name="query">Element query</param>
        /// <param name="scrollLimit">The scroll limit</param>
        /// <returns>The number of scrolls it took</returns>
        public static int FindDownAndTap(this IApp app, Func<AppQuery, AppQuery> query, int scrollLimit = 10)
        {
            return FindAndTap(app, query, EScrollDirection.Down, scrollLimit);
        }

        public static void WaitAndTapElement(this IApp app, Func<AppQuery, AppQuery> elementQuery)
        {
            app.WaitForElement(elementQuery);
            app.Tap(elementQuery);
        }

        public static void WaitAndTapElement(this IApp app, Func<AppQuery, AppWebQuery> elementQuery)
        {
            app.WaitForElement(elementQuery);
            app.Tap(elementQuery);
        }
    }

    public enum EScrollDirection
    {
        Up,
        Down
    }
}