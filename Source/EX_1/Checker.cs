using System;
using System.Collections.Generic;

namespace EX_1
{
    public class Person
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Man, Female
    }

    public interface ICheck
    {
        public bool Check(Person p);
    }

    public class AgeChecker : ICheck
    {
        public bool Check(Person p)
        {
            return p.Age >= 18;
        }
    }

    public class GenderChecker : ICheck
    {
        public bool Check(Person p)
        {
            return p.Gender == Gender.Man;
        }
    }

    public interface IPersonProcessor
    {
        void RunChecks(Person p);
    }

    public class PersonProcessor : IPersonProcessor
    {
        private IEnumerable<ICheck> Checks;

        public PersonProcessor(IEnumerable<ICheck> checks)
        {
            Checks = checks;
        }

        public void RunChecks(Person p)
        {
            foreach (var check in Checks)
            {
                Console.WriteLine($"{p.Name}: {nameof(check)} - result: {check.Check(p)}");
            }
        }
    }
}