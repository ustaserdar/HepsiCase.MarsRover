using HepsiCase.Application.Contracts;
using HepsiCase.IoC;
using HepsiCase.Shared.Enums;
using HepsiCase.Shared.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace HepsiCase.Test
{
    public class RoverTest
    {
        private IRover _rover;

        [SetUp]
        public void Setup()
        {
            var services = ServiceContainerBuilder.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            _rover = serviceProvider.GetService<IRover>();

            _rover.SetPosition("2 4 W");
        }

        [Test]
        public void Rover_TurnLeft()
        {
            _rover.TurnLeft();

            Assert.AreEqual(Directions.S, _rover.Direction);
        }

        [Test]
        public void Rover_TurnRight()
        {
            _rover.TurnRight();

            Assert.AreEqual(Directions.N, _rover.Direction);
        }

        [Test]
        public void Rover_MoveForward()
        {
            _rover.MoveForward();

            Assert.AreEqual(1, _rover.PositionX);
            Assert.AreEqual(Directions.W, _rover.Direction);
        }

        [Test]
        public void Rover_SetPosition()
        {
            _rover.SetPosition("1 5 S");

            Assert.AreEqual(1, _rover.PositionX);
            Assert.AreEqual(5, _rover.PositionY);
            Assert.AreEqual(Directions.S, _rover.Direction);
        }

        [Test]
        public void Rover_SetPosition_PositionException()
        {
            Assert.Throws(typeof(PositionException), () => _rover.SetPosition("A B D"));
        }
    }
}