using JDE.Common.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test.meth();
            //Test.methDotNet();
            String spellData = "{ \"id\": 133, \"name\": \"Fireball\", \"icon\": \"spell_fire_flamebolt\", \"description\": \"Hurls a fiery ball that causes 1,846 Fire damage.\", \"range\": \"40 yd range\", \"powerCost\": \"4% of base mana\", \"castTime\": \"2.25 sec cast\"}";
            Spell s = JsonSerialization<Spell>.GetObject(spellData);

            string newdata = JsonSerialization<Spell>.GetString(s);

            var v = DataGenerator.GetUserDataSets();
            
            string json = JsonSerialization<ReportModel>.GetString(v);
            ReportModel rm = JsonSerialization<ReportModel>.GetObject(json);

        }
    }
}
