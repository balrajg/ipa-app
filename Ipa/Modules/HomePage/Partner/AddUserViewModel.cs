using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Plugin.Connectivity;
using System.Diagnostics;
using System.Collections.Generic;

namespace Ipa
{
	public class AddUserViewModel : ViewModelBase
	{
		private string _CourseId;

		public AddUserViewModel (string courseId)
		{
			_CourseId = courseId;
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

		private RelayCommand _BackBtnCmd;

		public RelayCommand BackBtnCmd {
			get { 
				return _BackBtnCmd ?? (_BackBtnCmd = new RelayCommand (() => {
					NavigationHandler.GlobalNavigator.Navigation.PopAsync();
				}));
			}
		}

		private RelayCommand<List<ParticipantList>> _SendCmd;

		public RelayCommand<List<ParticipantList>> SendCmd {
			get { 
				return _SendCmd ?? (_SendCmd = new RelayCommand<List<ParticipantList>> ((participantList) => {
					AddUsers(participantList);
				}));
			}
		}

		public void AddUsers (List<ParticipantList> participantList)
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				AddParticipant partData = new AddParticipant ();
				partData.CourseId = this._CourseId;
				partData.ParticipantListData = participantList;
				ReportHandler.GetAddParticipantList( partData,
					(response) => {
						Debug.WriteLine ("success:" + response.ResponseCode);
						NavigationHandler.GlobalNavigator.Navigation.PopAsync();
						IsBusy=false;
					},
					(errorResponse) => {
						//Debug.WriteLine ("Error:: /nCode: " + errorResponse.ResponseCode + "/nMessage: " + errorResponse.Status);
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						IsBusy = false;
					}
				);
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}
	}
}


