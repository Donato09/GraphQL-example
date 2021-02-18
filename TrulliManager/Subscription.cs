using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrulliManager.Database.Models;

namespace TrulliManager
{
    public class Subscription
    {

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Trullo>> OnTrulloCreate([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Trullo>("TrulloCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Trullo>> OnTrulloGet([Service] ITopicEventReceiver eventReciver, CancellationToken cancellationToken)
        {
            return await eventReciver.SubscribeAsync<string, Trullo>("ReturnedTrullo", cancellationToken);
        }

    }
}
