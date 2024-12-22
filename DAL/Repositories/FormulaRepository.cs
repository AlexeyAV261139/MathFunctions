using DAL.Entities;
using ISOCI.DAL;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class FormulaRepository
{
    private readonly ApplicationContext _context;

    public FormulaRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void Create(Formula formula)
    {
        _context.Furmulas.Add(formula);
        _context.SaveChanges();
    } 
    
    public List<Formula> GetAll() =>   
        _context.Furmulas.ToList();

    public void Delete(long id)
    {
        var formula = _context.Furmulas.Find(id) 
            ?? throw new Exception("Формулы с таким id не существует");

        _context.Furmulas.Remove(formula);
        _context.SaveChanges();
    }

    public Formula GetById(long id)
        => _context.Furmulas
        .Include(x => x.Parametrs)
        .FirstOrDefault(e => e.Id == id) 
        ?? throw new Exception("Нет формулы с таким ID");
}