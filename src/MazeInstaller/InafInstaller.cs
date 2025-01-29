using CodyMazeBot;
using CodyMazeBot.StoreModels;

namespace MazeInstaller {
    internal class InafInstaller : IInstaller {
        const string EventName = "inaf";

        public async Task Install(Storage s) {
            await s.StoreEvent(EventName, new CodyMazeBot.StoreModels.Event {
                Title = Util.EngItaPor(
                    "INAF Astrophysical CodyMaze",
                    "CodyMaze Astrofisico di INAF",
                    "CodyMaze Astrofísico INAF"
                ),
                Questionnaire = new CodyMazeBot.StoreModels.Questionnaire {
                    Questions = [
                        new QuestionnaireQuestion {
                            Kind = "age",
                            Text = Util.EngItaPor(
                                "How old are you?",
                                "Quanti anni hai?",
                                "Quantos anos você tem?"
                            ),
                        },
                        new QuestionnaireQuestion {
                            Kind = "string",
                            Text = Util.EngItaPor(
                                "What is the ZIP code of the place you live in?",
                                "Qual è il codice di avviamento postale (CAP) del luogo dove abiti?",
                                "Qual é o código postal do lugar onde você mora?"
                            ),
                        }
                    ],
                },
                Code = EventName,
                Grid = new Dictionary<string, CodyMazeBot.StoreModels.GridCell>
                {
                    { "a1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "sun", HasStar = true } },
                    { "a2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "mercury", HasStar = false } },
                    { "a3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "venus", HasStar = false } },
                    { "a4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "earth", HasStar = true } },
                    { "a5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "mars", HasStar = false } },

                    { "b1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "jupiter", HasStar = true } },
                    { "b2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "saturn", HasStar = false } },
                    { "b3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "uranus", HasStar = false } },
                    { "b4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "neptune", HasStar = false } },
                    { "b5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "pluto", HasStar = false } },

                    { "c1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "moon", HasStar = false } },
                    { "c2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "solarsystem", HasStar = false } },
                    { "c3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "moons", HasStar = false } },
                    { "c4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "asteroids", HasStar = false } },
                    { "c5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "constellations", HasStar = true } },

                    { "d1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "milkyway", HasStar = false } },
                    { "d2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "stellarevolution", HasStar = false } },
                    { "d3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "nebulas", HasStar = false } },
                    { "d4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "compactobjects", HasStar = false } },
                    { "d5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "bigbang", HasStar = false } },

                    { "e1", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "exploration", HasStar = false } },
                    { "e2", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "exoplanets", HasStar = true } },
                    { "e3", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "galaxies", HasStar = false } },
                    { "e4", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "particles", HasStar = false } },
                    { "e5", new CodyMazeBot.StoreModels.GridCell { CategoryCode = "instruments", HasStar = false } },
                }
            });

            await Util.AddCategory(s, EventName, "sun", Util.EngItaPor("The Sun", "Il Sole", "O Sol"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What darkens the Sun during a solar eclipse?",
                        "Che cosa oscura il Sole durante un'eclisse solare?",
                        "O que escurece o Sol durante um eclipse solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "The Moon",
                            "La Luna",
                            "A Lua"
                        ),
                        Util.EngItaPor(
                            "The Earth",
                            "La Terra",
                            "A Terra"
                        ),
                        Util.EngItaPor(
                            "The clouds",
                            "Le nubi",
                            "As nuvens"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the temperature of the sunspots compared to the rest of the photosphere?",
                        "Com'è la temperatura delle macchie solari rispetto al resto della fotosfera?",
                        "Qual é a temperatura das manchas solares em comparação com o restante da fotosfera?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Lower",
                            "Più bassa",
                            "Menor"
                        ),
                        Util.EngItaPor(
                            "Higher",
                            "Più alta",
                            "Maior"
                        ),
                        Util.EngItaPor(
                            "Sunspots have the same temperature",
                            "Le macchie solari hanno la stessa temperatura",
                            "As manchas solares têm a mesma temperatura"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How far is the Sun from the Earth?",
                        "Quanto dista il Sole dalla Terra?",
                        "Qual é a distância entre o Sol e a Terra?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 150 millions kilometres",
                            "Circa 150 milioni di chilometri",
                            "Cerca de 150 milhões de quilômetros"
                        ),
                        Util.EngItaPor(
                            "About 150 thousand kilometres",
                            "Circa 150 mila chilometri",
                            "Cerca de 150 mil quilômetros"
                        ),
                        Util.EngItaPor(
                            "About 150 kilometres",
                            "Circa 150 chilometri",
                            "Cerca de 150 quilômetros"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What kind of star is the Sun?",
                        "Che tipo di stella è il Sole?",
                        "Que tipo de estrela é o Sol?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A yellow dwarf",
                            "Una nana gialla",
                            "Uma anã amarela"
                        ),
                        Util.EngItaPor(
                            "A white dwarf",
                            "Una nana bianca",
                            "Uma anã branca"
                        ),
                        Util.EngItaPor(
                            "A red giant",
                            "Una gigante rossa",
                            "Uma gigante vermelha"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How old is the Sun?",
                        "Quanti anni ha il Sole?",
                        "Qual é a idade do Sol?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 4.6 bilions years",
                            "Circa 4.6 miliardi di anni",
                            "Cerca de 4,6 bilhões de anos"
                        ),
                        Util.EngItaPor(
                            "About 10 bilions years",
                            "Circa 10 miliardi di anni",
                            "Cerca de 10 bilhões de anos"
                        ),
                        Util.EngItaPor(
                            "About 4.6 millions years",
                            "Circa 4.6 milioni di anni",
                            "Cerca de 4,6 milhões de anos"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the Sun made of?",
                        "Di cosa è fatto il Sole?",
                        "Do que é feito o Sol?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Plasma",
                            "Di plasma",
                            "Plasma"
                        ),
                        Util.EngItaPor(
                            "Fire",
                            "Di fuoco",
                            "Fogo"
                        ),
                        Util.EngItaPor(
                            "Magma",
                            "Di magma",
                            "Magma"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long does the  Sun take to rotate?",
                        "Quanto tempo impiega il Sole a ruotare su sè stesso?",
                        "Quanto tempo leva para o Sol completar uma rotação?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 600 hours",
                            "Circa 600 ore",
                            "Cerca de 600 horas"
                        ),
                        Util.EngItaPor(
                            "About 24 hours",
                            "Circa 24 ore",
                            "Cerca de 24 horas"
                        ),
                        Util.EngItaPor(
                            "About 365 days",
                            "Circa 365 giorni",
                            "Cerca de 365 dias"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the fate of a star like the Sun?",
                        "Qual è il destino di una stella come il Sole?",
                        "Qual é o destino de uma estrela como o Sol?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "It will become a red giant, and then a white dwarf",
                            "Diventerà una gigante rossa e poi una nana bianca",
                            "Ela se tornará uma gigante vermelha e, em seguida, uma anã branca"
                        ),
                        Util.EngItaPor(
                            "It will become a neutron star",
                            "Diventerà una stella di neutroni",
                            "Ela se tornará uma estrela de nêutrons"
                        ),
                        Util.EngItaPor(
                            "It will explode into a Supernova",
                            "Esploderà in una supernova",
                            "Ela explodirá em uma supernova"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the temperature of the solar photosphere?",
                        "Qual è la temperatura della fotosfera solare?",
                        "Qual é a temperatura da fotosfera solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 5700 degrees",
                            "Circa 5700 gradi",
                            "Cerca de 5700 graus"
                        ),
                        Util.EngItaPor(
                            "About 10 thousand degrees",
                            "Circa 10mila gradi",
                            "Cerca de 10 mil graus"
                        ),
                        Util.EngItaPor(
                            "About 1300 degrees",
                            "Circa 1300 gradi",
                            "Cerca de 1300 graus"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "WHich star is closest to the Sun?",
                        "Qual è la stella più vicina al Sole?",
                        "Qual estrela está mais próxima do Sol?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Proxima Centauri",
                            "Proxima Centauri",
                            "Próxima Centauri"
                        ),
                        Util.EngItaPor(
                            "Barnard's star",
                            "Stella di Barnard",
                            "Estrela de Barnard"
                        ),
                        Util.EngItaPor(
                            "Sirius",
                            "Sirio",
                            "Sirius"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "mercury", Util.EngItaPor("Mercury", "Mercurio", "Mercúrio"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many satellites does Mercury have?",
                        "Quanti satelliti ha Mercurio?",
                        "Quantos satélites Mercúrio tem?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "None",
                            "Nessuno",
                            "Nenhum"
                        ),
                        Util.EngItaPor(
                            "2",
                            "2",
                            "2"
                        ),
                        Util.EngItaPor(
                            "6",
                            "6",
                            "6"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the radius of Mercury?",
                        "Qual è il raggio di Mercurio?",
                        "Qual é o raio de Mercúrio?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 2439 kilometres",
                            "Circa 2439 chilometri",
                            "Cerca de 2439 quilômetros"
                        ),
                        Util.EngItaPor(
                            "About 4879 kilometres",
                            "Circa 4879 chilometri",
                            "Cerca de 4879 quilômetros"
                        ),
                        Util.EngItaPor(
                            "About 12 thousand kilometres",
                            "Circa 12mila chilometri",
                            "Cerca de 12 mil quilômetros"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a day on Mercury?",
                        "Quanto è lungo un giorno su Mercurio?",
                        "Quanto tempo dura um dia em Mercúrio?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "59 Earth days",
                            "59 giorni terrestri",
                            "59 dias terrestres"
                        ),
                        Util.EngItaPor(
                            "88 Earth days",
                            "88 giorni terrestri",
                            "88 dias terrestres"
                        ),
                        Util.EngItaPor(
                            "50 hours",
                            "50 ore",
                            "50 horas"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a year on Mercury?",
                        "Quanto è lungo un anno su Mercurio?",
                        "Quanto tempo dura um ano em Mercúrio?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "88 Earth days",
                            "88 giorni terrestri",
                            "88 dias terrestres"
                        ),
                        Util.EngItaPor(
                            "50 Earth days",
                            "50 giorni terresti",
                            "50 dias terrestres"
                        ),
                        Util.EngItaPor(
                            "450 Earth days",
                            "450 giorni terrestri",
                            "450 dias terrestres"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the temperature on Mercury?",
                        "Qual è la temperatura su Mercurio?",
                        "Qual é a temperatura em Mercúrio?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 425 degrees in the side exposed to the sunlight, -175 degrees on the opposite side",
                            "Circa 425 gradi dove batte il Sole, -175 gradi nel lato opposto",
                            "Cerca de 425 graus no lado exposto à luz solar, -175 graus no lado oposto"
                        ),
                        Util.EngItaPor(
                            "About 400 degrees, everywhere",
                            "Circa 400 gradi, ovunque",
                            "Cerca de 400 graus em toda parte"
                        ),
                        Util.EngItaPor(
                            "About 425 degrees in the side exposed to the sunlight, 175 degrees on the opposite side",
                            "Circa 425 gradi dove batte il Sole, 175 gradi nel lato opposto",
                            "Cerca de 425 graus no lado exposto à luz solar, 175 graus no lado oposto"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How far is Mercury from the Sun?",
                        "Quanto dista Mercurio dal Sole?",
                        "Qual é a distância de Mercúrio ao Sol?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 58 millions kilometres",
                            "Circa 58 milioni di chilometri",
                            "Cerca de 58 milhões de quilômetros"
                        ),
                        Util.EngItaPor(
                            "About 150 millions kilometres",
                            "Circa 150 milioni di chilometri",
                            "Cerca de 150 milhões de quilômetros"
                        ),
                        Util.EngItaPor(
                            "About 5.8 millions kilometres",
                            "Circa 5.8 milioni di chilometri",
                            "Cerca de 5,8 milhões de quilômetros"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is Mercury's atmosphere mainly made of?",
                        "Da cosa è composta principalmente l'atmosfera di Mercurio?",
                        "De que é principalmente feita a atmosfera de Mercúrio?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Mercury has no atmosphere",
                            "Mercurio non ha atmosfera",
                            "Mercúrio não tem atmosfera"
                        ),
                        Util.EngItaPor(
                            "Oxygen and nitrogen",
                            "Ossigeno e azoto",
                            "Oxigênio e nitrogênio"
                        ),
                        Util.EngItaPor(
                            "Methane",
                            "Metano",
                            "Metano"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What does the surface of Mercury look like?",
                        "Come si presenta la superficie di Mercurio",
                        "Como é a superfície de Mercúrio?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Full of craters, like the Moon",
                            "Piena di crateri, come la Luna",
                            "Cheia de crateras, como a Lua"
                        ),
                        Util.EngItaPor(
                            "Fluid, because it is a very hot planet",
                            "Fluida, perché è un pianeta molto caldo",
                            "Fluída, porque é um planeta muito quente"
                        ),
                        Util.EngItaPor(
                            "Ice-covered, because it has no atmosphere",
                            "Ghiacciata, perché non ha atmosfera",
                            "Coberta de gelo, porque não tem atmosfera"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Is Mercury the smallest planet of the Solar System?",
                        "Mercurio è il più piccolo pianeta del Sistema solare?",
                        "Mercúrio é o menor planeta do Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Yes",
                            "Sì",
                            "Sim"
                        ),
                        Util.EngItaPor(
                            "No",
                            "No",
                            "Não"
                        ),
                        Util.EngItaPor(
                            "We cannot know",
                            "Non lo possiamo sapere",
                            "Não podemos saber"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Is Mercury the hottest planet of the Solar System?",
                        "Mercurio è il pianeta più caldo del Sistema solare?",
                        "Mercúrio é o planeta mais quente do Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "No",
                            "No",
                            "Não"
                        ),
                        Util.EngItaPor(
                            "Yes",
                            "Sì",
                            "Sim"
                        ),
                        Util.EngItaPor(
                            "We cannot know",
                            "Non lo possiamo sapere",
                            "Não podemos saber"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "venus", Util.EngItaPor("Venus", "Venere", "Vênus"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How big is Venus compared to the Earth?",
                        "Quanto è grande Venere rispetto alla Terra?",
                        "Como é grande Vênus em comparação com a Terra?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Venus is smaller",
                            "Venere è più piccolo",
                            "Vênus é menor."
                        ),
                        Util.EngItaPor(
                            "Venus is bigger",
                            "Venere è più grande",
                            "Vênus é maior."
                        ),
                        Util.EngItaPor(
                            "Venus is as big as the Earth",
                            "Venere come la Terra",
                            "Vênus é tão grande quanto a Terra."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a day on Venus?",
                        "Quanto è lungo un giorno su Venere?",
                        "Quanto tempo dura um dia em Vênus?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "245 Earth days",
                            "245 giorni terrestri",
                            "245 dias terrestres."
                        ),
                        Util.EngItaPor(
                            "225 Earth days",
                            "225 giorni terrestri",
                            "225 dias terrestres."
                        ),
                        Util.EngItaPor(
                            "245 hours",
                            "245 ore",
                            "245 horas."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a year on Venus?",
                        "Quanto è lungo un anno su Venere?",
                        "Quanto tempo dura um ano em Vênus?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "225 Earth days",
                            "225 giorni terrestri",
                            "225 dias terrestres."
                        ),
                        Util.EngItaPor(
                            "245 Earth days",
                            "245 giorni terrestri",
                            "245 dias terrestres."
                        ),
                        Util.EngItaPor(
                            "365 Earth days",
                            "365 giorni terrestri",
                            "365 dias terrestres."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the temperature on Venus?",
                        "Qual è la temperatura su Venere?",
                        "Qual é a temperatura em Vênus?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "500 degrees",
                            "500 gradi",
                            "500 graus."
                        ),
                        Util.EngItaPor(
                            "500 degrees in the side exposed to the sunlight, 200 degrees on the opposite side",
                            "500 gradi dove batte il Sole, 200 gradi nel lato opposto",
                            "500 graus no lado exposto à luz solar, 200 graus no lado oposto."
                        ),
                        Util.EngItaPor(
                            "500 degrees in the side exposed to the sunlight, -100 degrees on the opposite side",
                            "500 gradi dove batte il Sole, -100 gradi nel lato opposto",
                            "500 graus no lado exposto à luz solar, -100 graus no lado oposto."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How far is Venus from the Sun?",
                        "Quanto dista Venere dal Sole?",
                        "Qual é a distância de Vênus ao Sol?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "108 millions kilometres",
                            "108 milioni di chilometri",
                            "108 milhões de quilômetros."
                        ),
                        Util.EngItaPor(
                            "150 millions kilometres",
                            "150 milioni di chilometri",
                            "150 milhões de quilômetros."
                        ),
                        Util.EngItaPor(
                            "229 millions kilometres",
                            "229 milioni di chilometri",
                            "229 milhões de quilômetros."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Quanti satelliti ha Venere?",
                        "Quanti satelliti ha Venere?",
                        "Quantos satélites tem Vênus?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "0",
                            "0",
                            "0"
                        ),
                        Util.EngItaPor(
                            "1",
                            "1",
                            "1"
                        ),
                        Util.EngItaPor(
                            "2",
                            "2",
                            "2"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the atmospheric pressure on the surface of Venus?",
                        "Quant'è la pressione atmoferica sulla superficie di Venere?",
                        "Qual é a pressão atmosférica na superfície de Vênus?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "90 times higher than that on the Earth",
                            "90 volte superiore a quella sulla Terra",
                            "90 vezes maior do que na Terra."
                        ),
                        Util.EngItaPor(
                            "10 times higher than that on Earth",
                            "10 volte superiore a quella sulla Terra",
                            "10 vezes maior do que na Terra."
                        ),
                        Util.EngItaPor(
                            "Just like that on the Earth",
                            "Come quella sulla Terra",
                            "Igual à da Terra."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the atmosphereon Venus mainly composed of?",
                        "Da cosa è composta principalmente l'atmosfera di Venere?",
                        "Do que é principalmente composta a atmosfera de Vênus?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Carbon dioxide",
                            "Diossido di carbonio",
                            "Dióxido de carbono."
                        ),
                        Util.EngItaPor(
                            "Methane",
                            "Metano",
                            "Metano."
                        ),
                        Util.EngItaPor(
                            "Nitrogen",
                            "Azoto",
                            "Nitrogênio."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What distinguishes Venus from the other planets?",
                        "Cosa distingue Venere dagli altri pianeti?",
                        "O que distingue Vênus dos outros planetas?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "It has a retrograde rotation",
                            "Ha una rotazione retrograda",
                            "Tem uma rotação retrógrada."
                        ),
                        Util.EngItaPor(
                            "It is home to life",
                            "Ospita la vita",
                            "É lar de vida."
                        ),
                        Util.EngItaPor(
                            "It is very similar to the Earth",
                            "È molto simile alla Terra",
                            "É muito semelhante à Terra."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Why is Venus the hottest planet of the Solar System?",
                        "Perchè Venere è il pianeta più caldo del Sistema solare?",
                        "Por que Vênus é o planeta mais quente do Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Because it has a strong greenhouse effect",
                            "Perchè ha un forte effetto serra",
                            "Porque tem um forte efeito estufa."
                        ),
                        Util.EngItaPor(
                            "Because it is the planet closest to the Sun",
                            "Perchè è il più vicino al Sole",
                            "Porque é o planeta mais próximo do Sol."
                        ),
                        Util.EngItaPor(
                            "Because more sunlight comes to it",
                            "Perchè arriva più luce del Sole",
                            "Porque recebe mais luz solar."
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "earth", Util.EngItaPor("The Earth", "La Terra", "A Terra"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long does the Earth take to rotate?",
                        "Quanto impiega la Terra a ruotare su sé stessa?",
                        "Quanto tempo a Terra leva para girar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "More or less 24 hours",
                            "Circa 24 ore",
                            "Mais ou menos 24 horas."
                        ),
                        Util.EngItaPor(
                            "About 12 hours",
                            "Circa 12 ore",
                            "Cerca de 12 horas."
                        ),
                        Util.EngItaPor(
                            "About 48 hours",
                            "Circa 48 ore",
                            "Cerca de 48 horas."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long does the Earth take to rotate around the Sun?",
                        "Quanto impiega la Terra a ruotare intorno al Sole?",
                        "Quanto tempo a Terra leva para girar ao redor do Sol?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 365 days",
                            "Circa 365 giorni",
                            "Cerca de 365 dias."
                        ),
                        Util.EngItaPor(
                            "About 687 days",
                            "Circa 687 giorni",
                            "Cerca de 687 dias."
                        ),
                        Util.EngItaPor(
                            "More or less 24 hours",
                            "Circa 24 ore",
                            "Mais ou menos 24 horas."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "The Earth rotates on itself",
                        "La Terra ruota su sè stessa",
                        "A Terra gira sobre si mesma"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Counter-clockwise",
                            "In senso antiorario",
                            "No sentido anti-horário."
                        ),
                        Util.EngItaPor(
                            "Clockwise",
                            "In senso orario",
                            "No sentido horário."
                        ),
                        Util.EngItaPor(
                            "It depends on the season",
                            "Dipende dalle stagioni",
                            "Depende da estação."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What does the alternatiomn of the seasons depend on?",
                        "Da cosa dipende l'alternarsi delle stagioni?",
                        "Do que depende a alternância das estações?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "It depends on the inclination of the Earth's axis and the motion of revolution",
                            "Dall'inclinazione dell'asse terrestre e dal moto di rivoluzione",
                            "Isso depende da inclinação do eixo da Terra e do movimento de revolução."
                        ),
                        Util.EngItaPor(
                            "It depends on the motion of revolution",
                            "Dal moto di rivoluzione",
                            "Isso depende do movimento de revolução."
                        ),
                        Util.EngItaPor(
                            "It depend on the distance from the Sun",
                            "Dalla distanza dal Sole",
                            "Isso depende da distância do Sol."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the reason for tides?",
                        "Da cosa sono determinate le maree?",
                        "Qual é a razão das marés?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "They are caused by the mix of the Earth's centrifugal force and the gravitational foce exerted by the Moon",
                            "Dall'azione combinata della forza centrifuga terrestre e della forza gravitazionale esercitata dalla Luna",
                            "Elas são causadas pela combinação da força centrífuga da Terra e da força gravitacional exercida pela Lua."
                        ),
                        Util.EngItaPor(
                            "Dalla forza centrifuga dovuta alla rotazione della Terra",
                            "Dalla forza centrifuga dovuta alla rotazione della Terra",
                            "Devido à força centrífuga causada pela rotação da Terra."
                        ),
                        Util.EngItaPor(
                            "They are generated by the attraction of the Sun and the Moon",
                            "Dall'attrazione esercitata dal Sole e dalla Luna",
                            "Elas são geradas pela atração do Sol e da Lua."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the reason for the different length of day and nigh during the year?",
                        "A cosa è dovuta la diversa durata del giorno e della notte durante l'anno?",
                        "Qual é a razão para o comprimento diferente do dia e da noite durante o ano?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Inclination of the axis of rotation with respect to the orbit plane",
                            "All'inclinazione dell'asse di rotazione rispetto al piano dell'orbita",
                            "Inclinação do eixo de rotação em relação ao plano orbital."
                        ),
                        Util.EngItaPor(
                            "Earth's revolving motion",
                            "Al moto di rivoluzione della Terra",
                            "Movimento de rotação da Terra."
                        ),
                        Util.EngItaPor(
                            "Rotation of the Earth around its axis",
                            "Al moto di rotazione della Terra attorno al suo asse",
                            "Rotação da Terra em torno de seu eixo."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the sidereal day?",
                        "Che cos'è il giorno sidereo?",
                        "O que é o dia sideral?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "The time it take the Earth to rotate around its axis, equal to 23 hours, 56 minutes, and 4 seconds",
                            "Il tempo che impiega la Terra a ruotare attorno al proprio asse, pari a 23 ore, 56 minuti e 4 secondi",
                            "O tempo que a Terra leva para girar em torno de seu eixo, igual a 23 horas, 56 minutos e 4 segundos."
                        ),
                        Util.EngItaPor(
                            "The time it takes the Earth to rotate around its axis, equal to 24 hours",
                            "Il tempo che impiega la Terra a ruotare attorno al proprio asse, pari a 24 ore",
                            "O tempo que a Terra leva para girar em torno de seu eixo, igual a 24 horas."
                        ),
                        Util.EngItaPor(
                            "The time it takes the Moon to rotate around its axis",
                            "Il tempo che impiega la Luna a ruotare attorno al proprio asse",
                            "O tempo que a Lua leva para girar em torno de seu eixo."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the acceleration of gravity on the Earth's surface?",
                        "Qual è l'accelerazione di gravità sulla superficie terrestre?",
                        "Qual é a aceleração da gravidade na superfície da Terra?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "9.8 metres per second square",
                            "9.8 metri al secondo quadrato",
                            "9,8 metros por segundo quadrado."
                        ),
                        Util.EngItaPor(
                            "11.2 metres per second square",
                            "11.2 metri al secondo quadrato",
                            "11,2 metros por segundo quadrado."
                        ),
                        Util.EngItaPor(
                            "1.4 metres per second square",
                            "1.4 metri al secondo quadrato",
                            "1,4 metros por segundo quadrado."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Which star is closest to the Earth?",
                        "Qual è la stella più vicina alla Terra?",
                        "Qual estrela está mais próxima da Terra?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "The Sun",
                            "Sole",
                            "O Sol."
                        ),
                        Util.EngItaPor(
                            "Sirius",
                            "Sirio",
                            "Sirius."
                        ),
                        Util.EngItaPor(
                            "Proxima Centauri",
                            "Proxima Centauri",
                            "Proxima Centauri."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "The Earth describes an orbit around the Sun",
                        "La Terra descrive un orbita intorno al Sole",
                        "A Terra descreve uma órbita ao redor do Sol"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Which is slightly elliptical",
                            "Leggermente ellittica",
                            "Que é ligeiramente elíptica"
                        ),
                        Util.EngItaPor(
                            "Which is perfectly circular",
                            "Perfettamente circolare",
                            "Que é perfeitamente circular"
                        ),
                        Util.EngItaPor(
                            "Which is very much elliptical",
                            "Molto ellittica",
                            "Que é muito elíptica."
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "mars", Util.EngItaPor("Mars", "Marte", "Marte"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How big is Mars compared to the Earth?",
                        "Quanto è grande Marte rispetto alla Terra?",
                        "Qual é o tamanho de Marte é em comparação com o tamanho da Terra?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "It is smaller",
                            "È più piccolo",
                            "É menor."
                        ),
                        Util.EngItaPor(
                            "It is slightly bigger",
                            "È poco più grande",
                            "É ligeiramente maior"
                        ),
                        Util.EngItaPor(
                            "It is equal to the Earth",
                            "È uguale",
                            "É igual à Terra"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a day on Mars?",
                        "Quanto è lungo un giorno su Marte?",
                        "Quanto tempo dura um dia em Marte?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 25 hours",
                            "Circa 25 ore",
                            "Cerca de 25 horas."
                        ),
                        Util.EngItaPor(
                            "About 48 hours",
                            "Circa 48 ore",
                            "Cerca de 48 horas"
                        ),
                        Util.EngItaPor(
                            "24 hours",
                            "24 ore",
                            "24 horas"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a year on Mars?",
                        "Quanto è lungo un anno su Marte?",
                        "Quanto tempo dura um ano em Marte?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "687 Earth days",
                            "687 giorni terrestri",
                            "687 dias terrestres."
                        ),
                        Util.EngItaPor(
                            "364 Earth days",
                            "364 giorni terrestri",
                            "364 dias terrestres"
                        ),
                        Util.EngItaPor(
                            "12 Earth years",
                            "12 anni terrestri",
                            "12 anos terrestres"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the temperature on Mars?",
                        "Qual è la temperatura su Marte?",
                        "Qual é a temperatura em Marte?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "It varies between -140 and 25 degrees Celsius",
                            "Varia tra -140 e 25 gradi celsius",
                            "Varia entre -140 e 25 graus Celsius."
                        ),
                        Util.EngItaPor(
                            "It varies between -80 and 80 degrees",
                            "Varia tra -80 e 80 gradi",
                            "Varia entre -80 e 80 graus Celsius"
                        ),
                        Util.EngItaPor(
                            "About 25 degrees Celsius, everywherre",
                            "Circa 25 gradi celsius, ovunque",
                            "Cerca de 25 graus Celsius em todos os lugares"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many satellites does Mars have?",
                        "Quanti satelliti ha Marte?",
                        "Quantas luas Marte tem?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "2",
                            "2",
                            "2"
                        ),
                        Util.EngItaPor(
                            "1",
                            "1",
                            "1"
                        ),
                        Util.EngItaPor(
                            "0",
                            "0",
                            "0"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the atmospheric pressure on the surface of Mars?",
                        "Quanto vale la pressione atmosferica sulla superficie di Marte?",
                        "Qual é a pressão atmosférica na superfície de Marte?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About a tenth of the Earth's",
                            "Circa un decimo di quella terrestre",
                            "Cerca de um décimo da Terra."
                        ),
                        Util.EngItaPor(
                            "It is like the Earth's",
                            "Come quella terrestre",
                            "É como a da Terra"
                        ),
                        Util.EngItaPor(
                            "It is about 10 timed that of the Earth",
                            "Circa 10 volte quella terrestre",
                            "É cerca de 10 vezes a da Terra"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the main component of Mars' atmosphere?",
                        "Da cosa è composta principalmente l'atmosfera di Marte?",
                        "Qual é o principal componente da atmosfera de Marte?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Carbon dioxide",
                            "Diossido di carbonio",
                            "Dióxido de carbono."
                        ),
                        Util.EngItaPor(
                            "Nitrogen and Argon",
                            "Azoto e argon",
                            "Nitrogênio e argônio"
                        ),
                        Util.EngItaPor(
                            "Oxygen and nitrogen",
                            "Ossigeno e azoto",
                            "Oxigênio e nitrogênio"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How much would you wiegh on Mars compared to the Earth?",
                        "Quanto peseresti su Marte rispetto alla Terra?",
                        "Quanto você pesaria em Marte em comparação com a Terra?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About a third",
                            "Circa un terzo",
                            "Cerca de um terço."
                        ),
                        Util.EngItaPor(
                            "More than on the Earth",
                            "Più che sulla Terra",
                            "Mais do que na Terra"
                        ),
                        Util.EngItaPor(
                            "The same weight",
                            "Avrei lo stesso peso che ho sulla Terra",
                            "O mesmo peso"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Why is Mars called the Red Planet?",
                        "Perché Marte viene chiamato il Pianeta rosso?",
                        "Por que Marte é chamado de Planeta Vermelho?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "For its colour, due to great quantities of iron oxide",
                            "Per il suo colore dovuto a grandi quantità di ossido di ferro",
                            "Por sua cor, devido à grande quantidade de óxido de ferro."
                        ),
                        Util.EngItaPor(
                            "Because it reflects sunlight",
                            "Perché riflette la luce del Sole",
                            "Porque reflete a luz solar"
                        ),
                        Util.EngItaPor(
                            "Because it is very hot",
                            "Perché è molto caldo",
                            "Porque é muito quente"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What atmospheric event can take place on the surface of Mars?",
                        "Quale evento atmosferico può avvenire sulla superficie di Marte?",
                        "Que evento atmosférico pode ocorrer na superfície de Marte?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Sand storms",
                            "Tempeste di sabbia",
                            "Tempestades de areia."
                        ),
                        Util.EngItaPor(
                            "Rain",
                            "Pioggia",
                            "Chuva"
                        ),
                        Util.EngItaPor(
                            "Snow",
                            "Neve",
                            "Neve"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "jupiter", Util.EngItaPor("Jupiter", "Giove", "Júpiter"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the Red Spot on Jupiter?",
                        "Che cosa è la macchia Rossa su Giove?",
                        "O que é a Mancha Vermelha em Júpiter?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A storm",
                            "Una tempesta",
                            "Uma tempestade."
                        ),
                        Util.EngItaPor(
                            "A crater",
                            "Un cratere",
                            "Uma cratera."
                        ),
                        Util.EngItaPor(
                            "A volcano",
                            "Un vulcano",
                            "Um vulcão."
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a day on Jupiter?",
                        "Quanto è lungo un giorno su Giove?",
                        "Quanto tempo dura um dia em Júpiter?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "9.92 hours",
                            "9.92 ore",
                            "9,92 horas."
                        ),
                        Util.EngItaPor(
                            "10 Earth days",
                            "10 giorni terrestri",
                            "10 dias terrestres"
                        ),
                        Util.EngItaPor(
                            "99 Earth days",
                            "99 giorni terrestri",
                            "99 dias terrestres"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a year in Jupiter?",
                        "Quanto è lungo un anno su Giove?",
                        "Quanto tempo dura um ano em Júpiter?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "12 Earth years",
                            "12 anni terrestri",
                            "12 anos terrestres."
                        ),
                        Util.EngItaPor(
                            "120 Earth days",
                            "120 anni terrestri",
                            "120 dias terrestres"
                        ),
                        Util.EngItaPor(
                            "120 Earth days",
                            "120 giorni terrestri",
                            "120 dias terrestres"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the temperature on Jupiter?",
                        "Qual'è la temperatura su Giove?",
                        "Qual é a temperatura em Júpiter?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "-150 degrees centigrades",
                            "-150 gradi centigradi",
                            "150 graus Celsius."
                        ),
                        Util.EngItaPor(
                            "10 degrees centigrades",
                            "10 gradi centigradi",
                            "10 graus Celsius"
                        ),
                        Util.EngItaPor(
                            "150 degrees centigrades",
                            "150 gradi centigradi",
                            "150 graus Celsius"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many satellites does Jupiter have?",
                        "Quanti satelliti ha Giove?",
                        "Quantos satélites Júpiter tem?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "79",
                            "79",
                            "79"
                        ),
                        Util.EngItaPor(
                            "64",
                            "64",
                            "64"
                        ),
                        Util.EngItaPor(
                            "18",
                            "18",
                            "18"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the main component of Jupiter's atmosphere?",
                        "Da cosa è composta principalmente l'atmosfera di Giove?",
                        "Qual é o principal componente da atmosfera de Júpiter?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Hydrogen and helium",
                            "Idrogeno ed elio",
                            "Hidrogênio e Hélio."
                        ),
                        Util.EngItaPor(
                            "Ammonia and methane",
                            "Ammoniaca e metano",
                            "Amônia e metano"
                        ),
                        Util.EngItaPor(
                            "Methane and water",
                            "Metano e acqua",
                            "Metano e água"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What us the mass of Jupiter compared to the Earth?",
                        "Quant'è la massa di Giove rispetto a quella della Terra?",
                        "Qual é a massa de Júpiter em comparação com a Terra?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "318 times larger",
                            "318 volte più grande",
                            "318 vezes maior."
                        ),
                        Util.EngItaPor(
                            "31.8 times larger",
                            "31.8 volte più grande",
                            "31,8 vezes maior"
                        ),
                        Util.EngItaPor(
                            "3180 times larger",
                            "3180 volte più grande",
                            "3180 vezes maior"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What are the bands you see on the surface of Jupiter?",
                        "Che cosa sono le bande che si vedono sulla superficie di Giove?",
                        "O que são as faixas que você vê na superfície de Júpiter?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Clouds of different chemical composition",
                            "Nubi di diversa composizione chimica",
                            "Nuvens de diferentes composições químicas."
                        ),
                        Util.EngItaPor(
                            "Grounds with different chemical compositions",
                            "Terreni con diverse composizioni chimiche",
                            "Superfícies com diferentes composições químicas"
                        ),
                        Util.EngItaPor(
                            "Grounds of different colours",
                            "Terreni di diversi colori",
                            "Superfícies de diferentes cores"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Does Jupiter have rings?",
                        "Giove ha degli anelli?",
                        "Júpiter tem anéis?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Yes, but they are too faint to be seen from the Earth",
                            "Sì, ma troppo deboli per essere visti dalla Terra",
                            "Sim, mas são muito tênues para serem vistos da Terra."
                        ),
                        Util.EngItaPor(
                            "No",
                            "No",
                            "Não"
                        ),
                        Util.EngItaPor(
                            "Yes, they can be seen very clearly from the Earth",
                            "Sì, si vedono bene dalla Terra",
                            "Sim, podem ser vistos muito claramente da Terra"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the name of the larger moons observed by Galileo?",
                        "Come si chiamano le lune più grandi osservate da Galileo?",
                        "Qual é o nome das maiores luas observadas por Galileu?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Io, Europa, Ganymede, Callistus",
                            "Io, Europa, Ganimede, Callisto",
                            "Io, Europa, Ganimedes e Calisto."
                        ),
                        Util.EngItaPor(
                            "Titan, Enceladus, Phobos, Charon",
                            "Titano, Encelado, Phobos, Caronte",
                            "Titã, Encélado, Phobos, Caronte"
                        ),
                        Util.EngItaPor(
                            "Miranda, Charon, Deimos, Mimas",
                            "Miranda, Caronte, Deimos, Mimas",
                            "Miranda, Caronte, Deimos, Mimas"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "saturn", Util.EngItaPor("Saturn", "Saturno", "Saturno"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the shape of the storm at the north pole of Saturn?",
                        "Che forma ha la tempesta al polo nord di Saturno?",
                        "Qual é a forma da tempestade no polo norte de Saturno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Hexagonal",
                            "Esagonale",
                            "Hexagonal"
                        ),
                        Util.EngItaPor(
                            "Round",
                            "Circolare",
                            "Redonda"
                        ),
                        Util.EngItaPor(
                            "Square",
                            "Quadrata",
                            "Quadrada"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the radius of Saturn?",
                        "Qual'è il raggio di Saturno?",
                        "Qual é o raio de Saturno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "60 thousand kilometers, slightly smaller of Jupiter",
                            "60mila chilometri, poco meno di quello di Giove",
                            "60 mil quilômetros, ligeiramente menor que Júpiter"
                        ),
                        Util.EngItaPor(
                            "6000 kilometers, a little less than the Earth radius",
                            "6000 chilometri, poco meno di quello terrestre",
                            "6.000 quilômetros, um pouco menor que o raio da Terra"
                        ),
                        Util.EngItaPor(
                            "25 thousand kilometers, more or less like that of Uranus and Neptune",
                            "25mila chilometri, circa come quello di urano e nettuno",
                            "25 mil quilômetros, mais ou menos como o de Urano e Netuno"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a day on Saturn?",
                        "Quanto è lungo un giorno su Saturno?",
                        "Quanto tempo dura um dia em Saturno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "10.24 ore",
                            "10.24 ore",
                            "10,24 horas"
                        ),
                        Util.EngItaPor(
                            "25 hours",
                            "25 ore",
                            "25 horas"
                        ),
                        Util.EngItaPor(
                            "88 Earth days",
                            "88 giorni terrestri",
                            "88 dias terrestres"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a year on Saturn?",
                        "Quanto è lungo un anno su Saturno?",
                        "Quanto tempo dura um ano em Saturno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "30 anni terrestri",
                            "30 anni terrestri",
                            "30 anos terrestres"
                        ),
                        Util.EngItaPor(
                            "12 Earth years",
                            "12 anni terrestri",
                            "12 anos terrestres"
                        ),
                        Util.EngItaPor(
                            "687 days",
                            "687 giorni",
                            "687 dias terrestres"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the temperature on Saturn?",
                        "Qual'è la temperatura su Saturno?",
                        "Qual é a temperatura em Saturno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "-130 gradi",
                            "-130 gradi",
                            "-130 graus"
                        ),
                        Util.EngItaPor(
                            "-200 degrees",
                            "-200 gradi",
                            "-200 graus"
                        ),
                        Util.EngItaPor(
                            "10 degrees",
                            "10 gradi",
                            "10 graus"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many satellites does Saturn have?",
                        "Quanti satelliti ha Saturno?",
                        "Quantos satélites Saturno possui?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "82",
                            "82",
                            "82"
                        ),
                        Util.EngItaPor(
                            "79",
                            "79",
                            "79"
                        ),
                        Util.EngItaPor(
                            "27",
                            "27",
                            "27"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the main component of Saturn's atmosphere?",
                        "Da cosa è composta principalmente l'atmosfera di Saturno?",
                        "Qual é o componente principal da atmosfera de Saturno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Hydrogen and helium",
                            "Idrogeno e elio",
                            "Hidrogênio e hélio"
                        ),
                        Util.EngItaPor(
                            "Ammonia and methane",
                            "Ammoniaca e metano",
                            "Amônia e metano"
                        ),
                        Util.EngItaPor(
                            "Methane and water",
                            "Metano e acqua",
                            "Metano e água"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Quanto sono estesi gli anelli di Saturno?",
                        "Quanto sono estesi gli anelli di Saturno?",
                        "Quão extensos são os anéis de Saturno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "200 thousand kilometers",
                            "200mila chilometri",
                            "200 mil quilômetros"
                        ),
                        Util.EngItaPor(
                            "20 thousand kilometers",
                            "20mila chilometri",
                            "20 mil quilômetros"
                        ),
                        Util.EngItaPor(
                            "2000 kilometers",
                            "2000 chilometri",
                            "2.000 quilômetros"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Qual è il satellite più grande di Saturno?",
                        "Qual è il satellite più grande di Saturno?",
                        "Qual é a maior lua de Saturno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Titan",
                            "Titano",
                            "Titã"
                        ),
                        Util.EngItaPor(
                            "Ganymede",
                            "Ganimede",
                            "Ganimedes"
                        ),
                        Util.EngItaPor(
                            "Callistus",
                            "Callisto",
                            "Calisto"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Di cosa sono formati gli anelli?",
                        "Di cosa sono formati gli anelli?",
                        "Do que são formados os anéis?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "They are made of ice rock",
                            "Sono fatti di ghiaccio e roccia",
                            "São feitos de gelo rochoso"
                        ),
                        Util.EngItaPor(
                            "They are other tiny planets",
                            "Sono altri pianeti piccolissimi",
                            "São outros planetas pequenos"
                        ),
                        Util.EngItaPor(
                            "They are made of dust",
                            "Sono fatti di polveri",
                            "São feitos de poeira"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "uranus", Util.EngItaPor("Uranus", "Urano", "Urano"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the radius of Uranus?",
                        "Qual è il raggio di Urano?",
                        "Qual é o raio de Urano?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 25 thousand kilometer, just like Neptun's one",
                            "Circa 25mila chilometri, simile a quello di Nettuno",
                            "Cerca de 25 mil quilômetros, assim como o de Netuno"
                        ),
                        Util.EngItaPor(
                            "About 60 thousand kilometers, just like Saturn's one",
                            "Circa 60mila chilometri, simile a quello di Saturno",
                            "Cerca de 60 mil quilômetros, assim como o de Saturno"
                        ),
                        Util.EngItaPor(
                            "About 6 thousand kilometers, just like Venu's one",
                            "Circa 6mila chilometri, simile a quello di Venere",
                            "Cerca de 6 mil quilômetros, assim como o de Vênus"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a day on Uranus?",
                        "Quanto è lungo un giorno su Urano?",
                        "Quanto tempo dura um dia em Urano?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 15.6 Earth hours",
                            "Circa 15.6 ore terrestri",
                            "Cerca de 15,6 horas terrestres"
                        ),
                        Util.EngItaPor(
                            "More or less as the Earth",
                            "Circa come quello sulla Terra",
                            "Mais ou menos como a Terra"
                        ),
                        Util.EngItaPor(
                            "Less than 10 hours, it's the fastest planet",
                            "Meno di 10 ore, è il pianeta più veloce",
                            "Menos de 10 horas, é o planeta mais rápido"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a year on Uranus?",
                        "Quanto è lungo un anno su Urano?",
                        "Quanto tempo dura um ano em Urano?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 84 Earth years",
                            "Circa 84 anni terrestri",
                            "Cerca de 84 anos terrestres"
                        ),
                        Util.EngItaPor(
                            "More or less as the Earth",
                            "Circa come quello sulla Terra",
                            "Mais ou menos como a Terra"
                        ),
                        Util.EngItaPor(
                            "About 165 years",
                            "Circa 165 anni",
                            "Cerca de 165 anos terrestres"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What does Uranus consist of?",
                        "Di cosa è fatto principalmente Urano?",
                        "Do que Urano é composto?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Gas",
                            "Gas",
                            "Gás"
                        ),
                        Util.EngItaPor(
                            "Water",
                            "Acqua",
                            "Água"
                        ),
                        Util.EngItaPor(
                            "Soil",
                            "Terra",
                            "Solo"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Is Uranus the farthest planet from the Sun?",
                        "Urano è il pianeta più distante dal Sole?",
                        "Urano é o planeta mais distante do Sol?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "No",
                            "No",
                            "Não"
                        ),
                        Util.EngItaPor(
                            "Yes",
                            "Sì",
                            "Sim"
                        ),
                        Util.EngItaPor(
                            "According to the period of the year",
                            "Dipende dal periodo dell'anno",
                            "Depende do período do ano"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many moons does Uranus have?",
                        "Quante lune ha Urano?",
                        "Quantas luas Urano possui?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "27",
                            "27",
                            "27"
                        ),
                        Util.EngItaPor(
                            "None",
                            "Nessuno",
                            "Nenhuma"
                        ),
                        Util.EngItaPor(
                            "10",
                            "10",
                            "10"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the peculiarity of Uranus?",
                        "Qual è la particolarità di Urano?",
                        "Qual é a peculiaridade de Urano?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Its axis of rotation is almost parallel to the orbit plane",
                            "Il suo asse di rotazione è quasi parallelo al piano dell'orbita",
                            "Seu eixo de rotação é quase paralelo ao plano da órbita"
                        ),
                        Util.EngItaPor(
                            "It has a retrograde revolution motion",
                            "Ha un moto di rivoluzione retrogrado",
                            "Tem um movimento de revolução retrógrado"
                        ),
                        Util.EngItaPor(
                            "It's the slowest planet of the Solar System",
                            "È il pianeta più lento del Sistema solare",
                            "É o planeta mais lento do Sistema Solar"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Has Uranus been known since ancient times?",
                        "Urano è conosciuto fin dall'antichità?",
                        "Urano era conhecido desde os tempos antigos?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "No, it was discovered in 1781",
                            "No, è stato scoperto nel 1781",
                            "Não, foi descoberto em 1781"
                        ),
                        Util.EngItaPor(
                            "Yes, since the ancient Greeks",
                            "Sì, fin dagli antichi greci",
                            "Sim, desde os antigos gregos"
                        ),
                        Util.EngItaPor(
                            "No, it was discovered by Galileo",
                            "No, è stato scoperto da Galileo",
                            "Não, foi descoberto por Galileu"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Does Uranus have rings?",
                        "Urano ha degli anelli?",
                        "Urano possui anéis?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Yes, it has 13 rings",
                            "Sì, sono 13",
                            "Sim, possui 13 anéis"
                        ),
                        Util.EngItaPor(
                            "No",
                            "No",
                            "Não"
                        ),
                        Util.EngItaPor(
                            "Yes, just one",
                            "Sì, ne ha uno",
                            "Sim, apenas um"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Why does it appear blue?",
                        "Perchè appare di colore azzurro?",
                        "Por que Urano parece azul?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Because of the presence of methane in its atmosphere",
                            "Per la presenza di metano nella sua atmosfera",
                            "Devido à presença de metano em sua atmosfera"
                        ),
                        Util.EngItaPor(
                            "For the presence of oxygen in its atmosphere",
                            "Per la presenza di ossigeno nella sua atmosfera",
                            "Devido à presença de oxigênio em sua atmosfera"
                        ),
                        Util.EngItaPor(
                            "For the presence of nitrogen in its atmosphere",
                            "Per la presenza di azoto nella sua atmosfera",
                            "Devido à presença de nitrogênio em sua atmosfera"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "neptune", Util.EngItaPor("Neptune", "Nettuno", "Netuno"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the radius dof Neptune?",
                        "Qual è il raggio di Nettuno?",
                        "Qual é o raio de Netuno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 25 thousand kilometres, similar to that of Uranus",
                            "Circa 25mila chilometri, simile a quello di Urano",
                            "Cerca de 25 mil quilômetros, similar ao de Urano"
                        ),
                        Util.EngItaPor(
                            "About 60 thousand, similar to that of Jupiter",
                            "Circa 60mila, simile a quello di Giove",
                            "Cerca de 60 mil quilômetros, similar ao de Júpiter"
                        ),
                        Util.EngItaPor(
                            "About 3 thousand, similar to that of Mars",
                            "Circa 3mila, simile a quello di Marte",
                            "Cerca de 3 mil quilômetros, similar ao de Marte"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a day on Neptune?",
                        "Quanto è lungo un giorno su Nettuno?",
                        "Quanto tempo dura um dia em Netuno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 16 Earth hours",
                            "Circa 16 ore terrestri",
                            "Cerca de 16 horas terrestres"
                        ),
                        Util.EngItaPor(
                            "Circa 16 giorni terrestri",
                            "Circa 16 giorni terrestri",
                            "Cerca de 16 dias terrestres"
                        ),
                        Util.EngItaPor(
                            "About 1 Earth week",
                            "Circa 1 settimana terrestre",
                            "Cerca de 1 semana terrestre"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a year on Neptune?",
                        "Quanto è lungo un anno su Nettuno?",
                        "Quanto tempo dura um ano em Netuno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 165 Earth years",
                            "Circa 165 anni terrrestri",
                            "Cerca de 165 anos terrestres"
                        ),
                        Util.EngItaPor(
                            "Circa 1 anno terrestre",
                            "Circa 1 anno terrestre",
                            "Cerca de 1 ano terrestre"
                        ),
                        Util.EngItaPor(
                            "About 50 Earth years",
                            "Circa 50 anni terrestri",
                            "Cerca de 50 anos terrestres"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the average temperature of Neptune?",
                        "Qual è la temperatura media di Nettuno?",
                        "Qual é a temperatura média de Netuno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "-220 °C",
                            "-220 °C",
                            "-220 °C"
                        ),
                        Util.EngItaPor(
                            "220 °C",
                            "220 °C",
                            "220 °C"
                        ),
                        Util.EngItaPor(
                            "-40 °C",
                            "-40 °C",
                            "-40 °C"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many natural satellites does Neptune have?",
                        "Quanti satelliti naturali ha Nettuno?",
                        "Quantas luas naturais Netuno possui?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "14",
                            "14",
                            "14"
                        ),
                        Util.EngItaPor(
                            "10",
                            "10",
                            "10"
                        ),
                        Util.EngItaPor(
                            "27",
                            "27",
                            "27"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Which is Neptune's largest satellite?",
                        "Qual è il satellite più grande di Nettuno?",
                        "Qual é a maior lua de Netuno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Triton",
                            "Tritone",
                            "Tritão"
                        ),
                        Util.EngItaPor(
                            "Ariel",
                            "Ariel",
                            "Ariel"
                        ),
                        Util.EngItaPor(
                            "Titan",
                            "Titano",
                            "Titã"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What planet does Neptuen look like by composition of atmosphere?",
                        "A quale pianeta assomiglia per composizione dell'atmosfera Nettuno?",
                        "A que planeta Netuno se assemelha pela composição da atmosfera?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Uranus",
                            "Urano",
                            "Urano"
                        ),
                        Util.EngItaPor(
                            "Giove",
                            "Giove",
                            "Júpiter"
                        ),
                        Util.EngItaPor(
                            "Saturn",
                            "Saturno",
                            "Saturno"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What structures can we observe in Neptune's atmosphere?",
                        "Quali strutture si possono osservare nell'atmosfera di Nettuno?",
                        "Que estruturas podemos observar na atmosfera de Netuno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Cyclones of considerable size",
                            "Cicloni di notevoli dimensioni",
                            "Ciclones de tamanho considerável"
                        ),
                        Util.EngItaPor(
                            "There are no structures, its atmosphere is uniform",
                            "Non ci sono strutture, la sua atmosfera è uniforme",
                            "Não há estruturas, sua atmosfera é uniforme"
                        ),
                        Util.EngItaPor(
                            "The Dark Spot, a cyclon larger than Jupiter's Red Spot",
                            "La Macchia Scura, un ciclone più grande della Macchia Rossa di Giove",
                            "A Mancha Escura, um ciclone maior que a Mancha Vermelha de Júpiter"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Does Neptune have rings?",
                        "Nettuno ha degli anelli?",
                        "Netuno possui anéis?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Yes, there are 6 rings",
                            "Sì, sono 6",
                            "Sim, possui 6 anéis"
                        ),
                        Util.EngItaPor(
                            "No",
                            "No",
                            "Não"
                        ),
                        Util.EngItaPor(
                            "Yes, it has one ring",
                            "Sì, ne ha uno",
                            "Sim, possui um anel"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Has Neptune been known since ancient times?",
                        "Nettuno è conosciuto fin dall'antichità?",
                        "Netuno era conhecido desde os tempos antigos?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "No, it was discovered in 1846 with a telescope",
                            "No, è stato scoperto nel 1846 con il telescopio",
                            "Não, foi descoberto em 1846 com um telescópio"
                        ),
                        Util.EngItaPor(
                            "Yes, since the ancient Greeks",
                            "Sì, fin dagli antichi greci",
                            "Sim, desde os antigos gregos"
                        ),
                        Util.EngItaPor(
                            "No, it was discovered by Galileo",
                            "No, è stato scoperto da Galileo",
                            "Não, foi descoberto por Galileu"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "pluto", Util.EngItaPor("Pluto", "Plutone", "Plutão"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Which planet is no longer considered a planet since 2006?",
                        "Quale pianeta dal 2006 non è più considerato tale?",
                        "Qual planeta não é mais considerado um planeta desde 2006?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Pluto",
                            "Plutone",
                            "Plutão"
                        ),
                        Util.EngItaPor(
                            "Ganymede",
                            "Ganimede",
                            "Ganymede"
                        ),
                        Util.EngItaPor(
                            "Neptune",
                            "Nettuno",
                            "Netuno"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the name of the largest satellite of Pluto?",
                        "Come si chiama il satellite più grande di Plutone?",
                        "Qual é o nome do maior satélite de Plutão?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Charon",
                            "Caronte",
                            "Charon"
                        ),
                        Util.EngItaPor(
                            "Ganymede",
                            "Ganimede",
                            "Ganymede"
                        ),
                        Util.EngItaPor(
                            "Titan",
                            "Titano",
                            "Titã"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the average surface temperature on Pluto?",
                        "Qual è la temperatura media superficiale su Plutone?",
                        "Qual é a temperatura média da superfície em Plutão?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "-228°C",
                            "-228°C",
                            "-228°C"
                        ),
                        Util.EngItaPor(
                            "-252°C",
                            "-252°C",
                            "-252°C"
                        ),
                        Util.EngItaPor(
                            "-125°C",
                            "-125°C",
                            "-125°C"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "In what year was Pluto discovered?",
                        "In che anno è stato scoperto Plutone?",
                        "Em que ano Plutão foi descoberto?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "1930",
                            "1930",
                            "1930"
                        ),
                        Util.EngItaPor(
                            "1870",
                            "1870",
                            "1870"
                        ),
                        Util.EngItaPor(
                            "1912",
                            "1912",
                            "1912"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Pluto's surface shows a structure with a characteristic shape. What is it?",
                        "La superficie di Plutone mostra una struttura dalla forma caratteristica. Di quale forma si tratta?",
                        "A superfície de Plutão mostra uma estrutura com uma forma característica. O que é?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Heart",
                            "Cuore",
                            "Coração"
                        ),
                        Util.EngItaPor(
                            "Rabbit",
                            "Coniglio",
                            "Coelho"
                        ),
                        Util.EngItaPor(
                            "Cat",
                            "Gatto",
                            "Gato"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How is Pluto classified?",
                        "Come è classificato Plutone?",
                        "Como Plutão é classificado?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Dwarf planet",
                            "Pianeta nano",
                            "Planeta anão"
                        ),
                        Util.EngItaPor(
                            "Planet",
                            "Pianeta",
                            "Planeta"
                        ),
                        Util.EngItaPor(
                            "Asteroid",
                            "Asteroide",
                            "Asteroide"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How big is Pluto?",
                        "Quant'è grande Plutone?",
                        "Quão grande é Plutão?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "It is smaller than the Moon",
                            "È più piccolo della Luna",
                            "É menor que a Lua"
                        ),
                        Util.EngItaPor(
                            "It is larger than the Moon but smaller than the Earth",
                            "È più grande della Luna ma più piccolo della Terra",
                            "É maior que a Lua, mas menor que a Terra"
                        ),
                        Util.EngItaPor(
                            "It has more or less the same size of the Earth",
                            "Di dimensioni simili alla Terra",
                            "Tem mais ou menos o mesmo tamanho da Terra"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Where is Pluto located?",
                        "Dove si trova Plutone?",
                        "Onde está localizado Plutão?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Before the Kuiper belt",
                            "Prima della fascia di Kuiper",
                            "Antes do Cinturão de Kuiper"
                        ),
                        Util.EngItaPor(
                            "Between Mars and Jupiter, in the asteroid belt",
                            "Tra Marte e Giove, nella fascia degli asteroidi",
                            "Entre Marte e Júpiter, no cinturão de asteroides"
                        ),
                        Util.EngItaPor(
                            "Between Uranus and Neptune",
                            "Tra Urano e Nettuno",
                            "Entre Urano e Netuno"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long is a year on Pluto?",
                        "Quanto è lungo un anno su Plutone?",
                        "Quanto tempo dura um ano em Plutão?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 248 Earth years",
                            "Circa 248 anni terrestri",
                            "Cerca de 248 anos terrestres"
                        ),
                        Util.EngItaPor(
                            "About 1 Earth year",
                            "Circa 1 anno terrestre",
                            "Cerca de 1 ano terrestre"
                        ),
                        Util.EngItaPor(
                            "About 50 Earth years",
                            "Circa 50 anni terrestri",
                            "Cerca de 50 anos terrestres"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many satellites does Pluto have?",
                        "Quanti satelliti ha Plutone?",
                        "Quantos satélites Plutão possui?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "5",
                            "5",
                            "5"
                        ),
                        Util.EngItaPor(
                            "3",
                            "3",
                            "3"
                        ),
                        Util.EngItaPor(
                            "1",
                            "1",
                            "1"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "moon", Util.EngItaPor("The Moon", "La Luna", "A Lua"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many days does it take to see the same Moon phase again?",
                        "Quanti giorni passano per rivedere una stessa fase lunare?",
                        "Quantos dias são necessários para ver a mesma fase da Lua novamente?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 29 days",
                            "Circa 29 giorni",
                            "Cerca de 29 dias."
                        ),
                        Util.EngItaPor(
                            "7 days",
                            "7 giorni",
                            "7 dias aproximadamente"
                        ),
                        Util.EngItaPor(
                            "About 27 days",
                            "Circa 27 giorni",
                            "Cerca de 27 dias"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Why do astronauts seem to “bounce off” the Moon?",
                        "Perchè sulla Luna gli astronauti sembrano “rimbalzare”?",
                        "Por que os astronautas parecem “quicar” na Lua?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Because the force of gravity is lower",
                            "Perchè la forza di gravità è minore",
                            "Porque a força da gravidade é menor."
                        ),
                        Util.EngItaPor(
                            "Because there is no atmosphere",
                            "Perchè non c'è atmosfera",
                            "Porque não há atmosfera"
                        ),
                        Util.EngItaPor(
                            "Because the soil is springy",
                            "Perchè il terreno è elastico",
                            "Porque o solo é elástico"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What morphologies can be observed on the surface of the Moon?",
                        "Che morfologie si possono osservare sulla superficie della Luna?",
                        "Quais morfologias podem ser observadas na superfície da Lua?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Craters",
                            "Crateri",
                            "Crateras."
                        ),
                        Util.EngItaPor(
                            "Rivers",
                            "Fiumi",
                            "Rios e vulcões"
                        ),
                        Util.EngItaPor(
                            "Volcanoes",
                            "Vulcani",
                            "Vulcões"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Why do we always see the same side of the Moon?",
                        "Perché vediamo sempre la stessa faccia della Luna?",
                        "Por que sempre vemos o mesmo lado da Lua?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Because the rotation period is equal to that of revolution",
                            "Perché il periodo di rotazione è uguale a quello di rivoluzione",
                            "Porque o período de rotação é igual ao período de revolução."
                        ),
                        Util.EngItaPor(
                            "Because it does not revolve around itself, but only qround the Earth",
                            "Perché non gira su se stessa, ma solo intorno alla Terra",
                            "Porque não gira em torno de si mesma, mas apenas ao redor da Terra"
                        ),
                        Util.EngItaPor(
                            "Because the only period in which the Moon turns its hidden side towards us takes place when we cannot see it in the sky",
                            "Perché l'unico periodo in cui rivolge il lato nascosto verso di noi è quello in cui non la vediamo in cielo",
                            "Porque o único período em que a Lua vira seu lado oculto para nós ocorre quando não podemos vê-lo no céu"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of the Moon phase where the surface is in the shade?",
                        "Come si chiama la fase lunare in cui la superficie è in ombra?",
                        "Qual é o nome da fase da Lua em que a superfície está na sombra?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "New Moon",
                            "Luna Nuova",
                            "Lua Nova."
                        ),
                        Util.EngItaPor(
                            "Full Moon",
                            "Luna Piena",
                            "Lua Cheia"
                        ),
                        Util.EngItaPor(
                            "Crescent Moon",
                            "Luna Crescente",
                            "Lua Crescente"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long does the Moon's rotation period last?",
                        "Quanto dura il periodo di rotazione della Luna?",
                        "Quanto tempo dura o período de rotação da Lua?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 29 days",
                            "Circa 29 giorni",
                            "Cerca de 29 dias."
                        ),
                        Util.EngItaPor(
                            "About 25 days",
                            "Circa 25 giorni",
                            "Aproximadamente 25 dias"
                        ),
                        Util.EngItaPor(
                            "About 24 hours",
                            "Circa 24 ore",
                            "Aproximadamente 24 horas"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long does the Moon's revolution period last?",
                        "Quanto dura il periodo di rivoluzione della Luna?",
                        "Quanto tempo dura o período de revolução da Lua?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 29 days",
                            "Circa 29 giorni",
                            "Cerca de 29 dias."
                        ),
                        Util.EngItaPor(
                            "About 365 days",
                            "Circa 365 giorni",
                            "Aproximadamente 365 dias"
                        ),
                        Util.EngItaPor(
                            "About 24 hours",
                            "Circa 24 ore",
                            "Aproximadamente 24 horas"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What us the lunar atmosphere made of?",
                        "Da cosa è composta l'atmosfera lunare?",
                        "Do que é feita a atmosfera lunar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "The Moon has no atmosphere",
                            "La Luna non ha atmosfera",
                            "A Lua não possui atmosfera."
                        ),
                        Util.EngItaPor(
                            "Nytrogen and oxygen",
                            "Azoto e ossigeno",
                            "A Lua não tem atmosfera"
                        ),
                        Util.EngItaPor(
                            "Oxygen and carbon dioxide",
                            "Ossigeno e anidride carbonica",
                            "Oxigênio e dióxido de carbono"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the Moon?",
                        "Che cos'è la Luna?",
                        "O que é a Lua?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "The Earth's natural satellite",
                            "Il satellite naturale della Terra",
                            "O satélite natural da Terra."
                        ),
                        Util.EngItaPor(
                            "A small planet",
                            "Un pianetino",
                            "O satélite natural da Terra"
                        ),
                        Util.EngItaPor(
                            "An artificial satellite of the Earth",
                            "Un satellite artificiale della Terra",
                            "Um satélite artificial da Terra"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the name of the phenomenon by which the Sun disk is obscured by the Moon?",
                        "Come si chiama il fenomeno per cui il disco del Sole viene oscurato dalla Luna?",
                        "Qual é o nome do fenômeno pelo qual o disco solar é obscurecido pela Lua?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Solar eclipse",
                            "Eclissi di Sole",
                            "Eclipse Solar."
                        ),
                        Util.EngItaPor(
                            "Moon eclipse",
                            "Eclissi di Luna",
                            "Eclipse Solar"
                        ),
                        Util.EngItaPor(
                            "New Moon",
                            "Novilunio",
                            "Lua Nova"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "solarsystem", Util.EngItaPor("Solar System", "Sistema Solare", "Sistema Solar"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many planets are there in the Solar System?",
                        "Quanti sono i pianeti del Sistema Solare?",
                        "Quantos planetas existem no Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "8",
                            "8",
                            "8"
                        ),
                        Util.EngItaPor(
                            "9",
                            "9",
                            "9"
                        ),
                        Util.EngItaPor(
                            "10",
                            "10",
                            "10"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many rocky planets are there in the Solar System?",
                        "Quanti sono i pianeti rocciosi del Sistema solare?",
                        "Quantos planetas rochosos existem no Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "4",
                            "4",
                            "4"
                        ),
                        Util.EngItaPor(
                            "5",
                            "5",
                            "5"
                        ),
                        Util.EngItaPor(
                            "3",
                            "3",
                            "3"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Are the orbits of the planets on the same plane?",
                        "Le orbite dei pianeti sono sullo stesso piano?",
                        "As órbitas dos planetas estão no mesmo plano?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Yes, more or less",
                            "Sì, più o meno",
                            "Sim, mais ou menos"
                        ),
                        Util.EngItaPor(
                            "No, they are everywhere",
                            "No, sono dappertutto",
                            "Não, estão por toda parte"
                        ),
                        Util.EngItaPor(
                            "We cannot know this",
                            "Non possiamo saperlo",
                            "Não podemos saber disso"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the largest planet of the Solar System?",
                        "Qual è il pianeta più grande del Sistema solare?",
                        "Qual é o maior planeta do Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Jupiter",
                            "Giove",
                            "Júpiter"
                        ),
                        Util.EngItaPor(
                            "Saturn",
                            "Saturno",
                            "Saturno"
                        ),
                        Util.EngItaPor(
                            "Neptune",
                            "Nettuno",
                            "Netuno"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the smallest planet of the Solar System?",
                        "Qual è il pianeta più piccolo del Sistema solare",
                        "Qual é o menor planeta do Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Mercury",
                            "Mercurio",
                            "Mercúrio"
                        ),
                        Util.EngItaPor(
                            "Venus",
                            "Venere",
                            "Vênus"
                        ),
                        Util.EngItaPor(
                            "Mars",
                            "Marte",
                            "Marte"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is - on average - the coldest planet of the Solar System?",
                        "Qual è il pianeta mediamente più freddo del Sistema solare?",
                        "Qual é - em média - o planeta mais frio do Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Neptune",
                            "Nettuno",
                            "Netuno"
                        ),
                        Util.EngItaPor(
                            "Uranus",
                            "Urano",
                            "Urano"
                        ),
                        Util.EngItaPor(
                            "Jupiter",
                            "Giove",
                            "Júpiter"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Which planet has the fastest winds in the Solar System?",
                        "Quale pianeta ha i venti più veloci del Sistema solare?",
                        "Qual planeta possui os ventos mais rápidos no Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Neptune",
                            "Nettuno",
                            "Netuno"
                        ),
                        Util.EngItaPor(
                            "Uranus",
                            "Urano",
                            "Urano"
                        ),
                        Util.EngItaPor(
                            "Jupiter",
                            "Giove",
                            "Júpiter"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the hottest planet of the Solar System ?",
                        "Qual è il pianeta più caldo del Sistema solare?",
                        "Qual é o planeta mais quente do Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Venus",
                            "Venere",
                            "Vênus"
                        ),
                        Util.EngItaPor(
                            "Mercury",
                            "Mercurio",
                            "Mercúrio"
                        ),
                        Util.EngItaPor(
                            "The Earth",
                            "Terra",
                            "Terra"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What planet is mount Oiympus, the highest volcano of the Solar System, on?",
                        "Su quale pianeta si trova il monte Olimpo, il vulcano più alto del Sistema solare?",
                        "Em qual planeta está localizado o Monte Olimpo, o vulcão mais alto do Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Mars",
                            "Marte",
                            "Marte"
                        ),
                        Util.EngItaPor(
                            "The Earth",
                            "Terra",
                            "Terra"
                        ),
                        Util.EngItaPor(
                            "Venus",
                            "Venere",
                            "Vênus"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What are comets made of?",
                        "Di cosa sono fatte le comete?",
                        "Do que são feitos os cometas?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Ice, rocks, gas",
                            "Ghiaccio, rocce, gas",
                            "Gelo, rochas, gás"
                        ),
                        Util.EngItaPor(
                            "Rock and metals",
                            "Roccia e metalli",
                            "Rocha e metais"
                        ),
                        Util.EngItaPor(
                            "Gas",
                            "Gas",
                            "Gás"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "moons", Util.EngItaPor("Moons", "Lune", "Luas"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Which planet has more moons?",
                        "Quale pianeta ha più lune?",
                        "Qual planeta tem mais luas?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Saturn",
                            "Saturno",
                            "Saturno"
                        ),
                        Util.EngItaPor(
                            "Jupiter",
                            "Giove",
                            "Júpiter"
                        ),
                        Util.EngItaPor(
                            "Uranus",
                            "Urano",
                            "Urano"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What are Titam's oceans made of?",
                        "Da quale elemento sono costituiti gli oceani di Titano?",
                        "Do que são feitos os oceanos de Titã?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Methane",
                            "Metano",
                            "Metano"
                        ),
                        Util.EngItaPor(
                            "Water",
                            "Acqua",
                            "Água"
                        ),
                        Util.EngItaPor(
                            "Mercury",
                            "Mercurio",
                            "Mercúrio"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What makes Enceladus unique among all the satellites of the Solar System?",
                        "Cosa rende Encelado unico tra tutti i satelliti del Sistema solare?",
                        "O que torna Encélado único entre todos os satélites do Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "The presence of an underground ocean",
                            "La presenza di un oceano sotterraneo",
                            "A presença de um oceano subterrâneo"
                        ),
                        Util.EngItaPor(
                            "Its gaseous surface",
                            "La sua superficie gassosa",
                            "Sua superfície gasosa"
                        ),
                        Util.EngItaPor(
                            "The presence of many craters",
                            "La presenza di moltissimi crateri",
                            "A presença de muitas crateras"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of Saturn's satellite which looks like the “Black Death”?",
                        "Come si chiama il satellite di Saturno che sembra la “Morte Nera”?",
                        "Qual é o nome do satélite de Saturno que se parece com a “Morte Negra”?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Mimas",
                            "Mimas",
                            "Mimas"
                        ),
                        Util.EngItaPor(
                            "Enceladus",
                            "Encelado",
                            "Encélado"
                        ),
                        Util.EngItaPor(
                            "Europe",
                            "Europa",
                            "Europa"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of Saturn's moon, where Huygens landed?",
                        "Come si chiama la luna di Saturno dov'è atterrato Huygens?",
                        "Qual é o nome da lua de Saturno onde Huygens pousou?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Titan",
                            "Titano",
                            "Titã"
                        ),
                        Util.EngItaPor(
                            "Europe",
                            "Europa",
                            "Europa"
                        ),
                        Util.EngItaPor(
                            "Enceladus",
                            "Encelado",
                            "Encélado"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of Neptune's natural satellite?",
                        "Come si chiama il più grande satellite naturale di Nettuno?",
                        "Qual é o nome do satélite natural de Netuno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Triton",
                            "Tritone",
                            "Tritão"
                        ),
                        Util.EngItaPor(
                            "Titania",
                            "Titania",
                            "Titânia"
                        ),
                        Util.EngItaPor(
                            "Dione",
                            "Dione",
                            "Dione"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of Mars's natural satellites?",
                        "Come si chiamano i satelliti naturali di Marte?",
                        "Qual é o nome dos satélites naturais de Marte?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Phobos and Deimos",
                            "Phobos e Deimos",
                            "Phobos e Deimos"
                        ),
                        Util.EngItaPor(
                            "Mimas and Enceladus",
                            "Mimas e Encelado",
                            "Mimas e Encélado"
                        ),
                        Util.EngItaPor(
                            "Ariel and Umbriel",
                            "Ariel e Umbriel",
                            "Ariel e Umbriel"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of the largest of Pluto's five satellites?",
                        "Come si chiama il più grande dei cinque satelliti di Plutone?",
                        "Qual é o nome do maior dos cinco satélites de Plutão?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Charon",
                            "Caronte",
                            "Caronte"
                        ),
                        Util.EngItaPor(
                            "Hydra",
                            "Idra",
                            "Hidra"
                        ),
                        Util.EngItaPor(
                            "Styx",
                            "Stige",
                            "Styx"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of the most volcanically active body in the Solar System?",
                        "Come si chiama il corpo vulcanicamente più attivo del Sistema solare?",
                        "Qual é o nome do corpo mais vulcanicamente ativo do Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Io",
                            "Io",
                            "Io"
                        ),
                        Util.EngItaPor(
                            "Europe",
                            "Europa",
                            "Europa"
                        ),
                        Util.EngItaPor(
                            "Iapetus",
                            "Iapetus",
                            "Japeto"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of the largest moon in the Solar System?",
                        "Come si chiama la luna più grande del Sistema solare?",
                        "Qual é o nome da maior lua do Sistema Solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Ganymedes",
                            "Ganimede",
                            "Ganimedes"
                        ),
                        Util.EngItaPor(
                            "Callistus",
                            "Callisto",
                            "Calisto"
                        ),
                        Util.EngItaPor(
                            "Titan",
                            "Titano",
                            "Titã"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "asteroids", Util.EngItaPor("Asteroids", "Asteroidi", "Asteroides"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is an asteroid?",
                        "Che cos'è un asteroide?",
                        "O que é um asteroide?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "It's a small celestial body made of rocks, metals and ice: its size varies from one metre to hundreds of kilometesi",
                            "Un piccolo corpo celeste formato da roccia, metalli e ghiaccio delle dimensioni da un metro a centinaia di chilometri",
                            "É um pequeno corpo celeste feito de rochas, metais e gelo: seu tamanho varia de um metro a centenas de quilômetros"
                        ),
                        Util.EngItaPor(
                            "A dwarf planet",
                            "Un pianeta nano",
                            "Um planeta anão"
                        ),
                        Util.EngItaPor(
                            "A small rocky object with a diametre less than one metre",
                            "Un piccolo corpo roccioso del diametro inferiore al metro",
                            "Um pequeno objeto rochoso com um diâmetro inferior a um metro"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is a meteoroid?",
                        "Che cosa è un meteoroide?",
                        "O que é um meteoróide?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A small asteroid, with a size less than one metre",
                            "Un piccolo asteroide delle dimensioni inferiori al metro",
                            "Um pequeno asteroide, com tamanho inferior a um metro"
                        ),
                        Util.EngItaPor(
                            "A star",
                            "Una stella",
                            "Uma estrela"
                        ),
                        Util.EngItaPor(
                            "A kind of planet",
                            "Un tipo di pianeta",
                            "Um tipo de planeta"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Where is the asteroid belt?",
                        "Dove si trova la fascia principale degli asteroidi?",
                        "Onde está o cinturão de asteroides?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Between the orbit of Mars and the one of Jupiter",
                            "Tra l'orbita di Marte e quella di Giove",
                            "Entre a órbita de Marte e a de Júpiter"
                        ),
                        Util.EngItaPor(
                            "Around Jupiter",
                            "Attorno a Giove",
                            "Ao redor de Júpiter"
                        ),
                        Util.EngItaPor(
                            "Beyond Neptune",
                            "Oltre Nettuno",
                            "Além de Netuno"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the name given to asteroids composti primarily of ice?",
                        "Come sono chiamati gli asteroidi composti principalmente da ghiaccio?",
                        "Qual é o nome dado aos asteroides compostos principalmente de gelo?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Comets",
                            "Comete",
                            "Cometas"
                        ),
                        Util.EngItaPor(
                            "Meteoriti",
                            "Meteoriti",
                            "Meteoritos"
                        ),
                        Util.EngItaPor(
                            "Icy asteroids",
                            "Asteroidi ghiacciati",
                            "Asteroides gelados"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What are asteroids classified by?",
                        "In base a cosa vengono classificati gli asteroidi?",
                        "Como os asteroides são classificados?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "According to their chemical composition",
                            "Alla composizione chimica",
                            "De acordo com sua composição química"
                        ),
                        Util.EngItaPor(
                            "According to their shape",
                            "Alla forma",
                            "De acordo com sua forma"
                        ),
                        Util.EngItaPor(
                            "According to the type of orbit",
                            "Al tipo di orbita",
                            "De acordo com o tipo de órbita"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is considered the main origin of asteroids?",
                        "Quale si pensa sia l'origine principale degli asteroidi?",
                        "Qual é considerada a principal origem dos asteroides?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "They are corpuscles which were not incorporated in the formation of planets",
                            "Sono corpuscoli che non sono stati inglobati nella formazione dei pianeti",
                            "São corpúsculos que não foram incorporados na formação dos planetas"
                        ),
                        Util.EngItaPor(
                            "They are the result of the impacts between planets",
                            "Sono il risultato degli impatti tra pianeti",
                            "São o resultado dos impactos entre planetas"
                        ),
                        Util.EngItaPor(
                            "They come from other planetary systems",
                            "Derivano da altri sistemi planetari",
                            "Vêm de outros sistemas planetários"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Why do asteroids need to be constantly monitored?",
                        "Perché gli asteroidi devono essere costantemente monitorati?",
                        "Por que os asteroides precisam ser constantemente monitorados?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Because some of them might orbit near the Earth",
                            "Perché alcuni potrebbero orbitare vicino alla Terra",
                            "Porque alguns deles podem orbitar perto da Terra"
                        ),
                        Util.EngItaPor(
                            "Because they could host life",
                            "Perché potrebbero ospitare della vita",
                            "Porque podem abrigar vida"
                        ),
                        Util.EngItaPor(
                            "Because their origin is still unknown",
                            "Perché la loro origine è ancora sconosciuta",
                            "Porque sua origem ainda é desconhecida"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What are shooting stars?",
                        "Cosa sono le stelle cadenti?",
                        "O que são estrelas cadentes?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Meteors",
                            "Meteore",
                            "Meteoros"
                        ),
                        Util.EngItaPor(
                            "Stars",
                            "Stelle",
                            "Estrelas"
                        ),
                        Util.EngItaPor(
                            "Planets",
                            "Pianeti",
                            "Planetas"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How big does an asteroid need to be to provoke mass extinction?",
                        "Quanto deve essere grande un asteroide per provocare un'estinzione di massa?",
                        "Quão grande um asteroide precisa ser para provocar uma extinção em massa?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Over 10 kilometres",
                            "Oltre 10 chilometri",
                            "Mais de 10 quilômetros"
                        ),
                        Util.EngItaPor(
                            "200 metres",
                            "200 metri",
                            "200 metros"
                        ),
                        Util.EngItaPor(
                            "10 metres",
                            "10 metri",
                            "10 metros"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Has any probe ever landed on an asteroid?",
                        "Sono mai atterrate sonde su asteroidi?",
                        "Alguma sonda já pousou em um asteroide?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Yes, on Ryugu and Bennu",
                            "Sì, su Ryugu e Bennu",
                            "Sim, em Ryugu e Bennu"
                        ),
                        Util.EngItaPor(
                            "Yes, on Vesta",
                            "Sì, su Vesta",
                            "Sim, em Vesta"
                        ),
                        Util.EngItaPor(
                            "No",
                            "No",
                            "Não"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "constellations", Util.EngItaPor("Constellations", "Costellazioni", "Constelações"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many constellations are recognized by the International Astronomical Union?",
                        "Quante sono le costellazioni riconosciute dall'Unione Astronomica Internazionale?",
                        "Quantas constelações são reconhecidas pela União Astronômica Internacional?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "88",
                            "88",
                            "88"
                        ),
                        Util.EngItaPor(
                            "12",
                            "12",
                            "12"
                        ),
                        Util.EngItaPor(
                            "70",
                            "70",
                            "70"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What constellation does the North Star belong to?",
                        "Qual è la costellazione a cui appartiene la stella Polare?",
                        "A qual constelação pertence a Estrela do Norte?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Ursa Minor",
                            "Orsa Minore",
                            "Ursa Menor"
                        ),
                        Util.EngItaPor(
                            "Ursa Major",
                            "Orsa Maggiore",
                            "Ursa Maior"
                        ),
                        Util.EngItaPor(
                            "Cassiopea",
                            "Cassiopea",
                            "Cassiopeia"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Which of these is a circumpolar constellation of the Northern hemisphere?",
                        "Quale di queste è una costellazione circumpolare dell'emisero boreale?",
                        "Qual destas é uma constelação circumpolar do hemisfério norte?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Ursa Major",
                            "Orsa Maggiore",
                            "Ursa Maior"
                        ),
                        Util.EngItaPor(
                            "Southern Cross",
                            "Croce del Sud",
                            "Cruzeiro do Sul"
                        ),
                        Util.EngItaPor(
                            "Swan",
                            "Cigno",
                            "Cisne"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Which of these constellations cannot be observed in the northern winter sky?",
                        "Quale di queste costellazioni non si osserva nel cielo invernale boreale?",
                        "Qual destas constelações não pode ser observada no céu do inverno do hemisfério norte?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Swan",
                            "Cigno",
                            "Cisne"
                        ),
                        Util.EngItaPor(
                            "Orion",
                            "Orione",
                            "Orion"
                        ),
                        Util.EngItaPor(
                            "Taurus",
                            "Toro",
                            "Touro"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many zodiacal constellations are there?",
                        "Quante sono le costellazioni zodiacali?",
                        "Quantas constelações do zodíaco existem?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "13",
                            "13",
                            "13"
                        ),
                        Util.EngItaPor(
                            "12",
                            "12",
                            "12"
                        ),
                        Util.EngItaPor(
                            "10",
                            "10",
                            "10"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the brightest star in the sky?",
                        "Qual è la stella più luminosa del cielo?",
                        "Qual é a estrela mais brilhante no céu?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Sirius",
                            "Sirio",
                            "Sirius"
                        ),
                        Util.EngItaPor(
                            "Vega",
                            "Vega",
                            "Vega"
                        ),
                        Util.EngItaPor(
                            "North Star",
                            "Stella Polare",
                            "Estrela do Norte"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "To which constellations do the stars which form the summer triangle belong?",
                        "A quali costellazioni appartengono le stelle che formano il triangolo estivo?",
                        "A quais constelações pertencem as estrelas que formam o triângulo de verão?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Eagle, Lyra, Swan",
                            "Aquila, Lira, Cigno",
                            "Águia, Lira, Cisne"
                        ),
                        Util.EngItaPor(
                            "Swan, Orion, Lyra",
                            "Cigno, Orione, Lira",
                            "Cisne, Orion, Lira"
                        ),
                        Util.EngItaPor(
                            "Ursa Major, Ursa Minor, Cassiopea",
                            "Orsa Maggiore, Orsa Minore, Cassiopea",
                            "Ursa Maior, Ursa Menor, Cassiopeia"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Are the stars of a constellation all at the same distance from us?",
                        "Le stelle di una costellazione sono tutte alla stessa distanza da noi?",
                        "As estrelas de uma constelação estão todas à mesma distância de nós?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "No",
                            "No",
                            "Não"
                        ),
                        Util.EngItaPor(
                            "Yes",
                            "Sì",
                            "Sim"
                        ),
                        Util.EngItaPor(
                            "We cannot know this",
                            "Non possiamo saperlo",
                            "Não podemos saber disso"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is a constellation?",
                        "Cos'è una costellazione?",
                        "O que é uma constelação?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A group of stars linked together by imaginary lines to form a figure",
                            "Un gruppo di stelle collegate fra loro da linee immaginarie in modo da formare una figura",
                            "Um grupo de estrelas conectadas por linhas imaginárias para formar uma figura"
                        ),
                        Util.EngItaPor(
                            "A group of stars which have the same brightness",
                            "Un gruppo di stelle che hanno tutte la stessa luminosità",
                            "Um grupo de estrelas que têm o mesmo brilho"
                        ),
                        Util.EngItaPor(
                            "A group of stars which are at the same distance from us",
                            "Un gruppo di stelle che si trovano alla stessa distanza da noi",
                            "Um grupo de estrelas que estão à mesma distância de nós"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What constellation is also called the great hunter?",
                        "Quale costellazione viene chiamata anche il grande cacciatore?",
                        "Qual constelação também é chamada de grande caçador?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Orion",
                            "Orione",
                            "Orion"
                        ),
                        Util.EngItaPor(
                            "Hercules",
                            "Ercole",
                            "Hércules"
                        ),
                        Util.EngItaPor(
                            "Taurus",
                            "Toro",
                            "Touro"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "milkyway", Util.EngItaPor("Milky Way", "Via Lattea", "Via Láctea"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What does the light-year measure?",
                        "Cosa misura l'anno luce?",
                        "O que mede o ano-luz?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Distance",
                            "Una distanza",
                            "Distância"
                        ),
                        Util.EngItaPor(
                            "Time",
                            "Un tempo",
                            "Tempo"
                        ),
                        Util.EngItaPor(
                            "Speed",
                            "Una velocità",
                            "Velocidade"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How big is the Milky Way?",
                        "Quant'è grande la Via Lattea?",
                        "Quão grande é a Via Láctea?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "100thousand light-years",
                            "100mila anni luce",
                            "100 mil anos-luz"
                        ),
                        Util.EngItaPor(
                            "200thousand light-years",
                            "200mila anni luce",
                            "200 mil anos-luz"
                        ),
                        Util.EngItaPor(
                            "10thousand light-years",
                            "10mila anni luce",
                            "10 mil anos-luz"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many stars are there in the Milky Way?",
                        "Quante stelle ci sono nella Via Lattea?",
                        "Quantas estrelas existem na Via Láctea?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Between 100 and 400 billions",
                            "Tra 100 e 400 miliardi",
                            "Entre 100 e 400 bilhões"
                        ),
                        Util.EngItaPor(
                            "Between 100 and 400 millions",
                            "Tra 100 e 400 milioni",
                            "Entre 100 e 400 milhões aproximadamente"
                        ),
                        Util.EngItaPor(
                            "About 1 billion",
                            "Circa 1 miliardo",
                            "1 bilhão"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "In which constellation can the centre of the Milky Way be observed?",
                        "In quale costellazione si può osservare il centro della Via Lattea?",
                        "Em qual constelação pode-se observar o centro da Via Láctea?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Sagittarius",
                            "Sagittario",
                            "Sagitário"
                        ),
                        Util.EngItaPor(
                            "Orion",
                            "Orione",
                            "Orion"
                        ),
                        Util.EngItaPor(
                            "Ursa Mayor",
                            "Orsa Maggiore",
                            "Ursa Maior"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the age of the Milky Way?",
                        "Qual è l'età della Via Lattea?",
                        "Qual é a idade da Via Láctea?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 13 billions years",
                            "Circa 13 miliardi di anni",
                            "Aproximadamente 13 bilhões de anos"
                        ),
                        Util.EngItaPor(
                            "About 4.5 billions years",
                            "Circa 4.5 miliardi di anni",
                            "Aproximadamente 4,5 bilhões de anos"
                        ),
                        Util.EngItaPor(
                            "About 13 millions years",
                            "Circa 13 milioni di anni",
                            "Aproximadamente 13 milhões de anos"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many arms does the MIlky Way have?",
                        "Quanti bracci ha la Via Lattea?",
                        "Quantos braços a Via Láctea possui?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "5",
                            "5",
                            "5"
                        ),
                        Util.EngItaPor(
                            "2",
                            "2",
                            "2"
                        ),
                        Util.EngItaPor(
                            "7",
                            "7",
                            "7"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What kind of galaxy is the Milky Way ?",
                        "Che tipo di galassia è la Via Lattea?",
                        "Que tipo de galáxia é a Via Láctea?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Barred spiral galaxy",
                            "Spirale barrata",
                            "Galáxia espiral barrada"
                        ),
                        Util.EngItaPor(
                            "Elliptical galaxy",
                            "Ellittica",
                            "Galáxia elíptica"
                        ),
                        Util.EngItaPor(
                            "Irregular galaxy",
                            "Irregolare",
                            "Galáxia irregular"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of the Milky Way arm where the Sun is?",
                        "Come si chiama il braccio della Via Lattea in cui si trova il Sole?",
                        "Qual é o nome do braço da Via Láctea onde o Sol está localizado?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Orion Arm",
                            "Braccio di Orione",
                            "Braço de Orion"
                        ),
                        Util.EngItaPor(
                            "Perseus Arm",
                            "Braccio di Perseo",
                            "Braço de Perseu"
                        ),
                        Util.EngItaPor(
                            "Sagittarius Arm",
                            "Braccio del Sagittario",
                            "Braço de Sagitário"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the galaxy like ours and closest to the MIlky Way?",
                        "Qual è la galassia simile alla nostra più vicina alla Via Lattea?",
                        "Qual é a galáxia semelhante à nossa e mais próxima da Via Láctea?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Andromeda",
                            "Andromeda",
                            "Andrômeda"
                        ),
                        Util.EngItaPor(
                            "Large Magellanic Cloud",
                            "La grande nube di Magellano",
                            "Grande Nuvem de Magalhães"
                        ),
                        Util.EngItaPor(
                            "Triangulum Galaxy",
                            "La galassia Triangolo",
                            "Galáxia Triângulo"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What galaxy does the Milky Way belong to?",
                        "La Via Lattea di quale ammasso di galassie fa parte?",
                        "A que grupo de galáxias pertence a Via Láctea?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Local Group",
                            "Gruppo Locale",
                            "Grupo Local"
                        ),
                        Util.EngItaPor(
                            "Fornax Group",
                            "Gruppo della Fornace",
                            "Grupo Fornax"
                        ),
                        Util.EngItaPor(
                            "Virgo Group",
                            "Gruppo della Vergine",
                            "Grupo de Virgem"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "stellarevolution", Util.EngItaPor("Stellar evolution", "Evoluzione stellare", "Evolução estelar"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What energy source feeds stars like the Sun?",
                        "Quale fonte di energia alimenta le stelle come il Sole?",
                        "Qual fonte de energia alimenta estrelas como o Sol?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Nuclear energy",
                            "Energia nucleare",
                            "Energia nuclear"
                        ),
                        Util.EngItaPor(
                            "Chemical energy",
                            "Energia chimica",
                            "Energia química"
                        ),
                        Util.EngItaPor(
                            "Gravitational energy",
                            "Energia gravitazionale",
                            "Energia gravitacional"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Protostars release mainly",
                        "Le protostelle emettono principalmente",
                        "As protoestrelas liberam principalmente"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Infrared radiation",
                            "Radiazione infrarossa",
                            "Radiação infravermelha"
                        ),
                        Util.EngItaPor(
                            "Ultraviolet radiation",
                            "Radiazione ultravioletta",
                            "Radiação ultravioleta"
                        ),
                        Util.EngItaPor(
                            "X radiation",
                            "Radiazione X",
                            "Raios-X"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of the forst phase of a star's life?",
                        "Come si chiama la prima fase della vita di una stella?",
                        "Qual é o nome da primeira fase da vida de uma estrela?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Protostar",
                            "Protostella",
                            "Protoestrela"
                        ),
                        Util.EngItaPor(
                            "White dwarf",
                            "Nana bianca",
                            "Anã branca"
                        ),
                        Util.EngItaPor(
                            "Supernova",
                            "Supernova",
                            "Supernova"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the heaviest chemical element which a massive star can “burn” with nuclear reactions?",
                        "Qual è l'elemento chimico più pesante che una stella massiccia riesce a “bruciare” con le reazioni nucleari?",
                        "Qual é o elemento químico mais pesado que uma estrela massiva pode “queimar” em reações nucleares?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Iron, because the production of magnesium is an endothermic reaction",
                            "Il ferro, perché la produzione di magnesio è una reazione endotermica",
                            "Ferro, porque a produção de magnésio é uma reação endotérmica"
                        ),
                        Util.EngItaPor(
                            "Oxygen",
                            "L'ossigeno",
                            "Oxygen"
                        ),
                        Util.EngItaPor(
                            "Silicon",
                            "Il silicio",
                            "Silício"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What phenomenon precedes the formation of a neutron star?",
                        "Quale fenomeno precede la formazione di una stella di neutroni?",
                        "Qual fenômeno antecede a formação de uma estrela de nêutrons?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "The explosion of a Supernova",
                            "L'esplosione di una supernova",
                            "A explosão de uma Supernova"
                        ),
                        Util.EngItaPor(
                            "Hydrogen depletion",
                            "L'esaurimento dell'idrogeno",
                            "Depleção de hidrogênio"
                        ),
                        Util.EngItaPor(
                            "The formation of a planetary nebula",
                            "La formazione di una nebulosa planetaria",
                            "A formação de uma nebulosa planetária"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "The colour of a star indicates its:",
                        "Il colore di una stella è indicativo della sua:",
                        "A cor de uma estrela indica sua:"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Temperature",
                            "Temperatura",
                            "Temperatura"
                        ),
                        Util.EngItaPor(
                            "Distance",
                            "Distanza",
                            "Distância"
                        ),
                        Util.EngItaPor(
                            "Size",
                            "Dimensione",
                            "Tamanho"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the  (lower) limit to the mass of a star un order to give rise to a Supernova at the end of its evolutionary cycle?",
                        "Qual è il limite (inferiore) alla massa di una stella affinché dia origine, al termine del suo ciclo evolutivo, a una supernova?",
                        "Qual é o limite (inferior) de massa de uma estrela para dar origem a uma Supernova no final de seu ciclo evolutivo?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "10 solar masses",
                            "10 masse solari",
                            "10 massas solares"
                        ),
                        Util.EngItaPor(
                            "2.4 solar masses",
                            "2.4 masse solari",
                            "2,4 massas solares"
                        ),
                        Util.EngItaPor(
                            "100 solar masses",
                            "100 masse solari",
                            "100 massas solares"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the most present element in a newly-formed star?",
                        "Qual è l'elemento più presente in una stella appena formata?",
                        "Qual é o elemento mais presente em uma estrela recém-formada?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Hydrogen",
                            "Idrogeno",
                            "Hidrogênio"
                        ),
                        Util.EngItaPor(
                            "Helium",
                            "Elio",
                            "Hélio"
                        ),
                        Util.EngItaPor(
                            "Oxygen",
                            "Ossigeno",
                            "Oxygen"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Why does not a star collapse becasue of its own force of gravity?",
                        "Perché una stella non collassa per azione della sua stessa forza di gravità?",
                        "Por que uma estrela não entra em colapso devido à sua própria força gravitacional?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "The pressure of radiation offsets gravity",
                            "La pressione della radiazione controbilancia la gravità",
                            "A pressão da radiação compensa a gravidade"
                        ),
                        Util.EngItaPor(
                            "Thanks to the gravitational force between star and planets",
                            "Grazie alla forza gravitazione tra la stella e i pianeti",
                            "Graças à força gravitacional entre a estrela e os planetas"
                        ),
                        Util.EngItaPor(
                            "The compact nucleus supports the outside",
                            "Il nucleo compatto sostiene la parte esterna",
                            "O núcleo compacto suporta o exterior"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What size determines the evolution of a star?",
                        "Quale grandezza determina l'evoluzione di una stella?",
                        "Que tamanho determina a evolução de uma estrela?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Mass",
                            "La massa",
                            "Massa"
                        ),
                        Util.EngItaPor(
                            "Temperature",
                            "La temperatura",
                            "Temperatura"
                        ),
                        Util.EngItaPor(
                            "Size",
                            "La dimensione",
                            "Tamanho"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "nebulas", Util.EngItaPor("Nebulas", "Nebulose", "Nebulosas"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is a nebula?",
                        "Cos'è una nebulosa?",
                        "O que é uma nebulosa?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "An interstellar cloud, made up of gas, dust and plasma",
                            "Una nube interstellare costituita da gas, polveri e plasma",
                            "Uma nuvem interestelar, composta por gás, poeira e plasma"
                        ),
                        Util.EngItaPor(
                            "A cloud of gas which is in space",
                            "Una nuvola di gas che si trova nello spazio",
                            "Uma nuvem de gás no espaço"
                        ),
                        Util.EngItaPor(
                            "A type of galaxy",
                            "Una tipologia di galassia",
                            "Um tipo de galáxia"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's a Supernova remnant?",
                        "Cos'è un resto di supernova?",
                        "O que é um remanescente de Supernova?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A nebula that forms after the explosion of a Supernova",
                            "Una nebulosa che si forma in seguito all'esplosione di una supernova",
                            "Uma nebulosa que se forma após a explosão de uma Supernova"
                        ),
                        Util.EngItaPor(
                            "Rocky debris which is releaed after the explosion of a Supernova",
                            "I detriti rocciosi che vengono rilasciati in seguito all'esplosione di una supernova",
                            "Destroços rochosos liberados após a explosão de uma Supernova"
                        ),
                        Util.EngItaPor(
                            "A type of star",
                            "Un tipo di stella",
                            "Um tipo de estrela"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's a planetary nebula?",
                        "Cos'è una nebulosa planetaria?",
                        "O que é uma nebulosa planetária?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A nebula formed by the gas ejected from stars becoming white dwarfs",
                            "Una nebulosa che si forma dal gas espulso dalle stelle che diventano nane bianche",
                            "Uma nebulosa formada pelo gás ejectado de estrelas que se tornam anãs brancas"
                        ),
                        Util.EngItaPor(
                            "A nebula surrounding a planet",
                            "Una nebulosa che circonda un pianeta",
                            "Uma nebulosa que envolve um planeta"
                        ),
                        Util.EngItaPor(
                            "A nebula where planets are formed",
                            "Una nebulosa da cui si formano i pianeti",
                            "Uma nebulosa onde planetas são formados"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Which of these is not the name of a nebula?",
                        "Quale di queste non è il nome di una nebulosa?",
                        "Qual destes não é o nome de uma nebulosa?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Cassiopeia",
                            "Nebulosa di Cassiopea",
                            "Cassiopeia"
                        ),
                        Util.EngItaPor(
                            "Orion",
                            "Nebulosa di Orione",
                            "Orion"
                        ),
                        Util.EngItaPor(
                            "Crab",
                            "Nebulosa del Granchio",
                            "Carangueijo"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the Crab Nebula?",
                        "Che cosa è la Nebulosa del Granchio?",
                        "O que é a Nebulosa do Caranguejo?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A Supernova remnant",
                            "Un resto di supernova",
                            "Um remanescente de Supernova"
                        ),
                        Util.EngItaPor(
                            "A galaxy",
                            "Una galassia",
                            "Uma galáxia"
                        ),
                        Util.EngItaPor(
                            "A black hole",
                            "Un buco nero",
                            "Um buraco negro"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Where do stars form?",
                        "Dove si formano le stelle?",
                        "Onde as estrelas se formam?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Inside hydrogen-rich insterstellar clouds",
                            "All'interno di nubi insterstellari ricche di idrogeno",
                            "Dentro de nuvens interestelares ricas em hidrogênio"
                        ),
                        Util.EngItaPor(
                            "In the empty regions between galaxies",
                            "Nelle regioni vuote tra le galassie",
                            "Nas regiões vazias entre galáxias"
                        ),
                        Util.EngItaPor(
                            "In the accretion disks of black holes",
                            "Nei dischi di accrescimento dei buchi neri",
                            "Nos discos de acreção de buracos negros"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "The life of a star begins from:",
                        "La vita di una stella comincia da:",
                        "A vida de uma estrela começa a partir de:"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A nebula of gas and dust",
                            "Una nebulosa di gas e polveri",
                            "Uma nebulosa de gás e poeira"
                        ),
                        Util.EngItaPor(
                            "A compact cluster of gas and dust",
                            "Un ammasso compatto di gas e polveri",
                            "Um aglomerado compacto de gás e poeira"
                        ),
                        Util.EngItaPor(
                            "An energy nebul",
                            "Una nebulosa di energia",
                            "Uma nebulosa de energia"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Why do we see nebulae?",
                        "Perché vediamo le nebulose?",
                        "Por que vemos nebulosas?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Because they reflect the light emitted by a star inside them (reflection nebulae) or the ionized gas they are made of emits light (emission nebulae)",
                            "Perché riflettono la luce emessa da una stella al loro interno (nebulose a riflessione) oppure il gas ionizzato di cui sono fatte emette luce (nebulose a emissione)",
                            "Porque elas refletem a luz emitida por uma estrela em seu interior (nebulosas de reflexão) ou o gás ionizado que as compõe emite luz (nebulosas de emissão)"
                        ),
                        Util.EngItaPor(
                            "Because new stars are forming inside",
                            "Perché all'interno si stanno formando nuove stelle",
                            "Porque novas estrelas estão se formando dentro delas"
                        ),
                        Util.EngItaPor(
                            "Because at their centre there is always a pulsar emitting light",
                            "Perché al centro c'è sempre una pulsar che emette luce",
                            "Porque em seu centro sempre há um pulsar emitindo luz"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What emits light in a planetary nebula?",
                        "In una nebulosa planetaria, che cosa emette luce?",
                        "O que emite luz em uma nebulosa planetária?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A glowing shell of ionized expanding gas, ejected by some stars in the final stage of their life",
                            "Un involucro incandescente di gas ionizzato in espansione, espulso da alcune stelle nella fase finale della loro vita",
                            "Uma concha luminosa de gás ionizado em expansão, ejectada por algumas estrelas em sua fase final de vida"
                        ),
                        Util.EngItaPor(
                            "A black hole at the centre of the nebula",
                            "Un buco nero al centro della nebulosa",
                            "Um buraco negro no centro da nebulosa"
                        ),
                        Util.EngItaPor(
                            "Stars forming inside the nebula",
                            "Le stelle che si stanno formando all'interno della nebulosa",
                            "Estrelas se formando dentro da nebulosa"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How long does a planetary nebula remain visible?",
                        "Quanto tempo rimane visibile una nebulosa planetaria?",
                        "Quanto tempo uma nebulosa planetária permanece visível?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A few thousand years",
                            "Poche decine di migliaia di anni",
                            "Alguns milhares de anos"
                        ),
                        Util.EngItaPor(
                            "Billions of years, like the life of a star",
                            "Come la vita di una stella, miliardi di anni",
                            "Bilhões de anos, como a vida de uma estrela"
                        ),
                        Util.EngItaPor(
                            "A few hundred years",
                            "Poche centinaia di anni",
                            "Algumas centenas de anos"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "compactobjects", Util.EngItaPor("Compact Objects", "Oggetti compatti", "Objetos compactos"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is a black hole?",
                        "Cos'è un buco nero?",
                        "O que é um buraco negro?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A region of spacetime with a gravitational field so intense, that neither matter, nor light can escape",
                            "Una regione dello spaziotempo con un campo gravitazionale così intenso da non lasciare sfuggire né la materia, né la luce",
                            "Uma região do espaço-tempo com um campo gravitacional tão intenso que nem matéria nem luz podem escapar"
                        ),
                        Util.EngItaPor(
                            "A hole in spacetime",
                            "Un buco nello spaziotempo",
                            "Um buraco no espaço-tempo uma região"
                        ),
                        Util.EngItaPor(
                            "A region where new planetary systems are born",
                            "Una regione dove nascono nuovi sistemi planetari",
                            "Onde novos sistemas planetários nascem"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How can a black hole form?",
                        "Come si può formare un buco nero?",
                        "Como um buraco negro pode se formar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "As the last evolutionary stage of a massive star (over 20 solar masses)",
                            "Come ultimo stadio evolutivo di una stella massiccia (più di 20 masse solari)",
                            "Como a última fase evolutiva de uma estrela massiva (mais de 20 massas solares)"
                        ),
                        Util.EngItaPor(
                            "From a gravitational vortex triggered by a pulsar",
                            "Da un vortice gravitazionale innescato da una pulsar",
                            "De um vórtice gravitacional desencadeado por um pulsar"
                        ),
                        Util.EngItaPor(
                            "From the explosion of a nebula",
                            "Dall'esplosione di una nebulosa",
                            "Da explosão de uma nebulosa"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Who predicted the existence of black holes?",
                        "Chi predisse l'esistenza dei buchi neri?",
                        "Quem previu a existência de buracos negros?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Albert Einstein",
                            "Albert Einstein",
                            "Albert Einstein"
                        ),
                        Util.EngItaPor(
                            "Stephen Hawking",
                            "Stephen Hawking",
                            "Stephen Hawking"
                        ),
                        Util.EngItaPor(
                            "Margherita Hack",
                            "Margherita Hack",
                            "Margherita Hack"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of the supermassive black hole at the centre of the Milky Way?",
                        "Come si chiama il buco nero supermassiccio presente al centro della Via Lattea?",
                        "Qual é o nome do buraco negro supermassivo no centro da Via Láctea?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Sagittarius A*",
                            "Sagittarius A*",
                            "Sagittarius A*"
                        ),
                        Util.EngItaPor(
                            "Gargantua",
                            "Gargantua",
                            "Gargantua"
                        ),
                        Util.EngItaPor(
                            "M87",
                            "M87",
                            "M87"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's a supermassive black hole?",
                        "Cos'è un buco nero supermassiccio?",
                        "O que é um buraco negro supermassivo?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "It's a black hole with a mass of millions or bilions times that of the Sun, at the centre of galaxies",
                            "Un buco nero con una massa di milioni o miliardi di volte quella del Sole, nel centro delle galassie",
                            "É um buraco negro com uma massa de milhões ou bilhões de vezes a do Sol, localizado no centro das galáxias"
                        ),
                        Util.EngItaPor(
                            "A set of black holes which orbit around each other",
                            "Un insieme di buchi neri che orbitano gli uni intorno agli altri",
                            "Um conjunto de buracos negros que orbitam entre si"
                        ),
                        Util.EngItaPor(
                            "A black hole originating from a una stella supermassive star",
                            "Un buco nero che si origina da una stella supermassiccia",
                            "Um buraco negro originado de uma estrela supermassiva única"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the horizon of events?",
                        "Cos'è l'orizzonte degli eventi?",
                        "O que é o horizonte de eventos?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "An imaginary surface surrounding the black hole, beyond which nothing can escape",
                            "Una superficie immaginaria che circonda il buco nero oltre la quale niente riesce più a uscire",
                            "Uma superfície imaginária ao redor do buraco negro, além da qual nada pode escapar"
                        ),
                        Util.EngItaPor(
                            "The radium of the black hole",
                            "Il raggio del buco nero",
                            "O raio do buraco negro"
                        ),
                        Util.EngItaPor(
                            "An imaginary surface surrounding the black hole, from which we can see the past",
                            "Una superficie immaginaria che circonda il buco nero dalla quale è possibile vedere il passato",
                            "Uma superfície imaginária ao redor do buraco negro, da qual podemos ver o passado"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Da quale corpo celeste la luce non riesce a uscire?",
                        "Da quale corpo celeste la luce non riesce a uscire?",
                        "De qual corpo celeste a luz não consegue escapar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Buco nero",
                            "Buco nero",
                            "Buraco negro"
                        ),
                        Util.EngItaPor(
                            "Pulsar",
                            "Pulsar",
                            "Pulsar"
                        ),
                        Util.EngItaPor(
                            "Quasar",
                            "Quasar",
                            "Quasar"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Black holes, Supernovae, neutron stars are the possible result of the death of what kind of star?",
                        "Buco nero, supernova, stella di neutroni sono il possibile risultato della morte di una stella di che tipo?",
                        "Buracos negros, Supernovas, estrelas de nêutrons são resultados possíveis da morte de que tipo de estrela?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A high-mass star",
                            "Di grande massa",
                            "Uma estrela de alta massa"
                        ),
                        Util.EngItaPor(
                            "An average-sized star",
                            "Di media grandezza",
                            "Uma estrela de tamanho médio"
                        ),
                        Util.EngItaPor(
                            "A small star",
                            "Piccola",
                            "Uma estrela pequena"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the last evolutionary stage of a high-mass star (> 20 solar masses)",
                        "Qual è l'ultimo stadio evolutivo di una stella di grande massa (> 20 masse solari)",
                        "Qual é a última fase evolutiva de uma estrela de alta massa (> 20 massas solares)?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Un buco nero",
                            "Un buco nero",
                            "Buraco negro"
                        ),
                        Util.EngItaPor(
                            "A white dwarf",
                            "Una nana bianca",
                            "Uma anã branca"
                        ),
                        Util.EngItaPor(
                            "A red super-giant",
                            "Una super gigante rossa",
                            "Uma supergigante vermelha"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "When was the first image of a black hole obtained?",
                        "Quando è stata ottenuta la prima immagine di un buco nero?",
                        "Quando foi obtida a primeira imagem de um buraco negro?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "In 2019",
                            "Nel 2019",
                            "Em 2019"
                        ),
                        Util.EngItaPor(
                            "In 1919",
                            "Nel 1919",
                            "Em 1919"
                        ),
                        Util.EngItaPor(
                            "In 1989",
                            "Nel 1989",
                            "Em 1989"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "bigbang", Util.EngItaPor("The Big Bang", "Il Big Bang", "O Big Bang"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How do we call the first light emitted by the Universe?",
                        "Come viene chiamata la prima luce emessa dall'universo?",
                        "Como chamamos a primeira luz emitida pelo Universo?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Cosmic microwave background radiation",
                            "Radiazione cosmica di fondo a microonde",
                            "Radiação cósmica de fundo em micro-ondas"
                        ),
                        Util.EngItaPor(
                            "Ultraviolet radiation",
                            "Radiazione ultravioletta",
                            "Radiação ultravioleta"
                        ),
                        Util.EngItaPor(
                            "Gamma radiation",
                            "Radiazione gamma",
                            "Radiação gama"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "When was the first light of the Universe emitted?",
                        "Quando è stata emessa la prima luce dell'universo?",
                        "Quando foi emitida a primeira luz do Universo?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "380 thousand years after the Big Bang",
                            "380mila anni dopo il Big Bang",
                            "380 mil anos após o Big Bang"
                        ),
                        Util.EngItaPor(
                            "3 minutes after the Big Bang",
                            "3 minuti dopo il Big Bang",
                            "3 minutos após o Big Bang"
                        ),
                        Util.EngItaPor(
                            "",
                            "",
                            "Um milhão de anos após o Big Bang"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the age of the Universe?",
                        "Qual è l'età dell'universo?",
                        "Qual é a idade do Universo?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "13.7 billions years",
                            "13.7 miliardi di anni",
                            "13,7 bilhões de anos"
                        ),
                        Util.EngItaPor(
                            "1.37 billions years",
                            "1.37 miliardi di anni",
                            "1,37 bilhões de anos"
                        ),
                        Util.EngItaPor(
                            "13.7 millions years",
                            "13.7 milioni di anni",
                            "13,7 milhões de anos"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's dark energy?",
                        "Che cosa è l'energia oscura?",
                        "O que é energia escura?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "It's a type of energy which is assumed to be responsible for the acceleration of the Universe, and seems to be the dominant form of energy in the Universe",
                            "Un tipo di energia che si presume sia responsabile dell'accelerazione dell'universo, e che sembra costituire la forma dominante di energia nell'universo",
                            "É um tipo de energia que se presume ser responsável pela aceleração do Universo e parece ser a forma dominante de energia no Universo"
                        ),
                        Util.EngItaPor(
                            "The energy generated by antimatter",
                            "L'energia generata dall'antimateria",
                            "A energia gerada pela antimatéria"
                        ),
                        Util.EngItaPor(
                            "The energy emitted by black holes",
                            "L'energia emessa dai buchi bianchi",
                            "A energia emitida por buracos negros"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "On what fundamental observations is the Big Bang theory based?",
                        "Su quali osservazioni fondamentali si basa la teoria del Big Bang?",
                        "Em quais observações fundamentais se baseia a teoria do Big Bang?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "The expansion of the Universe, the cosmic microwave background radiation and the abundance of light elements",
                            "L'espansione dell'universo, la radiazione cosmica di fondo a microonde e l'abbondanza di elementi leggeri",
                            "A expansão do Universo, a radiação cósmica de fundo em micro-ondas e a abundância de elementos leves"
                        ),
                        Util.EngItaPor(
                            "The Universe is contracting",
                            "L'universo si sta contraendo",
                            "O Universo está se contraindo"
                        ),
                        Util.EngItaPor(
                            "The Universe is flat",
                            "L'universo è piatto",
                            "O Universo é plano"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "The fact that the Universe is expanding means that:",
                        "Il fatto che l'universo si sta espandendo significa che",
                        "O fato de o Universo estar se expandindo significa que:"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Each galaxy moves away from the others",
                            "Ogni galassia si allontana dalle altre",
                            "Cada galáxia se afasta das outras"
                        ),
                        Util.EngItaPor(
                            "Galaxise are moving away from a common centre",
                            "Le galassie si stanno allontanando da un centro comune",
                            "As galáxias estão se afastando de um centro comum"
                        ),
                        Util.EngItaPor(
                            "Galaxies increase in size",
                            "Le galassie aumentano di dimensione",
                            "As galáxias aumentam de tamanho"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Age and distance of galaxies:",
                        "L'età e la distanza delle galassie:",
                        "Idade e distância das galáxias:"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "They are directly proportional",
                            "Sono direttamente proporzionali",
                            "São diretamente proporcionais"
                        ),
                        Util.EngItaPor(
                            "They are inversely proportional",
                            "Sono inversamente proporzionali",
                            "São inversamente proporcionais"
                        ),
                        Util.EngItaPor(
                            "There is a quadratic dependence between the one and the other",
                            "Esiste una dipendenza quadratica tra l'una e l'altra",
                            "Há uma dependência quadrática entre uma e outra"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "If the light emitted by galaxies  moved towards blue, what would that mean?",
                        "Se la luce emessa dalle galassie si spostasse verso il blu, cosa significherebbe?",
                        "Se a luz emitida pelas galáxias se deslocasse para o azul, o que isso significaria?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "The galaxies are approaching",
                            "Le galassie si avvicinano",
                            "As galáxias estão se aproximando"
                        ),
                        Util.EngItaPor(
                            "Galaxies are moving away, more slowly",
                            "Le galassie si allontanano, ma più lentamente",
                            "As galáxias estão se afastando, mais lentamente"
                        ),
                        Util.EngItaPor(
                            "The Universe is expanding",
                            "L'universo si espande",
                            "O Universo está se expandindo"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Which constant correlates the removal speed of galaxies and their distance?",
                        "Quale costante mette in relazione la velocità di allontanamento delle galassie e la loro distanza?",
                        "Qual constante correlaciona a velocidade de afastamento das galáxias e sua distância?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "The Hubble constant",
                            "Costante di Hubble",
                            "A constante de Hubble"
                        ),
                        Util.EngItaPor(
                            "The Planck constant",
                            "Costante di Planck",
                            "A constante de Planck"
                        ),
                        Util.EngItaPor(
                            "C, the speed of light",
                            "C, la velocità della luce",
                            "C, a velocidade da luz"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the temperature of the cosmic microwave background radiation?",
                        "Qual'è la temperatura della radiazione cosmica di fondo a microonde?",
                        "Qual é a temperatura da radiação cósmica de fundo em micro-ondas?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About -270 degrees Celsius",
                            "Circa -270 gradi Celsius",
                            "Cerca de -270 graus Celsius"
                        ),
                        Util.EngItaPor(
                            "About 0 degrees Celsius",
                            "Circa 0 gradi Celsius",
                            "Cerca de 0 grau Celsius"
                        ),
                        Util.EngItaPor(
                            "About 273 degrees Celsius",
                            "Circa 273 gradi Celsius",
                            "Cerca de 273 graus Celsius"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "exploration", Util.EngItaPor("Space exploration", "Esplorazione spaziale", "Exploração espacial"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many human being walked on the Moon to this day?",
                        "Quanti esseri umani hanno camminato sulla Luna fino ad oggi?",
                        "Quantas pessoas já caminharam na Lua até hoje?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "12",
                            "12",
                            "12"
                        ),
                        Util.EngItaPor(
                            "21",
                            "21",
                            "21"
                        ),
                        Util.EngItaPor(
                            "13",
                            "13",
                            "13"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Which spacecraft has probed Neptune?",
                        "Quale sonda spaziale ha studiato Nettuno?",
                        "Qual sonda espacial explorou Netuno?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Voyager 2",
                            "Voyager 2",
                            "Voyager 2"
                        ),
                        Util.EngItaPor(
                            "Hubble Space Telescope",
                            "Telescopio Spaziale Hubble",
                            "Telescópio espacial Hubble"
                        ),
                        Util.EngItaPor(
                            "Messenger",
                            "Messenger",
                            "Messenger"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of the Nasa probe which collected so many imaged of Mercury?",
                        "Come si chiama la sonda della Nasa che ha raccolto moltissime immagini di Mercurio?",
                        "Qual é o nome da sonda da NASA que coletou muitas imagens de Mercúrio?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Messenger",
                            "Messenger",
                            "Messenger"
                        ),
                        Util.EngItaPor(
                            "Voyager",
                            "Voyager",
                            "Voyager"
                        ),
                        Util.EngItaPor(
                            "Cassini",
                            "Cassini",
                            "Cassini"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Come si chiama la sonda che nel 2015 ha fotografato la superficie di Plutone?",
                        "Come si chiama la sonda che nel 2015 ha fotografato la superficie di Plutone?",
                        "Como se chama a sonda que en 2015 fotografou a superfície de Plutão?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "New Horizons",
                            "New Horizons",
                            "New Horizons"
                        ),
                        Util.EngItaPor(
                            "Hayabuza",
                            "Hayabuza",
                            "Hayabusa"
                        ),
                        Util.EngItaPor(
                            "Cassini-Huygens",
                            "Cassini-Huygens",
                            "Cassini-Huygens"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Which rocket brought the Apollo 11 mission into space?",
                        "Quale razzo portò la missione Apollo 11 nello spazio?",
                        "Qual foguete lançou a missão Apollo 11 ao espaço?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Saturn V",
                            "Saturn V",
                            "Saturn V"
                        ),
                        Util.EngItaPor(
                            "Ariane 5",
                            "Ariane 5",
                            "Ariane 5"
                        ),
                        Util.EngItaPor(
                            "Atlas",
                            "Atlas",
                            "Atlas"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the name of the first Russian satellite launched into orbit in 1957?",
                        "Qual è il nome del primo satellite russo lanciato in orbita nel 1957?",
                        "Qual é o nome do primeiro satélite russo lançado em órbita em 1957?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Sputnik 1",
                            "Sputnik 1",
                            "Sputnik 1"
                        ),
                        Util.EngItaPor(
                            "Moon 12",
                            "Luna 12",
                            "Lua 12"
                        ),
                        Util.EngItaPor(
                            "Voyager 1",
                            "Voyager 1",
                            "Voyager 1"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "In what year did humanity take its first step on the Moon?",
                        "In che anno l'umanità ha fatto il primo passo sulla Luna?",
                        "Em que ano a humanidade deu seu primeiro passo na Lua?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "1969",
                            "1969",
                            "1969"
                        ),
                        Util.EngItaPor(
                            "1972",
                            "1972",
                            "1972"
                        ),
                        Util.EngItaPor(
                            "1952",
                            "1952",
                            "1952"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What mission brought man on the Moon?",
                        "Quale missione ha portato l'umanità sulla Luna?",
                        "Qual missão levou o homem à Lua?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Apollo 11",
                            "Apollo 11",
                            "Apollo 11"
                        ),
                        Util.EngItaPor(
                            "Apollo 13",
                            "Apollo 13",
                            "Apollo 13"
                        ),
                        Util.EngItaPor(
                            "Apollo 10",
                            "Apollo 10",
                            "Apollo 10"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Which country launched the first automatic probe that landed on the Moon?",
                        "Da quale paese fu lanciata la prima sonda automatica a posarsi sulla Luna?",
                        "Qual país lançou a primeira sonda automática que pousou na Lua?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Soviet Union",
                            "Unione Sovietica",
                            "União Soviética"
                        ),
                        Util.EngItaPor(
                            "USA",
                            "USA",
                            "EUA"
                        ),
                        Util.EngItaPor(
                            "China",
                            "Cina",
                            "China"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of the farthest probe sent by man?",
                        "Come si chiama la sonda più lontana inviata dall'uomo?",
                        "Qual é o nome da sonda enviada mais longe pelo homem?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Voyager 1",
                            "Voyager 1",
                            "Voyager 1"
                        ),
                        Util.EngItaPor(
                            "New Horizons",
                            "New Horizons",
                            "New Horizons"
                        ),
                        Util.EngItaPor(
                            "Voyager 2",
                            "Voyager 2",
                            "Voyager 2"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "exoplanets", Util.EngItaPor("Exoplanets", "Esopianeti", "Exoplanetas"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What are exoplanets?",
                        "Che cosa sono gli esopianeti?",
                        "O que são exoplanetas?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Planets orbiting around stars other than the Sun",
                            "Pianeti che orbitano intorno a stelle diverse dal Sole",
                            "Planetas orbitando estrelas que não são o Sol"
                        ),
                        Util.EngItaPor(
                            "Rogue planets, inside the Solar System",
                            "Pianeti vagabondi, all'interno del Sistema solare",
                            "Planetas vagantes dentro do Sistema Solar"
                        ),
                        Util.EngItaPor(
                            "Planets warmer than the Earth",
                            "Pianeti più caldi della Terra",
                            "Planetas mais quentes que a Terra"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What are the main methods of finding exoplanets?",
                        "Quali sono i metodi principali con i quali si cercano gli esopianeti?",
                        "Quais são os principais métodos de encontrar exoplanetas?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "The transit method and the method of radial velocity",
                            "Il metodo del transito e il metodo della velocità radiale",
                            "O método de trânsito e o método de velocidade radial"
                        ),
                        Util.EngItaPor(
                            "The method of direct observation",
                            "Il metodo di osservazione diretta",
                            "O método de observação direta"
                        ),
                        Util.EngItaPor(
                            "Our technologies do not allow us to detect exoplanets",
                            "Le nostre tecnologie non sono sufficienti per trovare esopianeti",
                            "Nossas tecnologias não nos permitem detectar exoplanetas"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's a synonim of exoplanets?",
                        "Qual è un sinonimo di esopianeti?",
                        "Qual é um sinônimo de exoplanetas?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Extra-solar planets",
                            "Pianeti extra-solari",
                            "Planetas extra-solares"
                        ),
                        Util.EngItaPor(
                            "Extra-galactic planets",
                            "Pianeti extra-galattici",
                            "Planetas extra-galácticos"
                        ),
                        Util.EngItaPor(
                            "Planetoids",
                            "Planetoidi",
                            "Planetoides"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the transit method for searching exoplanets?",
                        "In cosa consiste il metodo del transito per la ricerca di esopianeti?",
                        "O que é o método de trânsito para buscar exoplanetas?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "When a planet passes in front of a star, it leads to a decrease in the brightness of a star",
                            "Quando un pianeta passa davanti alla stella, determina una diminuzione della luminosità della stella",
                            "Quando um planeta passa na frente de uma estrela, ocorre uma diminuição na luminosidade da estrela"
                        ),
                        Util.EngItaPor(
                            "When the planet passes in front of the star, we can take a photo",
                            "Quando il pianeta passa davanti alla stella, è possibile scattargli una foto",
                            "Quando o planeta passa na frente da estrela, podemos tirar uma foto"
                        ),
                        Util.EngItaPor(
                            "When a planet passes in front of a star, it leads to an increase in the brightness of the star",
                            "Quando un pianeta passa davanti alla stella, determina un aumento della luminosità della stella",
                            "Quando um planeta passa na frente de uma estrela, ocorre um aumento na luminosidade da estrela"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many exoplanets have been found sofar?",
                        "Quanti sono gli esopianeti trovati a oggi?",
                        "Quantos exoplanetas foram encontrados até agora?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "About 5000",
                            "Circa 5000",
                            "Cerca de 5000"
                        ),
                        Util.EngItaPor(
                            "About 500",
                            "Circa 500",
                            "Cerca de 500"
                        ),
                        Util.EngItaPor(
                            "About a billion",
                            "Circa un miliardo",
                            "Cerca de 1 bilhão"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is meant by habitable area?",
                        "Che cosa si intende per fascia abitabile?",
                        "O que é considerado como área habitável?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "The region around a star, where it is theoretically possible for a planet to have liquid water on its surface",
                            "La regione intorno a una stella dove è teoricamente possibile per un pianeta avere acqua liquida sulla sua superficie",
                            "A região ao redor de uma estrela, onde teoricamente é possível que um planeta tenha água líquida em sua superfície"
                        ),
                        Util.EngItaPor(
                            "The region around a star, where it is theoretically possible for a planet to host intelligent life",
                            "La regione intorno a una stella dove è teoricamente possibile per un pianeta essere abitato da forme di vita intelligenti",
                            "A região ao redor de uma estrela, onde teoricamente é possível que um planeta abrigue vida inteligente"
                        ),
                        Util.EngItaPor(
                            "The region around a star, where it is theoretically possible for a planet to have a breathable atmosphere",
                            "La regione intorno a una stella dove è teoricamente possibile per un pianeta avere un'atmosfera respirabile",
                            "A região ao redor de uma estrela, onde teoricamente é possível que um planeta tenha uma atmosfera respirável"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Do all exoplanets have the same size as the Earth?",
                        "Gli esopianeti hanno tutti la stessa dimensione della Terra?",
                        "Todos os exoplanetas têm o mesmo tamanho que a Terra?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "No",
                            "No",
                            "Não"
                        ),
                        Util.EngItaPor(
                            "Yes, always",
                            "Sì, sempre",
                            "Sim, sempre"
                        ),
                        Util.EngItaPor(
                            "We cannot know this",
                            "Non lo possiamo sapere",
                            "Não podemos saber isso"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Is there life in exoplanets?",
                        "Negli esopianeti c'è vita?",
                        "Há vida em exoplanetas?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Maybe",
                            "Può essere",
                            "Talvez"
                        ),
                        Util.EngItaPor(
                            "Yes, always",
                            "Sì, sempre",
                            "Sim, sempre"
                        ),
                        Util.EngItaPor(
                            "No, never",
                            "No, mai",
                            "Não, nunca"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of the extra-solar planets which are about 1.5 times the Earth's diametre?",
                        "Come si chiamano i pianeti extra-solari che sono circa 1.5 volte il diametro della Terra?",
                        "Qual é o nome dos exoplanetas que têm cerca de 1,5 vezes o diâmetro da Terra?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Super-Earths",
                            "Super-terre",
                            "Super-Terras"
                        ),
                        Util.EngItaPor(
                            "Mega-rocks",
                            "Mega-rocce",
                            "Mega-rochas"
                        ),
                        Util.EngItaPor(
                            "Iron-rich cores",
                            "Nuclei ferrosi",
                            "Núcleos ricos em ferro"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Are there planets which are considered more habitable than the Earth?",
                        "Esistono pianeti considerati più abitabili della Terra?",
                        "Existem planetas considerados mais habitáveis do que a Terra?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Yes, sofar 24 have been found",
                            "Sì, a oggi ne sono stati trovati 24",
                            "Sim, até agora foram encontrados 24"
                        ),
                        Util.EngItaPor(
                            "No",
                            "No",
                            "Não"
                        ),
                        Util.EngItaPor(
                            "Yes, only one was found",
                            "Sì, ne è stato trovato solo uno",
                            "Sim, apenas um foi encontrado"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "galaxies", Util.EngItaPor("Galaxies", "Galassie", "Galáxias"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the force which holds galaxies together?",
                        "Qual è la forza che tiene insieme le galassie?",
                        "Qual é a força que mantém as galáxias unidas?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Gravity",
                            "La gravità",
                            "Gravidade"
                        ),
                        Util.EngItaPor(
                            "Centripetal force",
                            "La forza centripeta",
                            "Força centrípeta"
                        ),
                        Util.EngItaPor(
                            "Centrifugal force",
                            "La forza centrifuga",
                            "Força centrífuga"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the name of matter between galaxies ?",
                        "Come si chiama la materia tra le galassie ?",
                        "Qual é o nome da matéria entre galáxias?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Intergalactic matter",
                            "Materia intergalattica",
                            "Matéria intergaláctica"
                        ),
                        Util.EngItaPor(
                            "Interstellar matter",
                            "Materia interstellare",
                            "Matéria interestelar"
                        ),
                        Util.EngItaPor(
                            "Dark matter",
                            "Materia oscura",
                            "Matéria escura"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What's the shape of our Galaxy?",
                        "Che forma ha la nostra Galassia",
                        "Qual é a forma da nossa Galáxia?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "(barred) spiral",
                            "Spirale (barrata)",
                            "Espiral (barrada)"
                        ),
                        Util.EngItaPor(
                            "Irregular",
                            "Irregolare",
                            "Irregular"
                        ),
                        Util.EngItaPor(
                            "Elliptical",
                            "Ellittica",
                            "Elíptica"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Da cosa sono formate le galassie?",
                        "Da cosa sono formate le galassie?",
                        "De que são formadas as galáxias?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Gas, polveri e miliardi di stelle",
                            "Gas, polveri e miliardi di stelle",
                            "Gás, poeira e bilhões de estrelas"
                        ),
                        Util.EngItaPor(
                            "Ghiaccio e rocce",
                            "Ghiaccio e rocce",
                            "Gelo e rochas"
                        ),
                        Util.EngItaPor(
                            "Polveri",
                            "Polveri",
                            "Poeira"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is at the centre of most galaxies?",
                        "Cosa c'è al centro della maggior parte delle galassie?",
                        "O que está no centro da maioria das galáxias?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A supermassive black hole",
                            "Un buco nero supermassiccio",
                            "Um buraco negro supermassivo"
                        ),
                        Util.EngItaPor(
                            "A stellar black hole",
                            "Un buco nero stellare",
                            "Um buraco negro estelar"
                        ),
                        Util.EngItaPor(
                            "A white hole",
                            "Un buco bianco",
                            "Um buraco branco"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Can galaxies collide?",
                        "Le galassie si possono scontrare",
                        "Galáxias podem colidir?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Yes",
                            "Sì",
                            "Sim"
                        ),
                        Util.EngItaPor(
                            "No, they are too far away from each other",
                            "No, sono troppo distanti",
                            "Ão, estão muito distantes uma da outra"
                        ),
                        Util.EngItaPor(
                            "No, they are moving away",
                            "No, si stanno allontando",
                            "Não, estão se afastando"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Starting from the smallest, put in order of size:",
                        "Partendo dal più piccolo, metti in ordine di dimensioni:",
                        "Começando pelo menor, coloque em ordem de tamanho:"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Star, Solar System, galaxy, Universe",
                            "Stella, Sistema solare, galassia, universo",
                            "Estrela, Sistema Solar, galáxia, Universo"
                        ),
                        Util.EngItaPor(
                            "Star, galaxy, Solar System, Universe",
                            "Stella, galassia, Sistema solare, universo",
                            "Estrela, galáxia, Sistema Solar, Universo"
                        ),
                        Util.EngItaPor(
                            "Universe, galaxy, star, Solar System",
                            "Universo, galassia, stella, Sistema solare",
                            "Universo, galáxia, estrela, Sistema Solar"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Are there groups of galaxies?",
                        "Esistono gruppi di galassie?",
                        "Existem grupos de galáxias?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Yes, they are called clusters of galaxies",
                            "Sì, si chiamano ammassi di galassie",
                            "Sim, são chamados de grupos e aglomerados de galáxias"
                        ),
                        Util.EngItaPor(
                            "No, they are isolated",
                            "No, stanno isolate",
                            "Não, estão isoladas"
                        ),
                        Util.EngItaPor(
                            "No, galaxies move away from each other",
                            "No, le galassie si allontanano le une dalle altre",
                            "Não, as galáxias se afastam umas das outras"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is a quasar?",
                        "Che cos'è un quasar?",
                        "O que é um quasar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A quasi-stellar radiosource",
                            "Una radiosorgente quasi stellare",
                            "Uma fonte de rádio quasi-estelar"
                        ),
                        Util.EngItaPor(
                            "A pulsar",
                            "Una pulsar",
                            "Um pulsar"
                        ),
                        Util.EngItaPor(
                            "A stellar blòack hole",
                            "Un buco nero stellare",
                            "Um buraco negro estelar"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How many galaxies are there in the Universe?",
                        "Quante galassie ci sono nell'universo?",
                        "Quantas galáxias existem no Universo?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Over 200 billions",
                            "Oltre 200 miliardi",
                            "Mais de 200 bilhões"
                        ),
                        Util.EngItaPor(
                            "About 2 billions",
                            "Circa 2 miliardi",
                            "Cerca de 2 bilhões"
                        ),
                        Util.EngItaPor(
                            "200 millions",
                            "200 milioni",
                            "200 milhões"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "particles", Util.EngItaPor("Particles", "Particelle", "Partículas"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What are the main components of cosmic rays?",
                        "Di cosa sono composti principalmente i raggi cosmici?",
                        "Quais são os principais componentes dos raios cósmicos?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Protons",
                            "Protoni",
                            "Prótons"
                        ),
                        Util.EngItaPor(
                            "Neutrinos",
                            "Neutrini",
                            "Neutrinos"
                        ),
                        Util.EngItaPor(
                            "Photons",
                            "Fotoni",
                            "Fótons"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What are neutrinos?",
                        "Cosa sono i neutrini?",
                        "O que são neutrinos?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Particlea without eletctric charge and with very small mass",
                            "Particelle prive di carica elettrica e con massa piccolissima",
                            "Partículas sem carga elétrica e com massa muito pequena"
                        ),
                        Util.EngItaPor(
                            "Protons",
                            "Protoni",
                            "Prótons"
                        ),
                        Util.EngItaPor(
                            "Photons",
                            "Fotoni",
                            "Fótons"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Do neutrinos interact with matter?",
                        "I neutrini interagiscono con la materia?",
                        "Os neutrinos interagem com a matéria?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Very seldom",
                            "Molto raramente",
                            "Muito raramente"
                        ),
                        Util.EngItaPor(
                            "Always",
                            "Sempre",
                            "Sempre"
                        ),
                        Util.EngItaPor(
                            "They cannot cross the matter",
                            "Non possono attraversare la materia",
                            "Eles não conseguem atravessar a matéria"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What are cosmic rays diverted from?",
                        "Da cosa vengono deviati i raggi cosmici?",
                        "O que desvia raios cósmicos?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "From magnetic fields",
                            "Dai campi magnetici",
                            "Campos magnéticos"
                        ),
                        Util.EngItaPor(
                            "From gravity",
                            "Dalla gravità",
                            "Gravidade"
                        ),
                        Util.EngItaPor(
                            "From low temperatures",
                            "Dalle basse temperature",
                            "Baixas temperaturas"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is a proton?",
                        "Che cosa è un protone?",
                        "O que é um próton?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "It's a particle with a positive charge",
                            "È una particella elementare con carica positiva",
                            "É uma partícula com carga positiva"
                        ),
                        Util.EngItaPor(
                            "It's a particle without charge",
                            "È una particella elementare priva di carica",
                            "É uma partícula sem carga"
                        ),
                        Util.EngItaPor(
                            "It's a particle with a negative charge",
                            "È una particella elementare con carica negativa",
                            "É uma partícula com carga negativa"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is a neutron?",
                        "Che cosa è un neutrone?",
                        "O que é um nêutron?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "It's a particle without charge",
                            "È una particella elementare priva di carica",
                            "É uma partícula sem carga"
                        ),
                        Util.EngItaPor(
                            "It's a particle with a positive charge",
                            "È una particella elementare con carica positiva",
                            "É uma partícula com carga positiva"
                        ),
                        Util.EngItaPor(
                            "It's a particle with a negative charge",
                            "È una particella elementare con carica negativa",
                            "É uma partícula com carga negativa"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is an electron?",
                        "Che cosa è un elettrone?",
                        "O que é um elétron?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "It's an elementary particle with a negative charge",
                            "È una particella elementare con carica negativa",
                            "É uma partícula elementar com carga negativa"
                        ),
                        Util.EngItaPor(
                            "It's an elementary particle with a positive charge",
                            "È una particella elementare con carica positiva",
                            "É uma partícula elementar com carga positiva"
                        ),
                        Util.EngItaPor(
                            "It's an elementary particle without charge",
                            "È una particella elementare priva di carica",
                            "É uma partícula elementar sem carga"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What gives rise to polar auroras?",
                        "Cosa origina le aurore polari?",
                        "O que dá origem às auroras polares?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Cosmic rays flowing to the Earth's poles",
                            "I raggi cosmici che fluiscono ai poli terrestri",
                            "Raios cósmicos fluindo para os polos da Terra"
                        ),
                        Util.EngItaPor(
                            "The rifraction of Sunlight",
                            "La rifrazione della luce del Sole",
                            "A refração da luz solar"
                        ),
                        Util.EngItaPor(
                            "Lightnings",
                            "Lampi",
                            "Relâmpagos"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the solar wind?",
                        "Che cos'è il vento solare?",
                        "O que é o vento solar?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A flow of charged particles coming from the Sun",
                            "Un flusso di particelle cariche proveniente dal Sole",
                            "Um fluxo de partículas carregadas provenientes do Sol"
                        ),
                        Util.EngItaPor(
                            "Electromagnetic radiation emitted by the solar photosphere",
                            "Radiazione elettromagnetica emessa dalla fotosfera solare",
                            "Radiação eletromagnética emitida pela fotosfera solar"
                        ),
                        Util.EngItaPor(
                            "A warm wind of solar origin which is felt on the Earth",
                            "Un vento caldo di origine solare che si sente sulla Terra",
                            "Um vento morno de origem solar que é sentido na Terra"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What particles are present in the nuclei of all atoms?",
                        "Quali particelle sono presenti nei nuclei di tutti gli atomi?",
                        "Quais partículas estão presentes nos núcleos de todos os átomos?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Protons",
                            "Protoni",
                            "Prótons"
                        ),
                        Util.EngItaPor(
                            "Neutrons",
                            "Neutroni",
                            "Nêutrons"
                        ),
                        Util.EngItaPor(
                            "Electrons",
                            "Elettroni",
                            "Elétrons"
                        ),
                    ]
                }
            );

            await Util.AddCategory(s, EventName, "instruments", Util.EngItaPor("Instrumentation", "Strumentazione", "Instrumentação"),
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What instrument breaks down the ligh in the different colours of the rainbow?",
                        "Quale strumento scompone la luce nei diversi colori dell'arcobaleno?",
                        "Qual instrumento que decompõe a luz nas diferentes cores do arco-íris?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Spectroscope",
                            "Spettroscopio",
                            "Espectroscópio"
                        ),
                        Util.EngItaPor(
                            "Telescope",
                            "Telescopio",
                            "Telescópio"
                        ),
                        Util.EngItaPor(
                            "Microscope",
                            "Microscopio",
                            "Microscópio"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What kind of optical telescope is only made of lenses?",
                        "Quale tipo di telescopio ottico è fatto solo di lenti?",
                        "Que tipo de telescópio óptico é feito apenas de lentes?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Refractor",
                            "Rifrattore",
                            "Refrator"
                        ),
                        Util.EngItaPor(
                            "Reflector",
                            "Riflettore",
                            "Refletor"
                        ),
                        Util.EngItaPor(
                            "Catadioptric",
                            "Catadiottrico",
                            "Catadióptrico"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Where is the largest Italian optical telescope?",
                        "Dove si trova il più grande telescopio ottico italiano?",
                        "Onde está o maior telescópio óptico italiano?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "In an island of the Canaries, Spain",
                            "In un'isola delle Canarie, in Spagna",
                            "Numa ilha das Canárias, Espanha"
                        ),
                        Util.EngItaPor(
                            "Italy",
                            "Italia",
                            "Itália"
                        ),
                        Util.EngItaPor(
                            "Switzerland",
                            "Svizzera",
                            "Suíça"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Chi è stato che per primo ha rivolto il telescopio verso il cielo?",
                        "Chi è stato che per primo ha rivolto il telescopio verso il cielo?",
                        "Quem foi o primeiro a apontar o telescópio para o céu?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Galileo Galilei",
                            "Galileo Galilei",
                            "Galileu Galilei"
                        ),
                        Util.EngItaPor(
                            "Johannes Kepler",
                            "Johannes Kepler",
                            "Johannes Kepler"
                        ),
                        Util.EngItaPor(
                            "Charles Messier",
                            "Charles Messier",
                            "Charles Messier"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the best place where you can build an optical telescope?",
                        "Qual è il posto migliore per costruire un telescopio ottico?",
                        "Qual é o melhor local para construir um telescópio óptico?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "On top of a mountain",
                            "In cima ad una montagna",
                            "No topo de uma montanha"
                        ),
                        Util.EngItaPor(
                            "On the beach",
                            "In spiaggia",
                            "Na praia"
                        ),
                        Util.EngItaPor(
                            "In the city",
                            "In città",
                            "Na cidade"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What kind of telescope on Earth can be used both day and night?",
                        "Che tipo di telescopio sulla Terra può essere utilizzato sia di giorno che di notte ?",
                        "Que tipo de telescópio na Terra pode ser usado tanto de dia quanto de noite?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Radiotelescope",
                            "Radiotelescopio",
                            "Radiotelescópio"
                        ),
                        Util.EngItaPor(
                            "Optical telescope",
                            "Telescopio ottico",
                            "Telescópio óptico"
                        ),
                        Util.EngItaPor(
                            "X telescope",
                            "Telescopio X",
                            "Telescópio X"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is the name of the well-known optical telescope orbiting at about 500 kilometres from the Earth?",
                        "Come si chiama il famoso telescopio ottico in orbita a circa 500 chilometri dalla Terra?",
                        "Qual é o nome do conhecido telescópio óptico que orbita a cerca de 500 quilômetros da Terra?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "Hubble",
                            "Hubble",
                            "Hubble"
                        ),
                        Util.EngItaPor(
                            "Kepler",
                            "Kepler",
                            "Kepler"
                        ),
                        Util.EngItaPor(
                            "Chandra",
                            "Chandra",
                            "Chandra"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "How was the first image of a black hole obtained?",
                        "In che modo è stata ottenuta la prima immagine di un buco nero?",
                        "Como foi obtida a primeira imagem de um buraco negro?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "With different radiotelescopes at the same time",
                            "Con diversi radiotelescopi contemporaneamente",
                            "Com diferentes radiotelescópios simultaneamente"
                        ),
                        Util.EngItaPor(
                            "With a single very powerful radiotelescope",
                            "Con un singolo radiotelescopio molto potente",
                            "Com um único radiotelescópio muito poderoso"
                        ),
                        Util.EngItaPor(
                            "With different optical telescopes",
                            "Con diversi telescopi ottici",
                            "Com diferentes telescópios ópticos"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "Where do you place instruments in order to detect X and Gammma radiation?",
                        "Dove si posizionano gli strumenti per rilevare la radiazione X e gamma?",
                        "Onde você coloca instrumentos para detectar radiação X e gama?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "In the space, out of the atmosphere",
                            "Nello spazio, fuori dall'atmosfera",
                            "No espaço, fora da atmosfera"
                        ),
                        Util.EngItaPor(
                            "In the deserts",
                            "Nei deserti",
                            "Nos desertos"
                        ),
                        Util.EngItaPor(
                            "In the mountains",
                            "Sulle montagne",
                            "Nas montanhas"
                        ),
                    ]
                },
                new CodyMazeBot.StoreModels.Question {
                    QuestionText = Util.EngItaPor(
                        "What is a radiotelescope?",
                        "Che cos'è un radiotelescopio?",
                        "O que é um radiotelescópio?"
                    ),
                    Answers = [
                        Util.EngItaPor(
                            "A telescope which detects radio waves",
                            "Un telescopio che rileva le onde radio",
                            "Um telescópio que detecta ondas de rádio"
                        ),
                        Util.EngItaPor(
                            "A telescope measuring radioactivity",
                            "Un telescopio che misura la radioattività",
                            "Um telescópio que mede radioatividade"
                        ),
                        Util.EngItaPor(
                            "A telescope which detects gamma rays",
                            "Un telescopio che rileva i raggi gamma",
                            "Um telescópio que detecta raios gama"
                        ),
                    ]
                }
            );
        }
    }
}
