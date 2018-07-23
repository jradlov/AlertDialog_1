using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using System;
using Android.Util;
using System.Collections;
using System.Collections.Generic;

namespace AlertDialog_1
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
		string[] sports = { "football", "baseball", "tennis", "golf" };
		//string[] items = {"Applied Maths","Applied Physics","Quantum Theory","Chemisty"};
		//string[] selectedItems = new ArrayList<>();
		List<string> selectedItems = new List<string>();
		bool[] booleans = {false, true, false, true};


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_main);

			Button btn1 = FindViewById<Button>(Resource.Id.button1);
			Button btn2 = FindViewById<Button>(Resource.Id.button2);

			btn1.Click += delegate {
				Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
				builder.SetTitle("Title");

				builder.SetMultiChoiceItems(sports, booleans, OnCheckedItems);
				builder.SetPositiveButton("Done", OkAction);

				var alert = builder.Create();
				alert.Show();
			};

			btn2.Click += delegate {
				Android.Support.V7.App.AlertDialog.Builder builder = new Android.Support.V7.App.AlertDialog.Builder(this);
				builder.SetTitle("Choose one:");
				builder.SetItems(sports, ChooseItem);
				builder.SetNegativeButton("Cancel", CancelAction);
				var alert = builder.Create();
				alert.Show();
			};
		}

		private void OnCheckedItems(object sender, DialogMultiChoiceClickEventArgs e)
		{
			var index = e.Which;
			/*if(selectedItems.Count > 0) {
				for(int i=0; i< selectedItems.Count; i++)
				selectedItems.Remove(selectedItems[i]);
			}*/

			for (int i=0; i<booleans.Length; i++) 
				booleans[i] = false;

			if (e.IsChecked) {
				selectedItems.Add(sports[index]);

				booleans[index] = true;

			}
			//for (int i = 0; i < selectedItems.Count; i++)
				//Log.Debug("=== DEBUG ===", selectedItems[i]);
		}

		private void ChooseItem(object sender, DialogClickEventArgs e)
		{
			var index = e.Which;
			Log.Debug("=== DEBUG ===", sports[index]);
		}



		private void OkAction(object sender, DialogClickEventArgs e)
		{
			Log.Debug("=== DEBUG ===", "Ok clicked!");

			for (int i=0; i < selectedItems.Count; i++)
				Log.Debug("=== DEBUG ===", selectedItems[i]);

			for (int i = 0; i < booleans.Length; i++)
				Log.Debug("=== DEBUG ===", booleans[i].ToString());
		}

		private void CancelAction(object sender, DialogClickEventArgs e)
		{
			Log.Debug("=== DEBUG ===", "Cancel clicked!");
		}
	}
}

