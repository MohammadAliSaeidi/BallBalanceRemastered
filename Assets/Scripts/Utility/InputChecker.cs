using System.Text.RegularExpressions;
using UnityEngine;

public static class InputChecker
{
	public static bool IsEmptyOrWhiteSpace(string text)
	{
		if (Regex.IsMatch(text, @"^\s*$"))
		{
			return true;
		}
		return false;
	}
}
