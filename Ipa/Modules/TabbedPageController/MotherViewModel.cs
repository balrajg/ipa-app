using System;
using GalaSoft.MvvmLight;
using System.Diagnostics;
using Plugin.Connectivity;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public class MotherViewModel : ViewModelBase
	{
		MotherPage _MotherPage;

		public static ViewModelBase HomeViewModel;
		public static ViewModelBase ReportViewModel;
		public static ViewModelBase ForumViewModel;
		public static ViewModelBase SettingViewModel;

		private bool _IsBusy;

		public bool IsBusy {
			set { 
				if (Set (() => IsBusy, ref _IsBusy, value)) {
					_IsBusy = value;
				}
			}
			get { 
				return _IsBusy;
			}
		}


		private object _SelectedCurrentPage;

		public object SelectedCurrentPage {

			set { 
				_SelectedCurrentPage = value;
				RaisePropertyChanged (() => SelectedCurrentPage);
				if (value != null)
					OnCurrentPageChanged ();
			}
			get { 
				return _SelectedCurrentPage;
			}
		}

		public MotherViewModel (string courseIdToSelect = null, string activityIdToSelect = null)
		{
			Init (courseIdToSelect, activityIdToSelect);
		}

		private async Task Init ( string courseIdToSelect = null, string activityIdToSelect = null)
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				Task.Run(async () => 
				{ 
					await CourseHandler.GetCourseList(App.UserName,
					async (response) =>
					{
						//Success callback
						App.CurrentDate = response.Response.CurrentDate;
						await FindUserRole(response.Response.CourseList);
						await LoadMotherPage(response.Response.CourseList, courseIdToSelect, activityIdToSelect);
					},
					(response) =>
					{
						//Error callback
						NavigationHandler.GlobalNavigator.DisplayAlert(Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						IsBusy = false;
					});
				});

			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		private async Task FindUserRole (List<Course> courseList)
		{
			List<int> role = new List<int> ();
			foreach (Course course in courseList) {
				for (int i = 0; i < course.RoleId.Length; i++) {
					if (role.Contains (course.RoleId [i]))
						continue;
					role.Add (course.RoleId [i]);
				}
			}
			App.UserRole = role.ToArray ();
		}

		private async Task LoadMotherPage(List<Course> courseList, string courseIdToSelect = null, string activityIdToSelect = null)
		{
			MotherPage page = new MotherPage ();
			Role userRole = App.GetUserRole ();
			if (userRole == Role.Participant) {
				InitParticipantMode (page, courseList, courseIdToSelect, activityIdToSelect);
			} else if (userRole == Role.Manager) {
				InitManagerMode (page, courseList);
			} else if (userRole == Role.Client) {
				InitClientMode (page, courseList);
			} else if (userRole == Role.Partner) {
				InitPartnerMode (page, courseList, courseIdToSelect);
            } else if (userRole == Role.ManagerCumParticipant) {
				InitManagerMode (page, courseList);
			}

		}

		public void StartActivity (string courseId, string activityId)
		{
			Role userRole = App.GetUserRole();
			if (userRole == Role.Participant)
			{
				((ParticipantHomeViewModel)HomeViewModel).LaunchActivity(courseId, activityId);
			}
			else if (userRole == Role.Partner)
			{
				((PartnerHomeViewModel)HomeViewModel).LaunchActivity(courseId);
				//InitPartnerMode(page, courseList, courseIdToSelect);
			}
			else if (userRole == Role.ManagerCumParticipant)
			{
				((ManagerHomeViewModel)HomeViewModel).LaunchActivity(courseId, activityId);
				//InitManagerMode(page, courseList);
			}
		}

		private void InitParticipantMode (MotherPage motherPage, List<Course> courseList, string courseId = null, string activityId = null)
		{
			ParticipantHomePage homePage = new ParticipantHomePage ();
			ParticipantHomeViewModel homeViewModel = new ParticipantHomeViewModel (courseList, courseId, activityId);
			HomeViewModel = homeViewModel;
			homePage.BindingContext = homeViewModel;

			ParticipantReportPage reportPage = new ParticipantReportPage ();
			ParticipantReportViewModel reportViewModel = new ParticipantReportViewModel (courseList);
			ReportViewModel = reportViewModel;
			reportPage.BindingContext = reportViewModel;

			//ForumPage forumPage = new ForumPage ();
			//ForumListPageViewModel forumViewModel = new ForumListPageViewModel (courseList);
			//ForumViewModel = forumViewModel;
			//forumPage.BindingContext = forumViewModel;

			SettingPage settingPage = new SettingPage ();
			SettingViewModel settingViewModel = new SettingViewModel ();
			SettingViewModel = settingViewModel;
			settingPage.BindingContext = new SettingViewModel ();


			Device.BeginInvokeOnMainThread (() => {
				motherPage.Children.Add (homePage);
				motherPage.Children.Add (reportPage);
				//motherPage.Children.Add (forumPage);
				motherPage.Children.Add (settingPage);
				NavigationHandler.GlobalNavigator.Navigation.PushAsync (motherPage);
			});
		}

		void InitManagerMode (MotherPage page, List<Course> courseList)
		{
			ManagerHomePage homePage = new ManagerHomePage ();
			ManagerHomeViewModel homeViewModel = new ManagerHomeViewModel (courseList);
			HomeViewModel = homeViewModel;
			homePage.BindingContext = homeViewModel;

			ManagerReportPage reportPage = new ManagerReportPage ();
			ManagerReportViewModel reportViewModel = new ManagerReportViewModel (courseList);
			ReportViewModel = reportViewModel;
			reportPage.BindingContext = reportViewModel;

			//ForumPage forumPage = new ForumPage ();
			//ForumListPageViewModel forumViewModel = new ForumListPageViewModel (courseList);
			//ForumViewModel = forumViewModel;
			//forumPage.BindingContext = forumViewModel;

			SettingPage settingPage = new SettingPage ();
			SettingViewModel settingViewModel = new SettingViewModel ();
			SettingViewModel = settingViewModel;
			settingPage.BindingContext = new SettingViewModel ();

			Device.BeginInvokeOnMainThread (() => {
				page.Children.Add (homePage);
				page.Children.Add (reportPage);
				//page.Children.Add (forumPage);
				page.Children.Add (settingPage);
				NavigationHandler.GlobalNavigator.Navigation.PushAsync (page, true);
			});

		}

		void InitClientMode (MotherPage page, List<Course> courseList)
		{
			ClientHomePage homePage = new ClientHomePage ();
			ClientHomeViewModel homeViewModel = new ClientHomeViewModel (courseList);
			HomeViewModel = homeViewModel;
			homePage.BindingContext = homeViewModel;

			ClientReportPage reportPage = new ClientReportPage ();
			ClientReportViewModel reportViewModel = new ClientReportViewModel ();
			ReportViewModel = reportViewModel;
			reportPage.BindingContext = reportViewModel;

//			ForumPage forumPage = new ForumPage ();
//			ForumListPageViewModel forumViewModel = new ForumListPageViewModel (courseList);
//			ForumViewModel = forumViewModel;
//			forumPage.BindingContext = forumViewModel;

			SettingPage settingPage = new SettingPage ();
			SettingViewModel settingViewModel = new SettingViewModel ();
			SettingViewModel = settingViewModel;
			settingPage.BindingContext = new SettingViewModel ();

			Device.BeginInvokeOnMainThread (() => {
				page.Children.Add (homePage);
				page.Children.Add (reportPage);
				//page.Children.Add (forumPage);
				page.Children.Add (settingPage);
				NavigationHandler.GlobalNavigator.Navigation.PushAsync (page, true);
			});
		}

		void InitPartnerMode (MotherPage page, List<Course> courseList, string courseIdToSelect = null)
		{
			PartnerHomePage homePage = new PartnerHomePage ();
			PartnerHomeViewModel homeViewModel = new PartnerHomeViewModel (courseList, courseIdToSelect);
			HomeViewModel = homeViewModel;
			homePage.BindingContext = homeViewModel;
			//notification for mark attendance.


	//		ForumPage forumPage = new ForumPage ();
	//		ForumListPageViewModel forumViewModel = new ForumListPageViewModel (courseList);
	//		ForumViewModel = forumViewModel;
	//		forumPage.BindingContext = forumViewModel;

			SettingPage settingPage = new SettingPage ();
			SettingViewModel settingViewModel = new SettingViewModel ();
			SettingViewModel = settingViewModel;
			settingPage.BindingContext = new SettingViewModel ();


			Device.BeginInvokeOnMainThread(() =>
			{
				page.Children.Add (homePage);
				//page.Children.Add (forumPage);
				page.Children.Add (settingPage);
				NavigationHandler.GlobalNavigator.Navigation.PushAsync (page, true);
				homeViewModel.LaunchActivity(courseIdToSelect);
			});
		}

		public void OnCurrentPageChanged ()
		{
			if (CrossConnectivity.Current.IsConnected) {
				IsBusy = true;
				if (this._MotherPage.CurrentPage is IHome) {

				} else if (this._MotherPage.CurrentPage is IReport) {
					
					if (App.GetUserRole() == Role.Client) {
						((ClientReportViewModel)this._MotherPage.CurrentPage.BindingContext).Init ();
					}
					
				} else if (this._MotherPage.CurrentPage is IForum) {
					
				} else if (this._MotherPage.CurrentPage is ISetting) {

				} 
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}
	}
}


