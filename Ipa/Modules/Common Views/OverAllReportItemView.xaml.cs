using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FFImageLoading.Work;

namespace Ipa
{
	public partial class OverAllReportItemView : ContentView
	{
		public OverAllReportItemView ()
		{
			InitializeComponent ();

			List<ITransformation> circleEffect= new List<ITransformation>();
			circleEffect.Add ( new FFImageLoading.Transformations.CircleTransformation());
			ProfileImage.Transformations = circleEffect;

		}

		public static readonly BindableProperty ParticipantNameProperty = 
			BindableProperty.Create<OverAllReportItemView, string> (
				(ctrl) => ctrl.ParticipantName,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((OverAllReportItemView) bindable).UserName.Text = newValue;
				}
			);

		public string ParticipantName {
			get { 
				return (string)GetValue (ParticipantNameProperty);
			}
			set { 
				SetValue (ParticipantNameProperty, value);
			}
		}

		public static readonly BindableProperty ParticipantSourceProperty = 
			BindableProperty.Create<OverAllReportItemView, Xamarin.Forms.ImageSource> (
				(ctrl) => ctrl.ParticipantSource,			
				null,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, Xamarin.Forms.ImageSource oldValue, Xamarin.Forms.ImageSource newValue) => {
					((OverAllReportItemView) bindable).ProfileImage.Source = newValue;
				}
			);

		public Xamarin.Forms.ImageSource ParticipantSource {
			get { 
				return (Xamarin.Forms.ImageSource)GetValue (ParticipantSourceProperty);
			}
			set { 
				SetValue (ParticipantSourceProperty, value);
			}
		}

		public static readonly BindableProperty L2BeliefAssessmentProperty = 
			BindableProperty.Create<OverAllReportItemView, string> (
				(ctrl) => ctrl.L2BeliefAssessment,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((OverAllReportItemView) bindable).ReportPercent.Text = newValue;
				}
			);

		public string L2BeliefAssessment {
			get { 
				return (string)GetValue (L2BeliefAssessmentProperty);
			}
			set { 
				SetValue (L2BeliefAssessmentProperty, value);
			}
		}
		public static readonly BindableProperty L2SkillAssessmentProperty = 
			BindableProperty.Create<OverAllReportItemView, string> (
				(ctrl) => ctrl.L2SkillAssessment,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((OverAllReportItemView) bindable).Activitypercent.Text = newValue;
				}
			);

		public string L2SkillAssessment {
			get { 
				return (string)GetValue (L2SkillAssessmentProperty);
			}
			set { 
				SetValue (L2SkillAssessmentProperty, value);
			}
		}
	}
}

