using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Chat.Droid.ChatRenderers;
using Chat.ChatHelper;
using Chat.ChatHelper.Views;
using Ipa.Droid;
using Ipa;

[assembly: ExportRenderer(typeof(BubbleLabel), typeof(BubbleLabelRenderer))]
namespace Chat.Droid.ChatRenderers
{
    class BubbleLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if(this.Element == null)
                return ;
//			if (true) {
//				string Username = App.UserName;
//				((BubbleLabel)this.Element).IsMyMessage = true;
//			} else {
//				((BubbleLabel)this.Element).IsMyMessage = false;
//			}


			if(((BubbleLabel)this.Element).IsMyMessage)
				this.Control.SetBackground( Context.GetDrawable(Ipa.Droid.Resource.Drawable.myMsgBg));
            else 
				this.Control.SetBackground ( Context.GetDrawable( Ipa.Droid.Resource.Drawable.msgBg));

//            this.Control.SetBackgroundColor( Color.Transparent.ToAndroid());
            
            
        }



    }
}