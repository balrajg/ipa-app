using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FFImageLoading.Work;
using System.Diagnostics;

namespace Ipa
{
	public partial class EditProfilePage : ContentPage
	{
		public EditProfilePage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			try {
//				BgImage.CacheDuration = TimeSpan.FromMilliseconds(0);
//				List<ITransformation> blurEffect = new List<ITransformation> ();
//				blurEffect.Add (new FFImageLoading.Transformations.BlurredTransformation (2));
//				BgImage.Transformations = blurEffect;
//
//				ProfileImage.CacheDuration = TimeSpan.FromMilliseconds(0);
//				List<ITransformation> circleEffect = new List<ITransformation> ();
//				circleEffect.Add (new FFImageLoading.Transformations.CircleTransformation ());
//				ProfileImage.Transformations = circleEffect;

				ChangePhoto.GestureRecognizers.Add (new TapGestureRecognizer () {
					Command = new Command (async(obj) => {
						var action = await DisplayActionSheet ("Select an Option", "Cancel", null, new string[] {
							"From Camera",
							"From Gallery"
						});
						if (action.Equals ("From Camera")) {
							(BindingContext as ProfileViewModel).FromCameraCmd.Execute (null);
						} else if (action.Equals ("From Gallery")) {
							(BindingContext as ProfileViewModel).FromGalleryCmd.Execute (null);
						}
					})
				});
			} catch (Exception e) {
				Debug.WriteLine ("Message is: " + e.Message + "\n Source: " + e.Source);
			}
		}


//		protected override void OnBindingContextChanged ()
//		{
//			base.OnBindingContextChanged ();
//			this._ViewModel = this.BindingContext as ProfileViewModel;
//		}
	}
}

