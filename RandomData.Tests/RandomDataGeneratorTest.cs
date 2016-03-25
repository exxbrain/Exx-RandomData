using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture;

namespace RandomData.Tests
{
    [TestFixture()]
    public class RandomDataGeneratorTest
    {
        [Test]
        public void Generate_CreatesObject()
        {
            //Arrange
            var generator = new RandomDataGenerator<Ordine>();

            //Act
            var res = generator.Generate();

            //Assert
            Assert.That(res, Is.TypeOf<Ordine>());
        }

        [Test]
        public void Generate_NumOfObjects_CreatesObjects()
        {
            //Arrange
            var generator = new RandomDataGenerator<Ordine>();
            var numOfObjects = new Fixture().Create<int>();

            //Act
            var res = generator.Generate(numOfObjects);

            //Assert
            Assert.That(res.Count(), Is.EqualTo(numOfObjects));
        }

        [Test]
        public void Ignore_PropertyReference_IntPropertyIsZero()
        {
            //Arrange
            var generator = new RandomDataGenerator<Ordine>();

            //Act
            generator.Ignore(o => o.id);
            var obj = generator.Generate();

            //Assert
            Assert.That(obj.id, Is.EqualTo(0));

        }

        [Test]
        public void Generate_CreatesObjectWithRandomilyPopulatedFields()
        {
            //Arrange
            var generator = new RandomDataGenerator<Ordine>();

            //Act
            var res = generator.Generate();

            //Assert
            Assert.That(res.destinatarioID, Is.GreaterThan(0));
            Assert.That(res.id, Is.GreaterThan(0));
            Assert.That(res.idHotel, Is.GreaterThan(0));
            Assert.That(res.idUtente, Is.GreaterThan(0));
            Assert.That(res.note, Is.Not.Null);
            Assert.That(res.room, Is.Not.Null);
            Assert.That(res.stato, Is.GreaterThan(0));
            Assert.That(res.ultimaModifica, Is.GreaterThan(DateTime.MinValue));
            Assert.That(res.utente, Is.Not.Null);
            Assert.That(res.utente.cognome, Is.Not.Null);
            Assert.That(res.utente.doNotDisturb, Is.GreaterThan(0));
            Assert.That(res.utente.eta, Is.GreaterThan(0));
            Assert.That(res.utente.frase, Is.Not.Null);
            Assert.That(res.utente.id, Is.GreaterThan(0));
        }
    }
}

