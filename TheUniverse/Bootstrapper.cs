using iQuest.TheUniverse.Application.AddGalaxy;
using iQuest.TheUniverse.Application.AddStar;
using iQuest.TheUniverse.Application.GetAllStars;
using iQuest.TheUniverse.Infrastructure;
using iQuest.TheUniverse.Presentation;

namespace iQuest.TheUniverse
{
    internal class Bootstrapper
    {
        private static RequestBus requestBus;

        public void Run()
        {
            requestBus = new RequestBus();
            ConfigureRequestBus();
            DisplayApplicationHeader();
            RunUserCommandProcessLoop();
        }

        private static void ConfigureRequestBus()
        {
            requestBus.RegisterHandler(typeof(AddStarRequest), typeof(AddStarRequestHandler));
            requestBus.RegisterHandler(typeof(AddGalaxyRequest), typeof(AddGalaxyRequestHandler));
            requestBus.RegisterHandler(typeof(GetAllStarsRequest), typeof(GetAllStarsRequestHandler));
        }

        private static void DisplayApplicationHeader()
        {
            ApplicationHeader applicationHeader = new ApplicationHeader();
            applicationHeader.Display();
        }

        private static void RunUserCommandProcessLoop()
        {
            Prompter prompter = new Prompter(requestBus);
            prompter.ProcessUserInput();
        }
    }
}