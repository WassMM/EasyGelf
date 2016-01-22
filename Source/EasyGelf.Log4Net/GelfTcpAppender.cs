using System.Linq;
using System.Net;
using EasyGelf.Core;
using EasyGelf.Core.Transports;
using EasyGelf.Core.Transports.Tcp;

namespace EasyGelf.Log4Net
{
	public sealed class GelfTcpAppender : GelfAppenderBase
	{
		public GelfTcpAppender()
		{
			RemoteAddress = IPAddress.Loopback.ToString();
			RemotePort = 12201;
		}

		public string RemoteAddress { get; set; }

		public int RemotePort { get; set; }

		protected override ITransport InitializeTransport(IEasyGelfLogger logger)
		{
			var configuration = new TcpTransportConfiguration
			{
				RemoteAddress = RemoteAddress,
				RemotePort = RemotePort,
			};
			return new TcpTransport(configuration, new GelfMessageSerializer());
		}
	}
}