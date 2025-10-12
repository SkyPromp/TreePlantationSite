using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class MessageRepository: IMessageRepository
{
    private readonly DbSet<Message> dbSet;

	public MessageRepository(BTPContext context)
	{
        this.dbSet = context.Set<Message>();
	}

    public async Task<Message> Create(Message message)
    {
        throw new NotImplementedException();
    }

    public void Delete(Message item)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Message>> GetAll(int pageNr, int pageSize)
    {
        return await dbSet.Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<Message> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Message Update(Message modifiedItem)
    {
        throw new NotImplementedException();
    }
}
