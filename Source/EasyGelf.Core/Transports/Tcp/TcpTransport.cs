﻿using System;
using System.Net.Sockets;

namespace EasyGelf.Core.Transports.Tcp
{
	public sealed class TcpTransport : ITransport
	{
		private readonly TcpTransportConfiguration configuration;
		private readonly IGelfMessageSerializer messageSerializer;
		private TcpClient client;

		public TcpTransport(TcpTransportConfiguration configuration, IGelfMessageSerializer messageSerializer)
		{
			this.configuration = configuration;
			this.messageSerializer = messageSerializer;
		}


		private void EstablishConnection()
		{
			try
			{
				if (client != null)
				{
					if (client.Connected)
						return;
					//throw new DisconnectedException();
				}
				client = new TcpClient();

				// To connect via remote address, not via IP! The TcpClient does resolve the ip address.
				client.Connect(configuration.RemoteAddress, configuration.RemotePort);
			}
			catch (Exception exception)
			{
				if (client != null)
					client.SafeDispose();
				client = null;
				throw new CannotConnectException(string.Format("Cannot connect to {0}:{1}", configuration.RemoteAddress, configuration.RemotePort), exception);
			}
		}


		public void Send(GelfMessage message)
		{
			EstablishConnection();
			using (var stream = client.GetStream())
			{
				var bytes = messageSerializer.Serialize(message);
				stream.Write(bytes, 0, bytes.Length);
				stream.WriteByte(0);
			}
		}

		public void Close()
		{
			if (client == null)
				return;
			client.SafeDispose();
			client = null;
		}
	}
}