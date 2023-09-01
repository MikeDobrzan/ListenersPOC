using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading.Tasks;

namespace PunBupApi {
	public class BunBup : IBunBupEventEmitter, ISubscribeCapable {
		public ChannelSubscriptionSet CreateChannelSubscriptions(IEnumerable<string> channels,
			long withTimetoken = 0) {
			return new ChannelSubscriptionSet(channels.Select(c => new ChannelSubscription(c)));
		}

		public ChannelSubscriptionSet CreateChannelSubscriptions(IEnumerable<Channel> channels,
			long withTimetoken = 0) {
			return CreateChannelSubscriptions(channels.Select(c => c.id));
		}

		public ChannelSubscriptionSet CreatePresenceChannelSubscriptions(IEnumerable<string> channels, long withTimetoken = 0) {

			return new ChannelSubscriptionSet(channels.Select(c => new ChannelPresenceSubscription(c)));
		}


		public ChannelSet CreateChannels(IEnumerable<string> channels) {
			return new ChannelSet();
		}

		public Channel CreateChannel(string channel) {
			return new Channel();
		}

		public ChannelSubscription CreateChannelSubscription(string channel,
			long withTimetoken = 0) {
			return new ChannelSubscription(channel);
		}

		public ChannelSubscription CreateChannelSubscription(Channel channel) {
			return CreateChannelSubscription(channel.id);
		}

		public BunBup(string subscribeKey, string publishKey, string secretKey = null, bool enableTelemetry = false) {
		}

		public void Subscribe() {
			throw new NotImplementedException();
		}

		public void Unsubscribe() {
		}


		public async Task Publish(string message, params string[] channels) {
		}


		public event Action<string> onMessage;
		public event Action<object> onStatus;
		public event Action<string> onSignal;
		public event Action<object> onPresence;
		public event Action<object> onObject;
		public event Action<object> onMessageReaction;
		public event Action<object> onFile;
	}


}