using B3.Model.Ativos.CDB;
using B3.Model.Calculo;
using BackendB3;
using BackendB3.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BackendB3.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Cdb_AteUmAnoEValorInicialPositivo_DeveRetornarSucesso()
        {
            // Arrange
            CalculoCdb calculoCdb = new CalculoCdb();
            decimal valorInicial = 1000m;
            uint qtdMeses = 12;

            // Act
            var cdb = calculoCdb.CalcularCdb(valorInicial, qtdMeses);

            // Assert
            Assert.IsTrue(cdb.Sucesso);
        }

        [DataTestMethod]
        [DataRow(1000, 2u)]
        [DataRow(1000, 3u)]
        [DataRow(1000, 4u)]
        [DataRow(1000, 5u)]
        [DataRow(1000, 6u)]
        public void IR_AteSeisMeses_DeveRetornarSucesso(float valor, uint meses)
        {
            // Arrange
            CalculoCdb calculoCdb = new CalculoCdb();

            // Act
            var cdb = calculoCdb.CalcularCdb((decimal)valor, meses);

            // Assert
            Assert.AreEqual(Aliquotas.AteSeisMeses, cdb.Data.AliquotaImpostoRenda);
        }

        [DataTestMethod]
        [DataRow(1000, 7u)]
        [DataRow(1000, 8u)]
        [DataRow(1000, 9u)]
        [DataRow(1000, 10u)]
        [DataRow(1000, 11u)]
        [DataRow(1000, 12u)]
        public void IR_AteDozeMeses_DeveRetornarSucesso(float valor, uint meses)
        {
            // Arrange
            CalculoCdb calculoCdb = new CalculoCdb();

            // Act
            var cdb = calculoCdb.CalcularCdb((decimal)valor, meses);

            // Assert
            Assert.AreEqual(Aliquotas.AteUmAno, cdb.Data.AliquotaImpostoRenda);
        }

        [DataTestMethod]
        [DataRow(1000, 13u)]
        [DataRow(1000, 14u)]
        [DataRow(1000, 15u)]
        [DataRow(1000, 16u)]
        [DataRow(1000, 17u)]
        [DataRow(1000, 18u)]
        [DataRow(1000, 19u)]
        [DataRow(1000, 20u)]
        [DataRow(1000, 21u)]
        [DataRow(1000, 22u)]
        [DataRow(1000, 23u)]
        [DataRow(1000, 24u)]
        public void IR_AteDoisAnos_DeveRetornarSucesso(float valor, uint meses)
        {
            // Arrange
            CalculoCdb calculoCdb = new CalculoCdb();

            // Act
            var cdb = calculoCdb.CalcularCdb((decimal)valor, meses);

            // Assert
            Assert.AreEqual(Aliquotas.AteDoisAnos, cdb.Data.AliquotaImpostoRenda);
        }

        [DataTestMethod]
        [DataRow(1000, 36u)]
        public void IR_MaisDeDoisAnos_DeveRetornarSucesso(float valor, uint meses)
        {
            // Arrange
            CalculoCdb calculoCdb = new CalculoCdb();

            // Act
            var cdb = calculoCdb.CalcularCdb((decimal)valor, meses);

            // Assert
            Assert.AreEqual(Aliquotas.MaisDeDoisAnos, cdb.Data.AliquotaImpostoRenda);
        }

        [DataTestMethod]
        [DataRow(1, 0u)]
        public void Cdb_ReceberMesIgualOuMenorQueUm_DeveRetornarErro(float valor, uint meses)
        {
            // Assert
            Assert.ThrowsException<ArgumentException>(() => new CalculoCdb().CalcularCdb((decimal)valor, meses));
        }


    }
}
