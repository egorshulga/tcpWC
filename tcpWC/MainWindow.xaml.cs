using System.Windows;

namespace tcpWC
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void sendToServer_Click(object sender, RoutedEventArgs e)
		{
			int wordsCount = Client.GetWordsCount(ServerIpBox.Text, TextBox.Text);
			WordsCountBox.Text = wordsCount.ToString();
		}
	}
}
