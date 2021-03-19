using System;
using iQuest.TheUniverse.Domain;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Application.AddGalaxy
{
    public class AddGalaxyRequestHandler : IRequestHandler<AddGalaxyRequest, bool>
    {
        public bool Execute(AddGalaxyRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request is AddGalaxyRequest addGalaxyRequest)
            {
                string galaxyName = addGalaxyRequest.GalaxyDetailsProvider.GetGalaxyName();
                return Universe.Instance.AddGalaxy(galaxyName);
            }
            
            throw new ArgumentException($"The request must be of type {request.GetType().FullName}.", nameof(request));
        }
    }
}