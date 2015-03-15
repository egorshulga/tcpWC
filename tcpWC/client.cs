using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace tcpWC
{
	public static class Client
	{
		private static readonly TcpClient tcpClient = new TcpClient();
		private static IPAddress serverIP;
		private const int serverPort = 41414;

		private const int wordsCountOnError = 0;

		public static int GetWordsCount(string serverIPtext, string text)
		{
			try
			{

				ParseServerIP(serverIPtext);

				ConnectToServer();

				SendTextToServer(text);

				int wordsCount = ReceiveWordsCount();

				CloseConnectionToServer();

				return wordsCount;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return wordsCountOnError;
			}
		}


		private static void ParseServerIP(string serverIPtext)
		{
			serverIP = IPAddress.Parse(serverIPtext);
		}


		private static void ConnectToServer()
		{
			tcpClient.Connect(serverIP, serverPort);
		}


		private static void SendTextToServer(string textToSend)
		{
			byte[] sendingBuffer = Encoding.Unicode.GetBytes(textToSend);
			NetworkStream sendingStream = tcpClient.GetStream();

			sendingStream.Write(sendingBuffer, 0, sendingBuffer.Length);
		}


		private static int ReceiveWordsCount()
		{
			NetworkStream receivingStream = tcpClient.GetStream();
			byte[] receivingBuffer = new byte[sizeof (int)];

			receivingStream.Read(receivingBuffer, 0, receivingBuffer.Length);

			return ConvertByteArrayToInt(receivingBuffer);
		}


		private static int ConvertByteArrayToInt(byte[] array)
		{
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(array);
			}
			return BitConverter.ToInt32(array, 0);
		}


		static private void CloseConnectionToServer()
		{
			tcpClient.Close();
		}

	}
}
