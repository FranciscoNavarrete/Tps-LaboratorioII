using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void VerificarListaPaquetesInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIDRepetidoException))]
        public void VerificarPaqueteDuplicado()
        {
            Correo correo = new Correo();
           
            Paquete paquete1 = new Paquete("Mitre 123", "123-123-1234");
            Paquete paquete2 = new Paquete("Alsino 345", "123-123-1234");

            correo += paquete1;
            correo += paquete2;

            Assert.AreEqual(paquete1, paquete2);
        }
    }
}
