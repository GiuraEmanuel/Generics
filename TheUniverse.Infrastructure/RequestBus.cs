using System;
using System.Collections.Generic;

namespace iQuest.TheUniverse.Infrastructure
{
    public class RequestBus
    {
        public void RegisterHandler<TRequest, TResponse, THandler>() where THandler : IRequestHandler<TRequest, TResponse>, new()
        {
            if (HandlerFactory<TRequest, TResponse>.CreateHandler != null)
                throw new InvalidOperationException("Request handler for TRequest and TResponse is already registered.");

            HandlerFactory<TRequest, TResponse>.CreateHandler = () => new THandler();
        }

        public TResponse Send<TRequest,TResponse>(TRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));


            if (HandlerFactory<TRequest, TResponse>.CreateHandler == null)
                throw new InvalidOperationException("Request handler for the TRequest and TResponse is not registered.");

            IRequestHandler<TRequest, TResponse> requestHandler = HandlerFactory<TRequest, TResponse>.CreateHandler();

            return requestHandler.Execute(request);
        }

        private static class HandlerFactory<TRequest, TResponse>
        {
            public static Func<IRequestHandler<TRequest, TResponse>> CreateHandler { get; set; }
        }
    }
}