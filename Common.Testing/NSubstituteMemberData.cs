using System;
using System.Reflection;
using Xunit;

namespace Common.Testing
{
	public class NSubstituteMemberData : MemberDataAttributeBase
	{
		public NSubstituteMemberData(string memberName, object[] parameters) : base(memberName, parameters) {}

		protected override object[] ConvertDataItem(MethodInfo testMethod, object item)
		{
			if (item == null) return null;

			if (!(item is object[] inlineData)) throw new ArgumentException($"{MemberName} on {MemberType ?? testMethod.DeclaringType} should yield an object[] as inlineData");

			return inlineData;
		}
	}
}
