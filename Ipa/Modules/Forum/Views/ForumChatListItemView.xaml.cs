using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FFImageLoading.Work;

namespace Ipa
{
	public partial class ForumChatListItemView : ContentView
	{
		public ForumChatListItemView ()
		{
			InitializeComponent ();
			List<ITransformation> circleEffect= new List<ITransformation>();
			circleEffect.Add ( new FFImageLoading.Transformations.CircleTransformation());
			profileImage.Transformations = circleEffect;
		}
		public static readonly BindableProperty ParticipantNameProperty = 
			BindableProperty.Create<ForumChatListItemView, string> (
				(ctrl) => ctrl.ParticipantName,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ForumChatListItemView) bindable).participantName.Text = newValue;
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
		public static readonly BindableProperty CourseNameProperty = 
			BindableProperty.Create<ForumChatListItemView, string> (
				(ctrl) => ctrl.CourseName,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ForumChatListItemView) bindable).courseName.Text = newValue;
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
		public static readonly BindableProperty MessageTextProperty = 
			BindableProperty.Create<ForumChatListItemView, string> (
				(ctrl) => ctrl.MessageText,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ForumChatListItemView) bindable).messageText.Text = newValue;
				}
			);

		public string MessageText {
			get { 
				return (string)GetValue (MessageTextProperty);
			}
			set { 
				SetValue (MessageTextProperty, value);
			}
		}
		public static readonly BindableProperty ProfileImageProperty = 
			BindableProperty.Create<ForumChatListItemView, string> (
				(ctrl) => ctrl.ProfileImage,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ForumChatListItemView) bindable).profileImage.Source = newValue;
				}
			);

		public string ProfileImage {
			get { 
				return (string)GetValue (ProfileImageProperty);
			}
			set { 
				SetValue (ProfileImageProperty, value);
			}
		}
		public static readonly BindableProperty TimeDescriptionProperty = 
			BindableProperty.Create<ForumChatListItemView, string> (
				(ctrl) => ctrl.TimeDescription,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ForumChatListItemView) bindable).timeDescription.Text = newValue;
				}
			);

		public string  TimeDescription{
			get { 
				return (string)GetValue (TimeDescriptionProperty);
			}
			set { 
				SetValue (TimeDescriptionProperty, value);
			}
		}
	}
}

