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
using OxyPlot;
using OxyPlot.Xamarin.Android;
using OxyPlot.Series;

namespace ProjetoTrade.Models
{
    class GraphHelper
    {
        List<GraphModel> _toPlot;
        View _view;
        PlotModel _plotModel;
        PieSeries _pieSeries;

        public GraphHelper(PlotView view, List<GraphModel> toPlot, EventHandler<OxyTouchEventArgs> onClick = null)
        {
            _view = view;
            _toPlot = toPlot;
            _plotModel = new PlotModel();
            _pieSeries = new PieSeries();
            
            AddRange(ToSlice(_toPlot));

            _plotModel.Series.Add(_pieSeries);
            _pieSeries.TouchStarted += onClick;
        }

        void AddRange(List<PieSlice> list)
        {
            foreach (var toAdd in list)
                _pieSeries.Slices.Add(toAdd);
        }

        public PlotModel getModel() => _plotModel;
        void Add(PieSlice toAdd) => _pieSeries.Slices.Add(toAdd);
        void Add(GraphModel toAdd) => _pieSeries.Slices.Add(ToSlice(toAdd));
        private PieSlice ToSlice(GraphModel slice) => new PieSlice(slice.Name, slice.Value) { Fill = OxyColor.Parse(slice.Color) };

        private List<PieSlice> ToSlice(List<GraphModel> slices)
        {
            var toReturn = new List<PieSlice>();
            foreach (var slice in slices)
                toReturn.Add(new PieSlice(slice.Name, slice.Value) { Fill = OxyColor.Parse(slice.Color) });
            return toReturn;
        }



        // pieSeries.OutsideLabelFormat = null;

        /*
        //Add horizontal layout for titles and colors of slices

        //=======================================================================
        LinearLayout hLayot = new LinearLayout(this);
        hLayot.Orientation = Orientation.Horizontal;
        LinearLayout.LayoutParams param = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
        hLayot.LayoutParameters = param;

        //Add views with colors
        LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(35, 35);

        View mView = new View(this);
        lp.TopMargin = 5;
        mView.LayoutParameters = lp;
        mView.SetBackgroundColor(Android.Graphics.Color.ParseColor(colors[i]));

        //Add titles
        TextView label = new TextView(this);
        label.TextSize = 12;
        label.SetTextColor(Android.Graphics.Color.Black);
        label.Text = string.Join(" ", modelAllocations[i]);
        param.LeftMargin = 15;
        label.LayoutParameters = param;
        //========================================================================

        hLayot.AddView(mView); //Quadrado
        hLayot.AddView(label); //Label
        mLLayoutModel.AddView(hLayot); //adiciona Quadrado + Label
        */
    }

    class GraphModel
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public GraphModel(int value, string name, string color)
        {
            Value = value;
            Name = name;
            Color = color;
        }
    }
}