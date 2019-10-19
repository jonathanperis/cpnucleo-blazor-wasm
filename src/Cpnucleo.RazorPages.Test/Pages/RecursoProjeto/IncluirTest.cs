﻿using Cpnucleo.Application.Interfaces;
using Cpnucleo.Infra.CrossCutting.Util.ViewModels;
using Cpnucleo.RazorPages.Pages.RecursoProjeto;
using Moq;
using SparkyTestHelpers.AspNetMvc.Core;
using SparkyTestHelpers.DataAnnotations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cpnucleo.RazorPages.Test.Pages.RecursoProjeto
{
    public class IncluirTest
    {
        private readonly Mock<IRecursoProjetoAppService> _recursoProjetoAppService;
        private readonly Mock<IRecursoAppService> _recursoAppService;
        private readonly Mock<IProjetoAppService> _projetoAppService;

        public IncluirTest()
        {
            _recursoProjetoAppService = new Mock<IRecursoProjetoAppService>();
            _recursoAppService = new Mock<IRecursoAppService>();
            _projetoAppService = new Mock<IProjetoAppService>();
        }

        [Fact]
        public void Test_OnGet()
        {
            // Arrange
            Guid idProjeto = Guid.NewGuid();

            ProjetoViewModel projetoMock = new ProjetoViewModel { };
            List<RecursoViewModel> listaMock = new List<RecursoViewModel> { };

            IncluirModel pageModel = new IncluirModel(_recursoProjetoAppService.Object, _recursoAppService.Object, _projetoAppService.Object)
            {
                PageContext = PageContextManager.CreatePageContext()
            };

            _projetoAppService.Setup(x => x.Consultar(idProjeto)).Returns(projetoMock);
            _recursoAppService.Setup(x => x.Listar()).Returns(listaMock);

            PageModelTester<IncluirModel> pageTester = new PageModelTester<IncluirModel>(pageModel);

            // Act
            pageTester
                .Action(x => () => x.OnGet(idProjeto))

                // Assert
                .TestPage();
        }

        [Fact]
        public void Test_OnPost()
        {
            // Arrange
            Guid idProjeto = Guid.NewGuid();

            RecursoProjetoViewModel recursoProjetoMock = new RecursoProjetoViewModel { IdProjeto = idProjeto };
            ProjetoViewModel projetoMock = new ProjetoViewModel { };
            List<RecursoViewModel> listaMock = new List<RecursoViewModel> { };

            IncluirModel pageModel = new IncluirModel(_recursoProjetoAppService.Object, _recursoAppService.Object, _projetoAppService.Object)
            {
                PageContext = PageContextManager.CreatePageContext()
            };

            _recursoProjetoAppService.Setup(x => x.Incluir(recursoProjetoMock));
            _projetoAppService.Setup(x => x.Consultar(idProjeto)).Returns(projetoMock);
            _recursoAppService.Setup(x => x.Listar()).Returns(listaMock);

            PageModelTester<IncluirModel> pageTester = new PageModelTester<IncluirModel>(pageModel);

            // Act
            pageTester
                .Action(x => () => x.OnPost(idProjeto))

                // Assert
                .WhenModelStateIsValidEquals(false)
                .TestPage();

            // Act
            pageTester
                .Action(x => () => x.OnPost(idProjeto))

                // Assert
                .WhenModelStateIsValidEquals(true)
                .TestRedirectToPage("Listar");

            // Assert
            Validation.For(recursoProjetoMock).ShouldReturn.NoErrors();
        }
    }
}