using UnityEngine;

namespace KoganeUnityLib
{
	public static class UniAndroidIntent
	{
		private static bool IsAndroid    => Application.platform == RuntimePlatform.Android;
		private static bool IsNotAndroid => !IsAndroid;

		public static bool GetBool( string name, bool defaultValue = default )
		{
			if ( IsNotAndroid ) return defaultValue;

			using ( var intent = GetIntent() )
			{
				return intent.Call<bool>( "getBooleanExtra", name, defaultValue );
			}
		}

		public static int GetInt( string name, int defaultValue = default )
		{
			if ( IsNotAndroid ) return defaultValue;

			using ( var intent = GetIntent() )
			{
				return intent.Call<int>( "getIntExtra", name, defaultValue );
			}
		}

		public static int[] GetIntArray( string name )
		{
			if ( IsNotAndroid ) return new int[0];

			using ( var intent = GetIntent() )
			{
				return intent.Call<int[]>( "getIntArrayExtra", name ) ?? new int[0];
			}
		}

		public static long GetLong( string name, long defaultValue = default )
		{
			if ( IsNotAndroid ) return defaultValue;

			using ( var intent = GetIntent() )
			{
				return intent.Call<long>( "getLongExtra", name, defaultValue );
			}
		}

		public static long[] GetLongArray( string name )
		{
			if ( IsNotAndroid ) return new long[0];

			using ( var intent = GetIntent() )
			{
				return intent.Call<long[]>( "getLongArrayExtra", name ) ?? new long[0];
			}
		}

		public static string GetString( string name )
		{
			if ( IsNotAndroid ) return string.Empty;

			using ( var intent = GetIntent() )
			{
				return intent.Call<string>( "getStringExtra", name ) ?? string.Empty;
			}
		}

		public static string[] GetStringArray( string name )
		{
			if ( IsNotAndroid ) return new string[0];

			using ( var intent = GetIntent() )
			{
				return intent.Call<string[]>( "getStringArrayExtra", name ) ?? new string[0];
			}
		}

		private static AndroidJavaObject GetIntent()
		{
			using ( var player = new AndroidJavaClass( "com.unity3d.player.UnityPlayer" ) )
			using ( var activity = player.GetStatic<AndroidJavaObject>( "currentActivity" ) )
			{
				var intent = activity.Call<AndroidJavaObject>( "getIntent" );
				return intent;
			}
		}
	}
}