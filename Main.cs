using System;
using Gtk;


namespace autoconnect
{
	class FancyButton
	{

		public FancyButton(Builder builder)
		{
			builder.Autoconnect(this);

		}
	}

	class Application
	{
		[BuilderExtensions.Object("main-window")] Window Window;
		[BuilderExtensions.Object("button1")] Button button1;

		public Application()
		{
			var bld = new Builder ();
			bld.AddFromFile("main.ui");
			bld.Autoconnect (this);
			button1.Clicked += (o, _) =>
			{
				Console.WriteLine("clicked!");
				button1.Label = "hiya!";
			};
			
			Window.ShowAll();
		}
	}

	class MainClass
	{

		public static void Main (string[] args)
		{
			GLib.Thread.Init ();
			Gtk.Application.Init ();
			var app = new Application();
			Gtk.Application.Run ();
		}
	}
}
