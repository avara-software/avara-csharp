using System;
using Avara.Core;
using Avara.Services.AutoScribe;

namespace Avara.Services;

/// <inheritdoc/>
public sealed class AutoScribeService : IAutoScribeService
{
    readonly Lazy<IAutoScribeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAutoScribeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAvaraClient _client;

    /// <inheritdoc/>
    public IAutoScribeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AutoScribeService(this._client.WithOptions(modifier));
    }

    public AutoScribeService(IAvaraClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AutoScribeServiceWithRawResponse(client.WithRawResponse));
        _studies = new(() => new StudyService(client));
        _users = new(() => new UserService(client));
        _reports = new(() => new ReportService(client));
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

    readonly Lazy<IReportService> _reports;
    public IReportService Reports
    {
        get { return _reports.Value; }
    }
}

/// <inheritdoc/>
public sealed class AutoScribeServiceWithRawResponse : IAutoScribeServiceWithRawResponse
{
    readonly IAvaraClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAutoScribeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AutoScribeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AutoScribeServiceWithRawResponse(IAvaraClientWithRawResponse client)
    {
        _client = client;

        _studies = new(() => new StudyServiceWithRawResponse(client));
        _users = new(() => new UserServiceWithRawResponse(client));
        _reports = new(() => new ReportServiceWithRawResponse(client));
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

    readonly Lazy<IReportServiceWithRawResponse> _reports;
    public IReportServiceWithRawResponse Reports
    {
        get { return _reports.Value; }
    }
}
