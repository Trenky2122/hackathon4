Systém EntBa
==============

Navrhli a čiastočne implementovali sme kompletné riešenie od otváracieho systému až po webovú aplikáciu na zakladanie a schvaľovanie žiadostí o vstup. Riešenie pozostáva z niekoľkých komponentov. Na pozadí by mala bežať SQL databáza.

Základnou entitou je používateľ, ktorý vyplní svoje údaje pri registrácií. Na základe toho bude schopný podávať žiadosti o vstup, kde bude vedený skrz sériu otázok na určenie na základe čoho chce vstúpiť. Otázky mu budú kladené od najlacnejšej dane. Systém mu umožní doložiť všetky potrebné doklady. Na základe overenia s registrami systém buď žiadosť automaticky schváli alebo ju pošle na schválenie úradníkovi – administrátorovi. Automaticky schválené budú len tie žiadosti, pri ktorých sa v registri EČV ako držiteľ vozidla preukáže rovnaká osoba ako je používateľ. Inak nevieme s dostatočnou istotou overiť, či používateľ je naozaj osoba za ktorú sa vydáva (v prípade záujmu by magistrát mohol jednorázovo po osobnej kontrole verifikovať konto, overenie podľa majiteľa EČV by nemuselo byť následne povinné).

Administrátor bude po kontrole môcť žiadosť schváliť, zamietnuť alebo vyžiadať dodatočné doklady v prípade potreby. O každej akcii bude používateľ notifikovaný poštou alebo v prípade záujmu SMS/WhatsApp správou. Každá schválená žiadosť vytvorí záznam do tabuľy EntrancePermissions.
Presunieme sa do bodu keď používateľ príde autom k blokáde. Keďže predpokladáme, že pamiatkari nebudú súhlasiť s použitím klasickej rampy, budeme pracovať so stĺpikom. Pri stĺpiku budú umiestnené 4 kamery alebo 2 kamery a tlakové senzory na detekciu prechodu auta. Kamery sú napojené na systém DTK LPR Solution, ktorý je schopný rozoznávať EČV auta. Prvá kamera zaznamenáva prichádzajúce autá. Systém rozozná EČV a notifikuje náš komponent na správu pylónu. Kompomnent preverí, či je EČV povolená a na základe toho otvorí pylón alebo nie. Ak sa pylón otvorí, auto prejde dnu a po prechode ho nasníma druhá kamera taktiež napojená na DTK LPR Solution. Tá po nasnímaní zadnej ŠPZ pošle request do správcu pylóna. Ten zavrie pylón a založí daňovú povinnosť pre používateľa (podobne by mohol namiesto zadnej kamery fungovať tlakový senzor). Podobne pri východe systém všetky ŠPZ pustí, ale zaznamenáva ich. Ak na niektorej z posledných 3 kamier zachytí neautorizovaný vstup, automaticky uloží pokutu. Pre ŠPZ ktoré nájde v systéme automaticky upovedomí používateľa mailom, pri ostatných upovedomí administrátora s vygenerovaným dokumentom, ktorý bude nutné poslať pravdepodobne poštou. Všetky vstupy sú zároveň aj s časovými pečiatkami uložené v tabuľke entrances, takže prípadné dôkazy sa vždy dajú nájsť v kamerových záznamoch. Systém tiež môže obsahovať senzor merania vzdialenosti (infracčervený alebo laserový) zabudovaný do podstavca stĺpiku a nasmerovaný na oblohu. Ten by bol prepojený s blízkym počítačom (môže byť ten istý, na ktorom bude bežať DTK LPR Solution). Na tomto pc môže bežať proces, ktorý v jednosekundových intervaloch meria vzdialenosť smerom hore. Akonáhle zaznamená ľubovoľný objekt vo výške 1.5 * výška stĺpika nad sebou počas cesty hore, stiahne stĺpik dole. Ak by však bol stĺpik dole pridlho, notifikuje emailom administrátora aby situáciu na kamere preveril a prípadne proces dočasne zastavil. Systém bude taktiež rozpoznávať kľúčové slová na vozidlách ako ambulancia, polícia, či hasiči. Pri záchranných zložkách využijeme aj decibelmeter, ktorý pomôže rozpoznať sirény.

Systém tiež bude obsahovať notifikačný servis ktorý bude posielať upomienky na blížiace sa konce splatnosti. Tiež systém na kontrolu bankového api a priradenie platby podľa variabilného symbolu.
