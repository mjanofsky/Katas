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

            foreach (var challengers in _couples)
            {
                switch (ageComparisonType)
                {
                    case AgeComparisonType.ClosestInAge:
                        if (challengers.AgeDiff < winningCouple.AgeDiff)
                        {
                            winningCouple = challengers;
                        }

                        break;

                    case AgeComparisonType.FurthestInAge:
                        if (challengers.AgeDiff > winningCouple.AgeDiff)
                        {
                            winningCouple = challengers;
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
                    var currentCouple = CreateCouple(_people[i], _people[j]);
                    AssignOldestPersonToPerson1(currentCouple);
                    _couples.Add(currentCouple);
                }
            }
        }
        Couple CreateCouple(Person person1, Person person2)
        {
            var currentCouple = new Couple
            {
                Person1 = person1,
                Person2 = person2
            };
            return currentCouple;
        }

        void AssignOldestPersonToPerson1(Couple currentCouple)
        {
            if (currentCouple.Person2.IsOlderThan(currentCouple.Person1))
            {
                var tempPerson = currentCouple.Person1;
                currentCouple.Person1 = currentCouple.Person2;
                currentCouple.Person2 = tempPerson;
            }
        }


    }
}