using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FFImageLoading.Work;

namespace Ipa
{
	public partial class SettingPage : ContentPage
	{
		public SettingPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);

//			BgImage.CacheDuration = TimeSpan.FromMilliseconds (0);
//			List<ITransformation> blurEffect= new List<ITransformation>();
//			blurEffect.Add ( new FFImageLoading.Transformations.BlurredTransformation(2));
//			BgImage.Transformations = blurEffect;
//
//			ProfileImage.CacheDuration = TimeSpan.FromMilliseconds (0);
//			List<ITransformation> circleEffect= new List<ITransformation>();
//			circleEffect.Add ( new FFImageLoading.Transformations.CircleTransformation());
//			ProfileImage.Transformations = circleEffect;
		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			SettingViewModel vm = (SettingViewModel)this.BindingContext;
			this.BindingContext = vm;
			vm.SetProfileInfo ();
		}
	}

}

