using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Abstract
{
    public interface IChannelRepository : IRepository<Channels>
    {
        IEnumerable<Channels> GetAllChannels();
    }
}
