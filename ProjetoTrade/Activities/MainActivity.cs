using Android.App;
using Android.Widget;
using Android.OS;
using OxyPlot;
using OxyPlot.Xamarin.Android;
using OxyPlot.Series;
using Android.Views;

namespace ProjetoTrade
{
    [Activity(Label = "ProjetoTrade", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        private PlotView plotViewModel;
        private LinearLayout mLLayoutModel;
        public PlotModel MyModel { get; set; }

        private int[] modelAllocValues = new int[] { 12, 5, 2, 40, 40, 1 };
        private string[] modelAllocations = new string[] { "Slice1", "Slice2", "Slice3", "Slice4", "Slice5", "Slice6" };
        string[] colors = new string[] { "#7DA137", "#6EA6F3", "#999999", "#3B8DA5", "#F0BA22", "#EC8542" };
        int total = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            plotViewModel = FindViewById<PlotView>(Resource.Id.plotViewModel);
            mLLayoutModel = FindViewById<LinearLayout>(Resource.Id.linearLayoutModel);

            //Model Allocation Pie char
            var plotModel2 = new PlotModel();
            var pieSeries2 = new PieSeries();
            pieSeries2.InsideLabelPosition = 0.0;
            pieSeries2.InsideLabelFormat = null;

            for (int i = 0; i < modelAllocations.Length && i < modelAllocValues.Length && i < colors.Length; i++)
            {

                pieSeries2.Slices.Add(new PieSlice(modelAllocations[i], modelAllocValues[i]) { Fill = OxyColor.Parse(colors[i]) });
                pieSeries2.OutsideLabelFormat = null;

                double mValue = modelAllocValues[i];
                double percentValue = (mValue / total) * 100;
                string percent = percentValue.ToString("#.##");

                //Add horizontal layout for titles and colors of slices
                LinearLayout hLayot = new LinearLayout(this);
                hLayot.Orientation = Android.Widget.Orientation.Horizontal;
                LinearLayout.LayoutParams param = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
                hLayot.LayoutParameters = param;

                //Add views with colors
                LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(15, 15);

                View mView = new View(this);
                lp.TopMargin = 5;
                mView.LayoutParameters = lp;
                mView.SetBackgroundColor(Android.Graphics.Color.ParseColor(colors[i]));

                //Add titles
                TextView label = new TextView(this);
                label.TextSize = 10;
                label.SetTextColor(Android.Graphics.Color.Black);
                label.Text = string.Join(" ", modelAllocations[i]);
                param.LeftMargin = 8;
                label.LayoutParameters = param;

                hLayot.AddView(mView);
                hLayot.AddView(label);
                mLLayoutModel.AddView(hLayot);

            }

            plotModel2.Series.Add(pieSeries2);
            MyModel = plotModel2;
            plotViewModel.Model = MyModel;

        }
    }
}