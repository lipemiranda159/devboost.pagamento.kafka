﻿using devboost.dronedelivery.core.domain;
using devboost.dronedelivery.core.domain.Enums;
using devboost.dronedelivery.core.services;
using devboost.dronedelivery.pagamento.EF.Integration;
using devboost.dronedelivery.sb.domain.Interfaces;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test
{
    public class PagamentoIntegrationTests
    {
        private readonly DeliverySettingsData _deliverySettings;
        private readonly IProducer _producer;

        public PagamentoIntegrationTests()
        {
            _deliverySettings = new DeliverySettingsData()
            {
                UrlBase = "http://www.api.com"
            };
            _producer = Substitute.For<IProducer>();
        }
        [Fact]
        public async Task ReportarResultadoAnaliseTest()
        {
            var pagamentoIntegration = new PagamentoIntegration(_deliverySettings, _producer);
            var listPagamento = new List<PagamentoStatusDto>()
            {
                new PagamentoStatusDto()
                {
                    Descricao = "teste",
                    IdPagamento = 1,
                    Status = EStatusPagamento.APROVADO
                }
            };

            Assert.True(await pagamentoIntegration.ReportarResultadoAnalise(listPagamento));

        }
    }
}
