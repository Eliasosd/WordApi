# WordApi

För att starta detta projekt krävs en lämplig IDE, med stöd för .NET 8 samt installerad .NET SDK (Applikationen är skriven och testad i Visual Studio 17.9.6).

Detta projekt innehåller ett API som har en funktion:
- Att räkna ord i en sträng.

Det krävs inget speciellt för att köra denna applikation, du kan eventuellt behöva generera ett SSL-certifikat för att komma åt Swagger-gränssnittet,
Vilket du i så fall ombeds att göra när du startar projektet. Vill du inte göra det kan du även nyttja applikationen i inkognito-läge i webbläsaren.

Du startar APIet genom att starta projektet i Visual Studio som vanligt, din standardwebbläsare startas automatiskt och väl i Swaggergränssnittet kommer du
få upp ett enda alternativ, den POST-metod som finns tar emot ett json-objekt, så i detta objekt kan du klistra in lämplig text som du vill räkna
ord på.

Vill du köra genom Swagger:
- Klicka på ``/WordCount``
- Klicka på ``Try it out``
- Ersätt ``string`` med den text som du vill räkna ord på.

APIet fungerar även mot kommandotolken, exempelanrop:
``curl -H "Content-type: application/json" -X "POST" -d "{\"text\":\"HÄR KAN DU SKRIVA IN DIN TEXT\"}" https://localhost:7108/WordCount``

Fungerar även mot Postman, där du i en ny request kan skapa på följande vis:
Skriv in ``https:://localhost:7108/WordCount`` i addressfältet och välj ``POST``.
Om det inte redan är förvalt, välj ``raw`` som input samt ``JSON`` i dropdownen.
``{
    "text": "HÄR KAN DU SKRIVA DEN TEXT DU VILL"
}``

För att du ska få en 200 respons, krävs att du fyller i en text, du kan inte lämna blankt eller endast mellanslag.

Hoppas du får nöje i att använda denna applikation!
EliasOsd
