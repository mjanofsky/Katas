using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class CouplesComparer
    {
        private readonly List<Person> _people;
        private List<Couple> _couples;

        public CouplesComparer(List<Person> people)
        {
            _people = people;
            CreateCouples();
        }

        public Couple FindCoupleByAgeDifference(AgeComparisonType ageComparisonType)
        {
            if (_people.Count < 2)
            {
                return new Couple();
            }

            Couple winningCouple = FindWinningCouple(ageComparisonType);

            return winningCouple;
        }

        private Couple FindWinningCouple(AgeComparisonType ageComparisonType)
        {
            Couple winningCouple = _couples.First();

            foreach (var couple in _couples)
            {
                switch (ageComparisonType)
                {
                    case AgeComparisonType.ClosestInAge:
                        if (couple.AgeDiff < winningCouple.AgeDiff)
                        {
                            winningCouple = couple;
                        }

                        break;

                    case AgeComparisonType.FurthestInAge:
                        if (couple.AgeDiff > winningCouple.AgeDiff)
                        {
                            winningCouple = couple;
                        }

                        break;
                }
            }

            return winningCouple;
        }

        private void CreateCouples()
        {
            _couples = new List<Couple>();

            for (var i = 0; i < _people.Count - 1; i++)
            {
                for (var j = i + 1; j < _people.Count; j++)
                {
                    var person1 = _people[i];
                    var person2 = _people[j];

                    var currentCouple = new Couple();

                    AssignOldestPersonToPerson1(person1, person2, currentCouple);

                    _couples.Add(currentCouple);
                }
            }

            void AssignOldestPersonToPerson1(Person person1, Person person2, Couple currentCouple)
            {
                if (person1.IsOlderThan(person2))
                {
                    currentCouple.Person1 = person1;
                    currentCouple.Person2 = person2;
                }
                else
                {
                    currentCouple.Person1 = person2;
                    currentCouple.Person2 = person1;
                }
            }
        }
    }
}