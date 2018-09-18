using System;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace Ipa
{
	public class WalkThroughViewModel: ViewModelBase
	{
		public WalkThroughViewModel ()
		{
			IWalkThroughData WalkThroughScreen1 =new WalkThroughData(){
				Heading="Impact",
				Source=ImageSource.FromFile("logo_login"),
				Description="Your personalised learning app"
			};

			IWalkThroughData WalkThroughScreen2 =new WalkThroughData(){
				Heading="Access your content, assessments, dashboards",
				Source=ImageSource.FromFile("logo_login"),
				Description="Share learning through chat forums"
			};

			IWalkThroughData WalkThroughScreen3 =new WalkThroughData(){
				Heading="Have fun with quizzes, snippets",
				Source=ImageSource.FromFile("logo_login"),
				Description="Learn productively and interactively!"
			};

			WalkThroughs.Add(WalkThroughScreen1);
			WalkThroughs.Add (WalkThroughScreen2);
			WalkThroughs.Add (WalkThroughScreen3);
			SelectedItem = _WalkThroughs [0];
		}
		private ObservableCollection<IWalkThroughData> _WalkThroughs;
		public ObservableCollection<IWalkThroughData> WalkThroughs{
			set{ 
				if(Set(()=> WalkThroughs, ref _WalkThroughs, value)){
					RaisePropertyChanged(()=> WalkThroughs);

				}
			}
			get{ 
				
				return _WalkThroughs ?? (_WalkThroughs = new ObservableCollection<IWalkThroughData> ());

			}
		}
		private bool _IsBusy;

		public bool IsBusy {
			set { 
				if (Set (() => IsBusy, ref _IsBusy, value)) {
					RaisePropertyChanged (() => IsBusy);
				}
			}
			get { 
				return _IsBusy;
			}
		}
		private IWalkThroughData _SelectedItem;
		public IWalkThroughData SelectedItem{
			set{ 
				if (Set (() => SelectedItem, ref _SelectedItem, value)) {
					RaisePropertyChanged (()=> SelectedItem);
				}
			}
			get{
				return _SelectedItem;
			}
		}
		private RelayCommand _StartedCmd;

		public RelayCommand StartedCmd {
			get { 
				return _StartedCmd ?? (_StartedCmd = new RelayCommand (() => {
					DoLogin();
				}));
			}
		}
		public async void DoLogin(){

			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				NavigationHandler.GlobalNavigator.Navigation.PopModalAsync (false);
				NavigationHandler.LoginNavigator.Navigation.PushAsync( new LoginPage ());
				NavigationHandler.GlobalNavigator.Navigation.PushModalAsync(NavigationHandler.LoginNavigator);
				App.IsFirstLaunch = "No";
				IsBusy = false;
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}
	}
}

