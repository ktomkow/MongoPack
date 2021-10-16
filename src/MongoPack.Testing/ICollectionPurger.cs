﻿using System.Threading.Tasks;

namespace MongoPack.Testing
{
    public interface ICollectionPurger
    {
        /// <summary>
        /// Purge whole database
        /// </summary>
        /// <returns></returns>
        Task Purge();

        /// <summary>
        /// Purge collection
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        Task Purge(string collection);
    }
}
 