using Android.App;
using Android.Widget;
using Android.OS;
using OxyPlot;
using OxyPlot.Xamarin.Android;
using System.Collections.Generic;
using ProjetoTrade.Models;
using ActionBar = Android.Support.V7.App.ActionBar;

namespace ProjetoTrade
{
    [Activity(Label = "ProjetoTrade", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        private PlotView plotView;

        List<GraphModel> instrument;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            //ActionBar actionBar = getSupport

            plotView = FindViewById<PlotView>(Resource.Id.plotViewModel);

            instrument = new List<GraphModel>();
            instrument.Add(new GraphModel(40, "PETR4", "#7DA137"));
            instrument.Add(new GraphModel(40, "PETR3", "#6EA6F3"));
            instrument.Add(new GraphModel(40, "VALE5", "#999999"));
            instrument.Add(new GraphModel(40, "BBAS3", "#3B8DA5"));
            instrument.Add(new GraphModel(40, "VALE3", "#F0BA22"));

            var graphPie = new GraphHelper(plotView, instrument, (s, e) => PieSeries_TouchStarted(s, e));

            plotView.Model = graphPie.getModel();
        }

        private void PieSeries_TouchStarted(object sender, OxyTouchEventArgs e)
        {
            Toast.MakeText(ApplicationContext, "Clicked", ToastLength.Long).Show();
        }
    }
}