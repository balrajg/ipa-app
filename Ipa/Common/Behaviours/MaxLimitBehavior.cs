using System;
using Xamarin.Forms;

namespace Ipa.Behaviors
{
	public class  MaxLimitBehavior : Behavior<Entry>
	{
		protected override void OnAttachedTo(Entry entry)
		{
			entry.TextChanged += OnEntryTextChanged;
			base.OnAttachedTo(entry);
		}

		protected override void OnDetachingFrom(Entry entry)
		{
			entry.TextChanged -= OnEntryTextChanged;
			base.OnDetachingFrom(entry);
		}

		void OnEntryTextChanged(object sender, TextChangedEventArgs args)
		{
			if (args.NewTextValue.Length <= 150) {
				((Entry)sender).Text = args.NewTextValue;
			} else {
				((Entry)sender).Text = args.OldTextValue;
			}
		}


	}

}

