using HepsiCase.Application.Contracts;
using HepsiCase.IoC;
using HepsiCase.Shared.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace HepsiCase.Test
{
    public class PlateauTest
    {
        private IPlateau _plateau;
        private IRover _rover;

        [SetUp]
        public void Setup()
        {
            var services = ServiceContainerBuilder.ConfigureServices();
            var provider = services.BuildServiceProvider();

            _plateau = provider.GetService<IPlateau>();
            _rover = provider.GetService<IRover>();
        }

        [Test]
        public void Plateau_SetSize()
        {
            _plateau.SetSize("8 8");
            Assert.AreEqual(8, _plateau.Width);
            Assert.AreEqual(8, _plateau.Height);
        }

        [Test]
        public void Plateau_AddRover()
        {
            _plateau.SetSize("5 5");

            _rover.SetPosition("1 2 N");

            _plateau.AddRover(_rover);

            Assert.AreEqual(1, _plateau.Rovers.Count);
        }

        [Test]
        public void Plateau_AddRover_PlateauSizeOverException()
        {
            _plateau.SetSize("5 5");

            _rover.SetPosition("1 6 N");

            Assert.Throws(typeof(PlateauSizeException), () => _plateau.AddRover(_rover));
        }

        [Test]
        public void Plateau_SetSize_ZeroWidthHeightPlateauException()
        {
            Assert.Throws(typeof(PlateauSizeException), () => _plateau.SetSize("0 0"));
        }
    }
}