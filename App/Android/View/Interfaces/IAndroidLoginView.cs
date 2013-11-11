using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Nfro.App.Core.View;
using Nfro.Core.Objects.Results;

namespace Nfro.App.Android.View {
    public interface IAndroidLoginView : ILoginView, IBaseView {
        void ToMain();
    }
}