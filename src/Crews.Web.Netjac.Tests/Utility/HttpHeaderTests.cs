using Crews.Web.Netjac.Utility;

namespace Crews.Web.Netjac.Tests.Utility;

public class HttpHeaderTests
{
	[Theory]
	[InlineData("Content-Type", "application/json", "Content-Type:application/json")]
	[InlineData("   Authorization ", "\tBasic abcdefgh  ", "Authorization:Basic abcdefgh")]
	[InlineData("X-Custom-Header", "ABC123 !#$&'()*+,/:;=?@[]", "X-Custom-Header:ABC123 !#$&'()*+,/:;=?@[]")]
	public void ToStringCorrectlyFormatsValidStrings(string name, string value, string expected)
	{
		HttpHeader header = new(name, value);
		Assert.Equal(expected, header.ToString());
	}

	[Fact]
	public void StringImplicitOperatorReturnsValidString()
	{
		HttpHeader header = new("X-Custom-Header", "ABC123");
		string expected = "X-Custom-Header:ABC123";
		Assert.Equal(expected, header);
	}

	[Fact]
	public void StringImplicitOperatorAndToStringAreIdentical()
	{
		HttpHeader header = new("X-Custom-Header", "ABC123");
		Assert.Equal(header, header.ToString());
	}

	[Fact]
	public void ClassImplicitOperatorReturnsValidObject()
	{
		string expectedName = "X-Custom-Header";
		string expectedValue = "ABC123";

		string headerString = $"{expectedName}:{expectedValue}";
		HttpHeader header = headerString;

		Assert.Equal(expectedName, header.Name);
		Assert.Equal(expectedValue, header.Value);
	}

	[Theory]
	[InlineData("Content-Type:application/json", "Content-Type:application/json")]
	[InlineData("   Authorization  :\tBasic abcdefgh  ", "Authorization:Basic abcdefgh")]
	[InlineData("X-Custom-Header:ABC123 !#$&'()*+,/:;=?@[]", "X-Custom-Header:ABC123 !#$&'()*+,/:;=?@[]")]
	public void DirectConstructorFormatsHeaderCorrectly(string input, string expected)
	{
		HttpHeader header = new(input);
		Assert.Equal(expected, header.ToString());
	}
}
