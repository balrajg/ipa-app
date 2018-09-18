using System;
using Xamarin.Forms;

namespace Ipa.Behaviors
{
	public class AreaCodeBehaviour : Behavior<Entry>
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
			if (args.NewTextValue.Length <= 2) {
				((Entry)sender).Text = args.NewTextValue;
			} else {
				((Entry)sender).Text = args.OldTextValue;
			}
		}
	}
}

