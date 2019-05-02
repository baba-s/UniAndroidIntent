using KoganeUnityLib;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace KoganeUnityLibExample
{
	public sealed class Example : MonoBehaviour
	{
		[SerializeField] private Text m_text = null;

		private void Start()
		{
			var sb = new StringBuilder();

			sb.AppendLine( "---------- int ----------" );
			sb.AppendLine();
			sb.AppendLine( UniAndroidIntent.GetInt( "i" ).ToString() );
			sb.AppendLine();
			sb.AppendLine( "---------- long ----------" );
			sb.AppendLine();
			sb.AppendLine( UniAndroidIntent.GetLong( "l" ).ToString() );
			sb.AppendLine();
			sb.AppendLine( "---------- string ----------" );
			sb.AppendLine();
			sb.AppendLine( UniAndroidIntent.GetString( "s" ) );
			sb.AppendLine();
			sb.AppendLine( "---------- bool ----------" );
			sb.AppendLine();
			sb.AppendLine( UniAndroidIntent.GetBool( "b" ).ToString() );
			sb.AppendLine();
			sb.AppendLine( "---------- int array ----------" );
			sb.AppendLine();

			foreach ( var n in UniAndroidIntent.GetIntArray( "ia" ) )
			{
				sb.AppendLine( n.ToString() );
			}

			sb.AppendLine();
			sb.AppendLine( "---------- long array ----------" );
			sb.AppendLine();

			foreach ( var n in UniAndroidIntent.GetLongArray( "la" ) )
			{
				sb.AppendLine( n.ToString() );
			}

			sb.AppendLine();
			sb.AppendLine( "---------- string array ----------" );
			sb.AppendLine();

			foreach ( var n in UniAndroidIntent.GetStringArray( "sa" ) )
			{
				sb.AppendLine( n );
			}

			m_text.text = sb.ToString();
		}
	}
}