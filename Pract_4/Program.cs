using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pract_4;

//1 часть
string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
int cntSymbols = 5;
var monthsBySymbols = from symbol in months
                      where symbol.Length == cntSymbols
                      select symbol;
foreach (var l in monthsBySymbols) Console.WriteLine(l);
Console.WriteLine();

var monthsBySeasons = from character in months
                      where (character.StartsWith('J') || character.StartsWith('F') || character.StartsWith('D') || character.StartsWith("Au"))
                      select character;
foreach (var c in monthsBySeasons) Console.WriteLine(c);
Console.WriteLine();

var monthsInAlphOrder = from alph in months
                        orderby alph
                        select alph;
foreach (var a in monthsInAlphOrder) Console.WriteLine(a);
Console.WriteLine();

var monthsWithU = from uChar in months
                  where (uChar.Contains("u") && uChar.Length >= 4)
                  select uChar;
foreach (var u in monthsWithU) Console.WriteLine(u);
Console.WriteLine();



//2 часть
Time clock_2 = new Time(0, 0, 10000);
var rand= new Random();
clock_2.PrintTime();
clock_2.MoveSeconds(20);
clock_2.PrintTime();


List<Time> times = new();
times.Add(new Time(15, 15, 2));
times.Add(new Time(10, 10, 45));
for(int i = 0; i < 20; i++)
    times.Add(new Time(rand.Next(24), rand.Next(61), rand.Next(61)));

foreach (var item in times)
    item.PrintTime();

//время с заданным значением часа
Console.WriteLine("Введите нужный вам час!");
int needHour = Convert.ToInt32(Console.ReadLine());
var hourInTime = from hITime in times
                 where hITime.Hours == needHour
                 select hITime;
int k = hourInTime.Count();
if (k!=0)
{
    Console.WriteLine("Результат:");
    foreach (var hour in hourInTime) hour.PrintTime();
}
else Console.WriteLine("Часов с таким временем нет!");
//списки времен по группам: ночь, утро, день, вечер
var nightTime = from nTime in times
                where nTime.Hours > -1 && nTime.Hours < 6
                orderby nTime.Hours, nTime.Minutes,nTime.Seconds
                select nTime;
Console.WriteLine("Ночные часы: ");
foreach (var nH in nightTime) nH.PrintTime();

var morningTime = from mTime in times
                  where mTime.Hours > 5 && mTime.Hours < 12
                  orderby mTime.Hours, mTime.Minutes, mTime.Seconds
                  select mTime;
morningTime.ThenBy(p => p.Minutes).ThenBy(p => p.Seconds);
Console.WriteLine("Утренние часы: ");
foreach (var mH in morningTime) mH.PrintTime();

var dayTime = from dTime in times
                where dTime.Hours > 11 && dTime.Hours < 18
                orderby dTime.Hours, dTime.Minutes, dTime.Seconds
              select dTime;
dayTime.ThenBy(p => p.Minutes).ThenBy(p => p.Seconds);
Console.WriteLine("Дневные часы: ");
foreach (var dH in dayTime) dH.PrintTime();

var eveningTime = from eTime in times
                where eTime.Hours > 17 && eTime.Hours < 24
                orderby eTime.Hours, eTime.Minutes, eTime.Seconds
                  select eTime;
eveningTime.ThenBy(p => p.Minutes).ThenBy(p => p.Seconds);
Console.WriteLine("Вечерние часы: ");
foreach (var eH in eveningTime) eH.PrintTime();


//минимальное время
var minHour = nightTime.First();
Console.WriteLine("Минимальное время:");
minHour.PrintTime(); 

//первое время, в котором часы и минуты совпадают
var equalHourMinute = from eqHM in times
                      where eqHM.Hours==eqHM.Minutes
                      select eqHM;
var firstEq = equalHourMinute.First();
Console.WriteLine("Первое время с одинаковым часом и минутами:");
firstEq.PrintTime();

//упорядоченный список времен
var sortTimes = from t in times
                orderby t.Hours, t.Minutes, t.Seconds
                select t;
Console.WriteLine("Отсортирванный список времен: ");
foreach (var item in sortTimes) item.PrintTime();




