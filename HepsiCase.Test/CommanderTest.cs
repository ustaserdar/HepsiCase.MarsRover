using HepsiCase.Application.Contracts;
using HepsiCase.IoC;
using HepsiCase.Shared.Enums;
using HepsiCase.Shared.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace HepsiCase.Test
{
    public class CommanderTest
    {
        private ICommander _roverCommander;
        private IRover _rover;

        [SetUp]
        public void Setup()
        {
            var services = ServiceContainerBuilder.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            var plateau = serviceProvider.GetService<IPlateau>();
            plateau.SetSize("5 5");

            _roverCommander = serviceProvider.GetService<ICommander>();
            _roverCommander.Plateau = plateau;

            _rover = serviceProvider.GetService<IRover>();
            _rover.SetPosition("1 2 N");
            _rover.Commands = "LMLMLMLMM";

            _roverCommander.Plateau.AddRover(_rover);
        }

        [Test]
        public void RoverCommander_Move()
        {
            var rover = _roverCommander.Plateau.Rovers[0];

            _roverCommander.Move(rover);

            Assert.AreEqual(1, rover.PositionX);
            Assert.AreEqual(3, rover.PositionY);
            Assert.AreEqual(Directions.N, rover.Direction);
        }

        [Test]
        public void RoverCommander_Move_CommandException()
        {
            var rover = _roverCommander.Plateau.Rovers[0];
            rover.Commands = "LMLML?MLMM";

            Assert.Throws(typeof(CommandException), () => _roverCommander.Move(rover));
        }

        [Test]
        public void RoverCommander_Move_PlateauSizeOverException()
        {
            var rover = _roverCommander.Plateau.Rovers[0];
            rover.Commands = "LMLMLMMMMMMLMM";

            Assert.Throws(typeof(PlateauSizeException), () => _roverCommander.Move(rover));
        }
    }
}
