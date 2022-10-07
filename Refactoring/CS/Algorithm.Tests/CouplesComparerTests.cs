using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Test
{    
    public class CouplesComparerTests
    {
        private readonly Person _sue = new Person() { Name = "Sue", BirthDate = new DateTime(1950, 1, 1) };
        private readonly Person _greg = new Person() { Name = "Greg", BirthDate = new DateTime(1952, 6, 1) };
        private readonly Person _sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        private readonly Person _mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };

        [Fact]
        public void When_Given_No_People_Returns_Empty_Couple()
        {
            var people = new List<Person>();
            var comparer = new CouplesComparer(people);

            var winningCouple = comparer.FindCoupleByAgeDifference(AgeComparisonType.ClosestInAge);

            Assert.Null(winningCouple.Person1);
            Assert.Null(winningCouple.Person2);
        }

        [Fact]
        public void When_Given_One_Person_Returns_Empty_Couple()
        {
            var people = new List<Person>() { _sue };
            var comparer = new CouplesComparer(people);

            var winningCouple = comparer.FindCoupleByAgeDifference(AgeComparisonType.ClosestInAge);

            Assert.Null(winningCouple.Person1);
            Assert.Null(winningCouple.Person2);
        }

        [Fact]
        public void When_Given_Two_People_Returns_Closest_Couple()
        {
            var people = new List<Person>() { _sue, _greg };
            var comparer = new CouplesComparer(people);

            var winningCouple = comparer.FindCoupleByAgeDifference(AgeComparisonType.ClosestInAge);

            Assert.Same(_sue, winningCouple.Person1);
            Assert.Same(_greg, winningCouple.Person2);
        }

        [Fact]
        public void When_Given_Two_People_Returns_Furthest_Couple()
        {
            var people = new List<Person>() { _greg, _mike };
            var comparer = new CouplesComparer(people);

            var winningCouple = comparer.FindCoupleByAgeDifference(AgeComparisonType.FurthestInAge);

            Assert.Same(_greg, winningCouple.Person1);
            Assert.Same(_mike, winningCouple.Person2);
        }

        [Fact]
        public void When_Given_Four_People_Returns_Closest_Couple()
        {
            var people = new List<Person>() { _greg, _mike, _sarah, _sue };
            var comparer = new CouplesComparer(people);

            var winningCouple = comparer.FindCoupleByAgeDifference(AgeComparisonType.ClosestInAge);

            Assert.Same(_sue, winningCouple.Person1);
            Assert.Same(_greg, winningCouple.Person2);
        }

        [Fact]
        public void When_Given_Four_People_Returns_Furthest_Couple()
        {
            var people = new List<Person>() { _greg, _mike, _sarah, _sue };
            var comparer = new CouplesComparer(people);

            var winningCouple = comparer.FindCoupleByAgeDifference(AgeComparisonType.FurthestInAge);

            Assert.Same(_sue, winningCouple.Person1);
            Assert.Same(_sarah, winningCouple.Person2);
        }
    }
}