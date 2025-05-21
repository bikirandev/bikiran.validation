using System;
using System.Text.RegularExpressions;

#nullable enable

namespace Bikiran.Validation
{
    /// <summary>
    /// Provides validation and parsing utilities for Git repository SSH URLs
    /// </summary>
    public class ValGit
    {
        /// <summary>
        /// Name of the Git repository
        /// </summary>
        public string RepoName { get; set; } = string.Empty;

        /// <summary>
        /// User/organization name from the repository URL
        /// </summary>
        public string User { get; set; } = string.Empty;

        /// <summary>
        /// Vendor name extracted from the domain (e.g., "github" from "github.com")
        /// </summary>
        public string Vendor { get; set; } = string.Empty;

        /// <summary>
        /// Full vendor domain from the repository URL (e.g., "github.com")
        /// </summary>
        public string VendorDomain { get; set; } = string.Empty;

        /// <summary>
        /// Parses a Git SSH URL into its constituent components
        /// </summary>
        /// <param name="gitSsh">SSH-style Git repository URL</param>
        /// <returns>ValGit object with parsed components or null if invalid format</returns>
        /// <remarks>
        /// Expected format: git@[vendor-domain]:[user]/[repo-name].git
        /// Example input: git@github.com:bikirandev/Bikiran.Validation.git
        /// Vendor is derived by removing the last part of the domain (e.g., "com" from "github.com")
        /// </remarks>
        private static ValGit? ParseFromSsh(string gitSsh)
        {
            var match = Regex.Match(gitSsh, @"^git@([^:]+):([^/]+)/(.+?)\.git$");
            if (!match.Success)
            {
                return null;
            }

            string vendorDomain = match.Groups[1].Value;
            string user = match.Groups[2].Value;
            string repoName = match.Groups[3].Value;

            // Extract vendor except the last part of the vendor domain
            string[] vendorDomainParts = vendorDomain.Split('.');
            string vendor = string.Join(".", vendorDomainParts, 0, vendorDomainParts.Length - 1);

            return new ValGit
            {
                RepoName = repoName,
                User = user,
                Vendor = vendor,
                VendorDomain = vendorDomain
            };
        }

        /// <summary>
        /// Validates a Git SSH repository URL format
        /// </summary>
        /// <param name="gitRepo">Repository URL to validate</param>
        /// <param name="title">Field name for error messages</param>
        /// <returns>ValidateStatus indicating validity</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. Matches standard Git SSH URL pattern
        /// 2. Contains valid domain structure
        /// 3. Proper repository path format
        /// Note: Only validates URL format, not repository existence
        /// </remarks>
        public static ValidateStatus IsValidGitRepoSsh(string gitRepo, string title)
        {
            var gitRepoParser = ParseFromSsh(gitRepo);
            if (gitRepoParser == null)
            {
                return new ValidateStatus { Error = true, Message = $"{title} is not a valid git repo" };
            }

            return new ValidateStatus { Error = false, Message = "" };
        }
    }
}
