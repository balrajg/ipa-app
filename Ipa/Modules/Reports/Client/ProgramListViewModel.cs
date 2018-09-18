using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;

namespace Ipa
{
	public class ProgramListViewModel : ViewModelBase
	{
		private Program _ProgramData;

		public ProgramListViewModel (Program ProgramData)
		{
			this._ProgramData = ProgramData;
		}
		public string ProgramName {
			get { 
				return _ProgramData.PrgName;
			}
		}
		public string ProgramId {
			get { 
				return _ProgramData.PrgID;
			}
		}
	}
}


