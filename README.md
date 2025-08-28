# Назначение
Библиотека для натуральной сортировки строк:
|Исходная коллекция|Лексикографическая сортировка|Натуральная сортировка|
|------|------|------|
|OKR-8 |OKR-1 |OKR-1 |
|OKR-2 |OKR-10|OKR-2 |
|OKR-5 |OKR-2 |OKR-3 |
|OKR-10|OKR-3 |OKR-5 |
|OKR-3 |OKR-5 |OKR-8 |
|OKR-1 |OKR-8 |OKR-10|

# Пример использования
```cs
using NaturalSortLib;

var list = new List<string> { "item2", "item10", "item1" };
var comparer = new NaturalStringComparer(CultureInfo.CurrentCulture.CompareInfo);
var sortedList = list.OrderBy(s => s, comparer).ToList();
```