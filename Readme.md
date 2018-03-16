Projekt na PT
Mateusz Sobieszczyk
Michał Krzysztof Prusimski
Aleksander Wojciechowski


Klasa DNSwatcher jest klasą odpowiedzialną za obsługę śledzenia ruchu użytkownika w sieci. Stanowi istotną część projektu

Posiada konstruktor z argumentem typu bool - decyduje on czy przyjęta zostanie domyślna czarna lista
Posiada również drugi kontruktor przyjujący listę słów kluczowych będących szukanych w tablicy dns

Debugowanie, sprawdzanie działania

Projekt DNSwatcher posiada metodę debug która w obecnej wersji przeprowadza cykliczne co sekundę proces weryfikacji, analiza wywoływanych metod pozwala w przejrzysty sposób prześledzić schemat działania
