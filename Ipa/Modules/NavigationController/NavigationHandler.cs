using System;
using Xamarin.Forms;

namespace Ipa
{
	public enum PageNavigatorType{ Login, Home, Report, Forum, Setting,Gobal}

	public static class NavigationHandler
	{
		private static NavigationPage _LoginNavigator;
		public static NavigationPage LoginNavigator{
			private set{ 
				_LoginNavigator = value;
			}
			get{ 
				return _LoginNavigator ?? (_LoginNavigator = new NavigationPage());
			}
		}

		private static NavigationPage _HomeNavigator;
		public static NavigationPage HomeNavigator{
			private set{ 
				_HomeNavigator = value;
			}
			get{ 
				return _HomeNavigator ?? (_HomeNavigator = new NavigationPage());
			}
		}

		private static NavigationPage _ReportsNavigator;
		public static NavigationPage ReportsNavigator{
			private set{ 
				_ReportsNavigator = value;
			}
			get{ 
				return _ReportsNavigator ?? (_ReportsNavigator = new NavigationPage());
			}
		}

		private static NavigationPage _ForumNavigator;
		public static NavigationPage ForumNavigator{
			private set{ 
				_ForumNavigator = value;
			}
			get{ 
				return _ForumNavigator ?? (_ForumNavigator = new NavigationPage());
			}
		}

		private static NavigationPage _SettingNavigator;
		public static NavigationPage SettingNavigator{
			private set{ 
				_SettingNavigator = value;
			}
			get{ 
				return _SettingNavigator ?? (_SettingNavigator = new NavigationPage ());
			}
		}

		private static NavigationPage _GlobalNavigator;
		public static NavigationPage GlobalNavigator{
			private set{ 
				_GlobalNavigator = value;
			}
			get{ 
				return _GlobalNavigator ?? (_GlobalNavigator = new NavigationPage ());
			}
		}

		public static NavigationPage InitNavigationPage(PageNavigatorType _navigatorType, Page page){

			switch (_navigatorType) {
			case PageNavigatorType.Login:
				{
					LoginNavigator = new NavigationPage ();
					if (page != null)
						LoginNavigator.PushAsync (page);
					return LoginNavigator;
				}
			case PageNavigatorType.Home:
				{
					HomeNavigator = new NavigationPage ();
					if (page != null)
						HomeNavigator.PushAsync (page);
					return HomeNavigator;
				}
			
			case PageNavigatorType.Report:
				{
					ReportsNavigator = new NavigationPage ();
					if (page != null)
						ReportsNavigator.PushAsync (page);
					return ReportsNavigator;
				}
			case PageNavigatorType.Forum:
				{
					ForumNavigator = new NavigationPage ();
					if (page != null)
						ForumNavigator.PushAsync (page);
					return ForumNavigator;
				}
			case PageNavigatorType.Setting:
				{
					SettingNavigator = new NavigationPage ();
					if (page != null)
						SettingNavigator.PushAsync (page);
					return SettingNavigator;
				}
			case PageNavigatorType.Gobal:
			{
				GlobalNavigator = new NavigationPage ();
				if (page != null)
					GlobalNavigator.PushAsync (page);
				return GlobalNavigator;
			}
		}
			return null;
		}
	}
}

