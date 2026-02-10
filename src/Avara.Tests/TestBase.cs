using System;
using Avara;

namespace Avara.Tests;

public class TestBase
{
    protected IAvaraClient client;

    public TestBase()
    {
        client = new AvaraClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}
