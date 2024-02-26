using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using study_together_api.Data;
using study_together_api.Utilities;

namespace study_together_api.Controllers;

public class DbControllerBase<T> : ControllerBase where T : DbControllerBase<T>
{
    protected DataContext _context;

    public DbControllerBase(DataContext context)
    {
        _context = context;
    }

    protected void FillPropertyValues<U> (U obj, Dictionary<string, dynamic>? props)
    {
        // Instantiate a Utility instance of `U` to set properties using Reflection
        var typeUtil = typeof(U);
        // Loop through `props` passed in and set values on `obj`
        foreach (KeyValuePair<string, dynamic> entry in props?.ToList() ?? []) 
        {
            string key = StringUtils.ToTitleCase(entry.Key);
            PropertyInfo? prop = typeUtil.GetProperty(entry.Key);
            string value = Convert.ToString(entry.Value);
            prop?.SetValue(obj, Convert.ChangeType(value, prop.PropertyType));
        }
    } 
}