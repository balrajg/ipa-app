using Chat.ChatHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FFImageLoading.Forms;
using FFImageLoading.Transformations;

namespace Chat.ChatHelper.Views
{
    public class TextMessageView: ContentView
    {
        private StackLayout MessageContainer;
        private Label NameLbl;
        private BubbleLabel MessageLbl;
		private RelativeLayout MessageLayout;
		private BubbleView _BubbleView;
		private StackLayout MsgContainer;
        private Label TimeStampLbl;
		private CachedImage ProfileImage;

		private readonly static ImageSource _DefaultImage = ImageSource.FromFile ("default_image.png");

		public TextMessageView(bool isMyMessage) {
			DrawView();  
			//IsMyMessage = isMyMessage;
        }

		private void DrawView()
		{
			NameLbl = new Label()
			{
				TextColor = Color.FromHex("#8A8A8A"),
				FontSize = 12,
				HorizontalOptions = LayoutOptions.Start
			};
			MessageLbl = new BubbleLabel()
			{
				TextColor = Color.Black,
				FontSize = 14,
				LineBreakMode = LineBreakMode.WordWrap,
				HorizontalOptions = LayoutOptions.Start,
				IsMyMessage = IsMyMessage
			};
			TimeStampLbl = new Label()
			{
				TextColor = Color.FromHex("#8A8A8A"),
				FontSize = 12,
				HorizontalOptions = LayoutOptions.Start
			};

			ProfileImage = new CachedImage()
			{

				HeightRequest = 33,
				WidthRequest = 33,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.End,
				Aspect = Aspect.AspectFill,
				LoadingPlaceholder = _DefaultImage,
				CacheDuration = TimeSpan.FromDays(1)
			};

			ProfileImage.Transformations.Add(new CircleTransformation(1d, "#cccccc"));

			StackLayout msgStack = new StackLayout
			{
				VerticalOptions = LayoutOptions.Fill,
				//				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 3,
				WidthRequest = 250
			};
			msgStack.Children.Add(NameLbl);

			if (Device.OS == TargetPlatform.iOS)
			{
				MessageLayout = new RelativeLayout
				{
					VerticalOptions = LayoutOptions.Fill,
				};

				_BubbleView = new BubbleView
				{
					IsMyMessage = this.IsMyMessage
				};
				MessageLbl.HorizontalOptions = LayoutOptions.FillAndExpand;

				StackLayout messageCapsule = new StackLayout
				{
					HorizontalOptions = LayoutOptions.Fill,
					Children = {
						MessageLbl
					},
					Padding = new Thickness(5)
				};

				MessageLayout.Children.Add(_BubbleView,
					Constraint.Constant(0),
					Constraint.Constant(0),
					Constraint.RelativeToView(messageCapsule, (layout, view) =>
					{
						return view.Width + 10;
					}),
					Constraint.RelativeToView(messageCapsule, (Layout, view) =>
					{
						return view.Height + 10;
					})
				);

				MessageLayout.Children.Add(messageCapsule,
					Constraint.Constant(5),
					Constraint.Constant(5),
					null,
					null
				);
				msgStack.Children.Add(MessageLayout);
			}
			else {
				msgStack.Children.Add(MessageLbl);
			}

			//			msgStack.Children.Add (MessageLbl);

			msgStack.Children.Add(TimeStampLbl);

			MessageContainer = new StackLayout
			{
				Children = {
					new StackLayout{
						Children ={
							ProfileImage
						},
						HorizontalOptions = LayoutOptions.Fill,
						VerticalOptions = LayoutOptions.End,
						Padding = new Thickness(5,5,5,20)
					},
					msgStack
				},
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.Start,
				Spacing = 3
			};

			Content = new StackLayout
			{
				Children = {
					MessageContainer
				},
				Padding = new Thickness(5)
			};
		}

        public string Name {
            set {
                if (value != null)
                    NameLbl.Text = value;
            }
            get {
                return NameLbl.Text;
            }
        }

        public string MessageText
        {
            set
            {
                if (value != null)
                    MessageLbl.Text = value;
            }
            get
            {
                return MessageLbl.Text;
            }
        }

        public string SentTime
        {
            set
            {
                if (value != null)
                    TimeStampLbl.Text = value;
            }
            get
            {
                return TimeStampLbl.Text;
            }
        }

        public ImageSource ProfileImageSource
        {
            set {
                ProfileImage.Source = value;
            }
            get
            {
                return ProfileImage.Source;
            }
        }

		private bool _IsMyMessage = false;
        public bool IsMyMessage {
            get {
                return _IsMyMessage;
            }
            set {
                if (_IsMyMessage != value)
                {
                    _IsMyMessage = value;
                    AlignMessage();
                }
                    
            }
        }

        private void AlignMessage() {
			if (IsMyMessage) {
				MessageContainer.HorizontalOptions = LayoutOptions.End;
				NameLbl.IsVisible = false;
				ProfileImage.IsVisible = false;
				if (TargetPlatform.iOS == Device.OS)
				{
					_BubbleView.IsMyMessage = true;
					MessageLayout.HorizontalOptions = LayoutOptions.End;
				}

				//_BubbleView.IsMyMessage = false;
				MessageLbl.IsMyMessage = true;
				MessageLbl.TextColor = Color.White;
				MessageLbl.HorizontalOptions = LayoutOptions.End;
				
				TimeStampLbl.HorizontalOptions = LayoutOptions.End;
			} else {
				MessageLbl.IsMyMessage = false;
			}
        }
    }
}
