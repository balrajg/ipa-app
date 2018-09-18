using System;

using Xamarin.Forms;

namespace Ipa
{
	public class ButtonClickedTriggerAction : TriggerAction<Button>
	{
		protected override void Invoke(Button sender)
		{
			if (sender.BackgroundColor == Color.FromRgb(43,145,193))
			{
				sender.BackgroundColor = Color.FromRgb(238,238,238);
				sender.TextColor=Color.FromRgb (120,120,120);
			}
			else
			{
				sender.BackgroundColor = Color.FromRgb(43,145,193);
				sender.TextColor=Color.FromRgb (244,244,244);
			}
		}
	}
}


