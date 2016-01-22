using System.Net;

namespace EasyGelf.Core.Transports.Tcp
{
	public sealed class TcpTransportConfiguration
	{
		/// <summary>
		/// Remote address for a host.
		/// After a while the remote address has different IP address, for example because of Load Balancer changes IP. In general
		/// to assume that IP address doesn't change is bad idea and we use the property for to refresh.
		/// </summary>
		public string RemoteAddress { get; set; }

		/// <summary>
		/// Port on the remote machine.
		/// </summary>
		public int RemotePort { get; set; }
	}
}