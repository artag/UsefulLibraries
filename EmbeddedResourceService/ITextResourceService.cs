using System.Threading.Tasks;

namespace EmbeddedResourceService
{
    public interface ITextResourceService
    {
        /// <summary>
        /// Read all characters from the embedded plain text resource.
        /// </summary>
        /// <param name="filename">Filename for embedded resource in solution.</param>
        /// <returns>
        /// Text data from embedded resource.
        /// If resource doesn't found returns empty string.
        /// </returns>
        /// <example>
        /// 1) Embedded resource file at: project\res1.txt
        ///    Usage: ReadToEnd("res1.txt");
        /// 2) Embedded resource file at: project\ResourcesFolder\res1.txt
        ///    Usage: ReadToEnd("ResourcesFolder.res1.txt");
        /// </example>
        string ReadToEnd(string filename);

        /// <summary>
        /// Read all characters from the embedded text resource asynchronously
        /// and returns them as one string.
        /// </summary>
        /// <param name="filename">Filename for embedded resource in solution.</param>
        /// <returns>
        /// Text data from embedded resource.
        /// If resource doesn't found returns empty string.
        /// </returns>
        /// <example>
        /// 1) Embedded resource file at: project\res1.txt
        ///    Usage: ReadToEndAsync("res1.txt");
        /// 2) Embedded resource file at: project\ResourcesFolder\res1.txt
        ///    Usage: ReadToEndAsync("ResourcesFolder.res1.txt");
        /// </example>
        Task<string> ReadToEndAsync(string filename);
    }
}