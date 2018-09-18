using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace Ipa
{
	public class BrowserViewModel: ViewModelBase
	{
		public BrowserViewModel (string bodyContent, string title, bool hasBackbutton = false)
		{
			this.TitleText = title;
			IsBusy = true;
		}

//		private bool _HasBackButton; 
//		public bool HasBackButton{
//			set{ 
//				if( Set(()=> HasBackButton, ref _HasBackButton, value)){
//					RaisePropertyChanged (()=> LeftBtnImageSource);
//				}
//
//			}
//			get{ 
//				return _HasBackButton;
//			}
//		}

		private bool _IsBusy;
		public bool IsBusy{
			set{ 
				if(Set (()=> IsBusy, ref _IsBusy, value)){
					RaisePropertyChanged (()=> IsBusy);
				}
			}
			get{ 
				return _IsBusy;
			}
		}

//		private ImageSource _LeftBtnImageSource;
//		public ImageSource LeftBtnImageSource{
//			get{ 
//				if (HasBackButton)
//					return ImageSource.FromFile ("back.png");
//				else
//					return ImageSource.FromFile ("menu.png");
//			}
//		}

		private string _TitleText;
		public string TitleText{
			set{ 
//				if (TitleText.Contains (TitleText)) {
					if (Set (() => TitleText, ref _TitleText, value)) {
						RaisePropertyChanged (() => TitleText);

//					}
				}
			}
			get{ 
				return _TitleText;
			}
		}

//		private string _Content;
//		public string Content{
//			set{
//				_Content = value;
//				RaisePropertyChanged (()=> ViewSource);
//			}
//			get{
//				return _Content;
//			}
//		}

//		private WebView _View;
//		public WebView View{
//			set{
//				_View = value;
//				RaisePropertyChanged (()=> View);
//			}
//			get{
//				return _View;
//			}
//		}

//		public HtmlWebViewSource ViewSource{
//			get{ 
//				HtmlWebViewSource ViewSource = new HtmlWebViewSource ();
////				ViewSource.Html = @"<html> <head><meta name=""viewport"" content=""width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no""> <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,700,600italic,400italic' rel='stylesheet' type='text/css'> <style>p, b{ font-family: 'Open Sans', sans-serif; } </style> </head><body style='font-family: 'Open Sans', sans-serif;'>"+Content+"</body></html>";
//				ViewSource.BaseUrl = "http://www.Ipa.in/index.php/we-are/";
//				return ViewSource;
//			}
//		}

		private RelayCommand _LeftNavBtnCommand;
		public RelayCommand LeftNavBtnCommand{
			get{ 
				return _LeftNavBtnCommand ?? (_LeftNavBtnCommand = new RelayCommand(()=>{
					NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
				}));
			}
		}

	}
}

