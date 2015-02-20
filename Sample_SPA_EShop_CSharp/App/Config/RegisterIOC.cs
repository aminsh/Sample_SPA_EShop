using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using DataAccess.RavenDB;
using Domain.Data;
using Domain.Model;
using Domain.Service;
using Microsoft.Practices.Unity;

namespace App.Config
{
    public static class Ioc
    {
        public static void Register()
        {
            var container = new UnityContainer();
            DependencyManager.Container = container;

            DependencyManager.Register<IUnitOfWork, RavenUnitOfWork>(Lifetime.PerRequest);
            DependencyManager.Register<IResult, Result>(Lifetime.PerRequest);

            DependencyManager.Register<CategoryService, CategoryService>(Lifetime.Singletone);
            DependencyManager.Register<ImageService, ImageService>(Lifetime.Singletone);
        }
    }
}