using ControllRR.Domain.Entities;
using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControllRR.Infrastructure.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly ControllRRContext _controllRRContext;

    public DocumentRepository(ControllRRContext controllRRContext)
    {
        _controllRRContext = controllRRContext;
    }

    public async Task<IEnumerable<Document>> GetAllAsync()
    {
      
        return await _controllRRContext.Documents.ToListAsync();

    }

    public async Task AddAsync(Document document)
    {
         _controllRRContext.Documents.Add(document);
         await _controllRRContext.SaveChangesAsync();

    }
    public async Task SaveChangesAsync()
    {
      await  _controllRRContext.SaveChangesAsync();
    }

}