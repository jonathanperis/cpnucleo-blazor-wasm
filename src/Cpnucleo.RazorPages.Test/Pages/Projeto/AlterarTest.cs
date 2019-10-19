﻿using Cpnucleo.Application.Interfaces;
using Cpnucleo.Infra.CrossCutting.Util.ViewModels;
using Cpnucleo.RazorPages.Pages.Projeto;
using Moq;
using SparkyTestHelpers.AspNetMvc.Core;
using SparkyTestHelpers.DataAnnotations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cpnucleo.RazorPages.Test.Pages.Projeto
{
    public class AlterarTest
    {
        private readonly Mock<IProjetoAppService> _projetoAppService;
        private readonly Mock<ISistemaAppService> _sistemaAppService;

        public AlterarTest()
        {
            _projetoAppService = new Mock<IProjetoAppService>();
            _sistemaAppService = new Mock<ISistemaAppService>();
        }

        [Fact]
        public void Test_OnGet()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            ProjetoViewModel projetoMock = new ProjetoViewModel { };
            List<SistemaViewModel> listaMock = new List<SistemaViewModel> { };

            AlterarModel pageModel = new AlterarModel(_projetoAppService.Object, _sistemaAppService.Object)
            {
                PageContext = PageContextManager.CreatePageContext()
            };

            _projetoAppService.Setup(x => x.Consultar(id)).Returns(projetoMock);
            _sistemaAppService.Setup(x => x.Listar()).Returns(listaMock);

            PageModelTester<AlterarModel> pageTester = new PageModelTester<AlterarModel>(pageModel);

            // Act
            pageTester
                .Action(x => () => x.OnGet(id))

                // Assert
                .TestPage();
        }

        [Theory]
        [InlineData("Projeto de Teste")]
        public void Test_OnPost(string nome)
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid idSistema = Guid.NewGuid();

            ProjetoViewModel projetoMock = new ProjetoViewModel { Id = id, Nome = nome, IdSistema = idSistema };
            List<SistemaViewModel> listaMock = new List<SistemaViewModel> { };

            AlterarModel pageModel = new AlterarModel(_projetoAppService.Object, _sistemaAppService.Object)
            {
                PageContext = PageContextManager.CreatePageContext()
            };

            _projetoAppService.Setup(x => x.Alterar(projetoMock));
            _sistemaAppService.Setup(x => x.Listar()).Returns(listaMock);

            PageModelTester<AlterarModel> pageTester = new PageModelTester<AlterarModel>(pageModel);

            // Act
            pageTester
                .Action(x => x.OnPost)

                // Assert
                .WhenModelStateIsValidEquals(false)
                .TestPage();

            // Act
            pageTester
                .Action(x => x.OnPost)

                // Assert
                .WhenModelStateIsValidEquals(true)
                .TestRedirectToPage("Listar");

            // Assert
            Validation.For(projetoMock).ShouldReturn.NoErrors();
        }
    }
}