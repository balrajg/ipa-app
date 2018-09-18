using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FFImageLoading.Work;
using System.Diagnostics;

namespace Ipa
{
	public partial class SetupProfilePage : ContentPage
	{
		private ProfileViewModel _ViewModel;

		public SetupProfilePage ()
		{
			
			InitializeComponent ();
			try{
				_ViewModel = new ProfileViewModel();
				this.BindingContext = _ViewModel;
			}
			catch(Exception e){
				Debug.WriteLine ("Message From Obect : " + e.Message + "\n Source: " + e.Source);
			}
			//this._ViewModel = _ViewModel;

			try{
				
//			List<ITransformation> blurEffect= new List<ITransformation>();
//			blurEffect.Add ( new FFImageLoading.Transformations.BlurredTransformation(2));
//		    BgImage.Transformations = blurEffect;
//
//			List<ITransformation> circleEffect= new List<ITransformation>();
//			circleEffect.Add ( new FFImageLoading.Transformations.CircleTransformation());
//			ProfileImage.Transformations = circleEffect;

			ChangePhoto.GestureRecognizers.Add (new TapGestureRecognizer(){
				Command = new Command(async(obj)=>{
						var action = await DisplayActionSheet ("Select an Option", "Cancel",null, new string[] {"From Camera","From Gallery"});
						if(action.Contains("From Camera")){
						_ViewModel.FromCameraCmd.Execute(null);
						}else if(action.Contains("From Gallery")){
						_ViewModel.FromGalleryCmd.Execute(null);
						}
				})
			});
			}
			catch(Exception e){
				Debug.WriteLine ("Message is: " + e.Message + "\n Source: " + e.Source);
			}

			NavigationPage.SetHasNavigationBar (this, false);
		}

		protected override bool OnBackButtonPressed()
		{
			return true;
		}

//		protected override void OnBindingContextChanged ()
//		{
//			base.OnBindingContextChanged ();
//			if (BindingContext != null) {
//				this._ViewModel = this.BindingContext as ProfileViewModel;
//			}
//		}

	}
}

