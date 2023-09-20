using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffebot_Discord
{
    internal class Kaffekoe
    {
        private Queue<Person> kaffekoe = new Queue<Person>();

        public void Enqueue(Person person)
        {
            kaffekoe.Enqueue(person);
        }

        public Person Dequeue()
        {
            return kaffekoe.Dequeue();
        }

        public void Rotate()
        {
            if (kaffekoe.Count > 1)
            {
                var firstPerson = kaffekoe.Dequeue();
                kaffekoe.Enqueue(firstPerson);
            }
        }
        public override string ToString()
        {
            return string.Join(", ",kaffekoe);

            
        }

       
    }
}
