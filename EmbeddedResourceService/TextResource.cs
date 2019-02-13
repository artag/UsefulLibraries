using System;
using System.IO;
using System.Threading.Tasks;

namespace EmbeddedResourceService
{
    /// <summary>
    /// Service class for access to embedded plain text resources.
    /// </summary>
    public class TextResource : EmbeddedResource, ITextResource
    {
        /// <summary>
        /// Initialize the instance of the <see cref="TextResource"/> class.
        /// </summary>
        /// <param name="type">Any type from the assembly.</param>
        public TextResource(Type type) : base(type)
        {
        }

        /// <inheritdoc />
        public string ReadToEnd(string filename)
        {
            try
            {
                using (var stream = Get(filename))
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception exception)
            {
                return string.Empty;
            }
        }

        /// <inheritdoc />
        public Task<string> ReadToEndAsync(string filename)
        {
            try
            {
                using (var stream = Get(filename))
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEndAsync();
                }
            }
            catch (Exception exc)
            {
                return Task.FromResult(string.Empty);
            }
        }
    }
}
