﻿using Business.Concretes;
using DataAccess.Concretes.EntityFramework;

CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

foreach (var category in categoryManager.GetAll())
{
    Console.WriteLine(category.Name);
}