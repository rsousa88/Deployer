// System
using System;

namespace Dataverse.XrmTools.Deployer.Helpers
{
    public static class VersionHelper
    {
        public static Version IncrementRevision(this Version version)
        {
            return version.AddVersion(0, 0, 0, 1);
        }
        public static Version IncrementBuild(this Version version)
        {
            return version.AddVersion(0, 0, 1, 0);
        }
        public static Version IncrementMinor(this Version version)
        {
            return version.AddVersion(0, 1, 0, 0);
        }
        public static Version IncrementMajor(this Version version)
        {
            return version.AddVersion(1, 0, 0, 0);
        }

        private static Version AddVersion(this Version current, int major, int minor, int build, int revision)
        {
            return new Version(current.Major + major, current.Minor + minor, current.Build + build, current.Revision + revision);
        }
    }
}
