using System.IO;

namespace EmbeddedResourceService
{
    public interface IEmbeddedResourceService
    {
        /// <summary>
        /// Get stream from embedded resource.
        /// </summary>
        /// <param name="filename">Filename for embedded resource in solution.</param>
        /// <returns>
        /// Stream from embedded resource.
        /// If embedded resource doesn't found returns null.
        /// </returns>
        /// <example>
        /// 1) Embedded resource file at: project\res1.txt
        ///    Usage: Get("res1.txt");
        /// 2) Embedded resource file at: project\ResourcesFolder\res1.txt
        ///    Usage: Get("ResourcesFolder.res1.txt");
        /// </example>
        Stream Get(string filename);
    }
}