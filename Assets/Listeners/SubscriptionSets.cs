using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using System.Linq;
using Unity.VisualScripting;

namespace PunBupApi {


	public class ChannelSet : IEnumerable<Channel>, IPublishCapable {
		private readonly BunBup _pn;

		public IEnumerator<Channel> GetEnumerator() {
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		// TODO do we want those bulk operations?
		public Task Publish(string msg) {
			throw new NotImplementedException();
		}

		public Task Fire(string msg) {
			throw new NotImplementedException();
		}

		public Task Signal(string msg) {
			throw new NotImplementedException();
		}
	}

	public class ChannelSubscriptionSet: ChannelSet, IEnumerable<ChannelSubscription>, IBunBupEventEmitter {
		public ChannelSubscriptionSet(IEnumerable<ChannelSubscription> subscriptions)
		{
		}


		public ChannelSubscriptionSet Add(ChannelSubscriptionSet c) => c;
		public ChannelSubscriptionSet Remove(ChannelSubscriptionSet c) => c;

		public ChannelSubscriptionSet Add(ChannelSubscription c) => c;

		public Task Publish(string message) => null;
		public Task Fire(string msg) {
			throw new NotImplementedException();
		}

		public Task Signal(string msg) {
			throw new NotImplementedException();
		}

		public event Action<string> onMessage;
		public event Action<object> onStatus;
		public event Action<string> onSignal;
		public event Action<object> onPresence;
		public event Action<object> onObject;
		public event Action<object> onMessageReaction;
		public event Action<object> onFile;

		public ChannelSubscription this[string subscriptionName] {
			get => throw new NotImplementedException();
		}

		public void Subscribe() {
		}

		public void Unsubscribe() {
			throw new NotImplementedException();
		}

		public IEnumerator<ChannelSubscription> GetEnumerator() {
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}