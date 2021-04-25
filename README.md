## Spis treści
* [Ogólne informacje](#ogólne-informacje)
* [Użyte technologie](#użyte-technologie)
* [Zmiana kontrastu](#zmiana-kontrastu)
* [Prezentacja programu](#prezentacja-programu)

## Ogólne informacje
Program wykorzystuje algorytmy na zmianę kontrastu oraz tworzy histogramy dla składowych R, G i B.
<h2>Zmiana kontrastu:</h2>
<h3>Kontrast  poprzez zmianę kąta nachylenia prostej na wykresie odwzorowania kolorów:</h3>
 <img src="https://i.imgur.com/AHjo8zj.png" width="300" height="300">

*  <b>v’(x,y) = (127 / (127 - Δc)) * (v(x, y) - Δc)</b> = zwiększanie kontrastu 
*  <b>v’(x,y) = ((127 + Δc) / 127) * v(x, y) - Δc</b> = zmniejszenie kontrastu 

gdzie <b>Δc</b> jest wartością kontrastu w zakresie [0..127] dla przypadku zwiększania
 i wartością kontrastu w zakresie [−128..0) dla przypadku zmniejszania.
 
<h3>Kontrast  poprzez zmianę kąta nachylenia prostej na wykresie odwzorowania kolorów, ale osobno dla jasnych i osobno dla ciemnych punktów:</h3>
 <img src="https://i.imgur.com/sMUC5tQ.png" width="300" height="300">

a) 
<b>v’(x,y)= (127-Δc)/127)*v(x,y)</b>  &nbsp;&nbsp;&nbsp;dla  &nbsp;&nbsp;&nbsp;&nbsp;<b>v(x,y)<127 </b>
<b>(127-Δc)/127)*v(x,y)+2Δc</b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dla <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;v(x,y)≥127 </b>

b) 
<b>v’(x,y)= (127/(127+Δc))*v(x,y)</b> &nbsp;&nbsp;&nbsp;&nbsp;dla <b>&nbsp;&nbsp;&nbsp;v(x,y)<127+Δc </b>
<b>(127*v(x,y)+255*Δc)/(127+Δc) </b>&nbsp;&nbsp;dla &nbsp;&nbsp;&nbsp;<b>v(x,y)>127-Δc </b>
<b>127</b> dla pozostałych 

Przypadek (a) zwiększa kontrast obrazu dla parametru <b>0 < Δc < 127 </b>
Przypadek (b) zmniejsza kontrast obrazu dla parametru <b>−127 < Δc < 0</b>

	
## Użyte technologie
Projekt został utworzony z wykorzystaniem:
* Język C#
* Visual Studio 2019

## Prezentacja programu
[![IMAGE ALT TEXT](https://img.youtube.com/vi/glZpw8Bujrc/0.jpg)](https://www.youtube.com/watch?v=glZpw8Bujrc "Contrast Histogram")

