using System;
using Avara.Core;
using Avara.Services.Viewer;

namespace Avara.Services;

/// <inheritdoc/>
public sealed class ViewerService : IViewerService
{
    readonly Lazy<IViewerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IViewerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAvaraClient _client;

    /// <inheritdoc/>
    public IViewerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ViewerService(this._client.WithOptions(modifier));
    }

    public ViewerService(IAvaraClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ViewerServiceWithRawResponse(client.WithRawResponse));
        _studies = new(() => new StudyService(client));
        _users = new(() => new UserService(client));
    }

    readonly Lazy<IStudyService> _studies;
    public IStudyService Studies
    {
        get { return _studies.Value; }
    }

    readonly Lazy<IUserService> _users;
    public IUserService Users
    {
        get { return _users.Value; }
    }
}

/// <inheritdoc/>
public sealed class ViewerServiceWithRawResponse : IViewerServiceWithRawResponse
{
    readonly IAvaraClientWithRawResponse _client;

    /// <inheritdoc/>
    public IViewerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ViewerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ViewerServiceWithRawResponse(IAvaraClientWithRawResponse client)
    {
        _client = client;

        _studies = new(() => new StudyServiceWithRawResponse(client));
        _users = new(() => new UserServiceWithRawResponse(client));
    }

    readonly Lazy<IStudyServiceWithRawResponse> _studies;
    public IStudyServiceWithRawResponse Studies
    {
        get { return _studies.Value; }
    }

    readonly Lazy<IUserServiceWithRawResponse> _users;
    public IUserServiceWithRawResponse Users
    {
        get { return _users.Value; }
    }
}
