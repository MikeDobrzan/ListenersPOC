using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Collections;

namespace PunBupApi {

	public class Channel: IPublishCapable, INamed {
		public Task Publish(string message) {
			return null;
		}

		public Task Fire(string msg) {
			throw new NotImplementedException();
		}

		public Task Signal(string message) {
			return null;
		}

		public string id { get; }

		protected BunBup pn { get; }
	}


	public class ChannelGroupSubscription : ISubscription {
		public event Action<string> onMessage;
		public event Action<object> onStatus;
		public event Action<string> onSignal;
		public event Action<object> onPresence;
		public event Action<object> onObject;
		public event Action<object> onMessageReaction;
		public event Action<object> onFile;


		public void Subscribe() {
			throw new NotImplementedException();
		}

		public void Unsubscribe() {
			throw new NotImplementedException();
		}

		public string id { get; }
	}


	public class ChannelSubscription : Channel, ISubscription {
		public bool presenceEnabled { get; protected set; }

		public ChannelSubscription(string name) {
			// this.name = name;
		}

		public static implicit operator ChannelSubscriptionSet(ChannelSubscription c) =>
			new ChannelSubscriptionSet(new[] { c });


		public void Subscribe() {
			throw new NotImplementedException();
		}

		public void Unsubscribe() {
			throw new NotImplementedException();
		}

		public event Action<string> onMessage;
		public event Action<object> onStatus;
		public event Action<string> onSignal;
		public event Action<object> onPresence;
		public event Action<object> onObject;
		public event Action<object> onMessageReaction;
		public event Action<object> onFile;
	}

	public class ChannelPresenceSubscription : ChannelSubscription {
		public ChannelPresenceSubscription(string name) : base(name)
		{
		}
	}

}