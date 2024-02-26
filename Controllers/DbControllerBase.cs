using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using study_together_api.Data;

namespace study_together_api.Controllers;

public class DbControllerBase<T> : ControllerBase where T : DbControllerBase<T>
{
    protected DataContext _context;

    public DbControllerBase(DataContext context)
    {
        _context = context;
    }
}