using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.IO;

namespace SandBox
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		//BgmPlayer
		private int		bgmIndex;
		private bool	isBgmMute;

		public MainWindow()
		{
			this.InitializeComponent();

			// 在此点下面插入创建对象所需的代码。
		}

		public void CloseWindow(object sender, RoutedEventArgs args)
		{
			this.Close();
		}

		public void DragWindow(object sender, MouseButtonEventArgs args)
		{
			this.DragMove();
		}

		private void BgmInitialize(object sender, EventArgs e)
		{
			bgmIndex = 0;
			isBgmMute = false;

			string[] bgmFiles = Directory.GetFiles("bgm","*.mp3");
			if (bgmFiles.Length > 0)
			{
				BgmPlayer.Source = new Uri(bgmFiles[bgmIndex], UriKind.RelativeOrAbsolute);
				BgmPlayer.Play();
			}
		}

		public void BgmChange(object sender, RoutedEventArgs args)
		{
			string[] bgmFiles = Directory.GetFiles("bgm", "*.mp3"); 
			if (bgmFiles.Length > 0)
			{
				BgmPlayer.Source = new Uri(bgmFiles[(++bgmIndex) % bgmFiles.Length], UriKind.RelativeOrAbsolute);
				BgmPlayer.Play();
			}
		}

		private void Button_Mute_MouseEnter(object sender, MouseEventArgs e) { Button_Mute_Clicked.Visibility = Visibility.Visible; }

		private void Button_Mute_MouseLeave(object sender, MouseEventArgs e) { Button_Mute_Clicked.Visibility = Visibility.Hidden; }

		public void Button_Mute_Click(object sender, RoutedEventArgs args)
		{
			if (isBgmMute)
			{
				BgmPlayer.Play();
				isBgmMute = false;
				Button_Mute_Forbid_Idle.Visibility = Visibility.Hidden;
				Button_Mute_Forbid_Clicked.Visibility = Visibility.Hidden; 
			}
			else
			{
				BgmPlayer.Pause();
				isBgmMute = true;
				Button_Mute_Forbid_Idle.Visibility = Visibility.Visible;
				Button_Mute_Forbid_Clicked.Visibility = Visibility.Visible; 
			}
		}
	}
	
}