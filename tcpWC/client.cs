using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace tcpWC
{
	class client
	{
		private TcpClient tcpClient = new TcpClient();
		IPAddress serverIP;
		private int port = 41414;

		public client(string serverIPtext)
		{
			serverIP = TryParseAddress(serverIPtext);


		}

		private IPAddress TryParseAddress(string serverIPtext)
		{
			try
			{
				return IPAddress.Parse(serverIPtext);
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to parse server IP");
				//throw;
			}
		}

	}
}
