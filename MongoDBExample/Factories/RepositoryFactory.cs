﻿using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBExample.DBConnection;
using MongoDBExample.Mappers;
using MongoDBExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Factories 
{
    public static class RepositoryFactory<TListDBFormat, TFieldId, TListTFilterQuery, TEntity, TDatabase, TDBFormat>
    {
        public static IRepository<TListDBFormat, TFieldId, TListTFilterQuery, TDBFormat> Create(IDBConnection<TDatabase> dbConnection, string databaseName, string document)
        {
            IMapper<TEntity, TDBFormat> mapper = MongoMapperFactory<TEntity, TDBFormat>.Create();
            IRepository<TListDBFormat, TFieldId, TListTFilterQuery, TDBFormat> repo = (IRepository < TListDBFormat, TFieldId, TListTFilterQuery, TDBFormat>)new MongoRepository((IMongoDatabase)dbConnection.GetDatabase(databaseName), document);
            return repo;
        }
    }
}
