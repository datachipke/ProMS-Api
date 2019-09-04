using proms.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.handlers.models
{
    public class SearchModel
    {
        public int tableId { set; get; }
        public string tableName { set; get; }
        public KeyValue[] columns { set; get; }
        //public string orderField { set; get; }
        //public string orderOption { set; get; }
        //public KeyValuePair<string, string>[] keyModel { set; get; }
        //public JoinModel joinModel { set; get; }
        //public AssociateModel associateModel { set; get; }
        //public int pageNo { set; get; }
        //public int perPage { set; get; }

        public class JoinModel
        {
            public Entity[] entities { get; set; }
        }
        public class AssociateModel
        {
            public Entity[] entities { get; set; }
        }
        public class Entity
        {
            public int tableId { set; get; }
            public string tableName { set; get; }
            public string joinType { set; get; }
            public string joinField { set; get; }
            public string parentField { set; get; }
            public string refField { set; get; }
            public KeyValuePair<string, string>[] columns { set; get; }
        }
    }
}