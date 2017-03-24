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
using Android.Graphics;

namespace ApplikasjonBoknaden.Droid
{
    public class DynamicView : LinearLayout
    {
        // private List layouts;

        private List<LinearLayout> layouts;

        public DynamicView(Context context, int count) :
            base(context)
        {
            this.Initialize(count);
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);

            foreach (var l in this.layouts)
            {
                l.LayoutParameters = new LinearLayout.LayoutParams(w / this.layouts.Count, ViewGroup.LayoutParams.WrapContent);
            }
        }

        private void Initialize(int count)
        {
            this.Orientation = Orientation.Horizontal;
            this.SetBackgroundColor(new Color(0, 125, 0));
            layouts = new List<LinearLayout>();
            for (int n = 0; n < count; n++)
            {
                var layout = new LinearLayout(this.Context)
                {
                    Orientation = Orientation.Vertical,
                    LayoutParameters =
                            new LinearLayout.LayoutParams(this.Width / count, ViewGroup.LayoutParams.WrapContent)
                };

                layouts.Add(layout);

                var button = new Button(this.Context)
                {
                    Text = "New button"
                };
                layout.AddView(button);

                this.AddView(layout);
            }
        }
    }
}