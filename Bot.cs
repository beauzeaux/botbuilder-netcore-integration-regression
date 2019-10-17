using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace botbuilder_integration_regression
{
    public sealed class Bot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(
            ITurnContext<IMessageActivity> turnContext,
            CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(turnContext?.Activity?.Text ?? "Echo failed");
        }
    }
}