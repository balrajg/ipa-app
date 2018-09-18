using System;
using Xamarin.Forms;

namespace Ipa.Behaviors
{
	public class MaxLengthEditorBehaviour: Behavior<Editor>
	{
		public MaxLengthEditorBehaviour ()
		{
		}

		protected override void OnAttachedTo (Editor bindable)
		{
			base.OnAttachedTo (bindable);
			bindable.TextChanged += CheckMaxLengthLimit;
		}

		private void CheckMaxLengthLimit(object sender, TextChangedEventArgs e){
			if (e.NewTextValue.Length <= 500) {
				((Editor)sender).Text = e.NewTextValue;
			} else {
				((Editor)sender).Text = e.OldTextValue;
			}
		}

		protected override void OnDetachingFrom (Editor bindable)
		{
			base.OnDetachingFrom (bindable);
			bindable.TextChanged -= CheckMaxLengthLimit;
		}


	}
}

