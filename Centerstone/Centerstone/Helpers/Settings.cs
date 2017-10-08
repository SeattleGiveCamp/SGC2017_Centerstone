using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Centerstone.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		static ISettings AppSettings => CrossSettings.Current;

		public static string LastApplicationPath {
			get {
				return AppSettings.GetValueOrDefault ("LastApplicationPath", "");
			}
			set {
				AppSettings.AddOrUpdateValue ("LastApplicationPath", value);
			}
		}
	}
}
