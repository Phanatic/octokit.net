﻿using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Octokit.Tests.Integration
{
    public class ReleasesClientTests
    {
        public class TheGetReleasesMethod
        {
            [IntegrationTest]
            public async Task ReturnsReleases()
            {
                var github = new GitHubClient("Test Runner User Agent")
                {
                    Credentials = AutomationSettings.Current.GitHubCredentials
                };

                var releases = await github.Release.GetAll("git-tfs", "git-tfs");

                Assert.True(releases.Count > 5);
                Assert.True(releases.Any(release => release.TagName == "v0.18.0"));
            }
        }
    }
}