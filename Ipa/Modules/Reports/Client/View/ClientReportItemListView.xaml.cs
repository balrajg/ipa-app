using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class ClientReportItemListView : ContentView
	{
		public ClientReportItemListView ()
		{
			InitializeComponent ();
		}
		public static readonly BindableProperty CourseNameProperty = 
			BindableProperty.Create<ClientReportItemListView, string> (
				(ctrl) => ctrl.CourseName,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ClientReportItemListView) bindable).Coursename.Text = newValue;
				}
			);

		public string CourseName {
			get { 
				return (string)GetValue (CourseNameProperty);
			}
			set { 
				SetValue (CourseNameProperty, value);
			}
		}

		public static readonly BindableProperty PreScoreProperty = 
			BindableProperty.Create<ClientReportItemListView, string> (
				(ctrl) => ctrl.PreScore,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					
					if(string.IsNullOrEmpty (newValue)){
						((ClientReportItemListView) bindable).Prescore.IsVisible = false;
						((ClientReportItemListView) bindable).PreImg.IsVisible = true;
					}else{
						((ClientReportItemListView) bindable).Prescore.Text = newValue;
						((ClientReportItemListView) bindable).Prescore.IsVisible = true;
						((ClientReportItemListView) bindable).PreImg.IsVisible = false;
					}
				}
			);

		public string PreScore {
			get { 
				return (string)GetValue (PreScoreProperty);
			}
			set { 
				SetValue (PreScoreProperty, value);
			}
		}

		public static readonly BindableProperty LapScoreProperty = 
			BindableProperty.Create<ClientReportItemListView, string> (
				(ctrl) => ctrl.LapScore,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					
					if(string.IsNullOrEmpty (newValue)){
						((ClientReportItemListView) bindable).Lapscore.IsVisible = false;
						((ClientReportItemListView) bindable).LapImg.IsVisible = true;
					}else{
						((ClientReportItemListView) bindable).Lapscore.Text = newValue;
						((ClientReportItemListView) bindable).Lapscore.IsVisible = true;
						((ClientReportItemListView) bindable).LapImg.IsVisible = false;
					}
				}
			);

		public string LapScore {
			get { 
				return (string)GetValue (LapScoreProperty);
			}
			set { 
				SetValue (LapScoreProperty, value);
			}
		}

		public static readonly BindableProperty PostScoreProperty = 
			BindableProperty.Create<ClientReportItemListView, string> (
				(ctrl) => ctrl.PostScore,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					
					if(string.IsNullOrEmpty (newValue)){
						((ClientReportItemListView) bindable).Postscore.IsVisible = false;
						((ClientReportItemListView) bindable).PostImg.IsVisible = true;
					}else{
						((ClientReportItemListView) bindable).Postscore.Text = newValue;
						((ClientReportItemListView) bindable).Postscore.IsVisible = true;
						((ClientReportItemListView) bindable).PostImg.IsVisible = false;
					}
				}
			);

		public string PostScore {
			get { 
				return (string)GetValue (PostScoreProperty);
			}
			set { 
				SetValue (PostScoreProperty, value);
			}
		}
			
		public static readonly BindableProperty LearnerScoreProperty = 
			BindableProperty.Create<ClientReportItemListView, string> (
				(ctrl) => ctrl.LearnerScore,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					
					if(string.IsNullOrEmpty (newValue)){
						((ClientReportItemListView) bindable).Learnerscore.IsVisible = false;
						((ClientReportItemListView) bindable).LearnerImg.IsVisible = true;
					}else{
						((ClientReportItemListView) bindable).Learnerscore.Text = newValue;
						((ClientReportItemListView) bindable).Learnerscore.IsVisible = true;
						((ClientReportItemListView) bindable).LearnerImg.IsVisible = false;
					}
				}
			);

		public string LearnerScore {
			get { 
				return (string)GetValue (LearnerScoreProperty);
			}
			set { 
				SetValue (LearnerScoreProperty, value);
			}
		}

		public static readonly BindableProperty AttendancePercentProperty = 
			BindableProperty.Create<ClientReportItemListView, string> (
				(ctrl) => ctrl.AttendancePercent,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ClientReportItemListView) bindable).Attendancepercent.Text = newValue;
				}
			);

		public string AttendancePercent {
			get { 
				return (string)GetValue (AttendancePercentProperty);
			}
			set { 
				SetValue (AttendancePercentProperty, value);
			}
		}
	}
}

