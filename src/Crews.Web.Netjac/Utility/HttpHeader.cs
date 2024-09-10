using System;

namespace Crews.Web.Netjac.Utility;

public struct HttpHeader
{
	public string Name { get; }
	public string Value { get; }

	public HttpHeader(string header)
	{
		string[] parts = header.Split(':');
		if (parts.Length != 2)
		{
			throw new FormatException("Header must be in the format [name:value].");
		}

		Name = parts[0].Trim();
		Value = parts[1].Trim();
	}

	public HttpHeader(string name, string value)
	{
		foreach (string[] part in new string[][] { [name, nameof(name)], [value, nameof(value)] })
		{
			if (part[0].Contains(':'))
			{
				throw new ArgumentException("Delimiter found in header name or value.", part[1]);
			}
		}

		Name = name.Trim();
		Value = value.Trim();
	}

    public override string ToString() => $"{Name}:{Value}";
}
