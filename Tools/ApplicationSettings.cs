public static class ApplicationSettings
{
#if UNITY_EDITOR
	public static bool IsUnityEditor = true;
#else
	public static bool IsUnityEditor = false;
#endif
#if PLATFORM_STANDALONE_WIN
	public static bool IsPlatformStandaloneWin = true;
#else
	public static bool IsPlatformStandaloneWin = false;
#endif

	/*
	Usage:

	public void Example()
	{
		if (ApplicationSettings.IsPlatformStandaloneWin)
			StandaloneWindowsExample(); // windows specific
		else
			EveryoneElseExample(); // other platforms:

		... // code that applies to all platforms 
	}

	Source: https://stackoverflow.com/questions/70066390/is-using-if-unity-editor-return-instead-of-if-unity-editor-to-be-able-to-see
	*/
}
