using System.Collections.Generic;
using System.Linq;
using AutoFixture;

namespace BlogApp.API.Tests
{
    public class TestBase
    {
        public IFixture FixtureRepository { get; set; }

        public TestBase()
        {
            FixtureRepository = new Fixture();
        }

        public T Create<T>()
        {
            return FixtureRepository.Create<T>();
        }

        public List<T> CreateMany<T>()
        {
            return FixtureRepository.CreateMany<T>().ToList();
        }
    }
}