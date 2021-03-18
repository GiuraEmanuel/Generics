using System;
using iQuest.TheUniverse.Domain;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Application.AddStar
{
    public class AddStarRequestHandler : IRequestHandler
    {
        public object Execute(object request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request is AddStarRequest addStarRequest)
            {
                string starName = addStarRequest.StarDetailsProvider.GetStarName();
                string galaxyName = addStarRequest.StarDetailsProvider.GetGalaxyName();

                return Universe.Instance.AddStar(starName, galaxyName);
            }

            throw new ArgumentException($"The request must be of type {request.GetType().FullName}.", nameof(request));
        }
    }
}