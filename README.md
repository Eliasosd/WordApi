# WordApi

För att starta detta projekt krävs Visual Studio, med stöd för .NET 8.

Detta projekt innehåller ett API som har en funktion:
- Att räkna ord i en sträng.

Det krävs inget speciellt för att köra denna applikation, du kommer att behöva generera ett SSL-certifikat för att komma åt Swagger-gränssnittet, 
vill du inte göra det kan du även nyttja applikationen i inkognito-läge.

Du startar APIet genom att starta projektet i Visual Studio, din standardwebbläsare startas automatiskt och väl i Swaggergränssnittet kommer du
få upp det enda alternativet. Den POST-metod som finns tar emot ett json-objekt, så i detta objekt kan du klistra in lämplig text som du vill räkna
ord på.

APIet fungerar även mot kommandotolken, exempelanrop:
``curl -H "Content-type: application/json" -X "POST" -d "{\"text\":\"HÄR KAN DU SKRIVA IN DIN TEXT\"}" https://localhost:7108/WordCount``

Fungerar även mot Postman, där du i en ny request kan skapa på följande vis:
Skriv in ``https:://localhost:7108/WordCount`` i addressfältet och välj ``POST``.
Om det inte redan är förvalt, välj ``raw`` som input samt ``JSON`` i dropdownen.
``{
    "text": "HÄR KAN DU SKRIVA DEN TEXT DU VILL"
}``

För att du ska få en 200 respons, krävs att du fyller i en text, du kan inte lämna blankt eller endast mellanslag.
