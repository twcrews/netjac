using System;

namespace Crews.Web.Netjac.Tests.Utility;

public class HttpHeaderTests
{
	[Theory]
	[InlineData("Content-Type", "application/json", "Content-Type:application/json")]
	[InlineData("   Authorization ", "\tBasic abcdefgh  ", "Authorization:Basic abcdefgh")]
	[InlineData("X-Custom-Header", "ABC123 !#$&'()*+,/:;=?@[]", "X-Custom-Header:ABC123 !#$&'()*+,/:;=?@[]")]
	public void ToString_CorrectlyFormatsValidStrings(string name, string value, string expected)
	{

	}
}
