using HotChocolate.Execution.Instrumentation;
using HotChocolate.Execution;
using HotChocolate.Resolvers;
using HotChocolate;
using Microsoft.Extensions.Logging;
using System;
using HotChocolate.Execution.Processing;
using Serilog;

namespace Fpl.Portal.GraphQL.Diagnostics
{
    public class LoggingExecutionDiagnosticsEventListener : ExecutionDiagnosticEventListener
    {
        private readonly ILogger<LoggingExecutionDiagnosticsEventListener>? _logger;
        public LoggingExecutionDiagnosticsEventListener(
            ILogger<LoggingExecutionDiagnosticsEventListener>? logger
        )
        {
            _logger = logger;
        }
        public override void RequestError(IRequestContext context, Exception exception)
        {
            _logger?.LogError(exception, "Exception during request");
            base.RequestError(context, exception);
        }
        public override void ResolverError(IMiddlewareContext context, IError error)
        {
            if (error.Exception != null)
                _logger?.LogError(error.Exception, "Resolver had an error: {Error}", error.Message);
            else
                _logger?.LogError("Resolver had an error: {Error}", error.Message);
            base.ResolverError(context, error);
        }
        public override void StartProcessing(IRequestContext context)
        {
            _logger?.LogDebug("GraphQL started processing");
            base.StartProcessing(context);
        }
        public override void StopProcessing(IRequestContext context)
        {
            _logger?.LogDebug("GraphQL stopped processing");
            base.StopProcessing(context);
        }
        public override void SubscriptionEventError(SubscriptionEventContext context, Exception exception) 
        {
            _logger?.LogError(exception, "SubscriptionEventError"); 
        }
        public override void SubscriptionTransportError(ISubscription subscription, Exception exception) 
        {
            _logger?.LogError(exception, "SubscriptionTransportError"); 
        }
        public override void TaskError(IExecutionTask task, IError error) 
        {
            _logger?.LogError(error.Exception, error.Message); 
        }
    }

}
