using CodyMazeBot;

namespace MazeInstaller {
    internal class NeoConnessiInstaller : IInstaller {
        const string EventName = "neoconnessi";

        public async Task Install(Storage s) {
            await s.StoreEvent(EventName, new CodyMazeBot.StoreModels.Event {
                Title = new Dictionary<string, string>
                {
                    { "it", "Neoconnessi" },
                    { "en", "Neoconnessi" },
                },
                Questionnaire = null,
                Code = EventName,
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

            await Util.AddCategory(s, EventName, "safebrowsing", Util.Ita("Navigazione sicura"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Secondo te, quale di questi è uno strumento che permette l’uso in sicurezza dello smartphone?"),
                    Answers = [
                        Util.Ita("Il controllo parentale (o parental control)"),
                        Util.Ita("Il salvaschermo"),
                        Util.Ita("La funzione allarme")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Se ti parlo di “navigazione sicura”, secondo te cosa intendo?"),
                    Answers = [
                        Util.Ita("Saper navigare in Internet con attenzione e consapevolezza"),
                        Util.Ita("Mettere una password al mio smartphone"),
                        Util.Ita("Permettere ai genitori di leggere i tuoi messaggi")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Ricevi un messaggio da un numero di telefono sconosciuto che ti chiede di cliccare su un link per ritirare un favoloso dono. Cosa fai?"),
                    Answers = [
                        Util.Ita("Lo mostro a un adulto, perché mi insospettisce un po’, e non clicco sul link"),
                        Util.Ita("Clicco subito: chissà chi mi ha fatto quel meraviglioso regalo!"),
                        Util.Ita("Lo inoltro a tutti i miei amici, saranno così contenti!")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "screentime", Util.Ita("Screen Time"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Hai mai sentito parlare di “screen time”? Cosa significa?"),
                    Answers = [
                        Util.Ita("Il tempo trascorso davanti a uno schermo, computer, tv, tablet o smartphone"),
                        Util.Ita("L’età di un dispositivo digitale"),
                        Util.Ita("Il tempo trascorso dall’invenzione del primo schermo")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quando giochi con la tua console o navighi su Internet, il tempo passa velocemente. Per evitare conseguenze sulla tua salute, qual è il tempo massimo per stare davanti a uno schermo?"),
                    Answers = [
                        Util.Ita("Non più di 2 ore al giorno"),
                        Util.Ita("Tutto il tempo che voglio, perché la Rete offre tantissime opportunità"),
                        Util.Ita("Se mi diverto non può farmi male")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("A quale distanza dovresti stare dallo schermo del computer?"),
                    Answers = [
                        Util.Ita("Tra 50 e 80 cm"),
                        Util.Ita("Meno di 50 cm"),
                        Util.Ita("Più di 80 cm")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "bullying", Util.Ita("Bullismo e cyberbullismo"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Qualcuno della tua classe ha mandato in giro la foto imbarazzante di un compagno. Cosa dovresti fare?"),
                    Answers = [
                        Util.Ita("Mostro la foto al mio insegnante e racconto cosa è successo"),
                        Util.Ita("Inoltro la foto ad altre persone"),
                        Util.Ita("Salvo la foto sul mio tuo telefono, potrebbe sempre servire!")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Sto per scrivere la mia opinione su Internet…"),
                    Answers = [
                        Util.Ita("Devo pensare prima di scrivere per non offendere chi legge"),
                        Util.Ita("Posso dire quello che voglio perché nessuno mi vede"),
                        Util.Ita("Non posso farlo, su Internet nessuno esprime veramente quello che pensa")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Se qualcuno mi mette a disagio o mi spaventa in Rete…"),
                    Answers = [
                        Util.Ita("Ne parlo con i miei genitori, con l’insegnante o con un’altra persona adulta di cui mi fido"),
                        Util.Ita("Non ne parlo con nessuno perché mi vergogno"),
                        Util.Ita("Rispondo con un insulto perché non avrebbe dovuto farlo")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "internetatschool", Util.Ita("Internet a scuola"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Internet è utile per tante cose, anche per studiare. Quando avete la possibilità di usarlo in classe, quale di questi è un uso consentito?"),
                    Answers = [
                        Util.Ita("Navigare con la supervisione dell’insegnante"),
                        Util.Ita("Chattare con i miei compagni mentre l’insegnante parla"),
                        Util.Ita("Controllare la classifica della mia squadra preferita")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("La tua scuola è piena di strumenti digitali. Quando guardi la LIM hai davanti…"),
                    Answers = [
                        Util.Ita("Una lavagna interattiva multimediale"),
                        Util.Ita("Una lima molto piccola"),
                        Util.Ita("Il registro elettronico")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Porti a scuola il tuo smartphone? Se sì, qual è l’uso corretto?"),
                    Answers = [
                        Util.Ita("Usarlo per svolgere ricerche o attività didattiche, se l’insegnante lo consente"),
                        Util.Ita("Tenerlo sempre spento"),
                        Util.Ita("Tenerlo sempre acceso, così se mi chiamano i miei genitori posso rispondere!")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "geolocalization", Util.Ita("Geolocalizzazione"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Secondo te, cosa vuol dire “geolocalizzazione”?"),
                    Answers = [
                        Util.Ita("È l'identificazione di dove si trova un oggetto, come lo smartphone"),
                        Util.Ita("È l’atteggiamento di chi resta fermo in un posto ben preciso "),
                        Util.Ita("È un modo di indicare le mappe online")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa ti permette di fare la geolocalizzazione?"),
                    Answers = [
                        Util.Ita("Raggiungere il posto che cerco, utilizzando le mappe"),
                        Util.Ita("Spiare i miei amici per vedere dove si trovano"),
                        Util.Ita("Niente, la geolocalizzazione non va mai attivata perché è pericolosa")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Sul tuo smartphone, quale di questi sistemi è collegato alle funzioni di geolocalizzazione?"),
                    Answers = [
                        Util.Ita("Il GPS"),
                        Util.Ita("La batteria"),
                        Util.Ita("Il salvaschermo")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "trust", Util.Ita("Fiducia e controllo"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Hai perso il cellulare: che tragedia! E ora cosa fai?"),
                    Answers = [
                        Util.Ita("Lo dico ai miei genitori o all’insegnante, e valuto di andare alla polizia "),
                        Util.Ita("Non dico niente a nessuno per evitare di essere sgridato"),
                        Util.Ita("Prendo di nascosto quello di un compagno")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Se i tuoi genitori installano il controllo parentale sul tuo computer, cosa significa?"),
                    Answers = [
                        Util.Ita("Che mi permettono di usare lo smartphone in tranquillità, proteggendomi dai contenuti non adatti alla mia età"),
                        Util.Ita("Che non hanno fiducia in me e vogliono controllarmi"),
                        Util.Ita("Che mi vietano l’utilizzo dei giochi")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Immagina di ricevere un messaggio da parte di uno sconosciuto: lo leggi e…"),
                    Answers = [
                        Util.Ita("Ne parlo con i miei genitori"),
                        Util.Ita("Rispondo subito, sono una persona educata!"),
                        Util.Ita("Penso che potremmo fare amicizia")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "privacy", Util.Ita("Privacy e impronta digitale"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Nel linguaggio digitale, se dico “privacy”, cosa intendo?"),
                    Answers = [
                        Util.Ita("La tutela delle informazioni personali e della vita privata"),
                        Util.Ita("L’insieme dei beni digitali di una persona: in italiano si traduce con “privato”"),
                        Util.Ita("I dati che vorrei avere, ma non ho: in italiano si traduce con “privazione”")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Immagina di ricevere un messaggio da uno sconosciuto che ti chiede qual è la tua password. Come reagisci?"),
                    Answers = [
                        Util.Ita("So che sono informazioni riservate, quindi non gli rispondo e ne parlo con un adulto"),
                        Util.Ita("Gliela scrivo, tanto come potrebbe mai usarla?!"),
                        Util.Ita("Gli chiedo prima a cosa gli serve")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Perché devi fare attenzione quando posti una fotografia, un video o un commento online?"),
                    Answers = [
                        Util.Ita("Perché tutto ciò che pubblico resta online e sarà visibile a tante persone"),
                        Util.Ita("Perché qualcuno potrebbe dirlo ai miei genitori e potrei ricevere una sgridata"),
                        Util.Ita("Non c’è motivo di stare attenti: chi guarderà mai le mie cose?!")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "phishing", Util.Ita("Phishing"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Hai mai sentito parlare di “phishing”? Sai cos’è?"),
                    Answers = [
                        Util.Ita("Una truffa online per sottrarre password e dati di accesso"),
                        Util.Ita("Una tecnica di pesca diventata popolare negli anni ‘90 grazie a un gioco online"),
                        Util.Ita("Un’email inviata per sbaglio")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Il “phishing” è una truffa che avviene online, spesso con un messaggio ingannevole per rubare i tuoi dati. Come lo puoi riconoscere facilmente?"),
                    Answers = [
                        Util.Ita("Cerca di attirare l’attenzione, con un contenuto forte come “Hai vinto un milione di euro!” o “Hai vinto uno smartphone favoloso!”"),
                        Util.Ita("In genere è un messaggio molto curato, senza errori di ortografia"),
                        Util.Ita("Arriva da una persona che conosco bene")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("“Phishing” è una parola inglese che indica…"),
                    Answers = [
                        Util.Ita("L’invio di messaggi pubblicitari non richiesti a un vasto pubblico"),
                        Util.Ita("L’acqua, il succo di frutta o altri liquidi rovesciati sulla tastiera "),
                        Util.Ita("La pubblicazione di un commento negativo su qualcosa")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "fakenews", Util.Ita("Fake news"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Le fake news sono nate con Internet?"),
                    Answers = [
                        Util.Ita("No, sono sempre esistite"),
                        Util.Ita("Sì, prima non esistevano"),
                        Util.Ita("Le fake news non esistono")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Che cosa sono le fake news?"),
                    Answers = [
                        Util.Ita("Notizie false per catturare la tua attenzione"),
                        Util.Ita("Notizie vere e attendibili"),
                        Util.Ita("Notizie vere ma scritte o pubblicate in modo anonimo")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa devi fare per scoprire se quelle che leggi sono fake news?"),
                    Answers = [
                        Util.Ita("Controllare la fonte della notizia (il sito dove compare e l’autore)"),
                        Util.Ita("Controllare la lunghezza dell’articolo: se è troppo lungo, la notizia non può essere vera"),
                        Util.Ita("Nessuna: non è possibile distinguere le fake news dalle notizie vere")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "identity", Util.Ita("Identità digitale"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("A che cosa pensi quando senti dire “identità digitale”?"),
                    Answers = [
                        Util.Ita("All’insieme dei dati e delle informazioni di un utente che si trovano online"),
                        Util.Ita("All’avatar con cui si interagisce nella comunità virtuale"),
                        Util.Ita("Alla carta d’identità elettronica ")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("La tua identità digitale è…"),
                    Answers = [
                        Util.Ita("Tanto importante quanto quella reale perché riguarda i miei dati personali e sensibili"),
                        Util.Ita("Meno importante di quella reale perché tanto è falsa"),
                        Util.Ita("Importantissima, perché da questa dipende il modo con cui gli amici mi percepiscono sui social media")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa consiglieresti a un tuo amico per proteggere la sua identità digitale?"),
                    Answers = [
                        Util.Ita("Di navigare su siti sicuri e utilizzare password non facilmente decifrabili"),
                        Util.Ita("Di non usare mai password troppo complicate"),
                        Util.Ita("Di non farsi troppi problemi e lasciare pure in giro tutti i suoi dati personali")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "behavior", Util.Ita("Comportamento in Rete"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cos’è la “netiquette”?"),
                    Answers = [
                        Util.Ita("Sono le regole del buon comportamento di un utente sul Web"),
                        Util.Ita("Sono degli adesivi da inviare online"),
                        Util.Ita("Sono le leggi che governano i social network")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quale di questi comportamenti è assolutamente da evitare quando navighi?"),
                    Answers = [
                        Util.Ita("Diffondere foto e informazioni personali dei tuoi amici"),
                        Util.Ita("Nessuno, in Internet si può fare tutto"),
                        Util.Ita("Fare recensioni su un prodotto acquistato online")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("La regola d’oro della netiquette è:"),
                    Answers = [
                        Util.Ita("Ricorda che anche sul Web siamo sempre persone"),
                        Util.Ita("Metti una faccina in ogni messaggio"),
                        Util.Ita("Non rispondere mai a nessuno")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "passwords", Util.Ita("Password sicure"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quale di queste password è la più sicura?"),
                    Answers = [
                        Util.Ita("Una password non riferita a informazioni che mi riguardano, con lettere maiuscole, numeri e caratteri speciali"),
                        Util.Ita("123456, perchè è talmente semplice che sono sicuro di non dimenticarla"),
                        Util.Ita("La mia data di nascita, perchè molti non la sanno e io sì")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa consiglieresti a un tuo amico per avere password veramente sicure?"),
                    Answers = [
                        Util.Ita("Scegliere password sempre diverse"),
                        Util.Ita("Scegliere sempre password uguali per non dimenticarle"),
                        Util.Ita("Scegliere password semplici come il suo nome")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quando si parla di sicurezza online, cosa si intende per “PIN”?"),
                    Answers = [
                        Util.Ita("Personal Identity Number: è una password"),
                        Util.Ita("Un suono emesso dal computer"),
                        Util.Ita("Pure Internet Navigation: è un sito web affidabile")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "gaming", Util.Ita("Gaming"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("C’è un tempo massimo che dovresti dedicare ai videogiochi?"),
                    Answers = [
                        Util.Ita("Non più di 2 ore al giorno"),
                        Util.Ita("No, posso starci quanto mi pare"),
                        Util.Ita("I videogiochi non vanno mai utilizzati")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Se qualcuno che non conosci ti contatta nella chat del gioco cosa devi fare? "),
                    Answers = [
                        Util.Ita("Non rispondere e continuare a giocare solo con chi conosco "),
                        Util.Ita("Rispondere subito: abbiamo degli interessi comuni"),
                        Util.Ita("Spegnere il computer e cambiare subito gioco")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("I videogiochi sono:"),
                    Answers = [
                        Util.Ita("Un’alternativa per giocare insieme agli amici, anche a distanza"),
                        Util.Ita("Un’attività solitaria, ma molto divertente"),
                        Util.Ita("Una perdita di tempo")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quale tipologia di videogiochi consente di giocare insieme nella stessa stanza?"),
                    Answers = [
                        Util.Ita("Gli exergame, i videogiochi che uniscono divertimento e allenamento"),
                        Util.Ita("I videogiochi in cui si può giocare contro il computer"),
                        Util.Ita("Tutte le categorie di videogiochi")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "cookies", Util.Ita("Cookie"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Hai appena accettato un Cookie. Cosa ti aspetti che faccia?"),
                    Answers = [
                        Util.Ita("Che raccolga dati sulla mia attività online per migliorare la navigazione"),
                        Util.Ita("Che nutra i miei avatar, ghiotti di biscotti al cioccolato"),
                        Util.Ita("Che mi compaia sullo schermo quando non lo uso per un po’")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quali di queste sono funzioni tipiche dei Cookie?"),
                    Answers = [
                        Util.Ita("Salvare i dati evitando una nuova autenticazione in una visita successiva "),
                        Util.Ita("Ripulire la memoria dello smartphone, per renderlo più prestante"),
                        Util.Ita("Bloccare i virus")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Apri un sito web e compare una schermata che ti informa della presenza di Cookie. Cosa fai?"),
                    Answers = [
                        Util.Ita("Leggo attentamente le indicazioni sul loro utilizzo e decido di conseguenza"),
                        Util.Ita("Finalmente, Cookie è il mio orsacchiotto preferito!"),
                        Util.Ita("Comunque dico di no: i Cookie non vanno mai accettati")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "competences", Util.Ita("Competenze digitali"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa devi sempre fare quando sei online?"),
                    Answers = [
                        Util.Ita("Essere responsabile"),
                        Util.Ita("Tenere in ordine la camera"),
                        Util.Ita("Non buttare cartacce a terra")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa significa “smart”?"),
                    Answers = [
                        Util.Ita("Intelligente e attento"),
                        Util.Ita("Simpatico e di bell’aspetto"),
                        Util.Ita("Banale, ovvio")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cos’è l’empatia digitale?"),
                    Answers = [
                        Util.Ita("La capacità di interagire con le persone anche a distanza, instaurando relazioni sane e positive"),
                        Util.Ita("La capacità di usare bene tutti i device, senza chiedere aiuto a nessuno"),
                        Util.Ita("La capacità di riconoscere le fake news")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "rights", Util.Ita("Diritti e doveri online"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Come si chiama l’insieme dei tuoi diritti e dei tuoi doveri online?"),
                    Answers = [
                        Util.Ita("Cittadinanza digitale"),
                        Util.Ita("Decalogo digitale"),
                        Util.Ita("Regole digitali")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Per essere un buon cittadino digitale devi:"),
                    Answers = [
                        Util.Ita("Conoscere i propri diritti e doveri in Rete, per agire in modo corretto"),
                        Util.Ita("Fare in Rete tutto ciò che si vuole, perché Internet è spazio libero"),
                        Util.Ita("Non seguire nessuna regola, perché la Rete non è la vita reale")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quale di questi è uno degli articoli contenuti nella “Dichiarazione dei diritti in Internet”"),
                    Answers = [
                        Util.Ita("Sono vietati l’accesso e il trattamento dei dati con finalità anche indirettamente discriminatorie"),
                        Util.Ita("Si può accedere a internet solo a determinate condizioni"),
                        Util.Ita("Ognuno su Internet ha il diritto di fare ciò che vuole, senza nessun tipo di conseguenza")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "devices", Util.Ita("Device e tecnologia"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("La tecnologia offre numerosi vantaggi alle nostre vite. Quale dei seguenti è corretto?"),
                    Answers = [
                        Util.Ita("Possiamo restare in contatto con familiari, amici, compagni di scuola e insegnanti anche quando si è distanti"),
                        Util.Ita("Possiamo prendere virus anche attraverso il computer"),
                        Util.Ita("Finalmente viviamo tutti davanti a uno schermo 24 ore su 24!")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Ti sei appena sdraiato sul divano per leggere un ebook. Quale device tieni in mano?"),
                    Answers = [
                        Util.Ita("L’ebook reader"),
                        Util.Ita("Lo smartphone"),
                        Util.Ita("Il mouse")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Che cos’è un device?"),
                    Answers = [
                        Util.Ita("È un dispositivo elettronico, come lo smartphone"),
                        Util.Ita("È un’applicazione"),
                        Util.Ita("È un mezzo di trasporto")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "health", Util.Ita("Salute e benessere digitale"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("La lettura sullo schermo di un computer è diversa dalla lettura su carta e spesso richiede alla vista:"),
                    Answers = [
                        Util.Ita("Un lavoro più faticoso"),
                        Util.Ita("Un lavoro più semplice "),
                        Util.Ita("Non ci sono differenze")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa si intende per “benessere digitale”?"),
                    Answers = [
                        Util.Ita("Un buon equilibrio tra attività online e vita reale"),
                        Util.Ita("La speranza che i computer non prendano virus"),
                        Util.Ita("La necessità di giocare sempre")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Prima di andare a dormire…"),
                    Answers = [
                        Util.Ita("Spengo il telefono… Lo riaccenderò domattina!"),
                        Util.Ita("Posso usare il telefono fino a tardi se non riesco ad addormentarmi"),
                        Util.Ita("Non uso il telefono ma lo tengo comunque acceso, non si sa mai!")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "revolution", Util.Ita("Rivoluzione tecnologica"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Dove è avvenuta la prima connessione Internet?"),
                    Answers = [
                        Util.Ita("In università"),
                        Util.Ita("A Hollywood"),
                        Util.Ita("Nello spazio")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Il 5G è uno dei passi fondamentali del prossimo futuro perché…"),
                    Answers = [
                        Util.Ita("Renderà più efficienti le nostre telecomunicazioni"),
                        Util.Ita("Permetterà di volare"),
                        Util.Ita("Aprirà le porte alla comunicazione con abitanti di altri pianeti")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Che cosa significa WWW?"),
                    Answers = [
                        Util.Ita("World Wide Web"),
                        Util.Ita("World Wide Win"),
                        Util.Ita("World Wide Wire")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "virtualreality", Util.Ita("Realtà virtuale"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Che cos’è la realtà virtuale?"),
                    Answers = [
                        Util.Ita("Un ambiente simile alla realtà ricreato da un computer"),
                        Util.Ita("La realtà circostante"),
                        Util.Ita("Un altro modo per chiamare la Rete")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa si intende per “realtà aumentata”?"),
                    Answers = [
                        Util.Ita("L'integrazione della realtà circostante con immagini generate dal computer"),
                        Util.Ita("La vita delle persone famose"),
                        Util.Ita("La realtà virtuale")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quale dispositivo è utile per entrare nella realtà virtuale?"),
                    Answers = [
                        Util.Ita("Un visore VR"),
                        Util.Ita("Un paio di occhiali da sole"),
                        Util.Ita("Un mouse wireless")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "web", Util.Ita("La Rete e Internet"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Un browser è…"),
                    Answers = [
                        Util.Ita("Un programma per navigare su Internet"),
                        Util.Ita("Un altro modo per dire Internet"),
                        Util.Ita("Un personaggio di Super Mario")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa vuol dire e cosa indica la parola “web”?"),
                    Answers = [
                        Util.Ita("Significa “ragnatela” e indica la rete dei siti Internet"),
                        Util.Ita("Significa “connessione” e indica la rete a cui si connettono gli smartphone"),
                        Util.Ita("È il nome in codice dell’inventore di Internet")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cos’è un motore di ricerca?"),
                    Answers = [
                        Util.Ita("Un programma che aiuta a cercare informazioni in rete"),
                        Util.Ita("Uno scooter di ultima generazione"),
                        Util.Ita("Un'applicazione pensata per studiare")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "cybersecurity", Util.Ita("Cybersecurity"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Immagina da grande di diventare un esperto di cybersecurity. Di cosa ti occuperai principalmente?"),
                    Answers = [
                        Util.Ita("Di processi e tecnologie che hanno l’obiettivo di proteggere le persone dagli attacchi in Rete"),
                        Util.Ita("Dell’attività dei ladri che cercano di rubare computer"),
                        Util.Ita("Di una serie di regole per difendersi dall’Intelligenza Artificiale")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Chi o cosa sono gli hacker?"),
                    Answers = [
                        Util.Ita("Pirati informatici"),
                        Util.Ita("Piccoli insetti"),
                        Util.Ita("Sistemi di sicurezza informatica")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Un esperto di informatica ti ha appena parlato di “firewall”, che cosa intendeva?"),
                    Answers = [
                        Util.Ita("Il sistema che protegge i tuoi dispositivi da situazioni rischiose"),
                        Util.Ita("Il sistema antincendio del computer"),
                        Util.Ita("Un programma di attacco usato dagli hacker")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "cloud", Util.Ita("Il Cloud"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cloud in inglese significa “nuvola”, ma nel mondo digitale cos’è?"),
                    Answers = [
                        Util.Ita("La tecnologia che permette di elaborare e archiviare dati in Rete"),
                        Util.Ita("Quando lo schermo dello smartphone si annebbia"),
                        Util.Ita("La nuvola digitale formata da tutti i siti web")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa ti permette di fare il Cloud?"),
                    Answers = [
                        Util.Ita("Conservare foto, documenti e contatti per non perderli anche se cambi telefono"),
                        Util.Ita("Risparmiare batteria sul tuo cellulare"),
                        Util.Ita("Scaricare tutte le applicazione gratuitamente")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quale di queste parole indica uno spazio su Internet per salvare copie dei propri file?"),
                    Answers = [
                        Util.Ita("Cloud"),
                        Util.Ita("Metaverso"),
                        Util.Ita("Big Data")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "socialmedia", Util.Ita("Utilizzo dei Social Media"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quali di questi sono dei social media?"),
                    Answers = [
                        Util.Ita("Instagram, TikTok e Twitch"),
                        Util.Ita("Google e Chrome"),
                        Util.Ita("Netflix e Disney+")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("C’è un’età minima per iscriversi sui social media?"),
                    Answers = [
                        Util.Ita("Sì, i social media hanno un’età minima per l’iscrizione (14 anni) ma devo comunque chiedere il consenso ai miei genitori"),
                        Util.Ita("No, mi iscrivo quando voglio"),
                        Util.Ita("No, lo decidono i miei genitori")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quali contenuti ci sono su TikTok?"),
                    Answers = [
                        Util.Ita("Challenge e balletti divertenti"),
                        Util.Ita("Testi lunghi e noiosi"),
                        Util.Ita("Gli stessi contenuti che si vedono in TV")
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "email", Util.Ita("Utilizzo delle email"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Se i destinatari della tua email sono in Copia Carbone Nascosta (CCN), significa che…"),
                    Answers = [
                        Util.Ita("Il loro indirizzo non appare agli altri destinatari del messaggio"),
                        Util.Ita("Non leggono il mio messaggio"),
                        Util.Ita("Ricevono il mio messaggio senza oggetto")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Qual è il simbolo presente in ogni indirizzo di posta elettronica?"),
                    Answers = [
                        Util.Ita("@"),
                        Util.Ita(";-)"),
                        Util.Ita("#")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Per scrivere una buona email…"),
                    Answers = [
                        Util.Ita("Inserisci sempre un “oggetto” chiaro e preciso, per far capire al tuo destinatario il contenuto della mail"),
                        Util.Ita("Bisogna firmare sempre con un nickname"),
                        Util.Ita("Bisogna scrivere tutto in stampatello maiuscolo")
                    ]
                }
            );
        }
    }
}
