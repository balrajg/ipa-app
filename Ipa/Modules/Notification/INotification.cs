using System;
using System.Collections.Generic;

namespace Ipa.Notification
{
	public interface INotification
	{
		void Show(int notifyId, NotificationPayload payload);
	}
}

