using InRiver.Rest.Lib.Api;

namespace InRiver.Rest.Lib.Client
{
    public interface IinRiverClient
    {
        IChannelApi ChannelApi { get; }

        IEntityApi EntityApi { get; }

        ILinkApi LinkApi { get; }

        IMediaApi MediaApi { get; }

        IModelApi ModelApi { get; }

        IQueryApi QueryApi { get; }

        ISyndicateApi SyndicateApi { get; }

        ISystemApi SystemApi { get; }

        IWorkareaApi WorkareaApi { get; }
    }
}