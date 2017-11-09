using RepoAndUnitOfWork.Abstract;
using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Concrete
{
    public class ChannelRepository : Repository<Channels>, IChannelRepository
    {
        public ChannelRepository(ProgramDbContext pb) : base(pb)
        {
        }

        public IEnumerable<Channels> GetAllChannels()
        {
            return dbContext.Channels.Select(x => x);
        }
    }
}
