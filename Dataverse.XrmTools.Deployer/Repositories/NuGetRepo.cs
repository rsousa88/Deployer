using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dataverse.XrmTools.Deployer.RepoInterfaces;
using NuGet.Packaging;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

namespace Dataverse.XrmTools.Deployer.Repositories
{
    public class NuGetRepo : INuGetRepo
    {
        public async Task<string> DownloadCoreToolsAsync(string toolsDir, string feed, string package)
        {
            var logger = NuGet.Common.NullLogger.Instance;
            var cancelToken = CancellationToken.None;
            var cacheCtx = new SourceCacheContext();

            var repo = Repository.Factory.GetCoreV3(feed);
            var search = await repo.GetResourceAsync<PackageSearchResource>();
            var resource = await repo.GetResourceAsync<FindPackageByIdResource>();

            var metadata = (await search.SearchAsync(package, new SearchFilter(false, SearchFilterType.IsLatestVersion), 0, 1, logger, cancelToken)).FirstOrDefault();
            var version = (await metadata.GetVersionsAsync()).Max(ver => ver.Version);

            using (var mStream = new MemoryStream())
            {
                if (!await resource.CopyNupkgToStreamAsync(package, version, mStream, cacheCtx, logger, cancelToken))
                {
                    throw new Exception($"NuGet package '{package}' was not found!");
                }

                using (var reader = new PackageArchiveReader(mStream))
                {
                    foreach (var file in await reader.GetFilesAsync(cancelToken))
                    {
                        if (Path.GetFileName(Path.GetDirectoryName(file)).Equals("coretools"))
                        {
                            using (var fStream = File.OpenWrite(Path.Combine(toolsDir, Path.GetFileName(file))))
                            using (var stream = await reader.GetStreamAsync(file, cancelToken))
                            {
                                await stream.CopyToAsync(fStream);
                            }
                        }
                    }
                }
            }

            // check solution packager tool
            var packager = new FileInfo(Path.Combine(toolsDir, "SolutionPackager.exe"));
            return packager.Exists ? packager.FullName : string.Empty;
        }
    }
}
