using System;
using System.Collections.Generic;
using System.Linq;

// English Pluralizatin Rules are Ported from FSharpx
// https://github.com/fsprojects/FSharpx.Extras/blob/master/src/FSharpx.Extras/Pluralizer.fs

namespace Plurally.Localization
{
    public class LocaleEN : ILocalization
	{
        private readonly Dictionary<string, string> SuffixRules = new Dictionary<string, string>()
        {
            { "ch",    "ches"   },
            { "sh",    "shes"   },
            { "ss",    "sses"   },
            { "ay",    "ays"    },
            { "ey",    "eys"    },
            { "iy",    "iys"    },
            { "oy",    "oys"    },
            { "uy",    "uys"    },
            { "y",     "ies"    },
            { "ao",    "aos"    },
            { "eo",    "eos"    },
            { "io",    "ios"    },
            { "oo",    "oos"    },
            { "uo",    "uos"    },
            { "o",     "oes"    },
            { "house", "houses" },
            { "cis",   "ces"    },
            { "sis",   "ses"    },
            { "xis",   "xes"    },
            { "louse", "lice"   },
            { "mouse", "mice"   },
            { "zoon",  "zoa"    },
            { "man",   "men"    },
            { "deer",  "deer"   },
            { "fish",  "fish"   },
            { "sheep", "sheep"  },
            { "itis",  "itis"   },
            { "ois",   "ois"    },
            { "pox",   "pox"    },
            { "ox",    "oxes"   },
            { "foot",  "feet"   },
            { "goose", "geese"  },
            { "tooth", "teeth"  },
            { "alf",   "alves"  },
            { "elf",   "elves"  },
            { "olf",   "olves"  },
            { "arf",   "arves"  },
            { "leaf",  "leaves" },
            { "nife",  "nives"  },
            { "life",  "lives"  },
            { "wife",  "wives"  },
            { "us",    "uses"   }
        };

        private readonly List<string> UnusualWords = new List<string>()
        {
            "aircraft",
            "bison",
            "carp",
            "chassis",
            "chinese",
            "clippers",
            "cod",
            "corps",
            "debris",
            "diabetes",
            "djinn",
            "dynamo",
            "elk",
            "flounder",
            "gallows",
            "graffiti",
            "headquarters",
            "herpes",
            "homework",
            "japanese",
            "mackerel",
            "measles",
            "mumps",
            "news",
            "pincers",
            "pliers",
            "rabies",
            "salmon",
            "scissors",
            "series",
            "shears",
            "species",
            "swine",
            "trout",
            "tuna"
        };

        private readonly List<Tuple<string, string, string>> SpecialWords = new List<Tuple<string, string, string>>
        {
            Tuple.Create("agendum",      "agenda",       ""            ),
            Tuple.Create("albino",       "albinos",      ""            ),
            Tuple.Create("alga",         "algae",        ""            ),
            Tuple.Create("alumna",       "alumnae",      ""            ),
            Tuple.Create("alumnus",      "alumni",       ""            ),
            Tuple.Create("apex",         "apices",       "apexes"      ),
            Tuple.Create("archipelago",  "archipelagos", ""            ),
            Tuple.Create("bacterium",    "bacteria",     ""            ),
            Tuple.Create("beef",         "beefs",        "beeves"      ),
            Tuple.Create("brother",      "brothers",     "brethren"    ),
            Tuple.Create("candelabrum",  "candelabra",   ""            ),
            Tuple.Create("casino",       "casinos",      ""            ),
            Tuple.Create("child",        "children",     ""            ),
            Tuple.Create("codex",        "codices",      ""            ),
            Tuple.Create("commando",     "commandos",    ""            ),
            Tuple.Create("cortex",       "cortices",     "cortexes"    ),
            Tuple.Create("cow",          "cows",         "kine"        ),
            Tuple.Create("criterion",    "criteria",     ""            ),
            Tuple.Create("datum",        "data",         ""            ),
            Tuple.Create("ditto",        "dittos",       ""            ),
            Tuple.Create("embryo",       "embryos",      ""            ),
            Tuple.Create("ephemeris",    "ephemeris",    "ephemerides" ),
            Tuple.Create("erratum",      "errata",       ""            ),
            Tuple.Create("extremum",     "extrema",      ""            ),
            Tuple.Create("fiasco",       "fiascos",      ""            ),
            Tuple.Create("fish",         "fishes",       "fish"        ),
            Tuple.Create("focus",        "focuses",      "foci"        ),
            Tuple.Create("fungus",       "fungi",        "funguses"    ),
            Tuple.Create("genie",        "genies",       "genii"       ),
            Tuple.Create("ghetto",       "ghettos",      ""            ),
            Tuple.Create("index",        "indices",      "indexes"     ),
            Tuple.Create("inferno",      "infernos",     ""            ),
            Tuple.Create("jumbo",        "jumbos",       ""            ),
            Tuple.Create("latex",        "latices",      "latexes"     ),
            Tuple.Create("lingo",        "lingos",       ""            ),
            Tuple.Create("macro",        "macros",       ""            ),
            Tuple.Create("money",        "moneys",       "monies"      ),
            Tuple.Create("mongoose",     "mongooses",    "mongoose"    ),
            Tuple.Create("murex",        "murecis",      ""            ),
            Tuple.Create("mythos",       "mythos",       "mythoi"      ),
            Tuple.Create("octopus",      "octopuses",    "octopodes"   ),
            Tuple.Create("ovum",         "ova",          ""            ),
            Tuple.Create("ox",           "ox",           "oxen"        ),
            Tuple.Create("photo",        "photos",       ""            ),
            Tuple.Create("pro",          "pros",         ""            ),
            Tuple.Create("radius",       "radiuses",     "radii"       ),
            Tuple.Create("rhino",        "rhinos",       ""            ),
            Tuple.Create("silex",        "silices",      ""            ),
            Tuple.Create("simplex",      "simplices",    "simplexes"   ),
            Tuple.Create("soliloquy",    "soliloquies",  "soliloquy"   ),
            Tuple.Create("stratum",      "strata",       ""            ),
            Tuple.Create("vertebra",     "vertebrae",    ""            ),
            Tuple.Create("vertex",       "vertices",     "vertexes"    ),
            Tuple.Create("vortex",       "vortices",     "vortexes"    )
        };

		public bool IsPlural(string word)
		{
            word = word.ToLowerInvariant();
            return (
                // Check to make sure not one of our special words
                !SpecialWords.Any(w => w.Item1 == word && w.Item2 != word && w.Item3 != word)
                // Check if unusual plural
                && (UnusualWords.Any(w => w == word)
                // Check if special plural
                || SpecialWords.Any(w => w.Item2 == word || w.Item3 == word)
                // Check if suffix matches
                || SuffixRules.Values
                    .Where(s => word.Length >= s.Length)
                    .Any(s => word.Substring(0, s.Length) == s)
                // Match S
                || word.EndsWith("s"))
            );
		}

        public bool IsSingular(string word)
        {
            throw new NotImplementedException();
        }
	}
}

