Се имплементира X-O игра со можност за играње против компјутер или против друг играч. Играта се игра така што се клика едно слободно копче од девет копчиња наредени во 3x3 табела, кое испишува X или O во зависност од кој е на ред. Целта е играчот да нареди три свои полиња во хоризонтална, вертикална или дијагонална линија.

#
_# Упатсво за користење_


 ![alt text](https://github.com/MetodiNakov123/X-O-/blob/master/X-O/%D0%9F%D1%80%D0%BE%D0%B7%D0%BE%D1%801.png)
 
 Слика 1
 


На слика 1 е прикажан почетната форма. Овде е даден насловот и две копчиња на кои се бира дали играчот сака да игра против компјутер или друг играч. Оваа форма води кон форма 2:


 ![](https://github.com/MetodiNakov123/X-O-/blob/master/X-O/%D0%9F%D1%80%D0%BE%D0%B7%D0%BE%D1%8021.png)

Слика 2.1
 

 ![](https://github.com/MetodiNakov123/X-O-/blob/master/X-O/%D0%9F%D1%80%D0%BE%D0%B7%D0%BE%D1%8022.png)

Слика 2.2

 

Форма 2 има две состојби. На слика 2.1 е прикажана првата, која се појавува кога играчот ќе избере да игра против компјутер. Овде има можност играчот да го внесе своето име, и да избере една од две тежини на компјутерот.

На слика 2.2 е прикажана втората состојба на форма 2, во која се внесуваат две имиња на двата играчи.  Оваа форма води кон главната форма, која е за играње.

![](https://github.com/MetodiNakov123/X-O-/blob/master/X-O/%D0%9F%D0%B7%D1%80%D0%BE%D0%B7%D0%BE%D1%80%203.png)

Слика 3



На слика 3 е прикажана главната форма, во која се одвива играта. Таа е составена од еден menuStrip кој содржи функции за нова игра, ресетирање на победи и излез. Под овој menuStrip се наоѓаат 9 копчиња кои се поставени во 3x3 матрица. Играчот нив ги притиска и тие испишуваат X или О во зависност од тоа кој играч го притиснал копчето. Со притискање на копче тоа повторно не може да се притисне, односно станува Disabled.

Под матрицата со копчиња се наоѓаат textbox p1 и p2, кои ги содржат имињата на играчите (или во едното пишува computer доколку играчот игра против компјутер).

Под нив се бројачите на победи. Тие бројат кој играч колку рунди победил, и колку од нив се нерешени. При победа на Играч 1 се зголемува бројот што се наоѓа под p1 и се

 ![](https://github.com/MetodiNakov123/X-O-/blob/master/X-O/prozor41.png)
 
 Слика 4

 

прикажува порака во MessageBox која вели дека Играч 1 победил.Истото важи и за нерешено и при победа на Играч 2.

#
# Алгоритми



Како податочна структура се користат самите елементи на главната форма. Копчињата се именувани по редица со буква (А,B или C) и по колона со број (1,2 или 3). Се добиваат копчињата A1,A2,B3,C3 итн... Со нив се манипулира за да се провери дали има победник и кое поле компјутерот да го одбери како негов следен потег.

 ![](https://github.com/MetodiNakov123/X-O-/blob/master/X-O/prozor6.png)

Слика 5

На слика 5 е прикажана функцијата која проверува дали има победник.  Проверува дали има 3 исти знаци хоризонтално, вертикално или дијагонално. Тоа го прави споредувајќи го текстот на копчињата. Ако пронајде победник (или е нерешено) ги заклучува сите копчиња и во messageBox кажува кој е победник.


 ![](https://github.com/MetodiNakov123/X-O-/blob/master/X-O/prozor5.png)

Слика 6


На оваа слика е прикажан алгоритмот за определување на следниот потег на компјутерот. На тежина Hard, компјутерот прво проверува дали може да ја победи играта, ако може ја завршува. Доколку тоа не е возможно, и ако противникот може да ја заврши играта во следниот негов потег, компјутерот тоа го спречува. Следен приоритет му е да го зафати средното поле. Доколку и тоа не успее да го направи, го зазема следното слободно поле.

На тежина Easy, приоритетите се сменети, односно компјутерот прво го блокира противникот, а потоа проверува дали може да ја заврши играта.





Изработиле:

Методи Наков, 161041

Илија Петров, 161203

Дејан Паунов, 162058
