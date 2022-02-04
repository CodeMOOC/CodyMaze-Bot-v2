using CodyMazeBot;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello, World!");

var loggerFactory = new LoggerFactory();

Storage s = new(loggerFactory.CreateLogger<Storage>());

await s.StoreEvent("neoconnessi", new CodyMazeBot.StoreModels.Event
{
    Title = new Dictionary<string, string>
    {
        { "it", "Neoconnessi" },
        { "en", "Neoconnessi" },
    },
    Questionnaire = null,
    Code = "neoconnessi",
    Grid = new Dictionary<string, CodyMazeBot.StoreModels.GridCell>
    {
        { "a1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "safebrowsing", HasStar = true } },
        { "a2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "cybersecurity", HasStar = false } },
        { "a3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "internetatschool", HasStar = false } },
        { "a4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "gaming", HasStar = true } },
        { "a5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "identity", HasStar = false } },

        { "b1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "trust", HasStar = true } },
        { "b2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "geolocalization", HasStar = false } },
        { "b3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "competences", HasStar = false } },
        { "b4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "virtualreality", HasStar = false } },
        { "b5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "phishing", HasStar = false } },

        { "c1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "rights", HasStar = false } },
        { "c2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "revolution", HasStar = false } },
        { "c3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "web", HasStar = false } },
        { "c4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "devices", HasStar = false } },
        { "c5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "fakenews", HasStar = true } },

        { "d1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "health", HasStar = false } },
        { "d2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "cloud", HasStar = false } },
        { "d3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "socialmedia", HasStar = false } },
        { "d4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "email", HasStar = false } },
        { "d5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "screentime", HasStar = false } },

        { "e1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "bullying", HasStar = false } },
        { "e2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "behavior", HasStar = true } },
        { "e3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "passwords", HasStar = false } },
        { "e4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "cookies", HasStar = false } },
        { "e5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "privacy", HasStar = false } },
    }
});

Dictionary<string, string> Ita(string v) => new Dictionary<string, string>
{
    { "it", v }
};

async Task AddCategory(string categoryName, string categoryTitle, params CodyMazeBot.StoreModels.Question[] questions)
{
    await s.StoreCategory("neoconnessi", categoryName, new CodyMazeBot.StoreModels.Category
    {
        Code = categoryName,
        Title = Ita(categoryTitle),
    });

    foreach(var q in questions) {
        await s.AddQuestion("neoconnessi", categoryName, q);
    }
}

await AddCategory("safebrowsing", "Navigazione sicura",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Secondo te, quale di questi è uno strumento che permette l’uso in sicurezza dello smartphone?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Il controllo parentale (o parental control)"),
            Ita("Il salvaschermo"),
            Ita("La funzione allarme")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Se ti parlo di “navigazione sicura”, secondo te cosa intendo?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Saper navigare in Internet con attenzione e consapevolezza"),
            Ita("Mettere una password al mio smartphone"),
            Ita("Permettere ai genitori di leggere i tuoi messaggi")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Ricevi un messaggio da un numero di telefono sconosciuto che ti chiede di cliccare su un link per ritirare un favoloso dono. Cosa fai?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Lo mostro a un adulto, perché mi insospettisce un po’, e non clicco sul link"),
            Ita("Clicco subito: chissà chi mi ha fatto quel meraviglioso regalo!"),
            Ita("Lo inoltro a tutti i miei amici, saranno così contenti!")
        }
    }
);

await AddCategory("screentime", "Screen Time",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Hai mai sentito parlare di “screen time”? Cosa significa?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Il tempo trascorso davanti a uno schermo, computer, tv, tablet o smartphone"),
            Ita("L’età di un dispositivo digitale"),
            Ita("Il tempo trascorso dall’invenzione del primo schermo")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Quando giochi con la tua console o navighi su Internet, il tempo passa velocemente. Per evitare conseguenze sulla tua salute, qual è il tempo massimo per stare davanti a uno schermo?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Non più di 2 ore al giorno"),
            Ita("Tutto il tempo che voglio, perché la Rete offre tantissime opportunità"),
            Ita("Se mi diverto non può farmi male")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("A quale distanza dovresti stare dallo schermo del computer?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Tra 50 e 80 cm"),
            Ita("Meno di 50 cm"),
            Ita("Più di 80 cm")
        }
    }
);

await AddCategory("bullying", "Bullismo e cyberbullismo",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Qualcuno della tua classe ha mandato in giro la foto imbarazzante di un compagno. Cosa dovresti fare?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Mostro la foto al mio insegnante e racconto cosa è successo"),
            Ita("Inoltro la foto ad altre persone"),
            Ita("Salvo la foto sul mio tuo telefono, potrebbe sempre servire!")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Sto per scrivere la mia opinione su Internet…"),
        Answers = new Dictionary<string, string>[] {
            Ita("Devo pensare prima di scrivere per non offendere chi legge"),
            Ita("Posso dire quello che voglio perché nessuno mi vede"),
            Ita("Non posso farlo, su Internet nessuno esprime veramente quello che pensa")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Se qualcuno mi mette a disagio o mi spaventa in Rete…"),
        Answers = new Dictionary<string, string>[] {
            Ita("Ne parlo con i miei genitori, con l’insegnante o con un’altra persona adulta di cui mi fido"),
            Ita("Non ne parlo con nessuno perché mi vergogno"),
            Ita("Rispondo con un insulto perché non avrebbe dovuto farlo")
        }
    }
);

await AddCategory("internetatschool", "Internet a scuola",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Internet è utile per tante cose, anche per studiare. Quando avete la possibilità di usarlo in classe, quale di questi è un uso consentito?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Navigare con la supervisione dell’insegnante"),
            Ita("Chattare con i miei compagni mentre l’insegnante parla"),
            Ita("Controllare la classifica della mia squadra preferita")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("La tua scuola è piena di strumenti digitali. Quando guardi la LIM hai davanti…"),
        Answers = new Dictionary<string, string>[] {
            Ita("Una lavagna interattiva multimediale"),
            Ita("Una lima molto piccola"),
            Ita("Il registro elettronico")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Porti a scuola il tuo smartphone? Se sì, qual è l’uso corretto?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Usarlo per svolgere ricerche o attività didattiche, se l’insegnante lo consente"),
            Ita("Tenerlo sempre spento"),
            Ita("Tenerlo sempre acceso, così se mi chiamano i miei genitori posso rispondere!")
        }
    }
);

await AddCategory("geolocalization", "Geolocalizzazione",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Secondo te, cosa vuol dire “geolocalizzazione”?"),
        Answers = new Dictionary<string, string>[] {
            Ita("È l'identificazione di dove si trova un oggetto, come lo smartphone"),
            Ita("È l’atteggiamento di chi resta fermo in un posto ben preciso "),
            Ita("È un modo di indicare le mappe online")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cosa ti permette di fare la geolocalizzazione?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Raggiungere il posto che cerco, utilizzando le mappe"),
            Ita("Spiare i miei amici per vedere dove si trovano"),
            Ita("Niente, la geolocalizzazione non va mai attivata perché è pericolosa")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Sul tuo smartphone, quale di questi sistemi è collegato alle funzioni di geolocalizzazione?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Il GPS"),
            Ita("La batteria"),
            Ita("Il salvaschermo")
        }
    }
);

await AddCategory("trust", "Fiducia e controllo",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Hai perso il cellulare: che tragedia! E ora cosa fai?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Lo dico ai miei genitori o all’insegnante, e valuto di andare alla polizia "),
            Ita("Non dico niente a nessuno per evitare di essere sgridato"),
            Ita("Prendo di nascosto quello di un compagno")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Se i tuoi genitori installano il controllo parentale sul tuo computer, cosa significa?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Che mi permettono di usare lo smartphone in tranquillità, proteggendomi dai contenuti non adatti alla mia età"),
            Ita("Che non hanno fiducia in me e vogliono controllarmi"),
            Ita("Che mi vietano l’utilizzo dei giochi")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Immagina di ricevere un messaggio da parte di uno sconosciuto: lo leggi e…"),
        Answers = new Dictionary<string, string>[] {
            Ita("Ne parlo con i miei genitori"),
            Ita("Rispondo subito, sono una persona educata!"),
            Ita("Penso che potremmo fare amicizia")
        }
    }
);

await AddCategory("privacy", "Privacy e impronta digitale",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Nel linguaggio digitale, se dico “privacy”, cosa intendo?"),
        Answers = new Dictionary<string, string>[] {
            Ita("La tutela delle informazioni personali e della vita privata"),
            Ita("L’insieme dei beni digitali di una persona: in italiano si traduce con “privato”"),
            Ita("I dati che vorrei avere, ma non ho: in italiano si traduce con “privazione”")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Immagina di ricevere un messaggio da uno sconosciuto che ti chiede qual è la tua password. Come reagisci?"),
        Answers = new Dictionary<string, string>[] {
            Ita("So che sono informazioni riservate, quindi non gli rispondo e ne parlo con un adulto"),
            Ita("Gliela scrivo, tanto come potrebbe mai usarla?!"),
            Ita("Gli chiedo prima a cosa gli serve")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Perché devi fare attenzione quando posti una fotografia, un video o un commento online?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Perché tutto ciò che pubblico resta online e sarà visibile a tante persone"),
            Ita("Perché qualcuno potrebbe dirlo ai miei genitori e potrei ricevere una sgridata"),
            Ita("Non c’è motivo di stare attenti: chi guarderà mai le mie cose?!")
        }
    }
);

await AddCategory("phishing", "Phishing",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Hai mai sentito parlare di “phishing”? Sai cos’è?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Una truffa online per sottrarre password e dati di accesso"),
            Ita("Una tecnica di pesca diventata popolare negli anni ‘90 grazie a un gioco online"),
            Ita("Un’email inviata per sbaglio")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Il “phishing” è una truffa che avviene online, spesso con un messaggio ingannevole per rubare i tuoi dati. Come lo puoi riconoscere facilmente?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Cerca di attirare l’attenzione, con un contenuto forte come “Hai vinto un milione di euro!” o “Hai vinto uno smartphone favoloso!”"),
            Ita("In genere è un messaggio molto curato, senza errori di ortografia"),
            Ita("Arriva da una persona che conosco bene")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("“Phishing” è una parola inglese che indica…"),
        Answers = new Dictionary<string, string>[] {
            Ita("L’invio di messaggi pubblicitari non richiesti a un vasto pubblico"),
            Ita("L’acqua, il succo di frutta o altri liquidi rovesciati sulla tastiera "),
            Ita("La pubblicazione di un commento negativo su qualcosa")
        }
    }
);

await AddCategory("fakenews", "Fake news",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Le fake news sono nate con Internet?"),
        Answers = new Dictionary<string, string>[] {
            Ita("No, sono sempre esistite"),
            Ita("Sì, prima non esistevano"),
            Ita("Le fake news non esistono")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Che cosa sono le fake news?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Notizie false per catturare la tua attenzione"),
            Ita("Notizie vere e attendibili"),
            Ita("Notizie vere ma scritte o pubblicate in modo anonimo")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cosa devi fare per scoprire se quelle che leggi sono fake news?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Controllare la fonte della notizia (il sito dove compare e l’autore)"),
            Ita("Controllare la lunghezza dell’articolo: se è troppo lungo, la notizia non può essere vera"),
            Ita("Nessuna: non è possibile distinguere le fake news dalle notizie vere")
        }
    }
);

await AddCategory("identity", "Identità digitale",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("A che cosa pensi quando senti dire “identità digitale”?"),
        Answers = new Dictionary<string, string>[] {
            Ita("All’insieme dei dati e delle informazioni di un utente che si trovano online"),
            Ita("All’avatar con cui si interagisce nella comunità virtuale"),
            Ita("Alla carta d’identità elettronica ")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("La tua identità digitale è…"),
        Answers = new Dictionary<string, string>[] {
            Ita("Tanto importante quanto quella reale perché riguarda i miei dati personali e sensibili"),
            Ita("Meno importante di quella reale perché tanto è falsa"),
            Ita("Importantissima, perché da questa dipende il modo con cui gli amici mi percepiscono sui social media")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cosa consiglieresti a un tuo amico per proteggere la sua identità digitale?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Di navigare su siti sicuri e utilizzare password non facilmente decifrabili"),
            Ita("Di non usare mai password troppo complicate"),
            Ita("Di non farsi troppi problemi e lasciare pure in giro tutti i suoi dati personali")
        }
    }
);

await AddCategory("behavior", "Comportamento in Rete",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cos’è la “netiquette”?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Sono le regole del buon comportamento di un utente sul Web"),
            Ita("Sono degli adesivi da inviare online"),
            Ita("Sono le leggi che governano i social network")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Quale di questi comportamenti è assolutamente da evitare quando navighi?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Diffondere foto e informazioni personali dei tuoi amici"),
            Ita("Nessuno, in Internet si può fare tutto"),
            Ita("Fare recensioni su un prodotto acquistato online")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("La regola d’oro della netiquette è:"),
        Answers = new Dictionary<string, string>[] {
            Ita("Ricorda che anche sul Web siamo sempre persone"),
            Ita("Metti una faccina in ogni messaggio"),
            Ita("Non rispondere mai a nessuno")
        }
    }
);

await AddCategory("passwords", "Password sicure",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Quale di queste password è la più sicura?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Una password non riferita a informazioni che mi riguardano, con lettere maiuscole, numeri e caratteri speciali"),
            Ita("123456, perchè è talmente semplice che sono sicuro di non dimenticarla"),
            Ita("La mia data di nascita, perchè molti non la sanno e io sì")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cosa consiglieresti a un tuo amico per avere password veramente sicure?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Scegliere password sempre diverse"),
            Ita("Scegliere sempre password uguali per non dimenticarle"),
            Ita("Scegliere password semplici come il suo nome")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Quando si parla di sicurezza online, cosa si intende per “PIN”?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Personal Identity Number: è una password"),
            Ita("Un suono emesso dal computer"),
            Ita("Pure Internet Navigation: è un sito web affidabile")
        }
    }
);

await AddCategory("gaming", "Gaming",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("C’è un tempo massimo che dovresti dedicare ai videogiochi?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Non più di 2 ore al giorno"),
            Ita("No, posso starci quanto mi pare"),
            Ita("I videogiochi non vanno mai utilizzati")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Se qualcuno che non conosci ti contatta nella chat del gioco cosa devi fare? "),
        Answers = new Dictionary<string, string>[] {
            Ita("Non rispondere e continuare a giocare solo con chi conosco "),
            Ita("Rispondere subito: abbiamo degli interessi comuni"),
            Ita("Spegnere il computer e cambiare subito gioco")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("I videogiochi sono:"),
        Answers = new Dictionary<string, string>[] {
            Ita("Un’alternativa per giocare insieme agli amici, anche a distanza"),
            Ita("Un’attività solitaria, ma molto divertente"),
            Ita("Una perdita di tempo")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Quale tipologia di videogiochi consente di giocare insieme nella stessa stanza?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Gli exergame, i videogiochi che uniscono divertimento e allenamento"),
            Ita("I videogiochi in cui si può giocare contro il computer"),
            Ita("Tutte le categorie di videogiochi")
        }
    }
);

await AddCategory("cookies", "Cookie",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Hai appena accettato un Cookie. Cosa ti aspetti che faccia?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Che raccolga dati sulla mia attività online per migliorare la navigazione"),
            Ita("Che nutra i miei avatar, ghiotti di biscotti al cioccolato"),
            Ita("Che mi compaia sullo schermo quando non lo uso per un po’")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Quali di queste sono funzioni tipiche dei Cookie?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Salvare i dati evitando una nuova autenticazione in una visita successiva "),
            Ita("Ripulire la memoria dello smartphone, per renderlo più prestante"),
            Ita("Bloccare i virus")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Apri un sito web e compare una schermata che ti informa della presenza di Cookie. Cosa fai?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Leggo attentamente le indicazioni sul loro utilizzo e decido di conseguenza"),
            Ita("Finalmente, Cookie è il mio orsacchiotto preferito!"),
            Ita("Comunque dico di no: i Cookie non vanno mai accettati")
        }
    }
);

await AddCategory("competences", "Competenze digitali",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cosa devi sempre fare quando sei online?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Essere responsabile"),
            Ita("Tenere in ordine la camera"),
            Ita("Non buttare cartacce a terra")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cosa significa “smart”?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Intelligente e attento"),
            Ita("Simpatico e di bell’aspetto"),
            Ita("Banale, ovvio")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cos’è l’empatia digitale?"),
        Answers = new Dictionary<string, string>[] {
            Ita("La capacità di interagire con le persone anche a distanza, instaurando relazioni sane e positive"),
            Ita("La capacità di usare bene tutti i device, senza chiedere aiuto a nessuno"),
            Ita("La capacità di riconoscere le fake news")
        }
    }
);

await AddCategory("rights", "Diritti e doveri online",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Come si chiama l’insieme dei tuoi diritti e dei tuoi doveri online?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Cittadinanza digitale"),
            Ita("Decalogo digitale"),
            Ita("Regole digitali")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Per essere un buon cittadino digitale devi:"),
        Answers = new Dictionary<string, string>[] {
            Ita("Conoscere i propri diritti e doveri in Rete, per agire in modo corretto"),
            Ita("Fare in Rete tutto ciò che si vuole, perché Internet è spazio libero"),
            Ita("Non seguire nessuna regola, perché la Rete non è la vita reale")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Quale di questi è uno degli articoli contenuti nella “Dichiarazione dei diritti in Internet”"),
        Answers = new Dictionary<string, string>[] {
            Ita("Sono vietati l’accesso e il trattamento dei dati con finalità anche indirettamente discriminatorie"),
            Ita("Si può accedere a internet solo a determinate condizioni"),
            Ita("Ognuno su Internet ha il diritto di fare ciò che vuole, senza nessun tipo di conseguenza")
        }
    }
);

await AddCategory("devices", "Device e tecnologia",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("La tecnologia offre numerosi vantaggi alle nostre vite. Quale dei seguenti è corretto?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Possiamo restare in contatto con familiari, amici, compagni di scuola e insegnanti anche quando si è distanti"),
            Ita("Possiamo prendere virus anche attraverso il computer"),
            Ita("Finalmente viviamo tutti davanti a uno schermo 24 ore su 24!")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Ti sei appena sdraiato sul divano per leggere un ebook. Quale device tieni in mano?"),
        Answers = new Dictionary<string, string>[] {
            Ita("L’ebook reader"),
            Ita("Lo smartphone"),
            Ita("Il mouse")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Che cos’è un device?"),
        Answers = new Dictionary<string, string>[] {
            Ita("È un dispositivo elettronico, come lo smartphone"),
            Ita("È un’applicazione"),
            Ita("È un mezzo di trasporto")
        }
    }
);

await AddCategory("health", "Salute e benessere digitale",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("La lettura sullo schermo di un computer è diversa dalla lettura su carta e spesso richiede alla vista:"),
        Answers = new Dictionary<string, string>[] {
            Ita("Un lavoro più faticoso"),
            Ita("Un lavoro più semplice "),
            Ita("Non ci sono differenze")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cosa si intende per “benessere digitale”?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Un buon equilibrio tra attività online e vita reale"),
            Ita("La speranza che i computer non prendano virus"),
            Ita("La necessità di giocare sempre")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Prima di andare a dormire…"),
        Answers = new Dictionary<string, string>[] {
            Ita("Spengo il telefono… Lo riaccenderò domattina!"),
            Ita("Posso usare il telefono fino a tardi se non riesco ad addormentarmi"),
            Ita("Non uso il telefono ma lo tengo comunque acceso, non si sa mai!")
        }
    }
);

await AddCategory("revolution", "Rivoluzione tecnologica",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Dove è avvenuta la prima connessione Internet?"),
        Answers = new Dictionary<string, string>[] {
            Ita("In università"),
            Ita("A Hollywood"),
            Ita("Nello spazio")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Il 5G è uno dei passi fondamentali del prossimo futuro perché…"),
        Answers = new Dictionary<string, string>[] {
            Ita("Renderà più efficienti le nostre telecomunicazioni"),
            Ita("Permetterà di volare"),
            Ita("Aprirà le porte alla comunicazione con abitanti di altri pianeti")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Che cosa significa WWW?"),
        Answers = new Dictionary<string, string>[] {
            Ita("World Wide Web"),
            Ita("World Wide Win"),
            Ita("World Wide Wire")
        }
    }
);

await AddCategory("virtualreality", "Realtà virtuale",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Che cos’è la realtà virtuale?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Un ambiente simile alla realtà ricreato da un computer"),
            Ita("La realtà circostante"),
            Ita("Un altro modo per chiamare la Rete")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cosa si intende per “realtà aumentata”?"),
        Answers = new Dictionary<string, string>[] {
            Ita("L'integrazione della realtà circostante con immagini generate dal computer"),
            Ita("La vita delle persone famose"),
            Ita("La realtà virtuale")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Quale dispositivo è utile per entrare nella realtà virtuale?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Un visore VR"),
            Ita("Un paio di occhiali da sole"),
            Ita("Un mouse wireless")
        }
    }
);

await AddCategory("web", "La Rete e Internet",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Un browser è…"),
        Answers = new Dictionary<string, string>[] {
            Ita("Un programma per navigare su Internet"),
            Ita("Un altro modo per dire Internet"),
            Ita("Un personaggio di Super Mario")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cosa vuol dire e cosa indica la parola “web”?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Significa “ragnatela” e indica la rete dei siti Internet"),
            Ita("Significa “connessione” e indica la rete a cui si connettono gli smartphone"),
            Ita("È il nome in codice dell’inventore di Internet")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cos’è un motore di ricerca?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Un programma che aiuta a cercare informazioni in rete"),
            Ita("Uno scooter di ultima generazione"),
            Ita("Un'applicazione pensata per studiare")
        }
    }
);

await AddCategory("cybersecurity", "Cybersecurity",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Immagina da grande di diventare un esperto di cybersecurity. Di cosa ti occuperai principalmente?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Di processi e tecnologie che hanno l’obiettivo di proteggere le persone dagli attacchi in Rete"),
            Ita("Dell’attività dei ladri che cercano di rubare computer"),
            Ita("Di una serie di regole per difendersi dall’Intelligenza Artificiale")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Chi o cosa sono gli hacker?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Pirati informatici"),
            Ita("Piccoli insetti"),
            Ita("Sistemi di sicurezza informatica")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Un esperto di informatica ti ha appena parlato di “firewall”, che cosa intendeva?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Il sistema che protegge i tuoi dispositivi da situazioni rischiose"),
            Ita("Il sistema antincendio del computer"),
            Ita("Un programma di attacco usato dagli hacker")
        }
    }
);

await AddCategory("cloud", "Il Cloud",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cloud in inglese significa “nuvola”, ma nel mondo digitale cos’è?"),
        Answers = new Dictionary<string, string>[] {
            Ita("La tecnologia che permette di elaborare e archiviare dati in Rete"),
            Ita("Quando lo schermo dello smartphone si annebbia"),
            Ita("La nuvola digitale formata da tutti i siti web")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Cosa ti permette di fare il Cloud?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Conservare foto, documenti e contatti per non perderli anche se cambi telefono"),
            Ita("Risparmiare batteria sul tuo cellulare"),
            Ita("Scaricare tutte le applicazione gratuitamente")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Quale di queste parole indica uno spazio su Internet per salvare copie dei propri file?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Cloud"),
            Ita("Metaverso"),
            Ita("Big Data")
        }
    }
);

await AddCategory("socialmedia", "Utilizzo dei Social Media",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Quali di questi sono dei social media?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Instagram, TikTok e Twitch"),
            Ita("Google e Chrome"),
            Ita("Netflix e Disney+")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("C’è un’età minima per iscriversi sui social media?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Sì, i social media hanno un’età minima per l’iscrizione (14 anni) ma devo comunque chiedere il consenso ai miei genitori"),
            Ita("No, mi iscrivo quando voglio"),
            Ita("No, lo decidono i miei genitori")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Quali contenuti ci sono su TikTok?"),
        Answers = new Dictionary<string, string>[] {
            Ita("Challenge e balletti divertenti"),
            Ita("Testi lunghi e noiosi"),
            Ita("Gli stessi contenuti che si vedono in TV")
        }
    }
);

await AddCategory("email", "Utilizzo delle email",
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Se i destinatari della tua email sono in Copia Carbone Nascosta (CCN), significa che…"),
        Answers = new Dictionary<string, string>[] {
            Ita("Il loro indirizzo non appare agli altri destinatari del messaggio"),
            Ita("Non leggono il mio messaggio"),
            Ita("Ricevono il mio messaggio senza oggetto")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Qual è il simbolo presente in ogni indirizzo di posta elettronica?"),
        Answers = new Dictionary<string, string>[] {
            Ita("@"),
            Ita(";-)"),
            Ita("#")
        }
    },
    new CodyMazeBot.StoreModels.Question
    {
        QuestionText = Ita("Per scrivere una buona email…"),
        Answers = new Dictionary<string, string>[] {
            Ita("Inserisci sempre un “oggetto” chiaro e preciso, per far capire al tuo destinatario il contenuto della mail"),
            Ita("Bisogna firmare sempre con un nickname"),
            Ita("Bisogna scrivere tutto in stampatello maiuscolo")
        }
    }
);

Console.WriteLine("All done?");
