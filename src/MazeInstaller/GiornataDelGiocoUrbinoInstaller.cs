using CodyMazeBot;

namespace MazeInstaller {
    internal class GiornataDelGiocoUrbinoInstaller : IInstaller {
        const string EventName = "giocourbino";

        public async Task Install(Storage s) {
            await s.StoreEvent(EventName, new CodyMazeBot.StoreModels.Event {
                Title = new Dictionary<string, string>
                {
                    { "it", "Giornata del Gioco Urbino 2024" },
                    { "en", "Giornata del Gioco Urbino 2024" },
                },
                Questionnaire = null,
                Code = EventName,
                Grid = new Dictionary<string, CodyMazeBot.StoreModels.GridCell>
                {
                    { "a1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = true } },
                    { "a2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "a3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "a4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = true } },
                    { "a5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },

                    { "b1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = true } },
                    { "b2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "b3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "b4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "b5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },

                    { "c1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "c2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "c3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "c4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "c5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = true } },

                    { "d1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "d2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "d3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "d4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "d5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },

                    { "e1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "e2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = true } },
                    { "e3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "e4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                    { "e5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "dizionario", HasStar = false } },
                }
            });

            await Util.AddCategory(s, EventName, "dizionario", Util.Ita("Dizionario dei giochi"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Fino a quando il Tiro alla fune è stato disciplina olimpica?"),
                    Answers = [
                        Util.Ita("1920"),
                        Util.Ita("2004"),
                        Util.Ita("Non è mai stato disciplina olimpica")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa serve per giocare a “Fuori il verde”?"),
                    Answers = [
                        Util.Ita("Un ramoscello con foglie"),
                        Util.Ita("Un semaforo"),
                        Util.Ita("Un alieno e un tabellone")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa dice Simone in “Simone dice”?"),
                    Answers = [
                        Util.Ita("Simone dice cosa si deve fare"),
                        Util.Ita("Simone dice chi comincia"),
                        Util.Ita("Simone deve stare zitto")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quale di queste è stata una challenge social?"),
                    Answers = [
                        Util.Ita("Far cadere una bottiglia in piedi"),
                        Util.Ita("Mordere la coda di una tigre"),
                        Util.Ita("Salire su un toro")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quante carte ha un mazzo francese?"),
                    Answers = [
                        Util.Ita("52"),
                        Util.Ita("60"),
                        Util.Ita("40")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quante donne ci sono in un mazzo di carte napoletane?"),
                    Answers = [
                        Util.Ita("Nessuna (ma ci sono quattro fanti e quattro cavalli)"),
                        Util.Ita("Quattro"),
                        Util.Ita("Otto")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Come finisce il proverbio “Chi sa il gioco…”"),
                    Answers = [
                        Util.Ita("…non l’insegni"),
                        Util.Ita("…sa il cavallo"),
                        Util.Ita("…dura poco")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quale di questi è un antico gioco da tavolo egizio?"),
                    Answers = [
                        Util.Ita("Senet"),
                        Util.Ita("Tenet"),
                        Util.Ita("Safèt")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Qual è il famoso solido di Rubik?"),
                    Answers = [
                        Util.Ita("Il cubo"),
                        Util.Ita("Il cono"),
                        Util.Ita("Il cilindro")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa si usa (o si usava) nel gioco della ruzzola?"),
                    Answers = [
                        Util.Ita("Un disco di legno"),
                        Util.Ita("Una ruota di bicicletta"),
                        Util.Ita("Un animale ruzzolante")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa si lancia nel gioco del Maiorchino?"),
                    Answers = [
                        Util.Ita("Un formaggio stagionato"),
                        Util.Ita("Uno spagnolo delle isole"),
                        Util.Ita("Una briscola")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quale di questi giochi compare nella Tabella dei Giuochi Proibiti?"),
                    Answers = [
                        Util.Ita("Bestia"),
                        Util.Ita("Cavalli marci"),
                        Util.Ita("Briscola bugiarda")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quali giochi portano il nome di Napoleone?"),
                    Answers = [
                        Util.Ita("Alcuni solitari"),
                        Util.Ita("Alcuni giochi di conquista"),
                        Util.Ita("Alcuni giochi di travestimento")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Come si chiama una persona che si muove sui trampoli?"),
                    Answers = [
                        Util.Ita("Trampoliere o trampolista"),
                        Util.Ita("Trampolinista"),
                        Util.Ita("Gambalunga")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Qual è il pezzo degli scacchi che può saltare gli altri?"),
                    Answers = [
                        Util.Ita("Il cavallo"),
                        Util.Ita("Il cammello"),
                        Util.Ita("Il canguro")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa fa Pierino sotto il ponte di Baracca, in una famosa conta?"),
                    Answers = [
                        Util.Ita("Fa i suoi bisogni poi li misura trentatré"),
                        Util.Ita("Si fa il ciuffo con la lacca"),
                        Util.Ita("Manda tutto in vacca")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quale di questi è un anagramma di labirinto?"),
                    Answers = [
                        Util.Ita("Ribaltoni"),
                        Util.Ita("Battiloro"),
                        Util.Ita("Latino di Bari")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Secondo Giulio Cesare…"),
                    Answers = [
                        Util.Ita("Il dado è tratto"),
                        Util.Ita("Il dado è da brodo"),
                        Util.Ita("Il dado è truccato")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Qual è il contrario di “giocare sporco”?"),
                    Answers = [
                        Util.Ita("Fair play"),
                        Util.Ita("Fare le bolle di sapone"),
                        Util.Ita("Pulire il piano di gioco")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("La prima edizione italiana de “I coloni di Catan” aveva un nome leggermente diverso. Quale?"),
                    Answers = [
                        Util.Ita("I coloni di Katan"),
                        Util.Ita("I coloni di Catania"),
                        Util.Ita("I coloni di Cattelan")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Tra giocatori da tavolo ci sono alcuni termini molto gergali. Per esempio, cosa è un “german”?"),
                    Answers = [
                        Util.Ita("Un gioco molto equilibrato, di solito con pezzi in legno"),
                        Util.Ita("Un gioco di guerra con molte anatre"),
                        Util.Ita("Un gioco di combattimento con würstel laser")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("In enigmistica, cosa è uno “scarto”?"),
                    Answers = [
                        Util.Ita("Una parola che perdendo una lettera ne dà un’altra"),
                        Util.Ita("Un enigma riuscito male"),
                        Util.Ita("Un gioco ferroviario")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Perché la scala H0 si chiama così?"),
                    Answers = [
                        Util.Ita("Indica, in tedesco la scala ‘Halb Null’, metà zero, per distinguerla dalla 00"),
                        Util.Ita("Per segnare sulla mancolista un trenino che ho"),
                        Util.Ita("Perché non ci sono acca nella parola scala (altrimenti sarebbe schala)")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Qual è il contributo italiano al gioco del Subbuteo?"),
                    Answers = [
                        Util.Ita("Spruzzare le basette con lucidatore spray"),
                        Util.Ita("Si possono comprare gli arbitri"),
                        Util.Ita("Si possono legare gli omini per fare il catenaccio")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Come viene ribattezzato il gioco del Bridge in era fascista?"),
                    Answers = [
                        Util.Ita("Ponte"),
                        Util.Ita("Briggio"),
                        Util.Ita("Messina")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("A Poker, il Colore vale…"),
                    Answers = [
                        Util.Ita("Più di una scala, meno di un full"),
                        Util.Ita("Più di un full, meno di una scala"),
                        Util.Ita("Come una combinazione di cinque carte uguali")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("In quale gioco si può “buzzare”?"),
                    Answers = [
                        Util.Ita("Taboo"),
                        Util.Ita("Hives"),
                        Util.Ita("Gino Pilotino")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Quale gioco da tavolo vintage ha tra le componenti un teschio in plastica?"),
                    Answers = [
                        Util.Ita("Brivido"),
                        Util.Ita("Pozioni esplosive"),
                        Util.Ita("L’allegro chirurgo")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Qual è la cosa più strana dell’edizione italiana di Monopoly Star Wars?"),
                    Answers = [
                        Util.Ita("Il carabiniere nell’angolo"),
                        Util.Ita("Il parcheggio gratuito"),
                        Util.Ita("Viale dei giardini")
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.Ita("Cosa si usa per giocare a Ripiglino?"),
                    Answers = [
                        Util.Ita("Un laccio o corda"),
                        Util.Ita("Un elastico"),
                        Util.Ita("Un boomerang")
                    ]
                }
            );
        }
    }
}
