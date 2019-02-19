using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Helper class contains the result (success or false) of operation
    /// and additional information about it.
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Initialize the instance of the <see cref="OperationResult"/> class.
        /// </summary>
        public OperationResult()
        {
            MessageList = new List<string>();
            Success = false;
        }

        /// <summary>
        /// Success status of operation. True - success, otherwise - false.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Additional information about operation result.
        /// </summary>
        public List<string> MessageList { get; }

        /// <summary>
        /// Add additional information about operation result.
        /// </summary>
        /// <param name="message">Information to add.</param>
        public void AddMessage(string message)
        {
            MessageList.Add(message);
        }
    }
}
