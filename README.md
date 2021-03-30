# The ludo game - avslutande projekt

I detta projekt ska ni implementera ett fia spel (Ludo på engelska), med knuff. Spelet **ska** vara en .NET 5 konsol applikation.

Det ska gå att spela spelet via en konsol applikation, två till fyra spelare vid samma dator.

Koden ska vara uppdelat i en konsol applikation och en class library som innehåller all logik, låt oss kalla det vår spelmotor / game engine.

Spelet ska spara i en databas (med code first och Entity Framework), så att det går att ta fram historik på alla tidigare spel. Om applikationen skulle stängas ner, ska det gå att komma tillbaka in i spelet.

# Programmering

Kod ska ligga i mappen **Source**, varje team får enbart ha en solution fil!!

Se till att skåpa unit tests för spelet.

## Spelmotor (GameEngine)

Spelmotorn styra alla regler i spelet och kollar t.ex. om en spelpjäs får flyttas, om en spelar har vunnit, den initiala uppställning av alla spelpjäser på brädet, vilken spelar som är den nästa, hur en tärning ska bete sig, etc.

Implementera spelmotorn i ett separat klass bibliotek.

En instans av spelmotorn innehåller staten av ett helt spel, det skall vara möjligt att initialisera spelet med en given state, t.ek. om ska kunna spara och inläsa ett spel.

Skriv enhetstester på spelmotorn

# Dokumentation

Skriv [user stories](https://www.mountaingoatsoftware.com/agile/user-stories) (i **Documentation** mappen), och starta inte koda något innan in har skrivet minst 3 user stories, men helst så det täcker hela fia spelet / applikationen, men se hela tiden till att lägga till fler user stories.

Om ni använder någon externa källor (båda kod och annat) ange dom i dokumentationen.

Dokumentation ska skrivas med markdown (.md), ni väljer själv om ni vill skriva på svenska eller engelska, markdown filerna placeras i **Documentation** mappen.

# Betygsättning

Tillsammans med projektet ska skåpas en [video](video_presentaion.md) som beskriver projektet.

**Deadline, video i Stream**: 2021-04-13, kl 23:59

**Deadline, kod på GitHub**: 2021-04-14, kl 23:59

## Koden
Ni kan göra så många branches baserat på *main* som ni önskar. När projektet är slut är det innehållet av *main* på ert **GitHub**-repo som räknas.

## Element i bedömning

* Process (**viktigt**), hur har ni kommat fram till det slutliga resultat, ska framgå av dokumentation
  * Hur har ni ackaterat uppgiften
* Solutionen-filen ska beså av tre projekt:
  * En .NET 5 console-application
  * Class Library med en game engine / spel motor
  * Test projekt
* Koden kompilera och det går att köra projektet lokalt
  * Ingen beroende till externa/hosta databaser (ska kunna köra lokalt)
* All logik som rör spelet, även kast av tärning, är placerat i spelmotorn
* Dokumentation av spelets element, klasser och funktionalitet (**viktigt**)
  * Ska finnas i Documentation-mappen
  * Dokumentationen rekommenderas att uppdateras löpande
  * CRC cards
  * User stories
  * Use Case diagram 
* Spelet ska spara i en databas (med code first och Entity Framework) (**viktigt**)
* Det ska gå att skåpa ett eller fler spel
  * Så att flera spel kan vara på gång
* Det ska gå att försätta spela ett oavslutat eksisterende spel
* Automatiserade tester (**viktigt**) av spelmotor
  * Unit test
* Async kod (om det gir mening)
* Fluent API (om det gir mening)

Dom fyra element som är markerat med **viktigt** är så klart dom som är viktigast i samband med bedömningen. Och det är det som ni ska fokusera på i eran video presentation.

## Frivilliga element (kan göras som extra)

* Dokument databas (EXTRA)
  * T.ex. spara spel i JSON, slags backup
* Prestanda optimering (dokumentera ett aktivt val)
* Datatjänst
* AI spelare (så att man spela mot datorn) 
* Grafik representation av spelbräda (i konsollen)

# Tips

Tänka inte visuellt/grafisk/3D när ni gör eran datamodell!

Där er <u>ingen krav</u> på verken Async eller fluent api, det viktigaste är att data sparas i en SQL databas med EF, att koden är testat med automatiserade test och att koden är lätt läst + dokumenterat.

Gör en dagbok (journal / log) varje dag, också om ni gör något själv på en kväll, så att ni har koll på processen, och kan dokumentera den. Förslag gör det som markdown-dokument i *Dokumentation*-mappen.

Pro-tips: Project i GitHub