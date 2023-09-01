using System.Collections.Generic;
using System.Threading.Tasks;

namespace PunBupApi {
	public interface IBunBupEventEmitter {
		event System.Action<string> onMessage;
		event System.Action<object> onStatus;
		event System.Action<string> onSignal;
		event System.Action<object> onPresence;
		event System.Action<object> onObject;
		event System.Action<object> onMessageReaction;
		event System.Action<object> onFile;
	}

	public interface ISubscribeCapable {
		public void Subscribe();
		public void Unsubscribe();
	}

	public interface INamed {
		public string id { get; }
	}

	public interface ISubscription : IBunBupEventEmitter, ISubscribeCapable, INamed {

	}

	public interface IPublishCapable {
		Task Publish(string msg);
		Task Fire(string msg);
		Task Signal(string msg);
	}
}