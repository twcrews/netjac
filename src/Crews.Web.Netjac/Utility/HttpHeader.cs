namespace Crews.Web.Netjac.Utility;

/// <summary>
/// Represents an HTTP header.
/// </summary>
public readonly struct HttpHeader
{
	/// <summary>
	/// The header's name.
	/// </summary>
	public string Name { get; }

	/// <summary>
	/// The header's value.
	/// </summary>
	public string Value { get; }

	/// <summary>
	/// Creates a new HTTP header object from the given string.
	/// </summary>
	/// <remarks>
	/// Due to the unpredictable nature of value delimiters in HTTP headers, a single value will always be assumed. If the
	/// header string contains multiple values, they must be separated manually. Then, a unique <c>HttpHeader</c> instance
	/// should be created for each of the values.
	/// </remarks>
	/// <param name="header">The string representation of the header.</param>
	public HttpHeader(string header)
	{
		string[] parts = header.Split(':', 2);

		Name = parts[0].Trim();
		Value = parts[1].Trim();
	}

	/// <summary>
	/// Creates a new HTTP header object from the given name and value.
	/// </summary>
	/// <param name="name">The name of the HTTP header.</param>
	/// <param name="value">The value or combined values of the HTTP header.</param>
	/// <exception cref="ArgumentException">
	/// The header delimiter character was found in the <c>name</c> argument.
	/// </exception>
	/// <remarks>
	/// Due to the unpredictable nature of value delimiters in HTTP headers, a single value will always be assumed. If the
	/// header string contains multiple values, they must be separated manually. Then, a unique <c>HttpHeader</c> instance
	/// should be created for each of the values.
	/// </remarks>
	public HttpHeader(string name, string value)
	{
		if (name.Contains(':'))
		{
			throw new ArgumentException("Delimiter found in header name.", nameof(name));
		}

		Name = name.Trim();
		Value = value.Trim();
	}

	/// <summary>
	/// Gets the string representation of the header in the format <c>name:value</c>.
	/// </summary>
	/// <returns>A string representation of the header.</returns>
	public override readonly string ToString() => $"{Name}:{Value}";

	/// <summary>
	/// Implicitly creates a new instance using the default constructor.
	/// </summary>
	/// <param name="header">The string representation of the header.</param>
	public static implicit operator HttpHeader(string header) => new(header);

	/// <summary>
	/// Implicitly converts the given instance to a string. Equivalent to calling <c>ToString()</c>.
	/// </summary>
	/// <param name="header">The current instance.</param>
	public static implicit operator string(HttpHeader header) => header.ToString();
}
