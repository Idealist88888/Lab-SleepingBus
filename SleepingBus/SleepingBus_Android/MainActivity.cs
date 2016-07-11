﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;

namespace SleepingBus_Android
{
    [Activity(Label = "SleepingBus_Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IRunnable
    {
        ImageButton ImgBtn;
        LinearLayout LinerLayoutAlarm;
        ListView alarmlistView;
        const int AlarmImage = 120;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            LinerLayoutAlarm = FindViewById<LinearLayout>(Resource.Id.LRLayout);
            ImgBtn = FindViewById<ImageButton>(Resource.Id.AddBtn);

            alarmlistView = FindViewById<ListView>(Resource.Id.listView);
            alarmlistView.LongClick += ListView_LongClick;




            ImgBtn.Click += ImgBtn_Click;

            ImgBtn.SetBackgroundResource(Resource.Drawable.add);


        }

        private void ListView_LongClick(object sender, Android.Views.View.LongClickEventArgs e)
        {

        }

        #region ADDPlus
        private void ImgBtn_Click(object sender, EventArgs e)
        {
            ImgBtn.SetBackgroundResource(Resource.Drawable.ADD4);
            ImgBtn.PostDelayed(new Runnable(this.Run), 100);

        }


        public void Run()
        {
            ImgBtn.SetBackgroundResource(Resource.Drawable.add);

        }
        #endregion

        private RelativeLayout ShowAlarm()
        {
            #region Layout Kod /*...*/
            /*<RelativeLayout
              android:layout_width="match_parent"
              android:layout_height="75dp"
              android:id="@+id/relativeLayout1">
              <ToggleButton
                  android:layout_width="wrap_content"
                  android:layout_height="wrap_content"
                  android:id="@+id/toggleButton1"
                  android:layout_centerInParent="true"
                  android:layout_alignParentEnd="true" />
              <ImageView
                  android:src="@drawable/budi"
                  android:layout_width="63.5dp"
                  android:layout_height="57.0dp"
                  android:id="@+id/imageView1"
                  android:layout_centerInParent="true"
                  android:layout_alignParentStart="true" />
              <TextView
                  android:text="Россия, Москва"
                  android:textAppearance="?android:attr/textAppearanceLarge"
                  android:layout_width="wrap_content"
                  android:layout_height="wrap_content"
                  android:id="@+id/textView1"
                  android:layout_toRightOf="@id/imageView1" />
              <TextView
                  android:text="Останкино 24"
                  android:textAppearance="?android:attr/textAppearanceMedium"
                  android:layout_width="wrap_content"
                  android:layout_height="wrap_content"
                  android:id="@+id/textView2"
                  android:layout_centerInParent="true"
                  android:layout_toRightOf="@id/imageView1" />
              <TextView
                  android:text="1356м"
                  android:textAppearance="?android:attr/textAppearanceMedium"
                  android:layout_width="wrap_content"
                  android:layout_height="wrap_content"
                  android:id="@+id/textView3"
                  android:layout_alignParentBottom="true"
                  android:layout_toRightOf="@id/imageView1" />
          </RelativeLayout>*/
            #endregion


            #region ToggleBtn
            Switch ToggleBtn = new Switch(this);
            RelativeLayout.LayoutParams paramToggleBtn = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
            paramToggleBtn.AddRule(LayoutRules.CenterInParent);
            paramToggleBtn.AddRule(LayoutRules.AlignParentEnd);
            ToggleBtn.LayoutParameters = paramToggleBtn;
            #endregion

            #region Image
            ImageView Image = new ImageView(this);
            RelativeLayout.LayoutParams paramImage = new RelativeLayout.LayoutParams(AlarmImage, AlarmImage);
            paramImage.AddRule(LayoutRules.CenterInParent);
            paramImage.AddRule(LayoutRules.AlignParentStart);
            Image.SetImageResource(Resource.Drawable.budi);
            Image.LayoutParameters = paramImage;
            #endregion

            #region textCity
            TextView textCity = new TextView(this);
            RelativeLayout.LayoutParams paramtextCity = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
            paramtextCity.MarginStart = AlarmImage + 20;
            paramtextCity.TopMargin = 10;
            textCity.TextSize = 26;
            textCity.Text = "Россия, Москва";
            textCity.LayoutParameters = paramtextCity;
            #endregion

            #region textBus
            TextView textBus = new TextView(this);
            RelativeLayout.LayoutParams paramtextBus = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
            paramtextBus.MarginStart = AlarmImage + 20;
            paramtextBus.AddRule(LayoutRules.CenterVertical);
            paramtextBus.BottomMargin = 10;
            textBus.Text = "Останкино 24";
            textBus.TextSize = 20;
            textBus.LayoutParameters = paramtextBus;
            #endregion

            #region textDistance
            TextView textDistance = new TextView(this);
            RelativeLayout.LayoutParams paramtextDistance = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
            paramtextDistance.AddRule(LayoutRules.AlignParentBottom);
            paramtextDistance.MarginStart = AlarmImage + 20;
            paramtextDistance.BottomMargin = 20;
            textDistance.Text = "1324м";
            textDistance.TextSize = 20;
            textDistance.LayoutParameters = paramtextDistance;
            #endregion

            #region RelativLayout
            RelativeLayout RelativLayout = new RelativeLayout(this);
            RelativLayout.LayoutParameters = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MatchParent, 200);
            RelativLayout.AddView(ToggleBtn);
            RelativLayout.AddView(Image);
            RelativLayout.AddView(textCity);
            RelativLayout.AddView(textBus);
            RelativLayout.AddView(textDistance);
            #endregion


            return RelativLayout;
        }
    }
}

