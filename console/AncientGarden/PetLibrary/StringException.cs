namespace PetLibrary;

using System.Text.RegularExpressions;
public static class StringException
{
  public static bool IsValidEmail(this string input) {
    return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
  }
}
