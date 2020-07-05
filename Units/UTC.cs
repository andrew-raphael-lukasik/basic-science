using DateTime = System.DateTime;

using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace Game.Models.CelestialMechanics.Units
{
	/// <summary> Seconds since 1970.I.01 00:00:00 </summary>
	[System.Serializable]
	public struct UTC
	{
		public readonly static DateTime epoch = new DateTime( 1970 , 1 , 1 , 0 , 0 , 0 , System.DateTimeKind.Utc );
		public DateTime dateTime;

		public static implicit operator DateTime ( UTC val ) => val.dateTime;
		public static implicit operator UTC ( DateTime val ) => new UTC{ dateTime=val };
		
		public static bool operator > ( UTC lhs , UTC rhs ) => lhs.dateTime > rhs.dateTime;
		public static bool operator < ( UTC lhs , UTC rhs ) => lhs.dateTime < rhs.dateTime;
		public static bool operator > ( UTC lhs , DateTime rhs ) => lhs.dateTime > rhs;
		public static bool operator < ( UTC lhs , DateTime rhs ) => lhs.dateTime < rhs;
		
		const string _unit = "UTC";
		public override string ToString () => $"{dateTime.ToLongDateString()} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(UTC))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
