using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;

namespace Ipa
{
	public class CourseListViewModel : ViewModelBase
	{
		private CourseData _Data;

		public CourseListViewModel (CourseData data)
		{
			this._Data = data;
		}
		private string CourseId {
			get {
				return _Data.CourseId;
			}
		}
	}
}


