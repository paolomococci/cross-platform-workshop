﻿namespace DummyRoster.Common;

public class Forecast
{
  public static readonly string[] Forecasts = new[] {
    "zero",
    "one",
    "two",
    "three",
    "four",
    "five",
    "six",
    "seven",
    "eight",
    "nine"
  };
  public DateTime NextDays { get; set; }
  public string Sample { get; set; } = "";
}
