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
        public void GetSeriesTest()
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
            s2.Titre = "Scrubs";
            s2.Resume = "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !";
            s2.Nbsaisons = 9;
            s2.Nbepisodes = 184;
            s2.Anneecreation = 2001;
            s2.Network = "ABC (US)";
            expected.Add(s2);

            Serie s3 = new Serie();
            s3.Serieid = 3;
            s3.Titre = "Scrubs";
            s3.Resume = "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !";
            s3.Nbsaisons = 9;
            s3.Nbepisodes = 184;
            s3.Anneecreation = 2001;
            s3.Network = "ABC (US)";
            expected.Add(s3);

            // Act
            Task<ActionResult<IEnumerable<Serie>>> listeSeriesRecuperees = controller.GetSeries();
            //List<Serie> series = listeSeriesRecuperees.Where(s => s.Serieid <= 3).ToList();

            // Assert

        }
    }
}