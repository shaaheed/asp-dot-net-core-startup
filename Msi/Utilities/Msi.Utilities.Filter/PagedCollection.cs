﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Msi.Utilities.Filter
{
    public class PagedCollection<T>
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Offset { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
        public int Size { get; set; }
        public IList<T> Items { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        string[] Sort { get; set; }

        public PagedCollection(IList<T> items, int totalCount, IFilterOptions options)
        {
            Offset = options?.Offset;
            Limit = options?.Limit;
            Size = totalCount;
            Items = items;
            Sort = options?.OrderBy;
        }

        //public T First { get; set; }
        //public T Last { get; set; }
        //public T Next { get; set; }
        //public T Previous { get; set; }
    }
}
