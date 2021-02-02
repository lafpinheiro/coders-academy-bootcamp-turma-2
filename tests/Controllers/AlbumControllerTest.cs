using System.Collections.Generic;
using Backend.Model;
using Moq;
using Xunit;
using FizzWare;
using FizzWare.NBuilder;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace tests.Controllers
{
    public class AlbumControllerTest
    {
        private Moq.Mock<Backend.Repository.IAlbumRepository> mockRepository { get; set; }
        private Backend.Controllers.AlbumController controller;

        [Fact]
        public async Task Should_Get_Albums()
        {
            mockRepository = new Moq.Mock<Backend.Repository.IAlbumRepository>();
            controller = new Backend.Controllers.AlbumController(mockRepository.Object);

            IList<Album> albums =  Builder<Album>.CreateListOfSize(10).Build();

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(albums);

            var result = await controller.Get();

            result.Should().NotBeNull();
            (result as OkObjectResult).StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task Should_Get_Album_By_Id()
        {
            mockRepository = new Moq.Mock<Backend.Repository.IAlbumRepository>();
            controller = new Backend.Controllers.AlbumController(mockRepository.Object);

            Album album = Builder<Album>.CreateNew().Build();

            mockRepository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(album);

            var result = await controller.GetAlbum(Guid.NewGuid());

            result.Should().NotBeNull();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
    }
    
}