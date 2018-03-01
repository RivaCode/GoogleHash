using System.Linq;

using IOPath = System.IO;

namespace Scheduler.Extentions
{
    internal static class HistoryExtentions
    {
        public static void Submit(this History history, string fileName)
        {
            var dirName = IOPath.Path.Combine(IOPath.Directory.GetCurrentDirectory(), "outputs");
            if (!IOPath.Directory.Exists(dirName))
            {
                IOPath.Directory.CreateDirectory(dirName);
            }

            IOPath.File.WriteAllLines(
                IOPath.Path.Combine(dirName, fileName),
                history.Select(info => info.Aggregate("", (agg, i) => $"{agg} {i}")));
        }
    }
}
