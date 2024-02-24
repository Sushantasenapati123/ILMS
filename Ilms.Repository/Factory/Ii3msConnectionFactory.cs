using System.Data;

namespace Ilms.Repository.Factory
{
     public interface Ii3msConnectionFactory
    {
        /// <summary>
        /// Gets the get connection.
        /// </summary>
        /// <value>The get connection.</value>
        IDbConnection GetConnection { get; }
    }
}
