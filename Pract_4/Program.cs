using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pract_4;

string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
int cntSymbols = 5;
var monthsBySymbols = from symbol in months where symbol.Length == cntSymbols select symbol;
foreach (var l in monthsBySymbols) Console.WriteLine(l);
Console.WriteLine();

var monthsBySeasons = from character in months where (character.StartsWith('J') || character.StartsWith('F') || character.StartsWith('D') || character.StartsWith("Au")) select character;
foreach (var c in monthsBySeasons) Console.WriteLine(c);
Console.WriteLine();

var monthsInAlphOrder = from alph in months orderby alph select alph;
foreach (var a in monthsInAlphOrder) Console.WriteLine(a);
Console.WriteLine();

var monthsWithU = from uChar in months where (uChar.Contains("u") && uChar.Length >= 4) select uChar;
foreach (var u in monthsWithU) Console.WriteLine(u);
Console.WriteLine();

Time clock_1 = new Time(1,24,0);
clock_1.PrintTime();
Time clock_2 = new Time(0, 0, 10000);
clock_2.PrintTime();