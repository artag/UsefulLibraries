using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EmbeddedResourceService
{
    /// <summary>
    /// Service class for access to assembly embedded resources.
    /// </summary>
    public class EmbeddedResourceService : IEmbeddedResourceService
    {
        private readonly Assembly _assembly;

        /// <summary>
        /// Initialize the instance of the <see cref="EmbeddedResourceService"/> class.
        /// </summary>
        /// <param name="type">Any type from the assembly.</param>
        public EmbeddedResourceService(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            _assembly = type.GetTypeInfo().Assembly;
        }

        /// <inheritdoc />
        public Stream Get(string filename)
        {
            var assemblyName = GetAssemblyName();
            var stream = _assembly.GetManifestResourceStream(assemblyName + "." + filename);
            return stream;
        }

        private string GetAssemblyName()
        {
            var fullName = _assembly.FullName;
            return fullName.Split(',').First();
        }
    }
}
