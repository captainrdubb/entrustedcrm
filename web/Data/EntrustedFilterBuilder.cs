using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entrusted.Web.Data.Search;
using MongoDB.Driver;

namespace Entrusted.Web.Data
{
    public class SearchFilterBuilder
    {
        public static FilterDefinition<TEntity> Build<TEntity>(ILookup<string, SearchParam> paramGroups)
        {
            if (paramGroups?.Count > 0 == false)
            {
                return Builders<TEntity>.Filter.Empty;
            }

            List<FilterDefinition<TEntity>> orDefinitions = new List<FilterDefinition<TEntity>>();
            foreach (IGrouping<string, SearchParam> group in paramGroups)
            {
                List<FilterDefinition<TEntity>> definitions = new List<FilterDefinition<TEntity>>();
                foreach (SearchParam searchParam in group)
                {
                    FilterDefinition<TEntity> definition = Builders<TEntity>.Filter.Regex(searchParam.Name, $".*{searchParam.Value.Trim()}.*");
                    definitions.Add(definition);
                }
                FilterDefinition<TEntity> orDefinition = Builders<TEntity>.Filter.Or(definitions);
                orDefinitions.Add(orDefinition);
            }

            FilterDefinition<TEntity> andDefinition = Builders<TEntity>.Filter.And(orDefinitions);

            return andDefinition;
        }
    }
}