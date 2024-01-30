using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSSeries.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSSeries.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WSSeries.Controllers.Tests
{
    [TestClass()]
    public class SeriesControllerTests
    {
        private SeriesController controller;
        public SeriesControllerTests()
        {
            var builder = new DbContextOptionsBuilder<SeriesDbContext>().UseNpgsql("Server=localhost;port=5432;Database=SeriesDB; uid=postgres; password=postgres;");
            SeriesDbContext context = new SeriesDbContext(builder.Options);
            controller = new SeriesController(context);
        }

        [TestMethod()]
        public void SeriesControllerTest()
        {
            Assert.IsNotNull(controller, "Controlleur est null");
        }

        [TestMethod()]
        public void GetSeriesTest_OK()
        {
            // Arrange
            List<Serie> expected = new List<Serie>();
            Serie s1 = new Serie();
            s1.Serieid = 1;
            s1.Titre = "Scrubs";
            s1.Resume = "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !";
            s1.Nbsaisons = 9;
            s1.Nbepisodes = 184;
            s1.Anneecreation = 2001;
            s1.Network = "ABC (US)";
            expected.Add(s1);

            Serie s2 = new Serie();
            s2.Serieid = 2;
            s2.Titre = "James May's 20th Century";
            s2.Resume = "The world in 1999 would have been unrecognisable to anyone from 1900. James May takes a look at some of the greatest developments of the 20th century, and reveals how they shaped the times we live in now.";
            s2.Nbsaisons = 1;
            s2.Nbepisodes = 6;
            s2.Anneecreation = 2007;
            s2.Network = "BBC Two";
            expected.Add(s2);

            Serie s3 = new Serie();
            s3.Serieid = 3;
            s3.Titre = "True Blood";
            s3.Resume = "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...";
            s3.Nbsaisons = 7;
            s3.Nbepisodes = 81;
            s3.Anneecreation = 2008;
            s3.Network = "HBO";
            expected.Add(s3);

            // Act
            List<Serie> series = controller.GetSeries().Result.Value.Where(s => s.Serieid <= 3).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, series, "Listes non égales");
        }

        [TestMethod()]
        public void GetSerieTest_OK()
        {
            // Arrange
            Serie expected = new Serie();
            expected.Serieid = 1;
            expected.Titre = "Scrubs";
            expected.Resume = "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !";
            expected.Nbsaisons = 9;
            expected.Nbepisodes = 184;
            expected.Anneecreation = 2001;
            expected.Network = "ABC (US)";

            // Act
            Serie? result = controller.GetSerie(1).Result.Value;

            // Assert
            Assert.AreEqual(expected, result, "Séries non égales");
        }
        [TestMethod()]
        public void GetSerieTest_NonOK()
        {
            var result = controller.GetSerie(0).Result.Result;

            Assert.AreEqual(StatusCodes.Status404NotFound, ((NotFoundResult)result).StatusCode, "Pas de code 404");
        }

        [TestMethod()]
        public void DeleteSerieTest_OK()
        {
            // Arrange
            Serie serie = new Serie();
            serie.Titre = "TestDelete";
            var resultPost = controller.PostSerie(serie).Result;

            // Act
            var result = controller.DeleteSerie(serie.Serieid).Result;

            // Assert
            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");

        }
        [TestMethod()]
        public void DeleteSerieTest_NonOK()
        {
            // Act
            var result = controller.DeleteSerie(0).Result;

            // Assert
            Assert.AreEqual(StatusCodes.Status404NotFound, ((NotFoundResult)result).StatusCode, "Pas de code 404");
        }

        [TestMethod()]
        public void PostSerieTest_OK()
        {
            // Arrange
            Serie serie = new Serie();
            serie.Titre = "TestPost";

            // Act
            var result = controller.PostSerie(serie).Result;

            // Assert
            Assert.IsInstanceOfType(((CreatedAtActionResult)result.Result).Value, typeof(Serie), "Pas de type Serie");
            Assert.AreEqual(StatusCodes.Status201Created, ((CreatedAtActionResult)result.Result).StatusCode, "Pas de code 201");

        }
    }
}