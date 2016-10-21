using System;
using Xamarin.UITest.Queries;

namespace XamarinMemeGeneratorDryRun.UITest.Queries
{
    public interface IScreenQueries
    {
        //TODO Add queries for your app

        //Global
        Func<AppQuery, AppQuery> ViewRootElement { get; }
        Func<AppQuery, AppQuery> ErrorMessageTitle { get; }

        //Main View
        Func<AppQuery, AppQuery> ButtonList { get; }
        Func<AppQuery, AppQuery> ButtonLogin { get; }

        //Login View
        Func<AppQuery, AppQuery> LoginViewTitle { get; }

        //Meme Stuff
        Func<AppQuery, AppQuery> ButtonGenerateMeme { get; }

    }
}

