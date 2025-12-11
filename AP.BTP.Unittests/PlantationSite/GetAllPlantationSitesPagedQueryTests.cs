using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using Moq;

namespace AP.BTP.Unittests.PlantationSite
{
    [TestClass]
    public class GetAllPlantationSitesPagedQueryTests
    {
        private Mock<IUnitOfWork> uowMock = null!;
        private Mock<IPlantationSiteRepository> plantationSiteRepoMock = null!;
        private Mock<IMapper> mapperMock = null!;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            plantationSiteRepoMock = new Mock<IPlantationSiteRepository>();
            mapperMock = new Mock<IMapper>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationSiteRepoMock.Object);
        }


        [TestMethod]
        public async Task Handle_ReturnsPagedResponse_WithMappedItems()
        {
            GetAllPlantationSitesPagedQuery query = new GetAllPlantationSitesPagedQuery
            {
                PageNr = 1,
                PageSize = 2,
                Search = "test",
                SortAscending = true
            };

            List<Domain.PlantationSite> domainItems = new List<Domain.PlantationSite>
            {
                new Domain.PlantationSite
                {
                    Id = 1,
                    Name = "Site1",
                    Street = "Main Street",
                    HouseNumber = "12A",
                    City = "City1",
                    PostalCode = 1000,
                    Country = "Country1",
                    Size = 500.0,
                    GroundPlan = "GroundPlan1",
                    Zones = new List<Domain.Zone>()
                },
                new Domain.PlantationSite
                {
                    Id = 2,
                    Name = "Site2",
                    Street = "Second Street",
                    HouseNumber = "34B",
                    City = "City2",
                    PostalCode = 2000,
                    Country = "Country2",
                    Size = 300.0,
                    GroundPlan = "GroundPlan2",
                    Zones = new List<Domain.Zone>()
                }
            };

            plantationSiteRepoMock
                .Setup(r => r.GetAllPaged(query.PageNr, query.PageSize, query.Search, query.SortAscending))
                .ReturnsAsync((domainItems, domainItems.Count));

            List<PlantationSiteDto> dtoItems = new List<PlantationSiteDto>
            {
                new PlantationSiteDto
                {
                    Id = 1,
                    Name = "Site1",
                    Street = "Main Street",
                    HouseNumber = "12A",
                    City = "City1",
                    PostalCode = 1000,
                    Country = "Country1",
                    Size = 500.0,
                    GroundPlan = "GroundPlan1",
                    Zones = new List<ZoneDto>()
                },
                new PlantationSiteDto
                {
                    Id = 2,
                    Name = "Site2",
                    Street = "Second Street",
                    HouseNumber = "34B",
                    City = "City2",
                    PostalCode = 2000,
                    Country = "Country2",
                    Size = 300.0,
                    GroundPlan = "GroundPlan2",
                    Zones = new List<ZoneDto>()
                }
            };

            mapperMock.Setup(m => m.Map<IEnumerable<PlantationSiteDto>>(domainItems))
                      .Returns(dtoItems);

            GetAllPlantationSitesPagedQueryHandler handler = new GetAllPlantationSitesPagedQueryHandler(uowMock.Object, mapperMock.Object);

            PagedResponseDto<PlantationSiteDto> result = await handler.Handle(query, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual(query.PageNr, result.PageNumber);
            Assert.AreEqual(query.PageSize, result.PageSize);
            Assert.AreEqual(domainItems.Count, result.TotalItems);
            CollectionAssert.AreEqual(dtoItems.ToList(), result.Items.ToList());
        }

        [TestMethod]
        public async Task Handle_NullSearch_SetsEmptyString()
        {
            GetAllPlantationSitesPagedQuery query = new GetAllPlantationSitesPagedQuery
            {
                PageNr = 1,
                PageSize = 1,
                Search = null,
                SortAscending = true
            };

            plantationSiteRepoMock
                .Setup(r => r.GetAllPaged(query.PageNr, query.PageSize, "", query.SortAscending))
                .ReturnsAsync((new List<Domain.PlantationSite>(), 0));

            GetAllPlantationSitesPagedQueryHandler handler = new GetAllPlantationSitesPagedQueryHandler(uowMock.Object, mapperMock.Object);

            PagedResponseDto<PlantationSiteDto> result = await handler.Handle(query, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.TotalItems);
            Assert.AreEqual(0, result.Items.Count());
        }
    }
}