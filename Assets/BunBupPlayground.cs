using System;
using System.Collections;
using System.Collections.Generic;
using PunBupApi;

public class DemoBunBup {
	async void Start() {
		var lotOfChannels = new string[] { "channelA", "channelB", "channelC" };
		var lotOfChannelsMinusOne = new string[] { "channelA", "channelC" };
		var bunchOfChannels = new string[] { "channelC", "channelD", "channelE" };

		// example PubNub object initialization
		BunBup pn = new BunBup(
			"test",
			"test",
			secretKey: "test",
			enableTelemetry: false);

		var channel = pn.CreateChannel("somechannel");
		var channelSub = pn.CreateChannelSubscription(channel);

		// Creation of a subscription to a single channel
		// Split into Channel and Subscription object under the hood?
		ChannelSubscriptionSet funChannel = pn.CreateChannelSubscription("funChannel");
		var a = funChannel["funChannel"];

		// Creation of a subscription to multiple channels.
		// Note, that SubscriptionSet<ChannelSubscription> will consist of ChannelSubscription objects, representing their respective channels
		ChannelSubscriptionSet aLotOfChannels =
			pn.CreateChannelSubscriptions(new string[] { "channelA", "channelB", "channelC" });
		ChannelSubscriptionSet aBunchOfChannels =
			pn.CreatePresenceChannelSubscriptions(new string[] { "channelD", "channelE", "channelC" });

		aBunchOfChannels.Add(pn.CreateChannelSubscription("channelC", withTimetoken: 123124));
		aBunchOfChannels.Subscribe();

		foreach (var v in aBunchOfChannels) {
			await v.Publish("asd");
		}



		var superset = aLotOfChannels.Add(aBunchOfChannels);
		superset.onPresence += o => { };


		// Add an event listener on the global object
		pn.onMessage += a => Console.WriteLine(a);

		// Add an event listener on a channel subscription set
		aLotOfChannels.onMessage += a => Console.WriteLine(a);

		// Add an event listener on a single channel subscription
		funChannel.onMessage += a => Console.WriteLine(a);

		// Execute the subscriptions (TBD)
		funChannel.Subscribe();
		aLotOfChannels.Subscribe();

		// Cancel a channel subscription - this is equivalent to disposing of the object
		// This will also clear any event listeners
		funChannel.Unsubscribe();

		// Of course this can be controlled from every level in the hierarchy
		aLotOfChannels.Unsubscribe();
		// This special case should probably be called UnsubscribeAll
		pn.Unsubscribe();

		// Example emergent functionality of the SubscriptionSet<ChannelSubscription> class:
		// await (aLotOfChannels + aBunchOfChannels).Publish("message");

		var allChannels = aLotOfChannels.Add(aBunchOfChannels);

		ChannelSubscriptionSet newSet = new ChannelSubscription("funChannel");

		var thisClass = new CustomerClass(newSet);
		newSet.Subscribe();

		aLotOfChannels["channelB"].onMessage += s => { };

		await aLotOfChannels.Publish("message");

		// await (aLotOfChannels + aBunchOfChannels).Publish("message");

		pn.onMessage += s => { };
		funChannel.onMessage += s => { };
		aLotOfChannels.onMessage += s => { };

		// aLotOfChannels.Unsubscribe();
		// aLotOfChannels = pn.SubscribeChannels(lotOfChannelsMinusOne);

		aLotOfChannels["channelB"].Unsubscribe();

		var notFunChannel = pn.CreateChannelSubscription("notFunChannel");

		//var something = new Something(funChannel);

		newSet.Remove(funChannel);
		newSet.Add(notFunChannel);
	}
}

// Example class in a Customer's code - meant for handling OnMessage events
public class CustomerClass {
	// Pubnub Event Emitter - common interface
	private ChannelSubscriptionSet channelB;

	// Can be either a Subscription, a SubscriptionSet or the whole PN object
	public CustomerClass(ChannelSubscriptionSet sub) {
		channelB = sub;
		channelB.onMessage += PnOnMessage;
	}

	private void PnOnMessage(object msg) {
		Console.WriteLine($"Message received: {msg}");
	}
}