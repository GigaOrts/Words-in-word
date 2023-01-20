# Words-in-word
Написать функцию, которая для данного слова найдет все слова, которые можно собрать из букв данного слова. Слова вывести отсортированные лексикографически.

keyWord - исходное слово для генерации слов, 2 < длина <= 15
words - список слов, 0 < длина <= 15000 

Примеры

	слово: “арбуз”
	словарь: {“бра”, “раб”, “зубр”, “кот”, “ток”}
	результат: {“бра”, “зубр”, “раб”}

	слово: “мама”
	словарь: {“кот”, “ток”, “мимо”}
	результат: {}  - из букв заданного слова нельзя собрать ни одно слово из словаря, результат пустой массив
