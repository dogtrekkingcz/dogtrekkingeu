package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("Microsoft.Maui.MauiApplication, Microsoft.Maui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc6488302ad6e9e4df1a.MauiApplication.class, crc6488302ad6e9e4df1a.MauiApplication.__md_methods);
		mono.android.Runtime.register ("GpsTracker.MainApplication, GpsTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc64552a98c7949be549.MainApplication.class, crc64552a98c7949be549.MainApplication.__md_methods);
		
	}
}
