using System;
using Xamarin.UITest.Queries;

namespace XamarinMemeGeneratorDryRun.UITest.Queries
{
    public class iOSQueries : IScreenQueries
    {
        //Global
        public Func<AppQuery, AppQuery> ViewRootElement { get { return c => c.Class("UIWindow"); } }
        public Func<AppQuery, AppQuery> ErrorMessageTitle { get { return c => c.Class("UILabel").Text("The requested feature is not implemented."); } }

        //MainActivity
        public Func<AppQuery, AppQuery> ButtonList { get { return c => c.Button(); } }
        public Func<AppQuery, AppQuery> ButtonLogin { get { return c => c.Button("buttonLogin"); } }

        //Login View
        public Func<AppQuery, AppQuery> LoginViewTitle { get { return c => c.Class("UINavigationBar").Id("Placeholder"); } }

        //Meme Stuff
        public Func<AppQuery, AppQuery> ButtonGenerateMeme { get { return c => c.Button(""); } }

    }
}

