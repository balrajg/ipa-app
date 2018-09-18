using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class AddUserItemView : ContentView
	{
		public AddUserItemView ()
		{
			InitializeComponent ();
			RemoveBtn.GestureRecognizers.Add (new TapGestureRecognizer((v) => {
				this.OnRemoveClicked?.Invoke (this, default(EventArgs));
			}));
		}

		public string Name{
			set{ 
				NameEty.Text = value;
			}
			get{ 
				return NameEty.Text;
			}
		}

		public string EmpId{
			set{ 
				EmpIdEty.Text = value;
			}
			get{ 
				return EmpIdEty.Text;
			}
		}

		public EventHandler OnRemoveClicked;
	}
}

